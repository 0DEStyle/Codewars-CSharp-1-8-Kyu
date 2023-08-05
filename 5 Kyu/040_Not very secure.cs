/*Challenge link:https://www.codewars.com/kata/526dbd6c8c0eb53254000110/train/csharp
Question:
In this example you have to validate if a user input string is alphanumeric. The given string is not nil/null/NULL/None, so you don't have to check that.

The string has the following conditions to be alphanumeric:

At least one character ("" is not valid)
Allowed characters are uppercase / lowercase latin letters and digits from 0 to 9
No whitespaces / underscore
*/

//***************Solution********************
//check in string s, if character is a letter or digit, and the string is not emptu or null
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static bool Alphanumeric(string s) => s.All(x => Char.IsLetterOrDigit(x)) && !string.IsNullOrEmpty(s);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class Sample_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("Mazinkaiser").Returns(true);
        yield return new TestCaseData("hello world_").Returns(false);
        yield return new TestCaseData("PassW0rd").Returns(true);
        yield return new TestCaseData("     ").Returns(false);
      }
    }
    
    [Test, TestCaseSource("testCases")]
    public bool Test(string str) => Kata.Alphanumeric(str);
  }
  
  [TestFixture]
  public class Extra_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("").Returns(false);
        yield return new TestCaseData("\n\t\n").Returns(false);
        yield return new TestCaseData("ciao\n$$_").Returns(false);
        yield return new TestCaseData("__ * __").Returns(false);
        yield return new TestCaseData("&)))(((").Returns(false);
        yield return new TestCaseData("43534h56jmTHHF3k").Returns(true);
      }
    }
    
    [Test, TestCaseSource("testCases")]
    public bool Test(string str) => Kata.Alphanumeric(str);
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789 _!";
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Concat(new char[rnd.Next(0, 31)].Select(_ => chars[rnd.Next(0, chars.Length)]));
        
        bool expected = new Regex("^[a-zA-Z0-9]+$").Match(test).Success;
        bool actual = Kata.Alphanumeric(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
