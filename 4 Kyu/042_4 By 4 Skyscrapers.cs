/*Challenge link:https://www.codewars.com/kata/5671d975d81d6c1c87000022/train/csharp
Question:
In a grid of 4 by 4 squares you want to place a skyscraper in each square with only some clues:

The height of the skyscrapers is between 1 and 4
No two skyscrapers in a row or column may have the same number of floors
A clue is the number of skyscrapers that you can see in a row or column from the outside
Higher skyscrapers block the view of lower skyscrapers located behind them

Can you write a program that can solve this puzzle?

Example:

To understand how the puzzle works, this is an example of a row with 2 clues. Seen from the left side there are 4 buildings visible while seen from the right side only 1:

 4	    	    	    	    	 1

There is only one way in which the skyscrapers can be placed. From left-to-right all four buildings must be visible and no building may hide behind another building:

 4	 1	 2	 3	 4	 1

Example of a 4 by 4 puzzle with the solution:

  	    	    	 1	 2	  
  	  	  	  	  	  
  	  	  	  	  	 2
 1	  	  	  	  	  
  	  	  	  	  	  
  	  	  	 3	  	  

  	  	  	 1	 2	  
  	 2	 1	 4	 3	  
  	 3	 4	 1	 2	 2
 1	 4	 2	 3	 1	  
  	 1	 3	 2	 4	  
  	  	  	 3	  	  

Task:

Finish:
public static int[][] SolvePuzzle(int[] clues)
Pass the clues in an array of 16 items. This array contains the clues around the clock, index:
  	 0	 1	   2	   3	  
 15	  	  	  	  	 4
 14	  	  	  	  	 5
 13	  	  	  	  	 6
 12	  	  	  	  	 7
  	11	10	 9	 8	  
If no clue is available, add value `0`
Each puzzle has only one possible solution
`SolvePuzzle()` returns matrix `int[][]`. The first indexer is for the row, the second indexer for the column. (Python: returns 4-tuple of 4-tuples, Ruby: 4-Array of 4-Arrays)
If you finished this kata you can use your solution as a base for the more challenging kata: 6 By 6 Skyscrapers
*/

//***************Solution********************
//vid ref: https://www.youtube.com/watch?v=PxqosXNiQZA&list=PLH_elo2OIwaCRRJ8in5rnv-kp81wF7kw5&index=1&pp=iAQB
//step ref: https://www.brainbashers.com/skyscrapershelp.asp
using System;
using System.Collections.Generic;
using System.Linq;

