/*Challenge link:https://www.codewars.com/kata/54bf1c2cd5b56cc47f0007a1/train/csharp
Question:
Count the number of Duplicates
Write a function that will return the count of distinct case-insensitive alphabetic characters and numeric digits that occur more than once in the input string. The input string can be assumed to contain only alphabets (both uppercase and lowercase) and numeric digits.

Example
"abcde" -> 0 # no characters repeats more than once
"aabbcde" -> 2 # 'a' and 'b'
"aabBcde" -> 2 # 'a' occurs twice and 'b' twice (`b` and `B`)
"indivisibility" -> 1 # 'i' occurs six times
"Indivisibilities" -> 2 # 'i' occurs seven times and 's' occurs twice
"aA11" -> 2 # 'a' and '1'
"ABBA" -> 2 # 'A' and 'B' each occur twice

*/

//***************Solution********************
using System.Linq;

//Convert string to lower case (distinct cas-insensitive)
//Group element by character: GroupBy<TSource, TKey>

//Where filters out unwanted result.
//if character count is greater than 1,
//then distinct count increase by 1.
//Simiplfied into one line by using an Enumerable methods.

public class Kata
{
  public static int DuplicateCount(string str) =>
    str.ToLower().GroupBy(c => c).Where(g => g.Count() > 1).Count();
}

//****************Sample Test*****************
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTest
{
  public static int Solution(string str)
  {
    str = String.Join("", str.ToLower().OrderBy(c => c));
    return Regex.Matches(str, @"(.)\1+").Count;
  }
  
  [Test]
  public void KataTests()
  {
    Assert.AreEqual(0, Kata.DuplicateCount(""));
    Assert.AreEqual(0, Kata.DuplicateCount("abcde"));
    Assert.AreEqual(2, Kata.DuplicateCount("aabbcde"));
    Assert.AreEqual(2, Kata.DuplicateCount("aabBcde"), "should ignore case");
    Assert.AreEqual(1, Kata.DuplicateCount("Indivisibility"));
    Assert.AreEqual(2, Kata.DuplicateCount("Indivisibilities"), "characters may not be adjacent");
  }
  
  [Test]
  public void RandomTests()
  {
    var random = new Random();
    string randomStr;
    for (int i = 0; i < 10; i++)
    {
      randomStr =
        String.Join("", Enumerable.Range(0, 20).Select((o, x) => (char)random.Next('a', 'z') + (char)random.Next('A', 'Z')));

      Assert.AreEqual(Solution(randomStr), Kata.DuplicateCount(randomStr));
    }
  }
}
