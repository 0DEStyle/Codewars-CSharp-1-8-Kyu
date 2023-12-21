/*Challenge link:https://www.codewars.com/kata/587c2d08bb65b5e8040004fd/train/csharp
Question:
An NBA game runs 48 minutes (Four 12 minute quarters). Players do not typically play the full game, subbing in and out as necessary. Your job is to extrapolate a player's points per game if they played the full 48 minutes.

Write a function that takes two arguments, ppg (points per game) and mpg (minutes per game) and returns a straight extrapolation of ppg per 48 minutes rounded to the nearest tenth. Return 0 if 0.

Examples:

Kata.NbaExtrap(12, 20) => 28.8
Kata.NbaExtrap(10, 10) => 48
Kata.NbaExtrap(5, 17)  => 14.1
Kata.NbaExtrap(0, 0)   => 0
Notes:
All inputs will be either be an integer or float.
Follow your dreams!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//check if mpg is not 0
//if so calculate the percentage between ppg and mpg, apply to 48 to get the result
//round the result to the nearest 1 decimal place
//else return 0
using static System.Math;
public class Kata{
  public static double NbaExtrap(double ppg, double mpg) => mpg != 0 ? Round(ppg / mpg * 48.0, 1) : 0;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Sample_Tests
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(28.8, Kata.NbaExtrap(12, 20));
      Assert.AreEqual(48.0, Kata.NbaExtrap(10, 10));
      Assert.AreEqual(14.1, Kata.NbaExtrap(5, 17));
      Assert.AreEqual(0, Kata.NbaExtrap(0, 0));
      Assert.AreEqual(42.6, Kata.NbaExtrap(30.8, 34.7));
      Assert.AreEqual(32.5, Kata.NbaExtrap(22.9, 33.8));
    }
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static double solution(double ppg, double mpg) =>
      mpg == 0 ? 0 : Math.Round(ppg * (48.0 / mpg), 1);
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        double ppg = rnd.NextDouble() * 35, mpg = rnd.NextDouble() * 48;
        
        double expected = solution(ppg, mpg);
        double actual = Kata.NbaExtrap(ppg, mpg);
      }
    }
  }
}
