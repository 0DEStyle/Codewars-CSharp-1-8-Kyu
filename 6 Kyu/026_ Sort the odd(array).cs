
/*Challenge link:
Question:
Task
You will be given an array of numbers. You have to sort the odd numbers in ascending order while leaving the even numbers at their original positions.

Examples
[7, 1]  =>  [1, 7]
[5, 8, 6, 3, 4]  =>  [3, 8, 6, 5, 4]
[9, 8, 7, 6, 5, 4, 3, 2, 1, 0]  =>  [1, 8, 3, 6, 5, 4, 7, 2, 9, 0]
*/

//***************Solution********************
//select tbe odd number, and sort it in order.
//shift the odd number position in array using using while loop
//return the result
using System.Linq;

public class Kata
{
    public static int[] SortArray(int[] array){
        var sortedOddNumbers = array.Where(x => x % 2 == 1).OrderBy(x => x);
        int i = 0;
        foreach (int oddNumber in sortedOddNumbers){            
            while(array[i] % 2 == 0)
                i++;
            array[i] = oddNumber;
            i++;
        }
        return array;
    }
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
      Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4 }));
      Assert.AreEqual(new int[] { 1, 3, 5, 8, 0 }, Kata.SortArray(new int[] { 5, 3, 1, 8, 0 }));
      Assert.AreEqual(new int[] { }, Kata.SortArray(new int[] { }));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual(new int[] { 1, 3, 2, 8, 5, 4, 11 }, Kata.SortArray(new int[] { 5, 3, 2, 8, 1, 4, 11 }));
      Assert.AreEqual(new int[] { 2, 22, 1, 5, 4, 11, 37, 0 }, Kata.SortArray(new int[] { 2, 22, 37, 11, 4, 1, 5, 0 }));
      Assert.AreEqual(new int[] { 1, 1, 5, 11, 2, 11, 111, 0 }, Kata.SortArray(new int[] { 1, 111, 11, 11, 2, 1, 5, 0 }));
      Assert.AreEqual(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }, Kata.SortArray(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
      Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, Kata.SortArray(new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
      Assert.AreEqual(new int[] { 0, 1, 2, 3, 4, 5, 8, 7, 6, 9 }, Kata.SortArray(new int[] { 0, 1, 2, 3, 4, 9, 8, 7, 6, 5 }));           
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int[],int[]> mySortArray = delegate (int[] array)
      {
        var odd = array.Where(elem => elem % 2 != 0).OrderBy(a => a).ToArray();
        var i = 0;
        return array.Select(elem => elem % 2 == 0 ? elem : odd[i++]).ToArray();        
      };
      
      for(int r=0;r<10;r++)
      {
        var firstArray = Enumerable.Range(0, rand.Next(0,10)).Select(a => rand.Next(0,100)).ToArray();
        var secondArray = Enumerable.Range(0, rand.Next(0,20)).Select(a => rand.Next(0,100)).ToArray();
        var thirdArray = Enumerable.Range(0, rand.Next(0,30)).Select(a => rand.Next(0,100)).ToArray();
        
        Assert.AreEqual(string.Join(",", mySortArray(firstArray.ToArray())), string.Join(",", Kata.SortArray(firstArray.ToArray())));
        Assert.AreEqual(string.Join(",", mySortArray(secondArray.ToArray())), string.Join(",", Kata.SortArray(secondArray.ToArray())));
        Assert.AreEqual(string.Join(",", mySortArray(thirdArray.ToArray())), string.Join(",", Kata.SortArray(thirdArray.ToArray())));
      }
    }
  }
}
