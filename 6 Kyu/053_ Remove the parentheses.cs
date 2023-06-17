/*Challenge link:https://www.codewars.com/kata/5f7c38eb54307c002a2b8cc8/train/csharp
Question:
Remove the parentheses
In this kata you are given a string for example:

"example(unwanted thing)example"
Your task is to remove everything inside the parentheses as well as the parentheses themselves.

The example above would return:

"exampleexample"
Notes
Other than parentheses only letters and spaces can occur in the string. Don't worry about other brackets like "[]" and "{}" as these will never appear.
There can be multiple parentheses.
The parentheses can be nested.

*/

//***************Solution********************
//check if s contains (
//if true, replace by pattern
//( followed by whatever is in the set () zero or more times, followed by )
//replace the pattern with nothing
//repeat itself by recursion.
//if false, return s
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

namespace Solution
{
  public static class Kata
  {
    public static string RemoveParentheses(string s)
    {
      return s.Contains('(') ? RemoveParentheses(Regex.Replace(s, @"\([^()]*\)", "")) : s;
    }
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

namespace Solution 
{
  [TestFixture]
  public class SolutionTest
  {
    private string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ   ";
    private string Correct(string s)
    {
      while (s.Contains('('))
      {
        s = Regex.Replace(s, @"\([^()]*\)", "");
      }
      return s;
    }
    
    private string GenParanthesisString()
    {
      Random rnd = new Random();
      string randomString = "";
      int stringLength = rnd.Next(1, 26);
      for (int i = 0; i < stringLength; i++)
      {
        randomString += chars[rnd.Next(0, chars.Length)];
      }
      return "(" + randomString + ")";
    }
    
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("exampleexample", Kata.RemoveParentheses("example(unwanted thing)example"));
      Assert.AreEqual("example  example", Kata.RemoveParentheses("example (unwanted thing) example"));
      Assert.AreEqual("a e", Kata.RemoveParentheses("a (bc d)e"));
      Assert.AreEqual("a", Kata.RemoveParentheses("a(b(c))"));
      Assert.AreEqual("hello example  something", Kata.RemoveParentheses("hello example (words(more words) here) something"));
      Assert.AreEqual("  ", Kata.RemoveParentheses("(first group) (second group) (third group)"));    }
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i <= 100; i++)
      {
        Random rnd = new Random();
        string randomString = "";
        int stringLength = rnd.Next(1, 501);
        for(int j = 0; j < stringLength; j++)
        {
          randomString += chars[rnd.Next(0, chars.Length)];
        }
        int par_num = rnd.Next(1, 26);
        for(int p = 0; p < par_num; p++)
        {
          int rand_ind = rnd.Next(0, randomString.Length);
          randomString = randomString.Substring(0, rand_ind) + GenParanthesisString() + randomString.Substring(rand_ind);
        }
        string expected = Correct(randomString);
        string actual = Kata.RemoveParentheses(randomString);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
