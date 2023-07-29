/*Challenge link:https://www.codewars.com/kata/55c4eb777e07c13528000021/train/csharp
Question:
The problem
How many zeroes are at the end of the factorial of 10? 10! = 3628800, i.e. there are 2 zeroes. 16! (or 0x10!) in hexadecimal would be 0x130777758000, which has 3 zeroes.

Scalability
Unfortunately, machine integer numbers has not enough precision for larger values. Floating point numbers drop the tail we need. We can fall back to arbitrary-precision ones - built-ins or from a library, but calculating the full product isn't an efficient way to find just the tail of a factorial. Calculating 100'000! in compiled language takes around 10 seconds. 1'000'000! would be around 10 minutes, even using efficient Karatsuba algorithm

Your task
is to write a function, which will find the number of zeroes at the end of (number) factorial in arbitrary radix = base for larger numbers.

base is an integer from 2 to 256
number is an integer from 1 to 1'000'000
Note Second argument: number is always declared, passed and displayed as a regular decimal number. If you see a test described as 42! in base 20 it's 4210 not 4220 = 8210.
*/

//***************Solution********************

using System;
using System.Linq;
using System.Collections.Generic;

public class FactorialTail {
  public static int zeroes(int radix, int number){            
    //create a list to add items.  
    List<int> factorDivs = new List<int>();
    int baseVal = radix;
    
    Console.WriteLine($"radix:{radix}, number:{number}");
    
    for (int div = 2; div <= radix; div++){
      int exponent = 0;
      
      //print info before process
      Console.WriteLine($"Before...div:{div}, baseVal:{baseVal}, exponent:{exponent}");
      
      // find prime factors of base (radix)
      while (baseVal % div == 0){
        baseVal /= div;
        exponent++;
      }
      
      //print info after process
      Console.WriteLine($"After... div:{div}, baseVal:{baseVal}, exponent:{exponent}");
      if (exponent > 0){
        // Divide factorial by each exponent.
        int k = (int)Math.Log(number, div);
        int a = 0;
        
        
        for (int i = 1; i <= k; i++){
          a += number / (int)(Math.Pow(div, i));
          //because a is int, it wil round downward
          Console.WriteLine($"div:{div}, i:{i}, a:{a}");
          }
        
        //info monitor, then add to list
        Console.WriteLine($"k:{k}, a:{a}"); 
        factorDivs.Add(a / exponent);
      }
    }
    
    //select the smaller value out of factorDivs and return the result.
    Console.WriteLine($"factorDivs.Min():{string.Concat(factorDivs)}\n\n\n");
    return factorDivs.Min();
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Can_Be_Solved_With_Basic_Computations() 
    {
      Assert.AreEqual(2, FactorialTail.zeroes (10, 10));
      Assert.AreEqual(3, FactorialTail.zeroes (16, 16));
    }

    [Test]
    public void Basic_Quirks()
    {
      Assert.AreEqual(2, FactorialTail.zeroes( 40, 10) /* "base > 36"*/);
      Assert.AreEqual(0, FactorialTail.zeroes( 17, 16) /* "prime base - no zeroes"*/);
      Assert.AreEqual(8, FactorialTail.zeroes(  7, 50) /* "prime base & higher powers"*/);
      Assert.AreEqual(6, FactorialTail.zeroes(100, 50) /* "base = 100"*/);
    }

    [Test]
    public void Considers_Full_Base_Decomposition()
    {
      Assert.AreEqual(10, FactorialTail.zeroes(12, 26) /* "p1^2 ~ p2 >>>"*/);
      Assert.AreEqual(11, FactorialTail.zeroes(12, 27) /* "p1^2 ~ p2 <<<"*/);
      Assert.AreEqual(12, FactorialTail.zeroes(12, 28) /* "p1^2 ~ p2 <<<"*/);
      Assert.AreEqual(14, FactorialTail.zeroes(12, 32) /* "p1^2 ~ p2 >>>"*/);
      Assert.AreEqual(15, FactorialTail.zeroes(12, 33) /* "p1^2 ~ p2 ==="*/);
      Assert.AreEqual(10, FactorialTail.zeroes(80, 49) /* "p1 ~ p2^3 <<<"*/);
      Assert.AreEqual(11, FactorialTail.zeroes(80, 50) /* "p1 ~ p2^3 >>>"*/);
      Assert.AreEqual(12, FactorialTail.zeroes(80, 52) /* "p1 ~ p2^3 ==="*/);
    }

    [Test]
    public void Relatively_Big_Prime_In_Base()
    {
      Assert.AreEqual(5, FactorialTail.zeroes( 17, 100) /* "single"*/);
      Assert.AreEqual(5, FactorialTail.zeroes(170, 100) /* "composite (2)"*/);
      Assert.AreEqual(5, FactorialTail.zeroes(221, 100) /* "composite (3)"*/);
    }


    private static int nprimefactors(int n, int prime)
    {
      int s = 0;
      while (0<(n/=prime)) s+=n;
      return s;
    }

    private static int[] primes = { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53,
          59, 61, 67, 71, 73, 79, 83, 89, 97, 101, 103, 107, 109, 113, 127, 131, 137, 139, 149, 151,
          157, 163, 167, 173, 179, 181, 191, 193, 197, 199, 211, 223, 227, 229, 233, 239, 241, 251 };
   
    [Test]
    public void Random_Samples()
    {
      Random rand = new Random();
      for (int i = 0; i < 50; i++)
      {
        int dbase = 1;
        int expected = Int32.MaxValue;
        int n = rand.Next(1, 1000000); 
        foreach (int p in primes)
        {
          if (dbase * p > 256) break;
          int pp = 0;
          while (rand.Next(0, p) == 0 && dbase * p < 256)
          {
            pp++;
            dbase *= p;
          }
          if (pp>0)
            expected = expected < (pp = nprimefactors(n, p) / pp) ? expected : pp;
        }
        if (dbase == 1)
        {
          dbase = primes[rand.Next(primes.Length)];
          expected = nprimefactors(n, dbase);
        }
        Assert.AreEqual(expected, FactorialTail.zeroes(dbase, n), $"{n}! in radix {dbase}");
      }
    }

    [Test]
    public void Pushes_To_The_Limits()
    {
      int b19 = 1 << 19;
      Assert.AreEqual( b19-1, FactorialTail.zeroes(  2,  b19) /*, "2^19! in binary"*/);
      Assert.AreEqual(     0, FactorialTail.zeroes(251,  250) /*, "Large prime - no zeroes"*/);
      Assert.AreEqual(   124, FactorialTail.zeroes(256, 1000) /*, "Maximum base"*/);
      Assert.AreEqual(999993, FactorialTail.zeroes(  2, 1000000) /*, "Maximum value"*/);
      Assert.AreEqual(249998, FactorialTail.zeroes( 10, 1000000) /*, "Maximum value"*/);
      Assert.AreEqual(124999, FactorialTail.zeroes(256, 1000000) /*, "Both maximized"*/);
    }
  }
}
