/*Challenge link:https://www.codewars.com/kata/5a023c426975981341000014/train/csharp
Question:
You are given two interior angles (in degrees) of a triangle.

Write a function to return the 3rd.

Note: only positive integers will be tested.

https://en.wikipedia.org/wiki/Triangle
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static int OtherAngle(int a, int b)=> 180 - a - b;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.OtherAngle(30, 60), Is.EqualTo(90));
      Assert.That(Kata.OtherAngle(60, 60), Is.EqualTo(60));
      Assert.That(Kata.OtherAngle(43, 78), Is.EqualTo(59));
      Assert.That(Kata.OtherAngle(10, 20), Is.EqualTo(150));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int a = rnd.Next(1, 175),
            b = rnd.Next(1, 180 - a),
            c = 180 - a - b;
          
        Assert.That(Kata.OtherAngle(a, b), Is.EqualTo(c));
      }
    }
  }
}
