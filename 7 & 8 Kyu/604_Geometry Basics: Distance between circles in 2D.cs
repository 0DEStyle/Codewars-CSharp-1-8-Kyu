/*Challenge link:https://www.codewars.com/kata/58e3031ce265671f6a000542/train/csharp
Question:
This series of katas will introduce you to basics of doing geometry with computers.

Point objects have x, y attributes. Circle objects have center which is a Point, and radius which is a number.

Write a function calculating distance between Circle a and Circle b.

If they're overlapping or one is completely within the other, just return zero.

Tests round answers to 6 decimal places, so you don't need to round them yourselves.
*/

//***************Solution********************
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨

      public class Circle
      {
        public Point Center {get;set;} // Point has properties X and Y
        public int Radius {get;set;}
      }
 */
using static System.Math;

namespace Solution{
  public static class Kata{
    public static double DistanceBetweenCircles(Circle a, Circle b){
      //d=√((x2 – x1)² + (y2 – y1)²).
      double distance = Sqrt(Pow(b.Center.X - a.Center.X, 2) + Pow(b.Center.Y - a.Center.Y, 2));
      double circleTouch = distance - a.Radius - b.Radius;
      return circleTouch <= 0 ? 0 : circleTouch;
    } 
  }
}
  


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System.Drawing;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(32, Math.Round(Kata.DistanceBetweenCircles(new Circle(new Point(10,60),11),new Circle(new Point(40,20),7)),6));
      Assert.AreEqual(0, Math.Round(Kata.DistanceBetweenCircles(new Circle(new Point(10,60),40),new Circle(new Point(40,20),40)),6));
      Assert.AreEqual(0, Math.Round(Kata.DistanceBetweenCircles(new Circle(new Point(100,100),50),new Circle(new Point(102,110),10)),6));    
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      for (int i = 0; i < 100; i++)
      {
        Circle a = new Circle(new Point(rand.Next(-50,50),rand.Next(-50,50)), rand.Next(1,50));
        Circle b = new Circle(new Point(rand.Next(-50,50),rand.Next(-50,50)), rand.Next(1,50));
        Assert.AreEqual(Math.Round(Solve.GetResult(a,b),6),Math.Round(Kata.DistanceBetweenCircles(a,b),6));
      }
    }
  }
}
