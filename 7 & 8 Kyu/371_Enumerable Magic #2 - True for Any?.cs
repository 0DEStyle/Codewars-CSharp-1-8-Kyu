/*Challenge link:https://www.codewars.com/kata/54598e89cbae2ac001001135/train/csharp
Question:
Create an any? (JS: any) function that accepts an array and a block (JS: function), and returns true if the block (/function) returns true for any item in the array. If the array is empty, the function should return false.
*/

//***************Solution********************
//in arr, check if any fun exist
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata
{
  public static bool Any(int[] arr, Func<int,bool> fun) => arr.Any(fun);
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
    public void BasicTest()
    {
      Assert.AreEqual(true, Kata.Any(new int[] { 1, 2, 3, 4 }, v => v > 3));
      Assert.AreEqual(false, Kata.Any(new int[] { 1, 2, 3, 4 }, v => v > 4));
    }
  
    [Test]
    public void ExtendedTests()
    {
      var list = new int[] { 0, 1, 2, 3, 5, 8, 13 };
      Assert.AreEqual(true, Kata.Any(list, v => v % 2 == 0), "At least 1 item is even");
      Assert.AreEqual(false, Kata.Any(list, v => v>20), "No items are greater than 20");
      Assert.AreEqual(true, Kata.Any(list, v => v > 0), "At least 1 item is a positive integer");
      Assert.AreEqual(false, Kata.Any(new int[0], v => v > 0), "An empty list should return false");
      
      Assert.AreEqual(true, Kata.Any(new int[] { 1, 2, 3, 4 }, v => v == 4), "At least 1 item equals 4");
      Assert.AreEqual(false, Kata.Any(new int[] { 1, 2, 3, 3 }, v => v == 4), "No item equals 4");
    }
  }
}
