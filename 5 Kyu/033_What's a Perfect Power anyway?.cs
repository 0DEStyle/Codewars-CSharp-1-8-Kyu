/*Challenge link:https://www.codewars.com/kata/54d4c8b08776e4ad92000835/train/csharp
Question:

A perfect power is a classification of positive integers:

In mathematics, a perfect power is a positive integer that can be expressed as an integer power of another positive integer. More formally, n is a perfect power if there exist natural numbers m > 1, and k > 1 such that mk = n.

Your task is to check wheter a given integer is a perfect power. If it is a perfect power, return a pair m and k with mk = n as a proof. Otherwise return Nothing, Nil, null, NULL, None or your language's equivalent.

Note: For a perfect power, there might be several pairs. For example 81 = 3^4 = 9^2, so (3,4) and (9,2) are valid solutions. However, the tests take care of this, so if a number is a perfect power, return any pair that proves it.

Examples
IsPerfectPower(4) => (2,2)
IsPerfectPower(5) => null
IsPerfectPower(8) => (2,3)
IsPerfectPower(9) => (3,2)
*/

//***************Solution********************

using System;

public class PerfectPower{
    public static (int, int)? IsPerfectPower(int n){
      
            //square root n and round to nearest int
            int k = (int)Math.Sqrt(n);
            for (int i = 2; i <= k; k--){
                //log n over log k will give m
                //if not, then it's not a perfect power, return null instead.
                int m = Convert.ToInt32(Math.Log(n, k));
                if (Math.Pow(k, m) == n)
                    return (k, m);
            }
            return null;
    }
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class PerfectPowerTest
{
    [Test]
    public void Test0()
    {
        Assert.IsNull(PerfectPower.IsPerfectPower(0), "0 is not a perfect number");
    }

    [Test]
    public void Test1()
    {
        Assert.IsNull(PerfectPower.IsPerfectPower(1), "1 is not a perfect number");
    }

    [Test]
    public void Test2()
    {
        Assert.IsNull(PerfectPower.IsPerfectPower(2), "2 is not a perfect number");
    }

    [Test]
    public void Test3()
    {
        Assert.IsNull(PerfectPower.IsPerfectPower(3), "3 is not a perfect number");
    }

    [Test]
    public void Test4()
    {
        Assert.AreEqual((2, 2), PerfectPower.IsPerfectPower(4), "4 = 2^2");
    }

    [Test]
    public void Test5()
    {
        Assert.IsNull(PerfectPower.IsPerfectPower(5), "5 is not a perfect power");
    }

    [Test]
    public void Test8()
    {
        Assert.AreEqual((2, 3), PerfectPower.IsPerfectPower(8), "8 = 2^3");
    }

    [Test]
    public void Test9()
    {
        Assert.AreEqual((3, 2), PerfectPower.IsPerfectPower(9), "9 = 3^2");
    }

    [Test]
    public void TestUpTo500()
    {
        var pp = new int[] { 4, 8, 9, 16, 25, 27, 32, 36, 49, 64, 81, 100, 121, 125, 128, 144, 169, 196, 216, 225, 243, 256, 289, 324, 343, 361, 400, 441, 484 };
        foreach (var i in pp)
            Assert.IsNotNull(PerfectPower.IsPerfectPower(i), $"{i} is a perfect power");
    }

    private Random rnd = new Random();

    [Test]
    public void TestRandomPerfectPowers()
    {
        for (int i = 0; i < 100; i++)
        {
            var m = rnd.Next(254) + 2;
            var k = (int)(rnd.NextDouble() * (Math.Log(int.MaxValue) / Math.Log(m) - 2.0) + 2.0);
            var l = Ipow(m, k);
            var r = PerfectPower.IsPerfectPower(l);
            Assert.IsNotNull(r, $"{l} is a perfect power");
            var (x, y) = r.GetValueOrDefault();
            Assert.AreEqual(l, Ipow(x, y), $"{x}^{y}!={l}");
        }
    }

    [Test]
    public void TestRandomNumbers()
    {
        Random rnd = new Random();
        for (int i = 0; i < 200; i++)
        {
            var m = rnd.Next(2, 20);
            var k = rnd.Next(2, Convert.ToInt32(Math.Log(int.MaxValue, m))); // replace 1000000 with the upper limit for n
            var n = Convert.ToInt32(Math.Pow(m, k)); // this is the test input
            var l = rnd.NextDouble() < 0.5 ? rnd.Next(int.MaxValue) : n;
            var s = Solution(l);
            var r = PerfectPower.IsPerfectPower(l);
            if(s == null)
            {
              Assert.IsNull(r, $"Incorrect answer for n={l}");
            }
            else
            {
              var (b, e) = r.GetValueOrDefault();
              Assert.AreEqual(Ipow(b, e), l, $"{b} ^ {e} does not equal {l}");
            }
        }
    }

    private static (int, int)? Solution(int n)
    {
        for (int i = 2; ; i++)
        {
            int r = Root(n, i);
            if (r < 2) return null;
            if (Ipow(r, i) == n) return (r, i);
        }
    }

    private static int Root(int n, int i) => (int)Math.Round(Math.Pow(n, 1.0 / i));

    private static int Ipow(int b, int e)
    {
        int p = 1;
        for (; e > 0; e >>= 1)
        {
            if ((e & 1) == 1) p *= b;
            b *= b;
        }
        return p;
    }
}
