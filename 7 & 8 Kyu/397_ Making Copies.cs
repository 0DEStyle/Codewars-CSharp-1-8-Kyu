/*Challenge link:https://www.codewars.com/kata/53d2697b7152a5e13d000b82/train/csharp
Question:
Write a function that takes a list (in Python) or array (in other languages) of numbers, and makes a copy of it.

Note that you may have troubles if you do not return an actual copy, item by item, just a pointer or an alias for an existing list or array.

If not a list or array is given as a parameter in interpreted languages, the function should raise an error.

Examples:

List<int> lst = new int[] {1, 2, 3, 4}.ToList();
List<int> lstCopy = lst.Copy();
lst[1] += 5;
lst == {1, 7, 3, 4};
lstCopy == {1, 2, 3, 4};
*/

//***************Solution********************
//make a new list
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;

public static class ListExtensions{
  public static List<T> Copy<T>(this List<T> l) =>  new List<T>(l);
}

//solution 2
using System.Collections.Generic;
using System.Linq;

public static class ListExtensions
{
  public static List<T> Copy<T>(this List<T> lst) => lst.ToList();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    [Test]
    public void FixedTest()
    {
      List<int> lst = new int[] {1, 2, 3, 4}.ToList();
      List<int> lstCopy = lst.Copy();
      Assert.That(lstCopy, Is.EqualTo(lst), "Copy unsuccessful");
      
      lst[1] += 5;
      Assert.That(lstCopy, Is.Not.EqualTo(lst), "The list was not properly copied");
      
      List<int> lstCopyCopy = lstCopy.Copy();
      Assert.That(lstCopyCopy, Is.EqualTo(lstCopy));
      lstCopy[rnd.Next(0, 4)] += rnd.Next(1, 5);
      Assert.That(lstCopyCopy, Is.Not.EqualTo(lst), "The copied list was not properly copied");
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        List<int> testLst = new int[rnd.Next(2, 10)].Select(_ => rnd.Next(0, 100)).ToList();
        List<int> testLstCopy = testLst.Copy();
        Assert.That(testLstCopy, Is.EqualTo(testLst));
        testLst.Add(rnd.Next(0, 100));
        Assert.That(testLstCopy, Is.Not.EqualTo(testLst));
      }
    }
  }
}
