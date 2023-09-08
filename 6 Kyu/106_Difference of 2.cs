/*Challenge link:https://www.codewars.com/kata/5340298112fa30e786000688/train/csharp
Question:
The objective is to return all pairs of integers from a given array of integers that have a difference of 2.

The result array should be sorted in ascending order of values.

Assume there are no duplicate integers in the array. The order of the integers in the input array should not matter.

Examples
[1, 2, 3, 4]  should return [[1, 3], [2, 4]]

[4, 1, 2, 3]  should also return [[1, 3], [2, 4]]

[1, 23, 3, 4, 7] should return [[1, 3]]

[4, 3, 1, 5, 6] should return [[1, 3], [3, 5], [4, 6]]
*/

//***************Solution********************


//order input by ascending order, i is the current element
//if input contains 1+2
//select i and i+2, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static (int, int)[] TwosDifference(int[] input) =>
      input.OrderBy(i => i)
           .Where(i => input.Contains(i + 2))
           .Select(i => (i, i + 2))
           .ToArray();
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class FixedTests
  {
    [Test]
    public void Tests()
    {
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (2, 4)},
        Kata.TwosDifference(new int[]{1, 2, 3, 4})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (4, 6)},
        Kata.TwosDifference(new int[]{1, 3, 4, 6})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3)},
        Kata.TwosDifference(new int[]{0, 3, 1, 4})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (2, 4)},
        Kata.TwosDifference(new int[]{4, 1, 2, 3})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (3, 5), (4, 6)},
        Kata.TwosDifference(new int[]{6, 3, 4, 1, 5})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (4, 6)},
        Kata.TwosDifference(new int[]{3, 1, 6, 4})
      );
      
      Assert.AreEqual(
        new (int, int)[]{(1, 3), (3, 5), (6, 8), (8, 10), (10, 12), (12, 14)},
        Kata.TwosDifference(new int[]{1, 3, 5, 6, 8, 10, 15, 32, 12, 14, 56})
      );
    }
  }

  [TestFixture]
  public class RandomTests
  {
    private static Random rand = new Random();
  
    private static void Shuffle(int[] a)
    {
      for (int i = a.Length - 1; i > 0; i--)
      {
        int j = rand.Next(i + 1), temp = a[j];
        a[j] = a[i];
        a[i] = temp;
      }
    }
  
    private static (int, int)[] Solution(int[] a)
    {
      var s = new HashSet<int>(a);
      return a.Where(x => s.Contains(x + 2)).OrderBy(x => x).Select(x => (x, x + 2)).ToArray();
    }
  
    [Test]
    public void Tests()
    {
      var base_ = new int[1001];
      for (int i = 0; i <= 1000; i++) base_[i] = i;
      
      for (int i = 0; i < 100; i++)
      {
        Shuffle(base_);
        var a = base_.Take(rand.Next(201)).ToArray();
        var result = Solution(a);
        Assert.AreEqual(result, Kata.TwosDifference(a));
      }
    }
  }
}
