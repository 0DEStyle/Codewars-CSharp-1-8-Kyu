/*Challenge link:
Question:
Given an integer as input, can you round it to the next (meaning, "greater than or equal") multiple of 5?

Examples:

input:    output:
0    ->   0
2    ->   5
3    ->   5
12   ->   15
21   ->   25
30   ->   30
-2   ->   0
-5   ->   -5
etc.
Input may be any positive or negative integer (including 0).

You can assume that all inputs are valid integers.


*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static int RoundToNext5(int n)=> (int)Math.Ceiling(n/5.0)*5;
}

//****************Sample Test*****************

using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(0, ExpectedResult=0)]
  [TestCase(1, ExpectedResult=5)]
  [TestCase(-1, ExpectedResult=0)]
  [TestCase(-5, ExpectedResult=-5)]
  [TestCase(3, ExpectedResult=5)]
  [TestCase(5, ExpectedResult=5)]
  [TestCase(7, ExpectedResult=10)]
  [TestCase(39, ExpectedResult=40)]
  public static int FixedTest(int n)
  {
    return Kata.RoundToNext5(n);
  }
  
  [Test]
  public static void RandomTest([Random(-1000000,1000000, 100)] int n)
  {
    Assert.AreEqual(Solution(n), Kata.RoundToNext5(n), "Should work for "+n);
  }
  
  private static int Solution(int n)
  {
    while(n % 5 != 0) n++;
    return n;
  }
}
