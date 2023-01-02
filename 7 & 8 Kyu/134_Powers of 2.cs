/*Challenge link:https://www.codewars.com/kata/57a083a57cb1f31db7000028/train/csharp
Question:
Complete the function that takes a non-negative integer n as input, and returns a list of all the powers of 2 with the exponent ranging from 0 to n ( inclusive ).

Examples
n = 0  ==> [1]        # [2^0]
n = 1  ==> [1, 2]     # [2^0, 2^1]
n = 2  ==> [1, 2, 4]  # [2^0, 2^1, 2^2]
*/

//***************Solution********************
//Loop from 0 and count up to n+1, create element 2 to the power of x, then store all elements into array and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Numerics;
using System.Linq;

public class Kata{
  public static BigInteger[] PowersOfTwo(int n)=> Enumerable.Range(0, n+1).Select(x => BigInteger.Pow(2, x)).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Numerics;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new BigInteger[] { 1 }, Kata.PowersOfTwo(0));
      Assert.AreEqual(new BigInteger[] { 1, 2 }, Kata.PowersOfTwo(1));
      Assert.AreEqual(new BigInteger[] { 1, 2, 4, 8, 16 }, Kata.PowersOfTwo(4));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int, BigInteger[]> myPowersOfTwo = delegate (int n)
      {
        return Enumerable.Range(0, n + 1).Select(a => BigInteger.Pow(2, a)).ToArray();
      };
      
      var shuffle = Enumerable.Range(0,201).OrderBy(a => rand.Next(-1,2));
      
      shuffle.ToList().ForEach(n => 
      {
        Assert.AreEqual(myPowersOfTwo(n), Kata.PowersOfTwo(n));        
      });
    }
  }
}
