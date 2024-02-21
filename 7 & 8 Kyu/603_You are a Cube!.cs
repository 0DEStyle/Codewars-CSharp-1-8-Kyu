/*Challenge link:https://www.codewars.com/kata/57da5365a82a1998440000a9/train/csharp
Question:
In geometry, a cube is a three-dimensional solid object bounded by six square faces, facets or sides, with three meeting at each vertex.The cube is the only regular hexahedron and is one of the five Platonic solids. It has 12 edges, 6 faces and 8 vertices.The cube is also a square parallelepiped, an equilateral cuboid and a right rhombohedron. It is a regular square prism in three orientations, and a trigonal trapezohedron in four orientations.

You are given a task of finding a if the provided value is a perfect cube!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨        I'm a cube!
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨     / 
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/

//find cube root of n, round to the nearest whole number, 
//then perform the power of 3 to see if it is the same as n
using static System.Math;

public class Kata{
  public static bool YouAreACube(int n) => Pow(Round(Cbrt(n)),3) == n;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(true, Kata.YouAreACube(27));
      Assert.AreEqual(true, Kata.YouAreACube(1));
      Assert.AreEqual(false, Kata.YouAreACube(2));
      Assert.AreEqual(false, Kata.YouAreACube(99));
      Assert.AreEqual(true, Kata.YouAreACube(64));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int,bool> sol = delegate (int value)
      {
        var s3 = Math.Round(Math.Pow(value, 1.0/3.0));
        return s3 * s3 * s3 == value;  
      };
    
      for(int i = 0; i < 100; ++i)
      { 
        int v = 0;
        if(rand.Next(0,2) == 1)
        {
          v = rand.Next(1, (int)Math.Pow(10, rand.Next(1,6)) + 1);
        }
        else
        {
          v = rand.Next(1, (int)Math.Pow(10, rand.Next(1,4)) + 1);
          v = v * v * v;
        }
        
        Assert.AreEqual(sol(v), Kata.YouAreACube(v), "It should work for random inputs too");     
      }
    }
  }
}
