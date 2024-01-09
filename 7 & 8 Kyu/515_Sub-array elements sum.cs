/*Challenge link:https://www.codewars.com/kata/5b5e0ef007a26632c400002a/train/csharp
Question:
Given an array (or list or vector) of arrays (or, guess what, lists or vectors) of integers, your goal is to return the sum of a specific set of numbers, starting with elements whose position is equal to the main array length and going down by one at each step.

Say for example the parent array (etc, etc) has 3 sub-arrays inside: you should consider the third element of the first sub-array, the second of the second array and the first element in the third one: [[3, 2, 1, 0], [4, 6, 5, 3, 2], [9, 8, 7, 4]] would have you considering 1 for [3, 2, 1, 0], 6 for [4, 6, 5, 3, 2] and 9 for [9, 8, 7, 4], which sums up to 16.

One small note is that not always each sub-array will have enough elements, in which case you should then use a default value (if provided) or 0 (if not provided), as shown in the test cases.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//x is the current element, i is the index
//if current element length is less than arr length - i, return x[arr.Length - i - 1], else use default value
//then sum the result.
using System.Linq;

class Kata{
    public static int ElementsSum(int[][] arr, int d = 0) => 
      arr.Select((x, i) => x.Length >= arr.Length - i ? x[arr.Length - i - 1] : d)
         .Sum();
}

//solution 2
using System.Linq;

class Kata
{
  public static int ElementsSum(int[][] arr, int d = 0)
  {
    return arr.Reverse().Select((x, i) => x.Length > i ? x[i] : d).Sum();
  }
}

//****************Sample Test*****************
//the test case from javascript
using NUnit.Framework;
using System;
using System.Linq;
class SolutionTest
{
    [Test]
    public void FixedTest()
    {
        Assert.AreEqual(16, Kata.ElementsSum(new[] { new[] { 3, 2, 1, 0 }, new[] { 4, 6, 5, 3, 2 }, new[] { 9, 8, 7, 4 } }));
        Assert.AreEqual(15, Kata.ElementsSum(new[] { new[] { 3 }, new[] { 4, 6, 5, 3, 2 }, new[] { 9, 8, 7, 4 } }));
        Assert.AreEqual(7, Kata.ElementsSum(new[] { new[] { 3, 2, 1, 0 }, new[] { 4, 6, 5, 3, 2 }, new int[0] }));
        Assert.AreEqual(12, Kata.ElementsSum(new[] { new[] { 3, 2, 1, 0 }, new[] { 4, 6, 5, 3, 2 }, new int[0] }, 5));
        Assert.AreEqual(0, Kata.ElementsSum(new[] { new[] { 3, 2 }, new[] { 4 }, new int[0] }));
    }

    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 200; i++)
        {
            var arr = MakeArr();
            if (random.NextDouble() < 0.7)
            {
                var d = random.Next(-10, 10);
                var expected = ElementsSum(arr, d);
                var actual = Kata.ElementsSum(arr, d);
                Assert.AreEqual(expected, actual);
            }
            else
            {
                var expected = ElementsSum(arr);
                var actual = Kata.ElementsSum(arr);
                Assert.AreEqual(expected, actual);
            }
        }
    }

    private Random random = new Random();

    private static int ElementsSum(int[][] arr, int d = 0) => arr.Select((x, i) => x.Length >= arr.Length - i ? x[arr.Length - i - 1] : d).Sum();
    private int[][] MakeArr()
    {
        var len = random.Next(1, 40);
        var arr = new int[len][];
        for (int i = 0; i < len; i++)
        {
            var l = random.Next(1, 40);
            arr[i] = new int[l];
            for (int j = 0; j < l; j++)
            {
                arr[i][j] = random.Next(-(int)Math.Pow(10, random.Next(3)), (int)Math.Pow(10, random.Next(3)));
            }
        }
        return arr;
    }
}
