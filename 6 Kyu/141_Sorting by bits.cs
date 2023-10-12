/*Challenge link:https://www.codewars.com/kata/59fa8e2646d8433ee200003f/train/csharp
Question:
In this kata you're expected to sort an array of 32-bit integers in ascending order of the number of on bits they have.

E.g Given the array [7, 6, 15, 8]

7 has 3 on bits (000...0111)
6 has 2 on bits (000...0110)
15 has 4 on bits (000...1111)
8 has 1 on bit (000...1000)
So the array in sorted order would be [8, 6, 7, 15].

In cases where two numbers have the same number of bits, compare their real values instead.

E.g between 10 (...1010) and 12 (...1100), they both have the same number of on bits '2' but the integer 10 is less than 12 so it comes first in sorted order.

Your task is to write a function that takes an array of integers and sort them as described above.

Note: your solution has to sort the array in place.

Example:

[3, 8, 3, 6, 5, 7, 9, 1]   =>    [1, 8, 3, 3, 5, 6, 9, 7]
*/

//***************Solution********************

//x is the current element, convert x to string binary, count if the character is '1'
//then order by ascending order, convert to array.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

class Kata{
    public static int[] SortByBit(int[] array) => 
      array.OrderBy(x => Convert.ToString(x, 2).Count(c => c == '1'))
           .ThenBy(x => x).ToArray();    
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
class Tests
{
    [Test]
    [TestCase(new[] { 3, 8, 3, 6, 5, 7, 9, 1 }, new[] { 1, 8, 3, 3, 5, 6, 9, 7 })]
    [TestCase(new[] { 9, 4, 5, 3, 5, 7, 2, 56, 8, 2, 6, 8, 0 }, new[] { 0, 2, 2, 4, 8, 8, 3, 5, 5, 6, 9, 7, 56 })]
    public void BasicTests(int[] input, int[] expected)
    {
        Assert.That(Kata.SortByBit(input), Is.EqualTo(expected));
    }

    Random rnd = new Random();
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var input = CreateArray();
            var expected = SolutionSortByBit(input);
            Assert.That(Kata.SortByBit(input), Is.EqualTo(expected));
        }
    }
    int[] CreateArray() => Enumerable.Range(0, rnd.Next(5, 30)).Select(_ => rnd.Next(1, 101)).ToArray();
    int[] SolutionSortByBit(int[] a) => a.OrderBy(x => Convert.ToString(x, 2).Count(y => y == '1')).ThenBy(x => x).ToArray();

}
