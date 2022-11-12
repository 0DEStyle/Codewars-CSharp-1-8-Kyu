/*Challenge link:https://www.codewars.com/kata/57f781872e3d8ca2a000007e/train/csharp
Question:
Given an array of integers, return a new array with each value doubled.

For example:

[1, 2, 3] --> [2, 4, 6]


*/

//***************Solution********************
//select each element and times it by 2, store the result in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata
{
  public static int[] Maps(int[] x) => x.Select(i=> i*2).ToArray();
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new [] { 2, 4, 6 }, Kata.Maps(new [] { 1, 2, 3 }));
      Assert.AreEqual(new [] { 8, 2, 2, 2, 8 }, Kata.Maps(new [] { 4, 1, 1, 1, 4 }));
      Assert.AreEqual(new [] { 4, 4, 4, 4, 4, 4 }, Kata.Maps(new [] { 2, 2, 2, 2, 2, 2 }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      for (var i=0;i<100;i++)
      {
        var len = rand.Next(2,8);
        var x = Enumerable.Range(0,len).Select(a => rand.Next(1,10)).ToArray();
        
        var expected = x.Select(a => a * 2).ToArray();
        
        Assert.AreEqual(expected, Kata.Maps(x),"It should work for random inputs too");
      }
    }
  }
}
