/*Challenge link:https://www.codewars.com/kata/57089707fe2d01529f00024a/train/csharp
Question:
If/else syntax debug
While making a game, your partner, Greg, decided to create a function to check if the user is still alive called checkAlive/CheckAlive/check_alive. Unfortunately, Greg made some errors while creating the function.

checkAlive/CheckAlive/check_alive should return true if the player's health is greater than 0 or false if it is 0 or below.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression

public class Player{
  private int health = 100;
  public int Health{
    get{return this.health;}
    set{health = value;}
}
  public Player(){
  }
  public bool CheckAlive() => this.Health > 0;
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    [Test, Description("Should return the proper result with fixed tests")]
    public void FixedTest()
    {
      Player greg = new Player();
      greg.Health = 5;
      Assert.AreEqual(true, greg.CheckAlive());
      
      Player joe = new Player();
      joe.Health = 0;
      Assert.AreEqual(false, joe.CheckAlive());
    }
    
    [Test, Description("Should return the proper result with random tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int health = rnd.Next(-10, 11);
        Player player = new Player();
        player.Health = health;
        
        bool expected = health > 0;
        bool actual = player.CheckAlive();
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
