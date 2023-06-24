/*Challenge link:https://www.codewars.com/kata/59c5f4e9d751df43cf000035/train/csharp
Question:
The vowel substrings in the word codewarriors are o,e,a,io. The longest of these has a length of 2. Given a lowercase string that has alphabetic characters only (both vowels and consonants) and no spaces, return the length of the longest vowel substring. Vowels are any of aeiou.

Good luck!

If you like substring Katas, please try:

Non-even substrings

Vowel-consonant lexicon
*/

//***************Solution********************
//split string by regex pattern "[^aeiou]+"
//select element by length
//get max value
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;
using System.Linq;

public static class Kata
{
  public static int Solve(string str) => Regex.Split(str, "[^aeiou]+").Select(x => x.Length).Max();
}

//method 2
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static int Solve(string str) => Regex.Split(str, "[^aeiou]+").Max(e => e.Length);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;
  
  public static class Solution
  {
    public static int Solve(string s) =>
      Regex.Matches(s, "[aeiou]*")
           .Cast<Match>()
           .DefaultIfEmpty()
           .Max(m => m.Value.Length);
  }
  
  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Random Tests")]
    public void SampleTest()
    {
      Assert.AreEqual(2, Kata.Solve("codewarriors"));
      Assert.AreEqual(3, Kata.Solve("suoidea"));
      Assert.AreEqual(3, Kata.Solve("ultrarevolutionariees"));
      Assert.AreEqual(1, Kata.Solve("strengthlessnesses"));
      Assert.AreEqual(2, Kata.Solve("cuboideonavicuare"));
      Assert.AreEqual(5, Kata.Solve("chrononhotonthuooaos"));
      Assert.AreEqual(8, Kata.Solve("iiihoovaeaaaoougjyaw"));
    }
    
    [Test, Description("Basic Tests")]
    public void RandomTest()
    {
      const int Tests = 420;
      Random rnd = new Random();
      
      for (int i = 0; i < Tests; ++i)
      {
        string s = String.Concat(new char[rnd.Next(5, 200)].Select(_ => (char)rnd.Next(97, 123)));
        
        int expected = Solution.Solve(s);
        int actual = Kata.Solve(s);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
