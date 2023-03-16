/*Challenge link:https://www.codewars.com/kata/580755730b5a77650500010c/train/csharp
Question:
Given a string s. You have to return another string such that even-indexed and odd-indexed characters of s are grouped and groups are space-separated (see sample below)

Note: 
0 is considered to be an even index. 
All input strings are valid with no spaces
input: 'CodeWars'
output 'CdWr oeas'

S[0] = 'C'
S[1] = 'o'
S[2] = 'd'
S[3] = 'e'
S[4] = 'W'
S[5] = 'a'
S[6] = 'r'
S[7] = 's'
Even indices 0, 2, 4, 6, so we have 'CdWr' as the first group
odd ones are 1, 3, 5, 7, so the second group is 'oeas'
And the final string to return is 'Cdwr oeas'
*/

//***************Solution********************
//select all characters with even index number, and select all character with odd index number
//concat each group and join by a space using string interpolation.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static string SortMyString(string s) =>
    $"{string.Concat(s.Where((item,index) => index % 2 == 0))} {string.Concat(s.Where((item,index) => index % 2 != 0))}";
} 

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Text;

  [TestFixture]
  public class Sample_Tests
  {
    private static object[] testCases = new object[]
    {
      new object[] {"CodeWars", "CdWr oeas"},
      new object[] {"YCOLUE'VREER", "YOU'RE CLEVER"},
    };
  
    [Test, TestCaseSource("testCases")]
    public void Test(string s, string expected) => Assert.AreEqual(expected, Kata.SortMyString(s));
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static string solution(string s)
    {
      // Stringbuilders for even and odd indexes
      StringBuilder even = new StringBuilder(), odd = new StringBuilder();
      
      // Iterate over string
      for (int i = 0; i < s.Length; ++i)
      {
        if ((i & 1) == 0)
        {
          even.Append(s[i]);
        }
        else
        {
          odd.Append(s[i]);
        }
      }
      
      return even.ToString() + " " + odd.ToString();
    }
  
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        StringBuilder sb = new StringBuilder(rnd.Next(2, 101));
        
        for (int j = 0; j < sb.Capacity; ++j)
        {
          sb.Append(rnd.Next(0, 2) == 0 ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123));
        }
        string test = sb.ToString();
        string expected = solution(test);
        string actual = Kata.SortMyString(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
