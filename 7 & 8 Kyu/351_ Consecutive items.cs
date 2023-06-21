/*Challenge link:https://www.codewars.com/kata/5f6d533e1475f30001e47514/train/csharp
Question:
You are given a list of unique integers arr, and two integers a and b. Your task is to find out whether or not a and b appear consecutively in arr, and return a boolean value (True if a and b are consecutive, False otherwise).

It is guaranteed that a and b are both present in arr.
*/

//***************Solution********************
//compare the index of both numbers using its absolute value, if answer is 1 then it is consecutive items.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

namespace Solution{
  public static class Kata{
    public static bool Consecutive(int[] arr, int a, int b) => Math.Abs(Array.IndexOf(arr, a) - Array.IndexOf(arr, b)) == 1;
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
// TODO: Replace examples and use TDD by writing your own tests


namespace Solution 
{
  [TestFixture]
  public class SolutionTest
  {
    public bool Solution(int[] arr, int a, int b)
    {
      return Math.Abs(Array.IndexOf(arr, a) - Array.IndexOf(arr, b)) == 1;
    }
    
    [Test]
    public void MyTest()
    {
      Assert.AreEqual(false, Kata.Consecutive(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 8));
      Assert.AreEqual(true, Kata.Consecutive(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9}, 2, 3));
      Assert.AreEqual(true, Kata.Consecutive(new int[]{1, 4, 5, 3, 2, 7, 6, 23, 76, 11, 0}, 2, 3));
      Assert.AreEqual(false, Kata.Consecutive(new int[]{1, -4, -5, 3, -2, 11, 23, -76, 6, -7, 2}, 2, 3));
      Assert.AreEqual(false, Kata.Consecutive(new int[]{1, 2, 3, 4, 5}, 1, 5));
      Assert.AreEqual(false, Kata.Consecutive(new int[]{1, 2, 3, 4, 5}, 5, 1));
    }
    
    [Test]
    public void TargetedTest()
    {
      Random rnd = new Random();
      for (int i = 1; i < 7; i++)
      {
        int a = rnd.Next(-1000000, 1000001);
        int b = rnd.Next(-1000000, 1000001);
        while (b == a)
        {
          b = rnd.Next(-1000000, 1000001);
        }
        int arrLen = rnd.Next(2, 251);
        int[] c = new int[arrLen + 2];
        for (int j = 1; j < (arrLen - 1); j++)
        {
          int num = rnd.Next(-1000000, 1000001);
          while (num == a || num == b)
          {
            num = rnd.Next(-1000000, 1000001);
          }
          c[j] = num;
        }
        c[0] = a;
        c[c.Length - 1] = b;
        Assert.AreEqual(Solution(c,a,b), Kata.Consecutive(c,a,b));
      }
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      for (int i = 1; i < 501; i++)
      {
        int range = rnd.Next(3,251);
        int num;
        List<int> arr = new List<int>();
        for (int j = 0; j < range; j++) 
        {
          num = rnd.Next(-1000000, 1000001);
          if (!arr.Contains(num)) 
          {
            arr.Add(num);
          }
        }
        int b;
        int a = rnd.Next(0, arr.Count);
        int answer = rnd.Next(0,2);
        if (answer == 1) 
        {
          int infront = rnd.Next(0,2);
          if (infront == 1) 
          {
            if (a != 0) 
            {
              b = arr[a - 1];
            }
            else 
            {
              b = arr[0];
              a = 1;
            }
          }
          else 
          {
            if (a != arr.Count - 1) 
            {
              b = arr[a + 1];
            }
            else 
            {
              b = arr[arr.Count - 1];
              a = arr.Count - 2;
            }
          }
        }
        else
        {
          int fOrS = rnd.Next(0,2);
          if (a <= 2 || a >= arr.Count - 2) 
          {
            if (fOrS == 1) 
            {
              if (a <= 2) b = arr[2];
              else {
                a = arr.Count-3;
                b = arr[arr.Count-1];
              }
            }
            else 
            {
              if (a >= arr.Count-2) b = arr[arr.Count - 3];
              else {
                a = 2;
                b = arr[0];
              }
            }
          }
          else 
          {
            if (fOrS == 1) 
            {
              b = arr[rnd.Next(0, a)];
            }
            else 
            {
              b = arr[rnd.Next(a + 1, arr.Count)];
            }
          }
        }
        Assert.AreEqual(Solution(arr.ToArray(), arr[a], b), Kata.Consecutive(arr.ToArray(), arr[a], b));
      }
    }
  }
}
