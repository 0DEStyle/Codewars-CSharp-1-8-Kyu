/*Challenge link:https://www.codewars.com/kata/520b9d2ad5c005041100000f/train/csharp
Question:
Move the first letter of each word to the end of it, then add "ay" to the end of the word. Leave punctuation marks untouched.

Examples
Kata.PigIt("Pig latin is cool"); // igPay atinlay siay oolcay
Kata.PigIt("Hello world !");     // elloHay orldway !
*/

//***************Solution********************

/*
if first pattern is a character, and last pattern (except \n) is a character
replace first character with last($2), replace last character with first($1), add ay to the end
Then simiplfied into one line by using an Lambda expression with Enumerable methods.
*/
using System.Text.RegularExpressions;
public class Kata
{
  public static string PigIt(string str) =>
    Regex.Replace(str, @"(\w)(\w*)", "$2$1ay");
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
  public static string Solution(string str)
  {
    return String.Join(" ", str.Split(' ').Select(w => w.Substring(1) + w[0] + "ay"));
  }

  [Test]
  public void KataTests()
  {
    Assert.AreEqual("igPay atinlay siay oolcay", Kata.PigIt("Pig latin is cool"));
    Assert.AreEqual("hisTay siay ymay tringsay", Kata.PigIt("This is my string"));
    Assert.AreEqual("elloHay orldway !", Kata.PigIt("Hello world !"));
  }
  
  [Test]
  public void RandomTests()
  {
    var random = new Random();
    string randomStr;
    for (int i = 0; i < 10; i++)
    {
      randomStr =
          String.Join("", Enumerable.Range(0, 20).Select((o, x) => (char)random.Next('a', 'z') + ((x+1) % 3 == 0 ? " ": "")));

      Assert.AreEqual(Solution(randomStr), Kata.PigIt(randomStr));
    }
  }
}
