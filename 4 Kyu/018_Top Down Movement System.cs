/*Challenge link:https://www.codewars.com/kata/59315ad28f0ebeebee000159/train/csharp
Question:
Task
Create a top-down movement system that would feel highly responsive to the player. In your Update method you have to check for the keys that are currently being pressed, the keys correspond to the enum Direction shown below, based on which key is pressed or released your method should behave this way:

When a key is first pressed, the player has to change his direction to that of the current key, without moving

If the key is still being pressed during the next Update, the player will move towards his current direction using these vectors: (Up = { 0, +1 } , Down = { 0, -1 }, Left = { -1, 0 }, Right = { +1, 0 })

If a new key is pressed, it will gain precedence over the previous key and the player will act as per 1)

4-A) If the current key (A) is released, then the precedence will go back to the previous key (B) (or the one before it, if (B) is not pressed anymore, and so on), then the player will behave as per 1).

4-B) If the current key is released, and no other keys are being pressed, the player will stand still

If all keys are released at once, the player will not move nor change direction

If multiple keys are pressed at once, the order of precedence will be the following { Up, Down, Left, Right }

Examples
(n = pressed key, [n] = current key, p() = press, r() = release, (8,2,4,6 = up, down, left, right)):

[] , p(8) -> [8] , p(4,6) -> 86[4] , r(6) -> 8[4] , r(4) -> [8] , r(8) -> []

[] , p(2486) -> 642[8] , r(2,8) -> 6[4] , r(4,6) -> []
This is what you'll need to use in your code (NB: the tile coordinates cannot be changed, you'll need to assign a new Tile each time the player moves):

  public enum Direction { Up = 8, Down = 2, Left = 4, Right = 6 }
  
  public struct Tile
  {
      public int X { get; }
      public int Y { get; }
      
      public Tile(int x, int y);
  }
  
  public static class Input
  {
      // pressed = true, released = false
      public static bool GetState(Direction direction);
  }
*/

//***************Solution********************

using System.Collections.Generic;

namespace TopDownMovement{
  public class PlayerMovement{
    public Tile Position { get; private set; }
    public Direction Direction { get; private set; }
    
    public List<Direction> Pressed = new List<Direction>();
    
    //reverse order of Up, Down, Left, Right
    public static List<Direction> directions = new List<Direction>(){
        Direction.Right,
        Direction.Left,
        Direction.Down,
        Direction.Up
    };
    
    public PlayerMovement(int x, int y) => Position = new Tile(x,y);
      
    public void Update(){
      //loop for each dir in Directions
      //check if Key is Pressed or Released
      //if keyState != to the dir keys that is pressed
      //true: add new dir to the list, false: remove dir from list.
      foreach (Direction dir in directions){
        bool keyState = Input.GetState(dir);
        if(keyState != Pressed.Contains(dir)){
          if(keyState) Pressed.Add(dir);
          else Pressed.Remove(dir);
        }
      }
      
      //Multiple keys pressed
      if(Pressed.Count > 0){
        //use the latest key pressed, index from the end
        Direction currentKey = Pressed[^1]; 
        if(Direction == currentKey){
          int x = Position.X, y = Position.Y;
        
        switch(currentKey){
            case Direction.Up:
            y++;
            break;
            case Direction.Down:
            y--;
            break;
            case Direction.Left:
            x--;
            break;
            case Direction.Right:
            x++;
            break;
        }
        //update tile coordinate
        Position = new Tile(x,y);
      }
      //if no multiple keys pressed
      else Direction = currentKey;
      }
    }
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TopDownMovement
{
  [TestFixture]
  public class SolutionTest
  {
      private PlayerMovement _player;
  
      private void TestEquality(Direction direction, int x, int y)
      {
          _player.Update();
  
          Assert.AreEqual(direction, _player.Direction);
          Assert.AreEqual(new Tile(x, y), _player.Position);
      }
  
      [Test(Description = "Basic Test 1")]
      public void BasicTest1()
      {
          _player = new PlayerMovement(0, 0);
          Input.Clear();

          Press(Direction.Down);

          TestEquality(Direction.Down, 0, 0);
          TestEquality(Direction.Down, 0, -1);
          TestEquality(Direction.Down, 0, -2);

          Press(Direction.Left);
          Press(Direction.Right);

          TestEquality(Direction.Left, 0, -2);
          TestEquality(Direction.Left, -1, -2);

          Release(Direction.Left);

          TestEquality(Direction.Right, -1, -2);

          Release(Direction.Right);

          TestEquality(Direction.Down, -1, -2);
          TestEquality(Direction.Down, -1, -3);

          Release(Direction.Down);

          TestEquality(Direction.Down, -1, -3);
      }

      [Test(Description = "All keys at once")]
      public void BasicTest2()
      {
          _player = new PlayerMovement(0, 0);
          Input.Clear();

          Press(Direction.Down);
          Press(Direction.Left);
          Press(Direction.Right);
          Press(Direction.Up);

          TestEquality(Direction.Up, 0, 0);
          TestEquality(Direction.Up, 0, 1);

          Release(Direction.Left);

          TestEquality(Direction.Up, 0, 2);

          Release(Direction.Up);

          TestEquality(Direction.Down, 0, 2);

          Release(Direction.Down);

          TestEquality(Direction.Right, 0, 2);
          TestEquality(Direction.Right, 1, 2);
          TestEquality(Direction.Right, 2, 2);

          Release(Direction.Right);

          TestEquality(Direction.Right, 2, 2);
      }

      [Test(Description = "Random Test")]
      public void RandomTest()
      {
          int x, y;
          Random rand = new Random();

          x = rand.Next(200) - 100;
          y = rand.Next(200) - 100;

          _player = new PlayerMovement(x, y);
          Input.Clear();

          Press(Direction.Down);
          Press(Direction.Left);
          Press(Direction.Right);
          Press(Direction.Up);

          TestEquality(Direction.Up, x, y);

          for (int i = 0; i < rand.Next(20) + 1; i++)
          {
              y++;
              TestEquality(Direction.Up, x, y);
          }

          Release(Direction.Left);

          y++;
          TestEquality(Direction.Up, x, y);

          Release(Direction.Up);

          TestEquality(Direction.Down, x, y);

          Release(Direction.Down);

          TestEquality(Direction.Right, x, y);
          x++;
          TestEquality(Direction.Right, x, y);
          x++;
          TestEquality(Direction.Right, x, y);

          Release(Direction.Right);

          TestEquality(Direction.Right, x, y);
      }

      private void Press(Direction dir) { Console.WriteLine("Pressed " + dir); Input.Press(dir); }
      private void Release(Direction dir) { Console.WriteLine("Released " + dir); Input.Release(dir); }
  }
}
