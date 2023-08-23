/*Challenge link:https://www.codewars.com/kata/562e6df5cf2d3908ad00019e/train/csharp
Question:
Don't Drink the Water

Given a two-dimensional array representation of a glass of mixed liquids, sort the array such that the liquids appear in the glass based on their density. (Lower density floats to the top) The width of the glass will not change from top to bottom.

======================
|   Density Chart    |
======================
| Honey   | H | 1.36 |
| Water   | W | 1.00 |
| Alcohol | A | 0.87 |
| Oil     | O | 0.80 |
----------------------

{                             {
  { 'H', 'H', 'W', 'O' },        { 'O','O','O','O' },
  { 'W', 'W', 'O', 'W' },  =>    { 'W','W','W','W' },
  { 'H', 'H', 'O', 'O' }         { 'H','H','H','H' }
}                             }
 
The glass representation may be larger or smaller. If a liquid doesn't fill a row, it floats to the top and to the left.
*/

//***************Solution********************

using System.Collections.Generic;
using System.Linq;

public class Kata{
  public static char[,] SeparateLiquids(char[,] glass){
    
    //dictionary for liquid name and density
    Dictionary<char, double> densities = new(){
      {'H', 1.36}, {'W', 1.00}, {'A', 0.87}, {'O', 0.8}};
    
    int i = 0;
    int rowLength = glass.GetLength(1);
    
    //loop and order elements by densities, c
    //assign new elment<char, double>  into current index of glass to c
    foreach(char c in glass.Cast<char>().OrderBy(c => densities[c])){
      glass[i / rowLength, i % rowLength] = c;
      i++;
    }
    return glass;
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test, Description("Should be able to sort 3 liquids"), Order(1)]
    public void ShouldBeAbleToHandle3Liquids()
    {
      char[,] actual = Kata.SeparateLiquids(new char[,] { { 'H', 'H', 'W', 'O' }, { 'W','W','O','W' }, { 'H','H','O','O' } });
      char[,] expected = new char[,] { { 'O', 'O', 'O', 'O' }, { 'W','W','W','W' }, { 'H','H','H','H' } };
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    [Test, Description("Should be able to sort 4 liquids"), Order(2)]
    public void ShouldBeAbleToHandle4Liquids()
    {
      char[,] actual = Kata.SeparateLiquids(new char[,] { { 'A','A','O','H' }, { 'A','H','W','O' }, { 'W','W','A','W' }, { 'H','H','O','O' } });
      char[,] expected = new char[,] { { 'O','O','O','O' }, { 'A','A','A','A' }, { 'W','W','W','W' }, { 'H','H','H','H'} };
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    [Test, Description("Should be able to handle one row"), Order(3)]
    public void ShouldBeAbleToHandleOneRow()
    {
      char[,] actual = Kata.SeparateLiquids(new char[,] { { 'A','H','W','O' } });
      char[,] expected = new char[,] { { 'O','A','W','H' } };
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    [Test, Description("Should be able to handle one column"), Order(4)]
    public void ShouldBeAbleToHandleOneColumn()
    {
      char[,] actual = Kata.SeparateLiquids(new char[,] { { 'A' }, { 'H' }, { 'W' }, { 'O' } });
      char[,] expected = new char[,] { { 'O' }, { 'A' }, { 'W' }, { 'H' } };
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    [Test, Description("Should be able to handle empty array"), Order(5)]
    public void ShouldBeAbleToHandleEmptyArray()
    {
      char[,] actual = Kata.SeparateLiquids(new char[,] { });
      char[,] expected = new char[,] { };
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    [Test, Description("Random tests (100 randomly generated matrices)"), Order(6)]
    public void RandomTest([Random(0, 11, 10)] int height, [Random(0, 11, 10)] int width)
    {
      char[,] randomMatrix = GenerateRandomMatrix(height, width);
      
      Func<char[,], char[,]> MySeparateLiquids = delegate (char[,] glass)
      {
        char[,] newGlass = new char[glass.GetLength(0), glass.GetLength(1)];
        char[] flattened = new char[glass.Length];
    
        int index = 0;
        foreach (char liquid in glass)
          flattened[index++] = liquid;
    
        flattened = flattened.OrderBy(x =>
        {
          switch (x)
          {
            case 'H':
              return 1.36;
            case 'W':
              return 1.00;
            case 'A':
              return 0.87;
            default:
              return 0.8;
          }
        }).ToArray();
        
        index = 0;
        for (int i = 0; i < newGlass.GetLength(0); i++)
          for (int j = 0; j < newGlass.GetLength(1); j++)
            newGlass[i, j] = flattened[index++];
        
        return newGlass;
      };
    
      char[,] expected = MySeparateLiquids(randomMatrix), actual = Kata.SeparateLiquids(randomMatrix);
      
      CollectionAssert.AreEqual(expected, actual, string.Join("\n", "Expected matrix:", ShowMatrix(expected), "Actual maxtrix:", ShowMatrix(actual)));
    }
    
    private static string ShowMatrix(char[,] matrix)
    {
      string stringRepresentation = "{\n";
      
      for (int i = 0; i < matrix.GetLength(0); i++)
      {
        stringRepresentation += "  { ";
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
          stringRepresentation += matrix[i, j] + " ";
        }
        stringRepresentation += "}\n";
      }
      stringRepresentation += "}";
      
      return stringRepresentation;
    }
    
    private static char[,] GenerateRandomMatrix(int height, int width)
    {
      const string Bases = "HWAO";
      Random rand = new Random();
      char[,] randomMatrix = new char[height, width];
      
      for (int h = 0; h < height; h++)
      {
        for (int w = 0; w < width; w++)
        {
          randomMatrix[h, w] = Bases[rand.Next(0,4)];
        }
      }
      
      return randomMatrix;
    }
  }
}
