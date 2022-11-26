/*Challenge link:https://www.codewars.com/kata/5174a4c0f2769dd8b1000003/train/csharp
Question:
Finish the solution so that it sorts the passed in array of numbers. If the function passes in an empty array or null/nil value then it should return an empty array.

For example:

SortNumbers(new int[] { 1, 2, 10, 50, 5 }); // should return new int[] { 1, 2, 5, 10, 50 }
SortNumbers(null); // should return new int[] { }
*/

//***************Solution********************
//check if nums is null, if true return empty array, else sort the order and return the array
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int[] SortNumbers(int[] nums) => nums == null ? new int[] { } : nums.OrderBy(x=>x).ToArray();
}

//solution 2

using System.Linq;
public class Kata{
  public static int[] SortNumbers(int[] nums) => nums?.OrderBy(i=>i).ToArray() ?? new int[0];
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
    public void BasicTests()
    {
      checkNums(new int[] { 1,2,3,10,5 }, new int[] { 1,2,3,5,10 });
      checkNums(null, new int[] { });
      checkNums(new int[] { }, new int[] {  });
      checkNums(new int[] { 20, 2, 10 }, new int[] { 2, 10, 20 });
      checkNums(new int[] { 2, 20, 10 }, new int[] { 2, 10, 20 });
      checkNums(new int[] { 2, 10, 20 }, new int[] { 2, 10, 20 });
    }
  
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int[],int[]> mySortNumbers = delegate (int[] nums)
      {
        return nums == null ? new int[0] : nums.OrderBy(o => o).ToArray();
      };
      
      for(int i=0;i<30;i++)
      {
        var length = rand.Next(2,10);
        var nums = Enumerable.Range(0,length).Select(o => rand.Next(0, 20)).ToArray();
        checkNums(nums, mySortNumbers(nums));
      }
    }
  
    private void checkNums(int[] nums, int[] expected)
    {
      var actual = Kata.SortNumbers(nums);
    
      Assert.AreEqual(expected, actual, nums != null ? "{" + string.Join(",", nums) + "}" : "null");
    }
  }
}
