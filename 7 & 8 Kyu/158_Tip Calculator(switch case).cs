/*Challenge link:https://www.codewars.com/kata/56598d8076ee7a0759000087/train/csharp
Question:
Complete the function, which calculates how much you need to tip based on the total amount of the bill and the service.

You need to consider the following ratings:

Terrible: tip 0%
Poor: tip 5%
Good: tip 10%
Great: tip 15%
Excellent: tip 20%
The rating is case insensitive (so "great" = "GREAT"). If an unrecognised rating is received, then you need to return:

"Rating not recognised" in Javascript, Python and Ruby...
...or null in Java
...or -1 in C#
Because you''re a nice person, you always round up the tip, regardless of the service.
*/

//***************Solution********************
//using switch case to tip
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static int CalculateTip(double amount, string rating) => rating.ToLower() switch{
      "terrible" => 0,
      "poor" => (int)Math.Ceiling(amount* 0.05),
      "good" => (int)Math.Ceiling(amount* 0.1),
      "great" => (int)Math.Ceiling(amount*0.15),
      "excellent" => (int)Math.Ceiling(amount*0.2),
      _ => -1
  };
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  [TestFixture]
  public class FixedTests
  {
    private static Random rnd = new Random();
  
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(4, Kata.CalculateTip(20, "Excellent")),
        () => Assert.AreEqual(3, Kata.CalculateTip(26.95, "good")),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Returns -1 when invalid rating")]
    public void InvalidTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(-1, Kata.CalculateTip(20, "hi")),
        () => Assert.AreEqual(-1, Kata.CalculateTip(20, "dfsjkfh")),
        () => Assert.AreEqual(-1, Kata.CalculateTip(20, "great!")),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Returns correct tip amount for whole amounts")]
    public void WholeAmountTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(0, Kata.CalculateTip(10, "Terrible")),
        () => Assert.AreEqual(2, Kata.CalculateTip(30, "poor")),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Returns correct tip amount for decimal amounts")]
    public void DecimalAmountTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(17, Kata.CalculateTip(107.65, "GReat")),
        () => Assert.AreEqual(35, Kata.CalculateTip(684.99, "Poor")),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
  }
  
  [TestFixture]
  public class RandomTests
  {
    private static Random rnd = new Random();
    
    public static int Solution(double amount, string rating)
    {
      Dictionary<string, double> ratings = new Dictionary<string, double>
      {
        {"excellent", 0.20},
        {"great", 0.15},
        {"good", 0.10},
        {"poor", 0.05},
        {"terrible", 0.00},
      };
      
      rating = rating.ToLower();
      return ratings.ContainsKey(rating) ? (int)Math.Ceiling(amount * ratings[rating]) : -1;
    }
  
    [Test, Description("Returns correct tip amount for decimal amounts")]
    public void RandomTest([Random(0, 50000, 200)] double amount)
    {
      string rating = new string[] {"ExCellEnt", "GrEAT", "GOOd", "poOR", "TErriblE", "junk", "quite a little off his rocker that waiter is"}[rnd.Next(0, 7)];
      int expected = Solution(amount, rating);
      int actual = Kata.CalculateTip(amount, rating);
      Console.WriteLine($"Testing for {amount} and \"{rating}\":\nExpected: {expected}\nActual:   {actual}\n");
      Assert.AreEqual(expected, actual);
    }
  }
}
