/*Challenge link:https://www.codewars.com/kata/55849d76acd73f6cc4000087/train/csharp
Question:
Let's imagine we have a popular online RPG. A player begins with a score of 0 in class E5. A1 is the highest level a player can achieve.

Now let's say the players wants to rank up to class E4. To do so the player needs to achieve at least 100 points to enter the qualifying stage.

Write a script that will check to see if the player has achieved at least 100 points in his class. If so, he enters the qualifying stage.

In that case, we return, "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.".

Otherwise return, False/false (according to the language in use).

NOTE
: Remember, in C# you have to cast your output value to Object type!
*/

//***************Solution********************
//check if points is greater or equal to 100
//if true return the according string
//else return false.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static Object PlayerRankUp(int points)=> 
    points >= 100 ? "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up." : false;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class PlayerRankUp
{
  [Test]
  public static void Test25()
  {
    Assert.AreEqual(Kata.PlayerRankUp(25), false);
  }
  
  [Test]
  public static void Test34()
  {
    Assert.AreEqual(Kata.PlayerRankUp(34), false);
  }
  
  [Test]
  public static void Test45()
  {
    Assert.AreEqual(Kata.PlayerRankUp(45), false);
  }
  
  [Test]
  public static void Test59()
  {
    Assert.AreEqual(Kata.PlayerRankUp(59), false);
  }
  
  [Test]
  public static void Test64()
  {
    Assert.AreEqual(Kata.PlayerRankUp(64), false);
  }
  
  [Test]
  public static void Test100()
  {
    Assert.AreEqual(Kata.PlayerRankUp(100), "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.");
  }
  
  [Test]
  public static void Test105()
  {
    Assert.AreEqual(Kata.PlayerRankUp(105), "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.");
  }
  
  [Test]
  public static void Test111()
  {
    Assert.AreEqual(Kata.PlayerRankUp(111), "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.");
  }
  
  [Test]
  public static void Test118()
  {
    Assert.AreEqual(Kata.PlayerRankUp(118), "Well done! You have advanced to the qualifying stage. Win 2 out of your next 3 games to rank up.");
  }
}
