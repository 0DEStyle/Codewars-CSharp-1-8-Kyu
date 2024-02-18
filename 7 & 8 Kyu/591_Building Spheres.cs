/*Challenge link:https://www.codewars.com/kata/55c1d030da313ed05100005d/train/csharp
Question:
Now that we have a Block let's move on to something slightly more complex: a Sphere.

Arguments for the constructor
radius -> integer
mass -> integer
Methods to be defined
GetRadius()       =>  radius of the Sphere
GetMass()         =>  mass of the Sphere
GetVolume()       =>  volume of the Sphere (a double rounded to 5 place after the decimal)
GetSurfaceArea()  =>  surface area of the Sphere (a double rounded to 5 place after the decimal)
GetDensity()      =>  density of the Sphere (a double rounded to 5 place after the decimal)
Example
Sphere ball = new Sphere(2,50)
ball.GetRadius() ->       2
ball.GetMass() ->         50
ball.GetVolume() ->       33.51032
ball.GetSurfaceArea() ->  50.26548
ball.GetDensity() ->      1.49208
Any feedback would be much appreciated
*/

//***************Solution********************
/*
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛⬛🟨🟨🟨🟨🟨⬛🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨⬛🟨🟨🟨🟨🟨⬛⬛⬜
⬜⬜⬜⬜⬛⬛⬛⬛🟨🟨⬛⬛🟨🟨⬛⬛🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨⬛⬛🟨🟨⬛⬛🟨🟨⬛⬛⬛⬛
⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬛⬛⬛⬛⬛⬛
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟥🟥🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨🟨🟨🟥🟥🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬛🟨🟥🟥🟥🟥🟨🟨🟨⬛🟥🟥🟥⬛🟨🟨🟨🟥🟥🟥🟥🟨⬛⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟨⬛⬛⬛⬜⬛🟨🟥🟥🟥🟥🟨🟨🟨⬛🟥🟥🟥⬛🟨🟨🟨🟥🟥🟥🟥🟨⬛⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟥🟥🟨🟨🟨🟨⬛🟥🟥🟥⬛⬛⬛🟨🟨🟥🟥🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛🟨🟨⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨⬛🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨⬛🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛⬛🟨🟨⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬛🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨⬛🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛🟨🟨🟨⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
*/
//volumn 4/3πr^3
//SurfaceArea 4πr^2
//density mass / volume
using static System.Math;

public class Sphere{
	private readonly int Radius;
  private readonly int Mass;
  
  public Sphere(int radius, int mass){
    Radius = radius;
    Mass = mass;
  }  
  
  public int GetRadius()          =>  Radius;
  public int GetMass()            =>  Mass;
  public double GetVolume()       =>  Round(PI * Pow(GetRadius(), 3) * 4 / 3, 5); //round to 5dps
  public double GetSurfaceArea()  =>  Round(PI * Pow(GetRadius(), 2) * 4, 5); //round to 5dps
  public double GetDensity()      =>  Round(GetMass() / GetVolume(), 5); // round to 5dps
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void BasicTests()
  {
    for (int i = 1;i < 50; i++)
    {
      int m = (int)Math.Pow((double)i,2.0);
      Sphere ball = new Sphere(i,m);
      Assert.AreEqual(i, ball.GetRadius(), "Check radius");
      Assert.AreEqual(m, ball.GetMass(), "Check mass");
      double v = (4.0 / 3) * Math.PI * Math.Pow ((double)i,3.0);
      Assert.AreEqual(Math.Round(v,5),ball.GetVolume(), "Check volume");
      Assert.AreEqual(Math.Round (4 * Math.PI * Math.Pow(i, 2.0), 5),ball.GetSurfaceArea(), "Check area");
      Assert.AreEqual(Math.Round(m/v,5),ball.GetDensity(), "Check density");
    }
  }
  [Test]
  public static void RandomTests()
  {
  	Random rand = new Random();
  	for(int i = 0;i<10;i++)
    {
    	int r = rand.Next(1,100);
      int m = rand.Next(1,100);
      Sphere ball = new Sphere(r,m);
      Assert.AreEqual(r, ball.GetRadius(), "Check radius");
      Assert.AreEqual(m, ball.GetMass(), "Check mass");
      double v = (4.0 / 3) * Math.PI * Math.Pow ((double)r,3.0);
      Assert.AreEqual(Math.Round(v,5),ball.GetVolume(), "Check volume");
      Assert.AreEqual(Math.Round (4 * Math.PI * Math.Pow(r, 2.0), 5),ball.GetSurfaceArea(), "Check area");
      Assert.AreEqual(Math.Round(m/v,5),ball.GetDensity(), "Check density");
    }
  }
}
