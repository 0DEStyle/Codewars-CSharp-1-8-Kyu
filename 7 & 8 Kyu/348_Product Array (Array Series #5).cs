/*Challenge link:https://www.codewars.com/kata/5a905c2157c562994900009d/train/csharp
Question:
Introduction and Warm-up (Highly recommended)
Playing With Lists/Arrays Series
Task
Given an array/list [] of integers , Construct a product array Of same size Such That prod[i] is equal to The Product of all the elements of Arr[] except Arr[i].

Notes
Array/list size is at least 2 .

Array/list's numbers Will be only Positives

Repetition of numbers in the array/list could occur.

Input >> Output Examples
productArray ({12,20}) ==>  return {20,12}
Explanation:
The first element in prod [] array 20 is the product of all array's elements except the first element

The second element 12 is the product of all array's elements except the second element .

productArray ({1,5,2}) ==> return {10,2,5}
Explanation:
The first element 10 is the product of all array's elements except the first element 1

The second element 2 is the product of all array's elements except the second element 5

The Third element 5 is the product of all array's elements except the Third element 2.

productArray ({10,3,5,6,2}) return ==> {180,600,360,300,900}
Explanation:
The first element 180 is the product of all array's elements except the first element 10

The second element 600 is the product of all array's elements except the second element 3

The Third element 360 is the product of all array's elements except the third element 5

The Fourth element 300 is the product of all array's elements except the fourth element 6

Finally ,The Fifth element 900 is the product of all array's elements except the fifth element 2
*/

//***************Solution********************
//for each element i in array
//aggregate a(the current element ) * b(next element) / i(excluding the index itself)
//store the result in array and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

class Kata{
    public static int[] ProductArray(int[] array)=> array.Select(i => array.Aggregate((a, b) => a * b) / i).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
class Tests
{
    [TestCase("12 20", "20 12")]
    [TestCase("3 27 4 2", "216 24 162 324")]
    [TestCase("13 10 5 2 9", "900 1170 2340 5850 1300")]
    [TestCase("16 17 4 3 5 2", "2040 1920 8160 10880 6528 16320")]
    public void BasicTest(string s, string str)
    {
        Assert.That(Kata.ProductArray(Foo(s)), Is.EqualTo(Foo(str)));
    }
    int[] Foo(string s) => s.Split().Select(int.Parse).ToArray();
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 40; i++)
        {
            var array = CreateArray();
            var expected = ProductArraySolution(array);
            Assert.That(Kata.ProductArray(array), Is.EqualTo(expected));
        }
    }

    int[] CreateArray()
    {
        var rnd = new Random();
        var length = rnd.Next(3, 8);
        var list = new List<int>();
        for (int i = 0; i < length; i++)
            list.Add(rnd.Next(1, 15));
        return list.ToArray();
    }
    int[] ProductArraySolution(int[] array) => array.Select(x => array.Aggregate((a, b) => a * b) / x).ToArray();
}
