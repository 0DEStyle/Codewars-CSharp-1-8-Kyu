/*Challenge link:https://www.codewars.com/kata/57c6b44f58da9ea6c20003da/train/csharp
Question:
Introduction
Take a list of n numbers a1, a2, a3, ..., aN to start with.

Arithmetic mean (or average) is the sum of these numbers divided by n.

Geometric mean (or average) is the product of these numbers taken to the nth root.

Example
List of numbers: 1, 3, 9, 27, 81

n = 5
Arithmetic mean = (1 + 3 + 9 + 27 + 81) / 5 = 121 / 5 = 24.2
Geometric mean = (1 * 3 * 9 * 27 * 81) ^ (1/5) = 59049 ^ (1/5) = 9
Task
You will be given a list of numbers and their arithmetic mean. However, the list is missing one number. Using this information, you must figure out and return the geometric mean of the FULL LIST, including the number that's missing.


*/

//***************Solution********************
using System.Linq;
using static System.Math;

public class Kata{
  public static double Geo_Mean(int[] nums, double arith_mean){
    //missing one number, so nums.Length + 1, 
    //time mean to find total, then subtract the sum of nums to find what's left
    var missing = (arith_mean * (nums.Length + 1)) - nums.Sum();
    
    //acuumulate result for geometric mean, x is current element, y is next
    //then product ^ 1/nums.Length + 1
    return Pow(nums.Aggregate(missing, (x, y) => x * y), 1.0 / (nums.Length + 1));
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(2.2894284851066637, Kata.Geo_Mean(new int[] { 1,2 }, 3));
      Assert.AreEqual(4.580344097847165, Kata.Geo_Mean(new int[] { 4,6,7,2 }, 5));
    }
    
    [Test]
    public void ExtendedTests()
    {
      var results1 = Kata.Geo_Mean(new int[] { 4,4,2 }, 3);
      var results2 = Kata.Geo_Mean(new int[] { 5,6,2,8,6 }, 6);
      var results3 = Kata.Geo_Mean(new int[] { 2,4,9,4,56,4,1,0 }, 23);

      Assert.AreEqual(2.8284271247461903, results1);
      Assert.AreEqual(5.440086845994799, results2);
      Assert.AreEqual(0.0, results3);

      var results4 = Kata.Geo_Mean(new int[] { -4,45,9 }, 6);
      var results5 = Kata.Geo_Mean(new int[] { 1,23,-2,8,6,35,-34,52 }, 10);
      var results6 = Kata.Geo_Mean(new int[] { 1,-3,3,6,5,52,130,-2,4,-5 }, 10);

      Assert.AreEqual(14.325905783504401, results4);
      Assert.AreEqual(8.015856437398835, results5);
      Assert.AreEqual(7.7330442855597, results6);
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<40;r++)
      {
        var length = rand.Next(3,8);
        var arr = Enumerable.Range(0,length).Select(a => rand.Next(2,21)).ToArray();
        
        double expected = Math.Pow(arr.Aggregate((a,b) => a*b), 1 / (double)length);
        
        Assert.AreEqual(Math.Round(expected,5), Math.Round(Kata.Geo_Mean(arr.Take(length-1).ToArray(), ((double)arr.Sum()) / length),5));
      }       
    }
  }
}
