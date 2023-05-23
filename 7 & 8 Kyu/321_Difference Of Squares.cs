/*Challenge link:https://www.codewars.com/kata/558f9f51e85b46e9fa000025/train/csharp
Question:
Recreation of Project Euler problem #6

Find the difference between the sum of the squares of the first n natural numbers (1 <= n <= 100) and the square of their sum.

Example
For example, when n = 10:

The square of the sum of the numbers is:

(1 + 2 + 3 + 4 + 5 + 6 + 7 + 8 + 9 + 10)2 = 552 = 3025

The sum of the squares of the numbers is:

12 + 22 + 32 + 42 + 52 + 62 + 72 + 82 + 92 + 102 = 385

Hence the difference between square of the sum of the first ten natural numbers and the sum of the squares of those numbes is: 3025 - 385 = 2640 
*/

//***************Solution********************

using System;

public class Kata{
  public static int DifferenceOfSquares(int n){
    
    //square of sum
    Console.WriteLine((n*(n+1)/2)*(n*(n+1)/2));
    //sum of squares
    Console.WriteLine((2 * n + 1) * (n + 1) * n / 6);
    //Simplified
    // n * (n + 1) * (3 * n * n - n - 2) / 12
    return  n * (n + 1) * (3 * n * n - n - 2) / 12;
  }
}
//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class Tests
  {
    [Test]
    [TestCase(5, ExpectedResult=170)]
    [TestCase(10, ExpectedResult=2640)]
    [TestCase(100, ExpectedResult=25164150)]
    public static int FixedTest(int x)
    {
      return Kata.DifferenceOfSquares(x);
    }
    
    private static int Solution(int x)
    {
      int a = 0;
      int b = 0;
      for(int i = 1; i <= x; i++)
      {
        a += (int)Math.Pow(i, 2);
        b += i;
      }
      return b*b-a;
    }
    
    [Test]
    public static void RandomTest([Random(1,100,100)]int x)
    {
      Assert.AreEqual(Solution(x), Kata.DifferenceOfSquares(x), string.Format("Should work for {0}", x));
    }
  }
}
