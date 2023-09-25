/*Challenge link:https://www.codewars.com/kata/59752e1f064d1261cb0000ec/train/csharp
Question:
Story
Due to lack of maintenance the minute-hand has fallen off Town Hall clock face.

And because the local council has lost most of our tax money to an elaborate email scam there are no funds to fix the clock properly.

Instead, they are asking for volunteer programmers to write some code that tell the time by only looking at the remaining hour-hand!

What a bunch of cheapskates!

Can you do it?

Kata
Given the angle (in degrees) of the hour-hand, return the time in 12 hour HH:MM format. Round down to the nearest minute.

Examples
12:00 = 0 degrees

03:00 = 90 degrees

06:00 = 180 degrees

09:00 = 270 degrees

12:00 = 360 degrees

Notes
0 <= angle <= 360

Do not make any AM or PM assumptions for the HH:MM result. They are indistinguishable for this Kata.

3 o'clock is 03:00, not 15:00
7 minutes past midnight is 12:07
7 minutes past noon is also 12:07
*/

//***************Solution********************

//create new DateTime, angle / 360 to get minute, * 12 to get hour.
//format to hh:mm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Dinglemouse{
  public static string WhatTimeIsIt(double angle) => 
    DateTime.Today.Add(TimeSpan.FromHours((angle / 360) * 12)).ToString("hh:mm");
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private static object[] Example_Test_Cases = new object[]
    {
      new object[] {"12:00", 0},
      new object[] {"12:00", 360},
      new object[] {"03:00", 90},
      new object[] {"06:00", 180},
      new object[] {"09:00", 270},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Example_Test_Cases")]
    public void Example_Test(string expected, double test)
    {
      Assert.AreEqual(expected, Dinglemouse.WhatTimeIsIt(test));
    }
    
    private static object[] Extended_Test_Cases = new object[]
    {
      new object[] {"01:00", 30},
      new object[] {"01:20", 40},
      new object[] {"01:30", 45},
      new object[] {"01:40", 50},
      new object[] {"02:00", 60},
    };
    
    [Test, TestCaseSource(typeof(SolutionTest), "Extended_Test_Cases")]
    public void Extended_Test(string expected, double test)
    {
      Assert.AreEqual(expected, Dinglemouse.WhatTimeIsIt(test));
    }
    
    private static Random rnd = new Random();
    
    private static string solution(double angle)
    {
      int minutes, hours;
      
      minutes = (int)(angle * 2);
      hours = minutes / 60;
      minutes %= 60;
      if (hours == 0) { hours = 12; }
      
      return $"{hours.ToString("D2")}:{minutes.ToString("D2")}";
    }
    
    [Test]
    public void Random_Tests()
    {
      for (int i = 0; i < 100; ++i)
      {
        double angle = rnd.NextDouble() * 360;
        string expected = solution(angle);
        string actual = Dinglemouse.WhatTimeIsIt(angle);
        Console.WriteLine("{0}d = <span style='color:green'>{1}</span>", angle.ToString("F2"), expected);
        Assert.AreEqual(expected, actual);
      }
    }
    
  }
}
