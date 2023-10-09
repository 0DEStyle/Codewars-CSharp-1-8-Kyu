/*Challenge link:https://www.codewars.com/kata/59b7571bbf10a48c75000070/train/csharp
Question:
Task
Write a function that accepts msg string and returns local tops of string from the highest to the lowest.
The string's tops are from displaying the string in the below way:

                                                      3
                              p                     2   4
            g               o   q                 1
  b       f   h           n       r             z
a   c   e       i       m          s          y
      d           j   l             t       x
                    k                 u   w
                                        v
The next top is always 1 character higher than the previous one. For the above example, the solution for the abcdefghijklmnopqrstuvwxyz1234 input string is 3pgb.

When the msg string is empty, return an empty string.
The input strings may be very long. Make sure your solution has good performance.
Check the test cases for more samples.


*/

//***************Solution********************
using System.Text;

public static class Kata{
  public static string Tops(string msg){
    //create new string builder result
    StringBuilder result = new StringBuilder();
    
    //loop in a pattern to insert msg character
    for(int i = 1, x = 0; i < msg.Length; i += 5 + 4 * x, x++)
      result.Insert(0, msg[i]);
    
    return result.ToString();
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;

  public static class Solution
  {
    public static string Tops(string msg)
    {
      StringBuilder result = new StringBuilder();
  
      for (int i = 1; i * (2 * i - 1) < msg.Length ; ++i) 
      { 
        result.Append(msg[i * (2 * i - 1)]); 
      }
      
      return String.Concat(Enumerable.Reverse(result.ToString()));
    }
  }

  [TestFixture]
  public class TopsTest
  {
    [Test, Description("Should work for basic strings")]
    public void BasicTest()
    {
      Assert.AreEqual(String.Empty, Kata.Tops(String.Empty));
      Assert.AreEqual("2", Kata.Tops("12"));
      Assert.AreEqual("3pgb", Kata.Tops("abcdefghijklmnopqrstuvwxyz12345"));
      Assert.AreEqual("M3pgb", Kata.Tops("abcdefghijklmnopqrstuvwxyz1236789ABCDEFGHIJKLMN"));
    }
    
    private static Random rnd = new Random();
    
    public static string MakeStr(int length)
    {
      string chars = "abcdefghijklmnopqrstuvwxyz01234567889ABCDEFGHIJKLMNOPQRSTUVWXYZ";
      StringBuilder sb = new StringBuilder();
      
      for (int i = 0; i < length; ++i)
      {
        sb.Append(chars[rnd.Next(0, chars.Length)]);
      }
      
      return sb.ToString();
    }
    
    [Test, Description("Should work for 100 random strings of 1000 length")]
    public void Random1000Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = MakeStr(1000);
        
        string expected = Solution.Tops(str);
        string actual = Kata.Tops(str);
        
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test, Description("Should work for 100 random strings of 10000 length")]
    public void Random10000Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = MakeStr(10000);
        
        string expected = Solution.Tops(str);
        string actual = Kata.Tops(str);
        
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test, Description("Should work for 100 random strings of 100000 length")]
    public void Random100000Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = MakeStr(100000);
        
        string expected = Solution.Tops(str);
        string actual = Kata.Tops(str);
        
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test, Description("Should work for 100 random strings of 1000000 length")]
    public void Random1000000Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = MakeStr(1000000);
        
        string expected = Solution.Tops(str);
        string actual = Kata.Tops(str);
        
        Assert.AreEqual(expected, actual);
      }
    }

  }
}
