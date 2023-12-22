/*Challenge link:https://www.codewars.com/kata/557b5e0bddf29d861400005d/train/csharp
Question:
Sometimes, I want to quickly be able to convert miles per imperial gallon (mpg) into kilometers per liter (kpl).

Create an application that will display the number of kilometers per liter (output) based on the number of miles per imperial gallon (input).

Make sure to round off the result to two decimal points.

Some useful associations relevant to this kata:

1 Imperial Gallon = 4.54609188 litres
1 Mile = 1.609344 kilometres
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//apply formula and round to 2 decimal places
using static System.Math;

public static class Kata{
	public static double Converter(int mpg) => Round(mpg / 4.54609188 * 1.609344,2) ;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class ConverterTests
{
  private static double converter(int mpg)
	{
		return Math.Round(mpg * 1.609344 / 4.54609188, 2);
	}
  
	[Test]
	public void Basic_Tests()
	{
		Assert.AreEqual(3.54, Kata.Converter(10));
		Assert.AreEqual(7.08, Kata.Converter(20));
		Assert.AreEqual(10.62, Kata.Converter(30));
		Assert.AreEqual(8.50, Kata.Converter(24));
		Assert.AreEqual(12.74, Kata.Converter(36));
	}
  
	[Test]
	public void Random_Tests()
	{
		var r = new Random();

		for (var index = 0; index < 40; index++){
			var test = r.Next(0, (int)Math.Pow(10, r.Next(1, 5)));
			Assert.AreEqual(ConverterTests.converter(10), Kata.Converter(10));
		}
	}
}
