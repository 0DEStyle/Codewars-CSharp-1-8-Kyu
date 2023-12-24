/*Challenge link:https://www.codewars.com/kata/56242b89689c35449b000059/train/csharp
Question:
A grid is a perfect starting point for many games (Chess, battleships, Candy Crush!).

Making a digital chessboard I think is an interesting way of visualising how loops can work together.

Your task is to write a function that takes two integers rows and columns and returns a chessboard pattern as a two dimensional array.

So chessBoard(6,4) should return an array like this:

[
    ["O","X","O","X"],
    ["X","O","X","O"],
    ["O","X","O","X"],
    ["X","O","X","O"],
    ["O","X","O","X"],
    ["X","O","X","O"]
]
And chessBoard(3,7) should return this:

[
    ["O","X","O","X","O","X","O"],
    ["X","O","X","O","X","O","X"],
    ["O","X","O","X","O","X","O"]
]
The white spaces should be represented by an: 'O'

and the black an: 'X'

The first row should always start with a white space 'O'
*/

//***************Solution********************
using System;
public class Kata{
  public static char[][] ChessBoard(int row, int column){
    
    //generate board row
    char[][] board = new char[row][];
    for(int i = 0; i < row; i++){
      //generate board column
      board[i] = new char[column];
      
      //Alternating the 'O' and 'X' depend on odd and even index
      for(int j = 0; j < column; j++)
          board[i][j] = (i + j) % 2 == 0 ? 'O' : 'X'; 
    }
    
    /*printing jank
    for(int i = 0; i < row; i++){
      for(int j = 0; j < column; j++)
        Console.Write($"{board[i][j]}");
    Console.WriteLine();
    }
    */
    return board;
  }
}

//solution 2
using System.Linq;

public class Kata
{
    public static char[][] ChessBoard(int row, int columns)
    {
        var evenChessRow = Enumerable.Range(0, columns).Select(c => c%2 == 0 ? 'O' : 'X').ToArray();
        var oddChessRow = Enumerable.Range(0, columns).Select(c => c%2 == 0 ? 'X' : 'O').ToArray();
    
        return Enumerable.Range(0, row).Select(r => r%2 == 0 ? evenChessRow : oddChessRow).ToArray();
    }
}
//solution 3
using System.Linq;

public class Kata
{
  public static char[][] ChessBoard(int row, int columns)
  {
    return new int[row].Select((_, i) => new int[columns].Select((_, j) => (i + j) % 2 == 0 ? 'O' : 'X').ToArray()).ToArray();
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    private Random rand = new Random();
    
    [Test]
    public void FormatTests()
    { 
      for (var i=0; i<8; i++) 
      {
        var rows = rand.Next(1,21);
        var columns = rand.Next(1,21);
      
        Assert.AreEqual(rows, Kata.ChessBoard(rows, columns).Length, "make sure the board has the correct number of rows");
        Assert.AreEqual(columns, Kata.ChessBoard(rows, columns)[0].Length, "make sure the board has the correct number of columns");
      }
    }
    
    [Test]
    public void AlternatingContentTests()
    {
      for (var i=0; i<10; i++) 
      {
        var rows = rand.Next(2,12);
        var columns = rand.Next(2,12);
      
        Console.WriteLine(rows + " - rows, " + columns + " - columns");
        
        var board = Kata.ChessBoard(rows, columns);
        
        Assert.AreEqual(rows, board.Length, "make sure the board has the correct number of rows");
        
        for (var j=0; j<rows; j+=2)
        {
          for(var k=0; k<columns; k++)
          {
            if((j+k) % 2 == 0)
            {
              Assert.AreEqual('O',board[j][k]);
            }
            else
            {
              Assert.AreEqual('X', board[j][k]);
            }
          }
        }
      }  
    }
  }
}
