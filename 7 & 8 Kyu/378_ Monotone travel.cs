/*Challenge link:https://www.codewars.com/kata/54466996990c921f90000d61/train/csharp
Question:
Story
Peter lives on a hill, and he always moans about the way to his home. "It's always just up. I never get a rest". But you're pretty sure that at least at one point Peter's altitude doesn't rise, but fall. To get him, you use a nefarious plan: you attach an altimeter to his backpack and you read the data from his way back at the next day.

Task
You're given a list of compareable elements:

heights = new int[0 ... 100]
Your job is to check whether for any x all successors are greater or equal to x.

Kata.IsMonotone(new int[] {1,2,3}) => true
Kata.IsMonotone(new int[] {1,1,2}) => true
Kata.IsMonotone(new int[] {1})     => true
Kata.IsMonotone(new int[] {3,2,1}) => false
Kata.IsMonotone(new int[] {3,2,2}) => false
If the list is empty, Peter has probably removed your altimeter, so we cannot prove him wrong and he's still right:

Kata.IsMonotone(new int[] {}) => true
Such a sequence is also called monotone or monotonic sequence, hence the name isMonotone.
*/

//***************Solution********************

//x is current element, i is index, get all elements where i is not 0(checking null and empty) and arr[i-1] is greater than x
//get bool value if there is any element, then inverse the bool.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static bool IsMonotone(int[] arr) => !arr.Where((x,i) => i != 0 && arr[i-1] > x).Any();
}

//solution 2
using System.Linq;

public class Kata
{
  public static bool IsMonotone(int[] arr)
  {
    return arr.OrderBy(i => i).SequenceEqual(arr);
  }
}

//solution 3
using System.Linq;

public class Kata
{
  public static bool IsMonotone(int[] arr)
  {
    return arr.Skip(1).Select((x,i) => x >= arr[i]).All(x => x);
  }
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
    [Test, Description("should work on increasing lists")]
    public void IncreasingTest()
    {
      Assert.AreEqual(true, Kata.IsMonotone(Enumerable.Range(1, 10).ToArray()));
      Assert.AreEqual(true, Kata.IsMonotone(Enumerable.Range(4, 9).ToArray()));
    }
    
    [Test, Description("should work on constant lists")]
    public void ConstantTest()
    {
      Assert.AreEqual(true, Kata.IsMonotone(new int[] {5, 5, 5, 5, 5}));
    }
    
    [Test, Description("should work on an empty list")]
    public void EmptyTest()
    {
      Assert.AreEqual(true, Kata.IsMonotone(new int[] {}));
    }
    
    [Test, Description("should return false on a decreasing list")]
    public void DecreasingTest()
    {
      Assert.AreEqual(false, Kata.IsMonotone(Enumerable.Range(1, 5).Reverse().ToArray()));
    }
    
    [Test, Description("should work on a non-decreasing list")]
    public void NonDecreasingTest()
    {
      Assert.AreEqual(true, Kata.IsMonotone(new int[] {1, 2, 3, 3, 4, 5}));
    }
    
    private static Random rnd = new Random();
    
    private static bool solution(int[] arr)
    {
      for (int i = 0; i < arr.Length - 1; ++i)
      {
        if (arr[i] > arr[i + 1]) { return false; }
      }
    
      return true;
    }
    
    [Test, Description("should work for random lists")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        int[] arr = new int[rnd.Next(0, 100 + 1)].Select(_ => rnd.Next()).ToArray();
        if (rnd.Next(0, 2) == 0) { arr = arr.OrderBy(x => x).ToArray(); }
        
        bool expected = solution(arr);
        bool actual = Kata.IsMonotone(arr);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
