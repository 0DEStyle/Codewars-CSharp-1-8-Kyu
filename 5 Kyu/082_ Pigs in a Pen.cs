/*Challenge link:https://www.codewars.com/kata/58fdcc51b4f81a0b1e00003e/train/csharp
Question:
see images in the link above!

Introduction
Dots and Boxes is a pencil-and-paper game for two players (sometimes more). It was first published in the 19th century by Édouard Lucas, who called it la pipopipette. It has gone by many other names, including the game of dots, boxes, dot to dot grid, and pigs in a pen.

Starting with an empty grid of dots, two players take turns adding a single horizontal or vertical line between two unjoined adjacent dots. The player who completes the fourth side of a 1×1 box earns one point and takes another turn only if another box can be made. (A point is typically recorded by placing a mark that identifies the player in the box, such as an initial). The game ends when no more lines can be placed. The winner is the player with the most points. The board may be of any size. When short on time, a 2×2 board (a square of 9 dots) is good for beginners. A 5×5 is good for experts. (Source Wikipedia)
Squares
Task
Your task is to complete the class called Game. You will be given the board size as an integer board that will be between 1 and 26, therefore the game size will be board x board. You will be given an array of lines that have already been taken, so you must complete all possible squares.
Rules
1.  The integer board will be passed when the class is initialised.

2.  board will be between 1 and 26.

3.  The lines array maybe empty or contain a list of line integers.

4.  You can only complete a square if 3 out of the 4 sides are already complete.

5.  The lines array that is passed into the play() function may not be sorted numerically!
Returns
Return an array of all the lines filled in including the original lines.

Return array must be sorted numerically.

Return array must not contain duplicate integers.
Example 1
Initialise
Initialise a board of 2 squares by 2 squares where board = 2


Line Numbering

Line Input
So for the line input of [1, 3, 4] the below lines would be complete

to complete the square line 6 is needed

Game Play
int board = 2;
List<int> lines = new List<int> { 1, 3, 4 };
Game game = new Game(board);
game.play(lines) => { 1, 3, 4, 6 }
Example 2
Initialise
int board = 2;
List<int> lines = new List<int> { 1, 2, 3, 4, 5, 8, 10, 11, 12 };
Game game = new Game(board);
game.play(lines) => { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 }
Solution


Good luck and enjoy!
*/

//***************Solution********************
using System.Linq;
using System.Collections.Generic;

namespace CodeWars{
    public class Game{
      //private list for storage
        private List<int[]> b;
      
      //create new int array with size n.
      //_ is current element, i is index
      //select many, loop from i * (n * 2 + 1) + 1, up to n
      //add new elements to array with format: x, x + n, x + n + 1, x + n * 2 + 1
      //conver to list and store in b.
        public Game(int n){
            b = new int[n].SelectMany((_,i) => Enumerable.Range(i * (n * 2 + 1) + 1, n))
                         .Select(x => new[]{x, x + n, x + n + 1, x + n * 2 + 1}).ToList(); 
        }

      //convert lines to hashset and store in h
      //from b get first of default, a and x are the current elements
      //add to a.count if h doesn't contain the element x and result is equal to 1, if result is not null
      //null-coalescing operator: returns the left-hand operand if the operand is not null; otherwise it returns the right hand operand.
      //if h doesn't contain x, and null, set first to 0.
        public List<int> play(List<int> lines){
            var h = lines.ToHashSet();
            while(h.Add(b.FirstOrDefault(a => a.Count(x => !h.Contains(x)) == 1)?
                          .First(x => !h.Contains(x)) ?? 0));
        
      //order h by ascending order, skip element if x < 1. convert result to list.
            return h.OrderBy(x => x).SkipWhile(x => x < 1).ToList();
        }
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        private Random ran = new Random();

        [TestCase]
        public void ExtraTest1()
        {
            Game game = new Game(2);
            List<int> original = new List<int> { 1, 3, 4 };
            List<int> result = new List<int> { 1, 3, 4, 6 };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest2()
        {
            Game game = new Game(2);
            List<int> original = new List<int> { 7, 9, 12 };
            List<int> result = new List<int> { 7, 9, 10, 12 };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest3()
        {
            Game game = new Game(2);
            List<int> original = new List<int> { 1, 2, 3, 4, 5, 8, 10, 11, 12 };
            List<int> result = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest4()
        {
            Game game = new Game(2);
            List<int> original = new List<int> { };
            List<int> result = new List<int> { };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest5()
        {
            Game game = new Game(4);
            List<int> original = new List<int> { 20, 21, 24, 26, 33, 34, 35, 38, 39 };
            List<int> result = new List<int> { 20, 21, 24, 25, 26, 29, 30, 33, 34, 35, 38, 39 };
            CollectionAssert.AreEquivalent(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest6()
        {
            Game game = new Game(3);
            List<int> original = new List<int> { 1, 2, 3, 4, 7, 9, 10, 11, 12, 14, 16, 18, 21, 22, 23, 24 };
            List<int> result = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24 };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        [TestCase]
        public void ExtraTest7()
        {
            Game game = new Game(3);
            List<int> original = new List<int> { 5, 6, 12, 13, 19, 20, 23 };
            List<int> result = new List<int> { 2, 5, 6, 9, 12, 13, 16, 19, 20, 23 };
            CollectionAssert.AreEqual(result, game.play(original));
        }

        private List<int> makesquare(int n)
        {
            
            List<int> sq = new List<int>();
            int max = 2 * n * n + (n * 2) - 1;
            for (int x=1;x< ran.Next(1, max * 2); x++)
            {
                int num = ran.Next(1, max);
                bool there = false;
                for(int b=0; b < sq.Count; b++)
                {
                    if (sq[b] == num) { there = true; }
                }
                if (!there) { sq.Add(num); }
            }
            return sq;
        }

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
            int board = ran.Next(1, 25);
            List<int> squares = makesquare(board);
            Game game1 = new Game(board);
            Game2 game2 = new Game2(board);
            List<int> result = game2.play(squares);
            CollectionAssert.AreEqual(result, game1.play(squares));
        }
    }
}
