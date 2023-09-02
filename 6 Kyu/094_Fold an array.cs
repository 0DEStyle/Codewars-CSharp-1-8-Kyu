/*Challenge link:https://www.codewars.com/kata/57ea70aa5500adfe8a000110/train/csharp
Question:
In this kata you have to write a method that folds a given array of integers by the middle x-times.

An example says more than thousand words:

Fold 1-times:
[1,2,3,4,5] -> [6,6,3]

A little visualization (NOT for the algorithm but for the idea of folding):

 Step 1         Step 2        Step 3       Step 4       Step5
                     5/           5|         5\          
                    4/            4|          4\      
1 2 3 4 5      1 2 3/         1 2 3|       1 2 3\       6 6 3
----*----      ----*          ----*        ----*        ----*


Fold 2-times:
[1,2,3,4,5] -> [9,6]
As you see, if the count of numbers is odd, the middle number will stay. Otherwise the fold-point is between the middle-numbers, so all numbers would be added in a way.

The array will always contain numbers and will never be null. The parameter runs will always be a positive integer greater than 0 and says how many runs of folding your method has to do.

If an array with one element is folded, it stays as the same array.

The input array should not be modified!

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have created other katas. Have a look if you like coding and challenges.
*/

//***************Solution********************
using System.Linq;

public class Kata{
  public static int[] FoldArray(int[] array, int runs){
    
    //concat char array into int
    int[] arr = (new int[0]).Concat(array).ToArray();
    
    //nested loop, split into half, add 1st to last, 2md tp 2nd last etc.
    for (int i = 0; i < runs; i++){
      for (int j = 0; j < arr.Length / 2; j++)
        arr[j] += arr[arr.Length - 1 - j];
      arr = arr.Take((arr.Length + 1) / 2).ToArray();
    }
    return arr;
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class KataTests
{
  [Test]
  public void BasicTests()
  {
    var input = new int[] { 1, 2, 3, 4, 5 };
    var expected = new int[] { 6, 6, 3 };
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.FoldArray(input, 1)));
    
    expected = new int[] { 9, 6 };
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.FoldArray(input, 2)));
    
    expected = new int[] { 15 };
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.FoldArray(input, 3)));
    
    input = new int[] { -9, 9, -8, 8, 66, 23 };
    expected = new int[] { 14, 75, 0 };
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.FoldArray(input, 1)));
  }  
  
  [Test]
  public void ExtendedTests()
  {
    var input = new int[] { 1, 2, 3, 4, 5, 99, 88, 78, 74, 73 };    
    Assert.AreEqual(string.Join(",", new int[] { input.Sum() }), string.Join(",", Kata.FoldArray(input, 5)));

    input = new int[] { -1, -2, -3, -4, -5, -99, -88, -78, -74, -73 };    
    Assert.AreEqual(string.Join(",", new int[] { input.Sum() }), string.Join(",", Kata.FoldArray(input, 5)));

    input = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };    
    Assert.AreEqual(string.Join(",", new int[] { input.Sum() }), string.Join(",", Kata.FoldArray(input, 10)));

    input = new int[] { 2 };
    Assert.AreEqual(string.Join(",", input), string.Join(",", Kata.FoldArray(input, 1)));
    
    input = new int[] { 2 };
    Assert.AreEqual(string.Join(",", input), string.Join(",", Kata.FoldArray(input, 20)));
  }
  
  [Test]
  public void RandomTests()
  {
    var rand = new Random();
    
    Func<int[], int, int[]> myFoldArray = null;
    
    myFoldArray = delegate (int[] array, int runs)
    {
      var length = (int)Math.Ceiling(array.Length/2.0);
      var foldedArray = new int[length];
    
      for(int i=0;i<length;i++)
      {
        if(i != array.Length -1 - i)
        {
          foldedArray[i] = array[i] + array[array.Length -1 - i];
        }
        else      
        {
          foldedArray[i] = array[i];
        }
      }
    
      if(runs == 1)
      {
        return foldedArray;
      }
      return myFoldArray(foldedArray, runs - 1);
    };
    
    for(int r=0;r<40;r++)
    {
      var length = rand.Next(1,200);
      var runs = rand.Next(1,20);
      var input = Enumerable.Range(1,length).Select(i => rand.Next(-200, 201)).ToArray();
      
      Assert.AreEqual(string.Join(",", myFoldArray(input, runs)), string.Join(",", Kata.FoldArray(input, runs)));
    }
  }
}
