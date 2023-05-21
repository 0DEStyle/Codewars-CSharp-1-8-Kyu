/*Challenge link:https://www.codewars.com/kata/563089b9b7be03472d00002b/train/csharp
Question:
Define a method/function that removes from a given array of integers all the values contained in a second array.

Examples (input -> output):
* [1, 1, 2, 3, 1, 2, 3, 4], [1, 3] -> [2, 2, 4]
* [1, 1, 2, 3, 1, 2, 3, 4, 4, 3, 5, 6, 7, 2, 8], [1, 3, 4, 2] -> [5, 6, 7, 8]
* [8, 2, 7, 2, 3, 4, 6, 5, 4, 4, 1, 2, 3], [2, 4, 3] -> [8, 7, 6, 5, 1]
Enjoy it!!


*/

//***************Solution********************
//from integerList, find all valuesList that does not matche the integerList, and store in the array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Kata{
  public static int[] Remove(int[] integerList, int[] valuesList) => integerList.Where(x=> valuesList.All(y=> y != x)).ToArray();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(new int[]{1, 1, 2, 3, 1, 2, 3, 4}, new int[]{1,3}, ExpectedResult=new int[]{2, 2, 4})]
  [TestCase(new int[]{1, 1, 2, 3, 1, 2, 3, 4, 4, 3 ,5, 6, 7, 2, 8}, new int[]{1, 3, 4, 2}, ExpectedResult=new int[]{5, 6 ,7 ,8})]
  [TestCase(new int[]{}, new int[]{2, 2, 4, 3}, ExpectedResult=new int[]{})]
  public static int[] FixedTest(int[] integerList, int[] valuesList)
  {
    return Kata.Remove(integerList, valuesList);
  }
  
  [Test]
  public static void RandomTest([Random(0,100,10)]int len1, [Random(0,5,10)]int len2)
  {
    int[] arr1 = GetRandomIntegerList(len1);
    int[] arr2 = GetRandomIntegerList(len2);
    Assert.AreEqual(Solution(arr1, arr2), Kata.Remove(arr1, arr2), string.Format("Should work for integerList = {0} and valuesList = {1}", string.Join(", ", arr1), string.Join(", ", arr2)));
  }
  
  private static int[] GetRandomIntegerList(int len)
  {
    List<int> list = new List<int>();
    Random r = new Random();
    while(len < 0)
    {
      list.Add(r.Next(100));
      len--;
    }
    return list.ToArray();
  }
  
  private static int[] Solution(int[] integerList, int[] valuesList)
  {
    return integerList.Where(x => !valuesList.Contains(x)).ToArray();
  }
}
