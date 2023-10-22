/*Challenge link:https://www.codewars.com/kata/59b24a2158ef58966e00005e/train/csharp
Question:
You receive the following letter in the mail...

Dear Valued Customer,

Thank you for your recent visit to the Nut Farm - https://www.codewars.com/kata/nut-farm

You came
You saw
You harvested our nuts
I am pleased to advise that more trees have recently come into season.

Looking forward to seeing you again soon.

Your Sincerely,
D.M. (CEO) Nut Co. 

Barely able to contain your excitement you jump in the car and head straight back to the Nut Farm.

To Recap
Harvesting nuts is very easy. We just shake the trees and the nuts fall out!

As they fall down the nuts might hit branches:

Sometimes they bounce left.
Sometimes they bounce right.
Sometimes they get stuck in the tree and don't fall out at all.
Legend
o = a nut
\ = branch. A nut hitting this branch bounces right
/ = branch. A nut hitting this branch bounces left
. = leaves, which have no effect on falling nuts
| = tree trunk, which has no effect on falling nuts
  = empty space, which has no effect on falling nuts
Kata Task
Shake the tree and count where the nuts land.

Output - An array (same width as the tree) which indicates how many nuts fell at each position ^

^ See the example tests

Notes

The nuts may be anywhere in the canopy of the tree
Nuts do not affect the falling patterns of other nuts
Falling nuts are only affected by the branches beneath them
There is not always space for nuts to fall between branches
A left/right bouncing nut may continue hitting other branches that bounces it further in that direction
If a nut bouncing in one direction bounces backwards then it will become stuck in the tree
There are no branches at the extreme left/right edges of the tree so it is not possible for a nut to fall "out of bounds"
Example
.\..\..o//.o....\o.
.\./\\.///....\.o\.
.oo.\..o/\....\\o/.
..o.o\\//.o/.......
.\/.\/.\.o\oo\o.oo.
././..//o..o..oo\o.
.\.o\oo/\.o.o..\.\.
.\.\..o/oo\...//...
            
            
(see image at the link above)
                
0000112013052200106

*/

//***************Solution********************
public class Dinglemouse{
  //function to check where the nut falls
    static int WhereFalls(char[][] tree, int x, int y){
      //if y is the same as tree length return x
      //if the current coordinate of tree is '\\', check if tree[y][x + 1] is equal to '/' , 
      //if true return -1, else recursively pass x+1,y into WhereFalls to accumulate result.
      //do the same for '/', then return the accumulated result from calling WhereFalls.
        if (y == tree.Length) return x;
        if (tree[y][x] == '\\') return tree[y][x + 1] == '/' ? -1 : WhereFalls(tree, x + 1, y);
        if (tree[y][x] == '/') return tree[y][x - 1] == '\\' ? -1 : WhereFalls(tree, x - 1, y);
        return WhereFalls(tree, x, y + 1);
    }

