/*Challenge link:https://www.codewars.com/kata/52dbae61ca039685460001ae/train/csharp
Question:
Create a function which accepts one arbitrary string as an argument, and return a string of length 26.

The objective is to set each of the 26 characters of the output string to either '1' or '0' based on the fact whether the Nth letter of the alphabet is present in the input (independent of its case).

So if an 'a' or an 'A' appears anywhere in the input string (any number of times), set the first character of the output string to '1', otherwise to '0'. if 'b' or 'B' appears in the string, set the second character to '1', and so on for the rest of the alphabet.

For instance:

"a   **&  cZ"  =>  "10100000000000000000000001"

*/

//***************Solution********************

//x is the current element.
//from string a-z, convert input to lower case, check if it contains x, if yes return '1' else '0'
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static string Change(string input) =>
    string.Concat("abcdefghijklmnopqrstuvwxyz".Select(x => input.ToLower().Contains(x) ? '1' : '0')); 
}

//solution 2
using System.Linq;

public class Kata
{
  public static string Change(string input)
  {
    return string.Concat(Enumerable.Range('a', 26).Select(i => input.ToLower().Contains((char) i) ? 1 : 0));
  }
}

//solution 3
  public class Kata
{
  public static string Change(string input)
  {
    int[] output = new int[26];
    
    foreach (char ch in input)
    {
      if (char.IsLetter(ch))
      {
        output[(ch % 32) - 1] = 1;
      }
    }
    
    return string.Concat(output);
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class Fixed_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("a **&  bZ")
                                     .Returns("11000000000000000000000001");
        yield return new TestCaseData("!!a$%&RgTT")
                                     .Returns("10000010000000000101000000");
        yield return new TestCaseData("")
                                     .Returns("00000000000000000000000000")
                                     .SetDescription("Empty string should return 26 '0'");
        yield return new TestCaseData("abcdefghijklmnopqrstuvwxyz")
                                     .Returns("11111111111111111111111111");
        yield return new TestCaseData("aaaaaaaaaaa")
                                     .Returns("10000000000000000000000000");
        yield return new TestCaseData("&%&%/$%$%$%$%GYtf67fg34678hgfdyd")
                                     .Returns("00010111000000000001000010");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string input) => Kata.Change(input);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static string solution(string input)
    {
      // Make a HashSet of all characters (converted to lower case) for fast lookup times
      HashSet<char> characters = new HashSet<char>(input.ToLower());
      
      // String to be mapped and returned
      string output = new String('_', 26);
      
      // Map string and concat back into string
      output = String.Concat(output.Select((_, idx) =>
      {
        // Check if characters contains the character with char code (idx + 97), 97 being the start of ASCII lowercase characters
        if (characters.Contains((char)(idx + 97)))
        {
          return "1";
        }
        else
        {
          return "0";
        }
      }));
      
      return output;
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 200;
      const int MinStringLength = 4;
      const int MaxStringLength = 100;
      const int MinChar = 0;
      const int MaxChar = 127;
      
      for (int i = Tests; i > 0; --i)
      {
        string input = new String('_', rnd.Next(MinStringLength, MaxStringLength + 1));
        
        input = String.Concat(input.Select(_ => 
          (char)rnd.Next(MinChar, MaxChar + 1)
        ));
        
        string expected = solution(input);
        string actual = Kata.Change(input);
        
        Assert.AreEqual(expected, actual, input);
      }
    }
  }
}
