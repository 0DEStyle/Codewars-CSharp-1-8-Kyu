/*Challenge link:https://www.codewars.com/kata/5cd5ba1ce4471a00256930c0/train/csharp
Question:Your job is to implement a function which returns the last D digits of an integer N as a list.

Special cases:
If D > (the number of digits of N), return all the digits.
If D <= 0, return an empty list.
Examples:
N = 1
D = 1
result = [1]

N = 1234
D = 2
result = [3, 4]

N = 637547
D = 6
result = [6, 3, 7, 5, 4, 7]
*/

//***************Solution********************
//turn number into string and split the character, 
//(int)x = '0' avoid the result turn into ASCII value
//take the last d amount of items and store in array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
    public static int[] LastDigit(long n, int d) => $"{n}".Select(x=>  (int)x - '0').TakeLast(d).ToArray();
}

//better method
using System.Linq;

public static class Kata
{
  public static int[] LastDigit(long n, int d)
  {
    return $"{n}".TakeLast(d).Select(c => c - '0').ToArray();
  }
}
//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void SampleTest()
    {
        Assert.AreEqual(new[] { 1 }, Kata.LastDigit(1, 1));
        Assert.AreEqual(new[] { 3, 7, 6, 7 }, Kata.LastDigit(123767, 4));
        Assert.AreEqual(new[] { 0 }, Kata.LastDigit(0, 1));
        Assert.AreEqual(new[] { 5, 6, 4, 7, 8, 6, 7, 5, 8, 5 }, Kata.LastDigit(34625647867585, 10));
        Assert.AreEqual(new int[] { }, Kata.LastDigit(1234, 0));
        Assert.AreEqual(new int[] { }, Kata.LastDigit(24134, -4));
        Assert.AreEqual(new[] { 1, 3, 4, 3 }, Kata.LastDigit(1343, 5));
    }

    private static int[] Solution(long n, int d)
    {
        return d < 1 ? new int[] { } : n.ToString().TakeLast(d).Select(x => int.Parse(x.ToString())).ToArray();
    }

    private static readonly Random Rand = new Random();

    private static long LongRandom(long min, long max, Random rand)
    {
        long result = rand.Next((int)(min >> 32), (int)(max >> 32));
        result <<= 32;
        result |= (uint)rand.Next((int)min, (int)max);
        return result;
    }

    [Test]
    public void RandomTest()
    {
        for (var i = 0; i < 300; i++)
        {
            var n = LongRandom(1, 10000000000, Rand);
            var d = Rand.Next(-10, 10);
            var expected = Solution(n, d);
            var message = FailureMessage(n, d, expected);
            var actual = Kata.LastDigit(n, d);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static string FailureMessage(long n, int d, int[] value)
    {
        return $"Should return [{string.Join(", ", value)}] with n={n} and d={d}";
    }
}
