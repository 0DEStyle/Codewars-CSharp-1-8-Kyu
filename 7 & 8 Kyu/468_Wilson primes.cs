/*Challenge link:https://www.codewars.com/kata/55dc4520094bbaf50e0000cb/train/csharp
Question:Wilson primes satisfy the following condition. Let P represent a prime number.

Then,

((P-1)! + 1) / (P * P)
should give a whole number.

Your task is to create a function that returns true if the given number is a Wilson prime.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  //factorial
  private static int fact(int n) => n > 1 ? fact(n - 1) * n : 1;
  
  //apply formula
  public static bool AmIWilson(int p) => (fact(p - 1) + 1.0) / (p * p) % 1 == 0;
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(5, ExpectedResult=true)]
  [TestCase(8, ExpectedResult=false)]
  [TestCase(9, ExpectedResult=false)]
  [TestCase(11, ExpectedResult=false)]
  [TestCase(13, ExpectedResult=true)]
  public static bool FixedTest(int p)
  {
    return Kata.AmIWilson(p);
  }
  
  [Test]
  public static void RandomTest([Random(0,100,20)] int p)
  {
    Assert.AreEqual(Solution(p), Kata.AmIWilson(p), "Should work for "+p);
  }
  
  private static bool Solution(int p)
  {
    return (((Faculty(p-1)+1)/(Math.Pow(p,2))))%1==0;
  }
  
  private static int Faculty(int num)
  {
    return (num == 1) ?  1 : num * Faculty(num-1);
  }
}
