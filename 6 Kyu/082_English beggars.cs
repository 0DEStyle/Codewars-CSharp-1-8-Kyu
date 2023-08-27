/*Challenge link:https://www.codewars.com/kata/59590976838112bfea0000fa/train/csharp
Question:
Born a misinterpretation of this kata, your task here is pretty simple: given an array of values and an amount of beggars, you are supposed to return an array with the sum of what each beggar brings home, assuming they all take regular turns, from the first to the last.

For example: [1,2,3,4,5] for 2 beggars will return a result of [9,6], as the first one takes [1,3,5], the second collects [2,4].

The same array with 3 beggars would have in turn have produced a better out come for the second beggar: [5,7,3], as they will respectively take [1,4], [2,5] and [3].

Also note that not all beggars have to take the same amount of "offers", meaning that the length of the array is not necessarily a multiple of n; length can be even shorter, in which case the last beggars will of course take nothing (0).

Note: in case you don't get why this kata is about English beggars, then you are not familiar on how religiously queues are taken in the kingdom ;)

Note 2: do not modify the input array.
*/

//***************Solution********************
public class Kata{
   public static int[] Beggars(int[] values, int n){
     //create bank account for number of beggars lol
       int[] beggars = new int[n];
     //no beggar
       if (n == 0)
         return beggars;
     //pay value[i] to (index mod number of beggars)
       for (int i = 0; i < values.Length; i++)
         beggars[i%n] += values[i];
       return beggars;
   }
}

//method 2
using static System.Linq.Enumerable;
public class Kata
{
   public static int[] Beggars(int[] values, int n) => 
     Range(0,n).Select(i => values.Where((_,index) => index % n == i).Sum()).ToArray();
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class SolutionTest
{
    private static int[] Solution(int[] values, int n)
    {
        if (n == 0) return new int[0];
        int[] res = new int[n];
        for (int i = 0, len = values.Length; i < len; i++)
            res[i % n] += values[i];
        return res;
    }

    private Random random = new Random();

    public int GetRandomInt(int start, int end) => random.Next(start, end + 1);

    public int[] GetRandomList()
    {
        int len = GetRandomInt(3, 40), randPower;
        var list = new int[len];
        for (int i = 0; i < len; i++)
        {
            randPower = (int)Math.Pow(10, GetRandomInt(1, 3));
            list[i] = GetRandomInt(1, randPower);
        }
        return list;
    }

    [Test]
    public void FixedTest()
    {
        // Basic tests
        int[] test = { 1, 2, 3, 4, 5 };
        int[] a1 = { 15 }, a2 = { 9, 6 }, a3 = { 5, 7, 3 }, a4 = { 1, 2, 3, 4, 5, 0 }, a5 = { };
        Assert.AreEqual(a1, Kata.Beggars(test, 1));
        Assert.AreEqual(a2, Kata.Beggars(test, 2));
        Assert.AreEqual(a3, Kata.Beggars(test, 3));
        Assert.AreEqual(a4, Kata.Beggars(test, 6));
        Assert.AreEqual(a5, Kata.Beggars(test, 0));
    }

    [Test]
    public void RandomTest()
    {
        // Random tests            
        int[] v; int n;
        for (int i = 0; i < 40; i++)
        {
            v = GetRandomList();
            n = GetRandomInt(1, 20);

            var msg = "n = " + n + ", values = " + string.Join(",", v);
            Assert.AreEqual(Solution(v, n), Kata.Beggars(v, n), "It should work for random inputs too, here " + msg);
        }
    }
}
