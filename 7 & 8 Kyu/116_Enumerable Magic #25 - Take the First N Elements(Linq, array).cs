/*Challenge link:https://www.codewars.com/kata/545afd0761aa4c3055001386/train/csharp
Question:
Create a function that accepts a list/array and a number n, and returns a list/array of the first n elements from the list/array.

If you need help, here is a reference:

https://docs.microsoft.com/en-us/dotnet/api/system.array?view=netcore-3.1
*/

//***************Solution********************
//take the first n number of elements from the array and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
    public static int[] Take(int[] arr, int n) => arr.Take(n).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void BasicTest()
    {
        Assert.AreEqual(new int[] { 0, 1, 2 }, Kata.Take(new int[] { 0, 1, 2, 3, 5, 8, 13 }, 3));
        Assert.AreEqual(new int[] { }, Kata.Take(new int[] { 0, 1, 2, 3, 5, 8, 13 }, 0));
        Assert.AreEqual(new int[] { }, Kata.Take(new int[] { }, 3));
    }

    private static readonly Random Rand = new Random();

    private static int[] Solution(int[] arr, int n)
    {
        return arr.Take(n).ToArray();
    }

    private static int[] RandomArray()
    {
        return Enumerable.Range(0, Rand.Next(15)).Select(x => Rand.Next(0, 100)).ToArray();
    }

    [Test]
    public void RandomTests()
    {
        for (var i = 0; i < 300; i++)
        {
            var randomArray = RandomArray();
            var n = Rand.Next(0, 20);
            var expected = Solution(randomArray, n);
            var message = FailureMessage(randomArray, expected, n);
            var actual = Kata.Take(randomArray, n);
            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(int[] arr, int[] value, int n)
    {
        return $"Should return [{string.Join(", ", value)}] with [{string.Join(", ", arr)}] and take {n}";
    }
}
