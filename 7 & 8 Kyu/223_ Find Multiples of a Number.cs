/*Challenge link:https://www.codewars.com/kata/58ca658cc0d6401f2700045f
Question:
In this simple exercise, you will build a program that takes a value, integer , and returns a list of its multiples up to another value, limit . If limit is a multiple of integer, it should be included as well. There will only ever be positive integers passed into the function, not consisting of 0. The limit will always be higher than the base.

For example, if the parameters passed are (2, 6), the function should return [2, 4, 6] as 2, 4, and 6 are the multiples of 2 up to 6.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;

public class Kata{
  public static List<int> FindMultiples(int integer, int limit){
    List<int> num = new List<int>();
    
    for(int i = integer; i <= limit; i+=integer)
      num.Add(i);
    
    return num;
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new List<int> { 5, 10, 15, 20, 25 }, Kata.FindMultiples(5, 25));
      Assert.AreEqual(new List<int> { 1, 2 }, Kata.FindMultiples(1, 2));
    }
    
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual(new List<int> { 5 }, Kata.FindMultiples(5, 7));
      Assert.AreEqual(new List<int> { 4, 8, 12, 16, 20, 24 }, Kata.FindMultiples(4, 27));
      Assert.AreEqual(new List<int> { 11, 22, 33, 44 }, Kata.FindMultiples(11, 54));
    }
    
    private static List<int> Solution(int integer, int limit)
    {
      List <int> result = new List<int>();
      for (int i = integer; i <= limit; i += integer)
      {
        result.Add(i);
      }
      return result;
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 50; ++i)
      {
        int integer = rnd.Next(1, 101);
        int limit = rnd.Next(101, 30001);
        Assert.AreEqual(Solution(integer, limit), Kata.FindMultiples(integer, limit));
      }
    }
  }
}
