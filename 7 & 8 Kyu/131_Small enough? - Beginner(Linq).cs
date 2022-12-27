https://www.codewars.com/kata/57cc981a58da9e302a000214/train/csharp/*Challenge link:https://www.codewars.com/kata/57cc981a58da9e302a000214/train/csharp
Question:
You will be given an array and a limit value. You must check that all values in the array are below or equal to the limit value. If they are, return true. Else, return false.

You can assume all values in the array are numbers.
*/

//***************Solution********************
//check each element in array, if any not greater than limit, return true, else false.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static bool SmallEnough(int[] a, int limit)=> !a.Any(i => i > limit);
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
      Assert.AreEqual(true, Kata.SmallEnough(new int[] { 66, 101 } ,200));
      Assert.AreEqual(false, Kata.SmallEnough(new int[] { 78, 117, 110, 99, 104, 117, 107, 115 } ,100));
      Assert.AreEqual(true, Kata.SmallEnough(new int[] { 101, 45, 75, 105, 99, 107 } ,107));
      Assert.AreEqual(true, Kata.SmallEnough(new int[] { 80, 117, 115, 104, 45, 85, 112, 115 } ,120));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual(false, Kata.SmallEnough(new int[] { 1, 1, 1, 1, 1, 2 } ,1));
      Assert.AreEqual(false, Kata.SmallEnough(new int[] { 78, 33, 22, 44, 88, 9, 6 } ,87));
      Assert.AreEqual(true, Kata.SmallEnough(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 } ,10));
      Assert.AreEqual(true, Kata.SmallEnough(new int[] { 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12, 12 } ,12));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<100;r++)
      {
        var a = Enumerable.Range(0, rand.Next(10,100)).Select(b => rand.Next(1, 200)).ToArray();
        var limit = rand.Next(197,200);
        
        Assert.AreEqual(a.All(c => c <= limit), Kata.SmallEnough(a, limit));
      }
    }
  }
}
