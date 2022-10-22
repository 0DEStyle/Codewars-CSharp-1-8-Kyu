/*Challenge link:https://www.codewars.com/kata/5513795bd3fafb56c200049e/train/csharp
Question:
Create a function with two arguments that will return an array of the first n multiples of x.

Assume both the given number and the number of times to count will be positive numbers greater than 0.

Return the results as an array or list ( depending on language ).

Examples
countBy(1,10)  should return  {1,2,3,4,5,6,7,8,9,10}
countBy(2,5)  should return {2,4,6,8,10}
*/

//***************Solution********************
//start at x, count to n*x, if the element modulus x is 0, store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
  public static int[] CountBy(int x, int n) => Enumerable.Range(x, n*x).Where(i => i%x == 0).ToArray();
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class BasicTests
{
  [Test]
  public static void CountBy1()
  {
    Assert.AreEqual(new int[] {1,2,3,4,5,6,7,8,9,10}, Kata.CountBy(1,10), "Array does not match");
  }
  
  [Test]
  public static void CountBy2()
  {
    Assert.AreEqual(new int[] {2,4,6,8,10}, Kata.CountBy(2,5), "Array does not match");
  }
  
  [Test]
  public static void CountBy3()
  {
    Assert.AreEqual(new int[] {3,6,9,12,15,18,21}, Kata.CountBy(3,7), "Array does not match");
  }
  
  [Test]
  public static void CountBy50()
  {
    Assert.AreEqual(new int[] {50,100,150,200,250}, Kata.CountBy(50,5), "Array does not match");
  }
  
  [Test]
  public static void CountBy100()
  {
    Assert.AreEqual(new int[] {100,200,300,400,500,600}, Kata.CountBy(100,6), "Array does not match");
  }
}

[TestFixture]
public static class RandomTests
{
  [Test]
  public static void Test()
  {
    Random r = new Random();
    for(int k = 0; k < 20; k++)
    {
      int x = r.Next(1, 100);
      int n = r.Next(1, 20);
      Assert.AreEqual(Solve(x,n), Kata.CountBy(x,n), "Did not work for this random test");
    }
  }
  
  private static int[] Solve(int x, int n) {
    int[] z = new int[n];
    for(int i = 0; i < n; i++)
      z[i] = (i+1) * x;
    return z;
  }
}
