/*Challenge link:https://www.codewars.com/kata/55ef57064cb8418a3f000061/train/csharp
Question:
An array of different positive integers is given. We should create a code that gives us the number (or the numbers) that has (or have) the highest number of divisors among other data.

The function proc_arrInt(), (Javascript: procArrInt()) will receive an array of unsorted integers and should output a list with the following results:

[(1), (2), (3)]

(1) - Total amount of numbers received
(2) - Total prime numbers received
(3) - a list [(a), (b)]
      (a)- The highest amount of divisors that a certain number (or numbers) of the given  
           array have
      (b)- A sorted list with the numbers that have the largest amount of divisors. The list may  
           have only one number
Examples
arr1 = [66, 36, 49, 40, 73, 12, 77, 78, 76, 8, 50,
       20, 85, 22, 24, 68, 26, 59, 92, 93, 30]

proc_arrInt(arr1) ------> [21, 2, [9, [36]]

# 21 integers in the array
# 2 primes: 73 and 97
# 36 is the number that has the highest amount of divisors:
# 1, 2, 3, 4, 6, 9, 12, 18, 36 (9 divisors, including 1 and 36)
Another case:

arr2 = [267, 273, 271, 145, 275, 150, 487, 169, 428, 50, 314, 444, 445,
        67, 458, 211, 58, 95, 357, 486, 359, 491, 108, 493, 247, 379]

proc_arrInt(arr2) ------> [26, 7, [12, [108, 150, 444, 486]]]

# 26 integers in the array
# 7 primes: 271, 487, 67, 211, 359, 491, 379
# 108, 150, 444 and 486 have the highest amount of divisors:
# 108: [1, 2, 3, 4, 6, 9, 12, 18, 27, 36, 54, 108] (12 divisors)
# 150: [1, 2, 3, 5, 6, 10, 15, 25, 30, 50, 75, 150] (12 divisors)
# 444: [1, 2, 3, 4, 6, 12, 37, 74, 111, 148, 222, 444] (12 divisors)
# 486: [1, 2, 3, 6, 9, 18, 27, 54, 81, 162, 243, 486] (12 divisors)
Happy coding!!


*/

//***************Solution********************
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata {
    public static (int, int, (int, int[])) ProcArrInt(int[] numbers) {
        int primes = 0, maxDivisor = 0;
      
        List<int> currMaxDivisor = new();
        foreach (var n in numbers) {
            var d = findDivisors(n);
          
          //count prime if there are only 2 divisor in a number.
          //ref https://www.youtube.com/watch?v=lAqH2dt7g5I
            if (d == 2) primes++;
          
          //remove the old max divisor from the list if the new one is bigger
            if (maxDivisor < d) {
                maxDivisor = d;
                currMaxDivisor.Clear();
                currMaxDivisor.Add(n);
            }
          //add the new one if both divisors are the same.
            else if (maxDivisor == d) currMaxDivisor.Add(n);
        }

        return (numbers.Length, primes, (maxDivisor, currMaxDivisor.OrderBy(v=>v).ToArray()));
    }
  
  //Find the number of divisors in a number
  //ref https://www.youtube.com/watch?v=Pbf8tScR_fg
    public static int findDivisors(int n) {
        int divisors = 2;
        for (int i = 2; i < Math.Sqrt(n + 1); i++)
            if (n % i == 0) divisors += n / i != i ? 2 : 1;
        return divisors;
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
      Act((21, 2, (9, new int[] { 36 })), new int[] { 66, 36, 49, 40, 73, 12, 77, 78, 76, 8, 50, 20, 85, 22, 24, 68, 26, 59, 92, 93, 30 });
      Act((26, 7, (12, new int[] { 108, 150, 444, 486 })), new int[] { 267, 273, 271, 145, 275, 150, 487, 169, 428, 50, 314, 444, 445, 67, 458, 211, 58, 95, 357, 486, 359, 491, 108, 493, 247, 379 });
    }
    
    [Test(Description = "Random Tests")]
    public void RandomTests([Random(5000, 50001, 100)] int k) => DoRandomTest(k);
    
    private void DoRandomTest(int k)
    {
      var rnd = new Random((int)(DateTime.Now.Ticks%int.MaxValue));
      var size = rnd.Next(100, 300);
      var numbers = Enumerable.Range(0, size).Select(_=>rnd.Next(2, k + 1)).Distinct().ToArray();
      DoTest(numbers);
    }
    
    private void DoTest(int[] numbers)
    {
      var expected = reference(numbers);
      Act(expected, numbers);
      (int, int, (int, int[])) reference(int[] numbers) {
        int primes = 0, best = 0;
        var bag = new HashSet<int>();
        foreach (var n in numbers) {
          var ds = DivisorCount(n);
          if (ds == 2) primes++;
          if (ds >= best) {
            if (ds > best) bag.Clear();
            bag.Add(n);
            best = ds;
          }
        }
        return (numbers.Length, primes, (best, bag.OrderBy(_=>_).ToArray()));
        int DivisorCount(int n) {
          int count = 1;
          for (int i=2; i*i<=n; i++) {
            if (n%i == 0) {
              count++;
              if (n/i != i) count++;
            }
          }
          if (n>1) count++;
          return count;
        }
      }
    }
    
    static string Print(IEnumerable<int> row) => $"[{string.Join(",",row)}]";
    
    static void Act((int, int, (int, int[])) expected, int[] numbers) => Assert.AreEqual(
      expected, 
      Kata.ProcArrInt(numbers),
      $"\n  numbers = {Print(numbers)}\n");
  }
}
