/*Challenge link:https://www.codewars.com/kata/53da6d8d112bd1a0dc00008b/train/csharp
Question:
In this kata you will create a function that takes in a list and returns a list with the reverse order.

Examples (Input -> Output)
* [1, 2, 3, 4]  -> [4, 3, 2, 1]
* [9, 2, 0, 7]  -> [7, 0, 2, 9]
*/

//***************Solution********************
//reverse link using linq
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Kata
{
  public static List<int> ReverseList(List<int> list) => Enumerable.Reverse(list).ToList();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new List<int> {1, 2, 3, 4}).Returns(new List<int> {4, 3, 2, 1});
        yield return new TestCaseData(new List<int> {3, 1, 5, 4}).Returns(new List<int> {4, 5, 1, 3});
        yield return new TestCaseData(new List<int> {3, 6, 9, 2}).Returns(new List<int> {2, 9, 6, 3});
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public List<int> SampleTest(List<int> list) => Kata.ReverseList(list);
    
    private static IEnumerable<TestCaseData> edgeCases
    {
      get
      {
        yield return new TestCaseData(new List<int> {1}).Returns(new List<int> {1}).SetDescription("One element in list");
        yield return new TestCaseData(new List<int> {}).Returns(new List<int> {}).SetDescription("Empty list");
      }
    }
    
    [Test, TestCaseSource("edgeCases")]
    public List<int> EdgeTest(List<int> list) => Kata.ReverseList(list);
    
    private static Random rnd = new Random();
    
    private static List<int> solution(List<int> list)
    {
      // Make shallow copy of list
      List<int> result = new List<int>(list);
      
      // Reverse list
      result.Reverse();
      
      return result;
    }
    
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        List<int> test = new List<int>(new int[rnd.Next(0, 100)].Select(_ => rnd.Next(-100, 101)));
        List<int> clone = new List<int>(test);
        
        List<int> actual = Kata.ReverseList(test);
        Assert.AreEqual(test, clone, "User mutated the input list!");
        
        List<int> expected = solution(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
