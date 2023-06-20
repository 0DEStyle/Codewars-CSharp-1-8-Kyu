/*Challenge link:https://www.codewars.com/kata/559cc2d2b802a5c94700000c/train/csharp
Question:
Create the function consecutive(arr) that takes an array of integers and return the minimum number of integers needed to make the contents of arr consecutive from the lowest number to the highest number.

For example:
If arr contains [4, 8, 6] then the output should be 2 because two numbers need to be added to the array (5 and 7) to make it a consecutive array of numbers from 4 to 8. Numbers in arr will be unique.
*/

//***************Solution********************

//check if array is not empty
//if true, max - min to find the difference, then subtract by array length + 1 to find
//the number of consecutive numbers needed.
//else return 0
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static int Consecutive(int[] arr) => arr.Any() ? arr.Max() - arr.Min() - arr.Length + 1 : 0;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(2, Kata.Consecutive(new int[] { 4, 8, 6 }));
      Assert.AreEqual(0, Kata.Consecutive(new int[] { 1, 2, 3, 4 }));
      Assert.AreEqual(0, Kata.Consecutive(new int[] { }));
      Assert.AreEqual(0, Kata.Consecutive(new int[] { 1 }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int[],int> myConsecutive = delegate (int[] arr)
      {
        if(arr.Length < 2)
        {
          return 0;
        }   
  
        return arr.Max() - arr.Min() - arr.Length + 1;
      };
      
      for(int r=0;r<100;r++)
      {
        List<int> arrList = new List<int>();
        for(int i=0;i<100;i++)
        {
          var rnd = rand.Next(i-50, 1000);
          if(!arrList.Contains(rnd))
          {
            arrList.Add(rnd);
          }
        }
        Assert.AreEqual(myConsecutive(arrList.ToArray()), Kata.Consecutive(arrList.ToArray()));
      }
    }
  }
}
