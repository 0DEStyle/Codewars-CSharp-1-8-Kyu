/*Challenge link:https://www.codewars.com/kata/582cb0224e56e068d800003c/train/csharp
Question:
Nathan loves cycling.

Because Nathan knows it is important to stay hydrated, he drinks 0.5 litres of water per hour of cycling.

You get given the time in hours and you need to return the number of litres Nathan will drink, rounded to the smallest value.

For example:

time = 3 ----> litres = 1

time = 6.7---> litres = 3

time = 11.8--> litres = 5
*/

//***************Solution********************
//math.floor rounds down the result, and typecast to int
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata
{
  public static int Litres(double time) => (int)Math.Floor(0.5 * time);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  public static Random rng = new Random();
  
  [Test]
  [TestCase(2, ExpectedResult = 1)]
  [TestCase(1.4, ExpectedResult = 0)]
  [TestCase(12.3, ExpectedResult = 6)]
  [TestCase(0.82, ExpectedResult = 0)]
  [TestCase(11.8, ExpectedResult = 5)]
  [TestCase(1787, ExpectedResult = 893)]
  [TestCase(0, ExpectedResult = 0)]
  public static int FixedTest(double d)
  {
    return Kata.Litres(d);
  }
  
  [Test]
  public static void RandomTest([Random(0,10000,100)] double d)
  {
    Assert.AreEqual((int)(d * 0.5), Kata.Litres(d));
  }
}
