/*Challenge link:https://www.codewars.com/kata/580dda86c40fa6c45f00028a/train/csharp
Question:
Find the sum of the odd numbers within an array, after cubing the initial integers. The function should return undefined/None/nil/NULL if any of the values aren't numbers.

Note: There are ONLY integers in the JAVA and C# versions of this Kata.


*/

//***************Solution********************
//check if arr is empty
//if so, return 0, else find the sum of all cubed all odd numbers.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int CubeOdd(int[] arr) => arr.Length == 0 ? 0 : arr.Sum(x=> x% 2 != 0 ? x*x*x : 0);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(28, Kata.CubeOdd(new int[] {1, 2, 3, 4}));
      Assert.AreEqual(0, Kata.CubeOdd(new int[] {-3, -2, 2, 3}));
    }
    
    private static int Solution(int[] arr) => arr.Select(x => x * x * x).Where(x => x % 2 == 1 || x % 2 == -1).Sum();
    
    [Test]
    public void SupplementalTest()
    {
      Assert.AreEqual(0, Kata.CubeOdd(new int[] {-5, -5, 5, 5}));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i <= 100; i++)
      {
        List<int> testCase = new List<int>();
        
        for (int j = 0; j <= rnd.Next(3, 10); ++j)
        {
          testCase.Add(rnd.Next(0, 60) - 10);
        }
        
        int myAnswer = Solution(testCase.ToArray());
        int theirAnswer = Kata.CubeOdd(testCase.ToArray());
        Assert.AreEqual(myAnswer, theirAnswer);
      }
    }
  }
  
  
  
  
}
