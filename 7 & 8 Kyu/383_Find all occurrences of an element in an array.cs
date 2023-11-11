/*Challenge link:https://www.codewars.com/kata/59a9919107157a45220000e1/train/csharp
Question:
Given an array (a list in Python) of integers and an integer n, find all occurrences of n in the given array and return another array containing all the index positions of n in the given array.

If n is not in the given array, return an empty array [].

Assume that n and all values in the given array will always be integers.

Example:

Kata.FindAll(new int[] {6, 9, 3, 4, 3, 82, 11}, 3) => new int[] {2, 4}
*/

//***************Solution********************


//x is current element, i is index
//from array select if current element x is n, return index, else -1
//from previous selected elements, get all elements that is not -1, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int[] FindAll(int[] array, int n) => 
    array.Select((x,i) => x == n ? i : -1).Where(x => x != -1).ToArray();
}

//solution 2
using System.Linq;

public class Kata
{
  public static int[] FindAll(int[] a, int n) => Enumerable.Range(0, a.Length).Where(i => a[i] == n).ToArray();
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
    
    private static int[] solution(int[] array, int n) =>
      array.Select((v, i) => v == n ? i : -1).Where(v => v != -1).ToArray();
  
    [Test, Description("Your solution should pass some fixed tests")]
    public void FixedTest()
    {
      Assert.AreEqual(new int[] {2, 4}, Kata.FindAll(new int[] {6, 9, 3, 4, 3, 82, 11}, 3));
      Assert.AreEqual(new int[] {1, 9}, Kata.FindAll(new int[] {10, 16, 20, 6, 14, 11, 20, 2, 17, 16, 14}, 16));
      Assert.AreEqual(new int[] {0, 1, 8}, Kata.FindAll(new int[] {20, 20, 10, 13, 15, 2, 7, 2, 20, 3, 18, 2, 3, 2, 16, 10, 9, 9, 7, 5, 15, 5}, 20));
    }
    
    [Test, Description("Your solution should pass some random tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] array = new int[rnd.Next(1, 100)].Select(_ => rnd.Next(1, 40)).ToArray();
        int n = rnd.Next(1, 40);
        
        int[] expected = solution(array, n);
        int[] actual = Kata.FindAll(array, n);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
