/*Challenge link:https://www.codewars.com/kata/5aa1bcda373c2eb596000112/train/csharp
Question:
Task
Given an array/list [] of n integers , find maximum triplet sum in the array Without duplications .

Notes :
Array/list size is at least 3 .

Array/list numbers could be a mixture of positives , negatives and zeros .

Repetition of numbers in the array/list could occur , So (duplications are not included when summing).

Input >> Output Examples
1- maxTriSum ({3,2,6,8,2,3}) ==> return (17)
Explanation:
As the triplet that maximize the sum {6,8,3} in order , their sum is (17)

Note : duplications are not included when summing , (i.e) the numbers added only once .

2- maxTriSum ({2,1,8,0,6,4,8,6,2,4}) ==> return (18)
Explanation:
As the triplet that maximize the sum {8, 6, 4} in order , their sum is (18) ,

Note : duplications are not included when summing , (i.e) the numbers added only once .

3- maxTriSum ({-7,12,-7,29,-5,0,-7,0,0,29}) ==> return (41)
Explanation:
As the triplet that maximize the sum {12 , 29 , 0} in order , their sum is (41) ,

Note : duplications are not included when summing , (i.e) the numbers added only once .


*/

//***************Solution********************
//select all distinct element in array a, order by descending, take the first 3 and find the sum.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

class Kata{
    public static int MaxTriSum(int[] a) => a.Distinct().OrderByDescending(x => x).Take(3).Sum();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [TestCase("-2 0 2", 0)]
    [TestCase("3 2 6 8 2 3", 17)]
    [TestCase("-2 -4 0 -9 2", 0)]
    [TestCase("-5 -1 -9 0 2", 1)]
    [TestCase("2 9 13 10 5 2 9 5", 32)]
    [TestCase("2 1 8 0 6 4 8 6 2 4", 18)]
    [TestCase("-3 -27 -4 -2 -27 -2", -9)]
    [TestCase("-7 12 -7 29 -5 0 -7 0 0 29", 41)]
    [TestCase("-14 -12 -7 -42 -809 -14 -12", -33)]
    [TestCase("-13 -50 57 13 67 -13 57 108 67", 232)]
    public void BasicTests(string s, int expected)
    {
        var a = s.Split().Select(int.Parse).ToArray();
        Assert.That(Kata.MaxTriSum(a), Is.EqualTo(expected));
    }
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 40; i++)
        {
            var a = new[] { 0 };
            var expected = MaxTriSumSolution(a);
            Assert.That(Kata.MaxTriSum(a), Is.EqualTo(expected));
        }
    }
    Random rnd = new Random();
    int R() => rnd.Next(-RandomNumForArray(), RandomNumForArray());
    int RandomNumForArray() => rnd.Next(1, (int)Math.Pow(10, rnd.Next(1, 6)));
    int MaxTriSumSolution(int[] a) => a.OrderByDescending(x => x).Distinct().Take(3).Sum();
    int[] CreateArray() => Enumerable.Range(0, rnd.Next(3, 201)).Select(x => R()).ToArray();
}
