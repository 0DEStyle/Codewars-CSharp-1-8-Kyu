/*Challenge link:https://www.codewars.com/kata/57a5b0dfcf1fa526bb000118/train/csharp
Question:
Define a function that removes duplicates from an array of numbers and returns it as a result.

The order of the sequence has to stay the same.
*/

//***************Solution********************
//find all distinct elements in array, then store in array and retunr the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

namespace Solution{
  public static class Program{
    public static int[] distinct(int[] a)=> a.Distinct().ToArray();
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void MyTest()
    {
      Assert.AreEqual(new int[]{1}, Program.distinct(new int[]{1}));
      Assert.AreEqual(new int[]{1,2}, Program.distinct(new int[]{1,2}));
      Assert.AreEqual(new int[]{1,2}, Program.distinct(new int[]{1,1,2}));
      Assert.AreEqual(new int[]{1,2,3,4,5}, Program.distinct(new int[]{1,1,1,2,3,4,5}));
      Assert.AreEqual(new int[]{1,2,3,4,5,6,7}, Program.distinct(new int[]{1,2,2,3,3,4,4,5,6,7,7,7}));
    }
  }
}
