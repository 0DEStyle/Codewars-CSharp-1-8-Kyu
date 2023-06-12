/*Challenge link:https://www.codewars.com/kata/57873ab5e55533a2890000c7/train/csharp
Question:
A new task for you!

You have to create a method, that corrects a given time string.
There was a problem in addition, so many of the time strings are broken.
Time is formatted using the 24-hour clock, so from 00:00:00 to 23:59:59.
Examples
"09:10:01" -> "09:10:01"  
"11:70:10" -> "12:10:10"  
"19:99:99" -> "20:40:39"  
"24:01:01" -> "00:01:01"  
If the input-string is null or empty return exactly this value! (empty string for C++) If the time-string-format is invalid, return null. (empty string for C++)

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have created other katas. Have a look if you like coding and challenges.
*/

//***************Solution********************

//using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Time{
  public static string Correct(string timeString){ 
    
    //check null or empty
    if(string.IsNullOrEmpty(timeString)) return timeString;
    
    //format validation test
    var str = Regex.Match(timeString, @"(\d{2}):(\d{2}):(\d{2})");
    if(!str.Success) return null;
    
    //Time formatting, to second
    DateTime d1 = new DateTime().AddSeconds(int.Parse(str.Groups[1].Value) * 3600 +
                                            int.Parse(str.Groups[2].Value) * 60 +
                                            int.Parse(str.Groups[3].Value));
    
    Console.WriteLine($"{d1.Hour:00}:{d1.Minute:00}:{d1.Second:00}");
    return $"{d1.Hour:00}:{d1.Minute:00}:{d1.Second:00}";
  }
}

//method 2
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Time
{
  public static string Correct(string timeString)
  {
    if (string.IsNullOrEmpty(timeString)) return timeString;
    if (!Regex.IsMatch(timeString, @"(\d{2}):(\d{2}):(\d{2})")) return null;
    var t = timeString.Split(':').Select(int.Parse).ToArray();
    return new TimeSpan(t[0], t[1], t[2]).ToString(@"hh\:mm\:ss");
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public void NullTest()
  {
    Assert.AreEqual(null, Time.Correct(null));
  }
  
  [Test]
  public void EmptyTest()
  {
    Assert.AreEqual("", Time.Correct(""));
  }
  
  [Test]
  public void InvalidFormatTests()
  {
    Assert.AreEqual(null, Time.Correct("001122"));
    Assert.AreEqual(null, Time.Correct("00;11;22"));
    Assert.AreEqual(null, Time.Correct("0a:1c:22"));
  } 
  
  [Test]
  public void CorrectionTests()
  {
    Assert.AreEqual("09:10:01", Time.Correct("09:10:01"));
    Assert.AreEqual("12:10:10", Time.Correct("11:70:10"));
    Assert.AreEqual("20:39:09", Time.Correct("19:99:09"));
    Assert.AreEqual("20:40:39", Time.Correct("19:99:99"));
    Assert.AreEqual("00:01:01", Time.Correct("24:01:01"));
    Assert.AreEqual("04:01:01", Time.Correct("52:01:01"));
    Assert.AreEqual("15:00:34", Time.Correct("14:59:94"));
  }  
  
  [Test]
  public void RandomTests()
  {
    Random rand = new Random((int)DateTime.Now.Ticks);
    
    for(int i = 0; i < 20; i++)
    {
      var hour = rand.Next(18, 89);
      var minute = rand.Next(56, 89);
      var second = rand.Next(57, 99);
      string timeString = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
      
      minute += second / 60;
      second = second % 60;      

      hour += minute / 60;    
      minute = minute % 60;
    
      hour = hour % 24; 
      
      string expected = string.Format("{0:D2}:{1:D2}:{2:D2}", hour, minute, second);
      Assert.AreEqual(expected, Time.Correct(timeString));
    }
  }
}
