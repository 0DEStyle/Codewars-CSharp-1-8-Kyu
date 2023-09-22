/*Challenge link:https://www.codewars.com/kata/56548dad6dae7b8756000037/train/csharp
Question:
Peter can see a clock in the mirror from the place he sits in the office. When he saw the clock shows 12:22

1
2
3
4
5
6
7
8
9
10
11
12
He knows that the time is 11:38

1
2
3
4
5
6
7
8
9
10
11
12
in the same manner:

05:25 --> 06:35

01:50 --> 10:10

11:58 --> 12:02

12:01 --> 11:59

Please complete the function WhatIsTheTime(timeInMirror), where timeInMirror is the mirrored time (what Peter sees) as string.

Return the real time as a string.

Consider hours to be between 1 <= hour < 13.

So there is no 00:20, instead it is 12:20.

There is no 13:20, instead it is 01:20.
*/

//***************Solution********************

//12:00 subtract timeInMirror, convert to format hh:mm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata{
        public static string WhatIsTheTime(string timeInMirror) =>
          DateTime.Parse("12:00").Subtract(TimeSpan.Parse(timeInMirror)).ToString("hh:mm");
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
    public class MyTest
    {
        [Test]
        public void FirstTest()
        {
            StringAssert.AreEqualIgnoringCase("06:35",Kata.WhatIsTheTime("05:25"));
        }

        [Test]
        public void SecondTest()
        {
            StringAssert.AreEqualIgnoringCase("11:59",Kata.WhatIsTheTime("12:01"));
        }
        
        [Test]
        public void ThirdTest()
        {
            StringAssert.AreEqualIgnoringCase("12:02", Kata.WhatIsTheTime("11:58"));
        }
        
        [Test]
        public void FourhTest()
        {
            StringAssert.AreEqualIgnoringCase("12:00", Kata.WhatIsTheTime("12:00"));
        }
        
        [Test]
        public void FifthTest()
        {
            StringAssert.AreEqualIgnoringCase("02:00", Kata.WhatIsTheTime("10:00"));
        }
        
        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            Rg rg = new Rg((int)d*10000);
            string time = rg.TimeGenerator();
            StringAssert.AreEqualIgnoringCase(Kata24November.WhatIsTheTime(time), Kata.WhatIsTheTime(time),"Mirror time is {0}, expect {1} but was {2}",time,Kata24November.WhatIsTheTime(time),Kata.WhatIsTheTime(time));
        }
    }
