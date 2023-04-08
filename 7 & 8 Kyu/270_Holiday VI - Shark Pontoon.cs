/*Challenge link:https://www.codewars.com/kata/57e921d8b36340f1fd000059/train/csharp
Question:
Your friend invites you out to a cool floating pontoon around 1km off the beach. Among other things, the pontoon has a huge slide that drops you out right into the ocean, a small way from a set of stairs used to climb out.

As you plunge out of the slide into the water, you see a shark hovering in the darkness under the pontoon... Crap!

You need to work out if the shark will get to you before you can get to the pontoon. To make it easier... as you do the mental calculations in the water you either freeze when you realise you are dead, or swim when you realise you can make it!

You are given 5 variables;

sharkDistance = distance from the shark to the pontoon. The shark will eat you if it reaches you before you escape to the pontoon.

sharkSpeed = how fast it can move in metres/second.

pontoonDistance = how far you need to swim to safety in metres.

youSpeed = how fast you can swim in metres/second.

dolphin = a boolean, if true, you can half the swimming speed of the shark as the dolphin will attack it.

The pontoon, you, and the shark are all aligned in one dimension.

If you make it, return "Alive!", if not, return "Shark Bait!".
*/

//***************Solution********************

//apply algorithm, and return the result accordingly
public class Kata{
    public static string Shark(
      int pontoonDistance, 
      int sharkDistance, 
      int youSpeed, 
      int sharkSpeed, 
      bool dolphin){
      
       double sharkSpeedz = sharkSpeed;
       double youSpeedz = youSpeed;
      if(dolphin == true)
        sharkSpeedz = sharkSpeed / 2; 
      
        return ((pontoonDistance / youSpeedz) >= (sharkDistance / sharkSpeedz)) ? "Shark Bait!" : "Alive!";
    }
}

//solution 2
//Simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static string Shark(int pontoonDistance, int sharkDistance, int yourSpeed, int sharkSpeed, bool dolphin)
  {
    return pontoonDistance * sharkSpeed < yourSpeed * sharkDistance * (dolphin ? 2 : 1)
      ? "Alive!"
      : "Shark Bait!";
  }
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
      Assert.AreEqual("Alive!", Kata.Shark(12, 50, 4, 8, true));
      Assert.AreEqual("Alive!", Kata.Shark(12, 50, 4, 8, false));
      Assert.AreEqual("Alive!", Kata.Shark(7, 55, 4, 16, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(24, 0, 4, 8, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(40, 35, 3, 20, true));
      Assert.AreEqual("Alive!", Kata.Shark(7, 8, 3, 4, true));
      Assert.AreEqual("Shark Bait!", Kata.Shark(7, 8, 3, 4, false));
    }
  }

  [TestFixture]
  public class RandomTests
  {
    private static string sol(int pd, int sd, int ys, int ss, bool d)
    {
      double yt = 1.0 * pd / ys;
      double st = sd * (d ? 2.0 : 1.0) / ss;
      return yt < st ? "Alive!" : "Shark Bait!";
    }
    
    [Test]
    public void RandomTest()
    {
      Random rand = new Random();
      for (int i = 0; i < 100; i++)
      {
        int pd = rand.Next(1, 50);
        int sd = rand.Next(1, 200);
        int ys = rand.Next(1, 4);
        int ss = rand.Next(1, 20);
        bool d = rand.Next(0, 1) == 1;
        Assert.AreEqual(sol(pd, sd, ys, ss, d), Kata.Shark(pd, sd, ys, ss, d), $"Shark({pd}, {sd}, {ys}, {ss}, {d})");
      }
    }
  }
}
