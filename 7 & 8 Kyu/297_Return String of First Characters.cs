/*Challenge link:https://www.codewars.com/kata/5639bdcef2f9b06ce800005b/train/csharp
Question:

In this exercise, a string is passed to a method and a new string has to be returned with the first character of each word in the string.

For example:

"This Is A Test" ==> "TIAT"
Strings will only contain letters and spaces, with exactly 1 space between words, and no leading/trailing spaces.
*/

//***************Solution********************
//slipt the string by space, then get the first letter of each array in the element
//concat the letters together and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public partial class Kata{
  public static string MakeString(string s)=>string.Concat(s.Split(" ").Select(x=> x.Substring(0, 1)));
}

//solution 2
using System.Linq;

public partial class Kata
{
  public static string MakeString(string s)
  {
    return string.Join("", s.Split(' ').Select(x => x[0]));
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
public static class MakeStringTests
{
  [Test]
  [TestCase("sees eyes xray yoat", ExpectedResult="sexy")]
  [TestCase("brown eyes are nice", ExpectedResult="bean")]
  [TestCase("cars are very nice", ExpectedResult="cavn")]
  [TestCase("kaks de gan has a big head", ExpectedResult="kdghabh")]
  public static string TestExample(string s)
  {
    return Kata.MakeString(s);
  }
  
  private static string Solution(string s)
  {
    return string.Join("", s.Split().Select(x => x[0]));
  }
  
  private static string GetRandomString()
  {
    Random r = new Random();
    int length = r.Next(9)+1;
    string alpha = "abcdefghijklmnopqrstuvwxyz";
    string result = string.Empty;
    for(int i = 0; i < length; i++)
    {
      result += alpha[r.Next(26)];
    }
    return result;
  }
  
  [Test]
  public static void RandomTest([Random(1,5,50)]int x)
  {
    string testStr = string.Empty;
    for(int i = 0; i < x; i++)
    {
      testStr += " " + GetRandomString();
    }
    testStr = testStr.Trim();
    
    Assert.AreEqual(Solution(testStr), Kata.MakeString(testStr), string.Format("Should work for \"{0}\"", testStr));
  }
}
