/*Challenge link:https://www.codewars.com/kata/52de553ebb55d1fca3000371/train/csharp
Question:
An Arithmetic Progression is defined as one in which there is a constant difference between the consecutive terms of a given series of numbers. You are provided with consecutive elements of an Arithmetic Progression. There is however one hitch: exactly one term from the original series is missing from the set of numbers which have been given to you. The rest of the given series is the same as the original AP. Find the missing term.

You have to write a function that receives a list, list size will always be at least 3 numbers. The missing term will never be the first or last one.

Example
Kata.FindMissing(new List<int> {1, 3, 5, 9, 11}) => 7
PS: This is a sample question of the facebook engineer challenge on interviewstreet. I found it quite fun to solve on paper using math, derive the algo that way. Have fun!
*/

//***************Solution********************

using System.Linq;
using System.Collections.Generic;
using System;

public class Kata{
  public static int FindMissing(List<int> list){
    //find out the step difference
    var step = (list.Max() - list.Min()) / list.Count;
    //from list, find the first element that isn't included in the list using (x + step), then add step again.
    return list.First(x => !list.Contains(x + step)) + step;
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
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new[] {new List<int> {1, 3, 5, 9, 11}}).Returns(7);
        yield return new TestCaseData(new[] {new List<int> {0, 5, 10, 20, 25}}).Returns(15);
        yield return new TestCaseData(new[] {new List<int> {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 11}}).Returns(10);
        yield return new TestCaseData(new[] {new List<int> {1040, 1220, 1580}}).Returns(1400);
        yield return new TestCaseData(new[] {new List<int> {1040, 1400, 1580}}).Returns(1220);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(List<int> list) => Kata.FindMissing(list);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static int solution(List<int> list)
    {
      int step = (list.Last() - list.First()) / list.Count();
      int current = list.First();
      
      for (int i = 0; i < list.Count(); ++i)
      {
        if (list[i] != current) { return current; }
        current += step;
      }
      
      throw new ArgumentException("No missing values were found in the provided list.");
    }
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int step = rnd.Next(1, 20000);
        int offset = rnd.Next(-10000, 10000); 
        List<int> test = new int[rnd.Next(3 + 1, 2000)].Select((_, idx) => idx * step - offset).ToList();
        
        // Remove one value
        int toRemove = rnd.Next(1, test.Count() - 1);
        int expected = test[toRemove];
        test.RemoveAt(toRemove);
        
        int actual = Kata.FindMissing(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
