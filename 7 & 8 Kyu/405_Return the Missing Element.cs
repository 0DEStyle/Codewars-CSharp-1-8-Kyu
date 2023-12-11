/*Challenge link:https://www.codewars.com/kata/5299413901337c637e000004/train/csharp
Question:
Fellow code warrior, we need your help! We seem to have lost one of our sequence elements, and we need your help to retrieve it!

Our sequence given was supposed to contain all of the integers from 0 to 9 (in no particular order), but one of them seems to be missing.

Write a function that accepts a sequence of unique integers between 0 and 9 (inclusive), and returns the missing element.

Examples:
[0, 5, 1, 3, 2, 9, 7, 6, 4] --> 8
[9, 2, 4, 5, 7, 0, 8, 6, 1] --> 3
*/

//***************Solution********************
//sum 1 to 9, subtract from total sum of goofyAhh to find the missing number
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static int GetMissingElement(int[] goofyAhh) => 45 - goofyAhh.Sum();
}

//solution 2
using System;
using System.Linq;

public static class Kata
{
  public static int GetMissingElement(int[] superImportantArray)
  {
    return (int)Enumerable.Range(0,9).Except(superImportantArray).FirstOrDefault();
  }
}

//solution 3
using System.Linq;

public static class Kata
{
  public static int GetMissingElement(int[] superImportantArray)
  {
    return Enumerable.Range(0, 10).First(i => !superImportantArray.Contains(i));
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class MissingElement
{
  public static int[] shuffle(int[] array)
  {
    Random rand = new Random();
    int len = array.Length;
  	for (int i = 0; i < len; i++)
  	{
  	    int r = i + (int)(rand.NextDouble() * (len - i));
  	    int t = array[r];
  	    array[r] = array[i];
  	    array[i] = t;
  	}
    return array;
  }
  
  [Test]
  public static void MissingElementTest()
  {
    int[] arr = new int[10] {0,1,2,3,4,5,6,7,8,9};
    int[] test = new int[9];
    int removedVal;
    for(int i=0; i<20; i++)
    {
      arr = shuffle(arr);
      removedVal = arr[9];
      Array.Copy(arr, test, 9);
      Assert.AreEqual(removedVal, Kata.GetMissingElement(test));
    }
  }
}
