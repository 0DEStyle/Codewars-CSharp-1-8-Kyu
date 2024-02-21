/*Challenge link:https://www.codewars.com/kata/5a03b3f6a1c9040084001765/train/csharp
Question:
Find the total sum of internal angles (in degrees) in an n-sided simple polygon. N will be greater than 2.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//apply formula
public class Kata{
    public static int Angle(int n) => (n-2) * 180;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class BasicTests
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual(180, Kata.Angle(3));
      Assert.AreEqual(360, Kata.Angle(4));
    }
  }


  [TestFixture]
  public class RandomTests
  {
    private static int sol(int n)
    {
      return (n-2)*180;
    }
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      for (int i = 0; i<40; i++)
      {
        int[] size = {10,100};
        int n = rnd.Next(3, size[rnd.Next(2)]);
        Console.WriteLine("Testing for {0})", n);
        Assert.AreEqual(RandomTests.sol(n), Kata.Angle(n));
      }
    }
  }
}
