/*Challenge link:https://www.codewars.com/kata/5a512f6a80eba857280000fc/train/csharp
Question:
Introduction and warm-up (highly recommended): Playing With Lists/Arrays Series

Task
Given an array/list of integers, find the Nth smallest element in the array.

Notes
Array/list size is at least 3.
Array/list's numbers could be a mixture of positives , negatives and zeros.
Repetition in array/list's numbers could occur, so don't remove duplications.
Input >> Output Examples
arr=[3,1,2]            n=2    ==> return 2 
arr=[15,20,7,10,4,3]   n=3    ==> return 7 
arr=[2,169,13,-5,0,-1] n=4    ==> return 2 
arr=[2,1,3,3,1,2],     n=3    ==> return 2 
Playing with Numbers Series
Playing With Lists/Arrays Series
More Enjoyable Katas

Enjoy Learning !!
*/

//***************Solution********************
//sort the array from low to high, get element at index of n-1
//return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
class Kata{
    public static int NthSmallest(int[] arr, int n) => arr.OrderBy(x=>x).ElementAt(n-1);
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase(02, 2, 3, 1, 2)]
    [TestCase(07, 3, 15, 20, 7, 10, 4, 3)]
    [TestCase(-1, 4, -5, -1, -6, -18)]
    [TestCase(-2, 5, -102, -16, -1, -2, -367, -9)]
    [TestCase(02, 4, 2, 169, 13, -5, 0, -1)]
    public void BasicTests(int expected, int pos, params int[] a)
    {
        Assert.That(Kata.NthSmallest(a, pos), Is.EqualTo(expected));
    }
    static Random rnd = new Random();
    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; i++)
        {
            var a = CreateArray();
            var pos = rnd.Next(1, a.Length + 1);
            var expected = SolutionNthSmallest(a, pos);
            Assert.That(Kata.NthSmallest(a, pos), Is.EqualTo(expected));
        }
    }
    int[] CreateArray() => Enumerable.Range(3, rnd.Next(3, 41)).Select(x => rnd.Next(-1000, 1000)).ToArray();
    int SolutionNthSmallest(int[] arr, int pos) => arr.OrderBy(x => x).ToArray()[pos - 1];
}
