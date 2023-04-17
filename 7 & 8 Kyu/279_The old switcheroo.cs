/*Challenge link:https://www.codewars.com/kata/55d410c492e6ed767000004f/train/csharp
Question:
Write a function

Vowel2Index(string s)
that takes in a string and replaces all the vowels [a,e,i,o,u] with their respective positions within that string.
E.g:

Kata.Vowel2Index("this is my string") == "th3s 6s my str15ng"
Kata.Vowel2Index("Codewars is the best site in the world") == "C2d4w6rs 10s th15 b18st s23t25 27n th32 w35rld"
Your function should be case insensitive to the vowels.


*/

//***************Solution********************
//replace all vowels to index, i.Index + 1 as the counter
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static string Vowel2Index(string str) => Regex.Replace(str, "[aeiou]", i => $"{i.Index + 1}");
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("this is my string", ExpectedResult="th3s 6s my str15ng")]
  [TestCase("Codewars is the best site in the world", ExpectedResult="C2d4w6rs 10s th15 b18st s23t25 27n th32 w35rld")]
  [TestCase("Tomorrow is going to be raining", ExpectedResult="T2m4rr7w 10s g1415ng t20 b23 r2627n29ng")]
  [TestCase("", ExpectedResult="")]
  public static string FixedTest(string str)
  {
    return Kata.Vowel2Index(str);
  }
  
  [Test]
  public static void RandomTest([Random(1,1000,100)] int len)
  {
    Random r = new Random();
    string s = "";
    while(--len >= 0)
    {
      s += (char)r.Next(122-97)+97;
    }
    Assert.AreEqual(Sol(s), Kata.Vowel2Index(s), String.Format("{0} should be {1}, but was {2}",s, Sol(s), Kata.Vowel2Index(s)));
  }
  
  private static string Sol(string str)
  {
    string s = "";
    int i= 0;
    foreach(char c in str)
    {
      i++;
      if("AEIOUaeiou".Contains(c.ToString()))
        s += i;
      else
        s += c;
    }
    return s;
  }
}
