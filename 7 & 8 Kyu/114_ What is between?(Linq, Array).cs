/*Challenge link:https://www.codewars.com/kata/55ecd718f46fba02e5000029/train/csharp
Question:Complete the function that takes two integers (a, b, where a < b) and return an array of all integers between the input parameters, including them.

For example:

a = 1
b = 4
--> [1, 2, 3, 4]
*/

//***************Solution********************
//start from a, increase number from b - a + 1, convert to array.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

 public static class Kata{
      public static int[] Between(int a, int b) => Enumerable.Range(a, b - a + 1).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTest {
  [Test]
  public void BasicTests() {
    Assert.AreEqual(new int[] { 0, 1, 2, 3 }, Kata.Between(0, 3));
    Assert.AreEqual(new int[] { -2, -1, 0, 1, 2 }, Kata.Between(-2, 2));
    Assert.AreEqual(new int[] { -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, Kata.Between(-10, 10));
  }
  
  private int[] Sol(int a, int b) => Enumerable.Range(a, b - a + 1).ToArray();
  
  [Test]
  public void RandomTests() {
    Random r = new Random();
    for (int i = 0; i < 100; i++) {
      int a = r.Next(-100, 101),
          b = a + r.Next(new int[] { 5, 20, 50 }[r.Next(3)]) + 1;
      Assert.AreEqual(Sol(a, b), Kata.Between(a, b));
    }
  }
}
