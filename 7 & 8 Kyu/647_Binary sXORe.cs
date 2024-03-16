/*Challenge link:https://www.codewars.com/kata/56d3e702fc231fdf72001779/train/csharp
Question:
Objective
Given a number n we will define it's sXORe to be 0 XOR 1 XOR 2 ... XOR n where XOR is the bitwise XOR operator.

Write a function that takes n and returns it's sXORe.

Examples
n	sXORe n
0	0
1	1
50	51
1000000	1000000

*/

//***************Solution********************
//set result to n mod 4 => 0 1 1 0
//if res is 0, return n
//if res is 1, return 1
//if res is 2, return n + 1, else return 0;
using System.Numerics;

public class BinarySxore{
    public static BigInteger Sxore (BigInteger n){
      BigInteger  res = n % 4;
      return res == 0 ? n :
             res == 1 ? 1 :
             res == 2 ? n + 1 : 0;
    }
}

//solution 2
using System.Numerics;

public class BinarySxore
{
  public static BigInteger Sxore (BigInteger n)
  {
    return new[] {n, 1, n + 1, 0}[(int) (n % 4)];
  }
}

///solution 3
using System;
using System.Numerics;

public class BinarySxore
{
    public static BigInteger Sxore(BigInteger n) =>
      (int)(n % 4) switch {
        0 => n,
        1 => 1,
        2 => n + 1,          
        _ => 0
      };
}
//****************Sample Test*****************
using System;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class SxoreTests
{
    private static Random rand = new Random();
    private static void Tester (BigInteger inp, BigInteger exp)
    {
        Assert.AreEqual(exp, BinarySxore.Sxore(inp));
    }
    private static BigInteger RandBigInteger(BigInteger min, BigInteger max)
    {
        var res = new BigInteger();
        while(res <= (max - min))
        {
            if(rand.Next(2) % 2 == 0)
            {
                res += new BigInteger(rand.Next());
            }
            else
            {
                res *= new BigInteger(rand.Next());
            }
        }
        return (res % (max - min + 1)) + min;
    }
    private static BigInteger Ans (BigInteger n)
    {
        return new BigInteger[]{n, 1, n + 1, 0}[(int)(n % 4)];
    }
    [Test]
    public void BasicTests ()
    {
        Tester(BigInteger.Parse("0"), BigInteger.Parse("0"));
        Tester(BigInteger.Parse("1"), BigInteger.Parse("1"));
        Tester(BigInteger.Parse("2"), BigInteger.Parse("3"));
        Tester(BigInteger.Parse("50"), BigInteger.Parse("51"));
        Tester(BigInteger.Parse("1000000"), BigInteger.Parse("1000000"));
        Tester(BigInteger.Parse("1000001"), BigInteger.Parse("1"));
        Tester(BigInteger.Parse("9999999999999999"), BigInteger.Parse("0"));
    }
    [Test]
    public void RandomTests ()
    {
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("0"), BigInteger.Parse("100000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("100000"), BigInteger.Parse("100000000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("1000000000"), BigInteger.Parse("100000000000000"));
            Tester(n, Ans(n));
        }
        for(int i = 0; i < 100; i++)
        {
            BigInteger n = RandBigInteger(BigInteger.Parse("100000000000000000"), BigInteger.Parse("1000000000000000000000000000"));
            Tester(n, Ans(n));
        }
    }
}
