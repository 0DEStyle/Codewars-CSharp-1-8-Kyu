/*Challenge link:https://www.codewars.com/kata/5917a2205ffc30ec3a0000a8/train/csharp
Question:
In a grid of 7 by 7 squares you want to place a skyscraper in each square with only some clues:

The height of the skyscrapers is between 1 and 7
No two skyscrapers in a row or column may have the same number of floors
A clue is the number of skyscrapers that you can see in a row or column from the outside
Higher skyscrapers block the view of lower skyscrapers located behind them
Can you write a program that can solve this puzzle in time?

This kata is based on 4 By 4 Skyscrapers and 6 By 6 Skyscrapers by FrankK. By now, examples should be superfluous; you should really solve Frank's kata first, and then probably optimise some more. A naive solution that solved a 4×4 puzzle within 12 seconds might need time somewhere beyond the Heat Death of the Universe for this size. It's quite bad.

Task
Create

public static int[][] SolvePuzzle(int[] clues)
Clues are passed in as an int[28].
The return value is an int[7][7].

All puzzles have one possible solution.
All this is the same as with the earlier kata.

Caveat: The tests for this kata have been tailored to run in ~10 seconds with the JavaScript reference solution. You'll need to do better than that! Please note the optimization tag.

Conceptis Puzzles have heaps of these puzzles, from 4×4 up to 7×7 and unsolvable within CodeWars time constraints. Old puzzles from there were used for the tests. They also have lots of other logic, numbers and mathematical puzzles, and their puzzle user interface is generally nice, very nice.
*/

//***************Solution********************
/* 
reference for useful info 
4fun 7x7: https://www.puzzlemix.com/menu.php?b=55
7x7 solver: https://codepen.io/rs_zdjn/pen/dyoYJjo
7x7 solving example: https://www.youtube.com/watch?v=-8YBPem40Lo&list=PLH_elo2OIwaCRRJ8in5rnv-kp81wF7kw5&index=4
6x6 logic: https://medium.com/launch-school/how-to-solve-a-1-kyu-kata-on-codewars-or-any-difficult-programming-exercise-f7e38ee7fd22

Basic 
4x4 logic: https://www.brainbashers.com/skyscrapershelp.asp

Optimisation:
nxn: https://codereview.stackexchange.com/questions/256579/skyscraper-solver-for-nxn-size
backtracking algo: https://www.geeksforgeeks.org/backtracking-algorithms/

Clues are in NESW order, clockwise starting from north.
clues[28]:
       { 7, 0, 0, 0, 2, 2, 3,  //N
         0, 0, 3, 0, 0, 0, 0,  //E
         3, 0, 3, 0, 0, 5, 0,  //S
         0, 0, 0, 0, 5, 0, 4 },//W
         
Techniques: https://www.conceptispuzzles.com/index.aspx?uri=puzzle/skyscrapers/techniques#:~:text=The%20object%20is%20to%20place,the%20value%20of%20the%20clue.
1.clues of 1
2.clues of n
3.tech 1, highest by order
4.tech 2, 2 clues
5.Unique skyscraper sequences
6.highest skycraper located for opposite clue
7.lowest skyscraper located for adjacent clue

find singled out, normal sudoku cancel
*/


/*                    ************** Visualisation of wtf is going on ****************
4x4 index
   0 1 2 3
15         4
14         5
13         6
12         7
  11,10,9,8
  
7x7 index
			      	//N
       0, 1, 2, 3, 4, 5, 6,  
	   27					            7 
	   26				 	            8
	   25					            9
//W  24					            10 //E
	   23					            11
	   22					            12
	   21					            13
		   20,19,18,17,16,15,14   
			      	//S
              
7x7 clues by index
clues[28]:
				    //N
     7, 0, 0, 0, 2, 2, 3,  
		4					            0 
		0				 	            0
		5					            3
//W	0					            0 //E
		0					            0
		0					            0
		0					            0
		  0, 5, 0, 0, 3, 0, 3   
				    //S

      This is the formula to solve N x N!
      we want to find the right index for each column and row, see 7x7 index, 
      col => let's say i is 0, then col is 20, so by using the formula below we get 0 and 20, and we pass that into Line(0,20)
      row => let's sat i is 7, then row is 27, so by using the formula below we get 0 and 20, and we pass that into Line(27,7)
      
      col = n * 3 - 1 - i  (NS)                
      row = n * 5 - 1 + i => then reverse (WE) 
      apply formula to generate index in the correct order
*/      

