/*Challenge link:https://www.codewars.com/kata/56214b6864fe8813f1000019/train/csharp
Question:
Terminal game bug squashing
You are creating a text-based terminal version of your favorite board game. In the board game, each turn has six steps that must happen in this order: roll the dice, move, combat, get coins, buy more health, and print status.

You are using a library that already has the functions below. Create a function named main that calls the functions in the proper order.

- `Combat`
- `BuyHealth`
- `GetCoins`
- `PrintStatus`
- `RollDice`
- `Move`
*/

//***************Solution********************
//fixed function call order, missing semi colon and spelling mistake.
using System;

public static partial class Kata
{
  public static int Health = 100;
  public static int Position = 0;
  public static int Coins = 0;
  
  public static void PlayTurn()
  {
    RollDice();
    Move();
    Combat();
    GetCoins();
    BuyHealth();
    PrintStatus();
  }
}

//2nd solution
using System.Linq;

public static partial class Kata
{
  public static int Health = 100;
  public static int Position = 0;
  public static int Coins = 0;
  
  public static void PlayTurn()
  {
    Log = "RollDice Move Combat GetCoins BuyHealth PrintStatus".Split().ToList();
  }
}
//****************Sample Test*****************
namespace Solution
{
  using System;
  using NUnit.Framework;
  
  [TestFixture]
  public class KataTests 
  {
    [Test, Description("Kata should define variables and store values")]
    public void VariableTest() 
    {
      Assert.AreEqual(100, Kata.Health);
      Assert.AreEqual(0, Kata.Position);
      Assert.AreEqual(0, Kata.Coins);
    }
    
    [Test, Description("PlayTurn should not throw an exception")]
    public void ErrorTest()
    {
      Assert.DoesNotThrow(() => Kata.PlayTurn());
    }
    
    [Test, Description("should roll dice first")]
    public void OrderTest1()
    {
      Assert.AreEqual("RollDice", Kata.Log[0]);
    }
    
    [Test, Description("should move second")]
    public void OrderTest2()
    {
      Assert.AreEqual("Move", Kata.Log[1]);
    }
  
    [Test, Description("should combat third")]
    public void OrderTest3()
    {
      Assert.AreEqual("Combat", Kata.Log[2]);
    }
    
    [Test, Description("should get coins fourth")]
    public void OrderTest4()
    {
      Assert.AreEqual("GetCoins", Kata.Log[3]);
    }
    
    [Test, Description("should buy health fifth")]
    public void OrderTest5()
    {
      Assert.AreEqual("BuyHealth", Kata.Log[4]);
    }
    
    [Test, Description("should print status sixth")]
    public void OrderTest6()
    {
      Assert.AreEqual("PrintStatus", Kata.Log[5]);
    }
  }
}
