/*Challenge link:https://www.codewars.com/kata/59cfc09a86a6fdf6df0000f1/train/csharp
Question:
Given a string and an array of integers representing indices, capitalize all letters at the given indices.

For example:

capitalize("abcdef",[1,2,5]) = "aBCdeF"
capitalize("abcdef",[1,2,5,100]) = "aBCdeF". There is no index 100.
The input will be a lowercase string with no spaces and an array of digits.

Good luck!

Be sure to also try:

Alternate capitalization

String array revisal


*/

//***************Solution********************
//if string s contains the index of i(to make sure no index overfloat)
//conver the current character to uppercase
//else keep the current character the same.
//concat all the character and returnt the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public static class Kata{
  public static string Capitalize(string s, List<int> idxs)
  => string.Concat(s.Select((c,i)=> idxs.Contains(i) ? char.ToUpper(c) : c));
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
    public static string Capitalize(string s, List<int> idxs)
    {
      char[] sb = s.ToCharArray();
      
      foreach(int idx in idxs)
      {
        if (idx < 0 || sb.Length <= idx) { continue; }
        sb[idx] = Char.ToUpper(sb[idx]);
      }
      
      return String.Concat(sb);
    }
  }

  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("abcdef", new List<int> {1, 2, 5}).Returns("aBCdeF");
        yield return new TestCaseData("abcdef", new List<int> {1, 2, 5, 100}).Returns("aBCdeF");
        yield return new TestCaseData("abcdef", new List<int> {1, 100, 2, 5}).Returns("aBCdeF");
        yield return new TestCaseData("codewars", new List<int> {1, 3, 5, 50}).Returns("cOdEwArs");
        yield return new TestCaseData("abracadabra", new List<int> {2, 6, 9, 10}).Returns("abRacaDabRA");
        yield return new TestCaseData("codewarriors", new List<int> {5}).Returns("codewArriors");
        yield return new TestCaseData("indexinglessons", new List<int> {0}).Returns("Indexinglessons");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string s, List<int> idxs) =>
      Kata.Capitalize(s, idxs);
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
          string s = String.Concat(new char[rnd.Next(10, 22)].Select(_ => (char)rnd.Next(97, 123)));
          List<int> idxs = new int[rnd.Next(2, 8)].Select(_ => rnd.Next(0, 25)).ToList();
          
          string expected = Solution.Capitalize(s, idxs);
          
          yield return new TestCaseData(s, idxs).Returns(expected);
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string s, List<int> idxs) =>
      Kata.Capitalize(s, idxs);
  }
}
