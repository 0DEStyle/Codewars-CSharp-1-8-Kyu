/*Challenge link:https://www.codewars.com/kata/57b68bc7b69bfc8209000307/train/csharp
Question:
Create a function that returns the average of an array of numbers ("scores"), rounded to the nearest whole number. You are not allowed to use any loops (including for, for/in, while, and do/while loops).

The array will never be empty. 
*/

//***************Solution********************
//use Linq function to find the average of array, then round to the nearest.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static int Average(int[] s)=> (int)Math.Round(s.Average(),0); 
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    { 
      var scores = new int[] { 49,3,5,300,7 };
      Assert.AreEqual(73, Kata.Average(scores));

      scores = new int[] { 90,98,89,100,100,86,94 };
      Assert.AreEqual(94, Kata.Average(scores));
    }
    
    [Test]
    public void ExtendedTests()
    {
      var scores = new int[] { 5, 78, 52, 900, 1 };
      Assert.AreEqual(207, Kata.Average(scores));

      scores = new int[] { 5, 25, 50, 75 };
      Assert.AreEqual(39, Kata.Average(scores));
      
      scores = new int[] { 2 };
      Assert.AreEqual(2, Kata.Average(scores));
      
      scores = new int[] { 1, 1, 1, 1, 9999 };
      Assert.AreEqual(2001, Kata.Average(scores));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int[],int> myAverage = scores => (int)Math.Round((double)scores.Sum() / scores.Length);

      for(int r=0;r<20;r++)
      {
        var scores = Enumerable.Range(0, rand.Next(2,20)).Select(i => rand.Next(1,200)).ToArray();
        Assert.AreEqual(myAverage(scores), Kata.Average(scores));
      }
    }
    
    [Test]
    public void AntiCheatingTest()
    {
      Assert.IsFalse(CheatingPrevention.CheatingDetection(), "Solution does not use any loops");
    }
  }
  }
