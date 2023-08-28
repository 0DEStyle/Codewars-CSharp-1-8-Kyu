/*Challenge link:https://www.codewars.com/kata/526233aefd4764272800036f/train/csharp
Question:
Write a function that accepts two square matrices (N x N two dimensional arrays), and return the sum of the two. Both matrices being passed into the function will be of size N x N (square), containing only integers.

How to sum two matrices:

Take each cell [n][m] from the first matrix, and add it with the same [n][m] cell from the second matrix. This will be cell [n][m] of the solution matrix.

Visualization:

|1 2 3|     |2 2 1|     |1+2 2+2 3+1|     |3 4 4|
|3 2 1|  +  |3 2 3|  =  |3+3 2+2 1+3|  =  |6 4 4|
|1 1 1|     |1 1 3|     |1+1 1+1 1+3|     |2 2 4|
Example
matrixAddition(
  [ [1, 2, 3],
    [3, 2, 1],
    [1, 1, 1] ],
//      +
  [ [2, 2, 1],
    [3, 2, 3],
    [1, 1, 3] ] )

// returns:
  [ [3, 4, 4],
    [6, 4, 4],
    [2, 2, 4] ]
*/

//***************Solution********************
public class Kata{
  public static int[][] MatrixAddition(int[][] a, int[][] b){
    
    //same dimension, so add element with the same row and col 
    for(int i=0; i<a.Length; i++)
        for(int j=0; j<a.Length; j++)
            a[i][j]+=b[i][j];
    return a;
  }
}


//method 2
using System;
using System.Linq;

public class Kata
{
  public static int[][] MatrixAddition(int[][] a, int[][] b) => a.Select((r, i) => r.Select((n, j) => n + b[i][j]).ToArray()).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new int[][] {new int[] {3, 5}, 
                                   new int[] {3, 5}}, Kata.MatrixAddition(new int[][] {new int[] {1, 2}, 
                                                                                       new int[] {1, 2}}, 
                                                                                       new int[][] {new int[] {2, 3}, 
                                                                                                    new int[] {2, 3}}));
    }
    
    [Test]
    public void ExtraTest()
    {
      Assert.AreEqual(new int[][] {new int[] {3}}, Kata.MatrixAddition(new int[][] {new int[] {1}}, 
                                                                                    new int[][] {new int[] {2}}));
      Assert.AreEqual(new int[][] {new int[] {3, 4, 4}, 
                                   new int[] {6, 4, 4},
                                   new int[] {2, 2, 4}}, Kata.MatrixAddition(new int[][] {new int[] {1, 2, 3}, 
                                                                                          new int[] {3, 2, 1},
                                                                                          new int[] {1, 1, 1}},
                                                                                          new int[][] {new int[] {2, 2, 1}, 
                                                                                                       new int[] {3, 2, 3},
                                                                                                       new int[] {1, 1, 3}}));
    }
    
    private static Random rnd = new Random();
    
    public static int[][] solution(int[][] a, int[][] b) =>
      ((int[][])(a.Clone())).Select((v1, i) =>
        v1.Select((v2, j) =>
          v2 + b[i][j]).ToArray()).ToArray();
    
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int size = rnd.Next(2, 8);
        int[][] a = new int[size][].Select(_ => new int[size].Select(__ => rnd.Next(1, 100)).ToArray()).ToArray();
        int[][] b = new int[size][].Select(_ => new int[size].Select(__ => rnd.Next(1, 100)).ToArray()).ToArray();
        
        int[][] cloneA = (int[][])a.Clone();
        int[][] cloneB = (int[][])b.Clone();
        
        int[][] expected = solution(a, b);
        int[][] actual = Kata.MatrixAddition(a, b);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
