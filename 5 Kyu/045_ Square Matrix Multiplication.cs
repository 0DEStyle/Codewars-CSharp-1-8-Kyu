/*Challenge link:https://www.codewars.com/kata/5263a84ffcadb968b6000513/train/csharp
Question:
Write a function that accepts two square (NxN) matrices (two dimensional arrays), and returns the product of the two. Only square matrices will be given.

How to multiply two square matrices:

We are given two matrices, A and B, of size 2x2 (note: tests are not limited to 2x2). Matrix C, the solution, will be equal to the product of A and B. To fill in cell [0][0] of matrix C, you need to compute: A[0][0] * B[0][0] + A[0][1] * B[1][0].

More general: To fill in cell [n][m] of matrix C, you need to first multiply the elements in the nth row of matrix A by the elements in the mth column of matrix B, then take the sum of all those products. This will give you the value for cell [m][n] in matrix C.

Example
  A         B          C
|1 2|  x  |3 2|  =  | 5 4|
|3 2|     |1 1|     |11 8|
Detailed calculation:

C[0][0] = A[0][0] * B[0][0] + A[0][1] * B[1][0] = 1*3 + 2*1 =  5
C[0][1] = A[0][0] * B[0][1] + A[0][1] * B[1][1] = 1*2 + 2*1 =  4
C[1][0] = A[1][0] * B[0][0] + A[1][1] * B[1][0] = 3*3 + 2*1 = 11
C[1][1] = A[1][0] * B[0][1] + A[1][1] * B[1][1] = 3*2 + 2*1 =  8
Link to Wikipedia explaining matrix multiplication (look at the square matrix example): http://en.wikipedia.org/wiki/Matrix_multiplication

A more visual explanation of matrix multiplication: http://matrixmultiplication.xyz
*/

//***************Solution********************
using System;

public class Kata{
    public static int[,] MatrixMultiplication(int[,] a, int[,] b){
      //create n by n array
        int n = a.GetLength(0);
        int [,] matrix = new int[n, n];
        
      //create format using loops and generate result.
        for (int i = 0; i < n; i++)
            for (int j = 0; j < n; j++)
                for (int k = 0; k < n; k++)
                    matrix[i, j] += a[i, k] * b[k, j];
        return matrix;
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class KataTest
{
    private int[,] Solution(int[,] a, int[,] b)
    {
        int n = a.GetLength(0);
        int[,] result = new int[n, n];
        for (int i = 0; i < n; ++i)
            for (int j = 0; j < n; ++j)
                for (int c = 0; c < n; ++c)
                    result[i, j] += a[i, c] * b[c, j];
        return result;
    }

    [Test]
    public void ExampleTest()
    {
        int[,] a = { { 1, 2 }, { 3, 2 } };
        int[,] b = { { 3, 2 }, { 1, 1 } };
        int[,] expected = { { 5, 4 }, { 11, 8 } };
        int[,] actual = Kata.MatrixMultiplication(a, b);
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void BasicTest()
    {
        {
            int[,] a = { { 9, 7 }, { 0, 1 } };
            int[,] b = { { 1, 1 }, { 4, 12 } };
            int[,] expected = { { 37, 93 }, { 4, 12 } };
            int[,] actual = Kata.MatrixMultiplication(a, b);
            Assert.AreEqual(expected, actual);
        }

        {
            int[,] a = { { 1, 2, 3 }, { 3, 2, 1 }, { 2, 1, 3 } };
            int[,] b = { { 4, 5, 6 }, { 6, 5, 4 }, { 4, 6, 5 } };
            int[,] expected = { { 28, 33, 29 }, { 28, 31, 31 }, { 26, 33, 31 } };
            int[,] actual = Kata.MatrixMultiplication(a, b);
            Assert.AreEqual(expected, actual);
        }
    }

    private static Random rnd = new Random();
    private static int RandomSize() => rnd.Next(2, 12);
    private static int RandomElement() => rnd.Next(21) - 10;

    [Test]
    public void RandomTestSmallMatrix()
    {
        for (int test = 0; test < 100; test++)
            RunTest(RandomSize());
    }

    [Test]
    public void RandomTestLargeMatrix()
    {
        for (int test = 0; test < 100; test++)
            RunTest(100);
    }

    private void RunTest(int size)
    {
        var a = new int[size, size];
        var b = new int[size, size];
        for (int j = 0; j < size; j++)
        {
            for (int k = 0; k < size; k++)
            {
                a[j, k] = RandomElement();
                b[j, k] = RandomElement();
            }
        }
        var expected = Solution(a, b);
        var actual = Kata.MatrixMultiplication(a, b);
        Assert.AreEqual(expected, actual);
    }
}
