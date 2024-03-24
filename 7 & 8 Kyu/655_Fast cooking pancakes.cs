/*Challenge link:https://www.codewars.com/kata/58552bdb68b034a1a80001fb/train/csharp
Question:
You need to cook pancakes, but you are very hungry. As known, one needs to fry a pancake one minute on each side. What is the minimum time you need to cook n pancakes, if you can put on the frying pan only m pancakes at a time? n and m are positive integers between 1 and 1000.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//n pancakes, m max pancake each time
//if n is less than m, return 2 times
//else 2 * pancakes + max each time - 1, divide by max pancake each time
public static class Kata {
  public static int CookPancakes(int n, int m) => n < m ? 2 : (2 * n + m - 1) / m;
}

//****************Sample Test*****************
namespace Solution {
  
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class SolutionTest
  {
    static void Act(int expected, int n, int m)
      => Assert.AreEqual(expected, Kata.CookPancakes(n, m), $"Input -> n = {n}, m = {m}");
    
    [TestCase(2, 1, 2)]
    [TestCase(2, 2, 2)]
    [TestCase(3, 3, 2)]
    [TestCase(4, 4, 2)]
    [TestCase(3, 4, 3)]
    [TestCase(2, 4, 4)]
    [TestCase(2, 1, 4)]
    [TestCase(2, 2, 3)]
    [TestCase(3, 5, 4)]
    [TestCase(4, 6, 3)]
    [TestCase(3, 6, 5)]
    [TestCase(6, 3, 1)]
    public void FixedTests(int expected, int n, int m) => Act(expected, n, m);
    
    [Test]
    public void RandomTests([Random(1, 1000, 20)] int n, [Random(1, 1000, 20)] int m)
    {
      var expected = n >= m ? (int) Math.Ceiling(2.0 * n / m) : 2;
      Act(expected, n, m);
    }
  }
}
