/*Challenge link:https://www.codewars.com/kata/58a5aeb893b79949eb0000f1/train/csharp
Question:
Complete the method that returns true if 2 integers share at least two 1 bits, otherwise return false. For simplicity assume that all numbers are non-negative.

Examples
 7  =  0111 in binary
10  =  1010
15  =  1111
7 and 10 share only a single 1-bit (at index 2) --> false
7 and 15 share 3 1-bits (at indexes 1, 2, and 3) --> true
10 and 15 share 2 1-bits (at indexes 0 and 2) --> true
Hint: you can do this with just string manipulation, but binary operators will make your life much easier.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//a AND b to get common bits
//convert binary to string, count the '1' to see if it is greater or equal to 2
//return a bool vale after
using System;
using System.Linq;

namespace BinaryOperators{
  public class BitCounting{
    public static bool SharedBits(int a, int b) => 
      Convert.ToString(a & b, 2)
             .Count(x => x == '1') >= 2;
  }
}

//****************Sample Test*****************
namespace BinaryOperators {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using static BitCounting;
  [TestFixture]
  public class AllTests
  {
    [Test]
    public void SharedBits1()
    {
      Assert.AreEqual(false, SharedBits(1, 2));
    }
    
    [Test]
    public void SharedBits2()
    {
      Assert.AreEqual(false, SharedBits(16, 8));
    }
    [Test]
    public void SharedBits3()
    {
      Assert.AreEqual(false, SharedBits(1, 1));
    }
    
    [Test]
    public void SharedBits4()
    {
      Assert.AreEqual(false, SharedBits(2, 3));
    }
  
    [Test]
    public void SharedBits5()
    {
      Assert.AreEqual(false, SharedBits(7, 10));
    }
    
    [Test]
    public void SharedBits6()
    {
      Assert.AreEqual(true, SharedBits(43, 77));
    }
    
    [Test]
    public void SharedBits7()
    {
      Assert.AreEqual(true, SharedBits(7, 15));
    }
    [Test]
    public void SharedBits8()
    {
      Assert.AreEqual(true, SharedBits(23, 7));
    }

    [Test]
    public void RandomBits()
    {
      Func<int,int,bool> sln = (int a, int b) => Convert.ToString(a & b, 2).Count(x => x == '1') > 1;
      Random rng = new Random();
      for(var i = 0; i < 100; i++)
      {
        var a = rng.Next(0, 2000);
        var b = rng.Next(0, 2000);
        Assert.AreEqual(sln(a,b), SharedBits(a,b));
      }
    }
  }
}
