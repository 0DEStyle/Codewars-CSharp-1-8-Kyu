/*Challenge link:https://www.codewars.com/kata/57ab3c09bb994429df000a4a/train/csharp
Question:
In this kata, your job is to return the two distinct highest values in a list. If there're less than 2 unique values, return as many of them, as possible.

The result should also be ordered from highest to lowest.

Examples:

[4, 10, 10, 9]  =>  [10, 9]
[1, 1, 1]  =>  [1]
[]  =>  []

*/

//***************Solution********************

//Order by descending using -x
//Get distinct number from the array, then take the first 2
//convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static int[] TwoHighest(int[] arr) => 
    arr.OrderBy(x=>-x).Distinct().Take(2).ToArray();
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(Array.Empty<int>(), Kata.TwoHighest(Array.Empty<int>()));
    Assert.AreEqual(new[] { 15 }, Kata.TwoHighest(new[] { 15 }));
    Assert.AreEqual(new[] { 20, 17 }, Kata.TwoHighest(new[] { 15, 20, 20, 17 }));
    Assert.AreEqual(new[] { 10, 9 }, Kata.TwoHighest(new[] { 4, 10, 10, 9 }));
    Assert.AreEqual(new[] { 1 }, Kata.TwoHighest(new[] { 1, 1, 1 }));
    Assert.AreEqual(new[] { 5, 4 }, Kata.TwoHighest(new[] { 4, 1, 2, 3, 5 }));
    Assert.AreEqual(new[] { 3, 2 }, Kata.TwoHighest(new[] { 1, 1, 2, 2, 3, 3 }));
    Assert.AreEqual(new[] { 9, 6 }, Kata.TwoHighest(new[] { 0, 3, 0, 6, 0, 9 }));
    Assert.AreEqual(new[] { 0 }, Kata.TwoHighest(new[] { 0, 0, 0 }));
    Assert.AreEqual(new[] { 9, 0 }, Kata.TwoHighest(new[] { 0, 9, 0 }));
  }
  
  private static readonly Random Rand = new();

  [Test]
  public void RandomTest()
  {
    for (var i = 0; i < 100; i++)
    {
      var arr = RandomArray();
      var expected = Solution(arr);
      var actual = Kata.TwoHighest(arr);
      var message = FailureMessage(arr, expected);
      Assert.AreEqual(expected, actual, message);
    }
  }

  private static int[] Solution(int[] arr)
  {
    return arr.Distinct().OrderByDescending(x => x).Take(2).ToArray();
  }

  private static int[] RandomArray()
  {
    return Enumerable.Range(0, Rand.Next(0, 10)).Select(_ => Rand.Next(0, 100)).ToArray();
  }

  private static string FailureMessage(int[] arr, int[] expected)
  {
    return $"Should return [{string.Join(", ", expected)}] with arr=[{string.Join(", ", arr)}]";
  }
}
