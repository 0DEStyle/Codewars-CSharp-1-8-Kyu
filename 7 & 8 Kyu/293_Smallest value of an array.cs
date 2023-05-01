/*Challenge link:https://www.codewars.com/kata/544a54fd18b8e06d240005c0/train/csharp
Question:
Write a function that can return the smallest value of an array or the index of that value. The function's 2nd parameter will tell whether it should return the value or the index.

Assume the first parameter will always be an array filled with at least 1 number and no duplicates. Assume the second parameter will be a string holding one of two values: 'value' and 'index'.

min([1,2,3,4,5], 'value') // => 1
min([1,2,3,4,5], 'index') // => 0
*/

//***************Solution********************
//check if string is equal "value"
//if so, return the minimum value from array
//anything else, return the index of the minimum value from array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static int FindSmallest(int[] numbers, string toReturn)=>
    toReturn  == "value" ? numbers.Min() : Array.IndexOf(numbers, numbers.Min());
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class FindSmallest
{
  [Test]
  public void Test_54321_value()
  {
    Assert.AreEqual(1, Kata.FindSmallest(new int[]{ 5, 4, 3, 2, 1}, "value"));
  }
  
  [Test]
  public void Test_54321_index()
  {
    Assert.AreEqual(4, Kata.FindSmallest(new int[]{ 5, 4, 3, 2, 1}, "index"));
  }
  
  [Test]
  public void Test_809_index()
  {
    Assert.AreEqual(1, Kata.FindSmallest(new int[]{ 8, 0, 9}, "index"));
  }
  
  [Test]
  public void Test_809_value()
  {
    Assert.AreEqual(0, Kata.FindSmallest(new int[]{ 8, 0, 9}, "value"));
  }
  
  [Test]
  public void Test_110011_index()
  {
    Assert.AreEqual(2, Kata.FindSmallest(new int[]{ 1, 1, 0, 0, 1, 1}, "index"));
  }
  
  [Test]
  public void Test_110011_value()
  {
    Assert.AreEqual(0, Kata.FindSmallest(new int[]{ 1, 1, 0, 0, 1, 1}, "value"));
  }
}
