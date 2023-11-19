/*Challenge link:https://www.codewars.com/kata/56b1eb19247c01493a000065/train/csharp
Question:
Given a list of integers values, your job is to return the sum of the values; however, if the same integer value appears multiple times in the list, you can only count it once in your sum.

For example:

Kata.UniqueSum(new List<int> {1, 2, 3}) => 6

Kata.UniqueSum(new List<int> {1, 3, 8, 1, 8}) => 12

Kata.UniqueSum(new List<int> {-1, -1, 5, 2, -7}) => -1

Kata.UniqueSum(new List<int>()) => null
Good Luck!
*/

//***************Solution********************

//check if list is null, is so return null, else find all distinct number in list and find the sum.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static int? UniqueSum(List<int> lst) => lst.Count() == 0 ? null : lst.Distinct().Sum();
}

//solution 2
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static int? UniqueSum(List<int> lst)
  {
    return lst.Any() ? lst.Distinct().Sum() : new int?();
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
      public class Kata15Feb
      {
          public static int? Unique_sum(List<int> lst)
          {
              if (lst.Count == 0)
              {
                  return null;
              }
              return lst.Distinct().Sum(p => p);
          }
      }
      
      
    public class Rg
      {
          static Random _random;
          private static int _counter;
          public Rg(int seed)
          {
              _counter = _counter + 1;
              _random = new Random(seed + _counter);
          }
  
          public List<int> MyList()
          {
              int counter = _random.Next(0, 10);
              List<int> myList = new List<int>();
              for (int i = 0; i < counter; i++)
              {
                  myList.Add(_random.Next(-10,10));
              }
              return myList;
          }
      }
  
  
      [TestFixture]
      public class Test
      {
          [Test]
          public void Test1()
          {
              Assert.AreEqual(6, Kata.UniqueSum(new List<int>() {1, 2, 3}));
              Assert.AreEqual(12, Kata.UniqueSum(new List<int>() {1, 3, 8, 1, 8}));
              Assert.AreEqual(-1, Kata.UniqueSum(new List<int>() {-1, -1, 5, 2, -7}));
          }
  
  
          [Test]
          public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
          {
              Rg rg = new Rg((int)d * 10000);
              List<int> myList = rg.MyList();
              Assert.AreEqual(Kata15Feb.Unique_sum(myList),Kata.UniqueSum(myList));
          }
      }
}
