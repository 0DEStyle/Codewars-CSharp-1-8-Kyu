/*Challenge link:https://www.codewars.com/kata/560a4962c0cc5c2a16000068/train/csharp
Question:
Not considering number 1, the integer 153 is the first integer having this property: the sum of the third-power of each of its digits is equal to 153. Take a look: 153 = 1³ + 5³ + 3³ = 1 + 125 + 27 = 153

The next number that experiments this particular behaviour is 370 with the same power.

Write the function eq_sum_powdig(), that finds the numbers below a given upper limit hMax (inclusive) that fulfills this property but with different exponents as the power for the digits.

eq_sum_powdig(hMax, exp): ----> sequence of numbers (sorted list) (Number one should not be considered).

Let's see some cases:

eq_sum_powdig(100, 2) ----> []

eq_sum_powdig(1000, 2) ----> []

eq_sum_powdig(200, 3) ----> [153]

eq_sum_powdig(370, 3) ----> [153, 370]
Enjoy it !!
*/

//***************Solution********************
using System.Linq;
using static System.Math;
using System.Collections.Generic;

public class Sumpowdig {
    public static long[] EqSumPowDig(long hmax, int exp){
      //create a list to store result.
      var res = new List<long>();
      
      //exclude 1 and 0, loop up to hmax
      //convert i to string, then to list, 
      //x is the current element/number, find the sum of power to each digit
      //check if the result is same as the number itself, if so add it to list.
      for(long i = 2; i <= hmax; i++)
        if(i.ToString().ToList().Sum(x => Pow(long.Parse(x.ToString()), exp)) == i)
          res.Add(i);
        
      //convert to array and return the result.
      return res.ToArray();
    }
}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Collections;
using NUnit.Framework;

[TestFixture]
public static class SumpowdigTests {

    private static Random rnd = new Random();

[Test]
    public static void test1() {
        Assert.AreEqual(new int[] {}, Sumpowdig.EqSumPowDig(100, 2));
        Assert.AreEqual(new int[] {}, Sumpowdig.EqSumPowDig(1000, 2));
        Assert.AreEqual(new int[] {}, Sumpowdig.EqSumPowDig(2000, 2));
        Assert.AreEqual(new int[] {153}, Sumpowdig.EqSumPowDig(200, 3));
        Assert.AreEqual(new int[] {153, 370}, Sumpowdig.EqSumPowDig(370, 3));
        Assert.AreEqual(new int[] {153, 370, 371}, Sumpowdig.EqSumPowDig(400, 3));
        Assert.AreEqual(new int[] {153, 370, 371, 407}, Sumpowdig.EqSumPowDig(500, 3));
        Assert.AreEqual(new int[] {153, 370, 371, 407}, Sumpowdig.EqSumPowDig(1000, 3));
        Assert.AreEqual(new int[] {153, 370, 371, 407}, Sumpowdig.EqSumPowDig(1500, 3));
        Assert.AreEqual(new int[] {1634, 8208, 9474}, Sumpowdig.EqSumPowDig(100000, 4));
        Assert.AreEqual(new int[] {4150, 4151, 54748, 92727, 93084}, Sumpowdig.EqSumPowDig(100000, 5));        
    }
    
    //-----------------------
    private static bool IsPowSol(long nb, int po) 
    {
        return nb == nb.ToString().Sum(c => (long)Math.Pow(int.Parse(c.ToString()), po));
    }
    public static long[] EqSumPowDigSol(long hmax, int exp) 
    {
        ArrayList a = new ArrayList();
        for (long i = 2; i <= hmax; i++)
            if (IsPowSol(i, exp))
                a.Add(i);
        long[] result = a.OfType<long>().ToArray();
        return result;
    }
    //-----------------------
[Test]    
    public static void RandomTest() {
      Console.WriteLine("Random Tests");
      for (int i = 0; i < 10; i++) { 
        long n = (long)rnd.Next(100000, 200000);   
        int p = rnd.Next(3, 5);   
        Assert.AreEqual(EqSumPowDigSol(n, p), Sumpowdig.EqSumPowDig(n, p)); 
      }
    }  
}
