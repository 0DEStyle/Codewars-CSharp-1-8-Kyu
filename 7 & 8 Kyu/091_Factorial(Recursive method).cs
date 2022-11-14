/*Challenge link:https://www.codewars.com/kata/54ff0d1f355cfd20e60001fc/train/csharp
Question:
In mathematics, the factorial of a non-negative integer n, denoted by n!, is the product of all positive integers less than or equal to n. For example: 5! = 5 * 4 * 3 * 2 * 1 = 120. By convention the value of 0! is 1.

Write a function to calculate factorial for a given input. If input is below 0 or above 12 throw an exception of type ArgumentOutOfRangeException (C#) or IllegalArgumentException (Java) or RangeException (PHP) or throw a RangeError (JavaScript) or ValueError (Python) or return -1 (C).

More details about factorial can be found here.


*/

//***************Solution********************
//if n is less than 0 or n is greater than 12, throw ArgumentOutOfRangeException
//Else apply factorial recurrsive method
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public static class Kata{
  public static int Factorial(int n) => n < 0 || n > 12 ? 
  throw new ArgumentOutOfRangeException() : n == 0 ? 1 : n * Factorial(n - 1);
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class FactorialTests
{
  [Test]
  public void FactorialOf0ShouldBe1()
  {
    Assert.AreEqual(1, Kata.Factorial(0));
  }
  
  [Test]
  public void FactorialOf1ShouldBe1()
  {
    Assert.AreEqual(1, Kata.Factorial(1));
  }
  
  [Test]
  public void FactorialOf2ShouldBe2()
  {
    Assert.AreEqual(2, Kata.Factorial(2));
  }
  
  [Test]
  public void FactorialOf3ShouldBe6()
  {
    Assert.AreEqual(6, Kata.Factorial(3));
  }
  
  [Test]
  public void AllFactorialsShouldBeCorrect()
  {
    for (var i = 0; i < 12; i++) {
      Assert.AreEqual(Factorial(i), Kata.Factorial(i));
    }
  }
  
  [Test]
  public void FactorialForNegativeInputShouldThrow()
  {
    Assert.Throws<ArgumentOutOfRangeException>(() => {
      Assert.AreEqual(0, Kata.Factorial(-1));
    });
  }
  
  [Test]
  public void FactorialFor13ShouldThrow()
  {
    Assert.Throws<ArgumentOutOfRangeException>(() => {
      Assert.AreEqual(0, Kata.Factorial(13));
    });
  }
  
  private int Factorial(int x)
  {
    if (x < 0 || x > 12) throw new ArgumentOutOfRangeException();
    return x == 0 ? 1 : x * Factorial(x-1);
  }
}