    public static int[] ShakeTree(char[][] tree){
      //get length of tree
        var r = new int[tree[0].Length];
      //2d loop to access each cell
        for(int i = 0; i < tree.Length; i++){
            for (int j = 0; j < tree[i].Length; j++)
              //if current cell contains 'o', pass data into WhereFalls.
              //if x is greater or equal to 0, add 1 to r[x].
                if (tree[i][j] == 'o'){
                    var x = WhereFalls(tree, j, i);
                    if (x >= 0) r[x] += 1;
                }
        }
        return r;
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
public class SolutionTests
{
    // Reference implementation for the random test cases.
    private static int[] ShakeTree(char[][] tree)
    {
        int w = tree[0].Length, h = tree.Length;
        var ret = new int[w];
        for (int y = 0; y < h; y++)
        {
            for (int x = 0; x < w; x++)
            {
                if (tree[y][x] == 'o')
                {
                    int nutx = x, nuty = y, dir = 0;
                    while (nutx > 0 && nutx < w && nuty < h - 1)
                    {
                        switch (tree[nuty + 1][nutx])
                        {
                            case '/': if (dir > 0) goto LOOPX; nutx--; dir = -1; break;
                            case '\\': if (dir < 0) goto LOOPX; nutx++; dir = 1; break;
                            default: nuty++; dir = 0; break;
                        }
                    } // this nut
                    ret[nutx]++;
                }
                LOOPX:;
            }
        }
        return ret;
    }

    private Random random = new Random();
    // Random Tree
    private char[][] MakeRandomTree()
    {
        var w = random.Next(5, 40); // width of tree
        var tree = "";

        // Branches
        for (int h = 0; h < w / 2; h++)
        {
            // height of tree
            var s = " "; // space on left of tree
            for (int x = 0; x < w; x++)
            {
                var rnd = random.NextDouble();
                var c = rnd < 0.2 ? '/' : rnd < 0.4 ? '\\' : rnd < 0.6 ? 'o' : ' ';
                s += c;
            }
            s += " "; // space on right of tree
            tree += s + "\n";
        }

        // Tree trunk
        int th = Math.Max(w / 4, 1); // height of trunk
        int tw = Math.Max(1, w * 1 / 6); // width of trunk
        for (int h = 0; h < th; h++)
        {
            // height of trunk
            var s = " "; // space on left of tree    
            for (int i = 0; i < w; i++)
            {
                s += (i >= (w - tw) / 2 && i <= tw + (w - tw) / 2) ? "|" : " ";
            }
            s += " "; // space on right of tree
            tree += s + "\n";
        }

        var rows = tree.Split("\n", StringSplitOptions.RemoveEmptyEntries);
        var ary = new char[rows.Length][];
        for (int i = 0; i < rows.Length; i++) ary[i] = rows[i].ToCharArray();
        return ary;
    }

    // ======================================================

    [Test]
    public void BounceLeft()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o o o  ",
            " /    / ",
            "   /    ",
            "  /  /  ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 1, 1, 0, 0, 1, 0, 0, 0 }, got);
    }

    [Test]
    public void RollLeft()
    {
        var tree = Utils.MakeTree(new[] 
        {
            " o      ",
            " / o o/ ",
            " ///    ",
            "   ///  ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 2, 0, 1, 0, 0, 0, 0, 0 }, got);
    }

    [Test]
    public void RollLeftAndGetStuck()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o      ",
            " / o o/ ",
            " \\//    ",
            "   \\//  ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 1, 0, 0, 0, 0, 0, 0, 0 }, got);
    }

    [Test]
    public void BounceRight()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o o o  ",
            " \\    \\ ",
            "   \\    ",
            "  \\  \\  ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 1, 1, 0, 1, 0 }, got);
    }

    [Test]
    public void RollRight()
    {
        var tree = Utils.MakeTree(new[] 
        {
            " o o  oo  ",
            " \\\\\\   \\\\ ",
            "  o \\o    ",
            "  \\\\  \\   ",
            "    ||    ",
            "    ||    ",
            "    ||    "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 1, 3, 0, 1, 0, 1 }, got);
    }

    [Test]
    public void RollRightAndGetStuck()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o o  oo  ",
            " \\\\\\   \\\\ ",
            "  o \\     ",
            "  \\\\/ \\   ",
            "    ||    ",
            "    ||    ",
            "    ||    "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 2, 0, 1, 0, 1 }, got);
    }

    [Test]
    public void RollLeftAndRight()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o        ",
            " \\\\\\\\\\\\\\  ",
            "  /////// ",
            " \\\\\\\\\\\\   ",
            "    ||    ",
            "    ||    ",
            "    ||    "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 0, 0, 1, 0, 0 }, got);
    }

    [Test]
    public void RollLeftAndRightAndGetStuck()
    {
        var tree = Utils.MakeTree(new[]
        {
            " o        ",
            " \\\\\\\\\\\\\\  ",
            "  /////// ",
            " \\\\\\\\\\\\/  ",
            "    ||    ",
            "    ||    ",
            "    ||    "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }, got);
    }

    [Test]
    public void NoObstacles()
    {
        var tree = Utils.MakeTree(new[] 
        {
            " oooooo ",
            "   o    ",
            "   ooo  ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 1, 1, 3, 2, 2, 1, 0 }, got);
    }

    [Test]
    public void NearlyAllStuck()
    {
        var tree = Utils.MakeTree(new[] 
        {
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " \\////\\ ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 0, 0, 5 }, got);
    }

    [Test]
    public void AllStuck()
    {
        var tree = Utils.MakeTree(new[]
        {
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " oooooo ",
            " \\///// ",
            "   ||   ",
            "   ||   ",
            "   ||   "
        });
        Utils.ShowTree(tree);
        var got = Dinglemouse.ShakeTree(tree);
        Utils.ShowNuts(got);
        Assert.AreEqual(new[] { 0, 0, 0, 0, 0, 0, 0, 0 }, got);
    }

    [Test]
    public void Random()
    {
        for (int r = 1; r <= 20; r++)
        {
            Console.WriteLine($"<hr>Random test #{r}\n");
            var tree = MakeRandomTree();
            Utils.ShowTree(tree);
            var expected = ShakeTree(tree);
            var got = Dinglemouse.ShakeTree(tree);
            Utils.ShowNuts(got);
            Assert.AreEqual(expected, got);
        }
    }
}
