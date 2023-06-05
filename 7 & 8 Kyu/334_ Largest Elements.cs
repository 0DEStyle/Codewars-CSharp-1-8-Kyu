/*Challenge link:https://www.codewars.com/kata/53d32bea2f2a21f666000256/train/csharp
Question:
Write a program that outputs the top n elements from a list.

Example:

Kata.Largest(2, new List<int> {7, 6, 5, 4, 3, 2, 1}) => new List<int> {6, 7}
*/

//***************Solution********************
//order the list by descending, from large to small
//take n amount of element,
//Reverse it to get the correct format
//convert to list and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata{
  public static List<int> Largest(int n, List<int> xs) => xs.OrderByDescending(x=>x).Take(n).Reverse().ToList();
}

//method 2
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static List<int> Largest(int n, List<int> xs)
  {
    return xs.OrderBy(x => x).TakeLast(n).ToList();
  }
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
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual(new List<int> {9, 10}, Kata.Largest(2, new List<int> {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}));
      Assert.AreEqual(new List<int> {5, 5, 5}, Kata.Largest(3, new List<int> {5, 1, 5, 2, 3, 1, 2, 3, 5}));
      Assert.AreEqual(new List<int> {3, 5, 9, 13, 22, 50, 63}, Kata.Largest(7, new List<int> {9, 1, 50, 22, 3, 13, 2, 63, 5}));
      Assert.AreEqual(new List<int> {}, Kata.Largest(0, new List<int> {1, 2, 3, 4, 8, 7, 6, 5}));
    }
    
    [Test, Description("Fixed Tests")]
    public void FixedTest()
    {
      Assert.AreEqual(new List<int> {}, Kata.Largest(0, new List<int> {10, 9, 8, 7, 6, 5, 4, 3, 2, 1}), "0 largest of 10 elements");
      Assert.AreEqual(new List<int> {-1, 0}, Kata.Largest(2, new List<int> {-3, -2, -1, 0, -9, -8, -7, -6, -4, -5}), "...elements may be negative");
    }
    
    private static Random rnd = new Random();
    
    private static List<int> solution(int n, List<int> xs) =>
      xs.OrderBy(x => x).Skip(xs.Count - n).ToList();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        List<int> xs = new int[rnd.Next(0, 100)].Select(_ => rnd.Next()).ToList();
        int n = rnd.Next(0, xs.Count);
        
        List<int> expected = solution(n, xs);
        List<int> actual = Kata.Largest(n, xs);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
