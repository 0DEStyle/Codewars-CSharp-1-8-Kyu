/*Challenge link:https://www.codewars.com/kata/5410c0e6a0e736cf5b000e69/train/csharp
Question:
The Hamming Distance is a measure of similarity between two strings of equal length. Complete the function so that it returns the number of positions where the input strings do not match.

Examples:
a = "I like turtles"
b = "I like turkeys"
Result: 3

a = "Hello World"
b = "Hello World"
Result: 0

a = "espresso"
b = "Expresso"
Result: 2
You can assume that the two inputs are ASCII strings of equal length.
*/

//***************Solution********************

//t current element, i is index
//from a, get elements where current elements is not equal to b[index]
//count the number of elemenet and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Hamming{
	public static int Distance(string a, string b) => a.Where((t, i) => t != b[i]).Count();
}

//****************Sample Test*****************
using System;

using NUnit.Framework;

[TestFixture]
public class HammingTests
{
	private readonly Random random = new Random();

	[TestCase("hello world", "hello world", 0)]
	[TestCase("I like turtles", "I like turkeys", 3)]
	[TestCase("hello world", "hello tokyo", 4)]
	[TestCase("a man a plan a canal", "a man a plan sobanal", 3)]
	[TestCase("hamming and cheese", "Hamming and Cheese", 2)]
	[TestCase("espresso", "Expresso", 2)]
	[TestCase("old father, old artificer", "of my soul the uncreated ", 24)]
	public void StaticTests(string a, string b, int expected)
	{
		Assert.AreEqual(expected, Hamming.Distance(a, b), 
        string.Format("Expected hamming distance of '{0}' and '{1}' to be {2}", a, b, expected));
	}

	[Test]
	public void RandomTest()
	{
		for (int i = 0; i < 20; i++)
		{
			int length = this.random.Next(20) + 10;
			int distance = 0;
			string a = string.Empty;
			string b = string.Empty;
			for (int j = 0; j < length; j++)
			{
				var c = this.RandomCharacter();
				a += c;
				if (this.CoinFlip(0.2))
				{
					b += this.RandomCharacter(c);
					distance++;
				}
				else
				{
					b += c;
				}
			}

			Assert.AreEqual(distance, Hamming.Distance(a, b), 
          string.Format("Expected hamming distance of '{0}' and '{1}' to be {2}", a, b, distance));
		}
	}

	private char RandomCharacter(char exclude = ' ')
	{
		char c;
		do
		{
			c = (char)(this.random.Next(123 - 32) + 32);
		}
		while (c == exclude);

		return c;
	}

	private bool CoinFlip(double chance = 0.5)
	{
		return this.random.NextDouble() < chance;
	}
}
