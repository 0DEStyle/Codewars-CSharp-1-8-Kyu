/*Challenge link:https://www.codewars.com/kata/6397b0d461067e0030d1315e/train/csharp
Question:
Write two functions, one that converts standard time to decimal time and one that converts decimal time to standard time.

One hour has 100 minutes (or 10,000 seconds) in decimal time, yet its duration is the same as in standard time. Thus a decimal minute consists of 36 standard seconds, which is 1/100 of an hour.
Working time is usually rounded to integer decimal minutes. Thus one standard minute equals 0.02 decimal hours, while two standard minutes equal 0.03 decimal hours and so on.
ToIndustrial(time) should accept either the time in minutes as an integer or a string of the format "h:mm". Minutes will always consist of two digits in the tests (e.g., "0:05"); hours can have more. Return a float that represents decimal hours (e.g. 1.75 for 1h 45m). Round to a precision of two decimal digits - do not simply truncate!
ToNormal(time)should accept a float representing decimal time in hours. Return a string that represents standard time in the format "h:mm".
There will be no seconds in the tests. We'll neglect them for the purpose of this kata.

Flavor text (click to expand)
Calculations with time units can be confusing, because we are used to calculating in the decimal system in every day use. An hour, however, consists of sixty minutes, which in turn consist of sixty seconds each.
When dealing with multiple entries of measured time - for example, in a working time recording - it can get hard to correctly sum up the total. A seemingly natural algorithm is to add up hours and minutes separately, then divmod the minutes with 60 to get additional complete hours and remaining minutes.

In Germany, some companies use decimal time (in German: "Industriezeit") to keep track of working hours, which makes it a lot easier to calculate multiple entries.
*/

//***************Solution********************

using System;
using System.Linq;

public class Kata{
    public static float ToIndustrial(dynamic time){
      double min;
      
      //check type
      if(time is int)
        min = time;
      
      //split time, then perform conversion.
      else{
        var arr = ((string[])time.Split(":")).Select(int.Parse).ToArray();
        min = (arr[0] * 60) + arr[1];
      }
      
      //typecast to float, round to 2dps
      return (float)Math.Round(min / 60, 2);
    }

    public static string ToNormal(float time){
      //convert to int and truncate
      //then format using string interpolation.
      var hour = (int)Math.Truncate(time);
      return $"{hour}:{Math.Round((time - hour) * 60, 0):00}";
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture, Description("100 Random Tests Cases")]
public class KataTests
{
	[Test, Description("ToIndustrial with Integers")]
	public void ToIndustrial([Random(1, 900, 100, Distinct = true)] int time)
	{
		Assert.AreEqual(InternalToIndustrial(time), Kata.ToIndustrial(time));
	}

	[Test, Description("ToIndustrial with Strings")]
	public void ToIndustrial([ValueSource(nameof(GetStringTimesArray))] string time)
	{
		Assert.AreEqual(InternalToIndustrial(time), Kata.ToIndustrial(time));
	}

	[Test, Description("ToNormal")]
	public void ToNormal([ValueSource(nameof(GetFloatsTimesArray))] float time)
	{
		Assert.AreEqual(InternalToNormal(time), Kata.ToNormal(time));
	}
	public static float InternalToIndustrial(int time) => MathF.Round(float.Parse(time.ToString()) / 60, 2);
	private static float InternalToIndustrial(string time)
	{
		return MathF.Round(time.ToString()
		.Split(':')
		.Select(int.Parse)
		.Aggregate((a, b) => a * 60 + b) / 60.0f, 2);
	}

	private static string InternalToNormal(float time)
	{
		var newTime = new TimeSpan(0, (int)Math.Round(time * 60), 0);
		var minutes = newTime.Minutes.ToString().PadLeft(2,'0');
		return $"{(int)newTime.TotalHours}:{minutes}";
	}

	private static string[] GetStringTimesArray()
	{
		var list = new HashSet<string>();
		var rand = TestContext.CurrentContext.Random;
		while (list.Count < 100)
		{
			var dt = new DateTime().AddMinutes(rand.Next());
			list.Add(dt.ToString("h:mm"));
		}
		return list.Select(s => $"{s}").ToArray();
	}

	private static float[] GetFloatsTimesArray()
	{
		var rand = TestContext.CurrentContext.Random;
		var list = new HashSet<float>();
		while (list.Count < 100)
		{
			float num = rand.Next(0, 115);
			float suf = rand.Next(99) / 100.0f;
			num += MathF.Round(suf * 100) / 100.0f;
			list.Add(num);
		}
		return list.ToArray();
	}
}
