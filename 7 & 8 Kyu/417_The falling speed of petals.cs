/*Challenge link:https://www.codewars.com/kata/5a0be7ea8ba914fc9c00006b/train/csharp
Question:
When it's spring Japanese cherries blossom, it's called "sakura" and it's admired a lot. The petals start to fall in late April.

Suppose that the falling speed of a petal is 5 centimeters per second (5 cm/s), and it takes 80 seconds for the petal to reach the ground from a certain branch.

Write a function that receives the speed (in cm/s) of a petal as input, and returns the time it takes for that petal to reach the ground from the same branch.

Notes:

The movement of the petal is quite complicated, so in this case we can see the velocity as a constant during its falling.
Pay attention to the data types.
If the initial velocity is non-positive, the return value should be 0
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//height: 5 * 80  = 400.0 cm (.0 for decimal place)
//check if v is greater than 0, if so 400.0 / v
//else return 0

public static class Kata{
  public static double SakuraFall(double v) => v > 0 ? 400.0 / v : 0;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class SampleTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(5).Returns(80);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double Test(double v) =>
      Kata.SakuraFall(v);
  }
  
  [TestFixture]
  public class FixedTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(10).Returns(40);
        yield return new TestCaseData(200).Returns(2);
        yield return new TestCaseData(-1).Returns(0);
        yield return new TestCaseData(0).Returns(0);
        yield return new TestCaseData(12.3).Returns(400 / 12.3);
        yield return new TestCaseData(3).Returns(400 / 3.0);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double Test(double v) =>
      Kata.SakuraFall(v);
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        Random rnd = new Random();
        
        for (int i = 0; i < 100; ++i)
        {
          double v = rnd.NextDouble() * 1000 - 500;
          yield return new TestCaseData(v).Returns(v <= 0 ? 0 : 400 / v);
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public double Test(double v) =>
      Kata.SakuraFall(v);
  }
}
