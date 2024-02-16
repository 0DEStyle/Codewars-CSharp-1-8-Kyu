/*Challenge link:https://www.codewars.com/kata/56582133c932d8239900002e/train/csharp
Question:
Complete the function to find the count of the most frequent item of an array. You can assume that input is an array of integers. For an empty array return 0

Example
input array: [3, -1, -1, -1, 2, 3, -1, 3, -1, 2, 4, 9, 3]
ouptut: 5 
The most frequent number in the array is -1 and it occurs 5 times.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check if collect is empty, if so return 0,
//else, group each number, then select the one with highest count.
using System.Linq;

public class Kata{
  public static int MostFrequentItemCount(int[] c) => 
    c.Length == 0 ? 0 : c.GroupBy(x => x).Max(x => x.Count());
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Diagnostics;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
  
    private static Random rnd = new Random();
    
    private static int solution(int[] collection)
    {
      if (collection.Length == 0) { return 0; }
      
      return collection
        .GroupBy(x => x)
        .OrderByDescending(x => x.Count())
        .First().Count();
    }
    
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {new int[] {3, -1, -1}, 2},
      new object[] {new int[] {3, -1, -1, -1, 2, 3, -1, 3, -1, 2, 4, 9, 3}, 5},
    };
    
    private static object[] Edge_Test_Cases = new object[]
    {
      new object[] {new int[] {}, 0},
      new object[] {new int[] {9}, 1},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(int[] test, int expected)
    {
      Assert.AreEqual(expected, Kata.MostFrequentItemCount(test));
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Edge_Test_Cases")]
    public void Edge_Test(int[] test, int expected)
    {
      Assert.AreEqual(expected, Kata.MostFrequentItemCount(test));
    }
    
    [Test, Description("Random Tests (1000 assertions)")]
    public void Random_Test()
    {
      Stopwatch sw = new Stopwatch();
      const int tests = 1000;
    
      for (int i = 0; i < tests; ++i)
      {
        int[] test = new int[rnd.Next(0, 100)];
        
        for (int j = 0; j < test.Length; ++j)
        {
          test[j] = rnd.Next(-15, 16);
        }
        
        int[] clone = (int[])test.Clone();
        
        sw.Start();
        int actual = Kata.MostFrequentItemCount(test);
        sw.Stop();
        
        Assert.AreEqual(test, clone, "User mutated the input array!");
        int expected = solution(test);
        Assert.AreEqual(expected, actual, "input: {" + String.Join(", ", test) + "}");
      }
      
      Console.WriteLine("Random tests passed!\nTotal user code execution time was {0}ms over {1} assertions", sw.Elapsed.TotalMilliseconds, tests);
    }
  }
}
