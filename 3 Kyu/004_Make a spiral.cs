/*Challenge link:https://www.codewars.com/kata/534e01fbbb17187c7e0000c6/train/csharp
Question:
Your task, is to create a NxN spiral with a given size.

For example, spiral with size 5 should look like this:

00000
....0
000.0
0...0
00000
and with the size 10:

0000000000
.........0
00000000.0
0......0.0
0.0000.0.0
0.0..0.0.0
0.0....0.0
0.000000.0
0........0
0000000000
Return value should contain array of arrays, of 0 and 1, with the first row being composed of 1s. For example for given size 5 result should be:

[[1,1,1,1,1],[0,0,0,0,1],[1,1,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
Because of the edge-cases for tiny spirals, the size will be at least 5.

General rule-of-a-thumb is, that the snake made with '1' cannot touch to itself.
*/

//***************Solution********************
using System;

public class Spiralizor{
  
  //map visualizer
  /*
  private static void printArray(int[,] map,int n){
    for(int i = 0; i < n;i++){
        for(int j = 0; j < n;j++){
          Console.Write(map[i,j]);
          }
        Console.WriteLine();
      }
  }
  */
  
    public static int[,] Spiralize(int n){
      //n by n spiral map
        var map = new int[n, n];
        int dx = 1, dy = 0;
        int x = 0, y = 0;
        int s = n - 1;
      
      //printArray(map,n);
      

        for (int k = 0; k <= n; k++){
          // fill the outer layer at dxdy direction
            for (int j = 0; j < s; j++)
                (map[y, x], x, y) = (1, x + dx, y + dy);
          
          //Console.WriteLine($"\nIteration {k}");
          //printArray(map,n);
            // rotate clockwise
            (dx, dy) = (-dy, dx);

            if (k > 0 && k % 2 == 0) 
              s -= 2;
            if (s < 1) 
              s = 1;
        }

      //Final result visualizer
      //Console.WriteLine("\nFinal result");
      //printArray(map,n);
        return map;
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public class SpiralizorTest
  {

        [Test]
    public void Test05()
    {
        int input = 5;
        int[,] expected = new int[,]{
            {1, 1, 1, 1, 1},
            {0, 0, 0, 0, 1},
            {1, 1, 1, 0, 1},
            {1, 0, 0, 0, 1},
            {1, 1, 1, 1, 1}
        };

        int[,] actual = Spiralizor.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void Test08()
    {
        int input = 8;
        int[,] expected = new int[,]{
            {1, 1, 1, 1, 1, 1, 1, 1},
            {0, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 1, 0, 1},
            {1, 0, 1, 0, 0, 1, 0, 1},
            {1, 0, 1, 1, 1, 1, 0, 1},
            {1, 0, 0, 0, 0, 0, 0, 1},
            {1, 1, 1, 1, 1, 1, 1, 1},
        };

        int[,] actual = Spiralizor.Spiralize(input);
        Assert.AreEqual(expected, actual);
    }
    
    [Test]
    public void TestRandom([ValueSource(nameof(Sizes))]int n)
    {
        int[,] expected = SpiralizorForTests.Spiralize(n);
        int[,] actual = Spiralizor.Spiralize(n);
        Assert.AreEqual(expected, actual);
    }
    
    private readonly static Random rnd = new Random();
    private static IEnumerable<int> Sizes => Enumerable.Range(5, 50).OrderBy(_ => rnd.Next());
    
    private class SpiralizorForTests
    {
        public static int[,] Spiralize(int size)
        {

            SpiralizorForTests spiralizor = new SpiralizorForTests(size);
            return spiralizor.Spiralize();
        }

        public int[,] Grid { get; private set; }
        public int N { get; private set; }

        public SpiralizorForTests(int n)
        {
            N = n;
            Grid = new int[N, N];
        }

        private int[,] Spiralize()
        {
            int minX = 0;
            int minY = 0;
            int maxX = N;
            int maxY = N;

            bool keepGoing = true;
            bool firstRun = true;

            while (keepGoing)
            {
                for (int i = minX; i < maxX; i++)
                {
                    Grid[minY, i] = 1;
                }

                if (!firstRun)
                {
                    minX += 2;
                }
                else
                {
                    firstRun = false;
                }

                for (int i = minY; i < maxY; i++)
                {
                    Grid[i, maxX - 1] = 1;

                }

                for (int i = maxX - 1; i > minX; i--)
                {
                    Grid[maxY - 1, i] = 1;
                }

                minY += 2;
                for (int i = maxY - 1; i > minY - 1; i--)
                {
                    Grid[i, minX] = 1;
                }

                maxX -= 2;
                maxY -= 2;
                if (minX + 2 >= maxX)
                {
                    keepGoing = false;
                }
            }

            return Grid;
        }
    }
  }
}
  
