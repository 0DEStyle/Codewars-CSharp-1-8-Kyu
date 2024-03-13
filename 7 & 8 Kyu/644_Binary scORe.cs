/*Challenge link:https://www.codewars.com/kata/56cafdabc8cfcc3ad4000a2b/train/csharp
Question:
Objective
Given a number n we will define its scORe to be 0 | 1 | 2 | 3 | ... | n, where | is the bitwise OR operator.

Write a function that takes n and finds it's scORe.

n	scORe n
0	0
1	1
49	63
1000000	1048575
Any feedback would be much appreciated
*/

//***************Solution********************
using System;
using System.Numerics;

public class BinaryScore{
    public static BigInteger Score (BigInteger n){
      
      //get length of upper bound
      var len = BigInteger.Log(n,2);
      BigInteger ans = 0;
      
      //loop through the length
      //bit shift ans to left by 1 then add 1
      for(int i = 0; i <= len; i++){
        ans <<=1;
        ans++;
      }
      return ans;
    } 
}

//solution 2
using System;
using System.Numerics;

public class BinaryScore
{
  public static BigInteger Score (BigInteger n)
  {
    return BigInteger.Pow(2, (int) Math.Ceiling(BigInteger.Log(n + 1, 2))) - 1;
  }
}
//****************Sample Test*****************
using System;
using System.Numerics;
using NUnit.Framework;

[TestFixture]
public class ScoreTests
{
    private static Random rand = new Random();
    private static void Tester (BigInteger inp, BigInteger exp)
    {
        Assert.AreEqual(exp, BinaryScore.Score(inp));
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
        return n > 0 ? BigInteger.Pow(new BigInteger(2), (int)BigInteger.Log(n, 2) + 1) - 1 : n;
    }
    [Test]
    public void BasicTests ()
    {
        Tester(BigInteger.Parse("0"), BigInteger.Parse("0"));
        Tester(BigInteger.Parse("1"), BigInteger.Parse("1"));
        Tester(BigInteger.Parse("2"), BigInteger.Parse("3"));
        Tester(BigInteger.Parse("49"), BigInteger.Parse("63"));
        Tester(BigInteger.Parse("1000000"), BigInteger.Parse("1048575"));
        Tester(BigInteger.Parse("10000000"), BigInteger.Parse("16777215"));
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
            BigInteger n = RandBigInteger(BigInteger.Parse("1000000000000000"), BigInteger.Parse("1000000000000000000000"));
            Tester(n, Ans(n));
        }
    }
}
