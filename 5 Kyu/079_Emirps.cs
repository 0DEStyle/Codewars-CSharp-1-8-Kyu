/*Challenge link:https://www.codewars.com/kata/55de8eabd9bef5205e0000ba/train/csharp
Question:
If you reverse the word "emirp" you will have the word "prime". That idea is related with the purpose of this kata: we should select all the primes that when reversed are a different prime (so palindromic primes should be discarded).

For example: 13, 17 are prime numbers and the reversed respectively are 31, 71 which are also primes, so 13 and 17 are "emirps". But primes 757, 787, 797 are palindromic primes, meaning that the reversed number is the same as the original, so they are not considered as "emirps" and should be discarded.

The emirps sequence is registered in OEIS as A006567

Your task
Create a function that receives one argument n, as an upper limit, and the return the following array:

[number_of_emirps_below_n, largest_emirp_below_n, sum_of_emirps_below_n]

Examples
find_emirp(10)
[0, 0, 0] ''' no emirps below 10 '''

find_emirp(50)
[4, 37, 98] ''' there are 4 emirps below 50: 13, 17, 31, 37; largest = 37; sum = 98 '''

find_emirp(100)
[8, 97, 418] ''' there are 8 emirps below 100: 13, 17, 31, 37, 71, 73, 79, 97; largest = 97; sum = 418 '''
Happy coding!!

Advise: Do not use a primality test. It will make your code very slow. Create a set of primes using a prime generator or a range of primes producer. Remember that search in a set is faster that in a sorted list or array
*/

//***************Solution********************
using System;
public class Emirps {
  //check if current prime is the same as reverse prime
  //output format: [number_of_emirps_below_n, largest_emirp_below_n, sum_of_emirps_below_n]
  public static long[] FindEmirp(long n){
    long count = 0, sum = 0, lastEm = -1;
    
    for (long l = 13; l <= n; l += 2) {
      if(isPrime(l)){              
        long rev = reverseLong(l);
        if ((rev != l) && isPrime(rev)) {
          lastEm = l;
          sum += l;
          count++;
        }
      }
    }
    return new long[3] { count, lastEm, sum };
  }
  
  //function to reverse number, convert to string, reverse and convert back to long.
  private static long reverseLong(long s) {
      char[] arr = s.ToString().ToCharArray();
      Array.Reverse(arr);
      return long.Parse(new string(arr));
  }
  
  //function to check if number is prime.
  private static Boolean isPrime(long n) {
    if (n == 2) return true;
    if (n % 2 == 0) return false;
    for (long i = 3; i <= Math.Sqrt(n) + 1; i += 2){
      if(n % i == 0)
        return false;
    }
    return true;
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class EmirpsTests 
{
    private static string Array2String( long[] list )
    {
        return "[" + string.Join(", ", list) + "]";
    }
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
    public static void tests(long[] list1, long[][] results)
    {
        for (int i = 0; i < list1.Length; i++)
            testing(EmirpsTests.Array2String(Emirps.FindEmirp(list1[i])), EmirpsTests.Array2String(results[i]));
        return;
    }  
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests FindEmirp");
        long[] l = new long[] {50, 100, 200, 500, 750, 1000};
        long[][] r = new long[][] { new long[] {4, 37, 98}, new long[] {8, 97, 418}, new long[] {15, 199, 1489}, new long[] {20, 389, 3232}, 
            new long[] {25, 743, 6857}, new long[] {36, 991, 16788} };
        tests(l, r);
    }
[Test]
    public static void test2() 
    {        
        Console.WriteLine("Medium Tests FindEmirp");
        long[] l = new long[] {3000, 7000, 10000, 15000, 20000};
        long[][] r = new long[][] { new long[] {96, 1979, 103268}, new long[] {147, 3929, 278175}, new long[] {240, 9967, 1076242}, 
          new long[] {446, 14957, 3661772}, new long[] {627, 19973, 6827225} };
        tests(l, r);
    }
[Test]
    public static void test3() 
    {        
        Console.WriteLine("Bigger Values Tests FindEmirp");
        long[] l = new long[] {50000, 75000, 100000, 120000, 200000, 500000};
        long[][] r = new long[][] { new long[] {980, 39989, 19183366}, new long[] {1135, 74959, 30404879}, new long[] {1646, 99989, 76002998}, 
          new long[] {2205, 119993, 137429553}, new long[] {4278, 199961, 470781280}, new long[] {6700, 399941, 1317845448} };
        tests(l, r);
    }
//
  private static string reverseStringSol(string s) 
  {
      char[] arr = s.ToCharArray();
      Array.Reverse(arr);
      return new string(arr);
  }
  private static Boolean isPrimeSol(long n) 
  {
      if (n == 2) return true;
      if (n % 2 == 0) return false;
      for (long i = 3; i <= Math.Sqrt(n) + 1; i += 2) 
          if(n % i == 0) return false;
      return true;
  }
  private static long[] FindEmirpSol(long n)
  {
      long[] ans = new long[3]; int st = 13; long sm = 0; long cnt = 0; long last = -1;
      for (long i = st; i <= n; i += 2) 
      {
          if(isPrimeSol(i)) 
          {
              string ri = reverseStringSol(i.ToString());
              long rinb = long.Parse(ri);
              if ((rinb != i) && isPrimeSol(rinb)) 
              {
                  last = i;
                  sm += i;
                  cnt++;
              }
          }
      }
      ans[0] = cnt; ans[1] = last; ans[2] = sm;
      return ans;
  }
  private static Random rnd = new Random();
  private static void wTests() 
  {
      for (int i = 0; i < 10; i++) 
      {
          int n = rnd.Next(300000, 500000);
          testing(Array2String(Emirps.FindEmirp(n)), Array2String(FindEmirpSol(n)));
      }
  }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* FindEmirp");
        wTests();
    } 
}
