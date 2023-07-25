/*Challenge link:https://www.codewars.com/kata/57658bfa28ed87ecfa00058a/train/csharp
Question:
Task
You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return the minimal number of steps to exit position [N-1, N-1] if it is possible to reach the exit from the starting position. Otherwise, return -1.

Empty positions are marked .. Walls are marked W. Start and exit positions are guaranteed to be empty in all test cases.

Path Finder Series:
#1: can you reach the exit?
#2: shortest path
#3: the Alpinist
#4: where are you?
#5: there's someone here
*/

//***************Solution********************

//you start at the top left and have to reach the exit that will always be in the bottom right. 

using System;
using System.Linq;

public class Finder{    
  public static int PathFinder(string maze){
    //create bool map with Jagged array
    var isOpen = maze.Split('\n').Select(x => x.Select(c => c == '.').ToArray()).ToArray();
    
    //Print out the bool values for Jagged array
      for (int y = 0; y < isOpen.Length; y++) {
        for (int x = 0; x < isOpen[y].Length; x++) {
          Console.Write(isOpen[y][x]);  
        }
        Console.WriteLine();
      }
        
    //set stepsNeeded to 999 for each cell
    var stepsNeeded = isOpen.Select(a => a.Select(c => 999).ToArray()).ToArray();
    
    //starting point x and y, bool values for each cell, the step needed for each cell, starting step
    Flood(0, 0, isOpen, stepsNeeded, 0); 
    
    //if Last stepsNeeded is less than 999, return step value, else return -1
    return stepsNeeded.Last().Last() < 999 ? stepsNeeded.Last().Last() : -1;
  }
  
  //if cell is open and stepNeeded is less than step
  //set StepsNeeded for current cell to new step
  //use recursive method to update the step until the condition is no longer true.
  private static void Flood(int x, int y, bool[][] isOpen, int[][] stepsNeeded, int step){
    if (isOpen[x][y] && stepsNeeded[x][y] > step){
      stepsNeeded[x][y] = step;
      if (x > 0) Flood(x - 1, y, isOpen, stepsNeeded, step + 1);
      if (y > 0) Flood(x, y - 1, isOpen, stepsNeeded, step + 1);
      if (x < isOpen.GetLength(0) - 1) Flood(x + 1, y, isOpen, stepsNeeded, step + 1);
      if (y < isOpen.GetLength(0) - 1) Flood(x, y + 1, isOpen, stepsNeeded, step + 1);
    }
  }
  
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class SolutionTest
{

    [Test]
    public void TestBasic()
    {

        string a = ".W.\n" +
                   ".W.\n" +
                   "...",

               b = ".W.\n" +
                   ".W.\n" +
                   "W..",

               c = "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   "......",

               d = "......\n" +
                   "......\n" +
                   "......\n" +
                   "......\n" +
                   ".....W\n" +
                   "....W.";

        Assert.AreEqual(4, Finder.PathFinder(a));
        Assert.AreEqual(-1, Finder.PathFinder(b));
        Assert.AreEqual(10, Finder.PathFinder(c));
        Assert.AreEqual(-1, Finder.PathFinder(d));
    }

    [Test]
    public void TestRandom50()
    {

        for (int i = 0; i < 50; i++)
        {
            int len = 4 + rand.Next(7);
            string str = RandomMaze(len);
            Console.WriteLine(str+ '\n');
            Assert.AreEqual(TestFinder.PathFinder(str), Finder.PathFinder(str), str);
        }
    }

    [Test]
    public void TestRandomBigMaze10()
    {
        for (int i = 0; i < 10; i++)
        {
            String str = RandomMaze(100);
            Assert.AreEqual(TestFinder.PathFinder(str), Finder.PathFinder(str), str);
        }
    }

    [Test]
    public void TestSnakesLabirinth()
    {

        Assert.AreEqual(96, Finder.PathFinder(
        ".W...W...W...\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        ".W.W.W.W.W.W.\n" +
        "...W...W...W."));

    }

    [Test]
    public void TestVerySmallLabirinth()
    {

        Assert.AreEqual(0, Finder.PathFinder("."));
    }

    private static readonly Random rand = new Random();
    private string RandomMaze(int len)
    {

        string template = new string('.', len);
        StringBuilder[] maze = Enumerable.Range(0, len).Select(i => new StringBuilder(template)).ToArray();

        for (int j = 0; j < len * len / 3; j++)
        {
            maze[rand.Next(len)][rand.Next(len)] = 'W';
        }
        maze[0][0] = '.';
        maze[len - 1][len - 1] = '.';
        return string.Join("\n", maze.Select(b => b.ToString()));
    }

    private class TestFinder
    {
        public static int PathFinder(string maze)
        {
            return new TestFinder().find(maze);
        }

        private string[] m;
        private int[,] steps;
        private Queue<int[]> front;
        private int goal;

        public int find(string maze)
        {
            m = maze.Split('\n');

            steps = new int[m.Length, m.Length];

            steps[0, 0] = 1;
            front = new Queue<int[]>();
            front.Enqueue(new[] { 0, 0 });

            goal = m.Length - 1;

            while (front.Any())
            {

                int[] c = front.Dequeue();

                if (c[0] == goal && c[1] == goal)
                    return steps[goal, goal] - 1;

                int step = steps[c[0], c[1]] + 1;
                TryStep(c[0] - 1, c[1], step);
                TryStep(c[0] + 1, c[1], step);
                TryStep(c[0], c[1] - 1, step);
                TryStep(c[0], c[1] + 1, step);

            }
            return -1;
        }

        private void TryStep(int r, int c, int v)
        {
            if (r < 0 || r > goal || c < 0 || c > goal || steps[r, c] != 0)
                return;

            string row = m[r];
            if (row[c] == '.')
            {
                steps[r, c] = v;
                front.Enqueue(new int[] { r, c });
            }
        }
    }
}
