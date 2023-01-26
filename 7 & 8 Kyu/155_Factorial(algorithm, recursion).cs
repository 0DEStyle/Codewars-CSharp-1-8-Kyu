/*Challenge link:https://www.codewars.com/kata/57a049e253ba33ac5e000212/train/csharp
Question:
Your task is to write function factorial.

https://en.wikipedia.org/wiki/Factorial
*/

//***************Solution********************
//apply recursive algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution{
  public static class Program{
    public static ulong Factorial(ulong n) =>  n > 0 ? n * Factorial(n - 1) : 1;
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Tests()
    {
      Assert.AreEqual(1, Program.Factorial(0));
      Assert.AreEqual(1, Program.Factorial(1));
      Assert.AreEqual(2, Program.Factorial(2));
      Assert.AreEqual(6, Program.Factorial(3));
      Assert.AreEqual(24, Program.Factorial(4));
      Assert.AreEqual(120, Program.Factorial(5));
      Assert.AreEqual(720, Program.Factorial(6));
      Assert.AreEqual(5040, Program.Factorial(7));
      Assert.AreEqual(40320, Program.Factorial(8));
      Assert.AreEqual(362880, Program.Factorial(9));
      Assert.AreEqual(3628800, Program.Factorial(10));
      Assert.AreEqual(39916800, Program.Factorial(11));
      Assert.AreEqual(479001600, Program.Factorial(12));
      Assert.AreEqual(6227020800, Program.Factorial(13));
      Assert.AreEqual(87178291200, Program.Factorial(14));
      Assert.AreEqual(1307674368000, Program.Factorial(15));
      Assert.AreEqual(20922789888000, Program.Factorial(16));
      Assert.AreEqual(355687428096000, Program.Factorial(17));
      Assert.AreEqual(6402373705728000, Program.Factorial(18));
    }
  }
}
