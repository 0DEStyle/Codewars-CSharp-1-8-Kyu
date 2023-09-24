/*Challenge link:https://www.codewars.com/kata/59325dc15dbb44b2440000af/train/csharp
Question:
Create a function isAlt() that accepts a string as an argument and validates whether the vowels (a, e, i, o, u) and consonants are in alternate order.

Kata.IsAlt("amazon")
// true
Kata.IsAlt("apple")
// false
Kata.IsAlt("banana")
// true
Arguments consist of only lowercase letters.
*/

//***************Solution********************

//while not match, compare word to pattern where
//character set "aeiou", match 2 times
//or negative charaacter set "aeiou", match 2 times
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static bool IsAlt(string word) => !Regex.IsMatch(word, "[aeiou]{2}|[^aeiou]{2}");
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(true, Kata.IsAlt("amazon"));
      Assert.AreEqual(false, Kata.IsAlt("apple"));
      Assert.AreEqual(true, Kata.IsAlt("banana"));
    }
     
    [Test]
    public void SingleCharTests()
    {
      Assert.AreEqual(true, Kata.IsAlt("a"));
      Assert.AreEqual(true, Kata.IsAlt("b"));
    }
    
    private static Random rnd = new Random();
    
    private static bool IsVowel(char c)
    {
      return "aeoiu".Contains(c);
    }
    
    private static bool Solution(string word)
    {
      bool vowel = IsVowel(word[0]);
      
      for (int i = 1; i < word.Length; ++i)
      {
        if (vowel && IsVowel(word[i])) return false;
        else if (!vowel && !IsVowel(word[i])) return false;
        
        vowel = !vowel;
      }
      
      return true;
    }
    
    [Test]
    public void RandomTests()
    {
      string letters = "abcdefghij";
      for (int i = 0; i < 100; ++i)
      {
        string word = "";
        for (int j = 0; j < 5; ++j)
        {
          word += letters[rnd.Next(0, letters.Length)];
        }
        
        Console.WriteLine("Testing for {0}", word);
        
        Assert.AreEqual(Solution(word), Kata.IsAlt(word));
      }
    }
  }
}
