/*Challenge link:https://www.codewars.com/kata/542c0f198e077084c0000c2e/train/csharp
Question:
Count the number of divisors of a positive integer n.

Random tests go up to n = 500000.

Examples (input --> output)
4 --> 3 (1, 2, 4)
5 --> 2 (1, 5)
12 --> 6 (1, 2, 3, 4, 6, 12)
30 --> 8 (1, 2, 3, 5, 6, 10, 15, 30)
Note you should only return a number, the count of divisors. The numbers between parentheses are shown only for you to see which numbers are counted in each case.


*/

//***************Solution********************
//from range 1 to n, if n & i == 0, count++
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata
{
  public static int Divisors(int n) => Enumerable.Range(1, n + 1).Where(i => n % i == 0).Count();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static int Solution(int n)
    { 
      int count = 0;
      double sqrt = Math.Sqrt(n);
      for (int i = 1; i <= sqrt; ++i)
      {
        if (n % i == 0) count += 2;
        if (i == sqrt) --count;
      }
      return count;
    }
    
    [Test]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(1, Kata.Divisors(1)),
        () => Assert.AreEqual(4, Kata.Divisors(10)),
        () => Assert.AreEqual(2, Kata.Divisors(11)),
        () => Assert.AreEqual(8, Kata.Divisors(54)),
        () => Assert.AreEqual(3, Kata.Divisors(25)),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int test = rnd.Next(0, 500000);
        int expected = Solution(test);
        int actual = Kata.Divisors(test);
        Console.WriteLine("Testing:  {0}\nExpected: {1}\nActual:   {2}\n", test, expected, actual);
        Assert.AreEqual(expected, actual);
      }
    }
    /*
    [Test]
    public void LargeNumberRandomTest()
    {
      for (int i = 0; i < 1000; ++i)
      {
        int test = 2147483647 - rnd.Next(0, 5000000);
        int expected = Solution(test);
        int actual = Kata.Divisors(test);
        Console.WriteLine("Testing:  {0}\nExpected: {1}\nActual:   {2}\n", test, expected, actual);
        Assert.AreEqual(expected, actual);
      }
    }
    */
  }
}
