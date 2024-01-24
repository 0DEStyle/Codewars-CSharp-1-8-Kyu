/*Challenge link:https://www.codewars.com/kata/5500d54c2ebe0a8e8a0003fd/train/csharp
Question:
Find the greatest common divisor of two positive integers. The integers can be large, so you need to find a clever solution.

The inputs x and y are always greater or equal to 1, so the greatest common divisor will always be an integer that is also greater or equal to 1.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//algo ref : https://www.youtube.com/watch?app=desktop&v=_hcC9n8jJYY
public class Kata{
  public static int Gcd(int a, int b) => b == 0 ? a :Gcd(b, a % b);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(30, 12).Returns(6);
        yield return new TestCaseData(8, 9).Returns(1);
        yield return new TestCaseData(1, 1).Returns(1);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int a, int b) => Kata.Gcd(a, b);
  }
  
  [TestFixture]
  public class Fixed_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(1, 3).Returns(1);
        yield return new TestCaseData(60, 12).Returns(12);
        yield return new TestCaseData(2672, 5678).Returns(334);
        yield return new TestCaseData(10927782, 6902514).Returns(846);
        yield return new TestCaseData(1590771464, 1590771620).Returns(4);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int a, int b) => Kata.Gcd(a, b);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static int solution(int a, int b)
    {
      int d = 0;
    
      // while both numbers are even...
      while ((a & 1) == 0 && (b & 1) == 0) {
        a >>= 1;
        b >>= 1;
        ++d;
      }
      
      while (a != b) {
        if      ((a & 1) == 0) { a /= 2; }
        else if ((b & 1) == 0) { b /= 2; }
        else if (a > b)        { a = (a - b) / 2; }
        else                   { b = (b - a) / 2; }
      }
      
      return a * (int)Math.Pow(2, d);
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      const int MinValue = 1;
      const int MaxValue = int.MaxValue - 1;
      
      for (int i = 0; i < Tests; ++i)
      {
        int a = rnd.Next(MinValue, MaxValue + 1);
        int b = rnd.Next(MinValue, MaxValue + 1);
        
        int expected = solution(a, b);
        int actual = Kata.Gcd(a, b);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
