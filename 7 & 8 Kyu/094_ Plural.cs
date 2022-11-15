
/*Challenge link:https://www.codewars.com/kata/52ceafd1f235ce81aa00073a/train/csharp
Question:
We need a simple function that determines if a plural is needed or not. It should take a number, and return true if a plural should be used with that number or false if not. This would be useful when printing out a string such as 5 minutes, 14 apples, or 1 sun.

You only need to worry about english grammar rules for this kata, where anything that isn't singular (one of something), it is plural (not one of something).

All values will be positive integers or floats, or zero.
*/

//***************Solution********************
//i n is not 1
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static bool Plural(double n) => n != 1;
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
      Assert.AreEqual(true, Kata.Plural(0), "Plural for 0");
      Assert.AreEqual(true, Kata.Plural(0.5), "Plural for 0.5");
      Assert.AreEqual(false, Kata.Plural(1), "Plural for 1");
      Assert.AreEqual(true, Kata.Plural(100), "Plural for 100");
      Assert.AreEqual(true, Kata.Plural(double.PositiveInfinity), "Plural for Infinity");      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for (var i = 0; i < 100; i++) 
      {        
        var n = rand.Next(0,100);        
        Assert.AreEqual(n != 1, Kata.Plural(n), "Plural for " + n);
        
        var d = rand.NextDouble() * 1000;
        Assert.AreEqual(d != 1, Kata.Plural(d), "Plural for " + d);
      }
    }
  }
}
