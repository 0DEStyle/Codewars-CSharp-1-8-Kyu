/*Challenge link:https://www.codewars.com/kata/5748838ce2fab90b86001b1a/train/csharp
Question:
Complete the function that calculates the area of the red square, when the length of the circular arc A is given as the input. Return the result rounded to two decimals.

image: an quater arc of a circle in a square

Note: use the π value provided in your language (Math::PI, M_PI, math.pi, etc)
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//r = 4 * A / 2π, circumference = r * r, round to 2 decimal
using System;
public class Kata{
  public static double SquareArea(double A) => Math.Round(Math.Pow(((4 * A) / (2 * Math.PI)),2) ,2);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Sample_Tests
  {
    private static double[][] testCases = new double[][]
    {
      new double[] {2, 1.62},
      new double[] {0, 0},
      new double[] {14.05, 80},
    };
  
    [Test, TestCaseSource("testCases")]
    public void SampleTest(double A, double expected)
    {
      Assert.AreEqual(expected, Kata.SquareArea(A));
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static double solution(double A) => Math.Round(Math.Pow(A * 4 / (Math.PI * 2), 2), 2);
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      const double Min = 1;
      const double Max = 50;
      
      for (int i = 0; i < Tests; ++i)
      {
        double A = rnd.NextDouble() * (Max - Min) + Min;
        
        double expected = solution(A);
        double actual = Kata.SquareArea(A);
        
        Assert.AreEqual(expected, actual, $"Should determine area of a square for a length of line A of {A}");
      }
    }
  }
}
