/*Challenge link:https://www.codewars.com/kata/5939ab6eed348a945f0007b2/train/csharp
Question:
When given a string of space separated words, return the word with the longest length. If there are multiple words with the longest length, return the last instance of the word with the longest length.

Example:

'red white blue' //returns string value of white

'red blue gold' //returns gold
*/

//***************Solution********************
//split the string by space
//order the each word by length, then get the last one.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Kata{
  public static string LongestWord(string stringOfWords) => stringOfWords.Split(" ").OrderBy(w => w.Length).Last();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Diagnostics;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {"a b c d e fgh", "fgh"},
      new object[] {"one two three", "three"},
      new object[] {"red blue grey", "grey"},
    };
    
    private static object[] Extra_Test_Cases = new object[]
    {
      new object[] {"a b c d each", "each"},
      new object[] {"each step", "step"},
      new object[] {"forward each step going", "forward"},
      new object[] {"brings each step going", "brings"},
      new object[] {"brings each opportunity step going", "opportunity"},
    };
    
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(string test, string expected)
    {
      Assert.AreEqual(expected, Kata.LongestWord(test));
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Extra_Test_Cases")]
    public void Extra_Test(string test, string expected)
    {
      Assert.AreEqual(expected, Kata.LongestWord(test));
    }
    
    [Test, Description("Random Tests (1000 assertions)")]
    public void Random_Test()
    {
      Stopwatch sw = new Stopwatch();
      const int tests = 1000;
      
      for (int i = 0; i < tests; ++i)
      {
        char[] words = new char[rnd.Next(80, 130)];
        for (int j = 0; j < words.Length; ++j)
        {
          if (rnd.Next(0, 10) == 0)
          {
            words[j] = ' ';
          }
          else
          {
            words[j] = (char)rnd.Next(97, 123);
          }
        }
        
        string test = new string(words);
        if (!test.Contains(' ')) { test += " thisprobablyshouldnthappen"; }
        
        string expected = test.Split(' ').OrderBy(x => x.Length).Last();
        
        sw.Start();
        string actual = Kata.LongestWord(test);
        sw.Stop();
        
        Assert.AreEqual(expected, actual);
      }
      
      Console.WriteLine("Random tests passed!\nTotal user code execution time was {0}ms over {1} assertions.", sw.Elapsed.TotalMilliseconds, tests);
    }
  }
}
