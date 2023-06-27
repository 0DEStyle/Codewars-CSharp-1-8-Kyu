/*Challenge link:https://www.codewars.com/kata/580435ab150cca22650001fb/train/csharp
Question:
Write a function filterLucky/filter_lucky() that accepts a list of integers and filters the list to only include the elements that contain the digit 7.

For example,

ghci> filterLucky [1,2,3,4,5,6,7,68,69,70,15,17]
[7,70,17]
Don't worry about bad input, you will always receive a finite list of integers.
*/

//***************Solution********************
//convert x to string with string interpolation
//check if string contains 7
//if yes, store in arrays and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int[] FilterLucky(int[] x) => x.Where(x=> $"{x}".Contains("7")).ToArray();
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
    public void FixedTests()
    {
      Assert.AreEqual(new int[] {7, 70, 17}, Kata.FilterLucky(new int[] {1, 2, 3, 4, 5, 6, 7, 68, 69, 70, 15, 17}));
      Assert.AreEqual(new int[] {}, Kata.FilterLucky(new int[] {})); 
    }
    
    private static int[] Solution(int[] x)
    {
      return x.Select(v => v.ToString()).Where(v => v.IndexOf("7") != -1).Select(Int32.Parse).ToArray();
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < 40; ++i)
      {
        List<int> test = new List<int>();
        for (int j = 0; j < 10; ++j)
        {
          test.Add(rnd.Next(0, 1000));
        }
        
        Console.WriteLine("Testing for these numbers: {0}", String.Join(", ", test.Select(x => x.ToString())));
        Assert.AreEqual(Solution(test.ToArray()), Kata.FilterLucky(test.ToArray()));
      }
    }
  }
}
