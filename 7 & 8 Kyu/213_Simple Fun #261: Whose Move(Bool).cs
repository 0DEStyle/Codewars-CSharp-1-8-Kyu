/*Challenge link:https://www.codewars.com/kata/59126992f9f87fd31600009b/train/csharp
Question:
Task
Two players - "black" and "white" are playing a game. The game consists of several rounds. If a player wins in a round, he is to move again during the next round. If a player loses a round, it's the other player who moves on the next round. Given whose turn it was on the previous round and whether he won, determine whose turn it is on the next round.

Input/Output
[input] string lastPlayer/$last_player

"black" or "white" - whose move it was during the previous round.

[input] boolean win/$win

true if the player who made a move during the previous round won, false otherwise.

[output] a string

Return "white" if white is to move on the next round, and "black" otherwise.

Example
For lastPlayer = "black" and win = false, the output should be "white".

For lastPlayer = "white" and win = true, the output should be "white".
*/

//***************Solution********************
//check if win is true, if so, lastplayer's turn
//else check if lastPlayer is "black" 
//if so, "white" wins
//else "black" wins
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string WhoseMove(string lastPlayer, bool win) => 
    win ? lastPlayer : lastPlayer == "black" ?  "white" : "black";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void FixedTests()
    {
      Assert.AreEqual("white", Kata.WhoseMove("black", false));
      Assert.AreEqual("white", Kata.WhoseMove("white", true));
      Assert.AreEqual("black", Kata.WhoseMove("white", false));
    }
    
    private static string Solution(string lastPlayer, bool win)
    {
      if (win) return lastPlayer;
      else return (lastPlayer == "white") ? "black" : "white";
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 100; ++i)
      {
        string lastPlayer = "white";
        if (rnd.Next(0, 2) == 1) lastPlayer = "black";
        bool win = false;
        if (rnd.Next(0, 2) == 1) win = true;
        Assert.AreEqual(Solution(lastPlayer, win), Kata.WhoseMove(lastPlayer, win));
      }
    }
  }
}
