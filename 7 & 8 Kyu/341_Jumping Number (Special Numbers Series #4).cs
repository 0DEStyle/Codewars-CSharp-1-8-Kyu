/*Challenge link:https://www.codewars.com/kata/5a54e796b3bfa8932c0000ed/train/csharp
Question:
Definition
Jumping number is the number that All adjacent digits in it differ by 1.

Task
Given a number, Find if it is Jumping or not .

Warm-up (Highly recommended)
Playing With Numbers Series
Notes
Number passed is always Positive .

Return the result as String .

The difference between ‘9’ and ‘0’ is not considered as 1 .

All single digit numbers are considered as Jumping numbers.

Input >> Output Examples
jumpingNumber(9) ==> return "Jumping!!"
Explanation:
It's single-digit number
jumpingNumber(79) ==> return "Not!!"
Explanation:
Adjacent digits don't differ by 1
jumpingNumber(23) ==> return "Jumping!!"
Explanation:
Adjacent digits differ by 1
jumpingNumber(556847) ==> return "Not!!"
Explanation:
Adjacent digits don't differ by 1
jumpingNumber(4343456) ==> return "Jumping!!"
Explanation:
Adjacent digits differ by 1
jumpingNumber(89098) ==> return "Not!!"
Explanation:
Adjacent digits don't differ by 1
jumpingNumber(32) ==> return "Jumping!!"
Explanation:
Adjacent digits differ by 1
*/

//***************Solution********************
//check if number is less than 10, if so, then it's a jumping number
//else use Recursive method to test each number, number / 10 to shift the digit.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
class Kata{
    public static string JumpingNumber(int number) =>
      number < 10 ? "Jumping!!" : Math.Abs(number % 10 - (number / 10) % 10) != 1 ? "Not!!" : JumpingNumber(number / 10);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
class Tests
{
    [TestCase(1)]
    [TestCase(7)]
    [TestCase(9)]
    [TestCase(23)]
    [TestCase(32)]
    [TestCase(98)]
    [TestCase(8987)]
    [TestCase(4343456)]
    [TestCase(98789876)]
    public void BasicJumpingNumbers(int number)
    {
        Assert.That(Kata.JumpingNumber(number), Is.EqualTo("Jumping!!"));
    }
    [TestCase(00000079)]
    public void BasicNotNumbers(int number)
    {
        Assert.That(Kata.JumpingNumber(number), Is.EqualTo("Not!!"));
    }
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var number = WOW(1, 1000000);
            var expected = SolutionJumpingNumber(number);
            Assert.That(Kata.JumpingNumber(number), Is.EqualTo(expected));
        }
    }
    static Random rnd = new Random();
    static int WOW(int a, int b) => rnd.Next(b - a + 1) + a;
    static string SolutionJumpingNumber(int number)
    {
        var s = number.ToString().Select(x => Convert.ToInt32(x) - '0').ToArray();
        for (var y = 0; y < s.Length; y++)
            for (var i = 0; i < s.Length - 1; i++)
                if (1 != Math.Abs(s[i] - s[i + 1])) return "Not!!";
        return "Jumping!!";
    }
}
