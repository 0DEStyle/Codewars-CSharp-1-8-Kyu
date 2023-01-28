/*Challenge link:https://www.codewars.com/kata/559f80b87fa8512e3e0000f5/train/csharp
Question:
Time to test your basic knowledge in functions! Return the odds from a list:

[1, 2, 3, 4, 5]  -->  [1, 3, 5]
[2, 4, 6]        -->  []
*/

//***************Solution********************
//select all the odd number and add to list, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;
public static class Kata{
  public static List<int> Odds(List<int> values) => values.Where( x =>  x % 2 == 1).ToList();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static List<int> Odds(List<int> values) =>
      values.Where(v => v % 2 != 0)
            .ToList();
  }
  
  [TestFixture]
  public class BasicTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new List<int>()).Returns(new List<int>()).SetDescription("Should handle empty list");
        yield return new TestCaseData(new List<int> {2, 4, 6}).Returns(new List<int>()).SetDescription("Should handle list with even numbers only");
        yield return new TestCaseData(new List<int> {1, 3, 5}).Returns(new List<int> {1, 3, 5}).SetDescription("Should handle list with odd numbers only");
        yield return new TestCaseData(new List<int> {1, 2, 3, 4, 5, 6}).Returns(new List<int> {1, 3, 5}).SetDescription("Should handle mixed list");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public List<int> Test(List<int> values) =>
      Kata.Odds(values);
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        const int Tests = 100;
        Random rnd = new Random();
        
        for (int i = 0; i < Tests; ++i)
        {
          List<int> values = new int[rnd.Next(0, 20)].Select(_ => rnd.Next()).ToList();
          List<int> expected = Solution.Odds(values);
          
          yield return new TestCaseData(values).Returns(expected).SetDescription("should handle random list");
        }
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public List<int> Test(List<int> values) =>
      Kata.Odds(values);
  }
}
