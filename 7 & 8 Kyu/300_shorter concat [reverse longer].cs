/*Challenge link:https://www.codewars.com/kata/54557d61126a00423b000a45/train/csharp
Question:
Given 2 strings, a and b, return a string of the form: shorter+reverse(longer)+shorter.

In other words, the shortest string has to be put as prefix and as suffix of the reverse of the longest.

Strings a and b may be empty, but not null (In C# strings may also be null. Treat them as if they are empty.).
If a and b have the same length treat a as the longer producing b+reverse(a)+b
*/

//***************Solution********************
//check if a or b is null, if so, set them to empty string ""
//if a is longer or equal to b, b +  reverse a + b
//else do the opposite.
using System.Linq;
class ReverseLonger{
	public static string ShorterReverseLonger(string a, string b){
    if (a == null) a = "";
    if (b == null) b = "";
    return a.Length >= b.Length ? $"{b}{string.Concat(a.Reverse())}{b}" :  $"{a}{string.Concat(b.Reverse())}{a}";
  }
}


//better solution

using System.Linq;
class ReverseLonger{
	public static string ShorterReverseLonger(string a, string b){
    a ??= "";
    b ??= "";
    return a.Length >= b.Length ? $"{b}{string.Concat(a.Reverse())}{b}" :  $"{a}{string.Concat(b.Reverse())}{a}";
  }
}
//****************Sample Test*****************
using NUnit.Framework;

[TestFixture]
public class ReverseLongerTests
{
	[Test]
	public void ReverLongerTest_1()
	{
		try
		{
			string input_a = "first";
			string input_b = "abcde";
			string expected = "abcdetsrifabcde";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_2()
	{
		try
		{
			string input_a = "hello";
			string input_b = "bau";
			string expected = "bauollehbau";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_3()
	{
		try
		{
			string input_a = "abcde";
			string input_b = "fghi";
			string expected = "fghiedcbafghi";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_4()
	{
		try
		{
			string input_a = "";
			string input_b = "b_notempty";
			string expected = "ytpmeton_b";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_5()
	{
		try
		{
			string input_a = "a_notempty";
			string input_b = "";
			string expected = "ytpmeton_a";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_6()
	{
		try
		{
			string input_a = null;
			string input_b = "b_notnull";
			string expected = "llunton_b";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_7()
	{
		try
		{
			string input_a = "a_notnull";
			string input_b = null;
			string expected = "llunton_a";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_8()
	{
		try
		{
			string input_a = "";
			string input_b = "";
			string expected = "";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_9()
	{
		try
		{
			string input_a = null;
			string input_b = null;
			string expected = "";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}

	[Test]
	public void ReverLongerTest_10()
	{
		try
		{
			string input_a = "Hello. This is a slightly longer text then in the other test cases. Shouldn't make a difference, really.";
			string input_b = "_";
			string expected = "_.yllaer ,ecnereffid a ekam t'ndluohS .sesac tset rehto eht ni neht txet regnol ylthgils a si sihT .olleH_";

			string actual = ReverseLonger.ShorterReverseLonger(input_a, input_b);

			Assert.AreEqual(expected, actual);
		}
		catch(System.Exception ex)
		{
			Assert.Fail("There seems to be an error in your code. The exception message reads as follow: " + ex.Message);
		}
	}
}
