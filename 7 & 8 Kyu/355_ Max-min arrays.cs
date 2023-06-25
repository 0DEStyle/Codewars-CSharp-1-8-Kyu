/*Challenge link:https://www.codewars.com/kata/5a090c4e697598d0b9000004/train/csharp
Question:
In this Kata, you will be given an array of unique elements, and your task is to rearrange the values so that the first max value is followed by the first minimum, followed by second max value then second min value, etc.

For example:

Kata.Solve(new List<int> {15,11,10,7,12}) => new List<int> {15,7,12,10,11}
The first max is 15 and the first min is 7. The second max is 12 and the second min is 10 and so on.

More examples in the test cases.

Good luck!
*/

//***************Solution********************
//create a loop start from 0 up to arr.Count
//if element is even, order by descending, but skip half of the values, select the first
//if element is odd, order normaly(Ascending), skip half of the values select the first
//store results as list and return the result.

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
  public static List<int> Solve(List<int> arr) =>
                Enumerable.Range(0, arr.Count).Select(i =>
                i % 2 == 0
                ? arr.OrderByDescending(x => x).Skip(i / 2).First()
                : arr.OrderBy(x => x).Skip(i / 2).First()).ToList();
  
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static List<int> Solve(List<int> arr)
    {
      List<int> sorted = arr.OrderBy(x => x).ToList();
      List<int> result = new List<int>(arr.Count);
      int i = 0;
      int j = arr.Count - 1;
      while (i < j)
      {
        result.Add(sorted[j--]);
        result.Add(sorted[i++]);
      }
      if (i == j) { result.Add(sorted[i]); }
      return result;
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.Solve(new List<int> {15,11,10,7,12}), Is.EqualTo(new List<int> {15,7,12,10,11}));
      Assert.That(Kata.Solve(new List<int> {91,75,86,14,82}), Is.EqualTo(new List<int> {91,14,86,75,82}));
      Assert.That(Kata.Solve(new List<int> {84,79,76,61,78}), Is.EqualTo(new List<int> {84,61,79,76,78}));
      Assert.That(Kata.Solve(new List<int> {52,77,72,44,74,76,40}), Is.EqualTo(new List<int> {77,40,76,44,74,52,72}));
      Assert.That(Kata.Solve(new List<int> {1,6,9,4,3,7,8,2}), Is.EqualTo(new List<int> {9,1,8,2,7,3,6,4}));
      Assert.That(Kata.Solve(new List<int> {78,79,52,87,16,74,31,63,80}), Is.EqualTo(new List<int> {87,16,80,31,79,52,78,63,74}));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int length = rnd.Next(100, 200);
        HashSet<int> nums = new HashSet<int>();
        while (length-- != 0)
        {
          nums.Add(rnd.Next(6, 10000));
        }
        List<int> arr = new List<int>(nums);
        Assert.That(Kata.Solve(arr), Is.EqualTo(Solution.Solve(arr)));
      }
    }
  }
}
