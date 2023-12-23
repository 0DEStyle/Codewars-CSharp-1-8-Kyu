/*Challenge link:https://www.codewars.com/kata/55c1d76ccc8f89fb2900009b/train/csharp
Question:
Hey Cube-Lovers!

Now we want to provide some more information about cubes. First, we implement two new properties: Volume and Surface.

Additional to this task we are going to refactor our code, so it will be bit more like professional C# code! You change the variable Side to a public property and remove the 'Getter' and 'Setter'.

The properties Volume and Surface should each have a public get-accessor and private set-accessor. Their correct mathematical values should be set in the cubes constructor and if Side's values is changed.

This MSDN site should provide some help:
https://msdn.microsoft.com/en-us/library/w86s7x04(v=VS.120).aspx
*/

//***************Solution********************
//apply formulas and return result.
using static System.Math;

public class Cube{
  private int side = 0;
  public double Volume => Side*Side*Side;
  public double Surface => Side*Side*6;
  
  //set private side to s
  public Cube(int s) => this.Side = s;
  public Cube(){}
  //method to get and set absolute value
  public int Side{get => Abs(side); set => side = value;}
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void TestGetAccessor()
  {
    Cube c = new Cube();
    Assert.AreEqual(0, c.Side, "The get-accessor should return 0");
  }
  
  [Test]
  public static void TestSetAccessor()
  {
    Cube c = new Cube();
    c.Side = 5;
    Assert.AreEqual(5, c.Side, "The set-accessor should have changed Side to 5");
  }
  
  [Test]
  public static void TestConstructor()
  {
    Cube c = new Cube(10);
    Assert.AreEqual(10, c.Side, "The get-accessor should return 10. Side should be set by a constructor");
  }
  
  [Test]
  public static void TestNegativeValues()
  {
    Cube c = new Cube(-3);
    Assert.AreEqual(3, c.Side, "Should switch -3 to 3 when constructor is used");
    c.Side = -8;
    Assert.AreEqual(8, c.Side, "Should switch -8 to 8 when set-accessor is used");
  }
  
  [Test]
  public static void TestVolume()
  {
    Cube c = new Cube(2);
    Assert.AreEqual(8, c.Volume, "Volume should be 8");
    c.Side = 3;
    Assert.AreEqual(27, c.Volume, "Volume should be 27");
  }
  
  [Test]
  public static void TestSurface()
  {
    Cube c = new Cube(2);
    Assert.AreEqual(24, c.Surface, "Volume should be 24");
    c.Side = 3;
    Assert.AreEqual(54, c.Surface, "Volume should be 54");
  }
  
  [Test]
  public static void RandomTests()
  {
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = r.Next(1000)-500;
      int num2 = Math.Abs(num);
      Cube c = new Cube(num);
      Assert.AreEqual(num2, c.Side);
      Assert.AreEqual(num2 * num2 * num2, c.Volume);
      Assert.AreEqual(num2 * num2 * 6, c.Surface);
    }
  }
}
