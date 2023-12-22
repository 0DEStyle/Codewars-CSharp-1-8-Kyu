/*Challenge link:https://www.codewars.com/kata/56b1f01c247c01db92000076/train/csharp
Question:
Given a string, you have to return a string in which each character (case-sensitive) is repeated once.

Examples (Input -> Output):
* "String"      -> "SSttrriinngg"
* "Hello World" -> "HHeelllloo  WWoorrlldd"
* "1234!_ "     -> "11223344!!__  "
Good Luck!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//x is the current element, from s using string interpolation to format the string.
//concat the strings and return the result.
using System.Linq;

public class Kata{
  public static string DoubleChar(string s) => string.Concat(s.Select(x => $"{x}{x}"));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class Test
{
  [Test]
  [TestCase("abcd", ExpectedResult="aabbccdd")]
  [TestCase("Adidas", ExpectedResult="AAddiiddaass")]
  [TestCase("1337", ExpectedResult="11333377")]
  [TestCase("illuminati", ExpectedResult="iilllluummiinnaattii")]
  [TestCase("123456", ExpectedResult="112233445566")]
  [TestCase("%^&*(", ExpectedResult="%%^^&&**((")]
  public static string FixedTest(string s)
  {
    return Kata.DoubleChar(s);
  }
  
  private static string Solution(string s)
  {
    return string.Join("", s.Select(x => "" + x + x));
  }
  
  [Test]
  public static void RandomTest([Random(1,30,100)] int len)
  {
    string s = RandomString(len, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!§$%&/()=0987654321");
    Assert.AreEqual(Solution(s), Kata.DoubleChar(s), string.Format("Should work for {0}", s));
  }
  
  private static string RandomString(int randStrLength, string allowedChars)
	{
		string randStr = string.Empty;
		Random r = new Random();
		for(int i = 0; i < randStrLength; i++)
		{
			randStr += allowedChars[r.Next(allowedChars.Length)];
		}
		return randStr;
	}
}
