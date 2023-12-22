/*Challenge link:https://www.codewars.com/kata/57bfea4cb19505912900012c/train/csharp
Question:
"Point reflection" or "point symmetry" is a basic concept in geometry where a given point, P, at a given position relative to a mid-point, Q has a corresponding point, P1, which is the same distance from Q but in the opposite direction.

Task
Given two points P and Q, output the symmetric point of point P about Q. Each argument is a two-element array of integers representing the point's X and Y coordinates. Output should be in the same format, giving the X and Y coordinates of point P1. You do not have to validate the input.

This kata was inspired by the Hackerrank challenge Find Point
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//apply formula, format into int array and return result.

public class Kata{
  public static int[] SymmetricPoint(int[] p, int[] q) => 
    new []{2 * q[0] - p[0], 2 * q[1] - p[1]};
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
    
    private static int[] solution(int[] p, int[] q) => p.Select((v, i) => v + (q[i] - v) * 2).ToArray();
  
    [Test, Description("Your solution should work for some fixed tests")]
    public void FixedTest()
    {
      Assert.AreEqual(new int[] {2, 2},        Kata.SymmetricPoint(new int[] {0, 0},     new int[] {1, 1}));
      Assert.AreEqual(new int[] {-6, -18},     Kata.SymmetricPoint(new int[] {2, 6},     new int[] {-2, -6}));
      Assert.AreEqual(new int[] {-30, 30},     Kata.SymmetricPoint(new int[] {10, -10},  new int[] {-10, 10}));
      Assert.AreEqual(new int[] {-25, 37},     Kata.SymmetricPoint(new int[] {1, -35},   new int[] {-12, 1}));
      Assert.AreEqual(new int[] {-1014, -443}, Kata.SymmetricPoint(new int[] {1000, 15}, new int[] {-7, -214}));
      Assert.AreEqual(new int[] {0, 0},        Kata.SymmetricPoint(new int[] {0, 0},     new int[] {0, 0}));
    }
    
    [Test, Description("Your solution should work for some random tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] p = new int[] {rnd.Next(-10000, 10001), rnd.Next(-10000, 10001)};
        int[] q = new int[] {rnd.Next(-10000, 10001), rnd.Next(-10000, 10001)};
        
        int[] expected = solution(p, q);
        int[] actual = Kata.SymmetricPoint(p, q);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
