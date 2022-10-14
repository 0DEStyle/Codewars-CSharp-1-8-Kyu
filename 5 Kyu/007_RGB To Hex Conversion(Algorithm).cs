/*Challenge link:https://www.codewars.com/kata/513e08acc600c94f01000001/train/csharp
Question:
The rgb function is incomplete. Complete it so that passing in RGB decimal values will result in a hexadecimal representation being returned. Valid decimal values for RGB are 0 - 255. Any values that fall out of that range must be rounded to the closest valid value.

Note: Your answer should always be 6 characters long, the shorthand with 3 will not work here.

The following are examples of expected output values:

Rgb(255, 255, 255) # returns FFFFFF
Rgb(255, 255, 300) # returns FFFFFF
Rgb(0,0,0) # returns 000000
Rgb(148, 0, 211) # returns 9400D3
*/

//***************Solution********************

//Solution 1
//check max and min condition, then convert the number into hex, X2 means Hex letter in capital, 2 digits placement only. 
//return the result in string.

public class Kata
{
  public static string Rgb(int r, int g, int b) 
  {
    if(r > 255) r = 255;
    if(r < 0) r = 0;

    if (g > 255) g = 255;
    if (g < 0) g = 0;

    if (b > 255) b = 255;
    if (b < 0) b = 0;
    
    return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
  }
}

//Solution 2
//same as above
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static string Rgb(int r, int g, int b) =>
             $"{(r > 255 ? 255 : r < 0 ? 0 : r):X2}" + 
             $"{(g > 255 ? 255 : g < 0 ? 0 : g):X2}" +
             $"{(b > 255 ? 255 : b < 0 ? 0 : b):X2}";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

namespace Solution
{
  [TestFixture]
  public class KataTests 
  {
    [Test]
    public void FixedTests() 
    {
      Assert.AreEqual("FFFFFF", Kata.Rgb(255,255,255));
      Assert.AreEqual("FFFFFF", Kata.Rgb(255,255,300));
      Assert.AreEqual("000000", Kata.Rgb(0,0,0));
      Assert.AreEqual("9400D3", Kata.Rgb(148,0,211));
      Assert.AreEqual("9400D3", Kata.Rgb(148,-20,211), "Handle negative numbers.");
      Assert.AreEqual("90C3D4", Kata.Rgb(144,195,212));
      Assert.AreEqual("D4350C", Kata.Rgb(212,53,12), "Consider single hex digit numbers.");
    }
    
    private static Random rnd = new Random();
    
    private static string rgb(int r, int g, int b) 
    {
      return hex(r) + hex(g) + hex(b);
    }
    
    private static string hex(int n) 
    {
      n = n < 0 ? 0 : n > 255 ? 255 : n;
      return (n < 16 ? "0" : "") + n.ToString("X");
    }
    
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < 100; ++i)
      {
        int r = rnd.Next(-50, 400);
        int g = rnd.Next(-50, 400);
        int b = rnd.Next(-50, 400);
        Console.WriteLine("Testing for {0}, {1}, {2}", r, g, b);
        
        string expected = rgb(r, g, b);
        string actual = Kata.Rgb(r, g, b);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
