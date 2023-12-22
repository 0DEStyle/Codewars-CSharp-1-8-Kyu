/*Challenge link:https://www.codewars.com/kata/57f6ad55cca6e045d2000627/train/csharp
Question:
Write a method, that will get an integer array as parameter and will process every number from this array.

Return a new array with processing every number of the input-array like this:

If the number has an integer square root, take this, otherwise square the number.

Example
[4,3,9,7,2,1] -> [2,9,3,49,4,1]
Notes
The input array will always contain only positive numbers, and will never be empty or null.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System;
using static System.Math;

public class Kata{
  public static int[] SquareOrSquareRoot(int[] array) => 
    array.Select(x => Sqrt(x) % 1 != 0 ? Convert.ToInt32(x * x) : Convert.ToInt32(Sqrt(x))).ToArray();
}

//solution 2
using System;
using System.Linq;

public class Kata
{
  public static int[] SquareOrSquareRoot(int[] array)
  {
    return array.Select(x => (int)(Math.Sqrt(x) % 1 == 0 ? Math.Sqrt(x) : x * x)).ToArray();
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
    var input = new int[] { 4, 3, 9, 7, 2, 1 };
    var expected = new int[] { 2, 9, 3, 49, 4, 1 };
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.SquareOrSquareRoot(input)));  

    input = new int[] { 100, 101, 5, 5, 1, 1 };
    expected = new int[] { 10, 10201, 25, 25, 1, 1};
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.SquareOrSquareRoot(input)));  
    
    input = new int[] { 1, 2, 3, 4, 5, 6 };
    expected = new int[] { 1, 4, 9, 2, 25, 36};
    Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.SquareOrSquareRoot(input)));  
  }  
  
  [Test]
  public void RandomTests()
  {
    var rand = new Random();
    
    Func<int[],int[]> mySquareOrSquareRoot = delegate (int[] array)
    {
      return array.Select(a => 
      {
        var sqrt = Math.Sqrt(a);
        if(sqrt == (int)sqrt)
        {
          return (int)sqrt;
        }
        return a * a;
      }).ToArray();
    };
  
    for(int r=0;r<30;r++)
    {
      var array = Enumerable.Range(0, rand.Next(3,20)).Select(a => rand.Next(1,101)).ToArray();
      var expected = mySquareOrSquareRoot(array);
      
      Assert.AreEqual(string.Join(",", expected), string.Join(",", Kata.SquareOrSquareRoot(array)));  
    }
  }
