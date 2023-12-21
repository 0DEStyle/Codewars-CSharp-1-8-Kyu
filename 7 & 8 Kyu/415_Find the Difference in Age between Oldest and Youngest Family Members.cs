/*Challenge link:https://www.codewars.com/kata/5720a1cb65a504fdff0003e2/train/csharp
Question:
At the annual family gathering, the family likes to find the oldest living family member’s age and the youngest family member’s age and calculate the difference between them.

You will be given an array of all the family members' ages, in any order. The ages will be given in whole numbers, so a baby of 5 months, will have an ascribed ‘age’ of 0. Return a new array (a tuple in Python) with [youngest age, oldest age, difference between the youngest and oldest age].
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//format into tuple, min age, max age and max - min age.
using System.Linq;

public class Kata{
  public static int[] DifferenceInAges(int[] a) => new int[]{a.Min(), a.Max(), a.Max() - a.Min()};
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static int[] solution(int[] ages)
    {
      int min = ages.Min(), 
          max = ages.Max(), 
          diff = max - min;
      
      return new int[] {min, max, diff};
    }
  
    [Test, Description("Should return expected results for sample tests")]
    public void SampleTest()
    {
      Assert.AreEqual(new int[] {6, 82, 76}, Kata.DifferenceInAges(new int[] {82, 15, 6, 38, 35}));
      Assert.AreEqual(new int[] {14, 99, 85}, Kata.DifferenceInAges(new int[] {57, 99, 14, 32}));
    }

    [Test, Description("Should return expected results for fixed tests")]
    public void FixedTest()
    {
      Assert.AreEqual(new int[] {3, 88, 85}, Kata.DifferenceInAges(new int[] {16, 22, 31, 44, 3, 38, 27, 41, 88}));
      Assert.AreEqual(new int[] {5, 98, 93}, Kata.DifferenceInAges(new int[] {5, 8, 72, 98, 41, 16, 55}));
      Assert.AreEqual(new int[] {14, 99, 85}, Kata.DifferenceInAges(new int[] {57, 99, 14, 32}));
      Assert.AreEqual(new int[] {0, 102, 102}, Kata.DifferenceInAges(new int[] {62, 0, 3, 77, 88, 102, 26, 44, 55}));
      Assert.AreEqual(new int[] {2, 88, 86}, Kata.DifferenceInAges(new int[] {2, 44, 34, 67, 88, 76, 31, 67}));
      Assert.AreEqual(new int[] {1, 92, 91}, Kata.DifferenceInAges(new int[] {46, 86, 33, 29, 87, 47, 28, 12, 1, 4, 78, 92}));
      Assert.AreEqual(new int[] {5, 88, 83}, Kata.DifferenceInAges(new int[] {66, 73, 88, 24, 36, 65, 5}));
      Assert.AreEqual(new int[] {3, 84, 81}, Kata.DifferenceInAges(new int[] {12, 76, 49, 37, 29, 17, 3, 65, 84, 38}));
      Assert.AreEqual(new int[] {0, 110, 110}, Kata.DifferenceInAges(new int[] {0, 110}));
      Assert.AreEqual(new int[] {33, 33, 0}, Kata.DifferenceInAges(new int[] {33, 33, 33}));
    }
    
    [Test, Description("Should return expected results for random tests")]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] ages = new int[rnd.Next(2, 100)].Select(_ => rnd.Next(0, 121)).ToArray();
        
        int[] expected = solution(ages);
        int[] actual = Kata.DifferenceInAges(ages);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
