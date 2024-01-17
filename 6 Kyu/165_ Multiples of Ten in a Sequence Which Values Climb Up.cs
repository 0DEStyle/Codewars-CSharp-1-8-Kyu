/*Challenge link:https://www.codewars.com/kata/561d54055e399e2f62000045/train/csharp
Question:
We define the sequence SF in the following way in terms of four previous sequences: S1, S2, S3 and ST

source: imgur.com //see image in link

We are interested in collecting the terms of SF that are multiple of ten.

The first term multiple of ten of this sequence is 60

Make the function find_mult10_SF() that you introduce the ordinal number of a term multiple of 10 of SF and gives us the value of this term.

Let's see some cases:

find_mult10_SF(1) == 60

find_mult10_SF(2) == 70080

find_mult10_SF(3) ==  90700800
Memoization is advisable to have a more agile code for tests.

Your code will be tested up to the 300-th term, multiple of 10.

Happy coding!!


*/

//***************Solution********************
/*
s_1(n) = 1 + 2^n + 3^n
s_2(n) = 1 + 2^n + 4^n
s_3(n) = 1 + 2^n + 3^n + 4^n + 5^n + 6^n
s_t(n) = s_3(n) - s_2(n) - s_1(n)

s_t(n) = 3^n + 5^n + 6^n - s_1(n)
s_t(n) = - 1 - 2^n + 5^n + 6^n

//sub s_t into s_f
s_f(n) = (s_t(n + 1) - 5 * s_t(n) - 4) / 4
s_f(n) = ((-1 - 2^(n+1) + 5^(n+1) + 6^(n+1)) - 5 * (- 1 - 2^n + 5^n + 6^n) - 4) / 4
s_f(n) = (-1 - 2^(n+1) + 5^(n+1) + 6^(n+1) + 5 + 5 * 2^n - 5^(n + 1) - 5 * 6^n - 4) / 4
s_f(n) = (- 2^(n+1) + 5^(n+1) + 6^(n+1) + 5 * 2^n - 5^(n + 1) - 5 * 6^n) / 4
s_f(n) = (- 2^(n+1) + 6^(n+1) + 5 * 2^n - 5 * 6^n) / 4

//pull 2 out of n and times both sides
s_f(n) = (- 2 * 2^(n) + 6 * 6^(n) + 10 * 2^(n-1) - 30 * 6^(n-1)) / 4
s_f(n) = (- 2^(n) + 3 * 6^(n) + 5 * 2^(n-1) - 15 * 6^(n-1)) / 2

//pull 2 out of n and times both sides again
s_f(n) = (- 2 * 2^(n - 1) + 18 * 6^(n - 1) + 10 * 2^(n-2) - 90 * 6^(n-2)) / 2
s_f(n) = - 2^(n - 1) + 9 * 6^(n - 1) + 5 * 2^(n-2) - 45 * 6^(n-2)

//subtract 6^(n-2)
s_f(n) = - 2^(n - 1) + 54 * 6^(n - 2) + 5 * 2^(n-2) - 45 * 6^(n-2)
s_f(n) = - 2^(n - 1) + 9 * 6^(n - 2) + 5 * 2^(n-2)

//pull 2 out of 2^(n-1) to make it 2^(n-2), then subtract 
s_f(n) = - 2 * 2^(n - 2) + 9 * 6^(n - 2) + 5 * 2^(n-2)
s_f(n) = 3 * 2^(n - 2) + 9 * 6^(n - 2)

s_f(n) % 10 = (3 * 2^(n - 2) + 9 * 6^(n - 2)) % 10
where n >= 3, 
2^n % 10 = [6,2,4,8][n % 4]
3 * 2^(n-2)) % 10 = [2,4,8,6][n % 4]
6^n % 10 = 6
9 * 6^n % 10 = 4
s_f(n) % 10 = ([2,4,8,6][n % 4] + 4) % 10
s_f(n) % 10 = [6,8,2,0][n % 4] % 10

SF(n) is a multiple of 10 if n%4 = 3
2,4,3,1,2,4,3,1,2,4,3,1....
Congruence 3,7,11... 
SF(3),SF(7),SF(11)...
pattern 4n - 1
https://www.youtube.com/watch?app=desktop&v=WUSG7sI6YoU
*/

using System.Numerics;
using System;

public static class Kata {
  public static BigInteger FindMult10SF(int n) {
    var m = 4 * n - 1;
    return  3 * BigInteger.Pow(2, m - 2) + 9 * BigInteger.Pow(6, m - 2);
  }
}

//solution 2
using System.Numerics;

public static class Kata {
  public static BigInteger FindMult10SF(int n) {
    int p = 4*n-1;
    BigInteger six = 6;
    BigInteger two = 2;
    return (BigInteger.Pow(six, p) + 3 * BigInteger.Pow(two, p)) / 4;
  }
}

//bit shift 
using System;
using System.Numerics;

public static class Kata {
  public static BigInteger FindMult10SF(int n) {
    int i = 4 * n - 1;
    return BigInteger.Pow(3, i) + new BigInteger(3) << i - 2;
  }
}
//****************Sample Test*****************
namespace Solution {
  
  using NUnit.Framework;
  using System;
  using System.Numerics;

  [TestFixture]
  public class SolutionTest
  {
    static void Act(BigInteger expected, int n) 
      => Assert.AreEqual(expected, Kata.FindMult10SF(n), $"Input -> n = {n}");
    
    [Test(Description="Fixed Tests")]
    [TestCase(60, 1)]
    [TestCase(70080, 2)]
    [TestCase(90700800, 3)]
    public void FixedTests(int expected, int n) => Act(expected, n);
    
    [Test] public void RandomTestsA([Random(1, 21, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsB([Random(21 , 41 , 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsC([Random(41 , 61 , 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsD([Random(61 , 81, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsE([Random(100 , 121, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsF([Random(130 , 151, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsG([Random(151 , 171, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsH([Random(171 , 191, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsI([Random(191 , 211, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsJ([Random(221 , 241, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsK([Random(251 , 271, 20)] int n) => DoRandomTest(n);
    [Test] public void RandomTestsL([Random(281 , 301, 20)] int n) => DoRandomTest(n);
    
    private void DoRandomTest(int m)
    {
      var expected = reference(m);
      Act(expected, m);
      BigInteger reference(int n) {
        int p = 4*n-1;
        BigInteger six = 6;
        BigInteger two = 2;
        return (BigInteger.Pow(six, p) + 3 * BigInteger.Pow(two, p)) / 4;
      }
    }
  }
}
