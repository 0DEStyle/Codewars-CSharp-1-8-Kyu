/*Challenge link:https://www.codewars.com/kata/525caa5c1bf619d28c000335/train/csharp
Question:
If we were to set up a Tic-Tac-Toe game, we would want to know whether the board's current state is solved, wouldn't we? Our goal is to create a function that will check that for us!

Assume that the board comes in the form of a 3x3 array, where the value is 0 if a spot is empty, 1 if it is an "X", or 2 if it is an "O", like so:

[[0, 0, 1],
 [0, 1, 2],
 [2, 1, 0]]
We want our function to return:

-1 if the board is not yet finished AND no one has won yet (there are empty spots),
1 if "X" won,
2 if "O" won,
0 if it's a cat's game (i.e. a draw).
You may assume that the board passed in is valid in the context of a game of Tic-Tac-Toe.
*/

//***************Solution********************
public class TicTacToe{
    public int IsSolved(int[,] board){
      //diagonal lines
        int d1 = 1, d2 = 1;
      //check if board is finished.
        bool empty = false;
      
      //size 3 x 3
        for (int i = 0; i < 3; i++){
            d1 *= board[i, i];     // diagonal \
            d2 *= board[2 - i, i]; // diagonal  /
            int row = 1, col = 1;
          
          //stack result for row and col
            for (int j = 0; j < 3; j++){
                row *= board[i, j];
                col *= board[j, i];
            }
          
            if (row == 1 || col == 1) return 1;
            if (row == 8 || col == 8) return 2;
            if (row == 0 || col == 0) empty = true;           
        }
      
        return d1 == 1 || d2 == 1 ? 1 : // return 1 if x wins
               d1 == 8 || d2 == 8 ? 2 : // return 2 if o wins
               empty ? -1 : 0;          // return -1 if empty, else return 0
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class TicTacToeTest {
	private TicTacToe tictactoe = new TicTacToe();
  
	[Test]
	public void TestingReturnOfIsSolvedMethod() {
    var boards = new Dictionary<int[,], int>();
    boards.Add(new int[,] { { 1, 1, 1 }, { 0, 2, 2 }, { 0, 0, 0 } }, 1);
    boards.Add(new int[,] { { 1, 2, 0 }, { 0, 1, 2 }, { 0, 0, 1 } }, 1);
    boards.Add(new int[,] { { 2, 1, 1 }, { 0, 1, 1 }, { 2, 2, 2 } }, 2);
    boards.Add(new int[,] { { 2, 2, 2 }, { 0, 1, 1 }, { 1, 0, 0 } }, 2);
    boards.Add(new int[,] { { 2, 1, 2 }, { 2, 1, 1 }, { 1, 2, 1 } }, 0);
    boards.Add(new int[,] { { 1, 2, 1 }, { 1, 1, 2 }, { 2, 1, 2 } }, 0);
    boards.Add(new int[,] { { 2, 0, 2 }, { 2, 1, 1 }, { 1, 2, 1 } }, -1);
    boards.Add(new int[,] { { 0, 0, 2 }, { 0, 0, 0 }, { 1, 0, 1 } }, -1);
    boards.Add(new int[,] { { 1, 2, 1 }, { 1, 1, 2 }, { 2, 2, 0 } }, -1);
    boards.Add(new int[,] { { 0, 2, 2 }, { 2, 1, 1 }, { 0, 0, 1 } }, -1);
    boards.Add(new int[,] { { 0, 1, 1 }, { 2, 0, 2 }, { 2, 1, 0 } }, -1);

    Random r = new Random();
    boards = boards.OrderBy(o => r.Next()).ToDictionary(b => b.Key, b => b.Value);

    foreach (KeyValuePair<int[,], int> boardMap in boards)
    {
      var actual = tictactoe.IsSolved(boardMap.Key);
      var expected = boardMap.Value;
      var err = String.Join(" ", boardMap.Key.OfType<int>().Select((n, i) => (i % 3) == 0 ? "\n" + n : "" + n));
      Assert.AreEqual(expected, actual, "For the following board: " + err);
    }
	}
}
