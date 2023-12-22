/*Challenge link:https://www.codewars.com/kata/578a8a01e9fd1549e50001f1/train/csharp
Question:
In this kata, we will make a function to test whether a period is late.

Our function will take three parameters:

last - The Date object with the date of the last period

today - The Date object with the date of the check

cycleLength - Integer representing the length of the cycle in days

Return true if the number of days passed from last to today is greater than cycleLength. Otherwise, return false.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//find difference between today and last, extract the days from result, compare to cycleLength and return bool value.
using System;

public static class Kata{
  public static bool PeriodIsLate(DateTime last, DateTime today, int cycleLength) => (today - last).Days > cycleLength;
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 35));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 07, 16), 35));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 13), new DateTime(2016, 06, 29), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 07, 12), new DateTime(2016, 08, 09), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 07, 12), new DateTime(2016, 08, 10), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 07, 01), new DateTime(2016, 08, 01), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 06, 01), new DateTime(2016, 06, 30), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2016, 01, 01), new DateTime(2016, 01, 31), 30));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2016, 01, 01), new DateTime(2016, 02, 01), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2020, 06, 01), new DateTime(2020, 07, 01), 40));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2020, 06, 01), new DateTime(2020, 06, 30), 30));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2020, 06, 12), new DateTime(2020, 07, 12), 28));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2000, 01, 01), new DateTime(2000, 01, 01), 28));
    Assert.AreEqual(true,  Kata.PeriodIsLate(new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), 30));
    Assert.AreEqual(false, Kata.PeriodIsLate(new DateTime(2022, 01, 01), new DateTime(2022, 02, 01), 40));
  }
  
  private static readonly Random Rand = new();

  [Test]
  public void RandomTest()
  {
    for (var i = 0; i < 100; i++)
    {
      var last = RandomDate();
      var today = last.AddDays(Rand.Next(20, 41));
      var cycleLength = Rand.Next(20, 41);

      var expected = Solution(last, today, cycleLength);
      var actual = Kata.PeriodIsLate(last, today, cycleLength);
      var message = FailureMessage(last, today, cycleLength, expected);

      Assert.AreEqual(expected, actual, message);
    }
  }

  private static bool Solution(DateTime last, DateTime today, int cycleLength)
  {
    return (today - last).TotalDays > cycleLength;
  }

  private static DateTime RandomDate()
  {
    var start = new DateTime(2023, 1, 1);
    var range = (DateTime.Today - start).Days;
    return start.AddDays(Rand.Next(range));
  }

  private static string FailureMessage(DateTime last, DateTime today, int cycleLength, bool expected)
  {
    return $"Should return {expected} with last={last:yyyy-MM-dd}, today={today:yyyy-MM-dd}, cycleLength={cycleLength}";
  }
}
