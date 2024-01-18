/*Challenge link:https://www.codewars.com/kata/55eec0ee00ae4a8fa0000075/train/csharp
Question:
The prime 149 has 3 permutations which are also primes: 419, 491 and 941.

There are 3 primes below 1000 with three prime permutations:

149 ==> 419 ==> 491 ==> 941
179 ==> 197 ==> 719 ==> 971
379 ==> 397 ==> 739 ==> 937
But there are 9 primes below 1000 with two prime permutations:

113 ==> 131 ==> 311
137 ==> 173 ==> 317
157 ==> 571 ==> 751
163 ==> 613 ==> 631
167 ==> 617 ==> 761
199 ==> 919 ==> 991
337 ==> 373 ==> 733
359 ==> 593 ==> 953
389 ==> 839 ==> 983
Finally, we can find 34 primes below 1000 with only one prime permutation:

[13, 17, 37, 79, 107, 127, 139, 181, 191, 239, 241, 251, 277, 281, 283, 313, 347, 349, 367, 457, 461, 463, 467, 479, 563, 569, 577, 587, 619, 683, 709, 769, 787, 797]
Each set of permuted primes are represented by its smallest value, for example the set 149, 419, 491, 941 is represented by 149, and the set has 3 permutations.

Notes

the original number (149 in the above example) is not counted as a permutation;
permutations with leading zeros are not valid
Your Task
Your task is to create a function that takes two arguments:

an upper limit (n_max) and
the number of prime permutations (k_perms) that the primes should generate below n_max
The function should return the following three values as a list:

the number of permutational primes below the given limit,
the smallest prime such prime,
and the largest such prime
If no eligible primes were found below the limit, the output should be [0, 0, 0]

Examples
Let's see how it would be with the previous cases:

permutational_primes(1000, 3) ==> [3, 149, 379]
''' 3 primes with 3 permutations below 1000, smallest: 149, largest: 379 '''

permutational_primes(1000, 2) ==> [9, 113, 389]
''' 9 primes with 2 permutations below 1000, smallest: 113, largest: 389 '''

permutational_primes(1000, 1) ==> [34, 13, 797]
''' 34 primes with 1 permutation below 1000, smallest: 13, largest: 797 '''
Happy coding!!
*/

//***************Solution********************
/*
    ∧＿∧
　 (｡･ω･｡)つ━☆・*。
  ⊂/　     /　   ・゜
　しーＪ　　　     °。+ * 。　
　　　　　                      .・゜
　　　　　                      ゜｡ﾟﾟ･｡･ﾟﾟ。
　　　　                         　ﾟ。　 　｡ﾟ
                                              　ﾟ･｡･ﾟ ૮˶• ﻌ •˶ა
                                                             ./づ~ /づ🦴
args n(upper limtit), k(num of permutation prime)
Output : [totalPrime, minPrime, maxPrime]
*/
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata {
  //Generate primes up to n and store in stack
  private static List<int> primeStack(int n){
    var stack = new List<int>{};
    
    for(int i = 2; i <= n; i++){
      if(primeCheck(i,stack))
        stack.Add(i);
      }
    return stack;
  }
  
  //method to check if prime from stack
  private static bool primeCheck(int x, List<int> stack){
    foreach(int item in stack)
        if(x % item == 0) 
          return false;
  return true;
  }
  
  public static (int,int,int) PermutationalPrimes(int n, int cap) {
    //get all prime numbers up to n
    var primes = primeStack(n);
    //Console.WriteLine(string.Join(",", primes));
    
    //x is the current element, i is index, _ is nothing
    //convert current prime number to string, sort its digits in ascending order,
    //create variables 
    //numPermutations where it is equal to i.Count - 1 (because i start at 0),  currentPrime = i.Min()
    //get elements where x.numPermutations == cap
    var permutations = primes.GroupBy(x => 
                                    string.Concat(x.ToString().OrderBy(x => x)), 
                                    x=>x,
                                    (_, i) => new {numPermutations = i.Count() - 1, currentPrime = i.Min()})
                             .Where(x => x.numPermutations == cap)
                             .Select(x => x.currentPrime);
    
    //check result
    //Console.WriteLine(string.Join(",", permutations));
    
    //format and return result
    return (permutations.Count(), permutations.Min(), permutations.Max());
  }
}

//****************Sample Test*****************
namespace Solution {
  
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test(Description = "Fixed Tests")]
    public void FixedTests() 
    {
      Act((3, 149, 379), 1000, 3);
      Act((9, 113, 389), 1000, 2);
      Act((34, 13, 797), 1000, 1);
    }
    
    [Test(Description = "Random Tests")] 
    public void RandomTests50([Random(5000, 50001, 6)] int n, [Random(1, 11, 5)]int k) => DoTest(n, k);
    
    private void DoTest(int n, int k)
    {
      var expected = reference(n, k);
      Act(expected, n, k);
      (int, int, int) reference(int n, int k) {
        var h = new Dictionary<int, HashSet<int>>();
        var q = new Dictionary<string, int>();
        var (a, b, c) = (n, 0, 0);
        for (int m = 2; m <= n; m++) {
          if (IsPrime(m)) {
            var s = Hash(m);
            if (q.ContainsKey(s)) {
              var u = q[s];
              h[u].Add(m);
            } else {
              q.Add(s, m);
              h.Add(m, new HashSet<int>());
            }
          }
        }
        foreach (var e in h) {
          if (e.Value.Count == k) {
            a = Math.Min(a, e.Key);
            b = Math.Max(b, e.Key);
            c++;
          }
        }
        return (c,a,b);
        string Hash(int n) => string.Concat(n.ToString().OrderBy(_=>_));
        bool IsPrime(int n) {
          if (n<2 || n%2==0 || n%3==0) return n==2 || n==3;
          for (int p=5; p*p<=n; p+=6) if (n%p==0 || n%(p+2)==0) return false;
          return true;
        }
      }
    }
    
    static void Act((int, int, int) expected, int n, int k) {
      var actual = Kata.PermutationalPrimes(n, k);
      Assert.AreEqual(expected, actual, $"\n n = {n}\n k = {k}\n");
    }
  }
}
