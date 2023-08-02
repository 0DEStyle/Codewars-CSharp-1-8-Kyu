/*Challenge link:https://www.codewars.com/kata/52a382ee44408cea2500074c/train/csharp
Question:
Write a function that accepts a square matrix (N x N 2D array) and returns the determinant of the matrix.

How to take the determinant of a matrix -- it is simplest to start with the smallest cases:

A 1x1 matrix |a| has determinant a.

A 2x2 matrix [ [a, b], [c, d] ] or

|a  b|
|c  d|
has determinant: a*d - b*c.

The determinant of an n x n sized matrix is calculated by reducing the problem to the calculation of the determinants of n matrices ofn-1 x n-1 size.

For the 3x3 case, [ [a, b, c], [d, e, f], [g, h, i] ] or

|a b c|  
|d e f|  
|g h i|  
the determinant is: a * det(a_minor) - b * det(b_minor) + c * det(c_minor) where det(a_minor) refers to taking the determinant of the 2x2 matrix created by crossing out the row and column in which the element a occurs:

|- - -|
|- e f|
|- h i|  
Note the alternation of signs.

The determinant of larger matrices are calculated analogously, e.g. if M is a 4x4 matrix with first row [a, b, c, d], then:

det(M) = a * det(a_minor) - b * det(b_minor) + c * det(c_minor) - d * det(d_minor)
*/

//***************Solution********************
//Solve matrix determinant by hand ref: https://www.youtube.com/watch?v=CcbyMH3Noow
using System;

public class Matrix{
  
  //get the minor part of the matrix
  public static int[][] Minor(int[][] matrix, int pos){
    
		int[][] minor = new int[matrix.Length - 1][];
		for (int i = 0; i < minor.Length; i++)
			minor[i] = new int[minor.Length];

		for (int i = 1; i < matrix.Length; i++){
			for (int j = 0; j < pos; j++)
				minor[i - 1][j] = matrix[i][j];
			for (int j = pos + 1; j < matrix.Length; j++)
				minor[i - 1][j - 1] = matrix[i][j];
		}
				return minor;
	}
  
   public static int Determinant(int[][] matrix){
     //print out matrix
     /*
     for(int i = 0; i < matrix.Length; i++){
       for(int j = 0; j < matrix.Length; j++){
         Console.Write(matrix[i][j] + ",");
       }
        Console.WriteLine();
     }
     */
     
     int result = 0;
     
     //fast process
     if (matrix.Length != matrix[0].Length)
       return -1;
     if (matrix.Length == 1)
       return matrix[0][0];
     
     //using recursive method to solve n by n until it reach 2nd order.
     //shift sign for each iteration by by doing (int)Math.Pow(-1, i), because it's +, -, +, - for n by n
     //ref: https://stackoverflow.com/questions/18320079/why-pow-1-0-returns-1-instead-of-1
     //acummulate the matrix result
     for (int i = 0; i < matrix.Length; i++)
			result += (int)Math.Pow(-1, i) * matrix[0][i] * Determinant(Minor(matrix, i));

		return result;
	}
}


//****************Sample Test*****************
using NUnit.Framework;
using System;
public class SolutionTest
{

    private static int[][][] matrix =
    {
        new int[][] { new [] { 1 } },
        new int[][] { new [] { 1, 3 }, new [] { 2, 5 } },
        new int[][] { new [] { 2, 5, 3 }, new [] { 1, -2, -1 }, new [] { 1, 3, 4 } }
    };

    private static int[] expected = { 1, -1, -20 };

    private static string[] msg = { "Determinant of a 1 x 1 matrix yields the value of the one element", "Should return 1 * 5 - 3 * 2 == -1 ", "" };

    [Test]
    public void SampleTests()
    {
        for (int n = 0; n < expected.Length; n++)
            Assert.AreEqual(expected[n], Matrix.Determinant(matrix[n]), msg[n]);
    }

