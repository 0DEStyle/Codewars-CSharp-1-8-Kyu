/*Challenge link:https://www.codewars.com/kata/58b16300a470d47498000811/train/csharp
Question:
In this Kata we focus on finding a sum S(n) which is the total number of divisors taken for all natural numbers less or equal to n. More formally, we investigate the sum of n components denoted by d(1) + d(2) + ... + d(n) in which for any i starting from 1 up to n the value of d(i) tells us how many distinct numbers divide i without a remainder.

Your solution should work for possibly large values of n without a timeout. Assume n to be greater than zero and not greater than 999 999 999 999 999. Brute force approaches will not be feasible options in such cases. It is fairly simple to conclude that for every n>1 there holds a recurrence S(n) = S(n-1) + d(n) with initial case S(1) = 1.

For example:
S(1) = 1
S(2) = 3
S(3) = 5
S(4) = 8
S(5) = 10

But is the fact useful anyway? If you find it is rather not, maybe this will help:

Try to convince yourself that for any natural k, the number S(k) is the same as the number of pairs (m,n) that solve the inequality mn <= k in natural numbers. Once it becomes clear, we can think of a partition of all the solutions into classes just by saying that a pair (m,n) belongs to the class indexed by n. The question now arises if it is possible to count solutions of n-th class. If f(n) stands for the number of solutions that belong to n-th class, it means that S(k) = f(1) + f(2) + f(3) + ...

The reasoning presented above leads us to some kind of a formula for S(k), however not necessarily the most efficient one. Can you imagine that all the solutions to inequality mn <= k can be split using sqrt(k) as pivotal item?


*/

//***************Solution********************
//apply formula
public class DivisorsCounter{
   public static long CountDivisors(long n){
     long res = 2 * n - 1; 
     for (long i = 2 ; i * i <= n ; i++) res += 2 * ((n/i) - i) + 1;
     return res;
   }
}

//method 2
using System;
using System.Linq;

public class DivisorsCounter
{
    public static long CountDivisors(long n)
    {
        int r = (int)Math.Sqrt(n);
        return Enumerable.Range(1, r).Sum(i => (long)(n / i * 2)) - (long)r * r;
    }
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class DivisorsCounterTest
{

    [Test]
    public void TestSmallNumbers()
    {
        var counted1 = DivisorsCounter.CountDivisors(5);
        Assert.AreEqual(10, counted1);

        var counted2 = DivisorsCounter.CountDivisors(22);
        Assert.AreEqual(74, counted2);

        var counted3 = DivisorsCounter.CountDivisors(99);
        Assert.AreEqual(473, counted3);

        var counted4 = DivisorsCounter.CountDivisors(124);
        Assert.AreEqual(619, counted4);
    }

    [Test]
    public void TestSampleSmallNumbers()
    {
        var counted1 = DivisorsCounter.CountDivisors(1);
        Assert.AreEqual(1, counted1);

        var counted2 = DivisorsCounter.CountDivisors(2);
        Assert.AreEqual(3, counted2);

        var counted3 = DivisorsCounter.CountDivisors(3);
        Assert.AreEqual(5, counted3);

        var counted4 = DivisorsCounter.CountDivisors(4);
        Assert.AreEqual(8, counted4);

        var counted5 = DivisorsCounter.CountDivisors(5);
        Assert.AreEqual(10, counted5);

        var counted6 = DivisorsCounter.CountDivisors(20);
        Assert.AreEqual(66, counted6);
    }

    [Test]
    public void TestGreaterNumbers()
    {
        var counted1 = DivisorsCounter.CountDivisors(1110L);
        Assert.AreEqual(7963, counted1);

        var counted2 = DivisorsCounter.CountDivisors(2210L);
        Assert.AreEqual(17373, counted2);

        var counted3 = DivisorsCounter.CountDivisors(3410L);
        Assert.AreEqual(28280, counted3);

        var counted4 = DivisorsCounter.CountDivisors(7510L);
        Assert.AreEqual(68182, counted4);

        var counted5 = DivisorsCounter.CountDivisors(125000002L);
        Assert.AreEqual(2349782184L, counted5);
    }

    [Test]
    public void TestQuiteLargeNumber()
    {
        var result = 27785452448917L;
        long number = 999999999999L;
        long counted = DivisorsCounter.CountDivisors(number);
        Assert.AreEqual(result, counted);
    }

    [Test]
    public void TestVeryLargeNumbers()
    {
        var result = 34693207724723990L;
        var number = 999999999999999L;
        var counted = DivisorsCounter.CountDivisors(number);
        Assert.AreEqual(result, counted);


        var result2 = 34693207724723862L;
        var number2 = 999999999999998L;
        var counted2 = DivisorsCounter.CountDivisors(number2);
        Assert.AreEqual(result2, counted2);

        var result3 = 34693207724723818L;
        var number3 = 999999999999995L;
        var counted3 = DivisorsCounter.CountDivisors(number3);
        Assert.AreEqual(result3, counted3);

        var result4 = 34693207724722436L;
        var number4 = 999999999999950L;
        var counted4 = DivisorsCounter.CountDivisors(number4);
        Assert.AreEqual(result4, counted4);
    }

    [Test]
    public void TestMediumSizeNumbers()
    {
        var result = 145504644L;
        var number = 9000001L;
        var counted = DivisorsCounter.CountDivisors(number);
        Assert.AreEqual(result, counted);


        var result2 = 20080731870L;
        var number2 = 963541024L;
        var counted2 = DivisorsCounter.CountDivisors(number2);
        Assert.AreEqual(result2, counted2);

        var result3 = 6638449L;
        var number3 = 500000L;
        var counted3 = DivisorsCounter.CountDivisors(number3);
        Assert.AreEqual(result3, counted3);
    }

    [Test]
    public void TestRandomNumber()
    {
        var rnd = new Random();
        for (int i = 0; i < 100; i++)
        {
            var number = (long)(rnd.NextDouble() * 10000000000000);
            var result = SenseiCalculator.CountDivisorsBySensei(number);
            long counted = DivisorsCounter.CountDivisors(number);
            Assert.AreEqual(result, counted);
        }
    }

    private class SenseiCalculator
    {
        public static long CountDivisorsBySensei(long n)
        {
            var sum = 0L;
            var floorOfSqrt = (long)Math.Floor(Math.Sqrt(n));
            for (long i = 1; i <= floorOfSqrt; i++)
                sum += n / i;
            sum *= 2;
            return sum - floorOfSqrt * floorOfSqrt;
        }
    }
}
