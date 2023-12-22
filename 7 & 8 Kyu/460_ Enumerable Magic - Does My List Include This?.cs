/*Challenge link:https://www.codewars.com/kata/545991b4cbae2a5fda000158/train/csharp
Question:
Create a method that accepts a list and an item, and returns true if the item belongs to the list, otherwise false.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check if array arr contains item, then return bool value.
using System.Linq;

public class Kata{
  public static bool Include(int[] arr, int item) => arr.Contains(item);
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
      Assert.AreEqual(true, Kata.Include(new int[] { 1,2,3,4 }, 3));
      Assert.AreEqual(false, Kata.Include(new int[] { 1,2,4,5 }, 3));
    }
    
    [Test]
    public void ExtendedTests()
    {
      var list = new int[] { 0,1,2,3,5,8,13,2,2,2,11 };
      
      Assert.AreEqual(true, Kata.Include(list, 13), "list includes 13");
      Assert.AreEqual(true, Kata.Include(list, 0), "list includes 0");
      Assert.AreEqual(false, Kata.Include(list, 100), "list does not include 100");
      
      Assert.AreEqual(true, Kata.Include(list, 2), "list includes 2 multiple times");
      Assert.AreEqual(true, Kata.Include(list, 11), "list includes 11");
      
      Assert.AreEqual(false, Kata.Include(new int[0], 0), "empty list doesn't include anything");
    }
  }
}
