/*Challenge link:https://www.codewars.com/kata/51b6249c4612257ac0000005/train/csharp
Question:
Create a function that takes a Roman numeral as its argument and returns its value as a numeric decimal integer. You don't need to validate the form of the Roman numeral.

Modern Roman numerals are written by expressing each decimal digit of the number to be encoded separately, starting with the leftmost digit and skipping any 0s. So 1990 is rendered "MCMXC" (1000 = M, 900 = CM, 90 = XC) and 2008 is rendered "MMVIII" (2000 = MM, 8 = VIII). The Roman numeral for 1666, "MDCLXVI", uses each letter in descending order.

Example:

RomanDecode.Solution("XXI") -- should return 21
Help:

Symbol    Value
I          1
V          5
X          10
L          50
C          100
D          500
M          1,000
Courtesy of rosettacode.org
*/

//***************Solution********************

using System.Collections.Generic;
using System.Linq;

public class RomanDecode{
  //Create dictionary 
	private static Dictionary<char,int> num = new Dictionary<char, int>{
                {'I',1},{'V',5},{'X',10},
                {'L',50},{'C',100},{'D',500},
                {'M',1000},
            };
  
  //reverse the the string roman, start from smallest.
  //aggregate, if num[ch] *3 is less than the value of current element, then -num[ch]
  //else return num[ch]
  public static int Solution(string roman) =>
    roman.Reverse().Aggregate(0, (current, ch) => current + (num[ch] *3 < current ? -num[ch] : num[ch]));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class RomanDecodeTests
{
	[TestCase(1, "I")]
	[TestCase(2, "II")]
	[TestCase(4, "IV")]
  [TestCase(21, "XXI")]
	[TestCase(500, "D")]
	[TestCase(1000, "M")]
	[TestCase(1954, "MCMLIV")]
	[TestCase(1990, "MCMXC")]
	[TestCase(2008, "MMVIII")]
	[TestCase(2014, "MMXIV")]
	public void Test(int expected, string roman)
	{
		Assert.AreEqual(expected, RomanDecode.Solution(roman));
	}
}
