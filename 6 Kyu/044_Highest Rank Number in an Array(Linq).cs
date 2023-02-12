/*Challenge link:https://www.codewars.com/kata/5420fc9bb5b2c7fd57000004/train/csharp
Question:
Complete the method which returns the number which is most frequent in the given input array. If there is a tie for most frequent number, return the largest number among them.

Note: no empty arrays will be given.

Examples
[12, 10, 8, 12, 7, 6, 4, 10, 12]              -->  12
[12, 10, 8, 12, 7, 6, 4, 10, 12, 10]          -->  12
[12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10]  -->   3

*/

//***************Solution********************
//group each number in the array
//select the highest count number from the array by the element key
//return the key.

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int HighestRank(int[] arr) => 
    arr.GroupBy(i => i)
    .Max(x => (x.Count(), x.Key))
    .Key;
}

//****************Sample Test*****************

namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTest()
    {
      var arr = new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12 };
      Assert.AreEqual(12, Kata.HighestRank(arr));
      
      arr = new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 10 };
      Assert.AreEqual(10, Kata.HighestRank(arr));
      
      arr = new int[] { 12, 10, 8, 12, 7, 6, 4, 10, 12, 10 };
      Assert.AreEqual(12, Kata.HighestRank(arr));

      arr = new int[] { 10, 12, 8, 12, 7, 6, 4, 10, 12, 10 };
      Assert.AreEqual(12, Kata.HighestRank(arr));

      arr = new int[] { 12, 10, 8, 8, 3, 3, 3, 3, 2, 4, 10, 12, 10 };
      Assert.AreEqual(3, Kata.HighestRank(arr));
    }
    
    [Test]
    public void RandomTest()
    {
      var rand = new Random();
      
      Func<int[], int> myHighestRank = delegate (int[] arr)
      {
        arr = arr.OrderBy(a => a).ToArray();
        var mxN = arr[0];
        var mxCount = 1;
        var lastNumber = arr[0];
        var actCount = 1;
  
        for(var i=1;i<arr.Length;i++)
        {  
          if(lastNumber == arr[i])
          {
            actCount++;
          }
          else
          {    
            if((actCount > mxCount) || (actCount == mxCount && mxN < lastNumber))
            {
              mxN = lastNumber;
              mxCount = actCount;        
            }
            lastNumber = arr[i];
            actCount = 1;
          }
        }

        if((actCount > mxCount) || (actCount == mxCount && mxN < lastNumber))
        {
          mxN = lastNumber;          
        }

        return mxN;
      };
      
      for(var r=0;r<40;r++)
      {
        var arr = Enumerable.Range(0, rand.Next(2,20)).Select(i => rand.Next(3,12)).ToArray();
        
        var expected = myHighestRank(arr);
        
        Assert.AreEqual(expected, Kata.HighestRank(arr), "Problem with " + string.Join(", ", arr));
      }    
    }
  }
}
