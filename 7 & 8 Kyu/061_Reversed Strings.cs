/*Challenge link: https://www.codewars.com/kata/5168bb5dfe9a00b126000018/train/csharp
Question:
Complete the solution so that it reverses the string passed into it.

'world'  =>  'dlrow'
'word'   =>  'drow'
*/

//***************Solution********************
//solution 1
//reverse the character one by one, store in string, then join and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata
{
  public static string Solution(string str) => string.Join("", str.Reverse().Select(x => x.ToString()).ToArray());
}

//solution 2
using System;
using System.Linq;
public static class Kata
{
  public static string Solution(string str) 
  {
    return string.Concat(str.Reverse());
  }
}

//solution 3
using System;
using System.Linq;

public static class Kata
{
  public static string Solution(string str) 
  {
     return new string(str.ToArray().Reverse().ToArray());
  }
}


//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class Tests
  {
    private static Random rnd = new Random();
  
    private static string solution(string str) => String.Concat(str.Reverse());
    
    private static string chars = "abcdefghijklmnopqrstuvwxyz    ,./';123456789!?";
  
    [Test]
    public void SubmitTests()
    {
      Assert.AreEqual("dlrow", Kata.Solution("world"));
      Assert.AreEqual("olleh", Kata.Solution("hello"));
      Assert.AreEqual("", Kata.Solution(""));
      Assert.AreEqual("h", Kata.Solution("h"));
      Assert.AreEqual("selur srawedoC", Kata.Solution("Codewars rules"));
    }
    
    [Test]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string str = String.Concat(new char[rnd.Next(1, 100)].Select(_ => chars[rnd.Next(0, chars.Length)]));
        
        string expected = solution(str);
        string actual = Kata.Solution(str);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
