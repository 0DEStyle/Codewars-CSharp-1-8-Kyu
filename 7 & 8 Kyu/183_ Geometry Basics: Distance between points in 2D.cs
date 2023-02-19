/*Challenge link:https://www.codewars.com/kata/58dced7b702b805b200000be/train/csharp
Question:
This series of katas will introduce you to basics of doing geometry with computers.

Point objects have fields X and Y.

Write a function calculating distance between Point a and Point b.

Tests compare expected result and actual answer with tolerance of 1e-6.
*/

//***************Solution********************
//Apply Distance between points formula, and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static double DistanceBetweenPoints(Point a, Point b) => Math.Sqrt(Math.Pow(a.X - b.X,2) + Math.Pow(a.Y - b.Y,2));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class SolutionTest
{
  private static Random rnd = new Random();

  [Test, Description("Fixed Tests")]
  public void FixedTest()
  {
    DoTest(new Point(    3,    3), new Point(  3,    3), 0        );
    DoTest(new Point(    1,    6), new Point(  4,    2), 5        );
    DoTest(new Point(-10.2, 12.5), new Point(0.3, 14.7), 10.728001);
  }


  [Test, Description("Random Tests")]
  public void RandomTest()
  {
    for (int i = 0; i < 100; ++i)
    {
      Point a = new Point((rnd.NextDouble() * 100 - 50), (rnd.NextDouble() * 100 - 50));
      Point b = new Point((rnd.NextDouble() * 100 - 50), (rnd.NextDouble() * 100 - 50));
      double expected = Math.Sqrt(Math.Pow(a.X - b.X, 2) + Math.Pow(a.Y - b.Y, 2));
      DoTest(a, b, expected);
    }
  }

  private void DoTest(Point a, Point b, double expected) {
    double actual = Kata.DistanceBetweenPoints(a, b);
    Assert.AreEqual(expected, actual, 1e-6, "Incorrect answer for:\n  a=Point({0}, {1})\n  b=Point({2}, {3})\n", a.X, a.Y, b.X, b.Y);
  }    
}
