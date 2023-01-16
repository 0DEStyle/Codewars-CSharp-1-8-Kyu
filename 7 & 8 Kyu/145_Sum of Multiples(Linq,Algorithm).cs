/*Challenge link:https://www.codewars.com/kata/57241e0f440cd279b5000829/train/csharp
Question:
Your Job
Find the sum of all multiples of n below m

Keep in Mind
n and m are natural numbers (positive integers)
m is excluded from the multiples
Examples
Kata.SumMul(2, 9)   => 2 + 4 + 6 + 8 = 20
Kata.SumMul(3, 13)  => 3 + 6 + 9 + 12 = 30
Kata.SumMul(4, 123) => 4 + 8 + 12 + ... = 1860
Kata.SumMul(4, 1)   // throws ArgumentException
Kata.SumMul(0, 20)  // throws ArgumentException

*/

//***************Solution********************
//check condition, then apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System;

public class Kata{
  public static int SumMul(int n, int m)
    => m - n <= 0 || n <= 0 ? throw new ArgumentException() : Enumerable.Range(1, (m-1) / n).Sum(x => x * n);
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
  
    [Test, Description("Should produce expected results for valid inputs")]
    public void SampleTest()
    {
      Assert.AreEqual(20, Kata.SumMul(2, 9), "n = 2, m = 9");
      Assert.AreEqual(30, Kata.SumMul(5, 20), "n = 5, m = 20");
      Assert.AreEqual(1860, Kata.SumMul(4, 123), "n = 4, m = 123");
      Assert.AreEqual(86469, Kata.SumMul(123, 4567), "n = 123, m = 4567");
    }
    
    [Test, Description("Should throw for invalid inputs")]
    public void ErrorTest()
    {
      Assert.Throws<ArgumentException>(() => Kata.SumMul(4, 1), "n = 4, m = 1");
      Assert.Throws<ArgumentException>(() => Kata.SumMul(0, 20), "n = 0, m = 20");
      Assert.Throws<ArgumentException>(() => Kata.SumMul(3, -7), "n = 3, m = -7");
    }
    
    [Test, Description("Should produce expected results for random arbitrary inputs")]
    public void RandomTest()
    {
      const int Tests = 1000;

      for (int i = 0; i < Tests; ++i)
      {
        int n = rnd.Next(-100, 1000);
        int m = rnd.Next(-100, 10000);
        
        if (m <= n || n <= 0)
        {
          Assert.Throws<ArgumentException>(() => Kata.SumMul(n, m), $"n = {n}, m = {m}");
        }
        else
        {
          int expected = Enumerable.Range(1, (m - 1) / n).Sum(v => v * n);
          int actual = Kata.SumMul(n, m);
          
          Assert.AreEqual(expected, actual, $"n = {n}, m = {m}");
        }
      }
    }
  }
}
