/*Challenge link:https://www.codewars.com/kata/5d6ee508aa004c0019723c1c/train/csharp
Question:
Integral numbers can be even or odd.

Even numbers satisfy n = 2m ( with m also integral ) and we will ( completely arbitrarily ) think of odd numbers as n = 2m + 1.
Now, some odd numbers can be more odd than others: when for some n, m is more odd than for another's. Recursively. :]
Even numbers are just not odd.

Task
Given a finite list of integral ( not necessarily non-negative ) numbers, determine the number that is odder than the rest.
If there is no single such number, no number is odder than the rest; return Nothing, null or a similar empty value.

Examples
Kata.Oddest(new int[] { 1, 2 }) => 1
Kata.Oddest(new int[] { 1, 3 }) => 3
Kata.Oddest(new int[] { 1, 5 }) => null
Hint
Click here.
How odd is -1 ?
*/

//***************Solution********************
/*
Better description
Integrals numbers (i.e. integers) can be even or odd.

For a given number, n, even numbers satisfy the equation n = 2m, while odd numbers satisfy the equation n = 2m + 1,
where m is also an integral number. Now, some odd numbers can be more odd than others.
An odd number's oddness can be determined using the above definition recursively, 
where a number is more odd if m is also odd. Even numbers are, of course, the least odd.

Task
Given a finite list of integral (not necessarily positive) numbers, determine which number is odder than the rest. 
If there is no single such number, return Nothing, null or the appropriate empty value for the given language.

*/
using System;
using System.Linq;

public class Kata {
  public static int? Oddest(int[] a) {
    Console.WriteLine("List: " + string.Join(",", a));
    
    //validation check
    if(a.Length == 0 || a == null) return null;
    if(a.Length == 1) return a[0];
    if(a.All(x => x == -1)) return null;
    else{
    //collect odds and evens into arrays
    int[] oddNums = a.Where(x => x % 2 != 0).ToArray();
    int[] evenNums = a.Where(x => x % 2 == 0).ToArray();
    
    //if odds is nothing return null, 
    //else select all x element, right shift 1, store in array
    //pass the array into Oddest recursively
    if(oddNums.Length == 0) return null;
    else if(evenNums.Length == 0){
      int? m = Oddest(a.Select(x => x >> 1).ToArray());
      Console.WriteLine("m:" + m);
      return m ==  null ? null : (2 * m) + 1;
    }
    //pass oddNums into Oddest recursively
    return Oddest(oddNums);
    }
  }
}


//solution 2
using System;
using System.Linq;

public class Kata 
{
  public static int? Oddest(int[] a) => a.Count(x => P(x) == a.Max(P)) == 1 ? a?.First(x => P(x) == a.Max(P)) : null;
  private static int P(int n) => n == -1 ? 32 : n%2 == 0 ? 0 : 1 + P((n-1)/2);
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest {
    [Test]
    public void ExampleTests() {
      Assert.AreEqual(1, Kata.Oddest(new int[] { 1, 2 }));
      Assert.AreEqual(3, Kata.Oddest(new int[] { 1, 3 }));
      Assert.AreEqual(null, Kata.Oddest(new int[] { 1, 5 }));
    }
    
    [Test]
    public void FixedTests() {
      Assert.AreEqual(null, Kata.Oddest(new int[] { }));
      Assert.AreEqual(0, Kata.Oddest(new int[] { 0 }));
      Assert.AreEqual(1, Kata.Oddest(new int[] { 0, 1 }));
      Assert.AreEqual(7, Kata.Oddest(new int[] { 1, 3, 5, 7 }));
      Assert.AreEqual(null, Kata.Oddest(new int[] { 2, 4 }));
      Assert.AreEqual(-1, Kata.Oddest(new int[] { -1 }));
      Assert.AreEqual(null, Kata.Oddest(new int[] { -1, -1 }));
      Assert.AreEqual(-1, Kata.Oddest(new int[] { -1, 0, 1 }));
      Assert.AreEqual(3, Kata.Oddest(new int[] { -3, 3 }));
      Assert.AreEqual(null, Kata.Oddest(new int[] { -5, 3 }));
      Assert.AreEqual(31, Kata.Oddest(Enumerable.Range(0, 42).ToArray()));
      Assert.AreEqual(-1, Kata.Oddest(Enumerable.Range(-42, 42).ToArray()));
    }
    
    private Nullable<int> Sol(int[] a) {
      if (a.Length == 0) return null;
      else if (a.Length == 1) return a[0];
      else if (a.All(n => n == -1)) return null;
      else {
        int[] odds = a.Where(x => x % 2 != 0).ToArray();
        int[] evens = a.Where(x => x % 2 == 0).ToArray();
        if (odds.Length == 0) return null;
        else if (evens.Length == 0) {
          Nullable<int> r = Sol(a.Select(n => n >> 1).ToArray());
          return r == null ? null : r * 2 + 1;
        } else {
          return Sol(odds);
        }
      }
    }
    
    [Test]
    public void RandomTests() {
      Random rng = new Random();
      for (int i = 0; i < 100; i++) {
        int[] xs = Enumerable.Range(1, rng.Next(51)).Select(_ => rng.Next(-100, 100)).ToArray();
        Assert.AreEqual(Sol(xs), Kata.Oddest(xs));
      }
    }
  }
}
