/*Challenge link:https://www.codewars.com/kata/5575aa1f24556d7a00000082/train/csharp
Question:
Normally numbers are ordered 1, 2, 3, ..., 9, but in an alternative universe, the numbers are ordered as follows:

7, 9, 6, 4, 1, 3, 5, 8, 2

The task is to create a function called GarbleSort to sort a list of numbers with the values 1 to 9 (inclusive) according to the alternative ordering above.

Examples:

GarbleSort({ 1, 2, 3 }) = { 1, 3, 2 }
GarbleSort({ 5, 6, 3 }) = { 6, 3, 5 }
*/

//***************Solution********************
//7, 9, 6, 4, 1, 3, 5, 8, 2 Alternative universe
//1, 2, 3, 4, 5, 6, 7, 8, 9 Normal order

//Sorted Alternative universe corresponding to index in normal order
//5, 9, 6, 4, 7, 3, 1, 8, 2 


using System.Linq;

public class Kata{
  public static int[] GarbleSort(int[] values){
    int[] nums = {5, 9, 6, 4, 7, 3, 1, 8, 2};
    return values.OrderBy(x => nums[x - 1]).ToArray();
  }
}

//solution 2
using System.Linq;
using System;
public class Kata
{
  public static int[] GarbleSort(int[] values)
  {
    var index=new int[]{7,9,6,4,1,3,5,8,2};
    return values.Select(x=>Array.IndexOf(index,x)).OrderBy(x=>x).Select(x=>index[x]).ToArray();
  }
}

//solution 3
using System;
using System.Linq;

public class Kata
{
  public static int[] GarbleSort(int[] values)
  {
    return values.OrderBy(x => "796413582".IndexOf(x.ToString())).ToArray();
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class GarbleSortTests
{
  [Test]
  public static void TestExample1()
  {
    CollectionAssert.AreEqual(
      new int[] { 1, 3, 2 },
      Kata.GarbleSort(new int[] { 1, 2, 3 }));
  }
  
  [Test]
  public static void TestExample2()
  {
    CollectionAssert.AreEqual(
      new int[] { 6, 3, 5 },
      Kata.GarbleSort(new int[] { 5, 6, 3 }));
  }

  [Test]
  public static void TestEmpty()
  {
    CollectionAssert.AreEqual(
      new int[] {},
      Kata.GarbleSort(new int[] {}));
  }
  
  [Test]
  public static void TestSingleItem()
  {
    CollectionAssert.AreEqual(
      new int[] { 4 },
      Kata.GarbleSort(new int[] { 4 }));
  }
  
  [Test]
  public static void TestNormalOrdering()
  {
    CollectionAssert.AreEqual(
      new int[] { 7, 9, 6, 4, 1, 3, 5, 8, 2 },
      Kata.GarbleSort(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }));
  }
  
  [Test]
  public static void TestAlreadyGarbled()
  {
    CollectionAssert.AreEqual(
      new int[] { 7, 9, 6, 4, 1, 3, 5, 8, 2 },
      Kata.GarbleSort(new int[] { 7, 9, 6, 4, 1, 3, 5, 8, 2 }));
  }
  
  [Test]
  public static void TestDuplicateValues()
  {
    CollectionAssert.AreEqual(
      new int[] { 7, 9, 9, 6, 4, 1, 1, 1, 3, 5, 5, 8, 2, 2 },
      Kata.GarbleSort(new int[] { 1, 2, 1, 5, 1, 6, 7, 2, 3, 4, 5, 9, 8, 9 }));
  }
  
  [Test]
  public static void TestAllSame()
  {
    CollectionAssert.AreEqual(
      new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 },
      Kata.GarbleSort(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 }));
  }
  
  [Test]
  public static void TestRandom()
  {
    Random r = new Random();
    
    for (int i = 0; i < 100; i++) {
      var arraySize = r.Next(100, 1000);
      var randomArray = new int[arraySize];
      
      for (int j = 0; j < arraySize; j++) {
        randomArray[j] = r.Next(1, 9);
      }
      
      CollectionAssert.AreEqual(
        GarbleSort(randomArray),
        Kata.GarbleSort(randomArray));
    }
  }
  
  public static int[] GarbleSort(int[] values)
  {
    var order = new int[] { 7, 9, 6, 4, 1, 3, 5, 8, 2 };
    
    Array.Sort(values,
      Comparer<int>.Create(
        (x, y) =>
          Array.IndexOf(order, x)
          .CompareTo(
          Array.IndexOf(order, y))));
          
    return values;
  }
}
