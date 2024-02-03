/*Challenge link:https://www.codewars.com/kata/59b0a6da44a4b7080300008a/train/csharp
Question:
Converting a 12-hour time like "8:30 am" or "8:30 pm" to 24-hour time (like "0830" or "2030") sounds easy enough, right? Well, let's see if you can do it!

You will have to define a function, which will be given an hour (always in the range of 1 to 12, inclusive), a minute (always in the range of 0 to 59, inclusive), and a period (either a.m. or p.m.) as input.

Your task is to return a four-digit string that encodes that time in 24-hour time.

Notes
By convention, noon is 12:00 pm, and midnight is 12:00 am.
On 12-hours clock, there is no 0 hour, and time just after midnight is denoted as, for example, 12:15 am. On 24-hour clock, this translates to 0015.

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//data time format ref: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
//hours: minutes period
//time parse, string interpolation to format result, convert to string at
//HH 	The hour, using a 24-hour clock from 00 to 23, mm The minute, from 00 to 59.
using System;

namespace Kata {  
  public class TimeConvert {    
   public static string Convert12hTo24h(int hours, int minutes, string period) =>
     TimeOnly.Parse($"{hours}:{minutes}{period}").ToString("HHmm");
  }  
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

using Kata;

namespace KataTest {
  
  [TestFixture]
  public class FixedTests
  {
    [TestCase(1,  0, ExpectedResult="0100", Description="Should return \"0100\" for hour=1, minutes=0, period=\"am\"")]
    [TestCase(2, 15, ExpectedResult="0215", Description="Should return \"0215\" for hour=2, minutes=15, period=\"am\"")]
    public string TestPeriodAm(int hour, int minutes) =>
      TimeConvert.Convert12hTo24h(hour, minutes, "am");
    
    [TestCase(1,  0, ExpectedResult="1300", Description="Should return \"1300\" for hour=1, minutes=0, period=\"pm\"")]
    [TestCase(2, 15, ExpectedResult="1415", Description="Should return \"1415\" for hour=2, minutes=15, period=\"pm\"")]
    public string TestPeriodPm(int hour, int minutes) =>
      TimeConvert.Convert12hTo24h(hour, minutes, "pm");
    
    [TestCase("am", ExpectedResult="0000", Description="Midnight: should return \"0000\" for hour=12, minutes=0, period=\"am\"")]
    [TestCase("pm", ExpectedResult="1200", Description="Noon: should return \"1200\" for hour=12, minutes=0, period=\"pm\"")]
    public string TestEdgeCases(string period) =>
      TimeConvert.Convert12hTo24h(12, 0, period);
    
  }
  
  [TestFixture]
  public class RandomTests
  {
    [TestCaseSource(nameof(GenerateTestCases))]
    public string TestRandom(int hour, int minutes, string period) =>
      TimeConvert.Convert12hTo24h(hour, minutes, period);
    
    static IEnumerable<TestCaseData> GenerateTestCases() {
      
      IList<TestCaseData> tests = new List<TestCaseData>();
      Random rnd = new Random();
      for(int h=0; h < 24; ++h) {
        int minuteLo = rnd.Next(0, 10);
        tests.Add(MakeTestCase(h, minuteLo));
        int minuteHi = rnd.Next(10, 60);
        tests.Add(MakeTestCase(h, minuteHi));
      }
      
      return tests
        .Select(e => (Elem: e, Key: rnd.Next()))
        .OrderBy(t => t.Key)
        .Select(t => t.Elem);
    }
    
    private static TestCaseData MakeTestCase(int h24, int m) {
      string expected = $"{h24:D2}{m:D2}";      
      int h = h24 == 0 ? 12 : h24 > 12 ? h24 - 12 : h24;
      string period = h24 < 12 ? "am" : "pm";      
      string title = $"Should return \"{expected}\" for hour={h}, minutes={m}, period=\"{period}\"";
      return new TestCaseData(h, m, period).Returns(expected).SetDescription(title);
    }
  }  
}
