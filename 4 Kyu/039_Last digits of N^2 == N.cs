/*Challenge link:https://www.codewars.com/kata/584dee06fe9c9aef810001e8/train/csharp
Question:
This is a very simply formulated task. Let's call an integer number N 'green' if N² ends with all of the digits of N. Some examples:

5 is green, because 5² = 25 and 25 ends with 5.

11 is not green, because 11² = 121 and 121 does not end with 11.

376 is green, because 376² = 141376 and 141376 ends with 376.

Your task is to write a function green that returns the nth green number, starting with 1 - green (1) == 1

Input range
n <= 5000
*/

//***************Solution********************
using System;
using N = System.Numerics.BigInteger; //reduce coding

public class GreenNumbers{
   private static N[] cache = new N[5002];
   private static int i = 2;
   private static N   a = new N(1), p = new N(1);
   private static N   m = new N(0), m5 = new N(5), m6 = new N(6);
   private static N   x = new N(0), y = new N(0);
  
   public static N Get(int n){
     //store 1 in cache array 1 to jump start
       cache[1] = new N(1);
     //info
     //Console.WriteLine($"n:{n},a{a},m5{m5},m{m},");
     
       while (i <= n) {
         //m5 square mod a to get last digit
            a = a * 10;
            m5 = (m5 * m5) % a;
         
         //set last digit to m
         //check if m is less than 0, if so update m6 = m+a, else m6 = m
            m = (1 - (m6 - 1) * (m6 - 1)) % a;
            m6 = (m < 0) ? m + a : m;
         
         //compare last digit.
            x = m5 < m6 ? m5 : m6;
            y = m5 > m6 ? m5 : m6;
         
         //update digit to cache accordiningly
            if (x > p) 
              cache[i++] = x;
            if (y > p) 
              cache[i++] = y;
            p = cache[i-1];
       }
       //results
       //Console.WriteLine(string.Join(",",cache));
       return cache[n];
   }
}

//method 2
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
public class GreenNumbers
{
  public static BigInteger Get(int n)
  {
    while(GREENS.Count < n) {
      BigInteger last = GREENS[GREENS.Count - 1];
      high5 = nextFive(high5);
      high6 = nextSix(high6);
      ten *= 10;
      GREENS.AddRange(new[]{ high5, high6}.Where(i => last < i).OrderBy(i => i));
    }
    return GREENS[n - 1];
  }
  
  private static List<BigInteger> GREENS = new List<BigInteger> { BigInteger.One, new BigInteger(5), new BigInteger(6) };
  private static BigInteger high5 = GREENS[1];
  private static BigInteger high6 = GREENS[2];
  private static BigInteger ten = new BigInteger(10);
    
  private static BigInteger nextFive(BigInteger five) {
    return BigInteger.Pow(five, 2) % (ten * 10);
  }
  
  private static BigInteger nextSix(BigInteger six) {
    BigInteger i = (- BigInteger.Pow(six, 2) / ten) % 10;
    if(i < 0) i += 10;
    return i * ten + six;
  }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
public class SolutionTest
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(new BigInteger(1), GreenNumbers.Get(1), "for n = 1");
        Assert.AreEqual(new BigInteger(5), GreenNumbers.Get(2), "for n = 2");
        Assert.AreEqual(new BigInteger(6), GreenNumbers.Get(3), "for n = 3");
        Assert.AreEqual(new BigInteger(25), GreenNumbers.Get(4), "for n = 4");
    }

    [Test]
    public void BiggerTests()
    {
        Assert.AreEqual(new BigInteger(2890625), GreenNumbers.Get(12), "for n = 12");
        Assert.AreEqual(new BigInteger(7109376), GreenNumbers.Get(13), "for n = 13");
    }

    [Test]
    public void AdvancedTests()
    {
        Assert.AreEqual(BigInteger.Parse("6188999442576576769103890995893380022607743740081787109376"), GreenNumbers.Get(100), "for n = 100");
        Assert.AreEqual(BigInteger.Parse("9580863811000557423423230896109004106619977392256259918212890625"), GreenNumbers.Get(110), "for n = 110");
    }

    private static Random rand = new Random();
    private static int MAX_TEST = 5000;

    [Test]
    public void RandomTests()
    {
        for (int n = 0; n < 100; n++)
        {
            int r = rand.Next(MAX_TEST) + 1;
            Assert.AreEqual(SuperGreeeeen.Get(r), GreenNumbers.Get(r), $"for n = {r}");
        }
        Assert.AreEqual(SuperGreeeeen.Get(MAX_TEST), GreenNumbers.Get(MAX_TEST), $"for n = {MAX_TEST}");
    }

    private class SuperGreeeeen
    {
        private static List<BigInteger> GREEN = new List<BigInteger> { BigInteger.Zero, BigInteger.One };

        private static BigInteger current = BigInteger.One, seed5 = new BigInteger(5), seed6 = new BigInteger(6);

        public static BigInteger Get(int n)
        {
            while (GREEN.Count <= n)
            {
                current *= 10;
                seed5 = (seed5 * seed5) % current;
                var seed = (1 - (seed6 - 1) * (seed6 - 1)) % current;
                seed6 = seed.Sign == 1 ? seed : seed + current;
                GREEN.AddRange(new[] { seed5, seed6 }.Where(x => x > GREEN[GREEN.Count - 1]).OrderBy(x => x));
            }
            return GREEN[n];
        }
    }
}
