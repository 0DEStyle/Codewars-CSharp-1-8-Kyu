/*Challenge link:https://www.codewars.com/kata/5899aa695401a83a5c0000c4/train/csharp
Question:
Circle area inside square
Turn an area of a square in to an area of a circle that fits perfectly inside the square.

inscribed circle

You get the blue+red area and need to calculate the red area.

Your function gets a number which represents the area of the square and should return the area of the circle. The tests are rounded by 8 decimals to make sure multiple types of solutions work.

You don't have to worry about error handling or negative number input: area >= 0.

This kata might be simpler than you expect, but good luck!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
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
//apply formula, round result to 8 dps.
using static System.Math;
namespace Kata {
  public class Convert{
    public static double SquareAreaToCircle(double area) => Round(Pow(Sqrt(area) / 2, 2) * PI, 8);
  }
}

//solution 2
namespace Kata {
  using System;
  public class Convert
  {
    public static double SquareAreaToCircle(double size)
    {
      return Math.PI * size/4;
    }
  }
}

//****************Sample Test*****************
namespace Kata {
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class Tests
  {
    [Test]
    public void Test9()
    {
      var result = Convert.SquareAreaToCircle(9);
      Assert.AreEqual(result.GetType(), typeof(double),"should a be double");
      Assert.AreEqual(Math.Round(result,8), Math.Round(7.0685834705770345d,8));
    }
    
    [Test]
    public void Test20()
    {
      var result = Convert.SquareAreaToCircle(20);
      Assert.AreEqual(Math.Round(result,8), Math.Round(15.707963267948969d,8));
    }
    
    [Test]
    public void RandomTest()
    {
      var sqr = new Func<double, double>((size) => Math.Pow(Math.Sqrt(size) / 2,2) * Math.PI);
      var r = new Random();
      for(var i = 0; i < 10; i++){
        var input = r.NextDouble();
        Assert.AreEqual(Math.Round(Convert.SquareAreaToCircle(input),8), Math.Round(sqr(input),8));
      }
    }
  }
}
