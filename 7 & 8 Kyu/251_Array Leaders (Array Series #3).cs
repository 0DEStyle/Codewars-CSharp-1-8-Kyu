/*Challenge link:https://www.codewars.com/kata/5a651865fd56cb55760000e0/train/csharp
Question:
Definition
An element is leader if it is greater than The Sum all the elements to its right side.

Task
Given an array/list [] of integers , Find all the LEADERS in the array.

Notes
Array/list size is at least 3 .

Array/list's numbers Will be mixture of positives , negatives and zeros

Repetition of numbers in the array/list could occur.

Returned Array/list should store the leading numbers in the same order in the original array/list .

Input >> Output Examples
arrayLeaders ({1, 2, 3, 4, 0}) ==> return {4}
Explanation:
4 is greater than the sum all the elements to its right side

Note : The last element 0 is equal to right sum of its elements (abstract zero).

arrayLeaders ({16, 17, 4, 3, 5, 2}) ==> return {17, 5, 2}
Explanation:
17 is greater than the sum all the elements to its right side

5 is greater than the sum all the elements to its right side

Note : The last element 2 is greater than the sum of its right elements (abstract zero).

arrayLeaders ({5, 2, -1}) ==> return {5, 2}
Explanation:
5 is greater than the sum all the elements to its right side

2 is greater than the sum all the elements to its right side

Note : The last element -1 is less than the sum of its right elements (abstract zero).

arrayLeaders ({0, -1, -29, 3, 2}) ==> return {0, -1, 3, 2}
Explanation:
0 is greater than the sum all the elements to its right side

-1 is greater than the sum all the elements to its right side

3 is greater than the sum all the elements to its right side

Note : The last element 2 is greater than the sum of its right elements (abstract zero).
*/

//***************Solution********************
//check if current element is greater than the sum of the "rigth-side" of the current element
//if so, add to array, and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
  public static int[] ArrayLeaders(int[] numbers) =>
    numbers.Where((current,next) => current > numbers.Skip(next + 1).Sum()).ToArray();
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;  

[TestFixture]
public class TestFixture
{
  [Test, Description("Positive Values")]   
  [TestCase(new int[] { 1, 2, 3, 4, 0 }, ExpectedResult=new int[] { 4 })]
  [TestCase(new int[] { 16, 17, 4, 3, 5, 2 }, ExpectedResult=new int[] { 17, 5, 2 })]
  public int[] PositiveTests(int[] numbers)
  {
    return Kata.ArrayLeaders(numbers);
  }
  
  [Test, Description("Negative Values")]   
  [TestCase(new int[] { -1, -29, -26, -2 }, ExpectedResult=new int[] { -1 })]
  [TestCase(new int[] { -36, -12, -27 }, ExpectedResult=new int[] { -36, -12 })]
  public int[] NegativeTests(int[] numbers)
  {
    return Kata.ArrayLeaders(numbers);
  }
  
  [Test, Description("Mixed Values")]   
  [TestCase(new int[] { 5, -2, 2 }, ExpectedResult=new int[] { 5, 2 })]
  [TestCase(new int[] { 0, -1, -29, 3, 2 }, ExpectedResult=new int[] { 0, -1, 3, 2 })]
  public int[] MixedTests(int[] numbers)
  {
    return Kata.ArrayLeaders(numbers);
  }
  
  [Test, Description("Random Values")]   
  public void RandomTests()
  {
    var RNG = new Random();
    for (var i = 0; i < 100; i++)
    {      
      var length = RNG.Next(10, 200);
      var input = new int[length];
      for (var j = 0; j < length; j++)
      {
        input[j] = RNG.Next(-1000, 1000);
      }
      var expected = Solution(input);
      var actual = Kata.ArrayLeaders(input);      
      Assert.AreEqual(expected, actual);
    }
  }
  
  public static int[] Solution(int[] numbers)
  {
    var answers = new List<int>();
    var sum = 0;
    numbers = (int[])numbers.Clone();
    Array.Reverse(numbers);
    foreach (var number in numbers)
    {
      if (number > sum)
      {
        answers.Insert(0, number);
      }
      sum += number;
    }
    return answers.ToArray();
  }  
}
