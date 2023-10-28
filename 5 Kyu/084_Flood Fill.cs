/*Challenge link:https://www.codewars.com/kata/5576f6719988e71ea30000ae/train/csharp
Question:
Task
Given a 2-dimensional grid and a zero-based (x,y) coordinate, flood-fill the area on the grid containing that coordinate with the given value. Two squares in the grid belong to the same area if they contain the same value and are adjacent either horizontally or vertically, but not diagonally.

See: https://en.wikipedia.org/wiki/Flood_fill

Grid
The grid is represented as a 2-dimensional rectangular array.

Example
A flood fill with 4 at the point (0, 1) of the following array would look like this:

   [[1, 2, 3],     [[1, 4, 3],
    [1, 2, 2],  ->  [1, 4, 4],
    [2, 3, 2]]      [2, 3, 4]]
Hint
One of the test cases is quite large so make sure your solution is as efficient as possible!
*/

//***************Solution********************
using System;
using System.Collections.Generic;

public class Kata{
  public static int[,] FloodFill(int[,] array, int startY, int startX, int newValue){
    //create new stack.
    var stack = new Stack<(int startY, int startX)>();
    
    //reference value, max Y, max X and first stack.
    var refVal = array[startY, startX];
    var maxY = array.GetLength(0);
    var maxX = array.GetLength(1);
    stack.Push((startY, startX));
    
    //while stack.count is not 0
    //remove/pop stack at y,x
    while(stack.Count != 0){
      (int y, int x) = stack.Pop();
      
      //if y is grater or equal to 0  and y is less than maxY (same to x value)
      //and array[y,x] is the same as reference value.
      if (y >= 0 && y < maxY
          && x >= 0 && x < maxX
          && array[y, x] == refVal){
        //set array[x,y] to new value from parameter. push the values into the right cell/stack.
        array[y, x] = newValue;
        stack.Push((y-1, x));
        stack.Push((y+1, x));
        stack.Push((y, x-1));
        stack.Push((y, x+1));
      }
    }
    //return result.
    return array;
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class FloodFillTests
{
  [Test]
  public void TestSmallestGrid()
  {
    CollectionAssert.AreEqual(
      new int[,] {{ 2 }},
      Kata.FloodFill(new int[,] {{ 1 }}, 0, 0, 2));
  }

  [Test]
  public void TestSingleValueMiddle()
  {
    CollectionAssert.AreEqual(
      new int[,] {{1,1,1},{1,3,1},{1,1,1}},
      Kata.FloodFill(new int[,] {{1,1,1},{1,2,1},{1,1,1}}, 1, 1, 3));
  }
  
  [Test]
  public void TestSingleValueCorners()
  {
    // Top left
    CollectionAssert.AreEqual(
      new int[,] {{3,1,1},{1,1,1},{1,1,1}},
      Kata.FloodFill(new int[,] {{2,1,1},{1,1,1},{1,1,1}}, 0, 0, 3));
      
    // Top right
    CollectionAssert.AreEqual(
      new int[,] {{1,1,3},{1,1,1},{1,1,1}},
      Kata.FloodFill(new int[,] {{1,1,2},{1,1,1},{1,1,1}}, 0, 2, 3));
      
    // Bottom left
    CollectionAssert.AreEqual(
      new int[,] {{1,1,1},{1,1,1},{3,1,1}},
      Kata.FloodFill(new int[,] {{1,1,1},{1,1,1},{2,1,1}}, 2, 0, 3));
    
    // Bottom right
    CollectionAssert.AreEqual(
      new int[,] {{1,1,1},{1,1,1},{1,1,3}},
      Kata.FloodFill(new int[,] {{1,1,1},{1,1,1},{1,1,2}}, 2, 2, 3));
  }

  [Test]
  public void TestEdges()
  {
    // Top
    CollectionAssert.AreEqual(
      new int[,] {{3,1,1},{3,1,1},{3,1,1}},
      Kata.FloodFill(new int[,] {{2,1,1},{2,1,1},{2,1,1}}, 0, 0, 3));
    
    // Bottom
    CollectionAssert.AreEqual(
      new int[,] {{1,1,3},{1,1,3},{1,1,3}},
      Kata.FloodFill(new int[,] {{1,1,2},{1,1,2},{1,1,2}}, 0, 2, 3));
      
    // Left
    CollectionAssert.AreEqual(
      new int[,] {{3,3,3},{1,1,1},{1,1,1}},
      Kata.FloodFill(new int[,] {{2,2,2},{1,1,1},{1,1,1}}, 0, 0, 3));
      
    // Right
    CollectionAssert.AreEqual(
      new int[,] {{1,1,1},{1,1,1},{3,3,3}},
      Kata.FloodFill(new int[,] {{1,1,1},{1,1,1},{2,2,2}}, 2, 0, 3));
  }

  [Test]
  public void TestDiagonalsDoNotFill()
  {
    CollectionAssert.AreEqual(
      new int[,] {{1,2,1},{2,3,2},{1,2,1}},
      Kata.FloodFill(new int[,] {{1,2,1},{2,1,2},{1,2,1}}, 1, 1, 3));
  }
  
  [Test]
  public void TestSpiral()
  {
    CollectionAssert.AreEqual(
      new int[,]
        {{3,3,3,3,3,3,3},
         {3,1,1,1,1,1,3},
         {3,1,3,3,3,1,3},
         {3,1,3,1,3,1,3},
         {3,1,3,1,1,1,3},
         {3,1,3,3,3,3,3},
         {3,1,1,1,1,1,1}},
      Kata.FloodFill(new int[,]
        {{2,2,2,2,2,2,2},
         {2,1,1,1,1,1,2},
         {2,1,2,2,2,1,2},
         {2,1,2,1,2,1,2},
         {2,1,2,1,1,1,2},
         {2,1,2,2,2,2,2},
         {2,1,1,1,1,1,1}}, 3, 4, 3));
  }
  
  [Test]
  public void TestSinglePath()
  {
    var actual = new int[,]
      {{1,1,1,1,1,1,1,1,1,1},
       {2,1,2,1,2,1,2,1,2,1},
       {2,1,2,1,2,1,2,1,2,2},
       {2,1,2,1,2,1,2,1,1,1},
       {2,1,2,1,2,1,2,2,2,2},
       {2,1,2,1,2,1,1,1,1,1},
       {2,1,2,1,2,2,2,2,2,2},
       {2,1,2,1,1,1,1,1,1,1},
       {2,1,2,2,2,2,2,2,2,2},
       {2,1,1,1,1,1,1,1,1,1}};
       
    var expected = new int[,]
      {{3,3,3,3,3,3,3,3,3,3},
       {2,3,2,3,2,3,2,3,2,3},
       {2,3,2,3,2,3,2,3,2,2},
       {2,3,2,3,2,3,2,3,3,3},
       {2,3,2,3,2,3,2,2,2,2},
       {2,3,2,3,2,3,3,3,3,3},
       {2,3,2,3,2,2,2,2,2,2},
       {2,3,2,3,3,3,3,3,3,3},
       {2,3,2,2,2,2,2,2,2,2},
       {2,3,3,3,3,3,3,3,3,3}};
       
    CollectionAssert.AreEqual(
      expected,
      Kata.FloodFill(actual, 0, 0, 3));
  }
  
  private int[,] MakeArray(int x, int y, int value)
  {
    var array = new int[x, y];
    for (int i = 0; i < x; i++) {
      for (int j = 0; j < x; j++) {
        array[i, j] = value;
      }
    }
    
    return array;
  }
  
  [Test]
  public void TestLargeRandom()
  {
    var actual = MakeArray(500, 500, 1);
    var expected = MakeArray(500, 500, 2);
    
    Random r = new Random();
    
    // Add a random sparse diagonal
    for (int i = 0; i < 100; i += 3)
    {
      for (int j = 0; j < 100; j += 3)
      {
        int value = r.Next(3, 10);
        
        actual[i, j] = value;
        expected[i, j] = value;
      }
    }
    
    CollectionAssert.AreEqual(
      expected,
      Kata.FloodFill(actual, 200, 200, 2));
  }
  
  [Test]
  public void TestExample()
  {
    var expected = new int[,]
      {{1,4,3},
       {1,4,4},
       {2,3,4}};
       
    var actual = new int[,]
      {{1,2,3},
       {1,2,2},
       {2,3,2}};
  
    CollectionAssert.AreEqual(expected, Kata.FloodFill(actual, 0, 1, 4));
  }
}
