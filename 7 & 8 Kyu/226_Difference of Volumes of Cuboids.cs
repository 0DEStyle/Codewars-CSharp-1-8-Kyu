/*Challenge link:https://www.codewars.com/kata/58cb43f4256836ed95000f97
Question:
In this simple exercise, you will create a program that will take two lists of integers, a and b. Each list will consist of 3 positive integers above 0, representing the dimensions of cuboids a and b. You must find the difference of the cuboids' volumes regardless of which is bigger.

For example, if the parameters passed are ([2, 2, 3], [5, 4, 1]), the volume of a is 12 and the volume of b is 20. Therefore, the function should return 8.

Your function will be tested with pre-made examples as well as random ones.

If you can, try writing it in one line of code.
*/

//***************Solution********************
//multiply everything in array x, and everything in array y
//then take the difference between x and y, and apply absolute value(no negative), return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static int FindDifference(int[] x, int[] y) =>  Math.Abs(x.Aggregate(1, (a, b) =>a * b) - y.Aggregate(1, (a, b) =>a * b));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Sample_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new[] {new int[] {3, 2, 5}, new int[] {1, 4, 4}}).Returns(14);
        yield return new TestCaseData(new[] {new int[] {9, 7, 2}, new int[] {5, 2, 2}}).Returns(106);
        yield return new TestCaseData(new[] {new int[] {11, 2, 5}, new int[] {1, 10, 8}}).Returns(30);
        yield return new TestCaseData(new[] {new int[] {4, 4, 7}, new int[] {3, 9, 3}}).Returns(31);
        yield return new TestCaseData(new[] {new int[] {15, 20, 25}, new int[] {10, 30, 25}}).Returns(0);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int[] a, int[] b) => Kata.FindDifference(a, b);
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static int solution(int[] a, int[] b) =>
      Math.Abs((a[0] * a[1] * a[2]) - (b[0] * b[1] * b[2]));
      
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] a = new int[] {rnd.Next(1, 30), rnd.Next(1, 30), rnd.Next(1, 30)};
        int[] b = new int[] {rnd.Next(1, 30), rnd.Next(1, 30), rnd.Next(1, 30)};
        
        int expected = solution(a, b);
        int actual = Kata.FindDifference(a, b);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
