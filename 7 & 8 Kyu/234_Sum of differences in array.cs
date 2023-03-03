/*Challenge link:https://www.codewars.com/kata/5b73fe9fb3d9776fbf00009e/train/csharp
Question:
Your task is to sum the differences between consecutive pairs in the array in descending order.

Example
[2, 1, 10]  -->  9
In descending order: [10, 2, 1]

Sum: (10 - 2) + (2 - 1) = 8 + 1 = 9

If the array is empty or the array has only one element the result should be 0 (Nothing in Haskell, None in Rust).
*/

//***************Solution********************
//check if length is more than 1
//if so, find the difference
//else return 0
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static int SumOfDifferences(int[] arr) => arr.Length > 1 ? arr.Max() - arr.Min(): 0;
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { }));
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { 0 }));
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { 1 }));
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { -1 }));
        Assert.AreEqual(34, Kata.SumOfDifferences(new int[] { -17, 17 }));
        Assert.AreEqual(9, Kata.SumOfDifferences(new int[] { 2, 1, 10 }));
        Assert.AreEqual(2, Kata.SumOfDifferences(new int[] { -3, -2, -1 }));
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { 1, 1, 1, 1, 1 }));
        Assert.AreEqual(0, Kata.SumOfDifferences(new int[] { 0, 0, 0, 0, 0 }));
        Assert.AreEqual(4, Kata.SumOfDifferences(new int[] { 1, 2, 3, 4, 5 }));
        Assert.AreEqual(29, Kata.SumOfDifferences(new int[] { 0, 29, 24, 17 }));
        Assert.AreEqual(50, Kata.SumOfDifferences(new int[] { 25, 24, -25, 2 }));
        Assert.AreEqual(22, Kata.SumOfDifferences(new int[] { -26, -4, -8, -8 }));
    }

    private static int Solution(int[] arr)
    {
        return arr.Length > 1 ? arr.Max() - arr.Min() : 0;
    }

    private static readonly Random Rand = new Random();

    private static int[] RandomArray()
    {
        return Enumerable.Range(0, Rand.Next(30)).Select(x => Rand.Next(-30, 30)).ToArray();
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var arr = RandomArray();
            var expected = Solution(arr);
            var message = FailureMessage(arr, expected);
            var actual = Kata.SumOfDifferences(arr);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(int[] arr, int value)
    {
        return $"Should return {value} with [{string.Join(", ", arr)}]";
    }
}
