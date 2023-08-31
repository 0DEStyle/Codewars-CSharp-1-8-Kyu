/*Challenge link:https://www.codewars.com/kata/54d7660d2daf68c619000d95/train/csharp
Question:

Common denominators

You will have a list of rationals in the form

{ {numer_1, denom_1} , ... {numer_n, denom_n} } 
or
[ [numer_1, denom_1] , ... [numer_n, denom_n] ] 
or
[ (numer_1, denom_1) , ... (numer_n, denom_n) ] 
where all numbers are positive ints. You have to produce a result in the form:

(N_1, D) ... (N_n, D) 
or
[ [N_1, D] ... [N_n, D] ] 
or
[ (N_1', D) , ... (N_n, D) ] 
or
{{N_1, D} ... {N_n, D}} 
or
"(N_1, D) ... (N_n, D)"
depending on the language (See Example tests) in which D is as small as possible and

N_1/D == numer_1/denom_1 ... N_n/D == numer_n,/denom_n.
Example:
convertFracs [(1, 2), (1, 3), (1, 4)] `shouldBe` [(6, 12), (4, 12), (3, 12)]
Note:
Due to the fact that the first translations were written long ago - more than 6 years - these first translations have only irreducible fractions.

Newer translations have some reducible fractions. To be on the safe side it is better to do a bit more work by simplifying fractions even if they don't have to be.

Note for Bash:
input is a string, e.g "2,4,2,6,2,8" output is then "6 12 4 12 3 12" 
*/

//***************Solution********************
//string format "(N_1, D) ... (N_n, D)"

using System.Linq;
using System;
public class Fracts {
  //Greatest common denominator, recursive
  private static long gcd(long a, long b) => b == 0 ? a : gcd(b, a%b);
  
  public static string convertFrac(long[,] lst) {
    //start from 0, count up to lst.GetLength(0), store in indices
    var indices = Enumerable.Range(0, lst.GetLength(0));
    
    //Aggregate indices, to get max denominator
    var d = indices.Aggregate(1L, (a,i) => a * lst[i,1] / gcd(a, lst[i, 1]));
    //Console.WriteLine(d);
    
    //string interpolation to fill in result in the correct format, then concatenate.
    return string.Concat(indices.Select(i => $"({d * lst[i,0] / lst[i,1]},{d})"));
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class FractsTests {

[Test]
  public void Test1() {
  
    long[,] lst = new long[,] { {1, 2}, {1, 3}, {1, 4} };
    Assert.AreEqual("(6,12)(4,12)(3,12)", Fracts.convertFrac(lst));
  
    lst = new long[,] { {69, 130}, {87, 1310}, {3, 4} };
    Assert.AreEqual("(18078,34060)(2262,34060)(25545,34060)", Fracts.convertFrac(lst));
    
    lst = new long[,] {  };
    Assert.AreEqual("", Fracts.convertFrac(lst));
        
    lst = new long[,] { {77, 130}, {84, 131}, {3, 4} };
    Assert.AreEqual("(20174,34060)(21840,34060)(25545,34060)", Fracts.convertFrac(lst));
    
    lst = new long[,] { {6, 13}, {187, 1310}, {31, 41} };
    Assert.AreEqual("(322260,698230)(99671,698230)(527930,698230)", Fracts.convertFrac(lst));
     
    lst = new long[,] { {8, 15}, {7, 111}, {4, 25} };
    Assert.AreEqual("(1480,2775)(175,2775)(444,2775)", Fracts.convertFrac(lst));
    
    lst = new long[,] { {1, 100}, {3, 1000}, {1, 2500}, {1, 20000} };
    Assert.AreEqual("(200,20000)(60,20000)(8,20000)(1,20000)", Fracts.convertFrac(lst));

    lst = new long[,] { {1, 1}, {3, 1}, {4, 1}, {5, 1} };
    Assert.AreEqual("(1,1)(3,1)(4,1)(5,1)", Fracts.convertFrac(lst));

    
  }
}
