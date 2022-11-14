/*Challenge link:https://www.codewars.com/kata/5ac6932b2f317b96980000ca/train/csharp
Question:
Task
Given a list of digits, return the smallest number that could be formed from these digits, using the digits only once (ignore duplicates).

Notes:
Only positive integers will be passed to the function (> 0 ), no negatives or zeros.
Input >> Output Examples
minValue ({1, 3, 1})  ==> return (13)
Explanation:
(13) is the minimum number could be formed from {1, 3, 1} , Without duplications

minValue({5, 7, 5, 9, 7})  ==> return (579)
Explanation:
(579) is the minimum number could be formed from {5, 7, 5, 9, 7} , Without duplications

minValue({1, 9, 3, 1, 7, 4, 6, 6, 7}) return  ==> (134679)
Explanation:
(134679) is the minimum number could be formed from {1, 9, 3, 1, 7, 4, 6, 6, 7} , Without duplications

Playing with Numbers Series
Playing With Lists/Arrays Series
Bizarre Sorting-katas
For More Enjoyable Katas
ALL translations are welcomed
Enjoy Learning !!
Zizou
*/

//***************Solution********************
//Solution 1
//find all distinct number, filter out the number below 0, order the numbers from small to large
//concatenate the numbers and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
class Kata{
    public static long MinValue(int[] a)=> 
      Convert.ToInt64(String.Concat(a.Distinct().Where(x => x > 0).OrderBy(x => x).ToArray()));
}

//solution 2
using System.Linq;

class Kata
{
  public static long MinValue(int[] a) => long.Parse(string.Concat(a.Distinct().OrderBy(x => x)));
}
//****************Sample Test*****************
namespace Solution
{
    using System;
    using NUnit.Framework;
    using System.Linq;
    using System.Collections.Generic;

    [TestFixture]
    public class Tests
    {
        [TestCase(13, 1, 3, 1)]
        [TestCase(457, 4, 7, 5, 7)]
        [TestCase(148, 4, 8, 1, 4)]
        [TestCase(579, 5, 7, 9, 5, 7)]
        [TestCase(678, 6, 7, 8, 7, 6, 6)]
        [TestCase(45679, 5, 6, 9, 9, 7, 6, 4)]
        [TestCase(134679, 1, 9, 1, 3, 7, 4, 6, 6, 7)]
        [TestCase(356789, 3, 6, 5, 5, 9, 8, 7, 6, 3, 5, 9)]
        public void BasicTests(long res, params int[] a)
        {
            Assert.That(Kata.MinValue(a), Is.EqualTo(res));
        }
        [Test]
        public void RandomTests()
        {
            for (int i = 0; i < 100; i++)
            {
                var a = CreateArray();
                var expected = MinValueSolution(a);
                var actual = Kata.MinValue(a);
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        private object MinValueSolution(int[] a) => Convert.ToInt64(string.Concat(a.OrderBy(x => x).Distinct()));

        private int[] CreateArray()
        {
            var rnd = new Random();
            var size = rnd.Next(2, 16);
            var l = new List<int>();
            for (int i = 0; i < size; i++)
                l.Add(rnd.Next(1, 10));
            return l.ToArray();
        }
    }
}
