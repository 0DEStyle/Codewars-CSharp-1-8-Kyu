/*Challenge link:https://www.codewars.com/kata/588f5a38ec641b411200005b/train/csharp
Question:
Write a function that receives two strings as parameter. This strings are in the following format of date: YYYY/MM/DD. Your job is: Take the years and calculate the difference between them.

Examples:
'1997/10/10' and '2015/10/10' -> 2015 - 1997 = returns 18 
'2015/10/10' and '1997/10/10' -> 2015 - 1997 = returns 18
At this level, you don't need validate months and days to calculate the difference.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern (?<= positive lookahead matches group before main expression
//^ start, any digit, match 4 times.
//  / followed by any digit match 2 times, /, any digit match 2 times
//replace with nothing parse to int
using System;
using System.Text.RegularExpressions;

public static class Kata{
  public static int myParse(string s) 
    => Int32.Parse(Regex.Replace(s, @"(?<=^\d{4})/\d{2}/\d{2}", ""));
    
//get absolute value because we don't know which one is bigger
    public static int HowManyYears(string date1, string date2) =>
      Math.Abs(myParse(date1) - myParse(date2));
}

//linq
using System;

public static class Kata
{
  public static int HowManyYears(string date1, string date2)
  {
    return Math.Abs(DateTime.Parse(date1).Year - DateTime.Parse(date2).Year);
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Globalization;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(18, Kata.HowManyYears("1997/10/10", "2015/10/10"));
        Assert.AreEqual(25, Kata.HowManyYears("1990/10/10", "2015/10/10"));
        Assert.AreEqual(25, Kata.HowManyYears("2015/10/10", "1990/10/10"));
        Assert.AreEqual(23, Kata.HowManyYears("1992/10/24", "2015/10/24"));
        Assert.AreEqual(18, Kata.HowManyYears("2018/10/10", "2000/10/10"));
        Assert.AreEqual(0, Kata.HowManyYears("2000/10/10", "2000/10/10"));
    }

    private static int Solution(string date1, string date2)
    {
        return Math.Abs(DateTime.Parse(date1).Year - DateTime.Parse(date2).Year);
    }

    private static readonly Random Rand = new Random();

    private static string RandomDateTime()
    {
        return new DateTime().AddYears(Rand.Next(1, 2100)).AddMonths(Rand.Next(1, 12)).AddDays(Rand.Next(1, 31))
            .ToString("yyyy/MM/dd", CultureInfo.InvariantCulture);
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 200; i++)
        {
            var dt1 = RandomDateTime();
            var dt2 = RandomDateTime();
            var expected = Solution(dt1, dt2);
            var message = FailureMessage(dt1, dt2, expected);
            var actual = Kata.HowManyYears(dt1, dt2);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(string dt1, string dt2, int value)
    {
        return $"Should return {value} with {dt1} and {dt2}";
    }
}