    private static readonly int[][][] matrix2 =
    {
        new int[][] { new[] { 5 } },
        new int[][] { new[] { 4, 6 }, new[] { 3, 8 } },
        new int[][] { new[] { 2, 4, 2 }, new[] { 3, 1, 1 }, new[] { 1, 2, 0 } },
        new int[][] { new[] { 6, 1, 1 }, new[] { 4, -2, 5 }, new[] { 2, 8, 7 } },
        new int[][] { new[] { 2, 4, -3 }, new[] { 1, 8, 7 }, new[] { 2, 3, 5 } },
        new int[][] { new[] { 1, 2, 3, 4 }, new[] { 5, 0, 2, 8 }, new[] { 3, 5, 6, 7 }, new[] { 2, 5, 3, 1 } },
        new int[][] { new[] { 2, 5, 3, 6, 3 }, new[] { 17, 5, 7, 4, 2 }, new[] { 7, 8, 5, 3, 2 }, new[] { 9, 4, -6, 8, 3 }, new[] { 2, -5, 7, 4, 2 } },
        new int[][] { new[] { 1, 2, 4, 0, 9 }, new[] { 2, 3, 4, 1, 1 }, new[] { 6, 7, 3, 9, 3 }, new[] { 2, 0, 3, 0, 2 }, new[] { 4, 5, 2, 3, 1 } },
        new int[][] { new[] { 2, 4, 5, 3, 1, 2 }, new[] { 2, 4, 7, 5, 3, 2 }, new[] { 1, 1, 0, 2, 3, 1 }, new[] { 1, 3, 9, 0, 3, 2 }, new[] { 1, 1, 2, 2, 4, 1 }, new[] { 0, 0, 4, 1, 2, 3 } },
        new int[][] { new[] { 3, 2, 1, 4, 0, 1 }, new[] { 1, 2, 3, 1, 9, 1 }, new[] { 0, 2, 1, 1, 9, 0 }, new[] { 8, 2, 1, 0, 2, 3 }, new[] { 2, 3, 4, 0, 1, 2 }, new[] { 2, 1, 0, 0, 1, 1 } }
    };

    private static int[] expected2 = { 5, 14, 10, -306, 113, 24, 2060, 1328, 88, -536 };

    private static string[] msg2 = {"Determinant of a 1 x 1 matrix yields the value of the one element",
                                "Should return 4*8 - 3*6, i.e. 14",
                                "Should return the determinant of [[2,4,2],[3,1,1],[1,2,0]], i.e. 10",
                                "Another 3 x 3 matrix",
                                "Another 3 x 3 matrix",
                                "A 4x4 matrix",
                                "A 5x5 matrix" ,
                                "Another 5x5 matrix",
                                "",
                                ""};

    [Test]
    public void MoreTests()
    {
        for (int n = 0; n < expected2.Length; n++)
            Assert.AreEqual(expected2[n], Matrix.Determinant(matrix2[n]), msg2[n]);
    }

    [Test]
    public void RandomTests()
    {
        for (int n = 0; n < 40; n++)
        {
            int mS = rand.Next(1,8);
            int[][] rMat = new int[mS][];
            for (int x = 0; x < mS; x++)
            {
                rMat[x] = new int[mS];
                for (int y = 0; y < mS; y++)
                    rMat[x][y] = rand.Next(-10,11);
            }
            int expected = SolMat101.Determinant(rMat);
            Assert.AreEqual(expected, Matrix.Determinant(rMat));
        }
    }

    [Test]
    public void RandomTestsHard()
    {
        for (int n = 0; n < 2; n++)
        {
            int mS = 10;
            int[][] rMat = new int[mS][];
            for (int x = 0; x < mS; x++)
            {
                rMat[x] = new int[mS];
                for (int y = 0; y < mS; y++)
                    rMat[x][y] = rand.Next(-10,11);
            }
            int expected = SolMat101.Determinant(rMat);
            Assert.AreEqual(expected, Matrix.Determinant(rMat));
        }
    }

    private Random rand = new Random();

    private static class SolMat101
    {

        public static int Determinant(int[][] m)
        {
            int d = 0, size = m.Length;
            if (size == 1) return m[0][0];

            for (int n = 0; n < size; n++)
            {
                int[][] newM = new int[size - 1][];
                for (int i = 0; i < size - 1; i++)
                    newM[i] = new int[size - 1];
                for (int x = 1; x < size; x++)
                    for (int y = 0; y < size; y++)
                    {
                        if (y == n) continue;
                        newM[x - 1][y + (y > n ? -1 : 0)] = m[x][y];
                    }
                d += (n % 2 != 0 ? -1 : 1) * m[0][n] * Determinant(newM);
            }
            return d;
        }
    }
}
