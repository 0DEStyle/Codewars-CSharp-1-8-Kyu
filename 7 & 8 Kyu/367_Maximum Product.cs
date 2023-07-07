/*Challenge link:https://www.codewars.com/kata/5a4138acf28b82aa43000117/train/csharp
Question:
Task
Given an array of integers , Find the maximum product obtained from multiplying 2 adjacent numbers in the array.

Notes
Array/list size is at least 2.

Array/list numbers could be a mixture of positives, negatives also zeroes .

Input >> Output Examples
adjacentElementsProduct([1, 2, 3]); ==> return 6
Explanation:
The maximum product obtained from multiplying 2 * 3 = 6, and they're adjacent numbers in the array.
adjacentElementsProduct([9, 5, 10, 2, 24, -1, -48]); ==> return 50
Explanation:
Max product obtained from multiplying 5 * 10  =  50 .

adjacentElementsProduct([-23, 4, -5, 99, -27, 329, -2, 7, -921])  ==>  return -14
Explanation:
The maximum product obtained from multiplying -2 * 7 = -14, and they're adjacent numbers in the array.
*/

//***************Solution********************
//start from 0, up to end of array
//select from array, current element times next element
//get the max value from the results and return it.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata
{
    public static int AdjacentElementsProduct(int[] array)=>
      Enumerable.Range(0, array.Length - 1).Select((x, i) => array[i] * array[i+1]).Max();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using static System.Linq.Enumerable;
[TestFixture]
public class Tests
{
    [TestCase(40, 5, 8)]
    [TestCase(06, 1, 2, 3)]
    [TestCase(90, 1, 5, 10, 9)]
    [TestCase(06, 5, 1, 2, 3, 1, 4)]
    [TestCase(48, 4, 12, 3, 1, 5)]
    public void PositiveNumbers(int expexted, params int[] a)
    {
        Assert.That(Kata.AdjacentElementsProduct(a), Is.EqualTo(expexted));
    }
    [TestCase(21, 3, 6, -2, -5, 7, 3)]
    [TestCase(50, 9, 5, 10, 2, 24, -1, -48)]
    [TestCase(30, 5, 6, -4, 2, 3, 2, -23)]
    [TestCase(-14, -23, 4, -5, 99, -27, 329, -2, 7, -921)]
    public void MixedValues(int expexted, params int[] a)
    {
        Assert.That(Kata.AdjacentElementsProduct(a), Is.EqualTo(expexted));
    }
    [TestCase(0, 1, 0, 1, 0, 1000)]
    [TestCase(6, 1, 2, 3, 0)]
    public void ContainingZeroes(int expexted, params int[] a)
    {
        Assert.That(Kata.AdjacentElementsProduct(a), Is.EqualTo(expexted));
    }
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var array = CreateArray();
            var expected = SolutionAdjacentElementsProduct(array);
            Assert.That(Kata.AdjacentElementsProduct(array), Is.EqualTo(expected));
        }
    }
    static int SolutionAdjacentElementsProduct(int[] a) => Range(0, a.Length - 1).Select(x => a[x] * a[x + 1]).Max();
    static Random rnd = new Random();
    int[] CreateArray()
        => Range(0, rnd.Next(2, 200)).Select(x => rnd.Next(-100, 102)).ToArray();
}
