/*Challenge link:https://www.codewars.com/kata/5715eaedb436cf5606000381/train/csharp
Question:
You get an array of numbers, return the sum of all of the positives ones.

Example [1,-4,7,12] => 1 + 7 + 12 = 20

Note: if there is nothing to sum, the sum is default to 0.
*/

//***************Solution********************
//select all positive numbers, sum and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static int PositiveSum(int[] arr) => arr.Where(num => num > 0).Sum();
}


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(new int[]{1, 2, 3, 4, 5}, ExpectedResult=15)]
  [TestCase(new int[]{1, -2, 3, 4, 5}, ExpectedResult=13)]
  [TestCase(new int[]{-1, 2, 3, 4, -5}, ExpectedResult=9)]
  [TestCase(new int[]{}, ExpectedResult=0)]
  [TestCase(new int[]{-1, -2, -3, -4, -5}, ExpectedResult=0)]
  public static int ExampleTest(int[] arr)
  {
    return Kata.PositiveSum(arr);
  }
  
  [Test]
  public static void RandomTest([Random(5, 120, 40)] int length)
  {
    int[] arr = RandomArray(length);
    Assert.AreEqual(Solution(arr), Kata.PositiveSum(arr), string.Format("Failed when arr = {0}", arr));
  }
  
  public static int[] RandomArray(int length)
  {
    int[] result = new int[length];
    Random rnd = new Random();
    for (int i = 0; i < length; ++i) {
      result[i] = rnd.Next(-100, 100);
    }
    return result;
  }
  
  private static int Solution(int[] arr)
  {
    return arr.Where(x => x > 0).Sum();
  }
}
