/*Challenge link:https://www.codewars.com/kata/55eea63119278d571d00006a/train/csharp
Question:
Hey awesome programmer!

You've got much data to manage and of course you use zero-based and non-negative ID's to make each data item unique!

Therefore you need a method, which returns the smallest unused ID for your next new data item...

Note: The given array of used IDs may be unsorted. For test reasons there may be duplicate IDs, but you don't have to find or remove them!

Go on and code some pure awesomeness! 
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//start from 0 count up to ids.Length + 1
//get the values that not in ids (Except)
//from those values, get the min value.
using System.Linq;

public class Kata{
  public static int NextId(int[] ids) => 
    Enumerable.Range(0, ids.Length + 1)
              .Except(ids)
              .Min();
}

//solution 2
using System;
using System.Linq;

public class Kata
{
  public static int NextId(int[] ids)
  {
    int i = 0;
    while (ids.Contains(i))
    {
      i++;
    }
    
    return i;
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(new int[]{0,1,2,3,5}, ExpectedResult=4)]
  [TestCase(new int[]{0,1,2,3,4,5,6,7,8,9,10}, ExpectedResult=11)]
  public static int FixedTest(int[] ids)
  {
    return Kata.NextId(ids);
  }
  
  [Test]
  public static void RandomTests()
  {
    List<int> list = new List<int>();
    Random r = new Random();
    for(int i = 0; i < 100; i++)
    {
      int num = r.Next(100);
      if(list.IndexOf(num) == -1) list.Add(num);
    }
    int[] nums = list.ToArray();
    Assert.AreEqual(Solution(nums), Kata.NextId(nums), String.Format("Should work for {0}", nums.ToString()));
  }
  
  private static int Solution(int[] ids)
  {
    List<int> idlist = new List<int>(ids);
    int num = 0;
    while(true)
    {
      if(idlist.IndexOf(num) == -1)
        return num;
      num++;
    }
  }
}
