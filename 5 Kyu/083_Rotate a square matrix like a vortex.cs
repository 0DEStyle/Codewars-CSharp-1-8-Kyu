/*Challenge link:https://www.codewars.com/kata/58d3cf477a4ea9bb2f000103/train/csharp
Question:
#Rotate a square matrix like a vortex

Your task is to rotate a square matrix of numbers like a vortex.

In most vortices, the fluid flow velocity is greatest next to its axis and decreases in inverse proportion to the distance from the axis.
So the rotation speed increases with every ring nearer to the middle.

For this kata this means, that the outer "ring" of the matrix rotates one step. The next ring rotates two steps. The next ring rotates three steps. And so on...

The rotation is always "to the left", so against clockwise!

An example:

The given matrix:
5 3 6 1
5 8 7 4
1 2 4 3
3 1 2 2

First step:
The outer ring is rotated once to the left.
5 3 6 1  ->  1 4 3 2
5 8 7 4  ->  6 8 7 2
1 2 4 3  ->  3 2 4 1
3 1 2 2  ->  5 5 1 3

Second step:
The second ring is rotated twice to the left.
8 7 -> 7 4 -> 4 2
2 4 -> 8 2 -> 7 8 

In the whole square the second step looks like this:
1 4 3 2  ->  1 4 3 2
6 8 7 2  ->  6 4 2 2
3 2 4 1  ->  3 7 8 1
5 5 1 3  ->  5 5 1 3

No more rings. So the result is clear.
#Task Create the method for rotating like a vortex. The method has one input parameter:
The sqaure matrix as an array of arrays

Your method have to return the rotated matrix. You must not change the input array! Create a new array for the output.

The square matrix will always be at least 1x1 and at most 20x20 and of course the array will never be null.


Have fun coding it and please don't forget to vote and rank this kata! :-)

I have also created other katas. Take a look if you enjoyed this kata!
*/

//***************Solution********************
public class Kata{
  
  //main function
  //nm is the matrix itself, i is the length of matrix, pass into rotateMatrixLeft function for process.
  public static int[][] RotateLikeAVortex(int[][] matrix){
     int[][] nm = matrix;
     for (int i = 0; i < matrix.Length >> 1;i++) 
       nm = rotateMatrixLeft(nm,i);
     return nm;
  }
  
