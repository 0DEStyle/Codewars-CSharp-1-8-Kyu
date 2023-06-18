/*Challenge link:https://www.codewars.com/kata/5520714decb43308ea000083/train/csharp
Question:
Given two numbers x and n, calculate the (positive) nth root of x; this means that being r = result, r^n = x

Examples
x = 4     n = 2  -->  2    # the square root of 4 is 2     2^2 = 4
x = 8     n = 3  -->  2    # the cube root of 8 is 2       2^3 = 8
x = 256   n = 4  -->  4    # the 4th root of 256 is 4      4^4 = 256
x = 9     n = 2  -->  3    # the square root of 9 is 3     3^2 = 9
x = 6.25  n = 2  -->  2.5  #                             2.5^2 = 6.25
Notes:
4 <= x < 10 ^ 20
4 <= n <= 50
Good luck!
*/

//***************Solution********************
//apply formula
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
namespace NthRoot
{
  public class Kata
  {
    public static double FindRoot(double x, int n)
    {
      return Math.Pow(x, 1.0 / n);
    }
  }
}

//****************Sample Test*****************
namespace NthRoot 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  [TestFixture]
  public class FixedTest
  {
    
    [TestCaseSource(nameof(GenerateTestCases))]
    public static void FixedTests((double, int, double) testCase)
    {
      var (x, n, expected) = testCase;
      double actual = Kata.FindRoot(x, n);
      Assert.AreEqual(expected, actual, 1e-9);
    }
    
    public static IEnumerable<(double, int, double)> GenerateTestCases() {
      yield return (4.0, 2, 2.0);
      yield return (8.0, 3, 2.0);
      yield return (256.0, 4, 4.0);
      yield return (9.0, 2, 3.0);
      yield return (6.25, 2, 2.5);
    }        
  }  
  
  [TestFixture]
  public class RandomTest
  {

    [TestCaseSource(nameof(GenerateTestCases))]
    public static void RandomTests((double , int) testCase)
    {
      var (x, n) = testCase;
      double expected =  Math.Pow(x, 1.0 / n);
      double actual = Kata.FindRoot(x, n);
      Assert.AreEqual(expected, actual, 1e-9);
    }
    
    public static IEnumerable<(double, int)> GenerateTestCases() {
      Random rand = new Random();
      for(int i = 0; i < 50; i++)
      {
        double x = rand.NextDouble() * 1e15;
        int n = rand.Next(4, 50);
        yield return (x, n);
      }
    }    
  }
}
