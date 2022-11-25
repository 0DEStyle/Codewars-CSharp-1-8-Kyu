/*Challenge link:https://www.codewars.com/kata/563cf89eb4747c5fb100001b/train/csharp
Question:
The museum of incredible dull things
The museum of incredible dull things wants to get rid of some exhibitions. Miriam, the interior architect, comes up with a plan to remove the most boring exhibitions. She gives them a rating, and then removes the one with the lowest rating.

However, just as she finished rating all exhibitions, she's off to an important fair, so she asks you to write a program that tells her the ratings of the items after one removed the lowest one. Fair enough.

Task
Given an array of integers, remove the smallest value. Do not mutate the original array/list. If there are multiple elements with the same value, remove the one with a lower index. If you get an empty array/list, return an empty array/list.

Don't change the order of the elements that are left.

Examples
* Input: [1,2,3,4,5], output= [2,3,4,5]
* Input: [5,3,2,1,4], output = [5,3,2,4]
* Input: [2,2,1,2,1], output = [2,2,2,1]
*/

//***************Solution********************
//remove the minimum number inside tenary, if true return numbers, else return numbers too
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Collections.Generic;
using System.Linq;

public class Remover{
  public static List<int> RemoveSmallest(List<int> numbers) => 
    numbers.Count > 0 && numbers.Remove(numbers.Min()) ? numbers : numbers;
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class RemoveSmallestTests
{
  private static Random rand = new Random();
  private static void Tester(List<int> argument, List<int> expectedResult)
  {
    CollectionAssert.AreEqual(expectedResult, Remover.RemoveSmallest(argument));
  }
  [Test]
  public static void BasicTests()
  {
    Tester(new List<int>{1, 2, 3, 4, 5},new List<int>{2, 3, 4, 5});
    Tester(new List<int>{5, 3, 2, 1, 4},new List<int>{5, 3, 2, 4});
    Tester(new List<int>{1, 2, 3, 1, 1},new List<int>{2, 3, 1, 1});
    Tester(new List<int>(),new List<int>());
  }
  [Test]
  public static void RandomTests()
  {
    for(int i = 0; i < 100; i++)
    {
      List<int> l = RandomList();
      Tester(l,Answer(l));
    }
  }
  private static List<int> RandomList()
  {
    List<int> list = new List<int> ();
    for(int i = 0; i < rand.Next(15); i++)
    {
      list.Add(rand.Next(400));
    }
    return list;
  }
  private static List<int> Answer(List<int> numbers)
  {
    List<int> answer = numbers.ToList();
    if(answer.Count > 0)
    {
      answer.Remove(answer.Min());
    }
    return answer;
  }
}
