/*Challenge link:https://www.codewars.com/kata/5a63948acadebff56f000018/train/csharp
Question:
Introduction and Warm-up (Highly recommended)
Playing With Lists/Arrays Series
Task
Given an array/list [] of integers , Find the product of the k maximal numbers.

Notes
Array/list size is at least 3 .

Array/list's numbers Will be mixture of positives , negatives and zeros

Repetition of numbers in the array/list could occur.

Input >> Output Examples
maxProduct ({4, 3, 5}, 2) ==>  return (20)
Explanation:
Since the size (k) equal 2 , then the subsequence of size 2 whose gives product of maxima is 5 * 4 = 20 .
maxProduct ({8, 10 , 9, 7}, 3) ==>  return (720)
Explanation:
Since the size (k) equal 3 , then the subsequence of size 3 whose gives product of maxima is  8 * 9 * 10 = 720 .
maxProduct ({10, 8, 3, 2, 1, 4, 10}, 5) ==> return (9600)
Explanation:
Since the size (k) equal 5 , then the subsequence of size 5 whose gives product of maxima is  10 * 10 * 8 * 4 * 3 = 9600 .
maxProduct ({-4, -27, -15, -6, -1}, 2) ==> return (4)
Explanation:
Since the size (k) equal 2 , then the subsequence of size 2 whose gives product of maxima is  -4 * -1 = 4 .
maxProduct ({10, 3, -1, -27} , 3)  return (-30)
Explanation:
Since the size (k) equal 3 , then the subsequence of size 3 whose gives product of maxima is 10 * 3 * -1 = -30 .
*/

//***************Solution********************
//sort the array from high to low, take the first "size" amount of elemenets and find the product.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata {
  public static int MaxProduct(int[] arr, int size) => arr.OrderByDescending(x=>x).Take(size).Aggregate(1, (a, b) => a * b);
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
      Assert.AreEqual(20, Kata.MaxProduct(new int[] { 4, 3, 5 }, 2));
      Assert.AreEqual(720, Kata.MaxProduct(new int[] { 10, 8, 7, 9 }, 3));
      Assert.AreEqual(288, Kata.MaxProduct(new int[] { 8, 6, 4, 6 }, 3));
      Assert.AreEqual(9600, Kata.MaxProduct(new int[] { 10, 2, 3, 8, 1, 10, 4 }, 5));
      Assert.AreEqual(247895375, Kata.MaxProduct(new int[] { 13, 12, -27, -302, 25, 37, 133, 155, -14 }, 5));
      Assert.AreEqual(4, Kata.MaxProduct(new int[] { -4, -27, -15, -6, -1 }, 2));
      Assert.AreEqual(136, Kata.MaxProduct(new int[] { -17, -8, -102, -309 }, 2));
      Assert.AreEqual(-30, Kata.MaxProduct(new int[] { 10, 3, -27, -1 }, 3));
      Assert.AreEqual(-253344, Kata.MaxProduct(new int[] { 14, 29, -28, 39, -16, -48 }, 4));
      Assert.AreEqual(1, Kata.MaxProduct(new int[] { 1 }, 1));
    }
    
    private int Sol(int[] arr, int size) => arr.OrderBy(x => x).Skip(arr.Length - size).Aggregate(1, (a, b) => a * b);
    
    [Test]
    public void RandomTests() {
      Random r = new Random();
      for (int i = 0; i < 100; i++) {
        int[] n = Enumerable.Range(0, r.Next(3, 11)).Select(_ => r.Next(-10, 11)).ToArray();
        int s = r.Next(1, n.Length + 1);
        Assert.AreEqual(Sol(n, s), Kata.MaxProduct(n, s));
      }
    }
  }
}
