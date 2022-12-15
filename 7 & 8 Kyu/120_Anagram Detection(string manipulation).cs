/*Challenge link:https://www.codewars.com/kata/529eef7a9194e0cbc1000255/train/csharp
Question:
An anagram is the result of rearranging the letters of a word to produce a new word (see wikipedia).

Note: anagrams are case insensitive

Complete the function to return true if the two arguments given are anagrams of each other; return false otherwise.

Examples
"foefet" is an anagram of "toffee"

"Buckethead" is an anagram of "DeathCubeK"
*/

//***************Solution********************
//convert string to upper case, sort the character in order, concatenate the character and compare, if same return true, else false
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static bool IsAnagram(string str, string original)=>
    string.Concat(str.ToUpper().OrderBy(c => c)) == string.Concat(original.ToUpper().OrderBy(c => c));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("foefet", "toffee", ExpectedResult=true)]
  [TestCase("Buckethead", "DeathCubeK", ExpectedResult=true)]
  [TestCase("Twoo", "Woot", ExpectedResult=true)]
  [TestCase("dumble", "bumble", ExpectedResult=false)]
  [TestCase("ound", "round", ExpectedResult=false)]
  [TestCase("apple", "pale", ExpectedResult=false)]
  public static bool FixedTest(string test, string original)
  {
    return Kata.IsAnagram(test, original);
  }
}
