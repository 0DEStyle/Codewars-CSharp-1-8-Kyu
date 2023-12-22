/*Challenge link:https://www.codewars.com/kata/5a2be17aee1aaefe2a000151/train/csharp
Question:
I'm new to coding and now I want to get the sum of two arrays... Actually the sum of all their elements. I'll appreciate for your help.

P.S. Each array includes only integer numbers. Output is a number too.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//sum of arr1 + sum of arr2
using System.Linq;

public static class Kata{
  public static int ArrayPlusArray(int[] arr1, int[] arr2) => arr1.Sum() + arr2.Sum();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  

  [TestFixture]
  public class SolutionTest
  {
    private int check(int[] arr1,int[] arr2)
    {
      return arr1.Sum()+arr2.Sum();
    }
      
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual(21, Kata.ArrayPlusArray(new int[]{1,2,3}, new int[]{4,5,6}));
      Assert.AreEqual(-21, Kata.ArrayPlusArray(new int[]{-1,-2,-3}, new int[]{-4,-5,-6}));
      Assert.AreEqual(15, Kata.ArrayPlusArray(new int[]{0,0,0}, new int[]{4,5,6}));
      Assert.AreEqual(2100, Kata.ArrayPlusArray(new int[]{100,200,300}, new int[]{400,500,600}));
      
    }
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
            
      for (int i = 0; i < 100; ++i)
      {
        int[] xs = new int[rnd.Next(2, 21)].Select(_ => rnd.Next(-100, 100)).ToArray();
        int[] ss = new int[rnd.Next(2, 21)].Select(_ => rnd.Next(-100, 100)).ToArray();
        Console.WriteLine("test №"+(i+1)); 
        Console.WriteLine(string.Join(" ",xs)); 
        Console.WriteLine(string.Join(" ",ss)); 
        Assert.That(Kata.ArrayPlusArray(xs,ss), Is.EqualTo(check(xs,ss)));
      }
      }
  }
  }