using System;
using System.Linq;
using System.Collections.Generic;
public class Skyscrapers{

//global variable to store board size n
public static int size = 42069;

    public static int[][] SolvePuzzle(int[] clues){
	    //find size of board and set global variable to n
      int n = clues.Length / 4;
      Skyscrapers.size = n;
      Console.WriteLine("n:" + n + " " + Skyscrapers.size);
      
      var col = new List<Line>{};
      var row = new List<Line>{};
      
      //generate Lines for both column and row by passing in the correct index(see above) to access the right clue
      for(int i = 0; i < n; i++){
        //uncomment this if you want to see what was being generated 
        //Console.WriteLine(i + " " + (n * 3 - 1 - i));   
        col.Add(new Line(clues[i], clues[n * 3 - 1 - i])); 
      }
      for(int i = n; i < n+n; i++){
        //uncomment this if you want to see what was being generated 
        //Console.WriteLine(i + " " + (n * 5 - 1 - i)); 
        row.Add(new Line(clues[n * 5 - 1 - i ], clues[i])); 
      }
      
/* visualisation for cells, uncomment this if you want to see what was being generated 
      var temp = row.Select(x => x.firstCell());
      var temp2 = col.Select(x => x.firstCell());
      foreach (var x in temp)
        Console.WriteLine(string.Join(" ",x));
      Console.WriteLine();
      foreach (var x in temp2)
        Console.WriteLine(string.Join(" ",x));
*/
      
		    //Solver: check for both rows and columns, while either current elements are not single
        while (row.Any(x => !x.CheckSingle()) || col.Any(x => !x.CheckSingle())){
			      //loop through each cells, and clear cells
            for (int y = 0; y < n; y++){
                for (int x = 0; x < n; x++){
                    col[y].removeCell(x).ForEach(z => row[x].SudokuWipe(y, z));
                    row[y].removeCell(x).ForEach(z => col[x].SudokuWipe(y, z));
                }
            }
        }
        return row.Select(x => x.firstCell()).ToArray();
    }
}

public class Line{
	private List<Number> numsList = new List<Number>();
	private static List<T> tempList<T>(T e) => new List<T> {e};
	//Generate 1 up to Skyscrapers.size
  private static int[] numRange = Enumerable.Range(1, Skyscrapers.size).ToArray();
  private static Number[] numArr = checkLine(numRange).Select(x => new Number(x.ToArray())).ToArray();
  
	//enumerable List
    private static IEnumerable<List<int>> checkLine(IEnumerable<int> x){
        var myEnum = x as int[] ?? x.ToArray();

		if(myEnum.Count() == 1)
			return tempList(tempList(myEnum.First()));
		return myEnum.SelectMany(y => checkLine(myEnum.Except(new int[] {y}))
					 .Select(z => new int[] {y}.Concat(z).ToList())).ToList();
    }

    public List<int> removeCell(int index){
        var line = new List<int>(numRange);
        foreach (var x in numsList)
            line.Remove(x.cellHeight[index]);
        return line;
    }
	
	//check single cell, sudoku wipe, get first cell value
    public bool CheckSingle() => numsList.Count == 1;
    public void SudokuWipe(int index, int cellHeight) => numsList.RemoveAll(x => x.cellHeight[index] == cellHeight);
    public int[] firstCell() => numsList[0].cellHeight;

	//pass n1 and n2 indexs into here, check validation for cell and add to nums
    public Line(int n1, int n2){
        foreach (Number x in numArr)
            if (x.checkValid(n1, n2)) 
				numsList.Add(x);
    }
}

//struct for repeatitive stuff
public struct Number{
  int x, y;
  public int[] cellHeight;
    
  public Number(IEnumerable<int> cellHeight){
        this.cellHeight = cellHeight as int[] ?? cellHeight.ToArray();
        x = visibleCell(this.cellHeight);
        y = visibleCell(this.cellHeight.Reverse());
    }

