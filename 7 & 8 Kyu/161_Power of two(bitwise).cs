/*Challenge link:
Question:
Complete the function power_of_two/powerOfTwo (or equivalent, depending on your language) that determines if a given non-negative integer is a power of two. From the corresponding Wikipedia entry:

a power of two is a number of the form 2n where n is an integer, i.e. the result of exponentiation with number two as the base and integer n as the exponent.

You may assume the input is always valid.

Examples
power_of_two?(1024) # true
power_of_two?(4096) # true
power_of_two?(333)  # false
Beware of certain edge cases - for example, 1 is a power of 2 since 2^0 = 1 and 0 is not a power of 2.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//method https://stackoverflow.com/questions/600293/how-to-check-if-a-number-is-a-power-of-2
public static class Kata{
  public static bool PowerOfTwo(int n) => n > 0 && (n & (n - 1)) == 0;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(2).Returns(true);
        yield return new TestCaseData(4096).Returns(true);
        yield return new TestCaseData(5).Returns(false);
        yield return new TestCaseData(0).Returns(false);
        yield return new TestCaseData(1).Returns(true);
        yield return new TestCaseData(536870912).Returns(true);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public bool SampleTest(int n) => Kata.PowerOfTwo(n);
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int n = rnd.Next(0, 1000000);
        if (rnd.Next(0, 2) == 0) { n = (int)Math.Pow(2, rnd.Next(1, 31)); }
        
        bool expected = n != 0 && (n & (n - 1)) == 0;
        bool actual = Kata.PowerOfTwo(n);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
