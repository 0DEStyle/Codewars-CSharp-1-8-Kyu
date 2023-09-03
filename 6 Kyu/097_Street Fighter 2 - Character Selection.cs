/*Challenge link:https://www.codewars.com/kata/5853213063adbd1b9b0000be/train/csharp
Question:
Short Intro

Some of you might remember spending afternoons playing Street Fighter 2 in some Arcade back in the 90s or emulating it nowadays with the numerous emulators for retro consoles.

Can you solve this kata? Suuure-You-Can!

UPDATE: a new kata's harder version is available here.

The Kata

You'll have to simulate the video game's character selection screen behaviour, more specifically the selection grid. Such screen looks like this:

Screen:

screen

Selection Grid Layout in text:

| Ryu  | E.Honda | Blanka  | Guile   | Balrog | Vega    |
| Ken  | Chun Li | Zangief | Dhalsim | Sagat  | M.Bison |
Input

the list of game characters in a 2x6 grid;
the initial position of the selection cursor (top-left is (0,0));
a list of moves of the selection cursor (which are up, down, left, right);
Output

the list of characters who have been hovered by the selection cursor after all the moves (ordered and with repetition, all the ones after a move, whether successful or not, see tests);
Rules

Selection cursor is circular horizontally but not vertically!

As you might remember from the game, the selection cursor rotates horizontally but not vertically; that means that if I'm in the leftmost and I try to go left again I'll get to the rightmost (examples: from Ryu to Vega, from Ken to M.Bison) and vice versa from rightmost to leftmost.

Instead, if I try to go further up from the upmost or further down from the downmost, I'll just stay where I am located (examples: you can't go lower than lowest row: Ken, Chun Li, Zangief, Dhalsim, Sagat and M.Bison in the above image; you can't go upper than highest row: Ryu, E.Honda, Blanka, Guile, Balrog and Vega in the above image).

Test

For this easy version the fighters grid layout and the initial position will always be the same in all tests, only the list of moves change.

Notice: changing some of the input data might not help you.

Examples

fighters = [
  ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
  ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
]
initial_position = (0,0)
moves = ['up', 'left', 'right', 'left', 'left']
then I should get:

['Ryu', 'Vega', 'Ryu', 'Vega', 'Balrog']
as the characters I've been hovering with the selection cursor during my moves. Notice: Ryu is the first just because it "fails" the first up See test cases for more examples.

fighters = [
  ["Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega"],
  ["Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison"]
]
initial_position = (0,0)
moves = ['right', 'down', 'left', 'left', 'left', 'left', 'right']
Result:

['E.Honda', 'Chun Li', 'Ken', 'M.Bison', 'Sagat', 'Dhalsim', 'Sagat']
OFF-TOPIC

Some music to get in the mood for this kata :

Street Fighter 2 - selection theme
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;

public class Kata{
  public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves){
    //string list to store character results.
    var results = new List<string>();
    var row = 0;
    var col = 0;
    
    //change index via moves
    foreach (var s in moves) {
      switch (s) {
        case "up": row -= 1;
          break;
        case "down": row += 1;
          break;
        case "left": col -= 1;
          break;
        case "right": col += 1;
          break;
      }
      
      //validation check
      //if row or col are out of bound, set them to 0
      //if the end of row if reached, set row --
      //if col is -1, set col to fighters[0].Length - 1
      if (row < 0) 
        row = 0;
      if (row == fighters.Length) 
        row--;
      if (col == fighters[0].Length) 
        col = 0;
      if (col == -1) 
        col = fighters[0].Length - 1;
      
      //add final result to list and go to next iteration
      results.Add(fighters[row][col]);
    }
      
    return results.ToArray();
  }  
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  [TestFixture]
  public class FrontTests
  {
      private Kata kata = new Kata();
      private Sol sol = new Sol();
      private string[][] fighters;
  
      public FrontTests()
      {
          this.fighters = new string[][]
          {
              new string[] { "Ryu", "E.Honda", "Blanka", "Guile", "Balrog", "Vega" },
              new string[] { "Ken", "Chun Li", "Zangief", "Dhalsim", "Sagat", "M.Bison" },
          };
      }


        [Test]
        public void _01_ShouldWorkWithFewMoves()
        {
            var moves = new string[] { "up", "left", "right", "left", "left" };
            var expected = new string[] { "Ryu", "Vega", "Ryu", "Vega", "Balrog" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }
        
        [Test]
        public void _02_ShouldWorkWithNoSelectionCursorMoves()
        {
            var moves = new string[] { };
            var expected = new string[] { };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _03_ShouldWorkWhenAlwaysMovingLeft()
        {
            var moves = new string[] { "left", "left", "left", "left", "left", "left", "left", "left" };
            var expected = new string[] { "Vega", "Balrog", "Guile", "Blanka", "E.Honda", "Ryu", "Vega", "Balrog" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _04_ShouldWorkWhenAlwaysMovingRight()
        {
        var moves = new string[] { "right", "right", "right", "right", "right", "right", "right", "right" };
            var expected = new string[] { "E.Honda", "Blanka", "Guile", "Balrog", "Vega", "Ryu", "E.Honda", "Blanka" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _05_ShouldUseAll4DirectionsClockwiseTwice()
        {
            var moves = new string[] { "up", "left", "down", "right", "up", "left", "down", "right" };
            var expected = new string[] { "Ryu", "Vega", "M.Bison", "Ken", "Ryu", "Vega", "M.Bison", "Ken" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _06_ShouldWorkWhenAlwaysMovingDown()
        {
            var moves = new string[] { "down", "down", "down", "down" };
            var expected = new string[] { "Ken", "Ken", "Ken", "Ken" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _07_ShouldWorkWhenAlwaysMovingUp()
        {
            var moves = new string[] { "up", "up", "up", "up" };
            var expected = new string[] { "Ryu", "Ryu", "Ryu", "Ryu" };

            CollectionAssert.AreEqual(expected, kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
        }

        [Test]
        public void _08_RandomTests()
        {
            var rnd = new Random();

            for (int i = 0; i < 35; i++)
            {
                var possibleMoves = new string[] { "left", "right", "down", "up" };

                var moves = Enumerable.Range(0, rnd.Next(3, 50)).Select(n => possibleMoves[rnd.Next(0, 4)]).ToArray();
                CollectionAssert.AreEqual(sol.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves), kata.StreetFighterSelection(fighters, new int[] { 0, 0 }, moves));
            }
        }

        #region My solution

        public class Sol
        {
            struct Move
            {
                public int x;
                public int y;
            }

            public string[] StreetFighterSelection(string[][] fighters, int[] position, string[] moves)
            {
                var movesValues = new Dictionary<string, Move>
            {
                { "left", new Move { x = -1, y = 0 } },
                { "right", new Move { x = 1, y = 0 } },
                { "up", new Move { x = 0, y = -1 } },
                { "down", new Move { x = 0, y = 1 } },
            };

                var x = position[0];
                var y = position[1];

                var selections = new List<string>(moves.Length);

                int cols = fighters[0].Length;

                foreach (var move in moves)
                {
                    var moveValue = movesValues[move];

                    x += moveValue.x;
                    if (x < 0)
                    {
                        x = cols - 1;
                    }
                    else if (x >= cols)
                    {
                        x = 0;
                    }

                    y += moveValue.y;
                    if (y < 0)
                    {
                        y = 0;
                    }
                    else if (y > 1)
                    {
                        y = 1;
                    }

                    selections.Add(fighters[y][x]);
                }

                return selections.ToArray();
            }
        }
        #endregion
  }
}
