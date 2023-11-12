/*Challenge link:https://www.codewars.com/kata/55e6f5e58f7817808e00002e/train/csharp
Question:
A number m of the form 10x + y is divisible by 7 if and only if x − 2y is divisible by 7. In other words, subtract twice the last digit from the number formed by the remaining digits. Continue to do this until a number known to be divisible by 7 is obtained; you can stop when this number has at most 2 digits because you are supposed to know if a number of at most 2 digits is divisible by 7 or not.

The original number is divisible by 7 if and only if the last number obtained using this procedure is divisible by 7.

Examples:
1 - m = 371 -> 37 − (2×1) -> 37 − 2 = 35 ; thus, since 35 is divisible by 7, 371 is divisible by 7.

The number of steps to get the result is 1.

2 - m = 1603 -> 160 - (2 x 3) -> 154 -> 15 - 8 = 7 and 7 is divisible by 7.

3 - m = 372 -> 37 − (2×2) -> 37 − 4 = 33 ; thus, since 33 is not divisible by 7, 372 is not divisible by 7.

4 - m = 477557101->47755708->4775554->477547->47740->4774->469->28 and 28 is divisible by 7, so is 477557101. The number of steps is 7.

Task:
Your task is to return to the function seven(m) (m integer >= 0) an array (or a pair, depending on the language) of numbers, the first being the last number m with at most 2 digits obtained by your function (this last m will be divisible or not by 7), the second one being the number of steps to get the result.

Forth Note:
Return on the stack number-of-steps, last-number-m-with-at-most-2-digits 

Examples:
seven(371) should return [35, 1]
seven(1603) should return [7, 2]
seven(477557101) should return [28, 7]
*/

//***************Solution********************

//if m is less then 99 (triple digit)
//return format {m, Count}
//else use recursive method to find out the result
// m/10 is to remove least significant digit from m
// (m % 10) is to get the last digit from m , then times 2
//increase the Count counter each iteration.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class DivSeven{
	public static long[] Seven(long m, long Count = 0) => 
    m < 99 ? new[] {m, Count} : Seven(m / 10 - 2 * (m % 10), ++Count);
}

//solution 2
using System;

public class DivSeven {
	public static long[] Seven(long m, long step = 0) {
		if(m < 100) return new long[] {m, step};
    long x = m / 10L, y = m % 10, res = x - 2 * y;
    return Seven(res, ++step);
	}
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class DivSevenTests {

    [Test]
    public void Test1() {
        Console.WriteLine("****** Basic Tests");    
        Assert.AreEqual(new long[] {10, 2}, DivSeven.Seven(1021));
        Assert.AreEqual(new long[] {28, 7}, DivSeven.Seven(477557101));
        Assert.AreEqual(new long[] {47, 7}, DivSeven.Seven(477557102));
        Assert.AreEqual(new long[] {21, 7}, DivSeven.Seven(234002979));
        Assert.AreEqual(new long[] {7, 2}, DivSeven.Seven(1603));
        Assert.AreEqual(new long[] {35, 1}, DivSeven.Seven(371));
        Assert.AreEqual(new long[] {0, 5}, DivSeven.Seven(1369851));
        Assert.AreEqual(new long[] {42, 1}, DivSeven.Seven(483));
        Assert.AreEqual(new long[] {28, 4}, DivSeven.Seven(483595));
        Assert.AreEqual(new long[] {0, 0}, DivSeven.Seven(0));
        Assert.AreEqual(new long[] {7, 2}, DivSeven.Seven(286*7));
        
    }

    //--------------------
    private static long[] SevenSol(long m)
    {
        int cnt = 0;
        while (m > 99) 
        {
            long a0 = m % 10;
            m = (m - a0) / 10 - 2 * a0;
            cnt++;
        }
        return new long[] {m, cnt};
    }
    //--------------------
    [Test]
    public static void Test2() {
        Console.WriteLine("\n 100 Random Tests ****************");
        Random rnd = new Random();
        for (int i = 0; i < 100; i++) {  
            long m = rnd.Next(100, 7500000);
            Assert.AreEqual(SevenSol(m), DivSeven.Seven(m));  
        }
    }
}
