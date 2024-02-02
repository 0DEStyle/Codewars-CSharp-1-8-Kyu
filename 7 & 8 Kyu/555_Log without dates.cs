/*Challenge link:https://www.codewars.com/kata/64cac86333ab6a14f70c6fb6/train/csharp
Question:
You will be given an array of events, which are represented by strings. The strings are dates in HH:MM:SS format.

It is known that all events are recorded in chronological order and two events can't occur in the same second.

Return the minimum number of days during which the log is written.

Example:

Input -> ["00:00:00", "00:01:11", "02:15:59", "23:59:58", "23:59:59"]
Output -> 1

Input -> ["12:12:12"]
Output -> 1

Input -> ["12:00:00", "23:59:59", "00:00:00"]
Output -> 2

Input -> []
Output -> 0
Good luck
*/

//***************Solution********************
using System;
using System.Linq;

public static class Kata{
  public static int CheckLogs(string[] log){
  //parse to time and store in array
    var timeArr = log.Select(TimeOnly.Parse).ToArray();
    //x is current element, i is index,
    //get element where if index is 0 or element index -1 in timeArr is less than or equal to x, then count it
    return timeArr.Where((x, i) => i == 0 || x <= timeArr[i - 1]).Count();
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class KataTests
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(1, Kata.CheckLogs(new[] { "12:12:12" }));
    Assert.AreEqual(1, Kata.CheckLogs(new[] { "00:00:00", "00:01:11", "02:15:59", "23:59:58", "23:59:59" }));
    Assert.AreEqual(2, Kata.CheckLogs(new[] { "12:00:00", "23:59:59", "00:00:00" }));
    Assert.AreEqual(3, Kata.CheckLogs(new[] { "12:00:00", "12:00:00", "00:00:00" }));
    Assert.AreEqual(5, Kata.CheckLogs(new[] { "00:00:00", "00:00:00", "00:00:00", "00:00:00", "00:00:00" }));
    Assert.AreEqual(1, Kata.CheckLogs(new[] { "10:10:10", "11:11:11", "12:12:12", "13:13:13", "14:14:14", "15:15:15", "16:16:16" }));
    Assert.AreEqual(2, Kata.CheckLogs(new[] { "23:59:59", "00:00:00" }));
    Assert.AreEqual(2, Kata.CheckLogs(new[] { "00:00:00", "00:00:01", "00:00:01" }));
    Assert.AreEqual(0, Kata.CheckLogs(Array.Empty<string>()));
    Assert.AreEqual(30, Kata.CheckLogs(Enumerable.Repeat("00:00:00", 30).ToArray()));
  }

  private static readonly Random Rand = new();

  [Test]
  public void RandomTest()
  {
    for (var i = 0; i < 100; i++)
    {
        var log = GenerateArrayTime();
        var expected = Solution(log);
        var message = FailureMessage(log, expected);
        var actual = Kata.CheckLogs(log);
        Assert.AreEqual(expected, actual, message);
    }
  }
  
  private static int Solution(string[] log)
  {
    var timeLog = log.Select(TimeOnly.Parse).ToArray();
    var days = 0;

    for (var i = 0; i < timeLog.Length; i++)
    {
        if (i == 0 || timeLog[i] <= timeLog[i - 1]) days++;
    }

    return days;
  }

  private static string[] GenerateArrayTime()
  {
    var num = Rand.Next(2, 100);
    var result = new List<string>();
    for (var i = 0; i < num; i++)
    {
        var hh = Rand.Next(0, 24).ToString("00");
        var mm = Rand.Next(0, 60).ToString("00");
        var ss = Rand.Next(0, 60).ToString("00");

        var time = string.Join(":", hh, mm, ss);
        result.Add(time);

        // randomly duplicate some elements (otherwise they very rarery occur)
        if (num < 80 && result.Count < 80 && Rand.Next(0, 6) == 0) result.Add(time);
    }

    return result.ToArray();
  }

  private static string FailureMessage(string[] actual, int expected)
  {
    return $"Should return {expected} with log=[{string.Join(", ", actual.Select(x => $"\"{x}\""))}]";
  }
}
