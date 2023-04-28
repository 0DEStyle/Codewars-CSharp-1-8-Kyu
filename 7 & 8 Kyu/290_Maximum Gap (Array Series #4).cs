/*Challenge link:https://www.codewars.com/kata/5a7893ef0025e9eb50000013/train/csharp
Question:
Introduction and Warm-up (Highly recommended)
Playing With Lists/Arrays Series
Task
Given an array/list [] of integers , Find The maximum difference between the successive elements in its sorted form.

Notes
Array/list size is at least 3 .

Array/list's numbers Will be mixture of positives and negatives also zeros_

Repetition of numbers in the array/list could occur.

The Maximum Gap is computed Regardless the sign.

Input >> Output Examples
maxGap ({13,10,5,2,9}) ==> return (4)
Explanation:
The Maximum Gap after sorting the array is 4 , The difference between 9 - 5 = 4 .
maxGap ({-3,-27,-4,-2}) ==> return (23)
Explanation:
The Maximum Gap after sorting the array is 23 , The difference between  |-4- (-27) | = 23 .

Note : Regardless the sign of negativity .

maxGap ({-7,-42,-809,-14,-12}) ==> return (767)  
Explanation:
The Maximum Gap after sorting the array is 767 , The difference between  | -809- (-42) | = 767 .

Note : Regardless the sign of negativity .

maxGap ({-54,37,0,64,640,0,-15}) //return (576)
Explanation:
The Maximum Gap after sorting the array is 576 , The difference between  | 64 - 640 | = 576 .

Note : Regardless the sign of negativity .


*/

//***************Solution********************

//sort array by descending (to avoid using Math.Abs for negative result)
//check if current difference is greater than max
//if so replace the max with current difference
//iterate to the next set
//once completed, return the max result.

using System;
using System.Linq;
public static class Kata{
  public static int MaxGap(int[] numbers){
    numbers = numbers.OrderByDescending(c => c).ToArray();
    int max = 0;
    
    for(int i = 0; i < numbers.Length-1;i++){
      if(numbers[i] - numbers[i+1] > max)
        max = numbers[i] - numbers[i+1];
    }
    return max;
  }
}

//oneline method
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

public static class Kata
{
  public static int MaxGap(int[] numbers)
  {
    return numbers
      .OrderBy(i => i)
      .Skip(1)
      .Zip(numbers.OrderBy(i => i), (a, b) => Math.Abs(b - a))
      .Max();
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;  

[TestFixture]
public class TestFixture
{
  [Test, Description("Basic Tests")]   
  [TestCase(new int[] { 13, 10, 2, 9, 5 }, ExpectedResult=4)]
  [TestCase(new int[] { 13, 3, 5 }, ExpectedResult=8)]
  [TestCase(new int[] { 24, 299, 131, 14, 26, 25 }, ExpectedResult=168)]
  [TestCase(new int[] { -3, -27, -4, -2 }, ExpectedResult=23)]
  [TestCase(new int[] { -7, -42, -809, -14, -12 }, ExpectedResult=767)]
  [TestCase(new int[] { 12, -5, -7, 0, 290 }, ExpectedResult=278)]
  [TestCase(new int[] { -54, 37, 0, 64, -15, 640, 0 }, ExpectedResult=576)]
  [TestCase(new int[] { 130, 30, 50 }, ExpectedResult=80)]
  [TestCase(new int[] { 1, 1, 1 }, ExpectedResult=0)]
  [TestCase(new int[] { -1, -1, -1 }, ExpectedResult=0)]  
  public int BasicTests(int[] numbers)
  {
    return Kata.MaxGap(numbers);
  }
  
  [Test, Description("Random Tests")]
  public void RandomTests()
  {
    var RNG = new Random();    
    for (var i = 0; i < 100; i++)
    {      
      var length = RNG.Next(3, 35);
      var input = new int[length];
      for (var j = 0; j < length; j++)
      {
        input[j] = RNG.Next(-10000, 10000);
      }
      var actual = Kata.MaxGap(input);
      var expected = Solution(input);
      Assert.AreEqual(actual, expected);
    }
  }
  
  private static int Solution(int[] numbers)
  {
    Array.Sort(numbers);
    var diff = 0;
    for (int i = 1; i < numbers.GetLength(0); i++)
    {
      diff = Math.Max(diff, numbers[i] - numbers[i - 1]);
    }
    return diff;  
  }
}
