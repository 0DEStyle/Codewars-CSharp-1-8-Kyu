/*Challenge link:https://www.codewars.com/kata/52685f7382004e774f0001f7/train/csharp
Question:
Write a function, which takes a non-negative integer (seconds) as input and returns the time in a human-readable format (HH:MM:SS)

HH = hours, padded to 2 digits, range: 00 - 99
MM = minutes, padded to 2 digits, range: 00 - 59
SS = seconds, padded to 2 digits, range: 00 - 59
The maximum time never exceeds 359999 (99:59:59)

You can find some examples in the test fixtures.
*/

//***************Solution********************
//Solution 1
//Check max condition, apply algorithm, create the correct format and return result.
public static class TimeFormat
{
    public static string GetReadableTime(int seconds){
      int minutes = 0, hours = 0, secondRemainder = 0, minutesRemainder = 0;
      string text = "";
      
      if(seconds > 359999)
        return text;
      if(seconds >= 59){
        secondRemainder = seconds % 60;
        minutes = (seconds - secondRemainder) / 60;
        minutesRemainder = minutes % 60;
        hours = (minutes - minutesRemainder) / 60;
      }
      
      if (hours.ToString().Length == 1) text += "0" + hours.ToString();
      else text += hours.ToString();
      
      if (minutesRemainder.ToString().Length == 1) text += ":0" + minutesRemainder.ToString();
      else text += ":" + minutesRemainder.ToString();
      
      if (secondRemainder.ToString().Length == 1) text += ":0" + secondRemainder.ToString();
      else text += ":" + secondRemainder.ToString();

      return text;
    }
}

//Solution 2
//apply algorithm using format.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public static class TimeFormat
{
    public static string GetReadableTime(int seconds) =>
         string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
}

//Solution 3
//same as above

class TimeFormat
{
  public static string GetReadableTime(int seconds) => $"{seconds / 3600:00}:{seconds / 60 % 60:00}:{seconds % 60:00}";
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class HumanReadableTimeTest
{
  [Test]
  public void HumanReadableTest()
  {
      Assert.AreEqual("00:00:00", TimeFormat.GetReadableTime(0));
      Assert.AreEqual("00:00:59", TimeFormat.GetReadableTime(59));
      Assert.AreEqual("00:01:00", TimeFormat.GetReadableTime(60));
      Assert.AreEqual("00:01:30", TimeFormat.GetReadableTime(90));
      Assert.AreEqual("00:59:59", TimeFormat.GetReadableTime(3599));
      Assert.AreEqual("01:00:00", TimeFormat.GetReadableTime(3600));
      Assert.AreEqual("12:34:56", TimeFormat.GetReadableTime(45296));
      Assert.AreEqual("23:59:59", TimeFormat.GetReadableTime(86399));
      Assert.AreEqual("24:00:00", TimeFormat.GetReadableTime(86400));
      Assert.AreEqual("99:59:59", TimeFormat.GetReadableTime(359999));
  }
}
