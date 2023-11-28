/*Challenge link:https://www.codewars.com/kata/56069d0c4af7f633910000d3/train/csharp
Question:
You love coffee and want to know what beans you can afford to buy it.

The first argument to your search function will be a number which represents your budget.

The second argument will be an array of coffee bean prices.

Your 'search' function should return the stores that sell coffee within your budget.

The search function should return a string of prices for the coffees beans you can afford. The prices in this string are to be sorted in ascending order.


*/

//***************Solution********************

//x is the current element
//in prices, get element where x is less than or equal to budget, order by ascending order, then return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static string Search(int budget, int[] prices) => string.Join(",",prices.Where(x => x <= budget).OrderBy(x=>x));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(3, new int[]{6,1,2,9,2}, ExpectedResult="1,2,2")]
  [TestCase(14, new int[]{7,3,23,9,14,20,7}, ExpectedResult="3,7,7,9,14")]
  [TestCase(0, new int[]{6,1,2,9,2}, ExpectedResult="")]
  public static string FixedTest(int budget, int[] prices)
  {
    return Kata.Search(budget, prices);
  }
  
  private static string Solution(int budget, int[] prices)
  {
    return string.Join(",", new List<int>(prices).Where(x => x <= budget).OrderBy(x => x).ToArray());
  }
  
  [Test]
  public static void RandomTest([Random(0,100,100)]int budget)
  {
    int[] prices = GetRandomArray(10);
    Assert.AreEqual(Solution(budget, prices), Kata.Search(budget, prices));
  }
  
  private static int[] GetRandomArray(int length)
  {
    List<int> nums = new List<int>();
    Random r = new Random();
    while(length > 0)
    {
      nums.Add(r.Next(100));
      length--;
    }
    return nums.ToArray();
  }
}
