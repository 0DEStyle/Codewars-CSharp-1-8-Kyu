/*Challenge link:https://www.codewars.com/kata/57b2020eb69bfcbf64000375/train/csharp
Question:
Change every letter in a given string to the next letter in the alphabet. The function takes a single parameter s (string).

Notes:

Spaces and special characters should remain the same.
Capital letters should transfer in the same way but remain capitilized.
Examples
"Hello"               -->  "Ifmmp"
"What is your name?"  -->  "Xibu jt zpvs obnf?"
"zoo"                 -->  "app"
"zzZAaa"              -->  "aaABbb"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern (?i) ignore case, from a to z
// x is current element, replace with "" + 
//check if x.Value[0] is lowercase
//if true, replace with next lowercase ASCII 
//else replace with next uppercase ASCII
public class Kata{
  public static string NextLetter(string s) => System.Text.RegularExpressions.Regex
                      .Replace(s, "(?i)[a-z]", x => "" + (char)(char.IsLower(x.Value[0]) ? 
                                                         (x.Value[0] - 'a'+1) % 26 + 'a' : 
                                                         (x.Value[0] - 'A'+1) % 26 + 'A'));
}

//LINQ
using System.Linq;

public class Kata
{
  public static string NextLetter(string str)
  {
    return string.Concat(str.Select(c => char.IsLetter(c) ? (char) (c + ("zZ".Contains(c) ? -25 : 1)) : c));
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("Nz Obnf Jt App", Kata.NextLetter("My Name Is Zoo"));
      Assert.AreEqual("Xibu jt zpvs obnf", Kata.NextLetter("What is your name"));
      Assert.AreEqual("aPp", Kata.NextLetter("zOo"));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual("J bn 4 zfbst pme.", Kata.NextLetter("I am 4 years old."));
      Assert.AreEqual("Nz dsfeju-dbse ovncfs tubsut xjui 19291.", Kata.NextLetter("My credit-card number starts with 19291."));
      Assert.AreEqual("!§$%&/()= bsf joufsfttujoh dibst.", Kata.NextLetter("!§$%&/()= are interessting chars."));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<string, string> MyNextLetter = delegate (string str)
      {
        var alphabet = "abcdefghijklmnopqrstuvwxyzaABCDEFGHIJKLMNOPQRSTUVWXYZA";
        return string.Concat(str.Select(c => alphabet.Contains(c) ? alphabet[alphabet.IndexOf(c)+1] : c));
      };
      
      for(int i = 0; i < 20; i++)
      {
        var word = string.Concat(Enumerable.Range(0,30).Select(o => (char)rand.Next(32, 91)));

        Assert.AreEqual(MyNextLetter(word), Kata.NextLetter(word));
      }
    }
  }
}
