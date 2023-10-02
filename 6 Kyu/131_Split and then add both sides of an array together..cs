/*Challenge link:https://www.codewars.com/kata/5946a0a64a2c5b596500019a/train/csharp
Question:
Inspired by the Fold an Array kata. This one is sort of similar but a little different.

Task
You will receive an array as parameter that contains 1 or more integers and a number n.

Here is a little visualization of the process:

Step 1: Split the array in two:

[1, 2, 5, 7, 2, 3, 5, 7, 8]
      /            \
[1, 2, 5, 7]    [2, 3, 5, 7, 8]
Step 2: Put the arrays on top of each other:

   [1, 2, 5, 7]
[2, 3, 5, 7, 8]
Step 3: Add them together:

[2, 4, 7, 12, 15]
Repeat the above steps n times or until there is only one number left, and then return the array.

Example
Input: arr=[4, 2, 5, 3, 2, 5, 7], n=2


Round 1
-------
step 1: [4, 2, 5]  [3, 2, 5, 7]

step 2:    [4, 2, 5]
        [3, 2, 5, 7]

step 3: [3, 6, 7, 12]


Round 2
-------
step 1: [3, 6]  [7, 12]

step 2:  [3,  6]
         [7, 12]

step 3: [10, 18]


Result: [10, 18]
*/

//***************Solution********************

//Simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

namespace Solution {
  public class Kata {
    //if n is less than 1 or a.length is less than 2, return a
    //else from array a, take a.length/2
    //prepend, add 0 to the beginning
    //skip 1 - a.length % 2
    //then Zip with a.Skip(a.Length /2), where x is first element y is second element
    //convert to array, now accumulate by recurssively calling SplitAndAdd, n - 1
    public static int[] SplitAndAdd(int[] a, int n) => 
      n < 1 || a.Length < 2 ? a :
      SplitAndAdd(a.Take(a.Length / 2).Prepend(0)
                                    .Skip(1 - a.Length % 2)
                                    .Zip(a.Skip(a.Length / 2), (x,y) => x + y).ToArray(), n - 1);
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    Random r = new Random();
  
    [Test]
    public void SplitAndAdd()
    {
      int[] expected = new int[]{5,10};
      int[] input = Kata.SplitAndAdd(new int[]{1,2,3,4,5},2);

      Assert.AreEqual(expected, input);

      expected = new int[]{15};
      input = Kata.SplitAndAdd(new int[]{1,2,3,4,5},3);

      Assert.AreEqual(expected, input);
      
      expected = new int[]{15};
      input = Kata.SplitAndAdd(new int[]{15},3);

      Assert.AreEqual(expected, input);
      
      expected = new int[]{183, 125};
      input = Kata.SplitAndAdd(new int[]{32,45,43,23,54,23,54,34},2);

      Assert.AreEqual(expected, input);
      
      expected = new int[]{32,45,43,23,54,23,54,34};
      input = Kata.SplitAndAdd(new int[]{32,45,43,23,54,23,54,34},0);

      Assert.AreEqual(expected, input);

      expected = new int[]{305, 1195};
      input = Kata.SplitAndAdd(new int[]{3,234,25,345,45,34,234,235,345},3);

      Assert.AreEqual(expected, input);

      expected = new int[]{1040, 7712};
      input = Kata.SplitAndAdd(new int[]{3,234,25,345,45,34,234,235,345,34,534,45,645,645,645,4656,45,3},4);

      Assert.AreEqual(expected, input);
      
      expected = new int[]{79327};
      input = Kata.SplitAndAdd(new int[]{23,345,345,345,34536,567,568,6,34536,54,7546,456},20);
      
      Assert.AreEqual(expected, input);
    }
    
    [Test]
    public void RandTest() {
      for(int i = 0; i <= 100; i++) {
        int[] randomArr = RandomArr();
        int iterations = r.Next(5) + 1;
        Assert.AreEqual(Solve(randomArr, iterations), Kata.SplitAndAdd(randomArr, iterations));
      }
    }
    
    
    private int[] RandomArr() {
      int[] toReturn = new int[r.Next(100) + 1];
      for (int i = 0; i < toReturn.Length; i++) {
        toReturn[i] = r.Next(100);
      }

      return toReturn;
    }
    
    private int[] Solve(int[] numbers, int n) {
      if (n == 0 || numbers.Length == 1)
        return numbers;
      
      int[] newnums = new int[(numbers.Length + 1) / 2];
      for (int i = 0; i < numbers.Length; i++)
        newnums[(numbers.Length % 2 == 0 ? i : i+1) % newnums.Length] += numbers[i];
        
      return Solve(newnums, n-1);
    }
  }
}
