/*Challenge link:https://www.codewars.com/kata/596fba44963025c878000039/train/csharp
Question:
An AI has infected a text with a character!!

This text is now fully mutated to this character.

If the text or the character are empty, return an empty string.
There will never be a case when both are empty as nothing is going on!!

Note: The character is a string of length 1 or an empty string.

Example
text before = "abc"
character   = "z"
text after  = "zzz"
*/

//***************Solution********************

//find the length of text, then store the same amount of characters in string, return the result.
public class Kata{
  public static string Contamination(string text, string character) {
    string str = "";
    for(int i = 0; i < text.Length;i++)
      str += character;
    return str;
  }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata
{
  public static string Contamination(string text, string character)
  {
    return String.Join("", Enumerable.Repeat(character, text.Length));
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("zzz", Kata.Contamination("abc", "z"));
      Assert.AreEqual("", Kata.Contamination("", "z"));
      Assert.AreEqual("", Kata.Contamination("abc", String.Empty));
      Assert.AreEqual("&&&&&&&&", Kata.Contamination("_3ebzgh4", "&"));
      Assert.AreEqual("      ", Kata.Contamination("//case", " "));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-=_+[]{};':,.<>/? ";
      
      for (int i = 0; i < 100; ++i)
      {
        string text = String.Empty;
        int loops = rnd.Next(0, 20);
        for (int j = 0; j < loops; ++j)
        {
          text += chars[rnd.Next(0, chars.Length)];
        }
        string character = String.Empty;
        if (rnd.Next(0, 10) != 0) character += chars[rnd.Next(0, chars.Length)];
        string expected = new Regex(".").Replace(text, character);
        string actual = Kata.Contamination(text, character);
        Console.WriteLine("Testing for \"{0}\" and \"{1}\"", text, character);
        Console.WriteLine("Expected: {0}", expected);
        Console.WriteLine("Actual:   {0}\n", actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
