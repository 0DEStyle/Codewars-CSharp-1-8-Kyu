/*Challenge link:https://www.codewars.com/kata/54d496788776e49e6b00052f/train/csharp
Question:
Given an array of positive or negative integers

 I= [i1,..,in]

you have to produce a sorted array P of the form

[ [p, sum of all ij of I for which p is a prime factor (p positive) of ij] ...]

P will be sorted by increasing order of the prime numbers. The final result has to be given as a string in Java, C#, C, C++ and as an array of arrays in other languages.

Example:
I = {12, 15}; // result = "(2 12)(3 27)(5 15)"
[2, 3, 5] is the list of all prime factors of the elements of I, hence the result.

Notes:

It can happen that a sum is 0 if some numbers are negative!
Example: I = [15, 30, -45] 5 divides 15, 30 and (-45) so 5 appears in the result, the sum of the numbers for which 5 is a factor is 0 so we have [5, 0] in the result amongst others.

In Fortran - as in any other language - the returned string is not permitted to contain any redundant trailing whitespace: you can use dynamically allocated character strings.
*/

//***************Solution********************
/*better description:
In (3 27), 27 comes from 12 + 15 because both are multiples of 3.
(2 12), only 12 contains factor of 2
(5 15), only 15 contains factor of 5
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class SumOfDivided {
	
	public static string sumOfDivided(int[] lst) {
    //Console.WriteLine(string.Join(", ",lst));
    //res to store result, primeNums list to store factors
    var res = "";
    List<int> primeNums = new List<int>();
    
    //start from i = 2, using lst.Max(Math.Abs) to find the upperbound of the list.
    for(int i = 2; i <= lst.Max(Math.Abs); i++){
      //x is the current element, if element in primeNums isn't repeating and is a factor to element in lst.
      //add to primeNums, using string interpolation to append and format the string.
      if(primeNums.All(x => i % x != 0) && lst.Any(x => x % i == 0)){
        Console.WriteLine(i);
        primeNums.Add(i);
        res += $"({i} {lst.Where(x => Math.Abs(x) % i == 0).Sum()})";
      }
    }
    return res;
  }
}

//solution 2
using System;
using System.Linq;

public class SumOfDivided {
	public static string sumOfDivided(int[] lst) =>
    string.Join(string.Empty, getPrimeFactors(lst).Select(p =>
    {
      var sum = lst.Where(i => i % p == 0).Sum();
      return $"({p} {sum})";
    }));
  
	private static int[] getPrimeFactors(int[] lst) {
    var factors = lst
      .SelectMany(i => Enumerable.Range(2, Math.Abs(i)).Where(f => i % f == 0))
      .Distinct();

    return factors
      .Where(p => factors.Count(f => p % f == 0) == 1)
      .OrderBy(p => p)
      .ToArray();
  }
}

//solution 3
public class SumOfDivided {
	
	public static string sumOfDivided(int[] lst) {
	    int[] rem = new int[lst.Length];
	    int max = 0;
	    string result = "";
	    for (int i = 0; i < lst.Length; ++i) {
	        rem[i] = System.Math.Abs(lst[i]);
	        max = System.Math.Max(max, System.Math.Abs(lst[i]));
	    }
	    for (int fac = 2; fac <= max; ++fac) {
	        bool isFactor = false;
	        int tot = 0;
	        for (int i = 0; i < lst.Length; ++i) {
	            if (rem[i] % fac == 0) {
	                isFactor = true;
	                tot += lst[i];
	                while (rem[i] % fac == 0) {
	                    rem[i] /= fac;
	                }
	            }
	        }
	        if (isFactor) {
	            result += "(" + fac + " " + tot + ")";
	        }
	    }
	    return result;
	}
}

//solution 4
using System;
using System.Collections.Generic;
using System.Linq;

public class SumOfDivided {
	
	public static string sumOfDivided(int[] lst) {
    var factors = new Dictionary<int, int>();
    foreach (var num in lst)
    {
      var remaining = num;
      for (int i = 2; Math.Abs(remaining) > 1; i++)
      {
        if (remaining % i == 0)
        {
          factors[i] = factors.ContainsKey(i) ? factors[i] + num : num;
          while (remaining % i == 0) 
          { 
            remaining /= i;
          }
        }
      }
    }
    return string.Concat(factors.OrderBy(kvp => kvp.Key).Select(kvp => $"({kvp.Key} {kvp.Value})"));
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class SumOfDividedTests 
{

    public static string Array2String(int[] list )
    {
        return "[" + string.Join(", ", list) + "]";
    }
    private static void testing(int[] l, string exp) {
        //Console.WriteLine("Testing: " + Array2String(l));
        string ans = SumOfDivided.sumOfDivided(l);
        //Console.WriteLine("Actual: " + ans);
        //Console.WriteLine("Expect: " + exp);
        //Console.WriteLine(exp == ans);
        Assert.AreEqual(exp, ans);
   }
    
[Test]
    public static void test1() 
    {        
        int[] lst = new int[] {12, 15};
        testing(lst, "(2 12)(3 27)(5 15)");       
        lst = new int[] {15,21,24,30,45};
        testing(lst, "(2 54)(3 135)(5 90)(7 21)");     
        lst = new int[] {107, 158, 204, 100, 118, 123, 126, 110, 116, 100};
        testing(lst, "(2 1032)(3 453)(5 310)(7 126)(11 110)(17 204)(29 116)(41 123)(59 118)(79 158)(107 107)");       
        lst = new int[] {-29804, -4209, -28265, -72769, -31744};
        testing(lst, "(2 -61548)(3 -4209)(5 -28265)(23 -4209)(31 -31744)(53 -72769)(61 -4209)(1373 -72769)(5653 -28265)(7451 -29804)");        
        lst = new int[] {17, -17, 51, -51};
        testing(lst, "(3 0)(17 0)");      
        lst = new int[] {173471};
        testing(lst, "(41 173471)(4231 173471)");     
        lst = new int[] {100000, 1000000};
        testing(lst, "(2 1100000)(5 1100000)");
    }
    //-----------------------
    public static string sumOfDividedPRIX(int[] lst) {
        int[] rem = new int[lst.Length];
        int max = 0;
        string result = "";
        for (int i = 0; i < lst.Length; ++i) {
            rem[i] = Math.Abs(lst[i]);
            max = Math.Max(max, Math.Abs(lst[i]));
        }
        for (int fac = 2; fac <= max; ++fac) {
            bool isFactor = false;
            int tot = 0;
            for (int i = 0; i < lst.Length; ++i) {
                if (rem[i] % fac == 0) {
                    isFactor = true;
                    tot += lst[i];
                    while (rem[i] % fac == 0) {
                        rem[i] /= fac;
                    }
                }
            }
            if (isFactor) {
                result += "(" + fac + " " + tot + ")";
            }
        }
        return result;
    }   
    //-----------------------
    private static Random rnd = new Random();
    private static int randint(Random rnd, int min, int max) {
        int randomNumber = rnd.Next(max - min) + min;
        return randomNumber;
    }
    public static int[] doEx(int k)
    {
        int i = 0;
        int[] res = new int[k];
        int rn;
        while (i < k)
        {
            int q = rnd.Next(0, 100);
            if (q % 5 == 0)
              rn = -rnd.Next(50, 100);
            else
              rn = rnd.Next(50, 200);
            res[i] = rn;
            i++;
        }
        return res;
    }
    public static void wTests1() {
        for (int i = 0; i < 50; i++) {
            int[] v = doEx(randint(rnd, 5, 25));           
            String exp = sumOfDividedPRIX(v);
            testing(v, exp);
        }
    }
    
[Test] 
    public static void RandomTests() 
    { 
        wTests1();
    } 
}
