/*Challenge link:https://www.codewars.com/kata/58aed2cafab8faca1d000e20/train/csharp
Question:
You are provided with an array of positive integers and an additional integer n (n > 1).

Calculate the sum of each value in the array to the nth power. Then subtract the sum of the original array.

Examples
{1, 2, 3}, 3  -->  (1^3 + 2^3 + 3^3 ) - (1 + 2 + 3)  -->  36 - 6  -->  30
{1, 2}, 5     -->  (1^5 + 2^5) - (1 + 2)             -->  33 - 3  -->  30
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//Accumulate pow of each number, sum them, then subtract the sum of a.

using System.Linq;
using static System.Math;

public class Kata{
  public static int ModifiedSum(int[] a, int n) => (int) (a.Sum(x => Pow(x, n)) - a.Sum()); 
}

//solution 2
using System;
using System.Linq;

public class Kata
{
    public static int ModifiedSum(int[] a, int n)
    {
        return a.Sum(x => (int) Math.Pow(x, n) - x);
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Diagnostics;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {new int[] {1, 2, 3}, 3, 30},
      new object[] {new int[] {1, 2}, 5, 30},
    };
    
    private static object[] Extra_Basic_Test_Cases = new object[]
    {
      new object[] {new int[] {3, 5, 7}, 2, 68},
    };
    
    private static object[] Advanced_Test_Cases = new object[]
    {
      new object[] {new int[] {1, 2, 3, 4, 5}, 3, 210},
      new object[] {new int[] {2, 7, 13, 17}, 2, 472},
      new object[] {new int[] {2, 5, 8}, 3, 630},
      new object[] {new int[] {2, 4, 6, 8}, 6, 312940},
      new object[] {new int[] {5, 10, 15}, 4, 61220},
      new object[] {new int[] {3, 6, 9, 12}, 3, 2670},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(int[] array, int exponent, int expected)
    {
      Assert.AreEqual(expected, Kata.ModifiedSum(array, exponent), "Solution should work for the examples provided in the Description");
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Extra_Basic_Test_Cases")]
    public void Extra_Basic_Test(int[] array, int exponent, int expected)
    {
      Assert.AreEqual(expected, Kata.ModifiedSum(array, exponent), "Solution should work for another basic fixed assertion");
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Advanced_Test_Cases")]
    public void Advanced_Test(int[] array, int exponent, int expected)
    {
      Assert.AreEqual(expected, Kata.ModifiedSum(array, exponent), "Solution should work for some advanced fixed assertions as well");
    }
    
    [Test, Description("Random Tests (1000 assertions)")]
    public void Random_Test()
    {
      Stopwatch sw = new Stopwatch();
      const int tests = 1000;
      
      for (int i = 0; i < tests; ++i)
      {
        int[] array = new int[rnd.Next(2, 21)].Select(e => rnd.Next(1, 11)).ToArray();
        int exponent = rnd.Next(2, 8);
        int expected = array.Aggregate(0, (acc, curr) => (int)Math.Pow(curr, exponent) + acc - curr);
        
        sw.Start();
        int actual = Kata.ModifiedSum(array, exponent);
        sw.Stop();
        
        Assert.AreEqual(expected, actual);
      }
      
      Console.WriteLine("Random tests passed!\nUser code execution time was {0}ms over {1} assertions.", sw.Elapsed.TotalMilliseconds, tests);
    }
  }
}
