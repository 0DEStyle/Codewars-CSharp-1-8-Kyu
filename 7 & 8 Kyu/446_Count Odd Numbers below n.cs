/*Challenge link:https://www.codewars.com/kata/59342039eb450e39970000a6/train/csharp
Question:
Given a number n, return the number of positive odd numbers below n, EASY!

Examples (Input -> Output)
7  -> 3 (because odd numbers below 7 are [1, 3, 5])
15 -> 7 (because odd numbers below 15 are [1, 3, 5, 7, 9, 11, 13])
Expect large Inputs!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//number of odd number below n is n divide by 2
public static class Kata{
  public static ulong OddCount(ulong n) => n / 2;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SampleTest
  {
    [Test]
    public void Test()
    {
      Assert.AreEqual(7, Kata.OddCount(15));
      Assert.AreEqual(7511, Kata.OddCount(15023));
    }
  }
  
  [TestFixture]
  public class RandomTest
  {
    [Test]
    public void Test()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        // some very very poor ulong generator
        ulong n = ((ulong)rnd.Next() << rnd.Next(0, 31)) + (ulong)rnd.Next();
        
        Assert.AreEqual(n / 2, Kata.OddCount(n));
      }
    }
  }
}
