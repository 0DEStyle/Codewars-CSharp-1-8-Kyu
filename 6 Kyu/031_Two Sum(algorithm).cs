/*Challenge link:https://www.codewars.com/kata/52c31f8e6605bcc646000082/train/csharp
Question:

Write a function that takes an array of numbers (integers for the tests) and a target number. It should find two different items in the array that, when added together, give the target value. The indices of these items should then be returned in a tuple / list (depending on your language) like so: (index1, index2).

For the purposes of this kata, some tests may have multiple answers; any valid solutions will be accepted.

The input will always be valid (numbers will be an array of length 2 or greater, and all of the items will be numbers; target will always be the sum of two different items from that array).

Based on: http://oj.leetcode.com/problems/two-sum/

two_sum([1, 2, 3], 4) == {0, 2}
*/

//***************Solution********************

//solution 1
//brute force testing each element and find the anwser.
public class Kata{
  public static int[] TwoSum(int[] numbers, int target){    
    int i = 0, j = 0;
    
    for( i = 0; i < numbers.Length; i++){
      for( j = i+1; j < numbers.Length; j++){
        if (target == numbers[i] + numbers[j])
             return new int[] {i,j};
      }
    }
    return new int[] {i,j};
  }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata
{
  public static int[] TwoSum(int[] numbers, int target) => numbers.Select((x,i)=>new [] {i, Array.IndexOf(numbers,target-x,i+1)}).First(x => x[1] != -1);
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
      Assert.AreEqual(new [] { 0, 2 }, Kata.TwoSum(new [] { 1, 2, 3 }, 4).OrderBy(a => a).ToArray());
      Assert.AreEqual(new [] { 1, 2 }, Kata.TwoSum(new [] { 1234, 5678, 9012 }, 14690).OrderBy(a => a).ToArray());
      Assert.AreEqual(new [] { 0, 1 }, Kata.TwoSum(new [] { 2, 2, 3 }, 4).OrderBy(a => a).ToArray());
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();      
      
      for (var i = 0; i < 500; i++) 
      {
        int[] numbers = Enumerable.Range(0,10).Select(a => rand.Next(0, 1000)).ToArray();
        int[] expected = new int[] { -1, -1 };

        expected[0] = rand.Next(0, numbers.Length);
  
        do 
        {
          expected[1] = rand.Next(0, numbers.Length);
        }
        while (expected[1] == expected[0]);
  
        if (expected[0] > expected[1]) 
        {
          var temp = expected[0];
          expected[0] = expected[1];
          expected[1] = temp;
        }
  
        var target = numbers[expected[0]] + numbers[expected[1]];

        //Console.WriteLine("numbers = [" + string.Join(", ", numbers) + "], target = " + target);
  
        var result = Kata.TwoSum(numbers.Select(n=>n).ToArray(), target);
        Assert.IsNotNull(result);
        Assert.AreEqual(2, result.Length, "Result should contain 2 values");
        Assert.AreEqual(2, result.Distinct().Count(), "Indices in result should be distinct");
        Assert.AreEqual(target, numbers[result[0]] + numbers[result[1]]);
      }
    }
  }
}
