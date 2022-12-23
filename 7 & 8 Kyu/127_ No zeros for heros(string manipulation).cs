/*Challenge link:
Question:
Numbers ending with zeros are boring.

They might be fun in your world, but not here.

Get rid of them. Only the ending ones.

1450 -> 145
960000 -> 96
1050 -> 105
-1050 -> -105
Zero alone is fine, don''t worry about it. Poor guy anyway
*/

//***************Solution********************
//check if n is 0, if true return 0, else convert n to string, and trim the ending 0s, then convert back to int.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class NoBoring {
    public static int NoBoringZeros(int n) => n == 0 ? 0 : Convert.ToInt32(n.ToString().TrimEnd('0'));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class NoBoringTests 
{

    private static void testing(int actual, int expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests NoBoringZeros");
        testing(NoBoring.NoBoringZeros(1450), 145);
        testing(NoBoring.NoBoringZeros(960000), 96);
        testing(NoBoring.NoBoringZeros(1050), 105);
        testing(NoBoring.NoBoringZeros(-1050), -105);
        testing(NoBoring.NoBoringZeros(-105), -105);
        testing(NoBoring.NoBoringZeros(0), 0);
        testing(NoBoring.NoBoringZeros(2016), 2016);
    }
    //-----------------------
  
    private static Random rnd = new Random();
    private static int NoBoringZerosSol(int n) 
    {
        if (n == 0) return n;
        while (n % 10 == 0) 
        {
            n = n / 10;
        }
        return n;
    }

    //-----------------------
    private static void test2() 
    {
        int i = 0;
        while (i < 100) 
        {
            int k = rnd.Next(100, 10000);
            testing(NoBoring.NoBoringZeros(1000 * k), NoBoringZerosSol(1000 * k));
            testing(NoBoring.NoBoringZeros(-1000 * k), NoBoringZerosSol(-1000 * k));
            testing(NoBoring.NoBoringZeros(2 * k), NoBoringZerosSol(2 * k));
            testing(NoBoring.NoBoringZeros(k), NoBoringZerosSol(k));
            i++;
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* NoBoringZeros");
        test2();
    } 
}
