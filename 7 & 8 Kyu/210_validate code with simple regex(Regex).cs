/*Challenge link:https://www.codewars.com/kata/56a25ba95df27b7743000016/train/csharp
Question:
Basic regex tasks. Write a function that takes in a numeric code of any length. The function should check if the code begins with 1, 2, or 3 and return true if so. Return false otherwise.

You can assume the input will always be a number.


*/

//***************Solution********************
//check if the string code's first letter matches the pattern
//pattern, ^ the start of the string, [1|2|3] 1 or 2 or 3, + one character
//return the bool value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static bool ValidateCode(string code)=> Regex.IsMatch(code, "^[1|2|3]+");
}

//****************Sample Test*****************
using System;
using System.Text.RegularExpressions;
using NUnit.Framework;

public class Tests
{
  [Test]
  [TestCase("123", ExpectedResult=true)]
  [TestCase("248", ExpectedResult=true)]
  [TestCase("8", ExpectedResult=false)]
  [TestCase("321", ExpectedResult=true)]
  [TestCase("9453", ExpectedResult=false)]
  public static bool FixedTest(string code)
  {
    return Kata.ValidateCode(code);
  }
  
  [Test]
  public static void RandomTest([Random(0,20,100)]int length)
  {
    string str = RandomString(length, "1234567890abcdefghijklmnopqrstuvwxyzABC_ ");
    Assert.AreEqual(Solution(str), Kata.ValidateCode(str), string.Format("Should work for {0}", str));
  }
  
  private static bool Solution(string code) 
  {
      return Regex.IsMatch(code, "^[1-3]");
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
