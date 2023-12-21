/*Challenge link:https://www.codewars.com/kata/58e3f824a33b52c1dc0001c0/train/csharp
Question:This series of katas will introduce you to basics of doing geometry with computers.

Write the function circleArea/CircleArea which takes in a Circle object and calculates the area of that circle.
The Circle class can be seen below:

public class Circle
{
  public Point Center { get; private set; }
  public double Radius { get; private set; }
  
  public Circle(Point center, double radius)
  {
    this.Center = center;
    this.Radius = radius;
  }
}
And the Point class can be seen below:

public class Point
{
  public double X { get; private set; }
  public double Y { get; private set; }
  
  public Point(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }
}
Documentation:
Kata.CircleArea Method (Circle)
Returns the area of a circle.

Syntax

public static double CircleArea(
Circle circle
  )

Parameters
circle
Type: Circle
The circle to calculate the area of.

Return Value
Type: System.Double
A double representing the area of the circle.
Tests round answers to 6 decimal places.
*/

//***************Solution********************
//𝝅r^2 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using static System.Math;

public static class Kata{
  public static double CircleArea(Circle circle) =>  PI * Pow(circle.Radius, 2);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public static class Solution
  {
    public static double CircleArea(Circle circle)
    {
      return Math.PI * circle.Radius * circle.Radius;
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    private static double epsilon = 1e-6;
  
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.CircleArea(new Circle(new Point(10, 10), 30)), Is.EqualTo(2827.433388).Within(epsilon));
      Assert.That(Kata.CircleArea(new Circle(new Point(25, -70), 30)), Is.EqualTo(2827.433388).Within(epsilon));
      Assert.That(Kata.CircleArea(new Circle(new Point(-15, 5), 0)), Is.EqualTo(0).Within(epsilon));
      Assert.That(Kata.CircleArea(new Circle(new Point(-15, 5), 12.5)), Is.EqualTo(490.873852).Within(epsilon));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        Point point = new Point(rnd.NextDouble() * 100 - 50, rnd.NextDouble() * 100 - 50);
        Double radius = rnd.NextDouble() * 50;
        Circle circle = new Circle(point, radius);
        
        Assert.That(Kata.CircleArea(circle), Is.EqualTo(Solution.CircleArea(circle)).Within(epsilon));
      }
    }
  }
}
