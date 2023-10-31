/*Challenge link:https://www.codewars.com/kata/5679d5a3f2272011d700000d/train/csharp
Question:
In a grid of 6 by 6 squares you want to place a skyscraper in each square with only some clues:

The height of the skyscrapers is between 1 and 6
No two skyscrapers in a row or column may have the same number of floors
A clue is the number of skyscrapers that you can see in a row or column from the outside
Higher skyscrapers block the view of lower skyscrapers located behind them

Can you write a program that can solve each 6 by 6 puzzle?

Example:

To understand how the puzzle works, this is an example of a row with 2 clues. Seen from the left there are 6 buildings visible while seen from the right side only 1:

 6	  	  	  	  	  	  	 1

There is only one way in which the skyscrapers can be placed. From left-to-right all six buildings must be visible and no building may hide behind another building:

 6	 1	 2	 3	 4	 5	 6	 1

Example of a 6 by 6 puzzle with the solution:

  	   	   	   	2	2	   	  
  	  	  	  	  	  	  	  
  	  	  	  	  	  	  	  
 3	  	  	  	  	  	  	  
  	  	  	  	  	  	  	 6
 4	  	  	  	  	  	  	 3
 4	  	  	  	  	  	  	  
  	  	  	  	  	4	  	  

  	  	  	  	 2	 2	  	  
  	 5	 6	 1	 4	 3	 2	  
  	 4	 1	 3	 2	 6	 5	  
 3	 2	 3	 6	 1	 5	 4	  
  	 6	 5	 4	 3	 2	 1	 6
 4	 1	 2	 5	 6	 4	 3	 3
 4	 3	 4	 2	 5	 1	 6	  
  	  	  	  	  	4	  	  

Task:

Finish:
public static int[][] SolvePuzzle(int[] clues)
Pass the clues in an array of 24 items. The clues are in the array around the clock. Index:
  	 0	 1	 2	 3	 4	 5	  
 23	  	  	  	  	  	  	 6
 22	  	  	  	  	  	  	 7
 21	  	  	  	  	  	  	 8
 20	  	  	  	  	  	  	 9
 19	  	  	  	  	  	  	 10
 18	  	  	  	  	  	  	 11
  	17	16	15	14	13	12	  
If no clue is available, add value `0`
Each puzzle has only one possible solution
`SolvePuzzle()` returns matrix `int[][]`. The first indexer is for the row, the second indexer for the column. Python returns a 6-tuple of 6-tuples, Ruby a 6-Array of 6-Arrays.
*/

//***************Solution********************
//note: solution timed out on 7x7
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
    [TestCase(3)]
    public void SolvePuzzleTest(int test)
    {
        var actual = Skyscrapers.SolvePuzzle(rtrt4342gg(test));
        CollectionAssert.AreEqual(gfsdfgrrre454(test), actual);
    }

    [Test]
    public void RandomizedSolvePuzzleTest()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var tests = Enumerable.Range(0, 15).ToList<int>();

        try
        {
            while (tests.Count > 0)
            {
                var n = tests[random.Next(0, tests.Count)];
                tests.Remove(n);
                var test = n % 4 + 1;
                var turn = n / 4;
                var clues = TurnClues(turn, rtrt4342gg(test));
                var expected = TurnExpected(turn, gfsdfgrrre454(test));
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
        var turnedClues = clues.Skip(x * 6).Take(((4 - x) * 6)).ToList();
        turnedClues.AddRange(clues.ToList().Take(x*6));
        return turnedClues.ToArray();
    }

    private int[][] TurnExpected(int x, int[][] expected)
    {
        var turnedExpected = new int[6][];
        for (var i = 0; i < 6; i++)
        {
            turnedExpected[i] = new int[6];
            for (var j=0; j< 6; j++)
            {
                if (x==0) turnedExpected[i][j] = expected[i][j];
                if (x==1) turnedExpected[i][j] = expected[j][5-i];
                if (x==2) turnedExpected[i][j] = expected[5-i][5-j];
                if (x==3) turnedExpected[i][j] = expected[5-j][i];
            }
        }
        return turnedExpected;
    }
    
    private int[] rtrt4342gg(int test)
    {
        if (test==1) return new[]{ 3, 2, 2, 3, 2, 1,
                                   1, 2, 3, 3, 2, 2,
                                   5, 1, 2, 2, 4, 3,
                                   3, 2, 1, 2, 2, 4};
        if (test==2) return new[]{ 0, 0, 0, 2, 2, 0,
                                   0, 0, 0, 6, 3, 0,
                                   0, 4, 0, 0, 0, 0,
                                   4, 4, 0, 3, 0, 0};
        if (test==3) return new[]{ 0, 3, 0, 5, 3, 4, 
                                   0, 0, 0, 0, 0, 1,
                                   0, 3, 0, 3, 2, 3,
                                   3, 2, 0, 3, 1, 0};
        if (test==4) return new[]{ 4, 3, 2, 5, 1, 5, 
                                   2, 2, 2, 2, 3, 1,
                                   1, 3, 2, 3, 3, 3,
                                   5, 4, 1, 2, 3, 4};
        throw new Exception("Unknown test");
    }
    
    private int[][] gfsdfgrrre454(int test)
    {
        if (test==1) return new[]{new []{ 2, 1, 4, 3, 5, 6}, 
                                  new []{ 1, 6, 3, 2, 4, 5}, 
                                  new []{ 4, 3, 6, 5, 1, 2}, 
                                  new []{ 6, 5, 2, 1, 3, 4}, 
                                  new []{ 5, 4, 1, 6, 2, 3}, 
                                  new []{ 3, 2, 5, 4, 6, 1 }};            
        if (test==2) return new[]{new []{ 5, 6, 1, 4, 3, 2 }, 
                                  new []{ 4, 1, 3, 2, 6, 5 }, 
                                  new []{ 2, 3, 6, 1, 5, 4 }, 
                                  new []{ 6, 5, 4, 3, 2, 1 }, 
                                  new []{ 1, 2, 5, 6, 4, 3 }, 
                                  new []{ 3, 4, 2, 5, 1, 6 }};            
        if (test==3) return new[]{new []{ 5, 2, 6, 1, 4, 3 }, 
                                  new []{ 6, 4, 3, 2, 5, 1 }, 
                                  new []{ 3, 1, 5, 4, 6, 2 }, 
                                  new []{ 2, 6, 1, 5, 3, 4 }, 
                                  new []{ 4, 3, 2, 6, 1, 5 }, 
                                  new []{ 1, 5, 4, 3, 2, 6 }};
        if (test==4) return new[]{new []{ 3, 4, 5, 1, 6, 2 }, 
                                  new []{ 4, 5, 6, 2, 1, 3 }, 
                                  new []{ 5, 6, 1, 3, 2, 4 }, 
                                  new []{ 6, 1, 2, 4, 3, 5 }, 
                                  new []{ 2, 3, 4, 6, 5, 1 }, 
                                  new []{ 1, 2, 3, 5, 4, 6 }};
        throw new Exception("Unknown test");
    }
}
