/*Challenge link:https://www.codewars.com/kata/55f73be6e12baaa5900000d4/train/csharp
Question:
Messi goals function
Messi is a soccer player with goals in three leagues:

LaLiga
Copa del Rey
Champions
Complete the function to return his total number of goals in all three leagues.

Note: the input will always be valid.

For example:

5, 10, 2  -->  17
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression.
//add all 3 variables together and return the result
public class Kata{
  public static int GetGoals(int a, int b, int c) =>  a + b + c;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void NoGoals()
    {
      Assert.AreEqual(Kata.GetGoals(0,0,0),0);
    }
    [Test]
    public void FiftyEightGoals()
    {
      Assert.AreEqual(Kata.GetGoals(43,10,5),58);
    }
    [Test]
    public void RandomGoals()
    {
      Func<int, int, int, int> solution = (ll, cl, cdr) => ll + cl + cdr;
      Random rnd = new Random();
      for (var i = 0; i < 100; i++) 
      {
        var l = rnd.Next() % 100;
        var c = rnd.Next() % 100;
        var r = rnd.Next() % 100;

        Assert.AreEqual(solution(l, c, r), Kata.GetGoals(l, c, r));
      }
    }
  }
}
