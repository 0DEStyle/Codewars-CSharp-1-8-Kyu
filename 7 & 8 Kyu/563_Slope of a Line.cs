/*Challenge link:https://www.codewars.com/kata/53222010db0eea35ad000001/train/csharp
Question:
Task
Your challenge is to write a function named getSlope/get_slope/GetSlope that calculates the slope of the line through two points.

Input
GetSlope will take in two Point objects. If the line through the two points is vertical, or the two points are the same, return null.

The Point object:

public class Point : System.Object
{
  public double X;
  public double Y;
  
  public Point(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }
  
  public override string ToString()
  {
    return $"({this.X}, {this.Y})";
  }
  
  public override bool Equals(object point)
  {
    // Typechecking
    if (point == null || point.GetType() != this.GetType())
    {
      return false;
    }
    
    return this.ToString() == point.ToString();
  }
}
*/

//***************Solution********************
//if p1 is the same as p2, return null
//else calculate the slope of the line through p1 and p2
using System;

public static class Kata{
  public static double? GetSlope(Point p1, Point p2){
    if(p1.X == p2.X) 
      return null;
    return (p1.Y - p2.Y) / (p1.X - p2.X);
  }
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  public static class Solution
  {
    public static double? GetSlope(Point p1, Point p2)
    {
      if (p1.X == p2.X) { return null; }
      
      return (p1.Y - p2.Y) / (p1.X - p2.X);
    }
  }

  [TestFixture, Description("Tests")]
  public class GetSlopeTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        // Fixed Tests
        yield return new TestCaseData(new Point(1, 1), new Point(2, 2)).Returns(1).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(-5,-5), new Point(9,9)).Returns(1).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(1,8), new Point(2,9)).Returns(1).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(8,3), new Point(-4,5)).Returns(-1/6.0).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(5,3), new Point(8,9)).Returns(2).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(1,3), new Point(0,3)).Returns(0).SetDescription("Should calculate the existing non-zero between 2 points");
        yield return new TestCaseData(new Point(11, 1), new Point(1, 11)).Returns(-1).SetDescription("Should calculate the existing non-zero between 2 points");
        
        yield return new TestCaseData(new Point(1, 1), new Point(1, 2)).Returns(null).SetDescription("Should return null if the line passing through the points is vertical");
        yield return new TestCaseData(new Point(-5, 9), new Point(-5, 12)).Returns(null).SetDescription("Should return null if the line passing through the points is vertical");
        
        yield return new TestCaseData(new Point(1, 1), new Point(1, 1)).Returns(null).SetDescription("Should return null if the same point is given twice");
        yield return new TestCaseData(new Point(-5, 9), new Point(-5, 9)).Returns(null).SetDescription("Should return null if the same point is given twice");
        
        // Random Tests
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          Point p1 = new Point(rnd.NextDouble() * 20, rnd.NextDouble() * 20),
                p2 = new Point(rnd.NextDouble() * 20, rnd.NextDouble() * 20);
                
          double? expected = Solution.GetSlope(p1, p2);
          
          yield return new TestCaseData(p1, p2).Returns(expected).SetDescription("Random Test");
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double? Test(Point p1, Point p2) =>
      Kata.GetSlope(p1, p2);
  }
}
