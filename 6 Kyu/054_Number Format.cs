/*Challenge link:https://www.codewars.com/kata/565c4e1303a0a006d7000127/train/csharp
Question:
Format any integer provided into a string with "," (commas) in the correct places.

Example:

For n = 100000 the function should return '100,000';
For n = 5678545 the function should return '5,678,545';
for n = -420902 the function should return '-420,902'.
*/

//***************Solution********************

//convert number to string by using string interpolation
//pattern
//set digits followed by (?=exp), zero-width positive lookahead of 3 digits
//followed by on word boundary (a word boundary or the position between a word and a non-word character)
//replace the first substring with ,
//https://learn.microsoft.com/en-us/dotnet/standard/base-types/substitutions-in-regular-expressions#EntireMatch
using System.Text.RegularExpressions;

public class Kata
{
  public static string NumberFormat(int number)
  {
    return Regex.Replace($"{number}", @"(\d)(?=(\d{3})+\b)", "$1,");
    //=> $"{number:N0}"; //N0 is Standard Numeric Format Strings
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(100000, ExpectedResult="100,000")]
  [TestCase(5678545, ExpectedResult="5,678,545")]
  [TestCase(-420902, ExpectedResult="-420,902")]
  public static string FixedTest(int num)
  {
    return Kata.NumberFormat(num);
  }
  
  private static string Solution(int number)
  {
    return number.ToString("N0");
  }
  
  [Test]
  public static void RandomTest([Random(1,10001,100)]int num)
  {
    num = (int)Math.Pow(7, (double)num / 1000);
    Assert.AreEqual(Solution(num), Kata.NumberFormat(num), string.Format("Should work for {0}", num));
  }
  
  [Test]
  public static void RandomNegativeTest([Random(1,10001,100)]int num)
  {
    num = -(int)Math.Pow(7, (double)num / 1000);
    Assert.AreEqual(Solution(num), Kata.NumberFormat(num), string.Format("Should work for {0}", num));
  }
}