public class Skyscrapers {
  public static int[][] SolvePuzzle(int[] clues) {
    //print clues 
    //string str = string.Concat(clues); Console.WriteLine(str);
    
    var n = clues.Length / 4;    //find board size by dividing clues by 4 sides
    var memento = new Stack<Stack<Action>>();
    var board = R(n).Select(_ => Enumerable.Repeat(0, n).ToArray()).ToArray();   //create board
    var cells = R(n*n).Select(_ => Enumerable.Repeat(0, n).ToArray()).ToArray(); //create cells
    var peers = R(n*n).Select(c => R(n).SelectMany(i => new[]{i * n +c % n,(c / n) * n + i})
                     .Where(i => i != c).ToArray()).ToArray();
    
    //2d array, c and i are current element, id is next
    var observers = clues.Select((c,id)=> R(n).Select(i => id < n ? id + i * n : id < n * 2 
                                                                  ? (n - 1 - i) + id % n * n : id < n * 3 
                                                                  ? (n - 1 - id % n) + (n - 1 - i) * n : i + (n - 1 - id % n ) * n).Concat(new[]{c}).ToArray()).ToArray();
    
    //misc functions to return some stuff
    IEnumerable<int> R(int b) => Enumerable.Range(0, b);            //Enumerable R(int b), from 0 count up to b
    void Snapshot() => memento.Push(new Stack<Action>());           //Current memento push into stack.
    void Reg(Action a) => memento.Peek().Push(a);                   //push a into memento stack
    int Pos(int c) => board[c / n][c % n];                              //board pos
    bool IsSet(int c) => Pos(c)!=0;                                 //check if pos is 0
    bool Has(int c, int v) => !IsSet(c) && cells[c][v] == 0;        //check if c isn't set and cells is equal to 0
    int[] Candidates(int c) => R(n).Where(i => cells[c][i] == 0).ToArray();    //check if current cell is 0, convert to array
    bool Verify(int[] o) => o[n] == 0 || o.Take(n).Any(i => Pos(i) == 0) || o[n] == Look(o); //if o[n] is equal to 0 or any pos is equal to 0 or o[n] is equal to Look(0)
    void Uncloack(int c, int v) => cells[c][v]--;                   //reveal cells by cells[c][v] subtract 1
    void Unlock(int c, int v) => board[c / n][c % n] = 0;               //set board[c/n][c%n] to 0
    
    int Look(int[] o) {  //return ls.Distinct().Count()
      var y =-1;
      var ls =o.Take(n).Select(x=>y=Math.Max(y,Pos(x))); 
      return ls.Distinct().Count(); 
    }
    void Restore() {     //pop stack.
      var ls = memento.Pop();
      while (ls.Count > 0) 
        ls.Pop().Invoke(); 
    }
     void Cloack(int c, int v) { //cloack cells
      cells[c][v]++; 
      Reg(() => Uncloack(c,v)); 
    }
    void Lock(int c, int v) {  //lock cell
      board[c / n][c % n]= v + 1; 
      peers[c].ToList().ForEach(p => Cloack(p,v)); 
      Reg(() => Unlock(c,v)); 
    }

    void ReduceEdgeConstraints() {
      foreach (var o in observers) {
        switch (o[o.Length-1]) {
          case 1:
            if (!IsSet(o[0])) Lock(o[0], n-1);
            break;
          case 2:
            if (Has(o[0], n -1)) Cloack(o[0], n -1);
            if (Has(o[1], n -2)) Cloack(o[1], n -2);
            break;
          default:
            if (o[o.Length-1] == n) {
              for (var i = 0; i < n; i++)
                if (!IsSet(o[i])) Lock(o[i], i);
            } else {
              for (var i = 0; i + 1 < o[o.Length-1]; i++)
                for (var j = 0; j < o[o.Length-1] -1 -i; j++)
                  if (Has(o[i], n -1 -j)) Cloack(o[i], n -1 -j);
            }
            break;
        }
      }
    }
    
    (int,int)[] Choose() {
      var m = n+1;
      var k = default((int,int)[]);
      for (var i = 0; i < n*n; i++) {
        if (Pos(i) != 0)
          continue;
        var xs = Candidates(i);
        if (xs.Length < m) {
          m = xs.Length;
          k = xs.Select(v=>(i, v)).ToArray();
          if (m < 2) return k;
        }
      }
      return k;
    }
    
    bool DFS() {
      var constraint = Choose();
      if (constraint == null) return observers.All(Verify);
      if (constraint.Length == 0) return false;
      foreach (var option in constraint) {
        var (cell, value) = option;
        Snapshot();
        Lock(cell, value);
        if (DFS()) return true;
        Restore();
      }
      return false;
    }
    
    
    //main, calling functions
    Snapshot();
    ReduceEdgeConstraints();
    DFS();
    return board;
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class SkyscrapersTests
{
    [TestCase(1)]
    [TestCase(2)]
    public void SolvePuzzleTest(int test)
    {
        var actual = Skyscrapers.SolvePuzzle(ett3ewedfa(test));
        CollectionAssert.AreEqual(gfff345ddd(test), actual);
    }

    [Test]
    public void RandomizedSolvePuzzleTest()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var tests = Enumerable.Range(0, 11).ToList<int>();

        try
        {
            while (tests.Count > 0)
            {
                var n = tests[random.Next(0, tests.Count)];
                tests.Remove(n);
                var test = n % 3 + 1;
                var turn = n / 4;
                var clues = TurnClues(turn, ett3ewedfa(test));
                var expected = TurnExpected(turn, gfff345ddd(test));
                CollectionAssert.AreEqual(expected, Skyscrapers.SolvePuzzle(clues));
            }
        }
        catch (NUnit.Framework.AssertionException ex)
        {
            Assert.Fail("Incorrect solution.");
        }
        catch (Exception ex)
        {
            throw new Exception("Error during executing.");
        }
    }

    private int[] TurnClues(int x, int[] clues)
    {
        var turnedClues = clues.Skip(x * 4).Take(((4 - x) * 4)).ToList();
        turnedClues.AddRange(clues.ToList().Take(x * 4));
        return turnedClues.ToArray();
    }

    private int[][] TurnExpected(int x, int[][] expected)
    {
        var turnedExpected = new int[4][];
        for (var i = 0; i < 4; i++)
        {
            turnedExpected[i] = new int[4];
            for (var j = 0; j < 4; j++)
            {
                if (x == 0) turnedExpected[i][j] = expected[i][j];
                if (x == 1) turnedExpected[i][j] = expected[j][3 - i];
                if (x == 2) turnedExpected[i][j] = expected[3 - i][3 - j];
                if (x == 3) turnedExpected[i][j] = expected[3 - j][i];
            }
        }
        return turnedExpected;
    }
    
    private int[] ett3ewedfa(int test)
    {
        if (test == 1) return new[]{ 2, 2, 1, 3, 
                                     2, 2, 3, 1, 
                                     1, 2, 2, 3, 
                                     3, 2, 1, 3};
        if (test == 2) return new[]{ 0, 0, 1, 2,  
        						                 0, 2, 0, 0,  
        						                 0, 3, 0, 0,
        						                 0, 1, 0, 0};
        if (test == 3) return new[]{ 1, 2, 4, 2, 
                                     2, 1, 3, 2, 
                                     3, 1, 2, 3, 
                                     3, 2, 2, 1};
        throw new Exception("Unknown test");
    }

    private int[][] gfff345ddd(int test)
    {
        if (test == 1) return new[]{new []{1, 3, 4, 2},       
                                    new []{4, 2, 1, 3},       
                                    new []{3, 4, 2, 1},
                                    new []{2, 1, 3, 4 }};
        if (test == 2) return new[]{new []{2, 1, 4, 3}, 
                                    new []{3, 4, 1, 2}, 
                                    new []{4, 2, 3, 1}, 
                                    new []{1, 3, 2, 4}};
        if (test == 3) return new[]{new []{4, 2, 1, 3},  
        							              new []{3, 1, 2, 4},  
        							              new []{1, 4, 3, 2},
                                    new []{2, 3, 4, 1}};
        throw new Exception("Unknown test");
    }
}
