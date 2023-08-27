/*Challenge link:https://www.codewars.com/kata/5c09ccc9b48e912946000157/train/csharp
Question:
Kata Task
A bird flying high above a mountain range is able to estimate the height of the highest peak.

Can you?

Example
The birds-eye view
^^^^^^
 ^^^^^^^^
  ^^^^^^^
  ^^^^^
  ^^^^^^^^^^^
  ^^^^^^
  ^^^^
The bird-brain calculations    //please check image in link for better visualization.
111111
 1^^^^111
  1^^^^11
  1^^^1
  1^^^^111111
  1^^^11
  1111
111111
 12222111
  12^^211
  12^21
  12^^2111111
  122211
  1111
111111
 12222111
  1233211
  12321
  12332111111
  122211
  1111
Height = 3

Series
Bird Mountain
Bird Mountain - the river
*/

//***************Solution********************
using System.Linq;

public class Dinglemouse{
  public static int PeakHeight(char[][] mntn){
    
    //change format from ^ and empty space to 1 and 0 repectively, so that we can process the data.
    var m = mntn.Select((arr,r) => arr.Select((x,c) => x == ' ' ? 0 : 1).ToArray()).ToArray();
    
    //loop for number of repetition, row and col
    for (int e = 2; e <= (m.Length/2+1); e++){
      for (int r = 1; r < m.Length-1; r++){
        for (int c = 1; c < m[r].Length-1; c++){
          //as long as the array value is greater or equal to 1
          //select min value from the 4 values, then + 1 and store in m[r][c]
          if (m[r][c] >= 1)
            m[r][c] = new [] { m[r-1][c], m[r+1][c], m[r][c-1], m[r][c+1]}.Min() + 1;
        }
      }
    }
    
    //from array get max value and return the result.
    return m.SelectMany(x => x).Max();
  }
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class SolutionTests
{
    private static char[][] Show(char[][] m)
    {
        foreach (var row in m)
            Console.WriteLine(new string(row));
        return m;
    }

    // ======================

    [Test]
    public void Ex()
    {
        char[][] mountain =
        {
            "^^^^^^        ".ToCharArray(),
            " ^^^^^^^^     ".ToCharArray(),
            "  ^^^^^^^     ".ToCharArray(),
            "  ^^^^^       ".ToCharArray(),
            "  ^^^^^^^^^^^ ".ToCharArray(),
            "  ^^^^^^      ".ToCharArray(),
            "  ^^^^        ".ToCharArray()
        };
        Assert.AreEqual(3, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Zero()
    {
        char[][] mountain =
        {
            "      ".ToCharArray(),
            "      ".ToCharArray(),
            "      ".ToCharArray()
        };
        Assert.AreEqual(0, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Rock()
    {
        char[][] mountain =
        {
            "           ".ToCharArray(),
            "           ".ToCharArray(),
            "           ".ToCharArray(),
            "      ^    ".ToCharArray()
        };
        Assert.AreEqual(1, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void One()
    {
        char[][] mountain = 
        {
            "      ".ToCharArray(),
            "  ^^  ".ToCharArray(),
            "      ".ToCharArray()
        };
        Assert.AreEqual(1, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Two()
    {
        char[][] mountain =
        {
            "^^^^^".ToCharArray(),
            " ^^^ ".ToCharArray(),
            "^^^^^".ToCharArray()
        };
        Assert.AreEqual(2, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Twins()
    {
        char[][] mountain =
        {
            "^^^^^       ".ToCharArray(),
            "^^^^^       ".ToCharArray(),
            "^^^^^       ".ToCharArray(),
            "            ".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray()
        };
        Assert.AreEqual(4, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Misc1()
    {
        char[][] mountain =
        {
            "^^   ^^^  ^^".ToCharArray(),
            "^ ^^  ^^^   ".ToCharArray(),
            "  ^^^   ^^  ".ToCharArray(),
            "    ^^ ^^   ".ToCharArray(),
            "   ^  ^     ".ToCharArray(),
            "    ^^      ".ToCharArray(),
            " ^^^^^^^^   ".ToCharArray(),
            "  ^^^^^^^^  ".ToCharArray(),
            " ^^ ^^^   ^^".ToCharArray(),
            "^^^    ^^ ^^".ToCharArray(),
            "     ^^^^^^^".ToCharArray()
        };
        Assert.AreEqual(2, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Misc2()
    {
        char[][] mountain = 
        {
            "     ^^^^^^".ToCharArray(),
            " ^^^^^^^^  ".ToCharArray(),
            "^^^^^^^^^  ".ToCharArray(),
            "  ^^^^^^^^ ".ToCharArray(),
            "  ^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^".ToCharArray(),
            "  ^^^^^^^^^".ToCharArray(),
            "  ^^^^^^^^ ".ToCharArray(),
            "  ^^^^^^^  ".ToCharArray(),
            "  ^^^^^^   ".ToCharArray(),
            "   ^^^^^^  ".ToCharArray(),
            "    ^^^^^  ".ToCharArray(),
            "      ^^   ".ToCharArray()
        };
        Assert.AreEqual(5, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Plateau()
    {
        char[][] mountain = 
        {
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
            "^^^^^^^^^^^^^^^^^^^^^".ToCharArray(),
        };
        Assert.AreEqual(11, Dinglemouse.PeakHeight(Show(mountain)));
    }

    [Test]
    public void Volcano()
    {
        char[][] mountain =
        {
            "      ^^^^^^^^^      ".ToCharArray(),
            "    ^^^^^^^^^^^^^    ".ToCharArray(),
            "  ^^^^^^^^^^^^^^^^^  ".ToCharArray(),
            " ^^^^^^^     ^^^^^^^ ".ToCharArray(),
            "^^^^^^^       ^^^^^^^".ToCharArray(),
            "^^^^^^^       ^^^^^^^".ToCharArray(),
            "^^^^^^^       ^^^^^^^".ToCharArray(),
            " ^^^^^^^     ^^^^^^^ ".ToCharArray(),
            "  ^^^^^^^^^^^^^^^^^  ".ToCharArray(),
            "    ^^^^^^^^^^^^^    ".ToCharArray(),
            "      ^^^^^^^^^      ".ToCharArray(),
        };
        Assert.AreEqual(4, Dinglemouse.PeakHeight(Show(mountain)));
    }

    // ========================================
    // Random

    private static int PeakHeight(char[][] mountain)
    {
        char[][] copy = new char[mountain.Length][];
        for (int y = 0; y < mountain.Length; y++)
        {
            copy[y] = new char[mountain[y].Length];
            for (int x = 0; x < mountain[0].Length; x++)
            {
                copy[y][x] = mountain[y][x];
            }
        }

        bool found;
        int height = 0;
        do
        {
            found = false;
            char[][] next = new char[copy.Length][];
            for (int y = 0; y < mountain.Length; y++)
            {
                next[y] = new char[mountain[y].Length];
                for (int x = 0; x < mountain[0].Length; x++)
                {
                    next[y][x] = copy[y][x];
                    if (copy[y][x] == '^')
                    {
                        if (y == 0 || x == 0 ||
                          y == copy.Length - 1 || x == copy[0].Length - 1 ||
                          copy[y - 1][x] == ' ' || copy[y + 1][x] == ' ' ||
                          copy[y][x - 1] == ' ' || copy[y][x + 1] == ' ')
                        {
                            found = true;
                            next[y][x] = ' ';
                        }
                    }
                }
            }
            if (found)
            {
                height++;
                copy = next;
            }

        } while (found);
        return height;
    }
    private Random random = new Random();
    private char[][] MakeMountain()
    {
        var mx = random.Next(10, 101);
        var my = random.Next(10, 51);
        var mountain = new char[my][];
        for (int i = 0; i < my; i++)
            mountain[i] = new char[mx];
        var a = random.Next(mx);
        var b = random.Next(mx);
        var c = random.Next(mx);
        var d = random.Next(mx);
        for (int y = 0; y < my; y++)
        {
            for (int x = 0; x < mx; x++)
            {
                mountain[y][x] = (x >= Math.Min(a, b) && x <= Math.Max(a, b)) ? '^' : ' ';
                if (x >= Math.Min(c, d) && x <= Math.Max(c, d)) mountain[y][x] = ' ';
            }
            a += random.Next(5) - 2;
            b += random.Next(5) - 2;

            c += random.Next(3) - 1;
            d += random.Next(3) - 1;

            a = Math.Min(Math.Max(0, a), mx - 1);
            b = Math.Min(Math.Max(0, b), mx - 1);

            c = Math.Min(Math.Max(0, c), mx - 1);
            d = Math.Min(Math.Max(0, d), mx - 1);
        }
        return mountain;
    }

    [Test]
    public void Random()
    {
        for (int r = 0; r < 50; r++)
        {
            Console.WriteLine($"<hr style='width:50%%; border:none;background-color:orange;height:1px;'>Random test #{r + 1}<br/>");
            var mountain = MakeMountain();
            Show(mountain);
            int expected = PeakHeight(mountain);
            int got = Dinglemouse.PeakHeight(mountain);
            Console.WriteLine($"\n-> height = {expected}");
            Assert.AreEqual(expected, got);
        }
    }
}
