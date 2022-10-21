/*Challenge link:https://www.codewars.com/kata/563a631f7cbbc236cf0000c2/train/csharp
Question:
Terminal game move function
In this game, the hero moves from left to right. The player rolls the dice and moves the number of spaces indicated by the dice two times.

Create a function for the terminal game that takes the current position of the hero and the roll (1-6) and return the new position.

Example:
move(3, 6) should equal 15
*/

//***************Solution********************
//apply algorithm 
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Game
{
  public static int Move(int position, int roll) => position + (roll*2);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [TestCase(0,4,8)]
  [TestCase(3,6,15)]
  [TestCase(2,5,12)]
  public void FixedTests(int position, int roll, int expected)
  {
    Assert.That(Game.Move(position,roll),Is.EqualTo(expected));
  }
  
  [Test]
  public void RandomTests()
  {
    for (var i = 0; i < 20; i++)
    {
      var roll = FloorRand(6);
      var position = FloorRand(20);
      Assert.That(Game.Move(position, roll), Is.EqualTo(Solution(position, roll)));
    }
  }
  
  private int Solution(int position, int roll)
  {
    return position + (roll * 2);
  }
  
  private int FloorRand(int value)
  {
    var random = new Random();
    return (int) Math.Floor((decimal) random.Next(0, value)) + 1;
  }
  
}
