/*Challenge link:https://www.codewars.com/kata/5a262cfb8f27f217f700000b/train/csharp
Question:
In this Kata, you will be given two strings a and b and your task will be to return the characters that are not common in the two strings.

For example:

solve("xyab","xzca") = "ybzc" 
--The first string has 'yb' which is not in the second string. 
--The second string has 'zc' which is not in the first string. 
Notice also that you return the characters from the first string concatenated with those from the second string.

More examples in the tests cases.

Good luck!

Please also try Simple remove duplicates

*/

//***************Solution********************
//check string "a" first, select all unique letters from string "b"
//then do the same with string "b"
//concat both enumerables together using string.Concat
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static string Solve(string a, string b)=>
    string.Concat(a.Where(x=>!b.Contains(x))) + string.Concat(b.Where(x=>!a.Contains(x)));
}
//better method
using System.Linq;

public static class Kata
{
  public static string Solve(string a, string b)
  {
    return string.Concat(a.Where(x => !b.Contains(x)).Concat(b.Where(x => !a.Contains(x))));
  }
}

//clever solution
using static System.Text.RegularExpressions.Regex;

public static class Kata
{
  public static string Solve(string a, string b)
  {
    return Replace(a, $"[{b}]", "") + Replace(b, $"[{a}]", "");
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  public static class Solution
  {
    public static string Solve(string a, string b)
    {
      var intersect = new HashSet<char>(a.Intersect(b));
      return String.Concat((a + b).Where(c => !intersect.Contains(c)));
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.Solve("xyab", "xzca"), Is.EqualTo("ybzc"));
      Assert.That(Kata.Solve("xyabb", "xzca"), Is.EqualTo("ybbzc"));
      Assert.That(Kata.Solve("abcd", "xyz"), Is.EqualTo("abcdxyz"));
      Assert.That(Kata.Solve("xxx", "xzca"), Is.EqualTo("zca"));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        string a = String.Concat(new char[rnd.Next(20, 50)].Select(_ => (char)rnd.Next(97, 123))),
               b = String.Concat(new char[rnd.Next(20, 50)].Select(_ => (char)rnd.Next(97, 123)));
        Assert.That(Kata.Solve(a, b), Is.EqualTo(Solution.Solve(a, b)));
      }
    }
  }
}
