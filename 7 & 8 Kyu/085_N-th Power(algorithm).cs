/*Challenge link:https://www.codewars.com/kata/57d814e4950d8489720008db/train/csharp
Question:
This kata is from check py.checkio.org

You are given an array with positive numbers and a non-negative number N. You should find the N-th power of the element in the array with the index N. If N is outside of the array, then return -1. Don't forget that the first element has the index 0.

Let's look at a few examples:

array = [1, 2, 3, 4] and N = 2, then the result is 3^2 == 9;
array = [1, 2, 3] and N = 3, but N is outside of the array, so the result is -1.
*/

//***************Solution********************
//check array length, if n is greater than index length, return -1
//else return index n to the power of n
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata
{
  public static double Index(int[] array, int n)=> array.Length > n ? Math.Pow(array[n], n) : -1;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static double Solution(int[] array, int n)
    {
      return (n >= array.Length) ? -1 : Math.Pow(array[n], n);
    }
  
    [Test]
    public void FixedTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(9, Kata.Index(new int[] {1, 2, 3, 4}, 2)),
        () => Assert.AreEqual(1000000, Kata.Index(new int[] {1, 3, 10, 100}, 3)),
        () => Assert.AreEqual(1, Kata.Index(new int[] {0, 1}, 0)),
        () => Assert.AreEqual(-1, Kata.Index(new int[] {1, 2}, 3)),
        () => Assert.AreEqual(1, Kata.Index(new int[] {0}, 0)),
        () => Assert.AreEqual(1, Kata.Index(new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 9)),
        () => Assert.AreEqual(1000000000000000000, Kata.Index(new int[] {1, 1, 1, 1, 1, 1, 1, 1, 1, 100}, 9)),
        () => Assert.AreEqual(1000, Kata.Index(new int[] {29, 82, 45, 10}, 3)),
        () => Assert.AreEqual(-1, Kata.Index(new int[] {6, 31}, 3)),
        () => Assert.AreEqual(-1, Kata.Index(new int[] {75, 68, 35, 61, 9, 36, 89, 0, 30}, 10)),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int length = rnd.Next(0, 10);
        int idx = rnd.Next(0, 10);
        int[] arr = new int[length].Select(x => rnd.Next(0, 100)).ToArray();
        double expected = Solution(arr, idx);
        double actual = Kata.Index(arr, idx);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
