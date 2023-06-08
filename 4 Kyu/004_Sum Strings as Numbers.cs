/*Challenge link:https://www.codewars.com/kata/sum-strings-as-numbers/train/csharp
Question:
Given the string representations of two integers, return the string representation of the sum of those integers.

For example:

sumStrings('1','2') // => '3'
A string representation of an integer will contain no characters besides the ten numerals "0" to "9".

I have removed the use of BigInteger and BigDecimal in java

Python: your solution need to work with huge numbers (about a milion digits), converting to int will not work.
*/

//***************Solution********************
//check if the string a and b is null or empty, if empty return "0"
//else parse the value to BigIntger and sum
//then use string interpolation to convert the result into string.
//return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Numerics;

public static class Kata{
    public static string sumStrings(string a, string b) =>
      $"{(BigInteger.Parse(string.IsNullOrEmpty(a) ? "0" : a) + BigInteger.Parse(string.IsNullOrEmpty(b) ? "0" : b))}";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class CodeWarsTest
{
	[Test]
	public void Test1()
	{
		Assert.AreEqual("579",Kata.sumStrings("123","456"));
	}
  [Test]
	public void Test2()
	{
		Assert.AreEqual("8842",Kata.sumStrings("8797","45"));
	}
  [Test]
	public void Test3()
	{
		Assert.AreEqual("10367",Kata.sumStrings("800","9567"));
	}
  [Test]
	public void Test4()
	{
		Assert.AreEqual("100",Kata.sumStrings("99","1"));
	}
  [Test]
	public void Test5()
	{
		Assert.AreEqual("8670",Kata.sumStrings("00103","08567"));
	}
  [Test]
	public void Test6()
	{
		Assert.AreEqual("5",Kata.sumStrings("","5"));
	}
  [Test]
	public void Test7()
	{
		Assert.AreEqual("712577413488402631964821329",Kata.sumStrings("712569312664357328695151392","8100824045303269669937"));
	}
  [Test]
	public void Test8()
	{
		Assert.AreEqual("131151201344081895336534324866",Kata.sumStrings("50095301248058391139327916261","81055900096023504197206408605"));
	}
}
