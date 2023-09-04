/*Challenge link:https://www.codewars.com/kata/515f51d438015969f7000013/train/csharp
Question:
Write a function that when given a number >= 0, returns an Array of ascending length subarrays.

pyramid(0) => [ ]
pyramid(1) => [ [1] ]
pyramid(2) => [ [1], [1, 1] ]
pyramid(3) => [ [1], [1, 1], [1, 1, 1] ]
Note: the subarrays should be filled with 1s


*/

//***************Solution********************

//create loop, start from 1 count up to n, i is current element
//create another loop, start from 1 count up to i, store result as array, then convert and return the result in array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int[][] Pyramid(int n) => Enumerable.Range(1, n).Select(i => Enumerable.Repeat(1, i).ToArray()).ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest {
    [Test]
    public void BasicTests() {
      Assert.AreEqual(new int[][] {}, Kata.Pyramid(0));
      Assert.AreEqual(new int[][] { new int[] { 1 } }, Kata.Pyramid(1));
      Assert.AreEqual(new int[][] { new int[] { 1 }, new int[] { 1, 1 } }, Kata.Pyramid(2));
      Assert.AreEqual(new int[][] { new int[] { 1 }, new int[] { 1, 1 }, new int[] { 1, 1, 1 } }, Kata.Pyramid(3));
    }
    
    private int[][] Sol(int n) => Enumerable.Range(1, n).Select(x => Enumerable.Repeat(1, x).ToArray()).ToArray();
    
    [Test]
    public void RandomTests() {
      Random r = new Random();
      for (int i = 0; i < 100; i++) {
        int n = r.Next(21);
        Assert.AreEqual(Sol(n), Kata.Pyramid(n));
      }
    }
  }
}
