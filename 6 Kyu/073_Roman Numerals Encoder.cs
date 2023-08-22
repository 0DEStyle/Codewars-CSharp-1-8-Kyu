/*Challenge link:https://www.codewars.com/kata/51b62bf6a9c58071c600001b/train/csharp
Question:
Create a function taking a positive integer between 1 and 3999 (both included) as its parameter and returning a string containing the Roman Numeral representation of that integer.

Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

Example:

RomanConvert.Solution(1000) -- should return "M"
Help:

Symbol    Value
I          1
V          5
X          10
L          50
C          100
D          500
M          1,000
Remember that there can't be more than 3 identical symbols in a row.

More about roman numerals - http://en.wikipedia.org/wiki/Roman_numerals
*/

//***************Solution********************

//create a dictionary to store 2 values, number value and the string representation
//from dictionary select element where n is greater or equal to current element value(key)
//then select the value and add to the result of recursive function Solution(n - p.Key)
//get first or default.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System.Collections.Generic;

public class RomanConvert{
  public static string Solution(int n) => new Dictionary<int, string>{
        {1000, "M"}, {900, "CM"}, {500, "D"}, {400, "CD"},
        {100, "C"}, {90, "XC"}, {50, "L"}, {40, "XL"},
        {10, "X"}, {9, "IX"}, {5, "V"}, {4, "IV"}, {1, "I"}
    }.Where(p => n >= p.Key).Select(p => p.Value + Solution(n - p.Key)).FirstOrDefault();
}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class RomanConvertTests
{
	private Random rnd = new Random();
  
  [TestCase(1, "I")]
	[TestCase(2, "II")]
	[TestCase(4, "IV")]
	[TestCase(500, "D")]
	[TestCase(1000, "M")]
	[TestCase(1954, "MCMLIV")]
	[TestCase(1990, "MCMXC")]
	[TestCase(2008, "MMVIII")]
	[TestCase(2014, "MMXIV")]
	public void FixedTest(int value, string expected)
	{
		Assert.AreEqual(expected, RomanConvert.Solution(value));
	}
  
  private static Dictionary<int, string> literals 
    = new Dictionary<int, string>
  {
    {1000,  "M"},
    { 900, "CM"},
    { 500,  "D"},
    { 400, "CD"},
    { 100,  "C"}, 
    {  90, "XC"},
    {  50,  "L"},
    {  40, "XL"},
    {  10,  "X"},
    {   9, "IX"},
    {   5,  "V"},
    {   4, "IV"},
    {   1,  "I"}
  };

	public static string Solution(int n)
	{
    return literals.Aggregate(
      string.Empty, 
      (result, next) =>
      {
        while (n>=next.Key) 
        {
          n -= next.Key;
          result += next.Value;
        }
        return result;
      }
    );
	}
  
  [Test]
  public void RandomTests() {
    for(int i=0; i<100; i++) {
      int n = rnd.Next(3888)+1;
      Assert.AreEqual(Solution(n), RomanConvert.Solution(n), $"Testing for: {n}");
    }
  }
}
