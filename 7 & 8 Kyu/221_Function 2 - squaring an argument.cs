/*Challenge link:https://www.codewars.com/kata/523b623152af8a30c6000027
Question:
Now you have to write a function that takes an argument and returns the square of it.
*/

//***************Solution********************
//create a method, then num * num
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static double Square(double num) => num * num;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void Test()
    {
      Assert.AreEqual(4, Kata.Square(2));
      Assert.AreEqual(100, Kata.Square(10));
    }
    
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        double test = rnd.NextDouble() * 1000;
        Assert.AreEqual(test * test, Kata.Square(test));
      }
    }
  }
}
