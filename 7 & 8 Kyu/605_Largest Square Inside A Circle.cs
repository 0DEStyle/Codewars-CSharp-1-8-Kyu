/*Challenge link:https://www.codewars.com/kata/5887a6fe0cfe64850800161c/train/csharp
Question:
Determine the area of the largest square that can fit inside a circle with radius r.


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
//The largest square that can be drawn in a circle has a side whose length is 0.707 times the diameter of the circle.
//times 2 to get the length of the square
//or sqare root 2
//apply formula and round to the nearest integer.
using static System.Math;

namespace Kata {
  public class Circle{
    public double AreaLargestSquare(int r) => Round(Pow(r * Sqrt(2), 2));
  }
}

//solution 2
namespace Kata {
  using System;
  public class Circle
  {
    public double AreaLargestSquare(int r)
    {
      return 2 * r * r;
    }
  }
}
//****************Sample Test*****************
namespace Kata {
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class CircleTest
  {
    [Test]
    public void AreaLargestSquareTest()
    {
      Circle source = new Circle();
      
      Assert.AreEqual(50, source.AreaLargestSquare(5));
      Assert.AreEqual(98, source.AreaLargestSquare(7));
      Assert.AreEqual(450, source.AreaLargestSquare(15));
    }
    
    [Test]
    public void Random()
    {
      Random random = new Random();
      Circle source = new Circle();
      int r;
      
      for (int i = 0; i < 20; i++)
      {
        r = random.Next(0, 50);
        Assert.AreEqual(TestAreaLargestSquare(r), source.AreaLargestSquare(r));
      }
    }
    
    public double TestAreaLargestSquare(int r)
    {
      return Math.Pow(2.0 * r, 2) / 2.0;
    }
  }
}
