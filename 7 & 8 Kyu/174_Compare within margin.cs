/*Challenge link:https://www.codewars.com/kata/56453a12fcee9a6c4700009c/train/csharp
Question:
Create a function close_compare that accepts 3 parameters: a, b, and an optional margin. The function should return whether a is lower than, close to, or higher than b.

a is considered "close to" b if margin is greater than or equal to the distance between a and b.

Please note the following:

When a is close to b, return 0.
Otherwise...

When a is less than b, return -1.

When a is greater than b, return 1.

If margin is not given, treat it as zero.

Assume: margin >= 0

Tip: Some languages have a way to make parameters optional.

Example 1
If a = 3, b = 5, and margin = 3, then close_compare(a, b, margin) should return 0.

This is because a and b are no more than 3 numbers apart.

Example 2
If a = 3, b = 5, and margin = 0, then close_compare(a, b, margin) should return -1.

This is because the distance between a and b is greater than 0, and a is less than b.


*/

//***************Solution********************
//apply conditions, and return 0, 1, - 1 accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static int CloseCompare(double a, double b, double margin = 0) => Math.Abs(b-a) <= margin ? 0 : a < b ? -1 : 1;
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
    public void NoMarginTests()
    {
      Assert.AreEqual(-1, Kata.CloseCompare(4, 5));
      Assert.AreEqual(0, Kata.CloseCompare(5, 5));
      Assert.AreEqual(1, Kata.CloseCompare(6, 5));      

      Assert.AreEqual(-1, Kata.CloseCompare(-4, -3), "a & b may be < 0");
      Assert.AreEqual(0, Kata.CloseCompare(-5, -5), "a & b may be < 0");
      Assert.AreEqual(1, Kata.CloseCompare(-5, -6), "a & b may be < 0");
    }
    
    [Test]
    public void MarginOf3Tests()
    {
      Assert.AreEqual(0, Kata.CloseCompare(2, 5, 3));
      Assert.AreEqual(0, Kata.CloseCompare(5, 2, 3));
      Assert.AreEqual(0, Kata.CloseCompare(8, 5, 3));
      Assert.AreEqual(1, Kata.CloseCompare(8.1, 5, 3));
      Assert.AreEqual(-1, Kata.CloseCompare(1.99, 5, 3));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for(int r=0;r<100;r++)
      {
        var a = rand.Next(-10000, 20001);
        var b = rand.Next(-10000, 20001);
        var m = rand.Next(0, 10000);
        var expected = (Math.Abs(a-b) <= m) ? 0 : (a < b) ? -1 : 1;
        
        Assert.AreEqual(expected, Kata.CloseCompare(a, b, m));
      }
    }
  }
}
