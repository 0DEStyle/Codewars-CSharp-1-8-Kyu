/*Challenge link:https://www.codewars.com/kata/55e7280b40e1c4a06d0000aa/train/csharp
Question:
John and Mary want to travel between a few towns A, B, C ... Mary has on a sheet of paper a list of distances between these towns. ls = [50, 55, 57, 58, 60]. John is tired of driving and he says to Mary that he doesn't want to drive more than t = 174 miles and he will visit only 3 towns.

Which distances, hence which towns, they will choose so that the sum of the distances is the biggest possible to please Mary and John?

Example:
With list ls and 3 towns to visit they can make a choice between: [50,55,57],[50,55,58],[50,55,60],[50,57,58],[50,57,60],[50,58,60],[55,57,58],[55,57,60],[55,58,60],[57,58,60].

The sums of distances are then: 162, 163, 165, 165, 167, 168, 170, 172, 173, 175.

The biggest possible sum taking a limit of 174 into account is then 173 and the distances of the 3 corresponding towns is [55, 58, 60].

The function chooseBestSum (or choose_best_sum or ... depending on the language) will take as parameters t (maximum sum of distances, integer >= 0), k (number of towns to visit, k >= 1) and ls (list of distances, all distances are positive or zero integers and this list has at least one element). The function returns the "best" sum ie the biggest possible sum of k distances less than or equal to the given limit t, if that sum exists, or otherwise nil, null, None, Nothing, depending on the language. In that case with C, C++, D, Dart, Fortran, F#, Go, Julia, Kotlin, Nim, OCaml, Pascal, Perl, PowerShell, Reason, Rust, Scala, Shell, Swift return -1.

Examples:
ts = [50, 55, 56, 57, 58] choose_best_sum(163, 3, ts) -> 163

xs = [50] choose_best_sum(163, 3, xs) -> nil (or null or ... or -1 (C++, C, D, Rust, Swift, Go, ...)

ys = [91, 74, 73, 85, 73, 81, 87] choose_best_sum(230, 3, ys) -> 228

Notes:
try not to modify the input list of distances ls
in some languages this "list" is in fact a string (see the Sample Tests). 
*/

//***************Solution********************

using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfK {
  public static int? chooseBestSum(int t, int k, List<int> ls){
    //t distance John is willing to travel
    //k number of town he will visit
    //ls distance between town
    //Console.WriteLine($"t:{t},k:{k},ls:{string.Join(",",ls)}");
    
    //not to modify the input list ls
    //from the list ls, get element that is less than or equal to t(distance)
    var _ls = ls.Where(x => x <= t);
    
    //if the list is empty, return null
    //from the new list _ls, select
    //current element + 
    //check if number of town is greater than 1, if so, use recursive function to select best Sum
    //by passing in total distance - current, number of town - 1, and skip current list _ls by index+1, store to list
    //else return 0
    //then select max combination with best possible sum from the list.
    return _ls.Count() == 0 ? null :
    _ls.Select((current, index) => current + (k > 1 ?
                                    chooseBestSum(t-current, k-1, _ls.Skip(index+1).ToList()) 
                                    : 0))
                                    .Max();
  }
}

//clearer solution
using System.Collections.Generic;
using System.Linq;

public static class SumOfK
{
  public static int? chooseBestSum(int t, int k, List<int> ls) =>
    ls.Combinations(k)
      .Select(c => (int?) c.Sum())
      .Where(sum => sum <= t)
      .DefaultIfEmpty()
      .Max();

  // Inspired by http://stackoverflow.com/questions/127704/algorithm-to-return-all-combinations-of-k-elements-from-n
  public static IEnumerable<IEnumerable<int>> Combinations(this IEnumerable<int> ls, int k) =>
    k == 0 ? new[] { new int[0] } :
      ls.SelectMany((e, i) =>
        ls.Skip(i + 1)
          .Combinations(k - 1)
          .Select(c => (new[] {e}).Concat(c)));
}

