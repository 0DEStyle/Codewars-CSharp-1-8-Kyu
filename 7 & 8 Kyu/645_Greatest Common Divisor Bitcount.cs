/*Challenge link:https://www.codewars.com/kata/54b45c37041df0caf800020f/train/csharp
Question:
The objective is to write a method that takes two integer parameters and returns a single integer equal to the number of 1s in the binary representation of the greatest common divisor of the parameters.

Taken from Wikipedia: "In mathematics, the greatest common divisor (gcd) of two or more integers, when at least one of them is not zero, is the largest positive integer that divides the numbers without a remainder. For example, the GCD of 8 and 12 is 4."

For example: the greatest common divisor of 300 and 45 is 15. The binary representation of 15 is 1111, so the correct output would be 4.

If both parameters are 0, the method should return 0. The function must be able to handle negative input.


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Numerics;

public class BinaryGCD {
  //method 2 get gcd
  public static int GCD(int a, int b) => b == 0 ? a : GCD(b, a % b);
  
  //get absolute values of x and y, pass into GCD, convert to binary format
  //b is the current element/char, count the number of '1' in the string and return the result
  public static int GcdBinary(int x, int y) =>
    Convert.ToString(GCD(Math.Abs(x), Math.Abs(y)), 2)
           .Count(b => b == '1');
}

//method 2
using System;
using System.Linq;
using System.Numerics;

public class BinaryGCD 
{
  public static int GcdBinary(int x, int y) 
  {
    return Convert.ToString((int) BigInteger.GreatestCommonDivisor(x, y), 2).Count(c => c == '1');
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class BinaryGCDTests
  {
    private Random rand = new Random();
  
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(6, BinaryGCD.GcdBinary(666666,333111)); 
      Assert.AreEqual(1, BinaryGCD.GcdBinary(545034,5));
      Assert.AreEqual(0, BinaryGCD.GcdBinary(0,0));
      Assert.AreEqual(14, BinaryGCD.GcdBinary(0,76899299));
      Assert.AreEqual(1, BinaryGCD.GcdBinary(-124, -16));
      
      Assert.AreEqual(2, BinaryGCD.GcdBinary(-3, 6));
         
      Assert.AreEqual(1, BinaryGCD.GcdBinary(545034,-5));
               
      Assert.AreEqual(1, BinaryGCD.GcdBinary(-8, 0));
      Assert.AreEqual(1, BinaryGCD.GcdBinary(0, -8));
    }
    
    [Test]
    public void RandomTests()
    {
      int[] tests = {testCase(3), testCase(-4), testCase(6), testCase(-8), testCase(10), testCase(12), 
         testCase(17), testCase(21), testCase(99), testCase(644), testCase(32), testCase(700), 
         testCase(-500), testCase(50), testCase(50), testCase(-50), testCase(3), testCase(33), testCase(-35)}; 
         
      Func<int, int, int> gcdB = null;
      gcdB = delegate (int x, int y)
      {
        int a = Math.Abs(x);
        int b = Math.Abs(y);
        if (y==0)
        {
          string num = Convert.ToString(a,2).Replace("0","");
          return num.Length;
        }
        
        return gcdB(b, a % b);
      };
      foreach (int i in tests)
      {
        Assert.AreEqual(gcdB(i, 8), BinaryGCD.GcdBinary(i, 8));
        Assert.AreEqual(gcdB(8, i), BinaryGCD.GcdBinary(8, i));
      }
    }
    
    public int testCase(int size)
    {
      return (int)(rand.NextDouble() * size);
    }
  }
}