	//count number of visible cells/Skyscrapers  
    public static int visibleCell(IEnumerable<int> cellHeight){
        var count = 1;
        var myEnum = cellHeight as int[] ?? cellHeight.ToArray();
        var heightMax = myEnum.First();
        for (int i = 1; i < Skyscrapers.size; i++){
            var currentHeight = myEnum.ElementAt(i);
            if (heightMax < currentHeight){
                heightMax = currentHeight;
                count++;
            }
        }
        return count;
    }
	//if n1 is 0 or equal to x  and do the same with n2
    public bool checkValid(int n1, int n2) => (n1 == 0 || n1 == x) && (n2 == 0 || n2 == y);
}





//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

public class SkyskrapersTestsConstants
{
    public static readonly int N = 7;
    public static readonly int TestsCount = 7;
    public static int [][] Clues { get { return clues; }}
    public static int [][][] Expected { get { return expected; }}

    static readonly int [][] clues = new[]
    {
        new [] { 7, 0, 0, 0, 2, 2, 3,
                 0, 0, 3, 0, 0, 0, 0,
                 3, 0, 3, 0, 0, 5, 0,
                 0, 0, 0, 0, 5, 0, 4 },
        new [] { 6, 4, 0, 2, 0, 0, 3,
                 0, 3, 3, 3, 0, 0, 4,
                 0, 5, 0, 5, 0, 2, 0,
                 0, 0, 0, 4, 0, 0, 3 },
        new [] { 0, 0, 0, 5, 0, 0, 3,
                 0, 6, 3, 4, 0, 0, 0,
                 3, 0, 0, 0, 2, 4, 0,
                 2, 6, 2, 2, 2, 0, 0 },
        new [] { 0, 0, 5, 0, 0, 0, 6,
                 4, 0, 0, 2, 0, 2, 0,
                 0, 5, 2, 0, 0, 0, 5,
                 0, 3, 0, 5, 0, 0, 3 },
        new [] { 0, 0, 5, 3, 0, 2, 0,
                 0, 0, 0, 4, 5, 0, 0,
                 0, 0, 0, 3, 2, 5, 4,
                 2, 2, 0, 0, 0, 0, 5 },
        new [] { 0, 2, 3, 0, 2, 0, 0,
                 5, 0, 4, 5, 0, 4, 0,
                 0, 4, 2, 0, 0, 0, 6,
                 5, 2, 2, 2, 2, 4, 1 },
        new [] { 0, 2, 3, 0, 2, 0, 0,
                 5, 0, 4, 5, 0, 4, 0,
                 0, 4, 2, 0, 0, 0, 6,
                 0, 0, 0, 0, 0, 0, 0 }
    };

