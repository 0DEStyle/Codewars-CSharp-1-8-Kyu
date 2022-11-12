/*Challenge link:https://www.codewars.com/kata/586f6741c66d18c22800010a/train/csharp
Question:
Your task is to make function, which returns the sum of a sequence of integers.

The sequence is defined by 3 non-negative values: begin, end, step (inclusive).

If begin value is greater than the end, function should returns 0

Examples

2,2,2 --> 2
2,6,2 --> 12 (2 + 4 + 6)
1,5,1 --> 15 (1 + 2 + 3 + 4 + 5)
1,5,3  --> 5 (1 + 4)
This is the first kata in the series:

Sum of a sequence (this kata)
Sum of a Sequence [Hard-Core Version]
*/

//***************Solution********************

//solution 1
// apply algorithm
using System;
public static class Kata
{
  public static int SequenceSum(int start, int end, int step){
    int ans = 0;
    
    if (start == end) return start;
    
    while(start + step <= end){
      if(ans == 0) ans = start;
      ans += start + step;
      start += step;
    }
    
    return ans;
    
  }
}

//solution 2
//recursion
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public static class Kata
{
  public static int SequenceSum(int start, int end, int step)
  {
    return start == end ? end : start > end ? 0 : SequenceSum(start + step, end, step) + start;
  }
}

//solution 3

//using Linq enumerable.repeat
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata
{
    public static int SequenceSum(int start, int end, int step) =>
         start > end ? 0 : Enumerable.Repeat(start, (end - start) / step + 1).Select((x, index) => x + step * index).Sum();
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(12, Kata.SequenceSum(2, 6, 2));
            Assert.AreEqual(15, Kata.SequenceSum(1, 5, 1));
            Assert.AreEqual(5, Kata.SequenceSum(1, 5, 3));
            Assert.AreEqual(45, Kata.SequenceSum(0, 15, 3));
            Assert.AreEqual(0, Kata.SequenceSum(16, 15, 3));
            Assert.AreEqual(26, Kata.SequenceSum(2, 24, 22));
            Assert.AreEqual(2, Kata.SequenceSum(2, 2, 2));
            Assert.AreEqual(2, Kata.SequenceSum(2, 2, 1));
            Assert.AreEqual(35, Kata.SequenceSum(1, 15, 3));
            Assert.AreEqual(0, Kata.SequenceSum(15, 1, 3));
        }

        [Test]
        public void RandomTests()
        {
            Random rand = new Random();

            for (int i = 1; i <= 100; i++)
            {
                int start = rand.Next(500 * i);
                int end = rand.Next(1000 * i);
                int step = rand.Next(1,10 * i);
                var expected = MyCode(start,end,step);
                var actual = Kata.SequenceSum(start,end,step);
                Assert.AreEqual(expected, actual);
                Console.WriteLine($"{start} .. {end} |{step}| = {actual}");
            }
        }

        private int MyCode(int start, int end, int step) => (start > end ? 0 : ((end -= (end - start) % step) + start) * (1 + (end - start) / step) / 2);
    }
}
