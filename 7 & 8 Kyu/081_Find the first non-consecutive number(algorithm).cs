/*Challenge link:https://www.codewars.com/kata/58f8a3a27a5c28d92e000144/train/csharp
Question:
Your task is to find the first element of an array that is not consecutive.

By not consecutive we mean not exactly 1 larger than the previous element of the array.

E.g. If we have an array [1,2,3,4,6,7,8] then 1 then 2 then 3 then 4 are all consecutive but 6 is not, so thats the first non-consecutive number.

If the whole array is consecutive then return null2.

The array will always have at least 2 elements1 and all elements will be numbers. The numbers will also all be unique and in ascending order. The numbers could be positive or negative and the first non-consecutive could be either too!

If you like this Kata, maybe try this one next: https://www.codewars.com/kata/represent-array-of-numbers-as-ranges

1 Can you write a solution that will return null2 for both [] and [ x ] though? (This is an empty array and one with a single number and is not tested for, but you can write your own example test. )

2
Swift, Ruby and Crystal: nil
Haskell: Nothing
Python, Rust, Scala: None
Julia: nothing
Nim: none(int) (See options)
*/

//***************Solution********************

//solution 1
//compare current element with the next element, loop until the last element -1
//if the difference is equal to 1, return the next element, else return null
public class Kata
{
  public static object FirstNonConsecutive(int[] arr){
    for(int i  = 0; i < arr.Length-1; i++){
    if(arr[i] != arr[i + 1] -1) 
      return arr[i+1];
    }
    return null;
}
  }
  
  //solution 2
  //same as above
  //Then simiplfied into one line by using an Lambda expression with Enumerable methods.
  using System.Linq;

public class Kata
{
  public static object FirstNonConsecutive(int[] arr) => arr.Cast<int?>().Skip(1).FirstOrDefault(i => i != ++arr[0]);
}

//or

using System.Linq;

public class Kata
{
  public static object FirstNonConsecutive(int[] a) => a.Skip(1).SkipWhile((x,i) => x == ++a[i]).Cast<int?>().FirstOrDefault();
}

//****************Sample Test*****************

namespace Solution {
  using NUnit.Framework;
  using System.Collections.Generic;
  using System.Linq;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SimpleTest()
    {
      Assert.AreEqual(6, Kata.FirstNonConsecutive(new int[] {1, 2, 3, 4, 6, 7, 8}));
    }
    
    [Test]
    public void ZeroTest()
    {
      Assert.AreEqual(0, Kata.FirstNonConsecutive(new int[] {-3, -2, 0, 1, 2}));
    }
    
    [Test]
    public void NegativeTest()
    {
      Assert.AreEqual(-1, Kata.FirstNonConsecutive(new int[] {-3, -1, 0, 1, 2}));
    }
    
    [Test]
    public void SequentialTest()
    {
      Assert.AreEqual(null, Kata.FirstNonConsecutive(new int[] {1, 2, 3, 4}));
    }
    
    private static object Solution(int[] arr)
    {
      for (int i = 0; i < arr.Length; ++i)
      {
        if (i + 1 == arr.Length) break;
      
        if (arr[i] + 1 != arr[i + 1])
        {
          return arr[i + 1];
        }
      }
      return null;
    }
    
    private Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 10; ++i)
      {
        List<int> testList = new List<int>();
        int offset = rnd.Next(0, 20) - 10;
        for (int j = 0; j < 20; ++j)
        {
          testList.Add(offset + (rnd.Next(0, 9)));
        }
        testList.Sort((a, b) => a - b);
        testList = testList.Distinct().ToList();
        Console.WriteLine(string.Join(", ", testList.ToArray()));
        object first = Kata.FirstNonConsecutive(testList.ToArray());
        object expected = Solution(testList.ToArray());
        
        Assert.AreEqual(expected, first);
      }
    }
  }
}
