/*Challenge link:https://www.codewars.com/kata/58d248c7012397a81800005c/train/csharp
Question:
To find the volume (centimeters cubed) of a cuboid you use the formula:

volume = Length * Width * Height

But someone forgot to use proper record keeping, so we only have the volume, and the length of a single side!

It's up to you to find out whether the cuboid has equal sides (= is a cube).

Return true if the cuboid could have equal sides, return false otherwise.

Return false for invalid numbers too (e.g volume or side is less than or equal to 0).

Note: side will be an integer


*/

//***************Solution********************
//if side is not negative, then check if side to the power of 3 is equal to volume, return true or false accordingly.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace CubeCheck {
  using System;
  public class CubeChecker{
    public bool IsCube(double volume, double side) => side > 0 ? Math.Pow(side,3) == volume : false;
  }
}

//better solution
namespace CubeCheck {
  using System;
  public class CubeChecker{
    public bool IsCube(double volume, double side) => Math.Pow(side,3)==volume && side>0;
  }
}
(Math.Pow(side,3)==volume && side>0);
//****************Sample Test*****************
namespace CubeCheck
{
  using NUnit.Framework;
  using System;
  [TestFixture]
  public class CubeTest
  {
    private CubeChecker _cube = new CubeChecker();
    [Test]
    public void ShouldReturnTrue()
    {
      Assert.AreEqual(true, _cube.IsCube(1, 1));      
      Assert.AreEqual(true, _cube.IsCube(8, 2));
    }
    [Test]
    public void ShouldReturnFalse()
    {
      Assert.AreEqual(false, _cube.IsCube(2, 1));
      Assert.AreEqual(false, _cube.IsCube(6, 3));
      Assert.AreEqual(false, _cube.IsCube(-8, -2));
      Assert.AreEqual(false, _cube.IsCube(0, 0));
      Assert.AreEqual(false, _cube.IsCube(200, 4));
      Assert.AreEqual(false, _cube.IsCube(-1, -2));
      Assert.AreEqual(false, _cube.IsCube(4, -2));
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      for(var i = 0; i < 50; i++)
      {
        var rand1 = rand.Next(-50, 100);
        var rand2= rand.Next(-20, 80);
        RandTests(rand1, rand2);
      }      
    }
    
    private void RandTests(double volume, double side)
    {
      var res = ((volume/(side * side)) == side && volume > 0 && side > 0);
      Assert.AreEqual(res, _cube.IsCube(volume, side));
      Console.Write($"values {volume} and {side} yielded {res} \n");
    }
  }
}
