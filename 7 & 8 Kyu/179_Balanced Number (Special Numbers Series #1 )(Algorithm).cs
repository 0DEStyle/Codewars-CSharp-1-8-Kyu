/*Challenge link:https://www.codewars.com/kata/5a4e3782880385ba68000018/train/csharp
Question:
A balanced number is a number where the sum of digits to the left of the middle digit(s) and the sum of digits to the right of the middle digit(s) are equal.

If the number has an odd number of digits, then there is only one middle digit. (For example, 92645 has one middle digit, 6.) Otherwise, there are two middle digits. (For example, the middle digits of 1301 are 3 and 0.)

The middle digit(s) should not be considered when determining whether a number is balanced or not, e.g. 413023 is a balanced number because the left sum and right sum are both 5.

The task
Given a number, find if it is balanced, and return the string "Balanced" or "Not Balanced" accordingly. The passed number will always be positive.

Examples
7 ==> return "Balanced"
Explanation:
middle digit(s): 7
sum of all digits to the left of the middle digit(s) -> 0
sum of all digits to the right of the middle digit(s) -> 0
0 and 0 are equal, so it's balanced.
295591 ==> return "Not Balanced"
Explanation:
middle digit(s): 55
sum of all digits to the left of the middle digit(s) -> 11
sum of all digits to the right of the middle digit(s) -> 10
11 and 10 are not equal, so it's not balanced.
959 ==> return "Balanced"
Explanation:
middle digit(s): 5
sum of all digits to the left of the middle digit(s) -> 9
sum of all digits to the right of the middle digit(s) -> 9
9 and 9 are equal, so it's balanced.
27102983 ==> return "Not Balanced"
Explanation:
middle digit(s): 02
sum of all digits to the left of the middle digit(s) -> 10
sum of all digits to the right of the middle digit(s) -> 20
10 and 20 are not equal, so it's not balanced.

*/

//***************Solution********************
//From string n, find the sum of the first half of the digits and then compare to the sum of the last half o the digits
//if they are equal return "Balanced" else "Not Balanced"
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

class Kata{
  public static string BalancedNumber(int n) =>
    $"{n}".Take(($"{n}".Length + 1) / 2 - 1).Sum(c => c) == $"{n}".Skip($"{n}".Length / 2 + 1).Sum(c => c)
        ? "Balanced"
        : "Not Balanced";
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using static System.String;
[TestFixture]
class Tests
{
    [TestCase(7, "Balanced")]
    [TestCase(959, "Balanced")]
    [TestCase(13, "Balanced")]
    [TestCase(56239814, "Balanced")]
    [TestCase(424, "Balanced")]
    public void BalancedTests(int input, string expected)
    {
        Assert.That(Kata.BalancedNumber(input), Is.EqualTo(expected));
    }
    [TestCase(1024, "Not Balanced")]
    [TestCase(66545, "Not Balanced")]
    [TestCase(295591, "Not Balanced")]
    [TestCase(1230987, "Not Balanced")]
    [TestCase(432, "Not Balanced")]
    public void NotBalancedTests(int input, string expected)
    {
        Assert.That(Kata.BalancedNumber(input), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTests()
    {
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            var input = rnd.Next();
            var expected = SolutionBalancedNumber(input);
            Assert.That(Kata.BalancedNumber(input), Is.EqualTo(expected));
        }
    }
    static string s = "";
    string SolutionBalancedNumber(int number)
    {
        s = number.ToString();
        var equal = SumUp(Sub(Concat(s.Reverse()))) == SumUp(Sub(s));
        return equal ? "Balanced" : "Not Balanced";
    }
    string Sub(string s) => Concat(s.Skip(((s.Length - 2) / 2) + 2));
    int SumUp(string v) => v.Select(x => Convert.ToInt32(x) - '0').Sum();
}
