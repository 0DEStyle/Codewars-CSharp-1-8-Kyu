/*Challenge link:https://www.codewars.com/kata/576cd0e17fdf4645810000bb/train/csharp
Question:
The task is very simple: There is a method that returns numbers. Put 150,000 of these numbers in a string and return this string.

The numbers have to be in the same order as the were delivered by the method.

But there is a problem. You have to do this very quick. Besides, the content will be asserted, there is also a time measurement. If your code is too slow, your solution is not valid. But don't be afraid, the time measurement uses 20 runs and uses the average. Also the allowed time will be always calculated on the fly. So also when Code Wars is slow, you should get an comparable result.

This is my first try for Performance Katas. I hope you'll like it.
*/

//***************Solution********************
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/
//150,000
//75,000 x2
//37,500 x4
//meh, times seems to be around the same
using System;
using System.Linq;

public static class Kata{
  public static string Performance(Func<int> method) => 
    string.Concat(Enumerable.Range(0, 150000).Select(x => method())); //2182ms, 2278ms, 2412 ms
    //string.Concat(Enumerable.Repeat(string.Concat(Enumerable.Range(0, 37500).Select(x => method())), 4)); // 2348ms, 2392ms
}

//solution 2
using System;
using System.Text;

public static class Kata
{
  public static string Performance(Func<int> method)
  { 
    StringBuilder sb1 = new StringBuilder();
    for(int i=0;i<150000;i++)
    {
      sb1.Append(method().ToString());
    }
    return sb1.ToString();
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class ComparingTests
{
  private Random rand = new Random();
  
  private StringBuilder sb = new StringBuilder();
  
  private Stopwatch sw = new Stopwatch();
  
  private int getRandomValue()
  {
    var i = rand.Next(0,9); 
    sb.Append(i.ToString());
    return i;
  }
  
  private string fastMethod(Func<int> method)
  { 
    StringBuilder sb1 = new StringBuilder();
    for(int i=0;i<150000;i++)
    {
      sb1.Append(method().ToString());
    }
    return sb1.ToString();
  }
  
  [Test]
  public void PerformanceTest()
  {
    int numberTrys = 20;
    List<long> elapsed = new List<long>();
    for (int i=0;i<numberTrys;i++)
    {
      sb.Clear();
      sw.Restart();
      var test = fastMethod(getRandomValue);
      sw.Stop();
      test.ToString();
      elapsed.Add(sw.ElapsedMilliseconds);
    }
        
    Console.WriteLine("My best value from " + numberTrys + " trys : " + elapsed.Min() + " ms");
    Console.WriteLine("My worst value from " + numberTrys + " trys: " + elapsed.Max() + " ms");
    Console.WriteLine("My mean value from " + numberTrys + " trys:  " + elapsed.Average() + " ms");
    
    var maxAllowedElapsed = (int) (Math.Ceiling(elapsed.Average() * 1.02) + 1);
    Console.WriteLine();
    Console.WriteLine("Allowed Value for your mean value: " + (maxAllowedElapsed - 1) + " ms");    
    Console.WriteLine();

    string actual = "";
    string expected = "";
    List<long> testElapsed = new List<long>();
    for(int i=0;i<numberTrys;i++)
    {
      sb.Clear();
      sw.Restart();
      actual = Kata.Performance(getRandomValue);
      sw.Stop();
      testElapsed.Add(sw.ElapsedMilliseconds);
      expected = sb.ToString();
    }
    
    Console.WriteLine("Your best value from " + numberTrys + " trys : " + testElapsed.Min() + " ms");
    Console.WriteLine("Your worst value from " + numberTrys + " trys: " + testElapsed.Max() + " ms");
    Console.WriteLine("Your mean value from " + numberTrys + " trys:  " + testElapsed.Average() + " ms");
    
    Assert.AreEqual(150000, actual.Length, "Wrong length of your string.");
    Assert.AreEqual(150000, expected.Length, "You didn't call the method 150000 times!");
    
    for(int i=0; i<100; i++)
    {
      int position = rand.Next(0, expected.Length-1);
      Assert.AreEqual(expected[position], actual[position], "The content of the string is not correct. You have to use the method.");    
    }
    
    Assert.Less(testElapsed.Average(), maxAllowedElapsed, "Your Code is not fast enough! (values in ms)");    
  }  
}
