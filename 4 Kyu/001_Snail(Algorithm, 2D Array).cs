/*Challenge link:https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp
Question:
Snail Sort
Given an n x n array, return the array elements arranged from outermost elements to the middle element, traveling clockwise.

array = [[1,2,3],
         [4,5,6],
         [7,8,9]]
snail(array) #=> [1,2,3,6,9,8,7,4,5]
For better understanding, please follow the numbers of the next array consecutively:

array = [[1,2,3],
         [8,9,4],
         [7,6,5]]
snail(array) #=> [1,2,3,4,5,6,7,8,9]
This image will illustrate things more clearly:
//see image at https://www.codewars.com/kata/521c2db8ddc89b9b7a0000c1/train/csharp

NOTE: The idea is not sort the elements from the lowest value to the highest; the idea is to traverse the 2-d array in a clockwise snailshell pattern.

NOTE 2: The 0x0 (empty matrix) is represented as en empty array inside an array [[]].
*/

//***************Solution********************
//add elements to list as the snail move at direction right > down > left > up, 
//each time the snail finished a round, reduce row and col by 1, and increase row start and col start by 1
//repeat until the list reaches max size, which is row * col.
//convert the list to array, and return the result.

using System;
using System.Collections.Generic;

public class SnailSolution
{
   public static int[] Snail(int[][] array)
   {
     List<int> temp = new List<int>();
     
     int row = array.GetLength(0), col = array[0].Length, rowStart = 0, colStart = 1,tempSize = row * col;
     if(col == 0 || row == 0) return temp.ToArray(); //check if empty
     
     while (temp.Count < tempSize){  //ending condition
    for (int i = rowStart; i < col; i++) //right
      temp.Add(array[rowStart][i]);
       
    for (int i = colStart; i < row; i++)//down
      temp.Add(array[i][col - 1]);
       
    for (int i = col - 1; i > rowStart; i--)//left
      temp.Add(array[row - 1][i - 1]);
       
    for (int i = row - 1; i > colStart; i--)//up
      temp.Add(array[i - 1][rowStart]);
       
    rowStart++; colStart++;col--;row--; //update result for next rotation
     }
     
     return temp.ToArray();
   }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
public class SnailTest
{

    private int[] Tsnail(int[][] array)
    {
        int[] sorted = new int[array.Length * array.Length];
        Tsnail(array, -1, 0, 1, 0, array.Length, 0, sorted);
        return sorted;
    }

    private void Tsnail(int[][] array, int x, int y, int dx, int dy, int l, int i, int[] sorted)
    {
        if (l == 0)
            return;
        for (int j = 0; j < l; j++)
        {
            x += dx;
            y += dy;
            sorted[i++] = array[y][x];
        }
        Tsnail(array, x, y, -dy, dx, dy == 0 ? l - 1 : l, i, sorted);

    }

    public string Int2dToString(int[][] a)
    {
        return $"[{string.Join("\n", a.Select(row => $"[{string.Join(",", row)}]"))}]";
    }

    public void Test(int[][] array, int[] result)
    {
        var text = $"{Int2dToString(array)}\nshould be sorted to\n[{string.Join(",", result)}]\n";
        Console.WriteLine(text);
        Assert.AreEqual(result, SnailSolution.Snail(array));
    }

    [Test]
    public void SnailTest1()
    {
        int[][] array =
        {
            new []{1, 2, 3},
            new []{4, 5, 6},
            new []{7, 8, 9}
        };
        var r = new[] { 1, 2, 3, 6, 9, 8, 7, 4, 5 };
        Test(array, r);
    }

    [Test]
    public void SnailTest2()
    {
        int[][] array =
        {
            new []{1, 2, 3, 9},
            new []{4, 5, 6, 4},
            new []{7, 8, 9, 1},
            new []{1, 2, 3, 4}
        };
        var r = new[] { 1, 2, 3, 9, 4, 1, 4, 3, 2, 1, 7, 4, 5, 6, 9, 8 };
        Test(array, r);
    }

    [Test]
    public void SnailTest2Empty()
    {
        int[][] a = { new int[] { } };
        Test(a, new int[0]);
    }

    [Test]
    public void SnailTestOne()
    {
        int[][] a = { new[] { 1 } };
        Test(a, new[] { 1 });
    }


    [Test]
    public void SnailRandomTest()
    {
        Console.WriteLine("Random Tests");
        Random rand = new Random();
        for (int n = 0; n < 100; n++)
        {
            var l = rand.Next(1, 31);
            var array = new int[l][];
            for (int i = 0; i < l; i++)
            {
                array[i] = new int[l];
                for (int j = 0; j < l; j++)
                    array[i][j] = rand.Next(1, 1001);
            }
            Test(array, Tsnail(array));
        }
    }
}
