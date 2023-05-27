/*Challenge link:https://www.codewars.com/kata/5abd66a5ccfd1130b30000a9/train/csharp
Question:
Scenario
Several people are standing in a row divided into two teams.
The first person goes into team 1, the second goes into team 2, the third goes into team 1, and so on.

Task
Given an array of positive integers (the weights of the people), return a new array/tuple of two integers, where the first one is the total weight of team 1, and the second one is the total weight of team 2.

Notes
Array size is at least 1.
All numbers will be positive.
Input >> Output Examples
rowWeights([13, 27, 49])  ==>  return (62, 27)
Explanation:
The first element 62 is the total weight of team 1, and the second element 27 is the total weight of team 2.

rowWeights([50, 60, 70, 80])  ==>  return (120, 140)
Explanation:
The first element 120 is the total weight of team 1, and the second element 140 is the total weight of team 2.

rowWeights([80])  ==>  return (80, 0)
Explanation:
The first element 80 is the total weight of team 1, and the second element 0 is the total weight of team 2.


*/

//***************Solution********************
//form a new array, where 1st element stores and sum all even numbers in array a,
//2nd element store and sum all odd numbers in the array a.
//return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
class Kata{
    public static int[] RowWeights(int[] a) => new[] {a.Where((x, i) => i % 2 == 0).Sum(), a.Where((x, i) => i % 2 == 1).Sum()};
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase("0", "0 0")]
    [TestCase("80", "80 0")]
    [TestCase("0 1 0", "0 1")]
    [TestCase("100 50", "100 50")]
    [TestCase("13 27 49", "62 27")]
    [TestCase("50 60 70 80", "120 140")]
    [TestCase("70 58 75 34 91", "236 92")]
    [TestCase("100 51 50 100", "150 151")]
    [TestCase("29 83 67 53 19 28 96", "211 164")]
    [TestCase("39 84 74 18 59 72 35 61", "207 235")]
    public void BasicTests(string s, string ex)
    {
        var a = s.Split().Select(int.Parse).ToArray();
        var expected = ex.Split().Select(int.Parse).ToArray();
        Assert.That(Kata.RowWeights(a), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 40; i++)
        {
            var a = new[] { 0 };
            var expected = RowWeightsSolution(a);
            Assert.That(Kata.RowWeights(a), Is.EqualTo(expected));
        }
    }
    Random rnd = new Random();
    int R() => rnd.Next(1, (int)Math.Pow(10, rnd.Next(1, 4)));
    int SumUp(int[] array, int n) => array.Where((x, i) => i % 2 == n).Sum();
    int[] RowWeightsSolution(int[] array) => new[] { SumUp(array, 0), SumUp(array, 1) };
    int[] CreateArray() => Enumerable.Range(0, rnd.Next(1, 36)).Select(x => R()).ToArray();
}
