/*Challenge link:https://www.codewars.com/kata/5259acb16021e9d8a60010af/train/csharp
Question:
Write a function that calculates the least common multiple of its arguments; each argument is assumed to be a non-negative integer. 
In the case that there are no arguments (or the provided array in compiled languages is empty), return 1. If any argument is 0, return 0.
*/

//***************Solution********************
using System.Linq;
using System.Collections.Generic;

public static class Kata{
    public static int Lcm(List<int> nums){
      //validation
        if (nums.Count == 0) 
          return 1;
        if (nums.Contains(0)) 
          return 0;
      
      //get max from nums list
        var sum = nums.Max();
      //check if nums.count where sum mod element is equal to 0, then check if it is not equal to nums.count
      //if true, add nums.max to sum
        while (nums.Count(i => sum % i == 0) != nums.Count)
            sum += nums.Max();

        return sum;
    }
}

//method 2
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static int Lcm(List<int> nums)
  {
    int gcd(int a, int b) => b != 0 ? gcd(b, a % b) : a;
    return nums.Aggregate(1, (a, b) => a * b / gcd(a, b));
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static int Gcd2(int a, int b) => b == 0 ? a : Gcd2(b, a % b);
    public static int Lcm2(int a, int b) => a * b / Gcd2(a, b);
    public static int Lcm(List<int> nums) => nums.Aggregate(1, Lcm2);
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void FixedTest()
    {
      Assert.That(Kata.Lcm(new List<int> {2, 5}), Is.EqualTo(10));
      Assert.That(Kata.Lcm(new List<int> {2, 3, 4}), Is.EqualTo(12));
      Assert.That(Kata.Lcm(new List<int> {9}), Is.EqualTo(9));
      Assert.That(Kata.Lcm(new List<int> {0}), Is.EqualTo(0));
      Assert.That(Kata.Lcm(new List<int> {0, 1}), Is.EqualTo(0));
      Assert.That(Kata.Lcm(new List<int> {1, 1, 1}), Is.EqualTo(1));
      Assert.That(Kata.Lcm(new List<int> {5, 6, 7, 9, 6, 9, 18, 4, 5, 15, 15, 10, 17, 7}), Is.EqualTo(21420));
      Assert.That(Kata.Lcm(new List<int> {17, 20, 4, 15, 4, 18, 12, 14, 20, 19, 2, 14, 13, 7}), Is.EqualTo(5290740));
      Assert.That(Kata.Lcm(new List<int> {11, 13, 4, 5, 17, 4, 10, 13, 16, 13, 13, 14, 20, 14}), Is.EqualTo(1361360));
      Assert.That(Kata.Lcm(new List<int> {20, 1, 6, 10, 3, 7, 8, 4}), Is.EqualTo(840));
      Assert.That(Kata.Lcm(new List<int> {3, 9, 9, 19, 18, 14, 18, 9}), Is.EqualTo(2394));
      Assert.That(Kata.Lcm(new List<int> {3, 9, 9, 19, 18, 14, 18, 0}), Is.EqualTo(0));
      Assert.That(Kata.Lcm(new List<int> {19, 3, 20, 15, 4, 17, 14}), Is.EqualTo(135660));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        List<int> nums = new List<int>(rnd.Next(0, 8));
        for (int j = 0; j < nums.Capacity; ++j) 
        {
          nums.Add(rnd.Next(1, 20));
        }
        Assert.That(Kata.Lcm(nums.ToList()), Is.EqualTo(Solution.Lcm(nums)));
      }
    }
  }
}
