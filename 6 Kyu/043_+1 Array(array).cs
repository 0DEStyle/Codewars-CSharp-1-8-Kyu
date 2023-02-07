/*Challenge link:https://www.codewars.com/kata/5514e5b77e6b2f38e0000ca9/train/csharp
Question:
Given an array of integers of any length, return an array that has 1 added to the value represented by the array.

the array can't be empty
only non-negative, single digit integers are allowed
Return nil (or your language's equivalent) for invalid inputs.

Examples
Valid arrays

[4, 3, 2, 5] would return [4, 3, 2, 6]
[1, 2, 3, 9] would return [1, 2, 4, 0]
[9, 9, 9, 9] would return [1, 0, 0, 0, 0]
[0, 1, 3, 7] would return [0, 1, 3, 8]

Invalid arrays

[1, -9] is invalid because -9 is not a non-negative integer

[1, 2, 33] is invalid because 33 is not a single-digit integer
*/

//***************Solution********************

using System;
using System.Linq;
using System.Numerics;

namespace Kata{
    public static class Kata{
        public static int[] UpArray(int[] num){
          //if array is empty or length is 0 or number is negative or number is double digits
            if (num == null || num.Length == 0 || num.Any(i => i < 0 || i > 9)) return null;
          //if num length is 1 or first element is '0', return 1
            if (num.Length == 1 && num[0] == '0') return new int[] { 1 };
          
          //TakeWhile stops when the condition is false, Where continues and find all elements matching the condition
            var leadingZeroes = num.TakeWhile(i => i == 0).Count();
          
          //add '0' by leadingzeroes amount of times, then convert num to string and add 1(bigInteger parse because big number)
          //then convert to string.
            var added = string.Concat(Enumerable.Repeat('0', leadingZeroes)) + (BigInteger.Parse(string.Concat(num)) + 1).ToString();
          //convert the characters in string added to int, return result as array;  
          return added.Select(c => (int)char.GetNumericValue(c)).ToArray();
        }
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Kata 
{  
  [TestFixture]
  public class ArrayTest
  {
    [Test]
    public void UpInvalid1()
    {
      var num = new int[] {1, 2, 33};      
      Assert.AreEqual(null, Kata.UpArray(num));
    }
    
    [Test]
    public void UpInvalid2()
    {
      var num = new int[] {1, 2, -1};      
      Assert.AreEqual(null, Kata.UpArray(num));
    }
    
    [Test]
    public void UpInvalid3()
    {
      var num = new int[] {};      
      Assert.AreEqual(null, Kata.UpArray(num));
    }
    
    [Test]
    public void Up074()
    {
      var num = new int[] {0, 7, 4};
      var newNum = new int[] {0, 7, 5};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    }
    
    
     [Test]
    public void Up574()
    {
      var num = new int[] {5, 7, 4};
      var newNum = new int[] {5, 7, 5};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    }
    
    [Test]
    public void Up999()
    {
      var num = new int[] {9, 9, 9};
      var newNum = new int[] {1, 0, 0, 0};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    }
    
    [Test]
    public void UpBigArray()
    {
      var num = new int[] {2, 1, 4, 7, 4, 8, 3, 6, 4, 7};
      var newNum = new int[] {2, 1, 4, 7, 4, 8, 3, 6, 4, 8};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    } 
    
    [Test]
    public void UpBiggerArray()
    {
      var num = new int[] {9,2,2,3,3,7,2,0,3,6,8,5,4,7,7,5,8,0,7};
      var newNum = new int[] {9,2,2,3,3,7,2,0,3,6,8,5,4,7,7,5,8,0,8};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    }    
    
    [Test]
    public void UpBiggestArray()
    {
      var num = new int[] {9,2,2,3,3,7,2,0,3,6,8,5,4,7,7,5,8,0,7,5,3,2,6,7,8,4,2,4,2,6,7,8,7,4,5,2,1};
      var newNum = new int[] {9,2,2,3,3,7,2,0,3,6,8,5,4,7,7,5,8,0,7,5,3,2,6,7,8,4,2,4,2,6,7,8,7,4,5,2,2};
      Assert.AreEqual(newNum, Kata.UpArray(num));
    } 
    
    [Test]
    public void UpRandomArray()
    {
      var random = new Random();
      for (var i = 0; i < 10000; i++)
      {
          var length = random.Next(1, 1000);
          var arr = new int[length];
          for (int j = 0; j < length; j++)
              arr[j] = random.Next(-5, 15);
          Assert.AreEqual(UpArray(arr), Kata.UpArray(arr));
      }
    } 
    
    private int[] UpArray(int[] num)
    {
        if (num == null || num.Length == 0) return null;
        if (!num.All(x => x >= 0 && x <= 9)) return null;
        var list = new List<int>(num);
        list[list.Count - 1]++;
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == 10)
            {
                list[i] -= 10;
                if (i == 0) list.Insert(0, 1);
                else list[i - 1]++;
            }
        }
        return list.ToArray();
    }
  }
}
