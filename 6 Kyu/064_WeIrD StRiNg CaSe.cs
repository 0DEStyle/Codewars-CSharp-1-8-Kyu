/*Challenge link:https://www.codewars.com/kata/52b757663a95b11b3d00062d/train/csharp
Question:
Write a function toWeirdCase (weirdcase in Ruby) that accepts a string, and returns the same string with all even indexed characters in each word upper cased, and all odd indexed characters in each word lower cased. The indexing just explained is zero based, so the zero-ith index is even, therefore that character should be upper cased and you need to start over for each word.

The passed in string will only consist of alphabetical characters and spaces(' '). Spaces will only be present if there are multiple words. Words will be separated by a single space(' ').

Examples:
toWeirdCase( "String" );//=> returns "StRiNg"
toWeirdCase( "Weird string case" );//=> returns "WeIrD StRiNg CaSe"
*/

//***************Solution********************
//split string s, select character, change even number index to uppercase, odd to lower case, join word with a space
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static string ToWeirdCase(string s) =>
    string.Join(" ", s.Split().Select(x =>string.Concat(x.Select((c, i) => i % 2 > 0 ? char.ToLower(c) : char.ToUpper(c)))));
}

//****************Sample Test*****************
namespace Solution
{
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;
  using NUnit.Framework;
  
  [TestFixture]
  public class Tests
  {
    [Test]
    public static void ShouldWorkForBasicStrings()
    {
      Assert.AreEqual("Oh", Kata.ToWeirdCase("oh"));
      Assert.AreEqual("BoY", Kata.ToWeirdCase("BOY"));
      Assert.AreEqual("ThIs Is A TeSt", Kata.ToWeirdCase("This is a test"));
    }
    [Test]
    public static void ShouldWorkForWhitespace()
    {
      Assert.AreEqual("", Kata.ToWeirdCase(""), "Empty strings should work too!");
      Assert.AreEqual("    ", Kata.ToWeirdCase("    "), "Whitespace should work too!");
    }
    [Test]
    public static void ShouldWorkForSymbols()
    {
      Assert.AreEqual("!@#$%^&*()", Kata.ToWeirdCase("!@#$%^&*()"), "Odd characters have to work");
    }
    [Test]
    public static void ShouldWorkForMoreComplexStrings()
    {
      Assert.AreEqual("OnCe, WhEn I WaS YoUnG, I CoDeD On ThE AmIgA!", Kata.ToWeirdCase("Once, when I was young, I coded on the Amiga!"));
    }
    
    private static Random rnd = new Random();
    private static string chars = "                 abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    private static string solution(string s) =>
      String.Join(" ", s.Split(' ').Select(word => String.Concat(word.Select((ch, idx) => idx % 2 == 0 ? Char.ToUpper(ch) : Char.ToLower(ch)))));
       
    [Test]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        string s = new Regex(@"\s+").Replace(String.Concat(new char[rnd.Next(5, 100)].Select(_ => chars[rnd.Next(0, chars.Length)])), " ").Trim();
        if (s == String.Empty) { s = "a"; }
        
        string expected = solution(s);
        string actual = Kata.ToWeirdCase(s);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
