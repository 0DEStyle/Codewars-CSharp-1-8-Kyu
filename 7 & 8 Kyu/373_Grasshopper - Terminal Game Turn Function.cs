/*Challenge link:https://www.codewars.com/kata/56019d3b2c39ccde76000086/train/csharp
Question:
Terminal game turn function
You are creating a text-based terminal version of your favorite board game. In the board game, each turn has six steps that must happen in this order: roll the dice, move, combat, get coins, buy more health, and print status.

You are using a library (Game.Logic in C#) that already has the functions below. Create a function named doTurn/DoTurn/do_turn that calls the functions in the proper order as described in the paragraph above.

- Combat
- BuyHealth
- GetCoins
- PrintStatus
- RollDice
- Move
*/

//***************Solution********************

//call function in this order "each turn has six steps that must happen in this order: roll the dice, move, combat, get coins, buy more health, and print status."
using static Game.Logic;

public class Kata{
  public static void DoTurn(){
    RollDice();
    Move();
    Combat();
    GetCoins();
    BuyHealth();
    PrintStatus();
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using static Game.Logic;
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("One Turn")]
    public void Test()
    {
      Kata.DoTurn();
    
      Assert.AreEqual(6, Log.Count, "should call all 6 functions");
      Assert.AreEqual("RollDice", Log[0], "should roll dice first");
      Assert.AreEqual("Move", Log[1], "should move second");
      Assert.AreEqual("Combat", Log[2], "should combat third");
      Assert.AreEqual("GetCoins", Log[3], "should get coins fourth");
      Assert.AreEqual("BuyHealth", Log[4], "should buy health fifth");
      Assert.AreEqual("PrintStatus", Log[5], "should print status sixth");
    }
  }
}
