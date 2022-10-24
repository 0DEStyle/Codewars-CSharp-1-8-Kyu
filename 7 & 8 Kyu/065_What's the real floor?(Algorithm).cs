/*Challenge link:https://www.codewars.com/kata/574b3b1599d8f897470018f6/train/csharp
Question:
Americans are odd people: in their buildings, the first floor is actually the ground floor and there is no 13th floor (due to superstition).

Write a function that given a floor in the american system returns the floor in the european system.

With the 1st floor being replaced by the ground floor and the 13th floor being removed, the numbers move down to take their place. In case of above 13, they move down by two because there are two omitted numbers below them.

Basements (negatives) stay the same as the universal level.

More information here

Examples
1  =>  0 
0  =>  0
5  =>  4
15  =>  13
-3  =>  -3
*/

//***************Solution********************
//Apply algorithm 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata
{
  public static int GetRealFloor(int n) => n == 0 || n == 1 ? 0 : n>2 && n < 13 ? n-1 : n>=13 ? n-2 : n;
}

/*
if(n == 0 || n == 1)
      return 0;
    if(n>2 && n < 13)
      return n-1;
    if(n>=13)
      return n-2;
    return n;
    */

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public static class Solution
  {
    public static int GetRealFloor(int n)
    {
      if (n <= 0) { return n; }
      if (n < 13) { return n - 1; }
      return n - 2;
    }
  }

  [TestFixture]
  public class ArbitraryValuesTest
  {
    [Test, Description("should return a correct value for floors lower than 13")]
    public void LessThan13Test()
    {
      Assert.AreEqual(0, Kata.GetRealFloor(0));
      Assert.AreEqual(0, Kata.GetRealFloor(1));
      Assert.AreEqual(4, Kata.GetRealFloor(5));
      Assert.AreEqual(9, Kata.GetRealFloor(10));
      Assert.AreEqual(11, Kata.GetRealFloor(12));
    }
    
    [Test, Description("should return a correct value for floors greater than 13")]
    public void GreaterThan13Test()
    {
      Assert.AreEqual(12, Kata.GetRealFloor(14));
      Assert.AreEqual(13, Kata.GetRealFloor(15));
      Assert.AreEqual(35, Kata.GetRealFloor(37));
      Assert.AreEqual(198, Kata.GetRealFloor(200));
    }
    
    [Test, Description("should return a correct value for basement floors")]
    public void BasementTest()
    {
      Assert.AreEqual(-2, Kata.GetRealFloor(-2));
      Assert.AreEqual(-5, Kata.GetRealFloor(-5));
    }
  }
  
  [TestFixture]
  public class RandomTest
  {
    [Test, Description("Random tests")]
    public void RandTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int n = rnd.Next(-100, 100);
        if (n == 13) { n += rnd.Next(10, 70); }
        
        Assert.AreEqual(Solution.GetRealFloor(n), Kata.GetRealFloor(n));
      }
    }
  }
}
