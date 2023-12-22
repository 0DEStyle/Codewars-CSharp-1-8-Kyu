/*Challenge link:https://www.codewars.com/kata/50654ddff44f800200000007/train/csharp
Question:
Given 2 strings, a and b, return a string of the form short+long+short, with the shorter string on the outside and the longer string on the inside. The strings will not be the same length, but they may be empty ( zero length ).

Hint for R users:

The length of string is not always the same as the number of characters
For example: (Input1, Input2) --> output

("1", "22") --> "1221"
("22", "1") --> "1221"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression

//compare length and return result accordingly
public class ShortLongShort{
  public static string Solution(string a, string b) => a.Length > b.Length ? b + a + b : a + b + a;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class SolutionTests
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("abba", ShortLongShort.Solution("a", "bb"));
      Assert.AreEqual("baab", ShortLongShort.Solution("aa", "b"));
    
      Assert.AreEqual("1221", ShortLongShort.Solution("1", "22"));
      Assert.AreEqual("1221", ShortLongShort.Solution("22", "1"));
      Assert.AreEqual("12321", ShortLongShort.Solution("232", "1"));
      Assert.AreEqual("232", ShortLongShort.Solution("232", ""));
      Assert.AreEqual("2322132232", ShortLongShort.Solution("232", "2132"));
    }
    
    [Test]
    public void RandomTest()
    {
      var rand = new Random();
      for(int i = 0 ; i < 10 ; i++)
      {
        var length1 = rand.Next(0,10);
        int length2 = -1;
        do
        {
          length2 = rand.Next(0,10);
        }
        while(length1 == length2);
        
        var string1 = string.Concat(Enumerable.Range(0, length1).Select(o => new string((char)rand.Next(48,90), 1)));
        var string2 = string.Concat(Enumerable.Range(0, length2).Select(o => new string((char)rand.Next(48,90), 1)));
        
        var shortString = string1.Length < string2.Length ? string1 : string2;
        var longString = string1.Length > string2.Length ? string1 : string2;
  
        var expected = shortString + longString + shortString;
        
        Assert.AreEqual(expected, ShortLongShort.Solution(string1, string2)); 
      }
    }
  }
}
