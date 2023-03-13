/*Challenge link:https://www.codewars.com/kata/54df2067ecaa226eca000229/train/csharp
Question:
Due to another of his misbehaved, the primary school's teacher of the young Gauß, Herr J.G. Büttner, to keep the bored and unruly young schoolboy Karl Friedrich Gauss busy for a good long time, while he teaching arithmetic to his mates, assigned him the problem of adding up all the whole numbers from 1 through a given number n.

Your task is to help the young Carl Friedrich to solve this problem as quickly as you can; so, he can astonish his teacher and rescue his recreation interval.

Here's, an example:

f(n=100) // returns 5050 
It's your duty to verify that n is a valid positive integer number. If not, please, return false (None for Python, null for C#, 0 for COBOL).

Note: the goal of this kata is to invite you to think about some 'basic' mathematic formula and how you can do performance optimization on your code. 

Advanced - experienced users should try to solve it in one line, without loops, or optimizing the code as much as they can.

Credits: this kata was inspired by the farzher's kata 'Sum of large ints' . In fact, it can be seen as a sort of prep kata for that one.
*/

//***************Solution********************
//check if n is greater than 0
//if true, n+1 * n/2
//else return null
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static long? RangeSum(long? n) => n > 0 ? n++ * n / 2 : null;
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
        yield return new TestCaseData(100L).Returns(5050L);
        yield return new TestCaseData(300L).Returns(45150L);
        yield return new TestCaseData(50000L).Returns(1250025000L);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public long? Test(long n) => Kata.RangeSum(n);
  }
  
  [TestFixture]
  public class Error_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(0).Returns(null).SetDescription("returns null if n is 0");
        yield return new TestCaseData(-10).Returns(null).SetDescription("returns null if n is less than 0");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public long? Test(long n) => Kata.RangeSum(n);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static long? solution(long n)
    {
      // Error handling
      if (n < 1) { return null; }
      
      // Triangular Number Formula:
      // https://en.wikipedia.org/wiki/Triangular_number
      return (n) * (n + 1) / 2;
    }
    
    [Test]
    public void Random1Test()
    {
      const int Tests = 100;
      const int MinValue = -2000000;
      const int MaxValue = int.MaxValue / 6;
      
      for (int i = 0; i < Tests; ++i)
      {
        long n = (long)rnd.Next(MinValue, MaxValue + 1);
        
        long? expected = solution(n);
        long? actual = Kata.RangeSum(n);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
