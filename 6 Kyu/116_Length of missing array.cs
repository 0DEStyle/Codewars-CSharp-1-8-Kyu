/*Challenge link:https://www.codewars.com/kata/57b6f5aadb5b3d0ae3000611/train/csharp
Question:
You get an array of arrays.
If you sort the arrays by their length, you will see, that their length-values are consecutive.
But one array is missing!


You have to write a method, that return the length of the missing array.

Example:
[[1, 2], [4, 5, 1, 1], [1], [5, 6, 7, 8, 9]] --> 3

If the array of arrays is null/nil or empty, the method should return 0.

When an array in the array is null or empty, the method should return 0 too!
There will always be a missing element and its length will be always between the given arrays.

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have created other katas. Have a look if you like coding and challenges.
*/

//***************Solution********************

//if arr is null or length is 0, or any element is null or length is 0, return 0
//else loop start from lowest length value of arr element, up to arr length
//then find the set difference to arr's element.length, get the first value.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int GetLengthOfMissingArray(object[][] arr) =>
    arr == null || arr.Length == 0 || arr.Any(x => x == null || x.Length == 0)
    ? 0
    : Enumerable.Range(arr.Min(x => x.Length), arr.Length).Except(arr.Select(x => x.Length)).First();
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
      Assert.AreEqual(3, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 }} ));
      Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 5, 2, 9 }, new object[] { 4, 5, 1, 1 }, new object[] { 1 }, new object[] { 5, 6, 7, 8, 9 }} ));
      Assert.AreEqual(2, Kata.GetLengthOfMissingArray(new object[][] { new object[] { null }, new object[] { null, null, null } } ));
      Assert.AreEqual(5, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 'a', 'a', 'a' }, new object[] { 'a', 'a' }, new object[] { 'a', 'a', 'a', 'a' }, new object[] { 'a' }, new object[] { 'a', 'a', 'a', 'a','a', 'a' }} ));
      
      // not starting with length 1
      Assert.AreEqual(4, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 5, 2, 9 }, new object[] { 4, 5, 1, 1, 5, 6}, new object[] { 1, 1 }, new object[] { 5, 6, 7, 8, 9 }} ));
      
      // edge cases
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { }));
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(null));
      
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { new object[] { }, new object[] { 1, 2, 2 } } ));
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2, 2 }, null} ));
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { null, new object[] { 1, 2, 2 } } ));
      Assert.AreEqual(0, Kata.GetLengthOfMissingArray(new object[][] { new object[] { 1, 2, 2 }, new object[] { }} ));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<40;r++)
      {
        var startLength = rand.Next(0,5);
        var endLength = rand.Next(startLength + 3, startLength + 12);
        
        var missingLength = rand.Next(startLength + 1, endLength);
        
        var listOfArrays = new List<object[]>();
        
        for(int i=startLength;i<=endLength;i++)
        {
          if(i != missingLength)
          {
            listOfArrays.Add(Enumerable.Range(0, i).Select(e => (object)rand.Next(0,5)).ToArray());
          }
        }
        
        if(startLength == 0)
        {
          missingLength = 0;
        }        
        
        var arrayOfArrays = listOfArrays.OrderBy(a => rand.Next(-1,2)).ToArray();        
        
        Assert.AreEqual(missingLength, Kata.GetLengthOfMissingArray(arrayOfArrays),
        "Wrong for [" + string.Join(", ", arrayOfArrays.Select(o => "[" + string.Join(", ", o) + "]"))+ "]");
      }
    }    
  }
}
