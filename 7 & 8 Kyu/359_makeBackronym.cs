/*Challenge link:https://www.codewars.com/kata/55805ab490c73741b7000064/train/csharp
Question:
back·ro·nym
An acronym deliberately formed from a phrase whose initial letters spell out a particular word or words, either to create a memorable name or as a fanciful explanation of a word's origin.

"Biodiversity Serving Our Nation", or BISON

(from https://en.oxforddictionaries.com/definition/backronym)

Complete the function to create backronyms. Transform the given string (without spaces) to a backronym, using the preloaded dictionary and return a string of words, separated with a single space (but no trailing spaces).

The keys of the preloaded dictionary are uppercase letters A-Z and the values are predetermined words, for example:

dict['P'] == "perfect"
Examples
"dgm" ==> "disturbing gregarious mustache"

"lkj" ==> "literal klingon joke"
*/

//***************Solution********************
//create dictionary for backronym
//Convert the string s to uppercase, then select each letter, replace by the corresponding word, join the string with space.
//return the result.
using System.Collections.Generic;
using System.Linq;

public partial class Kata
{
  public static string MakeBackronym(string s)
  {
    Dictionary<char, string> dict = new Dictionary<char, string>{
                {'A', "awesome"}, {'B', "beautiful"}, {'C', "confident"}, {'D', "disturbing"}, {'E', "eager"},
                {'F', "fantastic"}, {'G', "gregarious"}, {'H', "hippy"}, {'I', "ingestable"}, {'J', "joke"},
                {'K', "klingon"}, {'L', "literal"}, {'M', "mustache"}, {'N', "newtonian"}, {'O', "oscillating"},
                {'P', "perfect"}, {'Q', "queen"}, {'R', "rant"}, {'S', "stylish"}, {'T', "turn"}, {'U', "underlying"},
                {'V', "volcano"}, {'W', "weird"}, {'X', "xylophone"}, {'Y', "yogic"}, {'Z', "zero"},
            };

            return string.Join(" ", s.ToUpper().Select(x => dict[x]));
  }
}

//method 2
using System.Linq;

public partial class Kata
{
  public static string MakeBackronym(string s)
  {
    return string.Join(" ", s.ToUpper().Select(c => dict[c]));
  }
}

//****************Sample Test*****************
using NUnit.Framework;

using System;
using System.Text;
using System.Linq;

[TestFixture]
public static class BackronymTests
{
  [Test]
  public static void TestExample1()
  {
    Assert.AreEqual("ingestable newtonian turn eager rant eager stylish turn ingestable newtonian gregarious",
      Kata.MakeBackronym("interesting"));
  }
  
  [Test]
  public static void TestExample2()
  {
  
    Assert.AreEqual("confident oscillating disturbing eager weird awesome rant stylish",
      Kata.MakeBackronym("codewars"));
  }
  
  [Test]
  public static void BasicTests()
  {
    Assert.AreEqual("awesome disturbing hippy",
      Kata.MakeBackronym("adh"));
      
    Assert.AreEqual("literal mustache newtonian oscillating perfect",
      Kata.MakeBackronym("lmnop"));
      
    Assert.AreEqual("weird yogic volcano",
      Kata.MakeBackronym("wyv"));
      
    Assert.AreEqual("perfect rant ingestable volcano eager turn",
      Kata.MakeBackronym("privet"));
      
    Assert.AreEqual("perfect awesome klingon awesome",
      Kata.MakeBackronym("paka"));
      
    Assert.AreEqual("",
      Kata.MakeBackronym(""));
      
    Assert.AreEqual("perfect perfect perfect",
      Kata.MakeBackronym("ppp"));
      
    Assert.AreEqual("awesome beautiful confident disturbing eager fantastic gregarious hippy ingestable joke klingon literal mustache newtonian oscillating perfect queen rant stylish turn underlying volcano weird xylophone yogic zero",
      Kata.MakeBackronym("abcdefghijklmnopqrstuvwxyz"));
  }
  
  private static string Sol(string s)
  {
    return string.Join(" ", s.ToUpper().Select(c => Kata.dict[c]).ToArray());
  }
  
  [Test]
  public static void TestRandom()
  {
    Random r = new Random();
    
    string alphabet = "abcdefghijklmnopqrstuvwxyz";
    
    for (int i = 0; i < 40; i++) {
      var sb = new StringBuilder();
      for (int j = 0; j < r.Next(1, 20); j++) {
        sb.Append(alphabet[r.Next(0, alphabet.Length - 1)]);
      }
      
      Assert.AreEqual(
        Sol(sb.ToString()),
        Kata.MakeBackronym(sb.ToString()));
    }
  }
}
