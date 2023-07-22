/*Challenge link:https://www.codewars.com/kata/51ba717bb08c1cd60f00002f/train/csharp
Question:
A format for expressing an ordered list of integers is to use a comma separated list of either

individual integers
or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'. The range includes all integers in the interval including both endpoints. It is not considered a range unless it spans at least 3 numbers. For example "12,13,15-17"
Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.

Example:

solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
// returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"

*/

//***************Solution********************
//one line using Linq
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class RangeExtraction{
    public static string Extract(int[] input) =>
      //join string with ","
      //select smaller value between input.Length-1 and index+1, to keep elements at order for either 3 numbers with a dash or 1
      //if the input value from above subtract by current element is not 1, meaning it skipped a number
      //use the first number as sequence number if true
      //else return first number
      
      //group current element by Tuple (using Item1, Item2 or Item3)
      //if element x count is 1
      //return x.ElementAt(0), one digit
      //else return number followed by dash then another number.
      string.Join(",", input
            .Select((current, index) => 
             (current, input[Math.Min(input.Length-1, index+1)] - current != 1 ? input[0]++ : input[0]))
            .GroupBy(x => x.Item2, x => x.Item1)
            .Select(x => x.Count() == 1
            ? $"{x.ElementAt(0)}" : $"{x.Min()}{(x.Count() > 2 ? "-" : ",")}{x.Max()}")
        );
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodewarsTests
{
    [TestFixture]
    public class RangeExtractorTest
    {
        [Test(Description = "Simple tests")]
        public void SimpleTests()
        {
            Assert.AreEqual("1,2", RangeExtraction.Extract(new[] { 1, 2 }));
            Assert.AreEqual("1-3", RangeExtraction.Extract(new[] { 1, 2, 3 }));

            Assert.AreEqual(
                "-6,-3-1,3-5,7-11,14,15,17-20",
                RangeExtraction.Extract(new[] { -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 })
            );

            Assert.AreEqual(
                "-3--1,2,10,15,16,18-20",
                RangeExtraction.Extract(new[] { -3, -2, -1, 2, 10, 15, 16, 18, 19, 20 })
            );
        }

        [Test(Description = "Random tests")]
        public void RandomTests()
        {
            for( int i = 0; i < 30; i++ )
            {
                var data = GetRandomArray();
                Assert.AreEqual(Solver(data), RangeExtraction.Extract(data));
            }
        }

        private Random _random = new Random();

        private int[] GetRandomArray()
        {
            var y = _random.Next(-200, -100);
            var res = new List<int>();
            var count = _random.Next(50, 200);
            for( int i = 0; i < count; i++ )
            {
                res.Add(y);
                y += _random.Next(1, 3);
            }
            return res.ToArray();
        }

        private static string Solver(int[] args)
        {
            const int MIN_RANGE = 3;
            var res = new List<string>(args.Length);
            var nums = new List<int>();
            Action flush = () => {
                if( nums.Count >= MIN_RANGE )
                    res.Add(String.Format("{0}-{1}", nums[0], nums[nums.Count - 1]));
                else
                    res.Add(String.Join(",", nums));
                nums.Clear();
            };

            foreach( var x in args )
            {
                if( nums.Count == 0 || x == nums[nums.Count - 1] + 1 ) nums.Add(x);
                else
                {
                    flush();
                    nums.Add(x);
                }
            }
            flush();

            return String.Join(",", res);
        }

    }
}
