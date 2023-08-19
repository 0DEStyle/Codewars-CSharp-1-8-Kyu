/*Challenge link:https://www.codewars.com/kata/5526fc09a1bbd946250002dc/train/csharp
Question:
You are given an array (which will have a length of at least 3, but could be very large) containing integers. The array is either entirely comprised of odd integers or entirely comprised of even integers except for a single integer N. Write a method that takes the array as an argument and returns this "outlier" N.

Examples
[2, 4, 0, 100, 4, 11, 2602, 36]
Should return: 11 (the only odd number)

[160, 3, 1719, 19, 11, 13, -21]
Should return: 160 (the only even number)
*/

//***************Solution********************
//check if current element contains only 1 even or odd number, if so, return that element.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int Find(int[] integers) =>
    integers.Count(a => a % 2 == 1) > 1 ? integers.Single(a => a % 2 == 0): integers.Single(a => a % 2 == 1);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  public static void Test1()
  {
    int[] exampleTest1 = {2,6,8,-10,3}; 
    Assert.IsTrue(3 == Kata.Find(exampleTest1));
  }
  
  [Test]
  public static void Test2()
  {  
    int[] exampleTest2 = {206847684,1056521,7,17,1901,21104421,7,1,35521,1,7781};
    Assert.IsTrue(206847684 == Kata.Find(exampleTest2));
  }
  
  [Test]
  public static void Test3()
  {
    int[] exampleTest3 = { int.MaxValue, 0, 1 };
    Assert.IsTrue(0 == Kata.Find(exampleTest3));
  }
}
