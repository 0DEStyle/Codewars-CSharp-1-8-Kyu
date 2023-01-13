/*Challenge link:https://www.codewars.com/kata/556196a6091a7e7f58000018/train/csharp
Question:
Given a sequence of numbers, find the largest pair sum in the sequence.

For example

[10, 14, 2, 23, 19] -->  42 (= 23 + 19)
[99, 2, 2, 23, 19]  --> 122 (= 99 + 23)
Input sequence contains minimum two elements and every element is an integer.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int LargestPairSum(int[] numbers)=> numbers.OrderByDescending(x=>x).Take(2).Sum();
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
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(-16, Kata.LargestPairSum(new int[] {-8, -8, -16, -18, -19}));
      Assert.AreEqual(0, Kata.LargestPairSum(new int[] {-100, -29, -24, -19, 19}));
      Assert.AreEqual(10, Kata.LargestPairSum(new int[] {1, 2, 3, 4, 6, -1, 2}));
      Assert.AreEqual(42, Kata.LargestPairSum(new int[] {10, 14, 2, 23, 19}));
    }
    
    private static Random rnd = new Random();
    
    private static int solution(int[] numbers)
    {
      int max = int.MinValue;
      int second = int.MinValue;
      
      foreach (int n in numbers) 
      {
        if (n > max) 
        {
          second = max;
          max = n;
        }
        else if (n > second) 
        {
          second = n;
        }
      }
      
      return max + second;
    }
      
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] test = new int[rnd.Next(2, 30)].Select(_ => rnd.Next(-100, 101)).ToArray();
        int[] clone = (int[])test.Clone();
        int expected = solution(test);
        int actual = Kata.LargestPairSum(test);
        
        Assert.AreEqual(clone, test, "User mutated the input array!\nYou might be sorting the input.\nConsider that it is most performant to complete this Kata without sorting.");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
