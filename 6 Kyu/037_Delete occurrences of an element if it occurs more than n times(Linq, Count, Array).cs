/*Challenge link:https://www.codewars.com/kata/554ca54ffa7d91b236000023/train/csharp
Question:
Enough is enough!
Alice and Bob were on a holiday. Both of them took many pictures of the places they''ve been, and now they want to show Charlie their entire collection. However, Charlie doesn't like these sessions, since the motif usually repeats. He isn't fond of seeing the Eiffel tower 40 times.
He tells them that he will only sit for the session if they show the same motif at most N times. Luckily, Alice and Bob are able to encode the motif as a number. Can you help them to remove numbers such that their list contains each number only up to N times, without changing the order?

Task
Given a list and a number, create a new list that contains each number of list at most N times, without reordering.
For example if the input number is 2, and the input list is [1,2,3,1,2,1,2,3], you take [1,2,3,1,2], drop the next [1,2] since this would lead to 1 and 2 being in the result 3 times, and then take 3, which leads to [1,2,3,1,2,3].
With list [20,37,20,21] and number 1, the result would be [20,37,21].
*/

//***************Solution********************
//in arr,
//looping through each element, if b is the same as element a(index + 1), meaning checking each number one by one
//then if that number is less than or grater than x(the set number). return the result in array.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata {
  public static int[] DeleteNth(int[] arr, int x) => arr.Where((a,i)=>arr.Take(i+1).Count(b=>b==a) <= x).ToArray();
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class DeleteNthTests
{
  const int TESTS = 20;
  const int MOTIVES = 10;

  [Test]
  public void TestRandom()
  {
    List<int[]> tests = new List<int[]>();
    Random rand = new Random();

    for(var x = 0; x < TESTS; x++) {
      int[] motives = new int[MOTIVES];

      for(var y = 0; y < MOTIVES; y++) {
        motives[y] = rand.Next(3)+1;
      }

      tests.Add(motives);
    }

    foreach(var test in tests) {
      int max = rand.Next(3)+1;
      var expected = Solve(test, max);
      var actual = Kata.DeleteNth(test, max);
      
      Console.WriteLine(
        String.Format("([{0}], {1}) \n-  Expected: {2} Actual: {3}",
          String.Join(",", test),
          max,
          String.Join(",", expected),
          String.Join(",", actual)));
      
      CollectionAssert.AreEqual(expected, actual);
    }
  }

  private static int[] Solve(int[] arr, int x) {
    var cache = new System.Collections.Generic.Dictionary<int, int>();

    return arr.Where(n => {
      int count = cache.ContainsKey(n) ? cache[n] : 0;
      cache[n] = count + 1;
      return cache[n] <= x;
    }).ToArray();
  }
}
