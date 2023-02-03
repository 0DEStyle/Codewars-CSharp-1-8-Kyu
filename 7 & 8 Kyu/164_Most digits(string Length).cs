/*Challenge link:https://www.codewars.com/kata/58daa7617332e59593000006/train/csharp
Question:
Find the number with the most digits.

If two numbers in the argument array have the same number of digits, return the first one in the array.
*/

//***************Solution********************

//compare length of each element in number then find the longest, if both are the same, keep the first one.

using System.Linq;
public class Kata{
  public static int FindLongest(int[] number){
    int mostDit = 0;
    for(int i = 0 ; i < number.Length; i++)
      if(number[i].ToString().Length > mostDit.ToString().Length)
        mostDit = number[i];
    
    return mostDit;
  }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata
{
    public static int FindLongest(int[] N)
    {
        return N.OrderByDescending(X => X.ToString().Length).First();
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(100, Kata.FindLongest(new int[] {1, 10, 100}));
      Assert.AreEqual(9000, Kata.FindLongest(new int[] {9000, 8, 800}));
      Assert.AreEqual(900, Kata.FindLongest(new int[] {8, 900, 500}));
    }
    
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual(40000, Kata.FindLongest(new int[] {3, 40000, 100}));
      Assert.AreEqual(100000, Kata.FindLongest(new int[] {1, 200, 100000}));
      Assert.AreEqual(7000000, Kata.FindLongest(new int[] {7000000, 10, 100}));
    }
    
    private static int Solution(int[] number) => Int32.Parse(number.Select(v => v.ToString()).OrderByDescending(x => x.Length).First());
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int loops = rnd.Next(3, 20);
        List<int> test = new List<int>();
        for (int j = 0; j < loops; ++j)
        {
          test.Add(rnd.Next(0, (int)3e6 + 1));
        }
        int expected = Solution(test.ToArray());
        int actual = Kata.FindLongest(test.ToArray());
        Console.WriteLine("Test: {0}", String.Join(", ", test.Select(x => x.ToString())));
        Console.WriteLine("Expected: {0}", expected);
        Console.WriteLine("Actual: {0}\n", actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
