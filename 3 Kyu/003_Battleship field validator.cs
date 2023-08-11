/*Challenge link:https://www.codewars.com/kata/52bb6539a4cf1b12d90005b7/train/csharp
Question:
Write a method that takes a field for well-known board game "Battleship" as an argument and returns true if it has a valid disposition of ships, false otherwise. Argument is guaranteed to be 10*10 two-dimension array. Elements in the array are numbers, 0 if the cell is free and 1 if occupied by ship.

Battleship (also Battleships or Sea Battle) is a guessing game for two players. Each player has a 10x10 grid containing several "ships" and objective is to destroy enemy's forces by targetting individual cells on his field. The ship occupies one or more cells in the grid. Size and number of ships may differ from version to version. In this kata we will use Soviet/Russian version of the game.


Before the game begins, players set up the board and place the ships accordingly to the following rules:
There must be single battleship (size of 4 cells), 2 cruisers (size 3), 3 destroyers (size 2) and 4 submarines (size 1). Any additional ships are not allowed, as well as missing ships.
Each ship must be a straight line, except for submarines, which are just single cell.

//check link for image

The ship cannot overlap or be in contact with any other ship, neither by edge nor by corner.

//check link for image
This is all you need to solve this kata. If you're interested in more information about the game, visit this link.
*/

//***************Solution********************
namespace Solution {
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class BattleShip{
        public string Type { get; set; }
        public int Length { get; set; }
        public int Count { get; set; }
    }  
  
  //main function
    public static class BattleshipField{
      //fixed data for ship size and count
        private static readonly List<BattleShip> Ships = new List<BattleShip>{
            new BattleShip { Type = "Battleship", Length = 4, Count = 1 },
            new BattleShip { Type = "Cruiser", Length = 3, Count = 2 },
            new BattleShip { Type = "Torpedo boat", Length = 2, Count = 3 },
            new BattleShip { Type = "Submarine", Length = 1, Count = 4 }
        };
      
       //print fail message
        private static bool Fail(string message){
            Console.WriteLine($"  Error: {message}");
            return false;
        }

      //Recursive method to check the count of ship length.
        private static int CountShipLength(this int[,] battlefield, int x, int y, bool isHorizontal){
            var height = battlefield.GetLength(0);
            var width = battlefield.GetLength(1);
            var cell = battlefield[x, y];

           // cell isn't 1, so return 0.
           // check up to right edge of the field or check up to bottom edge of the field, don't count further.
            if (cell == 0 || isHorizontal && x == width - 1 || !isHorizontal && y == height - 1) 
                return cell;

            //recursively count the current cell plus a possible neighbour
            return cell + battlefield.CountShipLength(
                       isHorizontal ? x + 1 : 
                    x,!isHorizontal ? y + 1 : 
                      y,isHorizontal);
        }

      //Check validation of battle field
        public static bool ValidateBattlefield(int[,] battlefield){
            // Check number of cells.
            if (battlefield.Cast<int>().Sum() != Ships.Sum(s => s.Count * s.Length))
                return Fail("Wrong number of cells!");

            var height = battlefield.GetLength(0);
            var width = battlefield.GetLength(1);
            var lengths = new List<int> { 0, 0, 0, 0 };

            for (var i = 0; i < battlefield.Length; i++){
                var y = i % width;
                var x = (int)Math.Floor((double)i / width);

                var cell = battlefield[x, y];

              // if current cell is 0. Continue to next cell.
                if (cell == 0)continue;

                // check diagonals
                if (y < height - 1){
                    if (x < width - 1 && battlefield[x + 1, y + 1] == 1)
                        return Fail("Can't have a neighbour to the bottom right");

                    if (x > 0 && battlefield[x - 1, y + 1] == 1)
                        return Fail("Can't have a neighbour to the bottom left!");
                }

                // Count the ship's length.
                var hasLeft = x > 0 && battlefield[x - 1, y] == 1;
                var hasRight = x < width - 1 && battlefield[x + 1, y] == 1;
                var hasTop = y > 0 && battlefield[x, y - 1] == 1;
                var hasBottom = y < height - 1 && battlefield[x, y + 1] == 1;

                if (!new[] { hasLeft, hasRight, hasTop, hasBottom }.Any(b => b))
                    lengths[0]++;
                else if (!hasLeft && hasRight){
                    var length = battlefield.CountShipLength(x, y, true);
                    lengths[length - 1]++;
                }
                else if (!hasTop && hasBottom){
                    var length = battlefield.CountShipLength(x, y, false);
                    lengths[length - 1]++;
                }
            }
 
            //print info
            // Validated ships found
            Console.WriteLine("Validation success. Ship Counts\n" +
                              $"Battleships:   {lengths[3]}\n" +
                              $"Cruisers:      {lengths[2]}\n" +
                              $"Torpedo boats: {lengths[1]}\n" +
                              $"Submarines:    {lengths[0]}");

            for(var i = 0; i < Ships.Count; i++){
                if (lengths[i] != 4 - i)
                    return Fail($"Incorrect number of {Ships[i].Type.ToLowerInvariant()}s: {lengths[0]}");
            }

            // All validation passed
            Console.WriteLine("Success! This barttlefield is valid!");
            return true;
        }
    }
  }

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest {
    [Test]
    public void TestCase() {
      int[,] field1 = new int[10,10]
                     {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                      {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                      {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                      {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                      {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                      {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsTrue(BattleshipField.ValidateBattlefield(field1),
                 "Must return True for valid field");
      
      int[,] field2 = new int[10,10]
                      {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                       {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                       {0, 1, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field2),
                 "Must return False if unwanted ships are present");
                 
      int[,] field3 = new int[10,10]
                      {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                       {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field3),
                 "Must return False if number of ships of some type is incorrect");
                 
      int[,] field4 = new int[10,10]
                      {{0, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                       {0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field4),
                 "Must return False if some of ships is missing");
                 
      int[,] field5 = new int[10,10]
                      {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                       {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                       {1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                       {0, 0, 0, 1, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field5),
                 "Must return False if ships are in contact");
                 
      int[,] field6 = new int[10,10]
                      {{1, 0, 0, 0, 0, 1, 1, 0, 0, 0},
                       {1, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {1, 1, 0, 0, 1, 1, 1, 0, 1, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 1, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 1, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field6),
                 "Must return False if some of ships has incorrect shape (non-straight)");
                 
      int[,] field7 = new int[10,10]
                      {{1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                       {1, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {1, 0, 1, 0, 1, 1, 1, 0, 1, 0},
                       {1, 0, 1, 0, 0, 0, 0, 0, 0, 0},
                       {0, 0, 1, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 0, 1, 1, 1, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 1, 0},
                       {0, 0, 0, 1, 0, 0, 0, 0, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 1, 0, 0},
                       {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}};
      Assert.IsFalse(BattleshipField.ValidateBattlefield(field7),
                 "Must return False if the number and length of ships is not ok");
    }
  }
}
