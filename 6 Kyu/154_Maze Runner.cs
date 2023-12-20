/*Challenge link:https://www.codewars.com/kata/58663693b359c4a6560001d6/train/csharp
Question:
Introduction
Welcome Adventurer. Your aim is to navigate the maze and reach the finish point without touching any walls. Doing so will kill you instantly!
Task
You will be given a 2D array of the maze and an array of directions. Your task is to follow the directions given. If you reach the end point before all your moves have gone, you should return Finish. If you hit any walls or go outside the maze border, you should return Dead. If you find yourself still in the maze after using all the moves, you should return Lost.
The Maze array will look like

maze = [[1,1,1,1,1,1,1],
        [1,0,0,0,0,0,3],
        [1,0,1,0,1,0,1],
        [0,0,1,0,0,0,1],
        [1,0,1,0,1,0,1],
        [1,0,0,0,0,0,1],
        [1,2,1,0,1,0,1]]
..with the following key

      0 = Safe place to walk
      1 = Wall
      2 = Start Point
      3 = Finish Point
  direction = ["N","N","N","N","N","E","E","E","E","E"] == "Finish"
Rules
1. The Maze array will always be square i.e. N x N but its size and content will alter from test to test.

2. The start and finish positions will change for the final tests.

3. The directions array will always be in upper case and will be in the format of N = North, E = East, W = West and S = South.

4. If you reach the end point before all your moves have gone, you should return Finish.

5. If you hit any walls or go outside the maze border, you should return Dead.

6. If you find yourself still in the maze after using all the moves, you should return Lost.
Good luck, and stay safe!
*/

//***************Solution********************
/*
      0 = Safe place to walk
      1 = Wall
      2 = Start Point
      3 = Finish Point
*/
using System.Linq;

namespace CodeWars{
    class Kata{
        public string mazeRunner(int[,] maze, string[] directions){
          int x = 0, y = 0, len = maze.GetLength(0);
          
          //find starting point
          for(int i = 0; i < len; i++)
            for(int j = 0; j < len; j++)
              if(maze[i,j] == 2){ x = j; y = i;};
          
          //moving towards direction
          foreach(var dir in directions){
            switch(dir){
                case "N": y--; break;
                case "E": x++; break;
                case "S": y++; break;
                case "W": x--; break;
            }
            //check out of bound
            if(x < 0 || x > len - 1 || y < 0 || y > len - 1 || maze[y,x] == 1)  
              return "Dead";
            //check finish
            if(maze[y,x] == 3) 
              return "Finish";
          }
          //nothing matches
          return "Lost";
        }
    }
}

//solution 2
using System.Linq;
namespace CodeWars
{
    class Kata
    {
        public string mazeRunner(int[,] maze, string[] directions)
        {
            int i = 0, j = 0, n = maze.GetLength(0);
            for (; maze[i, j] != 2; j = ++j % n, i = j > 0 ? i : ++i % n) ;
            foreach (var item in directions.Select(act => (i += ("WNES".IndexOf(act) - 2) % 2, j += ("WNES".IndexOf(act) - 1) % 2)))
                if (i < 0 || j < 0 || i >= n || j >= n || maze[i, j] == 1) return "Dead";
                else if (maze[i, j] == 3) return "Finish";
            return "Lost";
        }
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        private int[,] maze = new int[,] { { 1, 1, 1, 1, 1, 1, 1 },
                                       { 1, 0, 0, 0, 0, 0, 3 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 0, 0, 1, 0, 0, 0, 1 },
                                       { 1, 0, 1, 0, 1, 0, 1 },
                                       { 1, 0, 0, 0, 0, 0, 1 },
                                       { 1, 2, 1, 0, 1, 0, 1 } };
        
        [TestCase]
        public void FinishTest1()
        {
            string[] directions = new string[] { "N", "N", "N", "N", "N", "E", "E", "E", "E", "E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }
        
        [TestCase]
        public void FinishTest2()
        {
            string[] directions = new string[] { "N","N","N","N","N","E","E","S","S","E","E","N","N","E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }
        
        [TestCase]
        public void FinishTest3()
        {
            string[] directions = new string[] { "N","N","N","N","N","E","E","E","E","E","W","W" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Finish", result, "Should return: 'Finish'");
        }
        
        [TestCase]
        public void DeadTest1()
        {
            string[] directions = new string[] { "N","N","N","W","W" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Dead", result, "Should return: 'Dead'");
        }
        
        [TestCase]
        public void DeadTest2()
        {
            string[] directions = new string[] { "N","N","N","N","N","E","E","S","S","S","S","S","S" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Dead", result, "Should return: 'Dead'");
        }
        
        [TestCase]
        public void LostTest1()
        {
            string[] directions = new string[] { "N","E","E","E","E" };
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            Assert.AreEqual("Lost", result, "Should return: 'Lost'");
        }
        
        private Random ran = new Random();

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTest()
        {
            int[,] maze = getMaze();
            string[] directions = getDirections();
            Kata test = new Kata();
            string result = test.mazeRunner(maze, directions);
            string solution = mazeRunner2(maze, directions);
            Assert.AreEqual(solution, result, "Should return: '"+solution+"'");
        }

        private string[] getDirections()
        {
            int size = ran.Next(1, 50);
            string[] directions = new string[size];
            for (int x = 0; x < size; x++)
            {
                int d = ran.Next(0, 3);
                if (d == 0) { directions[x] = "N"; }
                if (d == 1) { directions[x] = "E"; }
                if (d == 2) { directions[x] = "S"; }
                if (d == 3) { directions[x] = "W"; }
            }
            return directions;
        }

        private int[,] getMaze()
        {
            int size = ran.Next(10, 50);
            int[,] maze = new int[size, size];
            int len = Convert.ToInt32(Math.Sqrt(maze.Length));
            for (int x = 0; x < len; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    maze[y, x] = 0;
                }
            }
            for (int x = 0; x < ran.Next(1, maze.Length); x++)
            {
                int a = ran.Next(0, len);
                int b = ran.Next(0, len);
                maze[a, b] = 1;
            }
            int g = ran.Next(0, len);
            int h = ran.Next(0, len);
            maze[g, h] = 3;
            g = ran.Next(0, len);
            h = ran.Next(0, len);
            maze[g, h] = 2;
            return maze;
        }

        private string mazeRunner2(int[,] maze, string[] directions)
        {
            int startX = 0;
            int startY = 0;
            double len = Math.Sqrt(maze.Length);
            for (int x = 0; x < len; x++)
            {
                for (int y = 0; y < len; y++)
                {
                    if (maze[y, x] == 2) { startX = x; startY = y; }
                }
            }
            for (int x = 0; x < directions.Length; x++)
            {
                switch (directions[x])
                {
                    case "N": startY -= 1; break;
                    case "E": startX += 1; break;
                    case "S": startY += 1; break;
                    case "W": startX -= 1; break;
                }
                if (startY < 0 || startY > len - 1 || startX < 0 || startX > len - 1 || maze[startY, startX] == 1) { return "Dead"; }
                if (maze[startY, startX] == 3) { return "Finish"; }
            }

            return "Lost";
        }
    }
}
