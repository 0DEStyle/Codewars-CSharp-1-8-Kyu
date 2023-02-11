/*Challenge link:https://www.codewars.com/kata/56a946cd7bd95ccab2000055/train/csharp
Question:
Your task is simply to count the total number of lowercase letters in a string.

Examples
LowercaseCountCheck("abc") == 3
LowercaseCountCheck("abcABC123") == 3
LowercaseCountCheck("abcABC123!@€£#$%^&*()_-+=}{[]|\':;?/>.<,~"") == 3
LowercaseCountCheck("") == 0
LowercaseCountCheck("ABC123!@€£#$%^&*()_-+=}{[]|\':;?/>.<,~"") == 0
LowercaseCountCheck("abcdefghijklmnopqrstuvwxyz") == 26
'
*/

//***************Solution********************
//find if the string contains characters of a-z(lower case), then count and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;
public class Kata{
  public static int LowercaseCountCheck(string s) => Regex.Matches(s, "[a-z]").Count;
}

//solution 2: not regex, but Linq, 

using System;
using System.Linq;
public class Kata
{
  public static int LowercaseCountCheck(string s)
  =>s.Where(c=>Char.IsLower(c)).Count();
}

//solution 3 => s.Count(char.IsLower);

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

public class Tests
{
  [Test]
  [TestCase("abc", ExpectedResult=3)]
  [TestCase("abcABC123", ExpectedResult=3)]
  [TestCase("abcABC123!@€£#$%^&*()_-+=}{[]|\':;?/>.<,~", ExpectedResult=3)]
  [TestCase("", ExpectedResult=0)]
  [TestCase("ABC123!@€£#$%^&*()_-+=}{[]|\':;?/>.<,~", ExpectedResult=0)]
  [TestCase("abcdefghijklmnopqrstuvwxyz", ExpectedResult=26)]
  public static int FixedTest(string str)
  {
    return Kata.LowercaseCountCheck(str);
  }
  
  [Test]
  public static void RandomTest([Random(0,100,100)]int len)
  {
    string s = RandomString(len, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!§$%&/()=");
    Assert.AreEqual(Solution(s), Kata.LowercaseCountCheck(s), "Should work for {0}", s);
  }
  
  private static int Solution(string s)
  {
    return Regex.Replace(s, @"[^a-z]", "").Length;
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
