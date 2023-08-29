/*Challenge link:https://www.codewars.com/kata/528d9adf0e03778b9e00067e/train/csharp
Question:
You've just discovered a square (NxN) field and you notice a warning sign. The sign states that there's a single bomb in the 2D grid-like field in front of you.

Write a function mineLocation/MineLocation that accepts a 2D array, and returns the location of the mine. The mine is represented as the integer 1 in the 2D array. Areas in the 2D array that are not the mine will be represented as 0s.

The location returned should be an array (Tuple<int, int> in C#) where the first element is the row index, and the second element is the column index of the bomb location (both should be 0 based). All 2D arrays passed into your function will be square (NxN), and there will only be one mine in the array.

Examples:
mineLocation( [ [1, 0, 0], [0, 0, 0], [0, 0, 0] ] ) => returns [0, 0]
mineLocation( [ [0, 0, 0], [0, 1, 0], [0, 0, 0] ] ) => returns [1, 1]
mineLocation( [ [0, 0, 0], [0, 0, 0], [0, 1, 0] ] ) => returns [2, 1]


*/

//***************Solution********************
using System;

public class Kata{
    public static Tuple<int, int> MineLocation(int[,] field){
        int idx = 0;
        foreach(var e in field){
          //find mine location
            if (e == 1)
                break;
            ++idx;
        }            
      
      //result format in tuple, assign calculation to variables accordingly (index of set, element inside the index)
        return new Tuple<int, int>(idx / field.GetLength(0), idx % field.GetLength(0));
    }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new int[,] {{1, 0}, {0, 0}}).Returns(new Tuple<int, int>(0, 0));
        yield return new TestCaseData(new int[,] {{1, 0, 0}, {0, 0, 0}, {0, 0, 0}}).Returns(new Tuple<int, int>(0, 0));
        yield return new TestCaseData(new int[,] {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 1, 0}, {0, 0, 0, 0}}).Returns(new Tuple<int, int>(2, 2));
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public Tuple<int, int> Test(int[,] field) => Kata.MineLocation(field);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static Tuple<int, int> solution(int[,] field)
    {
      for (int i = 0; i < field.GetLength(0); ++i)
      {
        for (int j = 0; j < field.GetLength(1); ++j)
        {
          if (field[i, j] == 1) { return new Tuple<int, int>(i, j); }
        }
      }
    
      return null;
    }
    
    [Test]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int size = rnd.Next(3, 20);
        int[,] test = new int[size,size];
        
        for (int j = 0; j < size; ++j)
        {
          for (int k = 0; k < size; ++k)
          {
            test[j, k] = 0;
          }
        }
        
        test[rnd.Next(0, size), rnd.Next(0, size)] = 1;
        
        Tuple<int, int> expected = solution(test);
        Tuple<int, int> actual = Kata.MineLocation(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
