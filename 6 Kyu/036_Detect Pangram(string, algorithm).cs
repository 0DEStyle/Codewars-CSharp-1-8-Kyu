/*Challenge link:https://www.codewars.com/kata/545cedaa9943f7fe7b000048/train/csharp
Question:
A pangram is a sentence that contains every single letter of the alphabet at least once. For example, the sentence "The quick brown fox jumps over the lazy dog" is a pangram, because it uses the letters A-Z at least once (case is irrelevant).

Given a string, detect whether or not it is a pangram. Return True if it is, False if not. Ignore numbers and punctuation.


*/

//***************Solution********************
//convert string to lower case, in string check if character is a letter, group those letter, and count it
//if count is equal to 26, then it is a pangram. return the bool value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public static class Kata{
  public static bool IsPangram(string s)=> s.ToLower().Where(c => Char.IsLetter(c)).GroupBy(c => c).Count() == 26;
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class Tests 
  {
    private static Random rnd = new Random();
    
    private static object[][] testCases = new object[][]
    {
      new object[] {false, "This isn't a pangram!"},
      new object[] {false, "abcdefghijklmopqrstuvwxyz "},
      new object[] {false, "aaaaaaaaaaaaaaaaaaaaaaaaaa"},
      new object[] {false, "Detect Pangram"},
      new object[] {false, "A pangram is a sentence that contains every single letter of the alphabet at least once."},
      new object[] {true, "Cwm fjord bank glyphs vext quiz"},
      new object[] {true, "Pack my box with five dozen liquor jugs."},
      new object[] {true, "How quickly daft jumping zebras vex."},
      new object[] {true, "ABCD45EFGH,IJK,LMNOPQR56STUVW3XYZ"},
      new object[] {true, "AbCdEfGhIjKlM zYxWvUtSrQpOn"},
      new object[] {true, "Raw Danger! (Zettai Zetsumei Toshi 2) for the PlayStation 2 is a bit queer, but an alright game I guess, uh... CJ kicks and vexes Tenpenny precariously? This should be a pangram now, probably."},
    }.OrderBy(x => rnd.Next()).ToArray();
    
    [Test, TestCaseSource("testCases")]
    public void FixedTests(bool expected, string str) => Assert.AreEqual(expected, Kata.IsPangram(str));
  }
}
