/*Challenge link:https://www.codewars.com/kata/561e9c843a2ef5a40c0000a4/train/csharp
Question:
The prime numbers are not regularly spaced. For example from 2 to 3 the gap is 1. From 3 to 5 the gap is 2. From 7 to 11 it is 4. Between 2 and 50 we have the following pairs of 2-gaps primes: 3-5, 5-7, 11-13, 17-19, 29-31, 41-43

A prime gap of length n is a run of n-1 consecutive composite numbers between two successive primes (see: http://mathworld.wolfram.com/PrimeGaps.html).

We will write a function gap with parameters:

g (integer >= 2) which indicates the gap we are looking for

m (integer > 2) which gives the start of the search (m inclusive)

n (integer >= m) which gives the end of the search (n inclusive)

In the example above gap(2, 3, 50) will return [3, 5] or (3, 5) or {3, 5} which is the first pair between 3 and 50 with a 2-gap.

So this function should return the first pair of two prime numbers spaced with a gap of g between the limits m, n if these numbers exist otherwise `nil or null or None or Nothing (or ... depending on the language).

In such a case (no pair of prime numbers with a gap of `g`)
In C: return [0, 0]
In C++, Lua, COBOL: return `{0, 0}`. 
In F#: return `[||]`. 
In Kotlin, Dart and Prolog: return `[]`.
In Pascal: return Type TGap (0, 0).
Examples:
- gap(2, 5, 7) --> [5, 7] or (5, 7) or {5, 7}

gap(2, 5, 5) --> nil. In C++ {0, 0}. In F# [||]. In Kotlin, Dart and Prolog return []`

gap(4, 130, 200) --> [163, 167] or (163, 167) or {163, 167}

([193, 197] is also such a 4-gap primes between 130 and 200 but it is not the first pair)

gap(6,100,110) --> nil or {0, 0} or ... : between 100 and 110 we have 101, 103, 107, 109 but 101-107is not a 6-gap because there is 103in between and 103-109is not a 6-gap because there is 107in between.

You can see more examples of return in Sample Tests.

Note for Go
For Go: nil slice is expected when there are no gap between m and n. Example: gap(11,30000,100000) --> nil

Ref
https://en.wikipedia.org/wiki/Prime_gap
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
class GapInPrimes {
    public static long[] Gap(int gap, long start, long end) {
      long current = start,lastPrime = 0;    //initialize
      
      if(is_prime(current)) 
        lastPrime = current; //find the first prime and update the last to be the same
      
        while(current <= end){
          if (is_prime(current)){
            if (current - lastPrime == gap)             //check if gap is the same, then return the result
              return new long[] { lastPrime, current};
            
            lastPrime = current;      //update the last prime to current for next process
          }
          current++;
        }
      return null;
}


static bool is_prime (long n){
  if (n == 2) return true; //2 is the first prime
  if(n <= 1 || n % 2 == 0) return false; //non prime
  
  //method https://stackoverflow.com/questions/15743192/check-if-number-is-prime-number
  var boundary = (int)Math.Floor(Math.Sqrt(n)); 
    for (int i = 3; i <= boundary; i += 2)
        if (n % i == 0)
            return false;
    
    return true;    
}
}        


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class GapInPrimesTests {

    private static Random rnd = new Random();

[Test]
    public static void test1() {
        Assert.AreEqual(new long[] {101, 103}, GapInPrimes.Gap(2,100,103));
        Assert.AreEqual(new long[] {101, 103}, GapInPrimes.Gap(2,100,110));
        Assert.AreEqual(new long[] {103, 107}, GapInPrimes.Gap(4,100,110));
        Assert.AreEqual(null, GapInPrimes.Gap(6,100,110));
        Assert.AreEqual(new long[] {359, 367}, GapInPrimes.Gap(8,300,400));
        Assert.AreEqual(new long[] {337, 347}, GapInPrimes.Gap(10,300,400));
        
        Assert.AreEqual(new long[] {30109, 30113}, GapInPrimes.Gap(4,30000,100000));
        Assert.AreEqual(new long[] {30091, 30097}, GapInPrimes.Gap(6,30000,100000));
        Assert.AreEqual(new long[] {30161, 30169}, GapInPrimes.Gap(8,30000,100000));
        Assert.AreEqual(null, GapInPrimes.Gap(11,30000,100000));
        Assert.AreEqual(new long[] {1000037, 1000039}, GapInPrimes.Gap(2,1000000,1100000));
        //Assert.AreEqual(new long[] {10000139, 10000141}, GapInPrimes.Gap(2,10000000,11000000));
    }
    
    
    //-----------------------
    private static Boolean PrimeSol(long n) 
    {
        if (n == 2) return true;
        else if ((n < 2) || (n % 2 == 0)) return false;
        else {
            for (long i = 3; i <= Math.Sqrt(n); ++i) {
                if (n % i == 0) return false;
            }
            return true;
        }
    }
    public static long[] GapSol(int g, long m, long n) 
    {
        long[] res = new long[2];
        long i = m;
        while (i < n + 1) {
            if (PrimeSol(i)) {
                res[0] = i;
                break;
            }
            i++;
        }
        Boolean cont = true;
        while (cont) {
            long j = i + 1;
            while (j < n + 1) {
                if (PrimeSol(j)) {
                    if (j - i == g) {
                        res[1] = j;
                        return res;
                    } else {
                        res[0] = j;
                        i = j;
                    }
                }
                j++;
            }
            cont = false;
        }
        return null;
    }
    //-----------------------
[Test]    
    public static void RandomTest() {
      Console.WriteLine("Random Tests");
      for (int i = 0; i < 100; i++) { 
        long n = 0;
        if (rnd.Next(0, 99) % 5 == 0)
            n = (long)rnd.Next(1000, 2000); 
        else n = (long)rnd.Next(100000, 1000000); 
        Assert.AreEqual(GapSol(2, n, n + 1000), GapInPrimes.Gap(2, n, n + 1000));
        Assert.AreEqual(GapSol(4, n, n + 1000), GapInPrimes.Gap(4, n, n + 1000));
        Assert.AreEqual(GapSol(6, n, n + 1000), GapInPrimes.Gap(6, n, n + 1000));
        Assert.AreEqual(GapSol(8, n, n + 1000), GapInPrimes.Gap(8, n, n + 1000));
        Assert.AreEqual(GapSol(10, n, n + 100), GapInPrimes.Gap(10, n, n + 100));
      }
    }  
}
