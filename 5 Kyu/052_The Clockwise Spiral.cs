/*Challenge link:https://www.codewars.com/kata/536a155256eb459b8700077e/train/csharp
Question:
Do you know how to make a spiral? Let's test it!
Classic definition: A spiral is a curve which emanates from a central point, getting progressively farther away as it revolves around the point.

Your objective is to complete a function createSpiral(N) that receives an integer N and returns an NxN two-dimensional array with numbers 1 through NxN represented as a clockwise spiral.

Return an empty array if N < 1 or N is not int / number

Examples:

N = 3 Output: [[1,2,3],[8,9,4],[7,6,5]]

1    2    3    
8    9    4    
7    6    5    
N = 4 Output: [[1,2,3,4],[12,13,14,5],[11,16,15,6],[10,9,8,7]]

1   2   3   4
12  13  14  5
11  16  15  6
10  9   8   7
N = 5 Output: [[1,2,3,4,5],[16,17,18,19,6],[15,24,25,20,7],[14,23,22,21,8],[13,12,11,10,9]]

1   2   3   4   5    
16  17  18  19  6    
15  24  25  20  7    
14  23  22  21  8    
13  12  11  10  9
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class TheClockwiseSpiral{
    public static int[,] CreateSpiral(int N){
      //set n by n array
        int x = -1, y = 0, r = 0, d = 1;
        int[, ] m = new int[N, N];
      
      //rotate array right, down, lef, up direction
        while ((d += r / (N * d - d * d / 4)) < 2 * N) 
          m[y += (d % 4 - 1) % 2, x -= (d % 4 - 2) % 2] = ++r;
        return m;
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class TheClockwiseSpiralTest
{
    [Test]
    public void Test1()
    {
        var expected = new int[,] { { 1 } };
        Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(1));
    }
    [Test]
    public void Test2()
    {
        var expected = new int[,]
        {
            {1, 2},
            {4, 3},
        };
        Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(2));
    }
    [Test]
    public void Test3()
    {
        var expected = new int[,]
        {
            {1, 2, 3},
            {8, 9, 4},
            {7, 6, 5}
        };
        Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(3));
    }

    [Test]
    public void Test4()
    {
        var expected = new int[,]
        {
            {1, 2, 3, 4},
            {12, 13, 14, 5},
            {11, 16, 15, 6},
            {10, 9, 8, 7},
        };
        Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(4));
    }

    [Test]
    public void Test5()
    {
        var expected = new int[,]
        {
            {1, 2, 3, 4, 5},
            {16, 17, 18, 19, 6},
            {15, 24, 25, 20, 7},
            {14, 23, 22, 21, 8},
            {13, 12, 11, 10, 9}
        };
        Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(5));
    }

    [Test]
    public void RandomTest()
    {
        Random random = new Random();
        for (int i = 0; i < 30; i++)
        {
            var n = random.Next(100);
            var expected = Solution(n);
            Assert.AreEqual(expected, TheClockwiseSpiral.CreateSpiral(n));
        }
    }

    private static int[,] Solution(int N)
    {
        var a = new int[N, N];
        var steps = new int[] { 0, 1, 0, -1 };
        var turn = 0;
        var c = 1;
        var i = 0;
        var j = 0;
        var passed = 0;
        while (N > 0)
        {
            a[i, j] = c;
            if ((c - passed) % N == 0)
            {
                passed += N;
                if (turn % 2 == 0)
                    N--;
                turn++;
            }

            i += steps[(turn + 4) % 4];
            j += steps[(turn + 5) % 4];
            c++;
        }
        return a;
    }
}
