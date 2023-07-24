/*Challenge link:https://www.codewars.com/kata/52b7ed099cdc285c300001cd/train/csharp
Question:
Write a function called sumIntervals/sum_intervals that accepts an array of intervals, and returns the sum of all the interval lengths. Overlapping intervals should only be counted once.

Intervals
Intervals are represented by a pair of integers in the form of an array. The first value of the interval will always be less than the second value. Interval example: [1, 5] is an interval from 1 to 5. The length of this interval is 4.

Overlapping Intervals
List containing overlapping intervals:

[
   [1, 4],
   [7, 10],
   [3, 5]
]
The sum of the lengths of these intervals is 7. Since [1, 4] and [3, 5] overlap, we can treat the interval as [1, 5], which has a length of 4.

Examples:
sumIntervals( [
   [1, 2],
   [6, 10],
   [11, 15]
] ) => 9

sumIntervals( [
   [1, 4],
   [7, 10],
   [3, 5]
] ) => 7

sumIntervals( [
   [1, 5],
   [10, 20],
   [1, 6],
   [16, 19],
   [5, 11]
] ) => 19

sumIntervals( [
   [0, 20],
   [-100000000, 10],
   [30, 40]
] ) => 100000030
Tests with large intervals
Your algorithm should be able to handle large intervals. All tested intervals are subsets of the range [-1000000000, 1000000000].
*/

//***************Solution********************

using System;
using System.Linq;

public class Intervals{
    public static int SumIntervals((int min, int max)[] intervals){
      /*check numbers
      Console.WriteLine(String.Join(",",intervals));
      Console.WriteLine(String.Join(",",intervals.OrderBy(x => x.min).ToArray()));
      */
      
      //Numbers can be negative, so get lowest possible as starting max.
      var prevMax = int.MinValue;
        
      //sort element by min
      //aggregate and accumulate
      //if previous max is less than next max
      //accumulate from negative current min + next max
      //else accumulate nothing.
        return intervals
            .OrderBy(x => x.min)
            .Aggregate(0, (acc, next) => acc += prevMax < next.max ? 
             - Math.Max(next.min, prevMax) + (prevMax = next.max) 
            : 0);
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

using In = System.ValueTuple<int, int>;

public class IntervalTest
{
    private In[] Shuffle(In[] a)
    {
        List<In> list = new List<In>(a);
        Shuffle(list);
        return list.ToArray();
    }

    private static void Shuffle<T>(List<T> deck)
    {
        var rnd = new Random();
        for (int n = deck.Count - 1; n > 0; --n)
        {
            int k = rnd.Next(n + 1);
            T temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
    }

    private int ShuffleAndSumIntervals(In[] arg)
    {
        return Intervals.SumIntervals(Shuffle(arg));
    }

    [Test]
    public void ShouldHandleEmptyIntervals()
    {
        Assert.AreEqual(0, Intervals.SumIntervals(new In[] { }));
        Assert.AreEqual(0, ShuffleAndSumIntervals(new In[] { (4, 4), (6, 6), (8, 8) }));
    }

    [Test]
    public void ShouldAddDisjoinedIntervals()
    {
        Assert.AreEqual(9, ShuffleAndSumIntervals(new In[] { (1, 2), (6, 10), (11, 15) }));
        Assert.AreEqual(11, ShuffleAndSumIntervals(new In[] { (4, 8), (9, 10), (15, 21) }));
        Assert.AreEqual(7, ShuffleAndSumIntervals(new In[] { (-1, 4), (-5, -3) }));
        Assert.AreEqual(78, ShuffleAndSumIntervals(new In[] { (-245, -218), (-194, -179), (-155, -119) }));
    }

    [Test]
    public void ShouldAddAdjacentIntervals()
    {
        Assert.AreEqual(54, ShuffleAndSumIntervals(new In[] { (1, 2), (2, 6), (6, 55) }));
        Assert.AreEqual(23, ShuffleAndSumIntervals(new In[] { (-2, -1), (-1, 0), (0, 21) }));
    }

    [Test]
    public void ShouldAddOverlappingIntervals()
    {
        Assert.AreEqual(7, ShuffleAndSumIntervals(new In[] { (1, 4), (7, 10), (3, 5) }));
        Assert.AreEqual(6, ShuffleAndSumIntervals(new In[] { (5, 8), (3, 6), (1, 2) }));
        Assert.AreEqual(19, ShuffleAndSumIntervals(new In[] { (1, 5), (10, 20), (1, 6), (16, 19), (5, 11) }));
    }

    [Test]
    public void ShouldHandleMixedIntervals()
    {
        Assert.AreEqual(13, ShuffleAndSumIntervals(new In[] { (2, 5), (-1, 2), (-40, -35), (6, 8) }));
        Assert.AreEqual(1234, ShuffleAndSumIntervals(new In[] { (-7, 8), (-2, 10), (5, 15), (2000, 3150), (-5400, -5338) }));
        Assert.AreEqual(158, ShuffleAndSumIntervals(new In[] { (-101, 24), (-35, 27), (27, 53), (-105, 20), (-36, 26) }));
    }
  
    [Test]
    public void ShouldHandleLargeIntervals()
    {
        Assert.AreEqual(2_000_000_000, Intervals.SumIntervals(new In[] { (-1_000_000_000, 1_000_000_000) }));
        Assert.AreEqual(100_000_030, Intervals.SumIntervals(new In[] { (0, 20), (-100_000_000, 10), (30, 40) }));
    }

    [Test]
    public void ShouldHandleSmallRandomIntervals()
    {
      RandomTests(1, 20, -500, 500, 1, 20);
    }

    [Test]
    public void ShouldHandleLargeRandomIntervals()
    {
      RandomTests(20, 200, -1_000_000_000, 1_000_000_000, 1_000_000, 10_000_000);
    }
  
    private void RandomTests(int minN, int maxN, int minX, int maxX, int minW, int maxW)
    {
        for (int i = 0; i < 100; i++)
        {
            var intervals = GenerateRandomSeq(minN, maxN, minX, maxX, minW, maxW);
            int expected = Expect(intervals);
            int actual = Intervals.SumIntervals(intervals);
            var msg = $"testing: {StringifyInterval(intervals)}";
            Assert.AreEqual(expected, actual, msg);
        }
    }

    private In[] GenerateRandomSeq(int minN, int maxN, int minX, int maxX, int minW, int maxW)
    {
        var rnd = new Random();
        int total = rnd.Next(minN, maxN + 1);
        var intervals = new In[total];
        for (int i = 0; i < total; i++)
        {
          int w = rnd.Next(minW, maxW + 1);
          int x = rnd.Next(minX, maxX - w + 1);
          intervals[i] = (x, x + w);
        }
        return intervals;
    }

    private string StringifyInterval(In[] i) => string.Join(", ", i.Select(x => $"[{string.Join(", ", x)}]"));

    private int Expect((int lo, int hi)[] intervals)
    {
        if (intervals == null) return 0;
        var sortedIntervals = intervals
                .Where(i => i.lo < i.hi)
                .OrderBy(i => i)
                .ToArray();
        if (sortedIntervals.Length == 0) return 0;
        var lastHi = sortedIntervals[0].lo;
        var sum = 0;
        foreach (var (lo, hi) in sortedIntervals)
        {
            if (hi <= lastHi)
                continue;
            sum += hi - (lo >= lastHi ? lo : lastHi);
            lastHi = hi;
        }
        return sum;
    }
}
