/*Challenge link:https://www.codewars.com/kata/59d398bb86a6fdf100000031/train/csharp
Question:
I will give you an integer (N) and a string. Break the string up into as many substrings of N as you can without spaces. If there are leftover characters, include those as well.

Example: 

n = 5;

str = "This is an example string";

Return value:
Thisi
sanex
ample
strin
g

Return value as a string: "Thisi"+"\n"+"sanex"+"\n"+"ample"+"\n"+"strin"+"\n"+"g"
*/

//***************Solution********************


//from string str, replace " " with ""
//select element, where x is current element, i is index
//if i is not equal to 0 or i mod n is equal to 0, return "\n" + x, newline + x
//else return x.ToString
//then Concat the elements and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public static class Kata{
  public static string StringBreakers(int n, string str) =>
    string.Concat(str.Replace(" ", "")
                     .Select((x,i) => i != 0 && i % n == 0 ? "\n" + x : x.ToString()));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Text;

  [TestFixture]
  public class SolutionTest
  {
  
    public static string Solution(int n, string str)
    {
      List<string> result = new List<string>();
      str = String.Join("", str.Split(' '));
      
      for (int i = 0; i < str.Length; i += n)
      {
        if (i + n > str.Length) { n = str.Length - i; }
        result.Add(str.Substring(i, n));
      }
      
      return String.Join("\n", result);
    }
  
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("Thisi"+"\n"+"sanex"+"\n"+"ample"+"\n"+"strin"+"\n"+"g", Kata.StringBreakers(5, "This is an example string"));
    }
    
    private static Random rnd = new Random();
    private static string chars = "      abcdefghijklmnopqrstuvwxyz";
    
    private static string randString()
    {
      StringBuilder sb = new StringBuilder();
      int length = rnd.Next(40, 100);
      
      for (int i = 0; i < length; ++i)
      {
        sb.Append(chars[rnd.Next(0, chars.Length)]);
      }
      
      return sb.ToString();
    }
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      Random rnd = new Random();
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = randString();
        int n = rnd.Next(4, 11);
        
        string expected = Solution(n, str);
        string actual = Kata.StringBreakers(n, str);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
