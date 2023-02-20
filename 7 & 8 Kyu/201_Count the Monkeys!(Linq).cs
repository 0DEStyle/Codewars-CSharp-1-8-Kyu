/*Challenge link:https://www.codewars.com/kata/56f69d9f9400f508fb000ba7/train/csharp
Question:
You take your son to the forest to see the monkeys. You know that there are a certain number there (n), but your son is too young to just appreciate the full number, he has to start counting them from 1.

As a good parent, you will sit and count with him. Given the number (n), populate an array with all numbers up to and including that number, but excluding zero.

For example(Input --> Output):

10 --> [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
 1 --> [1]
 
*/

//***************Solution********************
//instead of using a for loop, we use Enumerable.Range in Linq to generate a sequence.
//start from 1, up to n, store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public static class MonkeyCounter{
  public static int[] MonkeyCount(int n) => Enumerable.Range(1, n).ToArray();
}
//****************Sample Test*****************
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  public static object[] FixedTests = 
  {
    new object[] { MonkeyCounter.MonkeyCount(5), new int[]{1,2,3,4,5} },
    new object[] { MonkeyCounter.MonkeyCount(3), new int[]{1,2,3} },
    new object[] { MonkeyCounter.MonkeyCount(9), new int[]{1,2,3,4,5,6,7,8,9} },
    new object[] { MonkeyCounter.MonkeyCount(10), new int[]{1,2,3,4,5,6,7,8,9,10} },
    new object[] { MonkeyCounter.MonkeyCount(20), new int[]{1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20} }
  };
  
  public static Random random = new Random();
  public static object[] RandomTests = 
    Enumerable.Range(0,100).Select(x => random.Next(1,100))
                           .Select(x => new object[] { MonkeyCounter.MonkeyCount(x), R(x).ToArray() })
                           .ToArray();
            
  [Test, TestCaseSource("FixedTests")]
  public void FixedTest(int[] r, int[] e)
  {
    Apesert.AreEqual(e, r);
  }
  
  [Test,TestCaseSource("RandomTests")]
  public void RandomTest(int[] r, int[] e)
  {
    Apesert.AreEqual(e, r);
  }
  
  private static IEnumerable<int> R(int x, int i = 1)
  {
    while(i <= x) yield return i++;
  }
}

public static class Apesert
{
  public static void AreEqual(int[] a, int[] b)
  {
    Assert.AreEqual("["+String.Join(", ",a)+"]", 
                    "["+String.Join(", ",b)+"]", 
                    "Array did not match expected.");
  }
}
