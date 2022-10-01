/*Challenge link:https://www.codewars.com/kata/523f5d21c841566fde000009/train/csharp
Question:
Your goal in this kata is to implement a difference function, which subtracts one list from another and returns the result.

It should remove all values from list a, which are present in list b keeping their order.

Kata.ArrayDiff(new int[] {1, 2}, new int[] {1}) => new int[] {2}
If a value is present in b, all of its occurrences must be removed from the other:

Kata.ArrayDiff(new int[] {1, 2, 2, 2, 3}, new int[] {2}) => new int[] {1, 3}
*/

//***************Solution********************
using System.Linq;
//If element in "a" doesn't contain element in "b"
//Pass to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata
{
  public static int[] ArrayDiff(int[] a, int[] b) =>
    a.Where(x => !b.Contains(x)).ToArray();
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
    private static Random rnd = new Random();
    
    private static int[] solution(int[] a, int[] b)
    {
      // With a hashset, we won't have to iterate over b for every item in a.
      // Instead, we can check if an item exists in constant time
      HashSet<int> bSet = new HashSet<int>(b);
      
      return a.Where(v => !bSet.Contains(v)).ToArray();
    }
  
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new int[] {2},       Kata.ArrayDiff(new int[] {1, 2},    new int[] {1}));
      Assert.AreEqual(new int[] {2, 2},    Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {1}));
      Assert.AreEqual(new int[] {1},       Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {2}));
      Assert.AreEqual(new int[] {1, 2, 2}, Kata.ArrayDiff(new int[] {1, 2, 2}, new int[] {}));
      Assert.AreEqual(new int[] {},        Kata.ArrayDiff(new int[] {},        new int[] {1, 2}));
      Assert.AreEqual(new int[] {3}, Kata.ArrayDiff(new int[] {1, 2, 3}, new int[] {1, 2}));
    }
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 300;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] a = new int[rnd.Next(0, 10000)].Select(_ => rnd.Next(0, 1001)).ToArray();
        int[] b = new int[rnd.Next(0, 1000)].Select(_ => rnd.Next(0, 1001)).ToArray();
        
        int[] expected = solution(a, b);
        int[] actual = Kata.ArrayDiff(a, b);

        Assert.AreEqual(expected, actual);
      }
    }
  }
}
