/*Challenge link:https://www.codewars.com/kata/5f70c883e10f9e0001c89673/train/csharp
Question:
If you've completed this kata already and want a bigger challenge, here's the 3D version

Bob is bored during his physics lessons so he's built himself a toy box to help pass the time. The box is special because it has the ability to change gravity.

There are some columns of toy cubes in the box arranged in a line. The i-th column contains a_i cubes. At first, the gravity in the box is pulling the cubes downwards. When Bob switches the gravity, it begins to pull all the cubes to a certain side of the box, d, which can be either 'L' or 'R' (left or right). Below is an example of what a box of cubes might look like before and after switching gravity.

+---+                                       +---+
|   |                                       |   |
+---+                                       +---+
+---++---+     +---+              +---++---++---+
|   ||   |     |   |   -->        |   ||   ||   |
+---++---+     +---+              +---++---++---+
+---++---++---++---+         +---++---++---++---+
|   ||   ||   ||   |         |   ||   ||   ||   |
+---++---++---++---+         +---++---++---++---+
Given the initial configuration of the cubes in the box, find out how many cubes are in each of the n columns after Bob switches the gravity.

Examples (input -> output:
* 'R', [3, 2, 1, 2]      ->  [1, 2, 2, 3]
* 'L', [1, 4, 5, 3, 5 ]  ->  [5, 5, 4, 3, 1]
*/

//***************Solution********************
//if direction is right, use OrderBy to sort the array in ascending order,
//else use OrderByDescending to sort the array in descending order,
//convert back to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
    public static int[] Flip(char dir, int[] arr) => dir == 'R' ? arr.OrderBy(x=>x).ToArray() : arr.OrderByDescending(x=>x).ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static int[] Flip(char dir, int[] arr)
    {
      return dir == 'R' ?
             arr.OrderBy(i => i).ToArray() :
             arr.OrderByDescending(i => i).ToArray();
    }
    
    private static char GetRandomDir()
    {
      Random r = new Random();
      return r.Next(2) == 0 ? 'R' : 'L';
    }
    
    private static int[] GetRandomArr()
    {
      Random r = new Random();
      int size = r.Next(50);
      int[] arr = new int[size];
      
      for (int i = 0; i < size; i++)
      {
        arr[i] = r.Next(50);
      }
      return arr;
    }
    
    [Test]
    public void Fixed()
    {
      Assert.AreEqual(new int[]{ 1, 4, 5, 6, 7 }, Kata.Flip('R', new int[]{ 4, 5, 6, 7, 1 }));
      Assert.AreEqual(new int[]{ 9, 8, 3, 2, 1, 0 }, Kata.Flip('L', new int[]{ 3, 0, 9, 8, 1, 2 }));
      Assert.AreEqual(new int[]{ 12, 1, 0, 0, 0 }, Kata.Flip('L', new int[]{ 0, 0, 12, 0, 1 }));
      Assert.AreEqual(new int[]{ 2, 4, 7, 13, 93 }, Kata.Flip('R', new int[]{ 13, 2, 4, 7, 93 }));
      Assert.AreEqual(new int[]{ 1, 2, 3, 4, 5 }, Kata.Flip('R', new int[]{ 5, 4, 3, 2, 1 }));
    }
    
    [Test]
    public void Random()
    {
      for (int i = 0; i < 100; i++)
      {
        char dir = GetRandomDir();
        int[] arr = GetRandomArr();
        Assert.AreEqual(Flip(dir, arr), Kata.Flip(dir, arr));
      }
    }
  }
}
