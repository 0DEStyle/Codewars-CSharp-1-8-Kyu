/*Challenge link:https://www.codewars.com/kata/563e320cee5dddcf77000158/train/csharp
Question:
It's the academic year's end, fateful moment of your school report. The averages must be calculated. All the students come to you and entreat you to calculate their average for them. Easy ! You just need to write a script.

Return the average of the given array rounded down to its nearest integer.

The array will never be empty.
*/

//***************Solution********************
//sum of marks divide by amount of elements in marks.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int GetAverage(int[] marks) => marks.Sum() / marks.Length;
}

//solution 2
using System.Linq'
using System;

public class Kata
{
  public static int GetAverage(int[] marks) => (int)marks.Average();
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

public class Tests
{
  [Test]
  [TestCase(new int[]{2,2,2,2}, ExpectedResult= 2)]
  [TestCase(new int[]{5,10}, ExpectedResult= 7)]
  public static int FixedTest(int[] marks)
  {
    return Kata.GetAverage(marks);
  }
  
  private static int Solution(int[] marks)
  {
    return (int)Math.Floor(new List<int>(marks).Average());
  }
  
  [Test]
  public static void RandomTest([Random(1,10,98)]int x)
  {
    List<int> l = new List<int>();
    Random r = new Random();
    for(int i = 0; i < x; i++)
    {
      l.Add(r.Next(100)+1);
    }
    int[] arr = l.ToArray();
    Assert.AreEqual(Solution(arr), Kata.GetAverage(arr), string.Format("Should work for {0}", string.Join(", ",l.ToArray())));
  }
}
