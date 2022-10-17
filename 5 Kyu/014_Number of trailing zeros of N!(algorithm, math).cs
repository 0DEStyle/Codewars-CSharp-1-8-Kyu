/*Challenge link:https://www.codewars.com/kata/52f787eb172a8b4ae1000a34/train/csharp
Question:
Write a program that will calculate the number of trailing zeros in a factorial of a given number.

N! = 1 * 2 * 3 *  ... * N

Be careful 1000! has 2568 digits...

For more info, see: http://mathworld.wolfram.com/Factorial.html

Examples
zeros(6) = 1
# 6! = 1 * 2 * 3 * 4 * 5 * 6 = 720 --> 1 trailing zero

zeros(12) = 2
# 12! = 479001600 --> 2 trailing zeros
Hint: You're not meant to calculate the factorial. Find another way to find the number of zeros.


*/

//***************Solution********************

//apply algorithm, return result.
//algorithm ref https://mathworld.wolfram.com/Factorial.html
using System;

public static class Kata 
{
  public static int TrailingZeros(int n)
  {
    double factorial = (double)n;
    double trailingZeros = 0; 
    
    double kMax = Math.Log(factorial, 5);
    
    for(int k = 1; k < kMax+1; k++) //k shouldn't be zero, because of calculation
    {
    trailingZeros += Math.Floor(factorial / Math.Pow(5,k));
    Console.WriteLine("trailingZeros is " + trailingZeros);
    }
    return (int)trailingZeros;
  }
}

//solution 2
//same as above,
// simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public static class Kata 
{
  public static int TrailingZeros(int n) => Enumerable.Range(1, (int)Math.Log(n, 5)).Sum(i => (int)(n / Math.Pow(5, i)));
}

//****************Sample Test*****************
Write a program that will calculate the number of trailing zeros in a factorial of a given number.

N! = 1 * 2 * 3 *  ... * N

Be careful 1000! has 2568 digits...

For more info, see: http://mathworld.wolfram.com/Factorial.html

Examples
zeros(6) = 1
# 6! = 1 * 2 * 3 * 4 * 5 * 6 = 720 --> 1 trailing zero

zeros(12) = 2
# 12! = 479001600 --> 2 trailing zeros
Hint: You're not meant to calculate the factorial. Find another way to find the number of zeros.
