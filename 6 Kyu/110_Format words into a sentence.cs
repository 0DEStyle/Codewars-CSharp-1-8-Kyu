/*Challenge link:https://www.codewars.com/kata/51689e27fe9a00b126000004/train/csharp
Question:
Complete the method so that it formats the words into a single comma separated value. The last word should be separated by the word 'and' instead of a comma. The method takes in an array of strings and returns a single formatted string.

Note:

Empty string values should be ignored.
Empty arrays or null/nil/None values being passed into the method should result in an empty string being returned.
Example: (Input --> output)

['ninja', 'samurai', 'ronin'] --> "ninja, samurai and ronin"
['ninja', '', 'ronin'] --> "ninja and ronin"
[] -->""
*/

//***************Solution********************
//if words is null or there is nothing in words, return ""
//else, get all words elements that are not null of empty, join the string by ", "
//replace with pattern ", (?=\\w+$)" followed by  " and "
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
using System.Linq;

public static class Kata{
  public static string FormatWords(string[] words) =>
    words == null || !words.Any() ? "" :
    Regex.Replace(string.Join(", ", words.Where(x => !string.IsNullOrEmpty(x))), ", (?=\\w+$)", " and ");

}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class Sample_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new[] {new string[] {"one", "two", "three", "four"}})
                         .Returns("one, two, three and four")
                         .SetDescription("{\"one\", \"two\", \"three\", \"four\"} should return \"one, two, three and four\"");
        yield return new TestCaseData(new[] {new string[] {"one"}})
                         .Returns("one")
                         .SetDescription("{\"one\"} should return \"one\"");
        yield return new TestCaseData(new[] {new string[] {"one", "", "three"}})
                         .Returns("one and three")
                         .SetDescription("{\"one\", \"\", \"three\"} should return \"one and three\"");
        yield return new TestCaseData(new[] {new string[] {"", "", "three"}})
                         .Returns("three")
                         .SetDescription("{\"\", \"\", \"three\"} should return \"three\"");
        yield return new TestCaseData(new[] {new string[] {"one", "two", ""}})
                         .Returns("one and two")
                         .SetDescription("{\"one\", \"two\", \"\"} should return \"one and two\"");
        yield return new TestCaseData(new[] {new string[] {}})
                         .Returns("")
                         .SetDescription("{} should return \"\"");
        yield return new TestCaseData(null)
                         .Returns("")
                         .SetDescription("null should return \"\"");
        yield return new TestCaseData(new[] {new string[] {""}})
                         .Returns("")
                         .SetDescription("{\"\"} should return \"\"");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string[] words) => Kata.FormatWords(words);
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static string solution(string[] words)
    {
      // Edge case
      if (words == null)     { return ""; }
      
      // Filter out any empty strings
      words = words.Where(v => !String.IsNullOrEmpty(v)).ToArray();
      
      // Remaining edge cases
      if (words.Length == 1) { return words[0]; }
      if (words.Length == 0) { return ""; }
      
      // Join every word except the last
      string result = String.Join(", ", words.Take(words.Length - 1));
      
      // return result with " and <last element>"
      return result + " and " + words[words.Length - 1];
    }
    
    private static string generateRandomWord() =>
      String.Concat(new char[rnd.Next(0, 10)].Select(_ => (char)rnd.Next('a', 'z' + 1)));
    
    [Test]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string[] test = new string[rnd.Next(0, 20)].Select(_ => generateRandomWord()).ToArray();
        
        string expected = solution(test);
        string actual = Kata.FormatWords(test);
        
        string msg = $"\nIncorrect answer for words = {{ {string.Join(", ", test.Select(w => $"\"{w}\""))} }}\n";
        Assert.AreEqual(expected, actual, msg);
      }
    }
  }
}