  //process matrix to rotate left.
  public static int[][] rotateMatrixLeft(int[][] m,int p){
     int s = m.Length, nc , nr = 0;
    //storage with size s
     int[][] nm = new int[s][];
    
    //set nm[y] to new int[s]
    //then store m[y][x] to nm[y][x].
     for(int y = 0; y < s; y++) {
       nm[y] = new int[s]; 
       for(int x = 0; x < s; x++) 
         nm[y][x] = m[y][x];
     }
    
    //p is the original length of matrix, s is the current length of matrix.
    //rotate current ring of the matrix and store in nm.
     for(int c = s-1-p ; c >= p; c--) {
       nc = 0; 
       for (int r = p; r < s-p; r++) 
         nm[p+nr][p+nc++] = m[r][c]; 
       nr++;
     }
     return nm;
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  
  using System.Linq;
  
  public class KataTests
  {
    [Test]
    public void ExampleTests()
    {
      var matrix = new int[][] { new int[] { 5, 3, 6, 1 },
                                 new int[] { 5, 8, 7, 4 },
                                 new int[] { 1, 2, 4, 3 },
                                 new int[] { 3, 1, 2, 2 } };
                               
      var expected = new int[][] { new int[] { 1, 4, 3, 2 },
                                   new int[] { 6, 4, 2, 2 },
                                   new int[] { 3, 7, 8, 1 },
                                   new int[] { 5, 5, 1, 3 } };
      
      var actual = Kata.RotateLikeAVortex(matrix);
      var message = "Your result:\n" + MatrixToString(actual) + "\n\nExpected result:\n" + MatrixToString(expected);
      Assert.AreEqual(expected, actual, message);      
    }
    
    [Test]
    public void ExtendedTests()
    {
      var matrix1 = new int[][] { new int[] { 3 } };
      var expected1 = new int[][] { new int[] { 3 } };
      var actual1 = Kata.RotateLikeAVortex(matrix1);
      var message1 = "Your result:\n" + MatrixToString(actual1) + "\n\nExpected result:\n" + MatrixToString(expected1);
      Assert.AreEqual(expected1, actual1, message1);
      
      var matrix2 = new int[][] { new int[] { 3, 5 },
                                  new int[] { 4, 1 } };
      
      var expected2 = new int [][] { new int[] { 5, 1 },
                                     new int[] { 3, 4 } };
      var actual2 = Kata.RotateLikeAVortex(matrix2);
      var message2 = "Your result:\n" + MatrixToString(actual2) + "\n\nExpected result:\n" + MatrixToString(expected2);
      Assert.AreEqual(expected2, actual2, message2);
      
      var matrix7 = new int[][] { new int[] { 3, 5, 1, 2, 8, 4, 7 },
                                  new int[] { 3, 0, 1, 3, 8, 2, 7 },
                                  new int[] { 3, 2, 4, 4, 9, 9, 7 },
                                  new int[] { 3, 0, 1, 8, 8, 4, 7 },
                                  new int[] { 3, 5, 3, 7, 3, 5, 7 },
                                  new int[] { 3, 2, 1, 2, 1, 4, 7 },
                                  new int[] { 4, 1, 0, 1, 9, 4, 3 } };
      
      var expected7 = new int [][] { new int[] { 7, 7, 7, 7, 7, 7, 3 },
                                     new int[] { 4, 4, 1, 2, 1, 2, 4 },
                                     new int[] { 8, 5, 3, 1, 4, 5, 9 },
                                     new int[] { 2, 4, 7, 8, 4, 0, 1 },
                                     new int[] { 1, 9, 3, 8, 9, 2, 0 },
                                     new int[] { 5, 2, 8, 3, 1, 0, 1 },
                                     new int[] { 3, 3, 3, 3, 3, 3, 4 } };
      var actual7 = Kata.RotateLikeAVortex(matrix7);
      var message7 = "Your result:\n" + MatrixToString(actual7) + "\n\nExpected result:\n" + MatrixToString(expected7);
      Assert.AreEqual(expected7, actual7, message7);
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int[][], int[][]> myRotateLikeAVortex = delegate (int[][] matrix)
      {
        var nArr = new int[matrix.Length][];
        for(var i=0;i<matrix.Length;i++)
        {
          nArr[i] = new int[matrix.Length];
        }
        for(var h=0;h<(int)(matrix.Length/2);h++)
        {
          for(var i=h;i<matrix.Length-h;i++)
          {
            for(var j=h;j<matrix.Length-h;j++)
            {
              nArr[matrix.Length-1-j][i] = matrix[i][j];    
            }
          }
          matrix = new int[matrix.Length][];
          for(var i=0;i<matrix.Length;i++)
          {
            matrix[i] = nArr[i].ToArray();
          }
        }
        return matrix;
      };
      
      for(var r=0;r<20;r++)
      {
        var n = rand.Next(1,21);
        var matrix = Enumerable.Range(0,n).Select(a => Enumerable.Range(0,n).Select(b => rand.Next(0,10)).ToArray()).ToArray();
        
        var expected = myRotateLikeAVortex(matrix);
        var actual = Kata.RotateLikeAVortex(matrix);
        var message = "Your result:\n" + MatrixToString(actual) + "\n\nExpected result:\n" + MatrixToString(expected);
        
        Assert.AreEqual(expected, actual, message);
      }
    }
    
    private String MatrixToString(int[][] matrix)
    {
      return String.Join("\n", matrix.Select(a => String.Join(", ", a)));
    }
  }
}
