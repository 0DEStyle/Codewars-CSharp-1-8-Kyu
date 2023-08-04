/*Challenge link:https://www.codewars.com/kata/56b2abae51646a143400001d/train/csharp
Question:
The mystery function is defined over the non-negative integers. The more common name of this function is concealed in order to not tempt you to search the Web for help in solving this kata, which most definitely would be a very dishonorable thing to do.

Assume n has m bits. Then mystery(n) is the number whose binary representation is the entry in the table T(m) at index position n, where T(m) is defined recursively as follows:

T(1) = [0, 1]
T(m + 1) is obtained by taking two copies of T(m), reversing the second copy, prepending each entry of the first copy with 0 and each entry of the reversed copy with 1, and then concatenating the two. For example:

T(2) = [ 00, 01, 11, 10 ]
and

T(3) = [ 000, 001, 011, 010, 110, 111, 101, 100 ]
mystery(6) is the entry in T(3) at index position 6 (with indexing starting at 0), i.e., 101 interpreted as a binary number. So, mystery(6) returns 5.

Your mission is to implement the function mystery, where the argument may have up to 63 bits. Note that T(63) is far too large to compute and store, so you'll have to find an alternative way of implementing mystery.

You are also asked to implement mystery_inv ( or mysteryInv ), the inverse of mystery. Finally, you are asked to implement a function name_of_mystery ( or nameOfMystery ), which shall return the name that mystery is more commonly known as. After passing all tests you are free to learn more about this function on Wikipedia or another place.

Hint: If you don't know the name of mystery, remember there is information in passing as well as failing a test.
*/

//***************Solution********************

// simiplfied into one line by using an Lambda expression with Enumerable methods.
using static System.Linq.Enumerable; //reduce coding

public class MysteryFunction{
  
  //n to the power of (n right shift by 1 bit)
   public static long Mystery(long n) => n ^ (n >> 1);

  //start from 0 up to 6, aggregate, n is current elemenet, x,i are index
  //x to the power of (x right shift (1  left shift( 5 - current index)))
   public static long MysteryInv(long n) => Range(0, 6).Aggregate(n, (x,i) => x ^ (x >> (1 << (5 - i))));

   public static string NameOfMystery() => "gray code";
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class MysteryFunctionTest
{
    [Test]
    public void MysteryTest()
    {
        Assert.AreEqual(5, MysteryFunction.Mystery(6), "mystery(6) ");
        Assert.AreEqual(13, MysteryFunction.Mystery(9), "mystery(9) ");
        Assert.AreEqual(26, MysteryFunction.Mystery(19), "mystery(19) ");
    }

    [Test]
    public void MysteryInvTest()
    {
        Assert.AreEqual(6, MysteryFunction.MysteryInv(5), "mysteryInv(5)");
        Assert.AreEqual(9, MysteryFunction.MysteryInv(13), "mysteryInv(13)");
        Assert.AreEqual(19, MysteryFunction.MysteryInv(26), "mysteryInv(26)");
    }

    [Test]
    public void RandomSmallNumbersTest()
    {
        Random r = new Random();
        for (int i = 0; i < 20; i++)
        {
            long n = r.Next(1000);
            Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
        }
    }

    [Test]
    public void RandomInvSmallNumbersTest()
    {
        Random r = new Random();
        for (int i = 0; i < 20; i++)
        {
            long n = r.Next(1000);
            Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
        }
    }

    [Test]
    public void RandomBigNumbersTest()
    {
        Random r = new Random();
        for (int i = 0; i < 20; i++)
        {
            long n = (long)(r.NextDouble() * 999999999999999L);
            Assert.AreEqual(n ^ (n >> 1), MysteryFunction.Mystery(n), $"mystery({n})");
        }
    }

    [Test]
    public void RandomInvBigNumbersTest()
    {
        Random r = new Random();
        for (int i = 0; i < 20; i++)
        {
            long n = (long)(r.NextDouble() * 999999999999999L);
            Assert.AreEqual(MysteryInv(n), MysteryFunction.MysteryInv(n), $"mysteryInv({n})");
        }
    }

    [Test]
    public void FunctionNameTest()
    {
        Random r = new Random();
        for (int i = 0; i < 5; i++)
        {
            long n = r.Next(1000);
            Assert.AreEqual((n ^ (n >> 1)), MysteryFunction.Mystery(n), "No,no,no! Find the function before you can see it in the tests ;)");
        }
        Assert.AreEqual("gray code", MysteryFunction.NameOfMystery().ToLower());
    }

    private static long MysteryInv(long n)
    {
        long mask;
        for (mask = n >> 1; mask != 0; mask >>= 1)
            n ^= mask;
        return n;
    }
}
