/*Challenge link:https://www.codewars.com/kata/5765870e190b1472ec0022a2/train/csharp
Question:
Task
You are at position [0, 0] in maze NxN and you can only move in one of the four cardinal directions (i.e. North, East, South, West). Return true if you can reach position [N-1, N-1] or false otherwise.

Empty positions are marked ..
Walls are marked W.
Start and exit positions are empty in all test cases.
*/

//***************Solution********************

//start at top left, end at bottom right.
// W wall, . empty position, \n new row

using System.Linq;
using System;

public class Finder{
  //split the string by \n, from each line select empty position - c, store results in 2D array, solver to find bool value.
  public static bool PathFinder(string maze){
    //Console.WriteLine("\n\n\n"+maze +"\n");
    return solver(maze.Split('\n')
                        .Select(line => line.Select(c => '.' - c)
                        .ToArray()).ToArray());
    }
  
  //using recursive method to get bool value
   //-41 is wall, 0 is empty space, -1 is visited
  //if position is within x and y boundaries.
  //if current spot is empty 
  //if maze reached the end or current positition is visited
  //pass in directional values back into the function
    private static bool solver(int[][] maze, int x = 0, int y = 0){
      //Maze path visualizer
      /*
      for(int i = 0; i < maze.Length;i++){
        for (int j = 0; j < maze.Length; j++)
          Console.Write(maze[i][j] + ",");
        Console.WriteLine();
      }
      */
      return (x >= 0 && x < maze[0].Length) &&
             (y >= 0 && y < maze.Length) &&
             (maze[y][x] == 0) && (
             (x + 1 == maze[0].Length && y + 1 == maze.Length) ||
             (maze[y][x] = -1) == -1 && (
                solver(maze, x + 1, y) || //east
                solver(maze, x - 1, y) || //west
                solver(maze, x, y + 1) || //south
                solver(maze, x, y - 1))); //north
      }
}

//method 2
public class Finder {
    const int WALL = 2;
        const int VISITED = 1;
        public static bool PathFinder(string maze)
        {
            maze = maze.Replace(" ", string.Empty);
            int[,] matrix = CreateMatrix(maze);
            next(matrix, 0, 0);
            return matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1] == VISITED;
        }

        public static void next(int[,] matrix, int y, int x)
        {
            matrix[y, x] = VISITED;
            if (y > 0 && matrix[y - 1, x] != VISITED && matrix[y - 1, x] != WALL) // north
                next(matrix, y - 1, x);
            if (x > 0 && matrix[y, x - 1] != VISITED && matrix[y, x - 1] != WALL) // west
                next(matrix, y, x - 1);
            if (y < matrix.GetLength(0) - 1 && matrix[y + 1, x] != VISITED && matrix[y + 1, x] != WALL)
                next(matrix, y + 1, x);
            if (x < matrix.GetLength(1) - 1 && matrix[y, x + 1] != VISITED && matrix[y, x + 1] != WALL)
                next(matrix, y, x + 1);
        }

        public static int[,] CreateMatrix(string maze)
        {
            string[] str = maze.Split(new char[] { '\n' });
            int[,] matrix = new int[str.Length, str[0].Length];
            for(int row = 0; row < str[0].Length; row++)
            {
                for(int col = 0; col < str.Length; col++)
                {
                    if (str[col][row] == '.') matrix[col, row] = 0;
                    else matrix[col, row] = WALL;
                }
            }
            return matrix;
        }
    }

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

[TestFixture]
public class SolutionTest
{

    [Test]
    public void fixedTests()
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

