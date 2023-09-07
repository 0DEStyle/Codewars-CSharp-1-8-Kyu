/*Challenge link:https://www.codewars.com/kata/530045e3c7c0f4d3420001af/train/csharp
Question:
Your task is to create a function that will take an integer and return the result of the look-and-say function on that integer. This should be a general function that takes as input any positive integer, and returns an integer; inputs are not limited to the sequence which starts with "1".

Conway's Look-and-say sequence goes like this:

Start with a number.
Look at the number, and group consecutive digits together.
For each digit group, say the number of digits, then the digit itself.
This can be repeated on its result to generate the sequence.

For example:

Start with 1.
There is one 1 --> 11
Start with 11. There are two 1 digits --> 21
Start with 21. There is one 2 and one 1 --> 1211
Start with 1211. There is one 1, one 2, and two 1s --> 111221
Sample inputs and outputs::

0 --> 10
2014 --> 12101114
9000 --> 1930
22322 --> 221322
222222222222 --> 122
*/

//***************Solution********************

//convert number to string, then replace by pattern (\d)\1*, capture group digit, matches the number '1' 0 or more
//string interpolation length of m, followed by value of m
//parse back to ulong and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Text.RegularExpressions;

public static class Kata{
  public static ulong LookSay(ulong number) =>
    UInt64.Parse(Regex.Replace(number.ToString(), @"(\d)\1*", m => $"{m.Value.Length}{m.Value[0]}"));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Text.RegularExpressions;
  
  public static class Solution
  {
    public static ulong LookSay(ulong number) =>
      UInt64.Parse(Regex.Replace(number.ToString(), @"(\d)\1*", m => $"{m.Value.Length}{m.Value[0]}"));
  }

  [TestFixture]
  public class SampleTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(0ul).Returns(10ul).SetDescription("Input: 0ul\n      Expected: 10ul");
        yield return new TestCaseData(2014ul).Returns(12101114ul).SetDescription("Input: 2014ul\n      Expected: 12101114ul");
        yield return new TestCaseData(1122ul).Returns(2122ul).SetDescription("Input: 1122ul\n      Expected: 2122ul");
        yield return new TestCaseData(22322ul).Returns(221322ul).SetDescription("Input: 22322ul\n      Expected: 221322ul");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public ulong Test(ulong number) =>
      Kata.LookSay(number);
  }
  
  [TestFixture]
  public class SimpleTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(Kata.LookSay(Kata.LookSay(1ul))).Returns(1211ul).SetDescription("Input: Kata.LookSay(Kata.LookSay(1ul))\n      Expected: 1221ul");
        yield return new TestCaseData(1ul).Returns(11ul).SetDescription("Input: 1ul\n      Expected: 11ul");
        yield return new TestCaseData(0ul).Returns(10ul).SetDescription("Input: 0ul\n      Expected: 10ul");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public ulong Test(ulong number) =>
      Kata.LookSay(number);
  }
  
  [TestFixture]
  public class LongTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(33333333333331ul).Returns(13311ul).SetDescription("Input: 33333333333331ul\n      Expected: 13311ul");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public ulong Test(ulong number) =>
      Kata.LookSay(number);
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          ulong number = (ulong)rnd.Next(0, 1000001);
          ulong expected = Solution.LookSay(number);
          
          yield return new TestCaseData(number).Returns(expected).SetDescription($"Input: {number}ul\n      Expected: {expected}ul");
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public ulong Test(ulong number) =>
      Kata.LookSay(number);
  }
}
