/*Challenge link:https://www.codewars.com/kata/545a4c5a61aa4c6916000755/train/csharp
Question:
As a part of this Kata, you need to create a function that when provided with a triplet, returns the index of the numerical element that lies between the other two elements.

The input to the function will be an array of three distinct numbers (Haskell: a tuple).

For example:

gimme([2, 3, 1]) => 0
2 is the number that fits between 1 and 3 and the index of 2 in the input array is 0.

Another example (just to make sure it is clear):

gimme([5, 10, 14]) => 1
10 is the number that fits between 5 and 14 and the index of 10 in the input array is 1.
*/

//***************Solution********************
//sort the array, get the middle element (array[1])
//pick out the element index by value and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static int Gimme(double[] inputArray) =>  Array.IndexOf(inputArray, inputArray.OrderBy(x => x).ToArray()[1]);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual(0, Kata.Gimme(new double[] {2, 3, 1}));
      Assert.AreEqual(1, Kata.Gimme(new double[] {5, 10, 14}));
    }
    
    [Test]
    public void FloatTests()
    {
      Assert.AreEqual(0, Kata.Gimme(new double[] {2.1, 3.2, 1.4}));
      Assert.AreEqual(1, Kata.Gimme(new double[] {5.9, 10.4, 14.2}));
    }
    
    [Test]
    public void NegativeTests()
    {
      Assert.AreEqual(0, Kata.Gimme(new double[] {-2, -3, -1}));
      Assert.AreEqual(1, Kata.Gimme(new double[] {-5, -10, -14}));
    }
    
    [Test]
    public void MixedTests()
    {
      Assert.AreEqual(0, Kata.Gimme(new double[] {-2, -3.2, 1}));
      Assert.AreEqual(0, Kata.Gimme(new double[] {-5.2, -10.6, 14}));
    }
    
    public static int Solution(double[] inputArray)
    {
      double[] sorted = (double[])inputArray.Clone();
      Array.Sort(sorted);
      return Array.IndexOf(inputArray, sorted[1]);
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 40; ++i)
      {
        double[] testCase = new double[] {rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble()};
        Assert.AreEqual(Solution(testCase), Kata.Gimme(testCase));
      }
    }
  }
}
