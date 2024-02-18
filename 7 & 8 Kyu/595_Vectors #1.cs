/*Challenge link:https://www.codewars.com/kata/582b079bbbbc74bed7000095/train/csharp
Question:
##Let's make this short!

Remember, this is a kata which focuses on object oriented programming

Task: Create a class Vector3D

Properties: X, Y, Z and Length as double and public scope and accessors

X, Y and Z will be set by test methods

Length should only have an get-accessor which calculates the vector's length

##Some references, to get into the topic

The length or magnitude or norm of the vector a is denoted by ‖a‖ or, less commonly, |a|, which is not to be confused with the absolute value (a scalar "norm").

The length of the vector a can be computed with the Euclidean norm

How to calculate a vector's length - Link created 2016/11/15
##Tests

Final tests include 2 fixed and 125 random tests. They will look like this:

double length = new Vector3D()
{
  X = 0,
  Y = 0,
  Z = 2
}.Length;
length == 2 // true
##PostScriptum

If this kata gets enough reputation, I will add some follow up katas!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/
using static System.Math;
public class Vector3D{
  public double X{get;set;}
  public double Y{get;set;}
  public double Z{get;set;}
  //Length of vector = sqare root of x^2 + y^2 + z^2
  public double Length => Sqrt(X*X+Y*Y+Z*Z);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(0,2,0,ExpectedResult=2)]
  [TestCase(1,2,2,ExpectedResult=3)]
  public static double FixedTest(double x, double y, double z)
  {
    return new Vector3D()
    {
      X = x,
      Y = y,
      Z = z
    }.Length;
  }
  
  [Test]
  public static void RandomTest([Random(-10,10,5)] double x, [Random(-10,10,5)] double y, [Random(-10,10,5)] double z)
  {
    Assert.AreEqual(Solution(x,y,z), new Vector3D(){X=x,Y=y,Z=z}.Length, "Calculation of vector's length is not working correct!");
  }
  
  private static double Solution(double a, double b, double c)
  {
    return Math.Sqrt(Math.Pow(a, 2)+Math.Pow(b, 2)+Math.Pow(c, 2));
  }
}
