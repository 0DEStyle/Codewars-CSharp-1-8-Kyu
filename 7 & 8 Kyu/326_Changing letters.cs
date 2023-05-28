/*Challenge link:https://www.codewars.com/kata/5831c204a31721e2ae000294/train/csharp
Question:When provided with a String, capitalize all vowels

For example:

Input : "Hello World!"

Output : "HEllO WOrld!"

Note: Y is not a vowel in this kata.
*/

//***************Solution********************
//replace all vowels with uppercase, return result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public static class Kata{
  public static string Swap(string s) => Regex.Replace(s, "[aeiou]", x => x.Value.ToUpper());
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Text.RegularExpressions;
  
  public static class Solution
  {
    public static string Swap(string s) =>
      Regex.Replace(s, "([aeiou])", m => m.Value.ToUpper());
  }
  
  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("HelloWorld!").Returns("HEllOWOrld!");
        yield return new TestCaseData("Sunday").Returns("SUndAy");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string s) =>
      Kata.Swap(s);
  }
  
  [TestFixture]
  public class FixedTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("Codewars").Returns("COdEwArs");
        yield return new TestCaseData("Monday").Returns("MOndAy");
        yield return new TestCaseData("Friday").Returns("FrIdAy");
        yield return new TestCaseData("abracadabra").Returns("AbrAcAdAbrA");
        yield return new TestCaseData("AbrAcAdAbrA").Returns("AbrAcAdAbrA");
        yield return new TestCaseData("ABRACADABRA").Returns("ABRACADABRA");
        yield return new TestCaseData("aBRaCaDaBRa").Returns("ABRACADABRA");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string s) =>
      Kata.Swap(s);
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        Random rnd = new Random();
        string chars = "abcdefghiklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        
        for (int i = 0; i < 200; ++i)
        {
          var sb = new StringBuilder(rnd.Next(1, 200));
          
          for (int j = 0; j < sb.Capacity; ++j)
          {
            sb.Append(chars[rnd.Next(0, chars.Length)]);
          }
          
          string s = sb.ToString();
          string expected = Solution.Swap(s);
          
          yield return new TestCaseData(s).Returns(expected);
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string s) =>
      Kata.Swap(s);
  }
}
