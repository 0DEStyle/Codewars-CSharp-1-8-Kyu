/*Challenge link:https://www.codewars.com/kata/56882731514ec3ec3d000009/train/csharp
Question:
Connect Four
Take a look at wiki description of Connect Four game:

Wiki Connect Four

The grid is 6 row by 7 columns, those being named from A to G.

You will receive a list of strings showing the order of the pieces which dropped in columns:

List<string> myList = new List<string>()
{
    "A_Red",
    "B_Yellow",
    "A_Red",
    "B_Yellow",
    "A_Red",
    "B_Yellow",
    "G_Red",
    "B_Yellow"
};
The list may contain up to 42 moves and shows the order the players are playing.

The first player who connects four items of the same color is the winner.

You should return "Yellow", "Red" or "Draw" accordingly.
*/

//***************Solution********************
/* Grid 6 x 7, Player Red and Yellow

6
5
4
3
2
1
  A B C D E F G 
  
*/

using System;
using System.Linq;
using System.Collections.Generic;

public class ConnectFour{
  
  //check winner
    private static bool IsWinner(List<int> board, int i, int i1, int i2, int i3, Func<int, bool> isValid, out string winner){
        winner="";
        if (isValid(i)) {
            var v = board[i]+board[i1]+board[i2]+board[i3];
            if (v==4) 
              winner="Red"; 
            else if (v==-4) 
              winner="Yellow"; 
         }
         return winner!="";
    }
  
  //6x7 = 42 placements. 
    private static List<int> GetBoard(List<string> moves){        
        var board = new int[42].ToList();
      //pass data into MakeMove()
        moves.ForEach(m => MakeMove(board, m));
        return board;
    }
  
  //Convert moves into number, where 1 is Red and -1 is Yellow
  //store the number to the allocated location in the board.
    private static void MakeMove(List<int> board, string move){
        var column = (int)move.ToCharArray()[0]-65;        
        for(var i=column; i<42; i+=7){
          //if substring is "Red", return 1 else return -1
            if (board[i]==0){
                board[i] = move.Substring(2).ToLower()=="red" ? 1 : -1; 
                return;
            }
        }
    }
  
  //main function
    public static string WhoIsWinner(List<string> moves){
      //pass 6 moves into GetBoard() to seperate Red and Yellow, store results in b (aka board)
        var b = GetBoard(moves.Take(6).ToList());
      
      //Visualizer of board, 1 is red, -1 is yellow.
      var test = GetBoard(moves.ToList());
      //sequence before formatting.
      Console.WriteLine(string.Join(",",test));
      //formatting.
      for(int i = test.Count/7-1; i >= 0;i--){
        Console.Write("row:" + i + "  ");
        Console.WriteLine(string.Join(",",test.Skip(i*7).Take(7)));
      }
      
        foreach(var m in moves.Skip(6)){
            MakeMove(b, m);
            for(var i=0; i<42; i++){
                var winner = "";
              //from board b check coordiantes, Horizontally, vertically, diagonally \, diagonally /
                if (IsWinner(b, i, i+1, i+2, i+3, x => x%7<4, out winner )) return winner;
                if (IsWinner(b, i, i+7, i+14, i+21, x => x<21, out winner )) return winner;
                if (IsWinner(b, i, i-6, i-12, i-18, x => x>20 && x%7<4, out winner )) return winner;
                if (IsWinner(b, i, i+8, i+16, i+24, x => x<18 && x%7<4, out winner )) return winner;
            }
        }
      //no one wins :(
        return "Draw";
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
    public class MyTestConnectFour
    {
        [Test]
        public void FirstTest()
        {
            List<string> myList = new List<string>()
            {
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "A_Red",
                "B_Yellow",
                "G_Red",
                "B_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Yellow",ConnectFour.WhoIsWinner(myList),"it should return Yellow");
        }

        [Test]
        public void SecondTest()
        {
            List<string> myList = new List<string>()
            {
                "C_Yellow",
                "E_Red",
                "G_Yellow",
                "B_Red",
                "D_Yellow",
                "B_Red",
                "B_Yellow",
                "G_Red",
                "C_Yellow",
                "C_Red",
                "D_Yellow",
                "F_Red",
                "E_Yellow",
                "A_Red",
                "A_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "F_Yellow",
                "D_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "A_Red",
                "G_Yellow",
                "D_Red",
                "D_Yellow",
                "C_Red"
            };
            StringAssert.AreEqualIgnoringCase("Yellow",ConnectFour.WhoIsWinner(myList));
        }

        [Test]
        public void ThirdTest()
        {
            List<string> myList = new List<string>()
            {
                "A_Yellow",
                "B_Red",
                "B_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "C_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "G_Yellow",
                "D_Red",
                "F_Yellow",
                "E_Red",
                "D_Yellow"
            };
            StringAssert.AreEqualIgnoringCase("Red",ConnectFour.WhoIsWinner(myList),"it should return Red");
        }

        [Test]
        public void FourthTest()
        {
            List<string> myList = new List<string>()
            {
                "F_Yellow",
                "G_Red",
                "D_Yellow",
                "C_Red",
                "A_Yellow",
                "A_Red",
                "E_Yellow",
                "D_Red",
                "D_Yellow",
                "F_Red",
                "B_Yellow",
                "E_Red",
                "C_Yellow",
                "D_Red",
                "F_Yellow",
                "D_Red",
                "D_Yellow",
                "F_Red",
                "G_Yellow",
                "C_Red",
                "F_Yellow",
                "E_Red",
                "A_Yellow",
                "A_Red",
                "C_Yellow",
                "B_Red",
                "E_Yellow",
                "C_Red",
                "E_Yellow",
                "G_Red",
                "A_Yellow",
                "A_Red",
                "G_Yellow",
                "C_Red",
                "B_Yellow",
                "E_Red",
                "F_Yellow",
                "G_Red",
                "G_Yellow",
                "B_Red",
                "B_Yellow",
                "B_Red"
            };
            StringAssert.AreEqualIgnoringCase("Red",ConnectFour.WhoIsWinner(myList),"it should return Red");
        }

        [Test]
        public void FifthTest()
        {
            List<string> myList = new List<string>()
            {
                "C_Yellow",
                "B_Red",
                "B_Yellow",
                "E_Red",
                "D_Yellow",
                "G_Red",
                "B_Yellow",
                "G_Red",
                "E_Yellow",
                "A_Red",
                "G_Yellow",
                "C_Red",
                "A_Yellow",
                "A_Red",
                "D_Yellow",
                "B_Red",
                "G_Yellow",
                "A_Red",
                "F_Yellow",
                "B_Red",
                "D_Yellow",
                "A_Red",
                "F_Yellow",
                "F_Red",
                "B_Yellow",
                "F_Red",
                "F_Yellow",
                "G_Red",
                "A_Yellow",
                "F_Red",
                "C_Yellow",
                "C_Red",
                "G_Yellow",
                "C_Red",
                "D_Yellow",
                "D_Red",
                "E_Yellow",
                "D_Red",
                "E_Yellow",
                "C_Red",
                "E_Yellow",
                "E_Red"
            };
            StringAssert.AreEqualIgnoringCase("Yellow",ConnectFour.WhoIsWinner(myList),"it should return Red");
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            RgConnectFour rg = new RgConnectFour((int)d * 10000);
            List<string> myList = rg.ListOfPositions();
            StringAssert.AreEqualIgnoringCase(ConnectFour2January.WhoIsWinner(myList),ConnectFour.WhoIsWinner(myList));
        }
    }
