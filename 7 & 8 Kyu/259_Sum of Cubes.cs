/*Challenge link:https://www.codewars.com/kata/59a8570b570190d313000037/train/csharp
Question:
Write a function that takes a positive integer n, sums all the cubed values from 1 to n (inclusive), and returns that sum.

Assume that the input n will always be a positive integer.

Examples: (Input --> output)

2 --> 9 (sum of the cubes of 1 and 2 is 1 + 8)
3 --> 36 (sum of the cubes of 1, 2, and 3 is 1 + 8 + 27)
*/

//***************Solution********************
//apply algorithm to avoid using a loop, speeds up the execution time
//convert the answers to long and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public static class Kata{
  public static long SumCubes(int n) => (long)Math.Pow((n*(n+1)/2),2);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  public static class Solution
  {
    public static long SumCubes(int n) =>
      (long)Math.Pow(n * (n + 1) / 2, 2);
  }
  
  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual(1, Kata.SumCubes(1));
      Assert.AreEqual(9, Kata.SumCubes(2));
      Assert.AreEqual(36, Kata.SumCubes(3));
      Assert.AreEqual(100, Kata.SumCubes(4));
      Assert.AreEqual(3025, Kata.SumCubes(10));
      Assert.AreEqual(58155876, Kata.SumCubes(123));
    }
    
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int n = rnd.Next(1, 10000);
        
        long expected = Solution.SumCubes(n);
        long actual = Kata.SumCubes(n);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
