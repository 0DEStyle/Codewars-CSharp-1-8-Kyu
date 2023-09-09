/*Challenge link:https://www.codewars.com/kata/522551eee9abb932420004a0/train/csharp
Question:
I love Fibonacci numbers in general, but I must admit I love some more than others.

I would like for you to write me a function that, when given a number n (n >= 1 ), returns the nth number in the Fibonacci Sequence.

For example:

   NthFib(4) == 2
Because 2 is the 4th number in the Fibonacci Sequence.

For reference, the first two numbers in the Fibonacci sequence are 0 and 1, and each subsequent number is the sum of the previous two.


*/

//***************Solution********************


//if n is 1, return 0
//else if n is less than or equal to 3, return 1
//else pass n-2 into recurssive method + n-1 into  recurssive method
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Fibonacci{
    public int NthFib(int n) =>  n == 1 ? 0 : n <= 3 ? 1 : NthFib(n - 2) + NthFib(n - 1);
}
//****************Sample Test*****************
using NUnit.Framework;
[TestFixture]
public class Tests
{
  [Test]
  public void Test()
  {
    Fibonacci fib = new Fibonacci();
    Assert.AreEqual(0, fib.NthFib(1));
    Assert.AreEqual(1, fib.NthFib(2));
    Assert.AreEqual(1, fib.NthFib(3));
    Assert.AreEqual(2, fib.NthFib(4));
    Assert.AreEqual(3, fib.NthFib(5));
    Assert.AreEqual(5, fib.NthFib(6));
    Assert.AreEqual(8, fib.NthFib(7));
    Assert.AreEqual(13, fib.NthFib(8));
    Assert.AreEqual(21, fib.NthFib(9));
    Assert.AreEqual(34, fib.NthFib(10));
    Assert.AreEqual(55, fib.NthFib(11));
    Assert.AreEqual(89, fib.NthFib(12));
    Assert.AreEqual(144, fib.NthFib(13));
    Assert.AreEqual(233, fib.NthFib(14));
    Assert.AreEqual(377, fib.NthFib(15));
    Assert.AreEqual(610, fib.NthFib(16));
    Assert.AreEqual(987, fib.NthFib(17));
    Assert.AreEqual(1597, fib.NthFib(18));
    Assert.AreEqual(2584, fib.NthFib(19));
    Assert.AreEqual(4181, fib.NthFib(20));
    Assert.AreEqual(6765, fib.NthFib(21));
    Assert.AreEqual(10946, fib.NthFib(22));
    Assert.AreEqual(17711, fib.NthFib(23));
    Assert.AreEqual(28657, fib.NthFib(24));
    Assert.AreEqual(46368, fib.NthFib(25));
  }
}
