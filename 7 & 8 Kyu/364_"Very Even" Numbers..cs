/*Challenge link:https://www.codewars.com/kata/58c9322bedb4235468000019/train/csharp
Question:
Task
Write a function that returns true if the number is a "Very Even" number.

If a number is a single digit, then it is simply "Very Even" if it itself is even.

If it has 2 or more digits, it is "Very Even" if the sum of its digits is "Very Even".

Examples
number = 88 => returns false -> 8 + 8 = 16 -> 1 + 6 = 7 => 7 is odd 

number = 222 => returns true -> 2 + 2 + 2 = 6 => 6 is even

number = 5 => returns false

number = 841 => returns true -> 8 + 4 + 1 = 13 -> 1 + 3 => 4 is even
Note: The numbers will always be 0 or positive integers!
*/

//***************Solution********************
//apply formula
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static bool IsVeryEvenNumber(int number)=> ((number-1) % 9 + 1) % 2 == 0;
}

//solution 2
public class Kata
{
  public static bool IsVeryEvenNumber(int n)
  {
      return n-- == 0 || n % 9 % 2 == 1;
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Linq;

[TestFixture]
public class OddLadderTests
{
    [TestCase(        0,  true, TestName="0 is 'Very Even'")]
    [TestCase(        4,  true, TestName="4 is 'Very Even'")]
    [TestCase(       12, false, TestName="12 is not 'Very Even'")]
    [TestCase(      222,  true, TestName="222 is 'Very Even'")]
    [TestCase(        5, false, TestName="5 is not 'Very Even'")]
    [TestCase(       45, false, TestName="45 is not 'Very Even'")]
    [TestCase(     4554, false, TestName="4554 is not 'Very Even'")]
    [TestCase(     1234, false, TestName="1234 is not 'Very Even'")]
    [TestCase(       88, false, TestName="88 is not 'Very Even'")]
    [TestCase(       24,  true, TestName="24 is 'Very Even'")]
    [TestCase(400000220,  true, TestName="400000220 is 'Very Even'")]
    public void Test(int number, bool expected)
    {
        Assert.That(Kata.IsVeryEvenNumber(number), Is.EqualTo(expected));
    }
  
    [Test]
    public void RandomTests()
    {
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            var n = rnd.Next(1, int.MaxValue);
            var ex = SolutionIsVeryEvenNumber(n);
            Assert.That(Kata.IsVeryEvenNumber(n), Is.EqualTo(ex), $"{n} is {(ex?"":"not ")}'Very Even'");
        }
    }

    private bool SolutionIsVeryEvenNumber(int n)
    {
        if (n < 10) return n % 2 == 0;
        return SolutionIsVeryEvenNumber((n + "").Sum(x => Convert.ToInt32(x) - '0'));
    }
}
