/*Challenge link:https://www.codewars.com/kata/57faf32df815ebd49e000117/train/csharp
Question:
Task
Remove all exclamation marks from the end of words. Words are separated by a single space. There are no exclamation marks within a word.

Examples
remove("Hi!") === "Hi"
remove("Hi!!!") === "Hi"
remove("!Hi") === "!Hi"
remove("!Hi!") === "!Hi"
remove("Hi! Hi!") === "Hi Hi"
remove("!!!Hi !!hi!!! !hi") === "!!!Hi !!hi !hi"
*/

//***************Solution********************

//replace word bound ! with nothing.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
public class Kata{
  public static string Remove(string s) => Regex.Replace(s,@"\b!+", "");
}

//solution 2
using System.Text.RegularExpressions;
public class Kata
{
    public static string Remove(string s) => Regex.Replace(s, @"(?<=\w)!+", "");
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
 
    [Test, Description("It should work for basic tests")]
    [TestCase("Hi",    "Hi!",    TestName="Input: \"Hi!\"")]
    [TestCase("Hi",    "Hi!!!",  TestName="Input: \"Hi!!!\"")]
    [TestCase("!Hi",   "!Hi",    TestName="Input: \"!Hi\"")]
    [TestCase("!Hi",   "!Hi!",   TestName="Input: \"!Hi!\"")]
    [TestCase("Hi Hi", "Hi! Hi", TestName="Input: \"Hi! Hi\"")]
    [TestCase("!!!Hi !!hi !hi","!!!Hi !!hi!!! !hi", TestName="Input: \"!!!Hi !!hi!!! !hi\"")]
    public void SampleTest(String expected, String input)
    {
      Assert.AreEqual(expected, Kata.Remove(input));
    }
    
    private static Random rng = new Random();
    
    private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    [Test, Description("It should work for random tests too")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        StringBuilder input = new StringBuilder();
        StringBuilder expected = new StringBuilder();
        int words = rng.Next(1, 20);
        for (int w = 0; w < words; ++w)
        {
          if(w > 0) { input.Append(' '); expected.Append(' '); }
          int bangs = rng.Next(3);
          for (int b = 0; b < bangs; ++b) { input.Append('!'); expected.Append('!'); }
          int letters = rng.Next(1, 8);
          for (int l = 0; l < letters; ++l)
          { 
            char letter = chars[rng.Next(0, chars.Length)];
            input.Append(letter); expected.Append(letter);
          }
          bangs = rng.Next(3);
          for (int b = 0; b < bangs; ++b) input.Append('!');
        }
        string actual = Kata.Remove(input.ToString());
        Assert.AreEqual(expected.ToString(), actual, $"For input: {input}");
      }
    }
  }
}
