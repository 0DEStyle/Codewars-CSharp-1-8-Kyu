/*Challenge link:https://www.codewars.com/kata/541c8630095125aba6000c00/train/csharp
Question:
Digital root is the recursive sum of all the digits in a number.

Given n, take the sum of the digits of n. If that value has more than one digit, continue reducing in this way until a single-digit number is produced. The input will be a non-negative integer.

Examples
    16  -->  1 + 6 = 7
   942  -->  9 + 4 + 2 = 15  -->  1 + 5 = 6
132189  -->  1 + 3 + 2 + 1 + 8 + 9 = 24  -->  2 + 4 = 6
493193  -->  4 + 9 + 3 + 1 + 9 + 3 = 29  -->  2 + 9 = 11  -->  1 + 1 = 2
*/

//***************Solution********************
//add each digit together to get the digit root, the answer should between 1 to 9
//if the number exceeded the 9, repeat the first step until it become a single digit.
//apply formula
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Number
{
  //method by hand: https://www.youtube.com/watch?v=YX9Fd6kxLsA
  //efficient method: https://stackoverflow.com/questions/1057072/calculating-digital-root-is-there-a-better-way
  public static int DigitalRoot(long n) => (int)((n - 1) % 9 + 1);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class NumberTest
{
  [TestCase(16, ExpectedResult = 7)]
  [TestCase(195, ExpectedResult = 6)]
  [TestCase(992, ExpectedResult = 2)]
  [TestCase(999999999999, ExpectedResult = 9)]
  [TestCase(167346, ExpectedResult = 9)]
  [TestCase(0, ExpectedResult = 0)]
  [TestCase(10, ExpectedResult = 1)]
  public int Tests(long n)
  {
    return Number.DigitalRoot(n);      
  }
  
  [Test]
  [Repeat(100)]
  public void RandomTests()
  {
    var rnd = new Random();
    int len = rnd.Next(1, 20);
    long n = len == 1 ? rnd.NextInt64(10) : rnd.NextInt64((long) Math.Pow(10, len - 1), len == 19 ? Int64.MaxValue : (long) Math.Pow(10, len));
    int expected = (int)((n - 1) % 9 + 1);
    Assert.AreEqual(expected, Number.DigitalRoot(n), $"For n = {n}");
  }
}
