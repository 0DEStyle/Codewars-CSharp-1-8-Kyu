/*Challenge link:https://www.codewars.com/kata/58fa273ca6d84c158e000052/train/csharp
Question:
Determine the total number of digits in the integer (n>=0) given as input to the function. For example, 9 is a single digit, 66 has 2 digits and 128685 has 6 digits. Be careful to avoid overflows/underflows.

All inputs will be valid.


*/

//***************Solution********************
//convert n to string, then count the character that is less than or equal to 0.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class DecTools {
  public static int Digits(ulong n) => n.ToString().Count(x=>x>=0);
}

//solution 2
public class DecTools
{
  public static int Digits(ulong n)
  {
    return $"{n}".Length;
  }
}



//****************Sample Test*****************

namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Tests
  {
    [Test]
    public void DigitsZero()
    {
      Assert.AreEqual(1,DecTools.Digits(0));
    }
    
    [Test]
    public void DigitsMax()
    {
      Assert.AreEqual(20, DecTools.Digits(ulong.MaxValue));
    }
  
    [Test]
    public void DigitsPowersOfTen()
    {
      ulong n = 1ul;
      Assert.AreEqual(1, DecTools.Digits(n));
      for(int i = 1; i < 20; i++)
      {
        n *= 10ul;
        Assert.AreEqual(i+1, DecTools.Digits(n));
      }
    }
    
    [Test]
    public void DigitsPowersOfTenMinusOne()
    {
      ulong n = 1ul;
      for(int i = 1; i < 20; i++)
      {
        n *= 10ul;
        Assert.AreEqual(i, DecTools.Digits(n-1));
      }
    }
    
    [Test]
    public void DigitsPowersOfTenHalf()
    {
      ulong n = 1ul;
      for(int i = 1; i < 20; i++)
      {
        n *= 10ul;
        Assert.AreEqual(i, DecTools.Digits(n/2));
      }
    }
  }
}
