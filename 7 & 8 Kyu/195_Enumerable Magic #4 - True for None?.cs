/*Challenge link:https://www.codewars.com/kata/545993ee52756d98ca0010e1/train/csharp
Question:
Create a method none? (JS none) that accepts an array and a block (JS: a function), and returns true if the block (/function) returns true for none of the items in the array. An empty list should return true.
*/

//***************Solution********************
//if none of the element in arr is true, return the bool result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static bool None(int[] arr, Func<int, bool> fun) => !arr.Any(x => fun(x));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(true, Kata.None(new int[] { 1,2,3,4,5 }, v => v > 5));
      Assert.AreEqual(false, Kata.None(new int[] { 1,2,3,4,5 }, v => v > 4));
    }
    
    [Test]
    public void ExtendedTests()
    {
      var list = new int[] { 0,1,2,3,5,8,13 };
      
      Assert.AreEqual(true, Kata.None(list, v => v > 100), "no items are over 100");
      Assert.AreEqual(false, Kata.None(list, v => v > 9), "last item is over 9");
      Assert.AreEqual(false, Kata.None(list, v => v % 2 > 0), "some items are even");
      Assert.AreEqual(false, Kata.None(list, v => v % 2 == 0), "all items are odd");
      
      Assert.AreEqual(true, Kata.None(new int[0], v => v % 2 > 0), "empty list should return true");
    }
  }
}
