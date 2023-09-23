/*Challenge link:https://www.codewars.com/kata/51f1342c76b586046800002a/train/csharp
Question:
Round any given number to the closest 0.5 step

I.E.

solution(4.2) = 4
solution(4.3) = 4.5
solution(4.6) = 4.5
solution(4.8) = 5
Round up if number is as close to previous and next 0.5 steps.

solution(4.75) == 5
*/

//***************Solution********************
//n times 2, round then divide by 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static double Solution(double n) => System.Math.Round(n * 2) / 2;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private static object[] sampleTestCases = new object[]
    {
      new object[] {4.2, 4},
      new object[] {4.4, 4.5},
      new object[] {4.6, 4.5},
      new object[] {4.8, 5},
    };
  
    [Test, TestCaseSource("sampleTestCases")]
    public void SampleTest(double n, double expected)
    {
      Assert.AreEqual(expected, Kata.Solution(n));
    }
    
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
       double test = rnd.NextDouble() * 100;
       double expected = Math.Round(test * 2) / 2;
       double actual = Kata.Solution(test);
       Assert.AreEqual(expected, actual);
      }
    }
  }
}
