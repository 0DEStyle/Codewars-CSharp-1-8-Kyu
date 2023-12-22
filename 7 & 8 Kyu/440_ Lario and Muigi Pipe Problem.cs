/*Challenge link:https://www.codewars.com/kata/56b29582461215098d00000f/train/csharp
Question:
Issue
Looks like some hoodlum plumber and his brother has been running around and damaging your stages again.

The pipes connecting your level's stages together need to be fixed before you receive any more complaints.

The pipes are correct when each pipe after the first is 1 more than the previous one.

Task
Given a list of unique numbers sorted in ascending order, return a new list so that the values increment by 1 for each index from the minimum value up to the maximum value (both included).

Example
Input:  1,3,5,6,7,8 Output: 1,2,3,4,5,6,7,8


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//create range, start from number.Min, count up to numbers.Max subtract numbers.Min, then plus 1
//convert to list and return the result.
using System.Collections.Generic;
using System.Linq;

public class Fixer{
  public static List<int> PipeFix(List<int> numbers) =>  
    Enumerable.Range(numbers.Min(),numbers.Max() - numbers.Min() + 1).ToList();
}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public class LarioWorld
{
  [Test]
  public void FixThosePipes_t1()
  {
    Assert.AreEqual(new List<int>{1,2,3,4,5,6,7,8,9}, Fixer.PipeFix(new List<int>{1,2,3,5,6,8,9}));    
  }
  
  [Test]
  public void FixThosePipes_t2()
  {
    Assert.AreEqual(new List<int>{1,2,3,4,5,6,7,8,9,10,11,12}, Fixer.PipeFix(new List<int>{1,2,3,12}));
  }
  
  [Test]
  public void FixThosePipes_t3()
  {
    Assert.AreEqual(new List<int>{6,7,8,9}, Fixer.PipeFix(new List<int>{6,9}));
  }
  
  [Test]
  public void SecretNegativeWorld()
  {
    Assert.AreEqual(new List<int>{-1,0,1,2,3,4}, Fixer.PipeFix(new List<int>{-1,4}));
  }
  [Test]
  public void LengthOfOne()
  {
    Assert.AreEqual(new List<int>{2}, Fixer.PipeFix(new List<int>{2}));    
  }
  
  [Test]
  public static void RandomTest([Random(0,49,10)]int min, [Random(50,100,10)]int max)
  {
    List<int> pipes = new List<int>{ min, max };
    Assert.AreEqual(Solution(pipes), Fixer.PipeFix(pipes), string.Format("Should work for {0}", string.Join(", ", pipes)));
  }
  
  private static List<int> Solution(List<int> pipes)
  {
    return Enumerable.Range(pipes.Min(), pipes.Max()+1 - pipes.Min()).ToList();
  }
}
