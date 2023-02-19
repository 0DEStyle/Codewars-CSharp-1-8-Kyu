/*Challenge link:https://www.codewars.com/kata/55c28f7304e3eaebef0000da/train/csharp
Question:
Unfinished Loop - Bug Fixing #1
Oh no, Timmy's created an infinite loop! Help Timmy find and fix the bug in his unfinished for loop!
add .cs 
*/

//***************Solution********************
//from range 1 to n, add to list, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq; //WTF TIMMY!!! LEARN LINQ!!!
using System.Collections.Generic;

public class Kata{
  public static List<int> CreateList(int n) => Enumerable.Range(1, n).ToList();
}


//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  public static void FixedTest()
  {
    List<int> myValues = new List<int>(new int[] { 1 } );
    Assert.AreEqual(myValues, Kata.CreateList(1));
    
    myValues = new List<int>(new int[] { 1, 2 } );
    Assert.AreEqual(myValues, Kata.CreateList(2));
    
    myValues = new List<int>(new int[] { 1, 2, 3, 4, 5, 6 } );
    Assert.AreEqual(myValues, Kata.CreateList(6));
  }
  
  [Test]
  public static void RandomTests()
  {
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = r.Next(100)+1;
      Assert.AreEqual(Solution(num), Kata.CreateList(num));
    }
  }
  
  private static List<int> Solution(int num)
  {
    List<int> list = new List<int>();
    for(int counter = 1; counter <= num; counter++)
    {
      list.Add(counter);
    }
    return list;
  }
}