    static readonly int [][][] expected = new[]
    {
        new[] { new[] { 1, 5, 6, 7, 4, 3, 2 },
                new[] { 2, 7, 4, 5, 3, 1, 6 },
                new[] { 3, 4, 5, 6, 7, 2, 1 },
                new[] { 4, 6, 3, 1, 2, 7, 5 },
                new[] { 5, 3, 1, 2, 6, 4, 7 },
                new[] { 6, 2, 7, 3, 1, 5, 4 },
                new[] { 7, 1, 2, 4, 5, 6, 3 } },
        new[] { new[] { 2, 1, 6, 4, 3, 7, 5 },
                new[] { 3, 2, 5, 7, 4, 6, 1 },
                new[] { 4, 6, 7, 5, 1, 2, 3 },
                new[] { 1, 3, 2, 6, 7, 5, 4 },
                new[] { 5, 7, 1, 3, 2, 4, 6 },
                new[] { 6, 4, 3, 2, 5, 1, 7 },
                new[] { 7, 5, 4, 1, 6, 3, 2 } },
        new[] { new[] { 3, 5, 6, 1, 7, 2, 4 },
                new[] { 7, 6, 5, 2, 4, 3, 1 },
                new[] { 2, 7, 1, 3, 6, 4, 5 },
                new[] { 4, 3, 7, 6, 1, 5, 2 },
                new[] { 6, 4, 2, 5, 3, 1, 7 },
                new[] { 1, 2, 3, 4, 5, 7, 6 },
                new[] { 5, 1, 4, 7, 2, 6, 3 } },
        new[] { new[] { 3, 4, 1, 7, 6, 5, 2 },
                new[] { 7, 1, 2, 5, 4, 6, 3 },
                new[] { 6, 3, 5, 2, 1, 7, 4 },
                new[] { 1, 2, 3, 6, 7, 4, 5 },
                new[] { 5, 7, 6, 4, 2, 3, 1 },
                new[] { 4, 5, 7, 1, 3, 2, 6 },
                new[] { 2, 6, 4, 3, 5, 1, 7 } },
        new[] { new[] { 2, 3, 1, 4, 6, 5, 7 },
                new[] { 1, 7, 4, 6, 5, 2, 3 },
                new[] { 3, 6, 5, 7, 2, 1, 4 },
                new[] { 7, 5, 6, 3, 1, 4, 2 },
                new[] { 6, 2, 7, 5, 4, 3, 1 },
                new[] { 5, 4, 2, 1, 3, 7, 6 },
                new[] { 4, 1, 3, 2, 7, 6, 5 } },
        new[] { new[] { 7, 6, 2, 1, 5, 4, 3 },
                new[] { 1, 3, 5, 4, 2, 7, 6 },
                new[] { 6, 5, 4, 7, 3, 2, 1 },
                new[] { 5, 1, 7, 6, 4, 3, 2 },
                new[] { 4, 2, 1, 3, 7, 6, 5 },
                new[] { 3, 7, 6, 2, 1, 5, 4 },
                new[] { 2, 4, 3, 5, 6, 1, 7 } },
        new[] { new[] { 7, 6, 2, 1, 5, 4, 3 },
                new[] { 1, 3, 5, 4, 2, 7, 6 },
                new[] { 6, 5, 4, 7, 3, 2, 1 },
                new[] { 5, 1, 7, 6, 4, 3, 2 },
                new[] { 4, 2, 1, 3, 7, 6, 5 },
                new[] { 3, 7, 6, 2, 1, 5, 4 },
                new[] { 2, 4, 3, 5, 6, 1, 7 } }
    };
};

[TestFixture]
public class BasicTests
{
    [Test]
    public void Test_0_Medium()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[0]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[0], actual);
    }

    [Test]
    public void Test_1_Hard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[1]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[1], actual);
    }


    [Test]
    public void Test_2_Hard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[2]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[2], actual);
    }

    [Test]
    public void Test_3_VeryHard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[3]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[3], actual);
    }

    [Test]
    public void Test_4_VeryHard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[4]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[4], actual);
    }

    [Test]
    public void Test_5_VeryHard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[5]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[5], actual);
    }

    [Test]
    public void Test_6_VeryHard()
    {
        var actual = Skyscrapers.SolvePuzzle(SkyskrapersTestsConstants.Clues[6]);
        CollectionAssert.AreEqual(SkyskrapersTestsConstants.Expected[6], actual);
    }
}

[TestFixture]
public class RandomTests
{
    static int random_count()
    {
        return 3;
    }

    static int[] Rotate(int[] clues, int left_rotations_count)
    {
        var n = left_rotations_count * SkyskrapersTestsConstants.N;
        return clues.Skip(n).Concat(clues.Take(n)).ToArray();
    }

    static void Rotate(ref int a, ref int b, ref int c, ref int d, int left_rotations_count)
    {
        for(var count = 0; count < left_rotations_count; ++count)
        {
            swap(ref a, ref b);
            swap(ref b, ref c);
            swap(ref c, ref d);
        }
    }

    static void swap(ref int a, ref int b)
    {
        a ^= b; b ^= a; a ^= b;
    }

    static int[][] Rotate(int[][] board, int left_rotations_count)
    {
        var res = board;
        var n = board.Length;

        for(var i = 0; i < n/2; ++i)
            for(var j = 0; j < (n + 1) / 2; ++j)
                Rotate(ref res[i][j], ref res[j][n-1-i], ref res[n-1-i][n-1-j], ref res[n-1-j][i], left_rotations_count);

        return res;
    }

    [Test]
    public void ShouldPassAllTests()
    {
        for(var i = 0; i < SkyskrapersTestsConstants.TestsCount; ++i)
        {
            var rotations_count = random_count();
            var clues = Rotate(SkyskrapersTestsConstants.Clues[i], rotations_count);
            var actual = Skyscrapers.SolvePuzzle(clues);
            CollectionAssert.AreEqual(Rotate(SkyskrapersTestsConstants.Expected[i], rotations_count), actual);
        }
    }
}
