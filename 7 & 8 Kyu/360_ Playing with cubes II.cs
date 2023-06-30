/*Challenge link:https://www.codewars.com/kata/55c0ac142326fdf18d0000af/train/csharp
Question:
Hey Codewarrior!

You already implemented a Cube class, but now we need your help again! I'm talking about constructors. We don't have one. Let's code two: One taking an integer and one handling no given arguments!

Also we got a problem with negative values. Correct the code so negative values will be switched to positive ones!

The constructor taking no arguments should assign 0 to Cube's Side property.
*/

//***************Solution********************
using System;
public class Cube
{
  private int Side;
  public int Surface => 6 * Side * Side;
  public int Volume => Side * Side * Side;

  public Cube(){}
  public Cube(int sd= 0) => Side = Math.Abs(sd);
  
  public int GetSide()
  {
    return this.Side;
  }
  
  public void SetSide(int s)
  {
    this.Side = Math.Abs(s);
  }
}

//method 2
using static System.Math;
public class Cube {
  private int Side;
  public Cube() {}
  public Cube(int s) {
    SetSide(s);
  }
  public int GetSide() {
    return Side;
  }
  public void SetSide(int s) {
    Side = Abs(s);
  }
}
//method 3
public class Cube
{
  private int _side;
  public int GetSide() => _side;
  public void SetSide(int s) => _side = System.Math.Abs(s);
  public Cube(int side = 0) => _side = System.Math.Abs(side);
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Test
{
  [Test]
  public static void BasicTest()
  {
    Cube c = new Cube();
    Assert.AreEqual(0, c.GetSide(), "when not set before, Side should be 0");
    c.SetSide(5);
    Assert.AreEqual(5, c.GetSide(), "Should return 5");
  }
  
  [Test]
  public static void TestConstructor()
  {
    Cube c = new Cube(10);
    Assert.AreEqual(10, c.GetSide(), "Should be 10");
  }
  
  [Test]
  public static void TestNegativeValues()
  {
    Cube c = new Cube(-7);
    Assert.AreEqual(7, c.GetSide(), "Should be 7");
  }
  
  [Test]
  public static void TestNegativeValues2()
  {
    Cube c = new Cube(3);
    c.SetSide(-9);
    Assert.AreEqual(9, c.GetSide(), "Should be 9");
  }
}
