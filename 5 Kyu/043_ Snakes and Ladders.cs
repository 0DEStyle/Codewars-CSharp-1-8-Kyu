/*Challenge link:https://www.codewars.com/kata/587136ba2eefcb92a9000027/train/csharp
Question:
Introduction
Snakes and Ladders is an ancient Indian board game regarded today as a worldwide classic. It is played between two or more players on a gameboard having numbered, gridded squares. A number of "ladders" and "snakes" are pictured on the board, each connecting two specific board squares. (Source Wikipedia)

Task
Your task is to make a simple class called SnakesLadders. The test cases will call the method play(die1, die2) independantly of the state of the game or the player turn. The variables die1 and die2 are the die thrown in a turn and are both integers between 1 and 6. The player will move the sum of die1 and die2.
The Board

see image in challenge link

Rules
1.  There are two players and both start off the board on square 0.

2.  Player 1 starts and alternates with player 2.

3.  You follow the numbers up the board in order 1=>100

4.  If the value of both die are the same then that player will have another go.

5.  Climb up ladders. The ladders on the game board allow you to move upwards and get ahead faster. If you land exactly on a square that shows an image of the bottom of a ladder, then you may move the player all the way up to the square at the top of the ladder. (even if you roll a double).

6.  Slide down snakes. Snakes move you back on the board because you have to slide down them. If you land exactly at the top of a snake, slide move the player all the way to the square at the bottom of the snake or chute. (even if you roll a double).

7.  Land exactly on the last square to win. The first person to reach the highest square on the board wins. But there's a twist! If you roll too high, your player "bounces" off the last square and moves back. You can only win by rolling the exact number needed to land on the last square. For example, if you are on square 98 and roll a five, move your game piece to 100 (two moves), then "bounce" back to 99, 98, 97 (three, four then five moves.)

8.  If the Player rolled a double and lands on the finish square “100” without any remaining moves then the Player wins the game and does not have to roll again.
Returns
Return Player n Wins!. Where n is winning player that has landed on square 100 without any remainding moves left.

Return Game over! if a player has won and another player tries to play.

Otherwise return Player n is on square x. Where n is the current player and x is the sqaure they are currently on.
Good luck and enjoy!
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars{
    class SnakesLadders{
      
      //starting point 0,0
      //create a map based on the board image provide.
        private int[] playerSquare = new int[2] { 0, 0 };
        private int player = 0;
        private bool won = false;
        private int[,] trap = new int[21, 2]{
          {2,38},{7,14},{8,31},{15,26},{21,42},{28,84},
          {36,44},{51,67},{71,91},{78,98},{87,94},
          {16,6},{46,25},{49,11},{62,19},{64,60},
          {74,53},{89,68},{92,88},{95,75},{99,80}};

        public string play (int die1, int die2){
            if (won) 
              return "Game over!"; 
          
            int roll = die1 + die2;
          
          //if roll + player position is less than or equal to 100
            if (roll + playerSquare[player] <= 100){
                playerSquare[player] += roll;
                if (playerSquare[player] == 100) { 
                  won = true; 
                  return $"Player {player + 1} Wins!"; 
                }
            }
          // Land exactly on the last square to win.
            else
                playerSquare[player] = 100 - ((playerSquare[player] + roll) - 100);
            
          //check for trap
            for (int t = 0; t < trap.Length / 2; t++)
                if (playerSquare[player] == trap[t,0])
                  playerSquare[player] = trap[t, 1]; 
          
          //current postion
            string message = $"Player {player + 1} is on square {playerSquare[player]}";
            if (die1 != die2) { 
              if (player == 0) 
                player = 1; 
              else 
                player = 0;
            }
            return message;
        }
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        private SnakesLadders test1 = new SnakesLadders();
        private SnakesLadders2 test2 = new SnakesLadders2();
        private SnakesLadders test3 = new SnakesLadders();
        private SnakesLadders2 test4 = new SnakesLadders2();
        private SnakesLadders test5 = new SnakesLadders();
        private SnakesLadders2 test6 = new SnakesLadders2();
        private SnakesLadders test7 = new SnakesLadders();
        private SnakesLadders2 test8 = new SnakesLadders2();
        private SnakesLadders test9 = new SnakesLadders();
        private SnakesLadders2 test10 = new SnakesLadders2();

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest1()
        {
            Random ran = new Random();
            int var1 = ran.Next(1, 6);
            int var2 = ran.Next(1, 6);
            string result = test1.play(var1, var2);
            string solution = test2.play(var1, var2);
            Assert.AreEqual(solution, result, "Should return: '"+solution+"'");
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest2()
        {
            Random ran = new Random();
            int var1 = ran.Next(1, 6);
            int var2 = ran.Next(1, 6);
            string result = test3.play(var1, var2);
            string solution = test4.play(var1, var2);
            Assert.AreEqual(solution, result, "Should return: '" + solution + "'");
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest3()
        {
            Random ran = new Random();
            int var1 = ran.Next(1, 6);
            int var2 = ran.Next(1, 6);
            string result = test5.play(var1, var2);
            string solution = test6.play(var1, var2);
            Assert.AreEqual(solution, result, "Should return: '" + solution + "'");
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest4()
        {
            Random ran = new Random();
            int var1 = ran.Next(1, 6);
            int var2 = ran.Next(1, 6);
            string result = test7.play(var1, var2);
            string solution = test8.play(var1, var2);
            Assert.AreEqual(solution, result, "Should return: '" + solution + "'");
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest5()
        {
            Random ran = new Random();
            int var1 = ran.Next(1, 6);
            int var2 = ran.Next(1, 6);
            string result = test9.play(var1, var2);
            string solution = test10.play(var1, var2);
            Assert.AreEqual(solution, result, "Should return: '" + solution + "'");
        }
    }

    class SnakesLadders2
    {
        private int[] playerSquare = new int[2] { 0, 0 };
        private int player = 0;
        private bool won = false;
        private int[,] trap = new int[21, 2]{{2,38},{7,14},{8,31},{15,26},{21,42},{28,84},{36,44},{51,67},{71,91},{78,98},{87,94},
                    {16,6},{46,25},{49,11},{62,19},{64,60},{74,53},{89,68},{92,88},{95,75},{99,80}};

        public string play(int die1, int die2)
        {
            if (won) { return "Game over!"; }
            int roll = die1 + die2;
            if (roll + playerSquare[player] <= 100)
            {
                playerSquare[player] += roll;
                if (playerSquare[player] == 100) { won = true; return "Player " + (player + 1).ToString() + " Wins!"; }
            }
            else
            {
                playerSquare[player] = 100 - ((playerSquare[player] + roll) - 100);
            }
            for (int t = 0; t < trap.Length / 2; t++)
            {
                if (playerSquare[player] == trap[t, 0]) { playerSquare[player] = trap[t, 1]; }
            }
            string message = "Player " + (player + 1).ToString() + " is on square " + (playerSquare[player]).ToString();
            if (die1 != die2) { if (player == 0) { player = 1; } else { player = 0; }; }
            return message;
        }
    }
}
