/*Challenge link:https://www.codewars.com/kata/56ff6a70e1a63ccdfa0001b1/train/csharp
Question:
SpeedCode #2 - Array Madness
Objective
Given two integer arrays a, b, both of length >= 1, create a program that returns true if the sum of the squares of each element in a is strictly greater than the sum of the cubes of each element in b.

E.g.

Kata.ArrayMadness(new int[] {4, 5, 6}, new int[] {1, 2, 3}) => true // because 4 ** 2 + 5 ** 2 + 6 ** 2 > 1 ** 3 + 2 ** 3 + 3 ** 3
Get your timer out. Are you ready? Ready, get set, GO!!!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//compare the result and return bool value.
using System.Linq;
public class Kata{
  public static bool ArrayMadness(int[] a, int[] b) => a.Sum(x => x * x) >= b.Sum(x => x * x * x);
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
    
    private static bool solution(int[] a, int[] b) => 
      a.Aggregate(0, (p, c) => p + (int)Math.Pow(c, 2)) > b.Aggregate(0, (p, c) => p + (int)Math.Pow(c, 3));
  
    [Test, Description("Should work for sample tests")]
    public void SampleTest()
    {
      Assert.AreEqual(true, Kata.ArrayMadness(new int[] {4, 5, 6}, new int[] {1, 2, 3}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {5, 6, 7}, new int[] {4, 5, 6}));
    }

    [Test, Description("Should work for fixed tests")]
    public void FixedTest()
    {
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {4, 5, 6}, new int[] {3, 4, 5}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {3, 4, 5}, new int[] {2, 3, 4}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {2, 3, 4}, new int[] {1, 2, 3}));
      Assert.AreEqual(true, Kata.ArrayMadness(new int[] {1, 2, 3}, new int[] {0, 1, 2}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {5, 3, 2, 4, 1}, new int[] {15}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {2, 5, 3, 4, 1}, new int[] {3, 3, 3, 3, 3}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {1, 3, 4, 2, 4}, new int[] {2, 2, 2, 2, 2, 2, 2, 1}));
      Assert.AreEqual(true, Kata.ArrayMadness(new int[] {1, 2, 3, 4, 5}, new int[] {2, 2, 2, 2, 2, 2, 1, 1, 1}));
      Assert.AreEqual(false, Kata.ArrayMadness(new int[] {2, 4, 6, 8, 10, 12, 14}, new int[] {1, 3, 5, 7, 9, 11, 13}));
    }

    [Test, Description("Should work for random tests")]
    public void RandomTest()
    {
      const int Tests = 666;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] a = new int[rnd.Next(1, 11)].Select(_ => rnd.Next(1, 120)).ToArray();
        int[] b = new int[rnd.Next(1, 11)].Select(_ => rnd.Next(1, 30)).ToArray();
        
        bool expected = solution(a, b);
        bool actual = Kata.ArrayMadness(a, b);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
