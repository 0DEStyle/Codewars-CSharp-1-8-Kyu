/*Challenge link:https://www.codewars.com/kata/59706036f6e5d1e22d000016/train/csharp
Question:
If　a = 1, b = 2, c = 3 ... z = 26

Then l + o + v + e = 54

and f + r + i + e + n + d + s + h + i + p = 108

So friendship is twice as strong as love :-)

Your task is to write a function which calculates the value of a word based off the sum of the alphabet positions of its characters.

The input will always be made of only lowercase letters and will never be empty.
*/

//***************Solution********************
//find the ASCII value of character, then subtract by base number of 'a'(becomes 0), then add one.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
  public static int WordsToMarks(string str) => str.Sum(x=>x - 'a' + 1);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static int WordsToMarks(string str) =>
      str.Sum(v => v - 96);
  }
  
  [TestFixture]
  public class SampleTest
  {
    public static TestCaseData[] testCases = new TestCaseData[]
    {
      new TestCaseData("attitude").Returns(100).SetDescription("Input: \"attitude\"\n      Expected: 100"),
      new TestCaseData("friends").Returns(75).SetDescription("Input: \"friends\"\n      Expected: 75"),
      new TestCaseData("family").Returns(66).SetDescription("Input: \"family\"\n      Expected: 66"),
      new TestCaseData("selfness").Returns(99).SetDescription("Input: \"selfness\"\n      Expected: 99"),
      new TestCaseData("knowledge").Returns(96).SetDescription("Input: \"knowledge\"\n      Expected: 96"),
    };
  
    [Test, TestCaseSource("testCases")]
    public int Test(string str) =>
      Kata.WordsToMarks(str);
  }
  
  [TestFixture]
  public class RandomTest
  {
    public static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          string str = String.Concat(new char[rnd.Next(10, 20)].Select(_ => (char)rnd.Next(97, 123)));
          int expected = Solution.WordsToMarks(str);
          
          yield return new TestCaseData(str).Returns(expected).SetDescription($"Input: {str}\n      Expected: {expected}");
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(string str) =>
      Kata.WordsToMarks(str);
  }
}
