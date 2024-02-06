/*Challenge link:https://www.codewars.com/kata/563f879ecbb8fcab31000041/train/csharp
Question:
Write a function, factory, that takes a number as its parameter and returns another function.

The returned function should take an array of numbers as its parameter, and return an array of those numbers multiplied by the number that was passed into the first function.

In the example below, 5 is the number passed into the first function. So it returns a function that takes an array and multiplies all elements in it by five.

Translations and comments (and upvotes) welcome!

Example
Func<int[],int[]> fives = FunctionFactory.factory(5);    // returns a function - fives
int[] myArray = new int[]{1, 2, 3};
fives(myArray);                  //returns [5, 10, 15];
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//create arr, 
//x is current element, from arr, x time n,
//store in array and return the result.
using System.Linq;
using System;

public class FunctionFactory{
  public static Func<int[],int[]> factory(int n) => 
    arr => arr.Select(x => x * n).ToArray();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class FactoryTest
{
  private static Random rand = new Random();
  
  private static void testing(int[] expected, int[] actual)
  {
    Assert.AreEqual(expected, actual);
  }
  private static int[] RandomArr()
  {
    int[] arr = new int[rand.Next(100)];
    for(int i = 0; i < arr.Length; i++)
    {
      arr[i] = rand.Next(-1000,1000);
    }
    return arr;
  }
  private static int[] Ans(int[] arr ,int x)
  {
    int[] result = new int[arr.Length];
    for(int i = 0; i < arr.Length; i++)
    {
      result[i] = arr[i] * x;
    }
    return result;
  }
  private static void RandomTest()
  {
    int x = rand.Next(-100,1000);
    Func<int[],int[]> func = FunctionFactory.factory(x);
    for(int i = 0; i < 5; i++)
    {
      int[] arr = RandomArr();
      testing(func(arr),Ans(arr,x));
    }
  }
  [Test]
  public static void BasicTests()
  {
    testing(FunctionFactory.factory(3)(new int[]{1,2,3}),new int[]{3,6,9});
    testing(FunctionFactory.factory(5)(new int[]{1,2,3}),new int[]{5, 10, 15});
    testing(FunctionFactory.factory(6)(new int[]{10, 9, 8, 7}),new int[]{60, 54, 48, 42});
    testing(FunctionFactory.factory(2)(new int[]{14, 15, 16}),new int[]{28, 30, 32});
    testing(FunctionFactory.factory(1)(new int[]{847, 948, 34}),new int[]{847, 948, 34});
    testing(FunctionFactory.factory(93)(new int[]{37, 48, 13}),new int[]{3441, 4464, 1209});
  }
  [Test]
  public static void RandomTests()
  {
    for(int i = 0; i < 30; i++)
    {
      RandomTest();
    }
  }
}
