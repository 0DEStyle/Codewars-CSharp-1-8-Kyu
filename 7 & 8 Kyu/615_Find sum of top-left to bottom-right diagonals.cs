/*Challenge link:https://www.codewars.com/kata/5497a3c181dd7291ce000700/train/csharp
Question:
Given a square matrix (i.e. an array of subarrays), find the sum of values from the first value of the first array, the second value of the second array, the third value of the third array, and so on...

Examples
array = [[1, 2],
         [3, 4]]

diagonal sum: 1 + 4 = 5
array = [[5, 9, 1, 0],
         [8, 7, 2, 3],
         [1, 4, 1, 9],
         [2, 3, 8, 2]]

diagonal sum: 5 + 7 + 1 + 2 = 15
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//create sequence start from 0, count up to matrix's length
//x is the curetn element(or index), sum the elements diagonally

using System.Linq;

public static class Kata{
  public static int DiagonalSum(int[,] matrix) =>
    Enumerable.Range(0, matrix.GetLength(0))
              .Sum(x => matrix[x, x]);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class DiagonalSumTests {

  [Test]
  public void SampleTest() {
    Assert.AreEqual(12, Kata.DiagonalSum(new int[,] { { 12 } }));
    Assert.AreEqual(5, Kata.DiagonalSum(new int[2, 2] { { 1, 2 }, { 3, 4 } }));
    Assert.AreEqual(15, Kata.DiagonalSum(new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } }));
    Assert.AreEqual(34, Kata.DiagonalSum(new int[,] { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } }));
  }
  
  [Test]
  public void RandomTest() {
    var generator = new Random();
    var arraySize = generator.Next(20) + 5;
    var array = new int[arraySize, arraySize];
    var sum = 0;
    
    for (var i = 0; i < arraySize; ++i) {
      for (var j = 0; j < arraySize; ++j) {
        array[i, j] = generator.Next(1000);
        
        if (i == j) {
          sum += array[i, j];
        }
      }
    }
    
    Assert.AreEqual(sum, Kata.DiagonalSum(array), "Random test");
  }
}