//****************Sample Test*****************
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class SumOfKTests {

[Test]
  public static void Test1() {
    Console.WriteLine("****** Basic Tests");    
    List<int> ts = new List<int> {50, 55, 56, 57, 58};
    int? n = SumOfK.chooseBestSum(163, 3, ts);
    Assert.AreEqual(163, n);

    ts = new List<int> {50}; 
    n = SumOfK.chooseBestSum(163, 3, ts);
    Assert.AreEqual(null, n);   

    ts = new List<int> {91, 74, 73, 85, 73, 81, 87};
    n = SumOfK.chooseBestSum(230, 3, ts);
    Assert.AreEqual(228, n);
    n = SumOfK.chooseBestSum(331, 2, ts);
    Assert.AreEqual(178, n);
    n = SumOfK.chooseBestSum(331, 4, ts);
    Assert.AreEqual(331, n);
    n = SumOfK.chooseBestSum(331, 5, ts);
    Assert.AreEqual(null, n);
    n = SumOfK.chooseBestSum(331, 1, ts);
    Assert.AreEqual(91, n);
    n = SumOfK.chooseBestSum(700, 8, ts);
    Assert.AreEqual(null, n);    
  }
[Test]
  public static void Test2() {
    Console.WriteLine("****** Basic Tests bigger numbers");    
    List<int> ts = new List<int> {100, 76, 56, 44, 89, 73, 68, 56, 64, 123, 2333, 144, 50, 132, 123, 34, 89};    
    int? n = SumOfK.chooseBestSum(230, 4, ts);
    Assert.AreEqual(230, n);
    n = SumOfK.chooseBestSum(430, 5, ts);
    Assert.AreEqual(430, n);
    n = SumOfK.chooseBestSum(430, 8, ts);
    Assert.AreEqual(null, n);
    n = SumOfK.chooseBestSum(880, 8, ts);
    Assert.AreEqual(876, n);
    n = SumOfK.chooseBestSum(2430, 15, ts);
    Assert.AreEqual(1287, n);
    n = SumOfK.chooseBestSum(100, 2, ts);
    Assert.AreEqual(100, n);
    n = SumOfK.chooseBestSum(276, 3, ts);
    Assert.AreEqual(276, n);
    n = SumOfK.chooseBestSum(3760, 17, ts);
    Assert.AreEqual(3654, n);
    n = SumOfK.chooseBestSum(3760, 40, ts);
    Assert.AreEqual(null, n);
    n = SumOfK.chooseBestSum(50, 1, ts);
    Assert.AreEqual(50, n);
    n = SumOfK.chooseBestSum(1000, 18, ts);
    Assert.AreEqual(null, n);

    ts = new List<int> {100, 64, 123, 2333, 144, 50, 132, 123, 34, 89}; 
    n = SumOfK.chooseBestSum(230, 4, ts);
    Assert.AreEqual(null, n);
    n = SumOfK.chooseBestSum(230, 2, ts);
    Assert.AreEqual(223, n);
    n = SumOfK.chooseBestSum(2333, 1, ts);
    Assert.AreEqual(2333, n);        
    n = SumOfK.chooseBestSum(2333, 8, ts);
    Assert.AreEqual(825, n);      

    ts = new List<int> {1000, 640, 1230, 2333, 1440, 500, 1320, 1230, 340, 890, 732, 1346}; 
    n = SumOfK.chooseBestSum(2300, 4, ts);
    Assert.AreEqual(2212, n);
    n = SumOfK.chooseBestSum(2300, 5, ts);
    Assert.AreEqual(null, n);
    n = SumOfK.chooseBestSum(2332, 3, ts);
    Assert.AreEqual(2326, n);
    n = SumOfK.chooseBestSum(23331, 8, ts);
    Assert.AreEqual(10789, n);
    n = SumOfK.chooseBestSum(331, 2, ts);
    Assert.AreEqual(null, n);
  }

  //--------------------
  public static IEnumerable<IEnumerable<T>> Comb1234<T>(this IEnumerable<T> elements, int k)
  {
    return k == 0 ? new[] { new T[0] } :
    elements.SelectMany((e, i) =>
          elements.Skip(i + 1).Comb1234(k - 1).Select(c => (new[] {e}).Concat(c)));
  }
  private static int? chooseBestSum1234(int t, int k, List<int> ls) {
    IEnumerable<IEnumerable<int>> res = Comb1234(ls, k);
    int mx = -1;
    foreach (var s in res) {
      int sm = 0;
      foreach (int n in s) {
        sm += n;
      }
      if ((sm >= mx) && (sm <= t)) {
        mx = sm;
      }
    }
    if (mx != -1) return mx; else return null;
  }
  //--------------------
[Test]
  public static void Test3() {
    Console.WriteLine("\n 40 Random Tests ****************");
    Random rnd = new Random();
    for (int i = 0; i < 40; i++) {  
      List<int> ts = new List<int> { };  
      for (int j = 0; j < 20; j++) 
      {
        int n = rnd.Next(10, 500);
        ts.Add(n);
      }
      int p = rnd.Next(1, 5);
      int k = rnd.Next(50, 2000);
      Assert.AreEqual(chooseBestSum1234(k, p, ts), SumOfK.chooseBestSum(k, p, ts));  
    }
  }
}
