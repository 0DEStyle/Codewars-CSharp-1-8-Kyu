/*Challenge link:https://www.codewars.com/kata/51f2d1cafc9c0f745c00037d/train/csharp
Question:
Complete the solution so that it returns true if the first argument(string) passed in ends with the 2nd argument (also a string).

Examples:

solution('abc', 'bc') // returns true
solution('abc', 'd') // returns false
*/


//***************Solution********************
//check the the variable "str" with ending variable "ending" using the method "EndsWith", then simiplfied into one line by using an Enumerable methods.

public class Kata
{
  public static bool Solution(string str, string ending) => str.EndsWith(ending);
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
      new object[] {"samurai", "ai", true},
      new object[] {"sumo", "omo", false},
      new object[] {"ninja", "ja", true},
      new object[] {"sensei", "i", true},
      new object[] {"samurai", "ra", false},
      new object[] {"abc", "abcd", false},
      new object[] {"abc", "abc", true},
      new object[] {"abcabc", "bc", true},
      new object[] {"ails", "fails", false},
      new object[] {"fails", "ails", true},
      new object[] {"this", "fails", false},
      new object[] {"abc", "", true},
      new object[] {":-)", ":-(", false},
      new object[] {"!@#$%^&*() :-)", ":-)", true},
      new object[] {"abc\n", "abc", false},
    };
  
    [Test, TestCaseSource("sampleTestCases")]
    public void SampleTest(string str, string ending, bool expected)
    {
      Assert.AreEqual(expected, Kata.Solution(str, ending));
    }
  }
}
