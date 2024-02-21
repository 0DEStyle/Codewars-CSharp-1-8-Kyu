/*Challenge link:https://www.codewars.com/kata/554dc2b88fbafd2e95000125/train/csharp
Question:For a given 2D vector described by cartesian coordinates of its initial point and terminal point in the following format:

// Argument will be passed as a Vector2

public struct Vector2
{
  public Point2 Head;
  public Point2 Tail;
  
  public Vector2(Point2 tail, Point2 head)
  {
    this.Tail = tail;
    this.Head = head;
  }
  
  public Point2 this[int i]
  {
    get
    {
      return new Point2[] {this.Tail, this.Head}[i];
    }
  }
}

public struct Point2
{
  public double X;
  public double Y;
  
  public Point2(double x, double y)
  {
    this.X = x;
    this.Y = y;
  }
  
  public double this[int i]
  {
    get
    {
      return new double[] {this.X, this.Y}[i];
    }
  }
}
Your function must return the vector's length represented as a floating point number.
Error must be within 1e-7.

Coordinates can be integers or floating point numbers.
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
*/

using static System.Math;

public static class Kata{
  public static double VectorLength(Vector2 vec){
    //get diff between poitns, x and y
    var x = vec.Head.X - vec.Tail.X; var y = vec.Head.Y - vec.Tail.Y; 
    return Sqrt(x * x + y * y);
  }
}

//solution 2
using System;

public static class Kata
{
  public static double VectorLength(Vector2 vec) =>
    Math.Sqrt(Math.Pow(vec[0][0] - vec[1][0], 2) + Math.Pow(vec[0][1] - vec[1][1], 2));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private static double epsilon = 1e-7;
  
    [Test]
    public void ExampleTest()
    {
      Assert.That(Kata.VectorLength(new Vector2(new Point2(0, 1), new Point2(0, 0))), Is.EqualTo(1).Within(epsilon));
      Assert.That(Kata.VectorLength(new Vector2(new Point2(0, 3), new Point2(4, 0))), Is.EqualTo(5).Within(epsilon));
      Assert.That(Kata.VectorLength(new Vector2(new Point2(1, -1), new Point2(1, -1))), Is.EqualTo(0).Within(epsilon));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        double a = rnd.NextDouble() * 10,
               b = rnd.NextDouble() * 10,
               c = rnd.NextDouble() * 10,
               d = rnd.NextDouble() * 10;
               
        Vector2 vec = new Vector2(new Point2(a, b), new Point2(c, d));
        double expected = Math.Sqrt(Math.Pow(vec[0][0] - vec[1][0], 2) + Math.Pow(vec[0][1] - vec[1][1], 2));
        
        Assert.That(Kata.VectorLength(vec), Is.EqualTo(expected).Within(epsilon));
      }
    }
  }
}
