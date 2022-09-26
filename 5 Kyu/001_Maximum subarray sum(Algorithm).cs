/*Challenge link:https://www.codewars.com/kata/54521e9ec8e60bc4de000d6c/train/csharp
Question:
The maximum sum subarray problem consists in finding the maximum sum of a contiguous subsequence in an array or list of integers:

maxSequence [-2, 1, -3, 4, -1, 2, 1, -5, 4]
-- should be 6: [4, -1, 2, 1]
Easy case is when the list is made up of only positive numbers and the maximum sum is the sum of the whole array. If the list is made up of only negative numbers, return 0 instead.

Empty list is considered to have zero greatest sum. Note that the empty list or array is also a valid sublist/subarray.
*/

//***************Solution********************
//Maximum subarray sum, two nested loop method
//ref https://www.enjoyalgorithms.com/blog/maximum-subarray-sum

public static class Kata
{
  public static int MaxSequence(int[] arr) 
  { 
    int temp = 0, maxTemp = 0, n = arr.Length;
    
    for (int i = 0; i < n; i++){
      temp = 0;
      for(int j = i; j < n; j++){
        temp = temp + arr[j];
          if(temp > maxTemp)
              maxTemp = temp;
      }
    }
    return maxTemp;
  }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        public static Random randNum = new Random();
        public static int MaxSequence(int[] arr)
        {
            int m = 0;
            int a = 0;
            int s = 0;
            foreach (int e in arr)
            {
                s += e;
                m = s > m ? m : s;
                a = a > s - m ? a : s - m;
            }
            return a;
        }
        [Test]
        public void Test0()
        {
            Assert.AreEqual(0, Kata.MaxSequence(new int[0]));
        }
        [Test]
        public void Test1()
        {
            Assert.AreEqual(6, Kata.MaxSequence(new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 }));
        }
        [Test]
        public void Test2()
        {
            Assert.AreEqual(155, Kata.MaxSequence(new int[] { 7, 4, 11, -11, 39, 36, 10, -6, 37, -10, -32, 44, -26, -34, 43, 43 }));
        }
        private int[] GetRandomArray()
        {
            var arr = new int[50];
            for (int i = 0; i < 50; i++)
            {
                arr[i] = randNum.Next(-40, 40);
            }
            return arr;
        }
        [Test]
        public void RandomTests()
        {

            for (int i = 0; i < 50; ++i)
            {
                var arr = GetRandomArray();
                Assert.AreEqual(MaxSequence(arr), Kata.MaxSequence(arr));
            }
        }
    }
}
