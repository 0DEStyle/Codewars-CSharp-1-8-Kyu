/*Challenge link:https://www.codewars.com/kata/596f72bbe7cd7296d1000029/train/csharp
Question:
You are given an array. Complete the function that returns the number of ALL elements within an array, including any nested arrays.

Examples
[]                   -->  0
[1, 2, 3]            -->  3
["x", "y", ["z"]]    -->  4
[1, 2, [3, 4, [5]]]  -->  7
The input will always be an array.
*/

//***************Solution********************

//if object a is an object array, then get arr length and add it to the total sum of deepcount,
//else return 0;
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Kata{
  public static int DeepCount(object a) => a is object[] arr ? arr.Length + arr.Sum(DeepCount) : 0;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[]
      {
        new object[] {},
        0
      },
      new object[]
      {
        new object[] {1, 2, 3},
        3
      },
      new object[]
      {
        new object[] {"x", "y", new object[] {"z"}},
        4
      },
      new object[]
      {
        new object[] {1, 2, new object[] {3, 4, new object[] {5}}},
        7
      },
      new object[]
      {
        new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] { new object[] {}}}}}}}}},
        8
      }
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Tests(object test, int expected)
    {
      Assert.AreEqual(expected, Kata.DeepCount(test), $"Expected {expected}");
    }
    
    private static int solution(object a)
    {
      int count = 0;
      object[] b = (object[])a;
      
      for (int i = 0; i < b.Length; ++i)
      {
        if (b[i] is Array) { count += solution(b[i]); }
        ++count;
      }
      
      return count;
    }
    
    private static Random rnd = new Random();
    
    private static object multiArrayGenerator(int count, int maxDepth)
    {
      List<object> result = new List<object>();
      if (count < maxDepth)
      {
        for (int i = 0; i < 4; ++i)
        {
          double prob1 = rnd.NextDouble(), prob2 = rnd.NextDouble();
          if (prob1 > prob2)
          {
            result.Add(new List<object>());
          }
          else
          {
            result.Add(rnd.Next(0, 30));
          }
          if (result[i] is List<object>)
          {
            List<object> temp = (List<object>)result[i];
            if (temp.Count() == 0)
            {
              temp.Add(multiArrayGenerator(count + 1, maxDepth));
            }
            result[i] = temp;
          }
        }
    
      }
      return recurseToArray(result);
    }
    
    private static object[] recurseToArray(object list)
    {
      List<object> b = (List<object>) list;
      
      for (int i = 0; i < b.Count(); ++i)
      {
        if (b[i] is List<object>) { b[i] = recurseToArray(b[i]); }
      }
      
      return b.ToArray();
    }
    
    [Test, Description("Random Tests")]
    public void Random_Tests()
    {
      for (int i = 0; i < 20; ++i)
      {
        object test = multiArrayGenerator(0, rnd.Next(1, 6));
        int expected = solution(test);
        int actual = Kata.DeepCount(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
