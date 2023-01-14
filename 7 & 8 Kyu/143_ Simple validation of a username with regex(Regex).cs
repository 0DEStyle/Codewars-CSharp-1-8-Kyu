/*Challenge link:https://www.codewars.com/kata/56a3f08aa9a6cc9b75000023/train/csharp
Question:Write a simple regex to validate a username. Allowed characters are:

lowercase letters,
numbers,
underscore
Length should be between 4 and 16 characters (both included).
*/

//***************Solution********************
//return only lowercase letter, number and underscore, length between 4 to 16 character
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static bool ValidateUsr(string username) => Regex.IsMatch(username, "^[a-z0-9_]{4,16}$");
}

//****************Sample Test*****************
using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class Tests
{
  [Test]
  [TestCase("asddsa", ExpectedResult=true)]
  [TestCase("a", ExpectedResult=false)]
  [TestCase("Hass", ExpectedResult=false)]
  [TestCase("Hasd_12ssssssssssssssasasasasasssasassss", ExpectedResult=false)]
  [TestCase("", ExpectedResult=false)]
  [TestCase("____", ExpectedResult=true)]
  [TestCase("012", ExpectedResult=false)]
  [TestCase("p1pp1", ExpectedResult=true)]
  [TestCase("asd43 34", ExpectedResult=false)]
  [TestCase("asd43_34", ExpectedResult=true)]
  public static bool FixedTest(string username)
  {
    return Kata.ValidateUsr(username);
  }
  
  [Test]
  public static void RandomTest([Random(0,20,100)]int length)
  {
    string str = RandomString(length, "abcdefghijklmnopqrstuvwxyzABC_ ");
    Assert.AreEqual(Solution(str), Kata.ValidateUsr(str), string.Format("Should work for {0}", str));
  }
  
  private static bool Solution(string username) 
  {
    return Regex.Match(username, @"^[a-z0-9_]{4,16}$").Success;
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
