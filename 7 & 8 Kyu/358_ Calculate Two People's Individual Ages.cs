/*Challenge link:https://www.codewars.com/kata/58e0bd6a79716b7fcf0013b1/train/csharp
Question:
Create a function that takes in the sum and age difference of two people, calculates their individual ages, and returns a pair of values (oldest age first) if those exist or null/None if:

sum < 0
difference < 0
Either of the calculated ages come out to be negative
*/

//***************Solution********************
//check if sum or difference are negative, or difference is greater than sum
//if true, return null
//else apply formula to find the mid point of age, then add the difference, 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata{
  public static double[] GetAges(int s, int d) =>
     s < 0 || d < 0 || s < d ? null : new double []{(s-d)/2.0+d, (s-d)/2.0};
}



//methood 2
public class Kata
{
  public static double[] GetAges(int sum, int diff)
  {
    return sum < 0 || diff < 0 || sum < diff
        ? null
        : new[] {(sum + diff) / 2d, (sum - diff) / 2d};
  }
}
//****************Sample Test*****************

namespace Solution {
  using NUnit.Framework;
  using System;

  // TODO: Replace examples and use TDD development by writing your own tests

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new double[] {14, 10}, Kata.GetAges(24, 4), "it returns {14, 10} when passed 24, 4");
      Assert.AreEqual(new double[] {38.5, 24.5}, Kata.GetAges(63, 14), "it returns {38.5, 24.5} when passed 63, 14");
      Assert.AreEqual(null, Kata.GetAges(63, -14), "it returns null when passed 63, -14");
    }
    
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual(new double[] {18, 12}, Kata.GetAges(30, 6), "it returns {18, 12} when passed 30, 6");
      Assert.AreEqual(new double[] {40, 30}, Kata.GetAges(70, 10), "it returns {40, 30} when passed 70, 10");
      Assert.AreEqual(new double[] {11, 7}, Kata.GetAges(18, 4), "it returns {11, 7} when passed 18, 4");
      Assert.AreEqual(new double[] {80, 0}, Kata.GetAges(80, 80), "it returns {80, 80} when passed 80, 0");
      Assert.AreEqual(null, Kata.GetAges(-22, 15), "it returns null when passed -22, 15");
    }
    
    private static object Solution(int sum, int difference)
    {
      if (sum < 0 || difference < 0) return null;
      double[] result = new double[2] {(sum - difference) / 2d + difference, (sum - difference) / 2d};
      return (Array.TrueForAll(result, x => x >= 0)) ? result : null;
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 200; ++i)
      {
        int sum = rnd.Next(0, 100);
        int difference = rnd.Next(0, 100);
        Assert.That(Kata.GetAges(sum, difference), Is.EqualTo(Solution(sum, difference)).Within(1e-6));
      }
    }
  }
}
