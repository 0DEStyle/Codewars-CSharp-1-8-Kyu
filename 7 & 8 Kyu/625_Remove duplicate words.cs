/*Challenge link:https://www.codewars.com/kata/5b39e3772ae7545f650000fc/train/csharp
Question:
Your task is to remove all duplicate words from a string, leaving only single (first) words entries.

Example:

Input:

'alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta'

Output:

'alpha beta gamma delta'
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
➖➖🟨🟨
➖➖🟨🔳🟧
🟨🟨🟨🟨
🟨🟨🟨🟨
➖🟧🟧
Pattern:
(?<=\b\1\b.*) : positive look ahead, word boundary, matches capture group 1, word boundary, any character except line break
(\b[\w-]+\b\ ?): capture group 1, word boundary, matches any character, matches '-', once or more, word boundary, between 0 and 1

RegexOptions.RightToLeft : Specifies that the search will be from right to left instead of from left to right.

replace with nothing ""

Trim the end

*/
using System.Text.RegularExpressions;
public static class Kata{
  public static string RemoveDuplicateWords(string s) => 
    Regex.Replace(s, @"(?<=\b\1\b.*)(\b[\w-]+\b\ ?)", "",RegexOptions.RightToLeft).TrimEnd();
}

/no regex
using System.Linq;

public static class Kata
{
  public static string RemoveDuplicateWords(string s)
  {
      return string.Join(" ", s.Split(' ').Distinct());
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  public class TestHelpers
  {
    protected static Random rnd = new Random();
    protected static String[] words = "Alfa, Bravo, Charlie, Delta, Echo, Foxtrot, Golf, Hotel, India, Juliett, Kilo, Lima, Mike, November, Oscar, Papa, Quebec, Romeo, Sierra, Tango, Uniform, Victor, Whiskey, X-ray, Yankee, Zulu".ToLower().Split(new string[] { ", " }, StringSplitOptions.None);
    
    protected static string solution(string s) => String.Join(" ", s.Split(' ').Distinct());
    protected static string getString(int length = 20)
    {
      return String.Join(" ", new string[length].Select(v => words[rnd.Next(0, words.Length)]));
    }
  }

  [TestFixture, Description("Example tests")]
  public class ExampleTests
  {
    [Test, Description("Should handle sample case")]
    public void ExampleTest()
    {
      Assert.That(Kata.RemoveDuplicateWords("alpha beta beta gamma gamma gamma delta alpha beta beta gamma gamma gamma delta"), Is.EqualTo("alpha beta gamma delta"));
    }
  }
  
  [TestFixture, Description("Random tests")]
  public class RandomTests : TestHelpers
  {
    [Test, Description("Should handle random cases")]
    public void ExampleTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string testCase = getString(rnd.Next(20, 50));
        
        string actual = Kata.RemoveDuplicateWords(testCase);
        string expected = solution(testCase);
        
        Assert.That(actual, Is.EqualTo(solution(testCase)));
      }
    }
  }
}
