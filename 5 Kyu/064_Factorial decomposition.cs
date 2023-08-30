/*Challenge link:https://www.codewars.com/kata/5a045fee46d843effa000070/train/csharp
Question:
The aim of the kata is to decompose n! (factorial n) into its prime factors.

Examples:

n = 12; decomp(12) -> "2^10 * 3^5 * 5^2 * 7 * 11"
since 12! is divisible by 2 ten times, by 3 five times, by 5 two times and by 7 and 11 only once.

n = 22; decomp(22) -> "2^19 * 3^9 * 5^4 * 7^3 * 11^2 * 13 * 17 * 19"

n = 25; decomp(25) -> 2^22 * 3^10 * 5^6 * 7^3 * 11^2 * 13 * 17 * 19 * 23
Prime numbers should be in increasing order. When the exponent of a prime is 1 don't put the exponent.

Notes

the function is decomp(n) and should return the decomposition of n! into its prime factors in increasing order of the primes, as a string.
factorial can be a very big number (4000! has 12674 digits, n can go from 300 to 4000).
In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
*/

//***************Solution********************
using System;
using System.Linq;
using System.Collections.Generic;

class FactDecomp{
    public static string Decomp(int n){
      //if n is 0 or 1, return "1"
        if (n == 0 || n == 1) 
          return "1";
      
      //create dictionary d
        Dictionary<int, int> d = new Dictionary<int, int>();
      
      //
        for (int i = 2; i <= n; i++){
            var num = i;
            foreach (var key in d.Keys.ToArray()){
              //Console.WriteLine(key);
              //if num mod key is 0, increase d[key] by 1,  num = num / key
                while (num % key == 0){
                    d[key]++;
                    num /= key;
                }
            }
          //if key is not 1, add (num,1) into d
            if (num != 1) 
              d.Add(num, 1);
        }
      //set the correct format and return result.
        return string.Join(" * ", d.Select(x => x.Value > 1 ? $"{x.Key}^{x.Value}" : $"{x.Key}"));
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text;

[TestFixture]
public class FactDecompTest
{
    private static void testing(int n, string expected) {
		    Console.WriteLine("n: {0}, expected: {1}\n", n, expected);
        Assert.AreEqual(expected, FactDecomp.Decomp(n));
    }
    [Test]
    public static void test() {
        testing(17, "2^15 * 3^6 * 5^3 * 7^2 * 11 * 13 * 17");
        testing(5, "2^3 * 3 * 5");
        testing(22, "2^19 * 3^9 * 5^4 * 7^3 * 11^2 * 13 * 17 * 19");
        testing(14, "2^11 * 3^5 * 5^2 * 7^2 * 11 * 13");
        testing(25, "2^22 * 3^10 * 5^6 * 7^3 * 11^2 * 13 * 17 * 19 * 23");

        testing(45, "2^41 * 3^21 * 5^10 * 7^6 * 11^4 * 13^3 * 17^2 * 19^2 * 23 * 29 * 31 * 37 * 41 * 43");
        testing(48, "2^46 * 3^22 * 5^10 * 7^6 * 11^4 * 13^3 * 17^2 * 19^2 * 23^2 * 29 * 31 * 37 * 41 * 43 * 47");
        testing(35, "2^32 * 3^15 * 5^8 * 7^5 * 11^3 * 13^2 * 17^2 * 19 * 23 * 29 * 31");
        testing(23, "2^19 * 3^9 * 5^4 * 7^3 * 11^2 * 13 * 17 * 19 * 23");
        testing(35, "2^32 * 3^15 * 5^8 * 7^5 * 11^3 * 13^2 * 17^2 * 19 * 23 * 29 * 31");

        testing(79, "2^74 * 3^36 * 5^18 * 7^12 * 11^7 * 13^6 * 17^4 * 19^4 * 23^3 * 29^2 * 31^2 * 37^2 * 41 * 43 * 47 * 53 * 59 * 61 * 67 * 71 * 73 * 79");
        testing(66, "2^64 * 3^31 * 5^15 * 7^10 * 11^6 * 13^5 * 17^3 * 19^3 * 23^2 * 29^2 * 31^2 * 37 * 41 * 43 * 47 * 53 * 59 * 61");
        testing(98, "2^95 * 3^46 * 5^22 * 7^16 * 11^8 * 13^7 * 17^5 * 19^5 * 23^4 * 29^3 * 31^3 * 37^2 * 41^2 * 43^2 * 47^2 * 53 * 59 * 61 * 67 * 71 * 73 * 79 * 83 * 89 * 97");
        testing(95, "2^89 * 3^45 * 5^22 * 7^14 * 11^8 * 13^7 * 17^5 * 19^5 * 23^4 * 29^3 * 31^3 * 37^2 * 41^2 * 43^2 * 47^2 * 53 * 59 * 61 * 67 * 71 * 73 * 79 * 83 * 89");
        testing(70, "2^67 * 3^32 * 5^16 * 7^11 * 11^6 * 13^5 * 17^4 * 19^3 * 23^3 * 29^2 * 31^2 * 37 * 41 * 43 * 47 * 53 * 59 * 61 * 67");
    }
    //-----------------------
    private static Random rnd = new Random();
	  public static string DecompEF(int n)
	  {
		    int[] primePower = new int[n + 1];
		    while (n > 1)
		    {
			      int befn = n--;
			      for (int i = 2; i <= Math.Sqrt(befn); i++)
			      {
			          if (befn % i == 0)
			          {
				            befn /= i;
				            primePower[i]++;
				            i = 1;
			          }
			      }
			      primePower[befn]++;
		    }
		    StringBuilder result = new StringBuilder();
		    for (int i = 2; i < primePower.Length; i++)
		    {
			      if (primePower[i] == 0)
				        continue;
			      else if (primePower[i] == 1)
				        result.Append(i + " * ");
			      else
				        result.Append(i + "^" + primePower[i] + " * ");
		  }
	    string s = result.ToString();
		  return s.Substring(0,result.Length - 3);
	  }
	  public static void wTests() {
        Console.WriteLine("Random Tests");
        for (int i = 0; i < 100; i++) {
            int n = rnd.Next(300, 4000);
            testing(n, DecompEF(n));
        }
    }
    //-----------------------
    [Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* Decomp");
        wTests();
    } 
}
