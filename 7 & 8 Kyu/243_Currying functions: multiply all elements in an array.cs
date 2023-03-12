/*Challenge link:https://www.codewars.com/kata/586909e4c66d18dd1800009b/train/csharp
Question:
To complete this Kata you need to make a function multiplyAll/multiply_all which takes an array of integers as an argument. This function must return another function, which takes a single integer as an argument and returns a new array.

The returned array should consist of each of the elements from the first array multiplied by the integer.

Example:

multiplyAll([1, 2, 3])(2) = [2, 4, 6];
You must not mutate the original array.

Here's a nice Youtube video about currying, which might help you if this is new to you.
*/

//***************Solution********************
//create function called MultiplyAll, takes in an integer and an integer array
//then multiply each element in the array with the integer, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

class Kata{
  public static Func<int, int[]> MultiplyAll(int[] a) => i => a.Select(x => x * i).ToArray();
}



//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class Currying
  {
    private static Random rnd = new Random();
  
    private static Func<int, int[]> Solution(int[] arr) =>
      num => 
        arr.Select(v => v * num).ToArray();    
  
    [Test, Description("must return an array")]
    public void ArrayTest()
    {
      Assert.IsTrue(Kata.MultiplyAll(new int[] {1})(1).GetType().IsArray);
    }
    
    [Test, Description("array has correct length")]
    public void LengthTest()
    {
      Assert.IsTrue(Kata.MultiplyAll(new int[] {1, 2})(1).Length == 2);
    }
    
    [Test, Description("returned array has correct values")]
    public void ValuesTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(Kata.MultiplyAll(new int[] {1, 2, 3})(1), new int[] {1, 2, 3}),
        () => Assert.AreEqual(Kata.MultiplyAll(new int[] {1, 2, 3})(2), new int[] {2, 4, 6}),
        () => Assert.AreEqual(Kata.MultiplyAll(new int[] {1, 2, 3})(0), new int[] {0, 0, 0}),
        () => Assert.AreEqual(Kata.MultiplyAll(new int[] {})(10), new int[] {}, "should return an empty array"),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("random tests")]
    public void RandomTests()
    {
      for (int i = 0; i < 100; ++i)
      {
        int length = rnd.Next(0, 20);
        int[] arr = new int[length].Select(v => rnd.Next(0, 100)).ToArray();
        int num = rnd.Next(0, 100);
        int[] expected = Solution(arr)(num);
        int[] actual = Kata.MultiplyAll(arr)(num);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
