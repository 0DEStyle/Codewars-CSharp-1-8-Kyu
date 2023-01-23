/*Challenge link:https://www.codewars.com/kata/55d277882e139d0b6000005d/train/csharp
Question:
Find Mean
Find the mean (average) of a list of numbers in an array.

Information
To find the mean (average) of a set of numbers add all of the numbers together and divide by the number of values in the list.

For an example list of 1, 3, 5, 7

1. Add all of the numbers

1+3+5+7 = 16
2. Divide by the number of values in the list. In this example there are 4 numbers in the list.

16/4 = 4
3. The mean (or average) of this list is 4


*/

//***************Solution********************
//find average of array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class GrassHopper {
        public static int FindAverage(int[] nums) => nums.Sum() /nums.Length;
    }
//or

using System.Linq;

public class GrassHopper 
    {
        public static int FindAverage(int[] nums)
        {
            return (int)nums.Average();
        }
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
            Assert.AreEqual(1, GrassHopper.FindAverage(new[] { 1 }));
        }

        [Test]
        public void SecondTest()
        {
            Assert.AreEqual(4, GrassHopper.FindAverage(new[] { 1, 3, 5, 7 }));
        }

        [Test]
        public void ThirdTest()
        {
            Assert.AreEqual(-5, GrassHopper.FindAverage(new[] { -10, -5, -5, 0 }));
        }

        [Test]
        public void FourthTest()
        {
            Assert.AreEqual(0, GrassHopper.FindAverage(new[] { 0 }));
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 10)] double d)
        {
            Rg rg = new Rg((int)d*10000);
            int[] randomArray = rg.RandomArray();
            Assert.AreEqual(GrassHopper21December.FindAverage(randomArray),GrassHopper.FindAverage(randomArray));
        }
    }
