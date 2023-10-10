/*Challenge link:https://www.codewars.com/kata/5a58ca28e626c55ae000018a/train/csharp
Question:
Write the following function:

public static double AreaOfPolygonInsideCircle(double circleRadius, int numberOfSides)
It should calculate the area of a regular polygon of numberOfSides, number-of-sides, or number_of_sides sides inside a circle of radius circleRadius, circle-radius, or circle_radius which passes through all the vertices of the polygon (such circle is called circumscribed circle or circumcircle).

The answer should be a number rounded to 3 decimal places.

Input :: Output Examples

AreaOfPolygonInsideCircle(3, 3) // returns 11.691

AreaOfPolygonInsideCircle(5.8, 7) // returns 92.053

AreaOfPolygonInsideCircle(4, 5) // returns 38.042
Note: if you need to use Pi in your code, use the native value of your language unless stated otherwise.
*/

//***************Solution********************

//formula 0.5 * sides * r^2 * Sin(2 * Pi / n), round to 3 decimal place
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution {
  //simplify by using static System.Math
  using static System.Math;
  public class Calculator {
    public static double AreaOfPolygonInsideCircle(double r, int n) => Round(0.5 * n * r * r * Sin(2 * PI / n), 3);
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest {
    private static double CalculateAOPIC(double r, int n) {
      return Math.Round(n*r*r*Math.Sin(2*Math.PI/n)*500)/1000.0;
    }
    
    [Test]
    public void BasicTests() {
      Assert.AreEqual(11.691, Calculator.AreaOfPolygonInsideCircle(3,3));
      Assert.AreEqual(8, Calculator.AreaOfPolygonInsideCircle(2,4));
      Assert.AreEqual(14.86, Calculator.AreaOfPolygonInsideCircle(2.5,5));
    }
    
    [Test]
    public void RandomTest() {
      Random rnd = new Random();
      for(int i=0; i<100;i++) {
        double randR = rnd.NextDouble()*20+1;
        int randN = rnd.Next(4,24);
        double expected = SolutionTest.CalculateAOPIC(randR,randN);
        double actual = Calculator.AreaOfPolygonInsideCircle(randR,randN);
        if (actual != expected) Console.WriteLine ("Random test #" + (i + 1) + ": radius = " + randR + " sides = " +randN );
        Assert.AreEqual(expected, actual, 1e-3);
      }
    }
  }
}
