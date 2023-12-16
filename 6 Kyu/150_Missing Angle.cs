/*Challenge link:https://www.codewars.com/kata/58417e9ab9c25c774500001f/train/csharp
Question:
Below is a right-angled triangle:

  |\
  | \
  |  \
  |   \ 
o |    \ h 
  |     \
  |    θ \
  |_______\ 
     a
Your challange is to write a function (missingAngle in C/C#, missing_angle in Ruby), that calculates the angle θ in degrees to the nearest integer. You will be given three arguments representing each side: o, h and a. One of the arguments equals zero. Use the length of the two other sides to calculate θ. You will not be expected to handle any erronous data in your solution.
*/

//***************Solution********************

//Sohcahtoa
//Sin = O/H
//Cos = A/H
//Tan = O/A

//finding radian
//if h is 0, Tan O/A
//if a is 0, Sin O/H
//else Cos A/H
//then using 180/π * radian, round to the nearest integer.
//Then simiplfied into one line by using an Lambda expression

using static System.Math;

class Kata {
  public static double missingAngle(double h, double a, double o) =>
    Round((180/PI) *
    (h == 0 ? Atan(o / a) :
     a == 0 ? Asin(o / h) :
     Acos(a / h)));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class FinalTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(37, Kata.missingAngle(0, 400, 300));
      Assert.AreEqual(37, Kata.missingAngle(5, 4, 0));
      Assert.AreEqual(37, Kata.missingAngle(5, 4, 0));
      Assert.AreEqual(39, Kata.missingAngle(8, 0, 5));
      Assert.AreEqual(39, Kata.missingAngle(8, 0, 5));
      Assert.AreEqual(47, Kata.missingAngle(16.7, 0, 12.3));
      Assert.AreEqual(44, Kata.missingAngle(7, 5, 0));
    }
    [Test]
    public void RandomTests()
    {
      double o = 0, h = 0, a = 0;
      int num; // 0 for no h; 1 for no a; 2 for no o.
      Random rand = new Random();
      for (int i = 0; i < 100000; i++) {
        num = rand.Next(0, 3);
        switch (num) {
        case 0:
          o = rand.NextDouble();
          a = rand.NextDouble();
          Assert.AreEqual(testMissingAngle(0, a, o), Kata.missingAngle(0, a, o));
          break;
        case 1:
          o = rand.NextDouble();
          h = rand.NextDouble();
          Assert.AreEqual(testMissingAngle(h, 0, o), Kata.missingAngle(h, 0, o));
          break;
        case 3:
          a = rand.NextDouble();
          h = rand.NextDouble();
          Assert.AreEqual(testMissingAngle(h, a, 0), Kata.missingAngle(h, a, 0));
          break;
        }
      }
    }   
    private static double testMissingAngle(double h, double a, double o) {
      if (h == 0)
        return Math.Round(Math.Atan(o/a)*(180/Math.PI));
      else if (a == 0)
        return Math.Round(Math.Asin(o/h)*(180/Math.PI));
      else if (o == 0)
        return Math.Round(Math.Acos(a/h)*(180/Math.PI));
      else
        return 0;
    }
  }
}
