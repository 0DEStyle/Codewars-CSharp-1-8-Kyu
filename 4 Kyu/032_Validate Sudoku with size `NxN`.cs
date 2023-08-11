/*Challenge link:https://www.codewars.com/kata/540afbe2dc9f615d5e000425/train/csharp
Question:
Given a Sudoku data structure with size NxN, N > 0 and √N == integer, write a method to validate if it has been filled out correctly.

The data structure is a multi-dimensional Array, i.e:

[
  [7,8,4,  1,5,9,  3,2,6],
  [5,3,9,  6,7,2,  8,4,1],
  [6,1,2,  4,3,8,  7,5,9],
  
  [9,2,8,  7,1,5,  4,6,3],
  [3,5,7,  8,4,6,  1,9,2],
  [4,6,1,  9,2,3,  5,8,7],
  
  [8,7,6,  3,9,4,  2,1,5],
  [2,4,3,  5,6,1,  9,7,8],
  [1,9,5,  2,8,7,  6,3,4]
]
Rules for validation

Data structure dimension: NxN where N > 0 and √N == integer
Rows may only contain integers: 1..N (N included)
Columns may only contain integers: 1..N (N included)
'Little squares' (3x3 in example above) may also only contain integers: 1..N (N included)
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

class Sudoku{
  //2D array
    private int[][] _sudoku;
    private int _dimension;
    private int _chunk;
  
    public Sudoku(int[][] sudokuData){
        _sudoku = sudokuData;
        //because of NxN, need to find dimension
        _dimension = sudokuData.Length;
        _chunk = (int) Math.Sqrt(_dimension);
    }
  
    //pass line data and process.
    //check each line to see if all values are distinct
    //count all distinct for a final check sum
    private bool IsLineValid(IEnumerable<int> line) =>
      line.Where(x => x > 0 && x <= _dimension).Distinct().Count() == _dimension;
  
    public bool IsValid(){
      //pass each Line into IsLineValid
        return Enumerable.Range(0, _dimension)
            .All(x => IsLineValid(
            Enumerable.Range(0, _dimension).Select(y =>
            _sudoku[x / _chunk * _chunk + y / _chunk][x % _chunk * _chunk + y % _chunk])));
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class SudokuTests {

[Test]
  public void Test1() {
    var goodSudoku1 = new Sudoku(
      new int[][] {
      new int[] {7,8,4, 1,5,9, 3,2,6},
      new int[] {5,3,9, 6,7,2, 8,4,1},
      new int[] {6,1,2, 4,3,8, 7,5,9},
    
      new int[] {9,2,8, 7,1,5, 4,6,3},
      new int[] {3,5,7, 8,4,6, 1,9,2},
      new int[] {4,6,1, 9,2,3, 5,8,7},
      
      new int[] {8,7,6, 3,9,4, 2,1,5},
      new int[] {2,4,3, 5,6,1, 9,7,8},
      new int[] {1,9,5, 2,8,7, 6,3,4}
      });
     Assert.IsTrue(goodSudoku1.IsValid());
  }
  
[Test]
  public void Test2() {
    var goodSudoku2 = new Sudoku(
      new int[][] {
      new int[] {1,4, 2,3},
      new int[] {3,2, 4,1},
    
      new int[] {4,1, 3,2},
      new int[] {2,3, 1,4}
    });    
     Assert.IsTrue(goodSudoku2.IsValid());
  }

[Test]
  public void Test3() {
    var goodSudoku3 = new Sudoku(
      new int[][] {
      new int[] {1}
    });    
     Assert.IsTrue(goodSudoku3.IsValid());
  }
  
  [Test]
  public void Test4() {
    var goodSudoku4 = new Sudoku(
      new int[][] {
      new int[] {17, 19, 1, 11, 15, 8, 24, 5, 16, 9, 4, 20, 22, 7, 21, 13, 6, 23, 12, 10, 2, 18, 25, 3, 14},
      new int[] {4, 9, 14, 13, 8, 6, 21, 18, 17, 12, 1, 2, 3, 16, 15, 24, 25, 7, 5, 19, 11, 10, 22, 23, 20},
      new int[] {24, 25, 7, 21, 12, 4, 1, 2, 20, 3, 13, 5, 23, 10, 11, 9, 22, 8, 18, 14, 15, 19, 16, 6, 17},
      new int[] {16, 3, 23, 2, 5, 19, 13, 14, 22, 10, 6, 17, 18, 24, 25, 11, 20, 15, 4, 21, 12, 1, 7, 9, 8},
      new int[] {20, 10, 18, 22, 6, 15, 25, 23, 11, 7, 12, 9, 8, 19, 14, 17, 1, 3, 16, 2, 4, 24, 21, 13, 5},
      new int[] {19, 6, 20, 5, 25, 18, 2, 16, 15, 21, 17, 8, 7, 9, 23, 4, 12, 10, 14, 1, 24, 3, 11, 22, 13},
      new int[] {11, 13, 3, 17, 10, 22, 20, 12, 9, 23, 25, 15, 24, 6, 5, 8, 2, 18, 19, 16, 21, 4, 1, 14, 7},
      new int[] {15, 24, 9, 18, 21, 10, 7, 3, 4, 5, 14, 1, 11, 2, 16, 20, 13, 17, 23, 22, 6, 25, 19, 8, 12},
      new int[] {14, 7, 16, 12, 2, 1, 17, 19, 6, 8, 21, 22, 4, 18, 13, 3, 24, 25, 15, 11, 10, 20, 23, 5, 9},
      new int[] {8, 23, 22, 1, 4, 24, 11, 25, 13, 14, 3, 12, 10, 20, 19, 5, 9, 21, 7, 6, 18, 16, 2, 17, 15},
      new int[] {12, 1, 5, 10, 24, 2, 3, 21, 14, 11, 15, 25, 6, 22, 17, 16, 8, 9, 13, 4, 20, 23, 18, 7, 19},
      new int[] {23, 21, 2, 3, 17, 13, 12, 10, 7, 4, 8, 18, 19, 5, 9, 25, 15, 1, 20, 24, 22, 14, 6, 16, 11},
      new int[] {18, 8, 11, 20, 14, 16, 9, 17, 25, 1, 24, 21, 12, 4, 7, 6, 19, 22, 2, 23, 13, 5, 15, 10, 3},
      new int[] {6, 22, 25, 19, 13, 5, 8, 20, 18, 15, 23, 3, 16, 1, 2, 21, 11, 14, 10, 7, 9, 17, 12, 4, 24},
      new int[] {9, 16, 4, 15, 7, 23, 6, 22, 24, 19, 10, 11, 13, 14, 20, 18, 17, 5, 3, 12, 25, 21, 8, 2, 1},
      new int[] {7, 2, 13, 9, 20, 17, 16, 11, 21, 22, 18, 24, 14, 23, 1, 15, 3, 6, 25, 5, 8, 12, 10, 19, 4},
      new int[] {22, 18, 19, 24, 16, 3, 4, 8, 12, 25, 5, 13, 17, 15, 6, 10, 7, 11, 1, 9, 14, 2, 20, 21, 23},
      new int[] {5, 12, 6, 4, 1, 20, 18, 15, 23, 24, 16, 10, 2, 21, 3, 22, 14, 19, 8, 13, 7, 9, 17, 11, 25},
      new int[] {25, 17, 8, 14, 3, 7, 10, 13, 1, 2, 20, 19, 9, 11, 22, 12, 23, 4, 21, 18, 16, 15, 5, 24, 6},
      new int[] {10, 15, 21, 23, 11, 14, 19, 9, 5, 6, 7, 4, 25, 12, 8, 2, 16, 24, 17, 20, 1, 13, 3, 18, 22},
      new int[] {3, 11, 24, 7, 18, 9, 23, 1, 8, 13, 19, 16, 21, 17, 12, 14, 10, 20, 22, 25, 5, 6, 4, 15, 2},
      new int[] {13, 14, 15, 25, 19, 21, 22, 4, 10, 18, 2, 6, 1, 3, 24, 23, 5, 12, 11, 8, 17, 7, 9, 20, 16},
      new int[] {2, 4, 17, 16, 9, 11, 15, 7, 19, 20, 22, 14, 5, 25, 10, 1, 18, 13, 6, 3, 23, 8, 24, 12, 21},
      new int[] {21, 20, 12, 8, 22, 25, 5, 6, 3, 16, 9, 23, 15, 13, 18, 7, 4, 2, 24, 17, 19, 11, 14, 1, 10},
      new int[] {1, 5, 10, 6, 23, 12, 14, 24, 2, 17, 11, 7, 20, 8, 4, 19, 21, 16, 9, 15, 3, 22, 13, 25, 18}
      });
     Assert.IsTrue(goodSudoku4.IsValid());
  }
  
[Test]
  public void Test5() {
    var badSudoku1 = new Sudoku(
      new int[][] {
      new int[] {0,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9},
    
      new int[] {1,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9},
      
      new int[] {1,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9},
      new int[] {1,2,3, 4,5,6, 7,8,9}
      });
     Assert.IsFalse(badSudoku1.IsValid());
  }
  
[Test]
  public void Test6() {
    var badSudoku2 = new Sudoku(
      new int[][] {
      new int[] {1,2,3,4,5},
      new int[] {1,2,3,4},
    
      new int[] {1,2,3,4},
      new int[] {1}
    });   
     Assert.IsFalse(badSudoku2.IsValid());
  }  
  
[Test]
  public void Test7() {
    var badSudoku3 = new Sudoku(
      new int[][] {
      new int[] {2}
    });   
     Assert.IsFalse(badSudoku3.IsValid());
  } 

[Test]
  public void Test8() {
    var badSudoku4 = new Sudoku(
      new int[][] {
      new int[] {0}
    });   
     Assert.IsFalse(badSudoku4.IsValid());
  } 
  
[Test]
  public void Test9() {
    var badSudoku5 = new Sudoku(
      new int[][] {
      new int[] {1,2,3, 4,5,6, 7,8,9}, 
      new int[] {2,3,1, 5,6,4, 8,9,7}, 
      new int[] {3,1,2, 6,4,5, 9,7,8}, 
      new int[] {4,5,6, 7,8,9, 1,2,3}, 
      new int[] {5,6,4, 8,9,7, 2,3,1}, 
      new int[] {6,4,5, 9,7,8, 3,1,2}, 
      new int[] {7,8,9, 1,2,3, 4,5,6}, 
      new int[] {8,9,7, 2,3,1, 5,6,4}, 
      new int[] {9,7,8, 3,1,2, 6,4,5}
    });   
     Assert.IsFalse(badSudoku5.IsValid());
  } 
}
