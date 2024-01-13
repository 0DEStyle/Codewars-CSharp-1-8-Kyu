/*Challenge link:https://www.codewars.com/kata/57cc847e58a06b1492000264/train/csharp
Question:
Given an array of numbers, return a string made up of four parts:

a four character 'word', made up of the characters derived from the first two and last two numbers in the array. order should be as read left to right (first, second, second last, last),

the same as above, post sorting the array into ascending order,

the same as above, post sorting the array into descending order,

the same as above, post converting the array into ASCII characters and sorting alphabetically.

The four parts should form a single string, each part separated by a hyphen (-).

Example format of solution: "asdf-tyui-ujng-wedg"

Examples
[111, 112, 113, 114, 115, 113, 114, 110]  -->  "oprn-nors-sron-nors"
[66, 101, 55, 111, 113]                   -->  "Beoq-7Boq-qoB7-7Boq"
[99, 98, 97, 96, 81, 82, 82]              -->  "cbRR-QRbc-cbRQ-QRbc"
*/

//***************Solution********************
/*
ASCII convertor: https://www.duplichecker.com/ascii-to-text.php

Original array
[111, 112, 113, 114, 115, 113, 114, 110] 
 ^     ^                        ^    ^
from the first two and last two numbers in the array.
so [111, 112, 114 , 110]

then sorting the array into ascending order and do the same
[110, 111, 112, 113, 113, 114, 114, 115] 
 ^     ^                        ^    ^
Then repeat until the end

oprn = 111 112 114 110
nors = 110 111 114 115
sron = 115 114 111 110
nors = 110 111 114 115
*/

using System;
using System.Linq;

class Kata{
    public static string SortTransform(int[] arr){
      //convert to char, remove start from 2, upto arr length - 4, then concat the elements
      string s1 = string.Concat(arr.Select(x => (char)x)).Remove(2, arr.Length - 4);
      
      //Order the element first then convert to char, remove start from 2, upto arr length -4, then concat the elements
      string s2 = string.Concat(arr.OrderBy(x => x).Select(x => (char)x)).Remove(2, arr.Length - 4);
      
      //since s3 is the reverse of s2
      string s3 = string.Concat(s2.Reverse());
      
      //string interpolation for formatting.
      return $"{s1}-{s2}-{s3}-{s2}";
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
class Test
{
    [Test]
    [TestCase(new[] { 121, 122, 123, 124, 125, 120, 122, 132 }, "yzz-xy}-}yx-xy}")]
    [TestCase(new[] { 111, 112, 113, 114, 115, 113, 114, 110 }, "oprn-nors-sron-nors")]
    [TestCase(new[] { 51, 62, 73, 84, 95, 100, 99, 126 }, "3>c~-3>d~-~d>3-3>d~")]
    [TestCase(new[] { 66, 101, 55, 111, 113 }, "Beoq-7Boq-qoB7-7Boq")]
    [TestCase(new[] { 78, 117, 110, 99, 104, 117, 107, 115, 120, 121, 125 }, "Nuy}-Ncy}-}ycN-Ncy}")]
    [TestCase(new[] { 101, 48, 75, 105, 99, 107, 121, 122, 124 }, "e0z|-0Kz|-|zK0-0Kz|")]
    [TestCase(new[] { 80, 117, 115, 104, 65, 85, 112, 115, 66, 76, 62 }, "PuL>->Asu-usA>->Asu")]
    [TestCase(new[] { 91, 100, 111, 121, 51, 62, 81, 92, 63 }, "[d\\?-3>oy-yo>3-3>oy")]
    [TestCase(new[] { 78, 93, 92, 98, 108, 119, 116, 100, 85, 80 }, "N]UP-NPtw-wtPN-NPtw")]
    [TestCase(new[] { 111, 121, 122, 124, 125, 126, 117, 118, 119, 121, 122, 73 }, "oyzI-Io}~-~}oI-Io}~")]
    [TestCase(new[] { 82, 98, 72, 71, 71, 72, 62, 67, 68, 115, 117, 112, 122, 121, 93 }, "Rby]->Cyz-zyC>->Cyz")]
    [TestCase(new[] { 99, 98, 97, 96, 81, 82, 82 }, "cbRR-QRbc-cbRQ-QRbc")]
    [TestCase(new[] { 66, 99, 88, 122, 123, 110 }, "Bc{n-BXz{-{zXB-BXz{")]
    [TestCase(new[] { 66, 87, 98, 59, 57, 50, 51, 52 }, "BW34-23Wb-bW32-23Wb")]
    public void BasicTest(int[] arr, string expected)
    {
        Assert.That(Kata.SortTransform(arr), Is.EqualTo(expected));
    }
    string SortTransformSolution(int[] arr)
    {
        var two = Skipper(arr.OrderBy(x => x));
        var three = Skipper(arr.OrderByDescending(x => x));
        var four = Skipper(arr.Select(x => (char)x).OrderBy(x => x));
        return $"{Skipper(arr)}-{two}-{three}-{four}";
    }
    string Skipper(IEnumerable<int> a) => string.Concat(a.Take(2).Concat(a.Skip(a.Count() - 2).Take(2)).Select(x => (char)x));
    string Skipper(IEnumerable<char> a) => string.Concat(a.Take(2).Concat(a.Skip(a.Count() - 2).Take(2)));

    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var arr = CreateArray();
            var expected = SortTransformSolution(arr);
            Assert.That(Kata.SortTransform(arr), Is.EqualTo(expected));
        }
    }
    Random rnd = new Random();
    int[] CreateArray() => Enumerable.Range(33, rnd.Next(4, 94)).Select(_ => rnd.Next(33, 127)).ToArray();
}
