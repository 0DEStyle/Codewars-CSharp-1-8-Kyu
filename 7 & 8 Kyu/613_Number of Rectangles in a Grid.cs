/*Challenge link:https://www.codewars.com/kata/556cebcf7c58da564a000045/train/csharp
Question:
Given a grid of size m x n, calculate the total number of rectangles contained in this rectangle. All integer sizes and positions are counted.

Examples(Input1, Input2 --> Output):

3, 2 --> 18
4, 4 --> 100
Here is how the 3x2 grid works (Thanks to GiacomoSorbi for the idea):

1 rectangle of size 3x2:

[][][]
[][][]
2 rectangles of size 3x1:

[][][]
4 rectangles of size 2x1:

[][]
2 rectangles of size 2x2

[][]
[][]
3 rectangles of size 1x2:

[]
[]
6 rectangles of size 1x1:

[]
As you can see (1 + 2 + 4 + 2 + 3 + 6) = 18, and is the solution for the 3x2 grid.

There is a very simple solution to this!
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
//rearrange (m * (m + 1) * n * (n + 1))/4 
//it's the same thing but looks better
//apply formula
public class Grid {
  public static int NumberOfRectangles(int m, int n) => 
    (m * m + m) * (n * n + n) / 4;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class GridTests {
  private int Correct(int m, int n) {
    return (m * (m + 1) * n * (n + 1)) / 4;
  }

  [Test]
  public void BasicRandomTests() {
    Random random = new Random();

    for(int i = 0; i < 15; i++) {
      int m = random.Next(1, 100);
      int n = random.Next(1, 100);
      
      int expected = Correct(m, n);
      int actual = Grid.NumberOfRectangles(m, n);
      
      Assert.AreEqual(expected, actual);
    }
  }
}
