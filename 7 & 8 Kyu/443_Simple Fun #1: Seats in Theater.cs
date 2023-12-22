/*Challenge link:https://www.codewars.com/kata/588417e576933b0ec9000045/train/csharp
Question:
Task
Your friend advised you to see a new performance in the most popular theater in the city. He knows a lot about art and his advice is usually good, but not this time: the performance turned out to be awfully dull. It's so bad you want to sneak out, which is quite simple, especially since the exit is located right behind your row to the left. All you need to do is climb over your seat and make your way to the exit.

The main problem is your shyness: you're afraid that you'll end up blocking the view (even if only for a couple of seconds) of all the people who sit behind you and in your column or the columns to your left. To gain some courage, you decide to calculate the number of such people and see if you can possibly make it to the exit without disturbing too many people.

Given the total number of rows and columns in the theater (nRows and nCols, respectively), and the row and column you're sitting in, return the number of people who sit strictly behind you and in your column or to the left, assuming all seats are occupied.

Example
For nCols = 16, nRows = 11, col = 5 and row = 3, the output should be 96.

Here is what the theater looks like:

//see image in link

Input/Output
[input] integer nCols

An integer, the number of theater's columns.

Constraints: 1 ≤ nCols ≤ 1000.

[input] integer nRows

An integer, the number of theater's rows.

Constraints: 1 ≤ nRows ≤ 1000.

[input] integer col

An integer, the column number of your own seat (with the rightmost column having index 1).

Constraints: 1 ≤ col ≤ nCols.

[input] integer row

An integer, the row number of your own seat (with the front row having index 1).

Constraints: 1 ≤ row ≤ nRows.

[output] an integer
The number of people who sit strictly behind you and in your column or to the left.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression

//find the differences between big area's width and height, then use the result to find smaller area.
public class Kata{
  public static int SeatsInTheater(int nCols, int nRows, int col, int row) =>
    (nCols - col + 1) * (nRows - row);
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  
  using System;

  [TestFixture]
  public class Tests
  {
    [Test]
    public void ExampleTests()
    {
      Assert.AreEqual(96, Kata.SeatsInTheater(16, 11, 5, 3));

      Assert.AreEqual(0, Kata.SeatsInTheater(1, 1, 1, 1));
      
      Assert.AreEqual(18, Kata.SeatsInTheater(13, 6, 8, 3));
      
      Assert.AreEqual(99, Kata.SeatsInTheater(60,100,60,1));
      
      Assert.AreEqual(0, Kata.SeatsInTheater(1000,1000,1000,1000));
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      
      Func<int, int, int, int, int> solution = (nCols, nRows, col, row) =>
      {
        return (nCols - col + 1) * (nRows - row);
      };
      
      for(int i = 0; i < 100; i++)
      {
        int nCols = rand.Next(1, 1000);
        int nRows = rand.Next(1, 1000);
        int col = rand.Next(1, nCols + 1);
        int row = rand.Next(1, nRows + 1);
        
        int expected = solution(nCols, nRows, col, row);
        
        int actual = Kata.SeatsInTheater(nCols, nRows, col, row);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
