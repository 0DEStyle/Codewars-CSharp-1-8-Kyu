/*Challenge link:https://www.codewars.com/kata/5262119038c0985a5b00029f/train/csharp
Question:
Define a function that takes an integer argument and returns a logical value true or false depending on if the integer is a prime.

Per Wikipedia, a prime number ( or a prime ) is a natural number greater than 1 that has no positive divisors other than 1 and itself.

Requirements
You can assume you will be given an integer input.
You can not assume that the integer will be only positive. You may be given negative numbers as well ( or 0 ).
NOTE on performance: There are no fancy optimizations required, but still the most trivial solutions might time out. Numbers go up to 2^31 ( or similar, depending on language ). Looping all the way up to n, or n/2, will be too slow.
Example
is_prime(1)  /* false */
is_prime(2)  /* true  */
is_prime(-1) /* false */
*/

//***************Solution********************


//if n is less than 1 and 
//loop start from 2 up to (int) Sqrt(n) - 1
//get all elemenet is that n % i != 0
//return result in bool.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
  
using static System.Math;
using System.Linq;

public static class Kata{
  public static bool IsPrime(int n) =>  n > 1 && Enumerable.Range(2, (int) Sqrt(n) - 1).All(i => n % i != 0);
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static IEnumerable<TestCaseData> sampleTestCases
    {
      get
      {
        yield return new TestCaseData(0).Returns(false);
        yield return new TestCaseData(1).Returns(false);
        yield return new TestCaseData(2).Returns(true);
      }
    }
  
    [Test, TestCaseSource("sampleTestCases")]
    public bool SampleTest(int n) => Kata.IsPrime(n);
    
    private static IEnumerable<TestCaseData> fixedTestCases
    {
      get
      {
        yield return new TestCaseData(3).Returns(true);
        yield return new TestCaseData(4).Returns(false);
        yield return new TestCaseData(5).Returns(true);
        yield return new TestCaseData(6).Returns(false);
        yield return new TestCaseData(7).Returns(true);
        yield return new TestCaseData(8).Returns(false);
        yield return new TestCaseData(9).Returns(false);
        yield return new TestCaseData(73).Returns(true);
        yield return new TestCaseData(75).Returns(false);
        yield return new TestCaseData(5099).Returns(true);
        yield return new TestCaseData(-1).Returns(false);
        yield return new TestCaseData(-2).Returns(false);
      }
    }
    
    [Test, TestCaseSource("fixedTestCases")]
    public bool FixedTest(int n) => Kata.IsPrime(n);
    
    [Test, Description("Small random Tests")]
    public void SmallRandomTests()
    {
      const int Tests = 500;
      
      for (int i = 0; i < Tests; ++i)
      {
        int n = rnd.Next(1<<15);
        
        bool expected = Solution.IsPrime(n);
        bool actual = Kata.IsPrime(n);
        
        Assert.AreEqual(expected, actual, $"Incorrect answer for n={n}");
      }
    }
    
    
    [Test, Description("Large random Tests")]
    public void LargeRandomTests()
    {
      const int Tests = 500;
      
      for (int i = 0; i < Tests; ++i)
      {
        int n = rnd.Next();
        
        bool expected = Solution.IsPrime(n);
        bool actual = Kata.IsPrime(n);
        
        Assert.AreEqual(expected, actual, $"Incorrect answer for n={n}");
      }
    }
  }
  
  public static class Solution
  {
    private static Dictionary<int, bool> primesMemo = new Dictionary<int, bool>();
  
    public static bool IsPrime(int n)
    {
      // Memo Check
      if (primesMemo.ContainsKey(n)) { return primesMemo[n]; }
      
      double sqrt = Math.Sqrt(n);
      for (double i = 2; i <= sqrt; ++i)
      {
        if (n % i == 0)
        {
          primesMemo.Add(n, false);
          return false;
        }
      }
      
      primesMemo.Add(n, n >= 2);
      return n >= 2;
    }
  }
}
