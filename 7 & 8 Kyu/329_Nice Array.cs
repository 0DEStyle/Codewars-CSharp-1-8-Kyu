/*Challenge link:https://www.codewars.com/kata/59b844528bcb7735560000a0/train/csharp
Question:
A Nice array is defined to be an array where for every value n in the array, there is also an element n - 1 or n + 1 in the array.

examples:

[2, 10, 9, 3] is a nice array because

 2 =  3 - 1
10 =  9 + 1
 3 =  2 + 1
 9 = 10 - 1

[4, 2, 3] is a nice array because

4 = 3 + 1
2 = 3 - 1
3 = 2 + 1 (or 3 = 4 - 1)

[4, 2, 1] is a not a nice array because

for n = 4, there is neither n - 1 = 3 nor n + 1 = 5
Write a function named isNice/IsNice that returns true if its array argument is a Nice array, else false. An empty array is not considered nice.
*/

//***************Solution********************
//if arr length is not empty AND all the elements contains either n+1 or n-1
//return a bool value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static bool IsNice(int[] arr) => arr.Length > 0 && arr.All(x => arr.Contains(x + 1) || arr.Contains(x - 1));
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Basic Tests")]
    public void BasicTest()
    {
      Assert.AreEqual(false, Kata.IsNice(new int[] {0,2,19,4,4}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {3,2,1,0}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {3,2,10,4,1,6}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {1,1,8,3,1,1}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {0,1,2,3}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {1,2,3,4}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {0,-1,1}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {0,2,3}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {0}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {0,1,2,3,4,5,6,7,8,9}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {0,1,3,-2,5,4}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {0,-1,-2,-3,-4}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {1,-1,3}));
      Assert.AreEqual(false, Kata.IsNice(new int[] {1,-1,2,-2,3,-3,6}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {2,2,3,3,3}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {1,1,1,2,1,1}));
      Assert.AreEqual(true, Kata.IsNice(new int[] {1,2,7,8}));
    }
    
    private static Random rnd = new Random();
    
    private static int[][] b = new int[][] {new int[] {3,2,10,4,1,6,9},new int[] {3,2,1,0},new int[] {0,1,2,3},new int[] {0,1,3,-2,5,4},new int[] {3,2,10,4,1,6},new int[] {6,2,4,2,2,2,1,5,0,0},new int[] {6,2,4,2,2,2,1,5,0,-100},new int[] {0,0,0,0,0,0,0,0,0,0,1,1,1,-2,-1},new int[] {-6,-3,-3,8,-5,-4},
         new int[] {-6,-3,-3,8,-10,-4},new int[] {3,1,2,4,0},new int[] {0,1},new int[] {1,1,8,3,1,1},new int[] {9,0,6},new int[] {1,1,15,-1,-1},new int[] {0,0,0,0,0,0,0,0,0,0},
         new int[] {6,2,4,2,2,2,1,5,0,0,-12,13,-5,4,6},new int[] {1,1,1,2,1,1},new int[] {2,2,3,3,3},new int[] {0,1,2,3,4,5,6,7,8,9},new int[] {0,-1,1},new int[] {-2,5,0,5,12},new int[] {2},new int[] {0},new int[] {1,3,9,8},new int[] {},new int[] {1,2,3,4,0},new int[] {6,2,4,2,2,2,1,5,0,0,-12,13,-5,4,1},new int[] {25},new int[] {1,2,0,4,3}};
  
    private static bool solution(int[] arr)
    {
      HashSet<int> hSet = new HashSet<int>(arr);
      
      return arr.Any() && arr.All(v => hSet.Contains(v + 1) || hSet.Contains(v - 1));
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] arr = b[rnd.Next(0, b.Length)];
        
        bool expected = solution(arr);
        bool actual = Kata.IsNice(arr);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
