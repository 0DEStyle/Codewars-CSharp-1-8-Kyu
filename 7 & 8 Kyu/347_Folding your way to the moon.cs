/*Challenge link:https://www.codewars.com/kata/58f0ba42e89aa6158400000e/train/csharp
Question:
Have you heard about the myth that if you fold a paper enough times, you can reach the moon with it? Sure you have, but exactly how many? Maybe it's time to write a program to figure it out.

You know that a piece of paper has a thickness of 0.0001m. Given distance in units of meters, calculate how many times you have to fold the paper to make the paper reach this distance.
(If you're not familiar with the concept of folding a paper: Each fold doubles its total thickness.)

Note: Of course you can't do half a fold. You should know what this means ;P

Also, if somebody is giving you a negative distance, it's clearly bogus and you should yell at them by returning null (or whatever equivalent in your language). In Shell please return None. In C and COBOL please return -1.
*/

//***************Solution********************

//check if distance is negative, if so return null
//else check if distance is less than 0.0001, if true return 0
//else Log (distance * 10000)/ Log (2), then round up
//type cast double to nullable int and returnt the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public class Kata{
  public static int? FoldTo(double distance) => 
    distance < 0 ? null : 
    (int?) (distance < 0.0001 ? 0 : Math.Ceiling(Math.Log(distance * 10000, 2)));
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Diagnostics;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static int? solution(double distance)
    {
      // return null if distance is negative or 0
      if (distance < 0) { return null; }
      
      const double initialThickness = 0.0001;
      
      return (int)Math.Max(Math.Ceiling(Math.Log(distance / initialThickness, 2)), 0);
    }
    
    private static int? solution2(double distance)
    {
      if (distance < 0) { return null; }
      int count = 0;
      for (double d = 0.0001; d < distance; count++) d *= 2;
      return count;
    }
  
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {384000000, 42},
      new object[] {0.000001, 0},
      new object[] {0, 0},
      new object[] {-1, null},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(double distance, int? expected)
    {
      Assert.AreEqual(expected, Kata.FoldTo(distance));
    }
    
    [Test, Description("Random Tests (1000 assertions)")]
    public void Random_Test()
    {
      Stopwatch sw = new Stopwatch();
      const int tests = 1000;
      
      for (int i = 0; i < tests; ++i)
      {
        double distance, random = rnd.NextDouble();
        if (random < 0.1) { distance = 0; }
        else { distance = 0.0001*Math.Pow(2, rnd.NextDouble()*(128+22)-22); }
        if (random > 0.9) { distance *= -1; }
        Console.WriteLine("Distance: {0}m", distance);
        
        int? expected = solution2(distance);
        
        sw.Start();
        int? actual = Kata.FoldTo(distance);
        sw.Stop();
        
        Assert.AreEqual(expected, actual);
      }
      
      Console.WriteLine("\nRandom tests passed!\nUser code execution time was {0} milliseconds over {1} assertions.", sw.Elapsed.TotalMilliseconds, tests);
    }
    
  }
}
