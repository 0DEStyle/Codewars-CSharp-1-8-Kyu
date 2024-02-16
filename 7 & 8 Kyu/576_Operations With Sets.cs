/*Challenge link:https://www.codewars.com/kata/5609fd5b44e602b2ff00003a/train/csharp
Question:
We need a function that receives two arrays, each of them with elements that occur only once. We need to know:

Number of elements that are present in both arrays
Number of elements that are present in only one array
Number of remaining elements in arr1 after extracting the elements of arr2
Number of remaining elements in arr2 after extracting the elements of arr1
Example
arr1 = [1, 2, 3, 4, 5, 6, 7, 8, 9]
arr2 = [2, 4, 6, 8, 10, 12, 14]
The result is: [4, 8, 5, 3]

4 elements present in both arrays: 2, 4, 6, 8
8 elements present in only one array: 1, 3, 5, 7, 9, 10, 12, 14
5 elements remaning in arr1: 1, 3, 5, 7, 9
3 elements remaning in arr2: 10, 12, 14
No doubt, an easy kata to warm up before doing the more complex ones. Enjoy it!
*/

//***************Solution********************
using System.Linq;

public class Kata{
  public static int[] Process2Arrays(int[] a1, int[] a2){
    //count the elements excluded from either array
    var a = a1.Count(x => !a2.Contains(x));
    var b = a2.Count(x => !a1.Contains(x));
    
    //format and return result.
    return new int[] {a1.Length - a, a + b, a, b };
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      var arr1 = new int[] { 1, 2 ,3, 4, 5 ,6 ,7 ,8 ,9 };
      var arr2 = new int[] { 2, 4, 6, 8, 10, 12, 14 };
      Assert.AreEqual(new int[] { 4, 8, 5, 3 }, Kata.Process2Arrays(arr1, arr2));
    
      arr1 = new int[] {33, 2, 3, 37, 38, 40, 12, 10, 43, 44, 47, 49, 8, 19, 22, 24, 26, 28, 29, 30};
      arr2 = new int[] {1, 34, 17, 7, 9, 10, 43, 49, 22, 27, 28};
      Assert.AreEqual(new int[] {5, 21, 15, 6}, Kata.Process2Arrays(arr1, arr2));
    
      arr1 = new int[] {32, 34, 3, 4, 39, 10, 43, 13, 11, 18, 21, 22, 7, 25, 26, 36}; 
      arr2 = new int[] {32, 5, 38, 8, 41, 42, 12, 48, 40, 21, 22, 26, 10, 30};
      Assert.AreEqual(new int[] {5, 20, 11, 9}, Kata.Process2Arrays(arr1, arr2));
    
      arr1 = new int[] {0, 33, 37, 6, 10, 44, 13, 47, 16, 18, 22, 25};
      arr2 = new int[] {1, 38, 48, 8, 41, 7, 12, 47, 16, 40, 20, 23, 25};
      Assert.AreEqual(new int[] {3, 19, 9, 10}, Kata.Process2Arrays(arr1, arr2));
    
      arr1 = new int[] {0, 19, 34, 35, 5, 7, 45, 13, 3, 20, 26, 29, 30};
      arr2 = new int[] {33, 4, 38, 1, 8, 13, 47, 23, 28, 30, 31};
      Assert.AreEqual(new int[] {2, 20, 11, 9}, Kata.Process2Arrays(arr1, arr2));
    
      arr1 = new int[] {0, 35, 17, 6, 7, 10, 11, 46, 47, 16, 49, 20, 14, 23, 25, 26, 29}; 
      arr2 = new int[] {0, 6, 17, 42, 43, 47, 16, 49, 50, 21, 28, 30};
      Assert.AreEqual(new int[] {6, 17, 11, 6}, Kata.Process2Arrays(arr1, arr2));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int[],int[],int[]> myProcess2Arrays = delegate (int[] arr1, int[] arr2)
      {
        var count1 = arr1.Intersect(arr2).Count();
        var count3 = arr1.Except(arr2).Count();
        var count4 = arr2.Except(arr1).Count();
        
        return new int[] { count1, count3 + count4, count3, count4 };
      };
      
      for (var h = 0; h <= 100; h++) 
      {
        var l1 = rand.Next(10, 5000);
        var l2 = rand.Next(10, 5000);
        var arr1 = new List<int>();
        var arr2 = new List<int>();
        
        for (var i = 0; i <= l1; i++) 
        {
          var elem1 = rand.Next(0, 1500);
          if (arr1.Contains(elem1))
          {
            continue;
          }
          arr1.Add(elem1);          
        }
        
        for (var i = 0; i <= l2; i++) 
        {
          var elem2 = rand.Next(0, 1500);
          if (arr2.Contains(elem2))
          {
            continue;
          }
          arr2.Add(elem2);          
        }
        var expected = myProcess2Arrays(arr1.ToArray(), arr2.ToArray());
        var result = Kata.Process2Arrays(arr1.ToArray(), arr2.ToArray());
        Assert.AreEqual(string.Join(", ", expected), string.Join(", ", result));
      }
    }
  }
}
