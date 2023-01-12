/*Challenge link:https://www.codewars.com/kata/59dd3ccdded72fc78b000b25/train/csharp
Question:
Complete the function which returns the weekday according to the input number:

1 returns "Sunday"
2 returns "Monday"
3 returns "Tuesday"
4 returns "Wednesday"
5 returns "Thursday"
6 returns "Friday"
7 returns "Saturday"
Otherwise returns "Wrong, please enter a number between 1 and 7"
*/

//***************Solution********************
//return the day accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string WhatDay(int n)=>
    n == 1 ? "Sunday" : 
    n == 2 ? "Monday" :
    n == 3 ? "Tuesday" :
    n == 4 ? "Wednesday" :
    n == 5 ? "Thursday" :
    n == 6 ? "Friday" :
    n == 7 ? "Saturday" :
    "Wrong, please enter a number between 1 and 7";
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class SolutionTest
{
    [TestCase(1, "Sunday")]
    [TestCase(2, "Monday")]
    [TestCase(3, "Tuesday")]
    [TestCase(4, "Wednesday")]
    [TestCase(5, "Thursday")]
    [TestCase(6, "Friday")]
    [TestCase(7, "Saturday")]
    [TestCase(-1, "Wrong, please enter a number between 1 and 7")]
    [TestCase(0, "Wrong, please enter a number between 1 and 7")]
    [TestCase(8, "Wrong, please enter a number between 1 and 7")]
    [TestCase(20, "Wrong, please enter a number between 1 and 7")]
    public void FixedTest(int n, string expected)
    {
        Assert.AreEqual(expected, Kata.WhatDay(n));
    }

    [Test]
    public void RangeTest()
    {
        for (var i = -100; i < 100; i++)
        {
            Assert.AreEqual(Solution(i), Kata.WhatDay(i));
        }
    }

    [Test]
    public void RandomTest([Random(1, 1000, 30)] int n)
    {
        Assert.AreEqual(Solution(n), Kata.WhatDay(n));
    }

    private string Solution(int n) => n > 0 && n < 8
        ? new string[] {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}[n - 1]
        : "Wrong, please enter a number between 1 and 7";
}
