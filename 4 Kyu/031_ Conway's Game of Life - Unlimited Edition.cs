/*Challenge link:https://www.codewars.com/kata/52423db9add6f6fc39000354/train/csharp
Question:
Given a 2D array and a number of generations, compute n timesteps of Conway's Game of Life.

The rules of the game are:

Any live cell with fewer than two live neighbours dies, as if caused by underpopulation.
Any live cell with more than three live neighbours dies, as if by overcrowding.
Any live cell with two or three live neighbours lives on to the next generation.
Any dead cell with exactly three live neighbours becomes a live cell.
Each cell's neighborhood is the 8 cells immediately around it (i.e. Moore Neighborhood). The universe is infinite in both the x and y dimensions and all cells are initially dead - except for those specified in the arguments. The return value should be a 2d array cropped around all of the living cells. (If there are no living cells, then return [[]].)

For illustration purposes, 0 and 1 will be represented as ░░ and ▓▓ blocks respectively (PHP: plain black and white squares). You can take advantage of the htmlize function to get a text representation of the universe, e.g.:

console.log(htmlize(cells));
*/

//***************Solution********************
/*
1 generation
before
{1,0,0},
{0,1,1},
{1,1,0}

after applying 4 rules.
{0,1,0},
{0,0,1},
{1,1,1}

*/
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;

public class ConwayLife{
  public static int[,] GetGeneration(int[,] cells, int generation){
    
    // convert cells 2d array to HashSet<point> for later process
    var field = Enumerable.Range(0, cells.GetLength(0))
      .SelectMany(y => Enumerable.Range(0, cells.GetLength(1)).Select(x => new Point(x,y)))
      .Where(c => cells[c.Y, c.X] > 0)
      .ToHashSet();
    
    //Visualized cells, field pin point all alive cells with x,y coordinates.
    Console.WriteLine(string.Join(",\n",field));
    
    //helper methods to get info from points.
    IEnumerable<Point> Points9(Point c) => 
      Enumerable.Range(-1, 3)
      .SelectMany(y => Enumerable.Range(-1, 3).Select(x => new Point(c.X + x, c.Y + y)));
    
    //Get checks if field contains point, return bool value
    //Get9 return the sum of all bool values.
    int Get(Point p) => field.Contains(p) ? 1 : 0;
    int Get9(Point c) => Points9(c).Sum(Get);

    // while generation-- is greater than 0
    while (generation-- > 0){
      var scan = field.SelectMany(Points9).ToHashSet(); // determine positions to scan (remove duplicates)
      //Console.WriteLine(string.Join(",\n",scan));
      
      //apply rules to scan
      field = scan.Where(p => Get9(p) == 3 || (Get9(p) == 4 && Get(p) == 1)).ToHashSet();
      //Console.WriteLine("\n\n\nFiltered result");
      //Console.WriteLine(string.Join(",\n",field));
    }

    //convert HashSet<Point> back to cells[,] and return result
    int minX = field.Min(c => c.X);
    int maxX = field.Max(c => c.X) + 1;
    int minY = field.Min(c => c.Y);
    int maxY = field.Max(c => c.Y) + 1;
    var result = new int[maxY - minY, maxX - minX];
    
    for (int y = minY; y < maxY; y++) 
      for (int x = minX; x < maxX; x++) 
        result[y - minY, x - minX] = Get(new Point(x, y));
    return result;
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    private void CheckGlider(int[][,] gliders, int[,] check, int generation) 
    {
      Console.WriteLine("Number of generations = " + generation);
      int[,] res = ConwayLife.GetGeneration(gliders[0], generation);
      CollectionAssert.AreEqual(res, gliders[generation % 4], "Output doesn't match expected");
      CollectionAssert.AreEqual(gliders[0], check, "Solution should not modify input array");
    }
    
    [Test]
    public void TestGliders() 
    {
      int[][,] gliders = 
      {
        new int[,] {{1,0,0},{0,1,1},{1,1,0}},
        new int[,] {{0,1,0},{0,0,1},{1,1,1}},
        new int[,] {{1,0,1},{0,1,1},{0,1,0}},
        new int[,] {{0,0,1},{1,0,1},{0,1,1}}
      };
      int[,] check = {{1,0,0},{0,1,1},{1,1,0}};    
      Console.WriteLine("Glider");
      LifeDebug.Print(gliders[0]);    
      foreach(int i in new int[]{0,1,2,3,40}) CheckGlider(gliders, check, i);
    }
  
    [Test] 
    public void TestTwoGliders() 
    {
      int[][,] twoGliders = 
      {
        new int[,] {{1,1,1,0,0,0,1,0},{1,0,0,0,0,0,0,1},{0,1,0,0,0,1,1,1}},
        new int[,] {{1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1},
         {0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,1}}
        };    
        Console.WriteLine("Two Gliders");
        LifeDebug.Print(twoGliders[0]);    
        Console.WriteLine("Two Glider 100");
        int[,] res = ConwayLife.GetGeneration(twoGliders[0], 16);
        CollectionAssert.AreEqual(res, twoGliders[1], "Output doesn't match expected");
    }
  }
}
