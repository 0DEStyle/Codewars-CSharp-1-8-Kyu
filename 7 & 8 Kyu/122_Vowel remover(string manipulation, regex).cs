/*Challenge link:https://www.codewars.com/kata/5547929140907378f9000039/train/csharp
Question:
Create a function called shortcut to remove the lowercase vowels (a, e, i, o, u ) in a given string.

Examples
"hello"     -->  "hll"
"codewars"  -->  "cdwrs"
"goodbye"   -->  "gdby"
"HELLO"     -->  "HELLO"
don''t worry about uppercase vowels
y is not considered a vowel for this kata
*/

//***************Solution********************
remove any character of "aeiou" from string, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static string Shortcut(string s)=> Regex.Replace(s,"[aeiou]", "");
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

public class KataTest
{
  [Test]
  public void Test1()
  {
    KataTest.Assert("hello", "hll");
    KataTest.Assert("how are you today?", "hw r y tdy?");
    KataTest.Assert("complain", "cmpln");
    KataTest.Assert("never", "nvr");
  }

  private static void Assert(string input, string expected)
  {
      var result = Kata.Shortcut(input);
      NUnit.Framework.Assert.AreEqual(expected, result, String.Format("Expected \"{0}\" but got \"{1}\"", expected, result));
  }
}