        Assert.AreEqual(true, Finder.PathFinder(a));
        Assert.AreEqual(false, Finder.PathFinder(b));
        Assert.AreEqual(true, Finder.PathFinder(c));
        Assert.AreEqual(false, Finder.PathFinder(d));
    }


    [Test]
    public void moreTests()
    {

        string a =
            ".W...\n" +
            ".W...\n" +
            ".W.W.\n" +
            "...W.\n" +
            "...W.";
        Assert.AreEqual(true, Finder.PathFinder(a));

        a = ".W...\n" +
            ".W...\n" +
            ".W.W.\n" +
            "...WW\n" +
            "...W.";
        Assert.AreEqual(false, Finder.PathFinder(a));

        a = "..W\n" +
            ".W.\n" +
            "W..";
        Assert.AreEqual(false, Finder.PathFinder(a));

        a = ".WWWW\n" +
            ".W...\n" +
            ".W.W.\n" +
            ".W.W.\n" +
            "...W.";
        Assert.AreEqual(true, Finder.PathFinder(a));

        a = ".W...\n" +
            "W....\n" +
            ".....\n" +
            ".....\n" +
            ".....";
        Assert.AreEqual(false, Finder.PathFinder(a));

        a = ".W\n" +
            "W.";
        Assert.AreEqual(false, Finder.PathFinder(a));

        a = ".";
        Assert.AreEqual(true, Finder.PathFinder(a));
    }




    private static bool DEBUG = false;

    private Random rnd = new Random();

    private int rand(int n) { return rnd.Next(n); }
    private int rand(int n, int m) { return n + rnd.Next(m - n + 1); }

    [Test]
    public void randomTests()
    {

        int count = 0,
            TIMES = 20,
            RNG = 100;

        for (int nTimes = 0; nTimes < TIMES; nTimes++)
        {
            for (int n = 1; n < RNG + 1; n++)
            {
                string maze = generateMaze(n);

                bool expected = KikicestKiTrouveLaSolution.PathFinder(maze);
                Assert.AreEqual(expected, Finder.PathFinder(maze));

                count += expected ? 1 : 0;
            }
        }

        if (DEBUG) Console.WriteLine("" + count + "/" + (RNG * TIMES));
    }


    private string generateMaze(int n)
    {

        int size = n * n,
            nWalls = rand(size / 4, size / 3);

        ISet<int> posWalls = new HashSet<int>();
        while (posWalls.Count < nWalls)
            posWalls.Add(rand(size));

        StringBuilder[] sbArr = Enumerable.Range(0, n)
                                .Select(x => new StringBuilder(new string('.', n)))
                                .ToArray();

        foreach(var w in posWalls)
        {
            int x = w / n, y = w % n;
            sbArr[x][y] = 'W';
        };

        sbArr[n - 1][n - 1] = '.';        // first and last tile always free
        sbArr[0][0] = '.';

        return string.Join("\n", sbArr.Select(sb=>sb.ToString()));
    }
    
    private sealed class KikicestKiTrouveLaSolution
    {
        private class Point
        {
            public int x, y;

            public Point(int x, int y) { this.x = x;  this.y = y; }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Point other = (Point)obj;
                return x == other.x && y == other.y;

            }

            public override int GetHashCode() { return x * 31 + y; }
        }


        readonly private static List<Point> MOVES = new List<Point>() { new Point(1, 0), new Point(0, 1), new Point(0, -1), new Point(-1, 0)};
        
        public static bool PathFinder(string maze)
        {

            int S = (int)Math.Sqrt(maze.Length) - 1;
            if (S == 0) return true;

            ISet<Point> bag = new HashSet<Point>();
            int x = -1;

            foreach(string line in maze.Split('\n'))
            {
                x++;
                for (int y = 0; y < line.Length; y++)
                    if (line[y] == '.') bag.Add(new Point(x, y));
            }
            bag.Remove(new Point(0, 0));

            Point     end = new Point(S, S);
            bool[] hasEnd = { false};
            ISet<Point> look = new HashSet<Point>(new List<Point>() { new Point(0, 0) });

            while (look.Any())
            {
                if (hasEnd[0]) return true;
                look = new HashSet<Point>(
                            look.SelectMany(p=>MOVES.Select(d => new Point(p.x + d.x, p.y + d.y)))
                               .Distinct()
                               .Where(p => {
                                            if (p.Equals(end)) hasEnd[0] = true;
                                            if (bag.Contains(p))
                                            {
                                                bag.Remove(p);
                                                return true;
                                            }
                                            else return false;
                                          })
                            );
            }
            return false;
        }
    }
}
