/*Challenge link:https://www.codewars.com/kata/586c1cf4b98de0399300001d/train/csharp
Question:
Create a combat function that takes the player''s current health and the amount of damage recieved, and returns the player's new health. Health can't be less than 0.
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Game{
  public static float Combat(float health, float damage)=>  health - damage > 0 ? health - damage : 0;
}

//or
using System;

public static class Game
{
  public static float Combat(float health, float damage)
  {
    return Math.Max(0, health - damage);
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(100, 5).Returns(95);
        yield return new TestCaseData(92, 8).Returns(84);
        yield return new TestCaseData(20, 30).Returns(0);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public float Test(float health, float damage) =>
      Game.Combat(health, damage);
  }
  
  [TestFixture]
  public class FixedTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(50, 49).Returns(1);
        yield return new TestCaseData(90, 87).Returns(3);
        yield return new TestCaseData(33, 33).Returns(0);
        yield return new TestCaseData(100, 81).Returns(19);
        yield return new TestCaseData(23, 27).Returns(0);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public float Test(float health, float damage) =>
      Game.Combat(health, damage);
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          float health = (float)rnd.NextDouble() * 100,
                damage = (float)rnd.NextDouble() * 100;
                
          float expected = Math.Max(0, health - damage);
          
          yield return new TestCaseData(health, damage).Returns(expected);
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public float Test(float health, float damage) =>
      Game.Combat(health, damage);
  }
}
