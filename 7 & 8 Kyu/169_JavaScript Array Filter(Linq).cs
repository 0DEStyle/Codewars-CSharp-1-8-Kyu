/*Challenge link:https://www.codewars.com/kata/514a6336889283a3d2000001/train/csharp
Question:
Starting with .NET Framework 3.5, C# supports a Where (in the System.Linq namespace) method which allows a user to filter arrays based on a predicate. Use the Where method to complete the function given.

Enumerable.Where documentation: https://msdn.microsoft.com/en-us/library/bb534803(v=vs.110).aspx

The solution would work like the following:

Kata.GetEvenNumbers(new int[] {2, 4, 5, 6}) => new int[] {2, 4, 6}
*/

//***************Solution********************
//select only even number and return result in array format.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int[] GetEvenNumbers(int[] numbers) => numbers.Where(x=> x % 2 == 0).ToArray();
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
        yield return new TestCaseData(new int[] {1, 2})
                                     .Returns(new int[] {2});
        yield return new TestCaseData(new int[] {2, 6, 8, 10})
                                     .Returns(new int[] {2, 6, 8, 10});
        yield return new TestCaseData(new int[] {12, 14, 15})
                                     .Returns(new int[] {12, 14});
        yield return new TestCaseData(new int[] {13, 15})
                                     .Returns(new int[] {});
        yield return new TestCaseData(new int[] {1, 3, 9})
                                     .Returns(new int[] {});
        yield return new TestCaseData(new int[] {-1, -3, -9})
                                     .Returns(new int[] {});
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int[] FixedTests(int[] numbers) => Kata.GetEvenNumbers(numbers);
    
    private static Random rnd = new Random();
    
    private static int[] solution(int[] numbers)
    {
      Func<int, bool> isEven = (n) => (n & 1) == 0;
      
      return numbers.Where(isEven)
                    .ToArray();
    }
    
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTest()
    {
      const int Tests = 100;
      const int TestCaseLength = 30;
      const int MaxInt = 100 + 1;
      const int MinInt = -100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] test = new int[TestCaseLength].Select(_ => rnd.Next(MinInt, MaxInt)).ToArray();
        int[] clone = (int[])test.Clone();
        int[] expected = solution(test);
        int[] actual = Kata.GetEvenNumbers(test);
        
        Assert.AreEqual(test, clone, "User mutated the input array!");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
