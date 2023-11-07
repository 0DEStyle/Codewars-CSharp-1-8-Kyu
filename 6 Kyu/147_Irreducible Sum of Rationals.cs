/*Challenge link:https://www.codewars.com/kata/5517fcb0236c8826940003c9/train/csharp
Question:
You will have a list of rationals in the form

lst = [ [numer_1, denom_1] , ... , [numer_n, denom_n] ]
or

lst = [ (numer_1, denom_1) , ... , (numer_n, denom_n) ]
where all numbers are positive integers. You have to produce their sum N / D in an irreducible form: this means that N and D have only 1 as a common divisor.

Return the result in the form:

[N, D] in Ruby, Crystal, Python, Clojure, JS, CS, PHP, Julia, Pascal
Just "N D" in Haskell, PureScript
"[N, D]" in Java, CSharp, TS, Scala, PowerShell, Kotlin
"N/D" in Go, Nim
{N, D} in C, C++, Elixir, Lua
Some((N, D)) in Rust
Some "N D" in F#, Ocaml
c(N, D) in R
(N, D) in Swift
'(N D) in Racket
If the result is an integer (D evenly divides N) return:

an integer in Ruby, Crystal, Elixir, Clojure, Python, JS, CS, PHP, R, Julia
Just "n" (Haskell, PureScript)
"n" Java, CSharp, TS, Scala, PowerShell, Go, Nim, Kotlin
{n, 1} in C, C++, Lua
Some((n, 1)) in Rust
Some "n" in F#, Ocaml,
(n, 1) in Swift
n in Racket
(n, 1) in Swift, Pascal, Perl
If the input list is empty, return

nil/None/null/Nothing
{0, 1} in C, C++, Lua
"0" in Scala, PowerShell, Go, Nim
O in Racket
"" in Kotlin
[0, 1] in C++, "[0, 1]" in Pascal
[0, 1] in Perl
Example:
[ [1, 2], [1, 3], [1, 4] ]  -->  [13, 12]
1/2  +  1/3  +  1/4     =      13/12
Note
See sample tests for more examples and form of results.
*/

//***************Solution********************
using System;
public class SumFractions {
  //greatest common divisor function
  private static int GCD(int a, int b) => b == 0 ? a : GCD (b, a % b);
  
    public static string SumFracts(int[,] l){
      //check null
       if (l.GetLength(0) == 0) 
         return null;
      
      //set denominator to 1 to kickstart calcultion or else result will be 0
      //l[i,1] is denominator, l[i,0] is numerator
      int curNumerator = 0, curDenominator = 1;
      
      //accumulating Denominator
      for(int i = 0; i < l.GetLength(0); i++)
        curDenominator *= l[i,1];
      //accumulating Numerator
      for(int i = 0; i < l.GetLength(0); i++)
        curNumerator += l[i,0] * curDenominator / l[i,1];
      
      //calculation gcd
      var gcd = GCD(curNumerator, curDenominator);
      //Console.WriteLine(curNumerator + "/" + curDenominator + ", " + gcd);
      
      //format the result using string interpolation
      return gcd == curDenominator ? $"{curNumerator / curDenominator}" :
                                     $"[{curNumerator / gcd}, {curDenominator / gcd}]";
    }
  
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class SumFractionsTests 
{
    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test() 
    {        
        Console.WriteLine("Fixed Tests");
        int[,] a = new int[,] { {1,2}, {2,9}, {3,18}, {4,24}, {6,48} };
        String r = "[85, 72]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {1, 2}, {1, 3}, {1, 4} };
        r = "[13, 12]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {1, 3}, {5, 3} };
        r = "2";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {12, 3}, {15, 3} };
        r = "9";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {2, 7}, {1, 3}, {1, 12} };
        r = "[59, 84]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {69, 130}, {87, 1310}, {3, 4} };
        r = "[9177, 6812]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {77, 130}, {84, 131}, {60, 80} };
        r = "[67559, 34060]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {6, 13}, {187, 1310}, {31, 41} };
        r = "[949861, 698230]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {8, 15}, {7, 111}, {4, 25} };
        r = "[2099, 2775]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] {};
        r = null;
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {1, 8}, {1, 9} };
        r = "[17, 72]";
        testing(SumFractions.SumFracts(a), r);
        a = new int[,] { {2, 8}, {1, 9} };
        r = "[13, 36]";
        testing(SumFractions.SumFracts(a), r);
    }
    //-----------------------
    private static Random rnd = new Random();

    private static string Array2StringSol(int[] list)
    {
        return "[" + string.Join(", ", list) + "]";
    }
    private static int GcdSol(int x, int y) 
    {
        while (y != 0) 
        {
            int t = x; x = y; y = t % y;
        }
        return x;
    }
    private static int LcmSol(int a, int b) 
    {
        return (a * b) / GcdSol(a, b);
    }
    private static int ComDenomSol(int[,] l) 
    {
        int result = l[0, 1];
        for (int i = 1; i < l.GetLength(0); i++) 
        {
            result = LcmSol(result, l[i, 1]);
        }
        return result;
    }
    private static int SumNumSol(int[,] l) 
    {
        int lc = ComDenomSol(l);
        int s = 0;
        for (int i = 0; i < l.GetLength(0); i++) 
        {
            s += l[i, 0] * lc / l[i, 1];
        }
        return s;
    }
    public static string SumFractsSol(int[,] l) 
    {
        if (l.Length == 0) return null;
        int num = SumNumSol(l);
        int den = ComDenomSol(l);
        if (num % den == 0) return (num / den).ToString();
        int gd = GcdSol(num, den);
        return Array2StringSol(new int[] { num / gd, den / gd });
    }
    //-----------------------
    
[Test]
    public static void testB() {
        Console.WriteLine("Random Tests **** SumFracts");
        for (int i = 0; i < 50; i++) 
        {
            int a = rnd.Next(1, 200);
            int[,] op = new int[,] { {a, a + 1}, {a, a + 2} };
            testing(SumFractions.SumFracts(op), SumFractsSol(op));
        }
    }  
}
