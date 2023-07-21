/*Challenge link:https://www.codewars.com/kata/52742f58faf5485cae000b9a/train/csharp
Question:
Your task in order to complete this Kata is to write a function which formats a duration, given as a number of seconds, in a human-friendly way.

The function must accept a non-negative integer. If it is zero, it just returns "now". Otherwise, the duration is expressed as a combination of years, days, hours, minutes and seconds.

It is much easier to understand with an example:

* For seconds = 62, your function should return 
    "1 minute and 2 seconds"
* For seconds = 3662, your function should return
    "1 hour, 1 minute and 2 seconds"
For the purpose of this Kata, a year is 365 days and a day is 24 hours.

Note that spaces are important.

Detailed rules
The resulting expression is made of components like 4 seconds, 1 year, etc. In general, a positive integer and one of the valid units of time, separated by a space. The unit of time is used in plural if the integer is greater than 1.

The components are separated by a comma and a space (", "). Except the last component, which is separated by " and ", just like it would be written in English.

A more significant units of time will occur before than a least significant one. Therefore, 1 second and 1 year is not correct, but 1 year and 1 second is.

Different components have different unit of times. So there is not repeated units like in 5 seconds and 1 second.

A component will not appear at all if its value happens to be zero. Hence, 1 minute and 0 seconds is not valid, but it should be just 1 minute.

A unit of time must be used "as much as possible". It means that the function should not return 61 seconds, but 1 minute and 1 second instead. Formally, the duration specified by of a component must not be greater than any valid more significant unit of time.


*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

public class HumanTimeFormat{
  public static string formatDuration(int seconds){
    
    //return "now" if seconds is equal to 0
    if (seconds == 0) return "now";
    
    //set a TimeSpan that represents a specified number of seconds
    //year, convert seconds to days, and divide by 365 to become year.
    //day, convert seconds to days and mod 365 to get remaining days
    //hour/minute/second, convert seconds to hours/minutes/seconds.
    //store all format in timesList
    var time = TimeSpan.FromSeconds(seconds);
    var timesList = new string[]{
      MultipleFormat("year", time.Days / 365),
      MultipleFormat("day", time.Days % 365),
      MultipleFormat("hour", time.Hours),
      MultipleFormat("minute", time.Minutes),
      MultipleFormat("second", time.Seconds)
    };
    
    //store everything that is not empty in timesList into list.
		var list = timesList.Where(x => x != string.Empty).ToList();
    
    //return first of the list if count is 1
    if (list.Count == 1) return list.First();
    
		//creating the first variable for printing.
    var firstPart = string.Join(", ", list.Take(list.Count - 1));
		
    //string interpolation to output result.
		return $"{firstPart} and {list.Last()}";
  }
  
  //check plural to add s at the end.
  private static string MultipleFormat(string measure, double count){
    //store count into c
    var c = (int)count;
    
    //if string is not empty or c is equal to 0, return empty string.
    if (measure == string.Empty || c == 0) return string.Empty;
    
    //if c is not 1, set mesaure to measure + "s", for plural.
    if (c != 1) measure = measure + "s";
    
    //string interpolation to output result.
    return $"{c} {measure}";
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class Tests {
  [Test]
  public void basicTests() {
    Assert.AreEqual("now",HumanTimeFormat.formatDuration(0));
    Assert.AreEqual("1 second",HumanTimeFormat.formatDuration(1));
    Assert.AreEqual("1 minute and 2 seconds",HumanTimeFormat.formatDuration(62));
    Assert.AreEqual("2 minutes",HumanTimeFormat.formatDuration(120));
    Assert.AreEqual("1 hour, 1 minute and 2 seconds",HumanTimeFormat.formatDuration(3662));
    Assert.AreEqual("182 days, 1 hour, 44 minutes and 40 seconds",HumanTimeFormat.formatDuration(15731080));
    Assert.AreEqual("4 years, 68 days, 3 hours and 4 minutes",HumanTimeFormat.formatDuration(132030240));
    Assert.AreEqual("6 years, 192 days, 13 hours, 3 minutes and 54 seconds",HumanTimeFormat.formatDuration(205851834));
    Assert.AreEqual("8 years, 12 days, 13 hours, 41 minutes and 1 second",HumanTimeFormat.formatDuration(253374061));
    Assert.AreEqual("7 years, 246 days, 15 hours, 32 minutes and 54 seconds",HumanTimeFormat.formatDuration(242062374));
    Assert.AreEqual("3 years, 85 days, 1 hour, 9 minutes and 26 seconds",HumanTimeFormat.formatDuration(101956166));
    Assert.AreEqual("1 year, 19 days, 18 hours, 19 minutes and 46 seconds",HumanTimeFormat.formatDuration(33243586));
  }
  
  private const int MINS = 60;
  private const int HOURS = 60 * MINS;
  private const int DAYS = 24 * HOURS;
  private const int YEARS = 365 * DAYS;
  private string Sol(int seconds){
    var years = 0;
    var days = 0;
    var hours = 0;
    var minutes = 0;
    var toParse = seconds;
    var ret = "";
    if(toParse == 0) return "now";
    if(toParse >= YEARS){
      years = toParse / YEARS;
      toParse = toParse % YEARS;
    }
    if(toParse >= DAYS){
      days = toParse / DAYS;
      toParse = toParse % DAYS;
    }
    if(toParse >= HOURS){
      hours = toParse / HOURS;
      toParse = toParse % HOURS;
    }
    if(toParse >= MINS){
      minutes = toParse / MINS;
      toParse = toParse % MINS;
    }
    if(years > 0){
      if(years ==1) ret += string.Format("{0} year,", years);
      else ret += string.Format("{0} years,", years);
    }
    if(days > 0){
      if(days ==1) ret += string.Format("{0} day,", days);
      else ret += string.Format("{0} days,", days);
    }
    if(hours > 0){
      if(hours ==1) ret += string.Format("{0} hour,", hours);
      else ret += string.Format("{0} hours,", hours);
    }
    if(minutes > 0){
      if(minutes ==1) ret += string.Format("{0} minute,", minutes);
      else ret += string.Format("{0} minutes,", minutes);
    }
    if(toParse > 0){
      if(toParse ==1) ret += string.Format("{0} second,", toParse);
      else ret += string.Format("{0} seconds,", toParse);
    }
    ret = ret.TrimEnd(','); 
    var retSplit = ret.Split(',');
    var count = retSplit.Count();
    if(count > 1){
      ret = string.Join(", ", retSplit.Take(count -1));
      ret += " and ";
      ret += retSplit.Last();
    }   
    return ret.Trim();
  }
  
  [Test]
  public void RandomTests() {
    Random r = new Random();
    for (int i = 0; i < 100; i++) {
      int n = r.Next(10000000);
      Assert.AreEqual(Sol(n), HumanTimeFormat.formatDuration(n));
    }
  }
}
