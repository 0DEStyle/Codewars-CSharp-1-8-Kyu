/*Challenge link:https://www.codewars.com/kata/593c9175933500f33400003e/train/csharp
Question:
Implement a function, multiples(m, n), which returns an array of the first m multiples of the real number n. Assume that m is a positive integer.

Ex.

multiples(3, 5.0)
should return

[5.0, 10.0, 15.0]
*/

//***************Solution********************
//create a loop, start from 1 up to n, then multiply the current iteration number by n.
//store in an array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static double[] Multiples(int m, double n)=>Enumerable.Range(1, m).Select(x=>x*n).ToArray();
    
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new double[] {5, 10, 15}, Kata.Multiples(3, 5));
      Assert.AreEqual(new double[] {3.14}, Kata.Multiples(1, 3.14));
      Assert.AreEqual(new double[] {-1, -2, -3, -4, -5}, Kata.Multiples(5, -1));
    }
    
    private double[] Solution(double m, double n)
    {
      List<double> result = new List<double>();
    
      for (int i = 1; i <= m; ++i) {
        result.Add(n * i);
      }
      return result.ToArray();
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 100; ++i)
      {
        int m = rnd.Next(0, 100);
        int n = rnd.Next(0, 50);
        Assert.AreEqual(Solution(m, n), Kata.Multiples(m, n));
      }
    }
  }
}
