/*Challenge link:https://www.codewars.com/kata/5b4e779c578c6a898e0005c5/train/csharp
Question:
Given a number n, draw stairs using the letter "I", n tall and n wide, with the tallest in the top left.

For example n = 3 result in:

"I\n I\n  I"
or printed:

I
 I
  I
Another example, a 7-step stairs should be drawn like this:

I
 I
  I
   I
    I
     I
      I
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//start from 1, count up to n, generate element of "I" PadLeft
//join the string together with '\n' and return the result.
using System.Linq;

public class Kata{
  public static string DrawStairs(int n) => string.Join('\n', Enumerable.Range(1, n).Select("I".PadLeft));
}

//solution 2
public class Kata
{
  public static string DrawStairs(int n)
  {
    var result = "";
    for (int i = 1; i < n; i++)
    {
        result += "I\n" + new string(' ', i);
    }
            
    return result + "I";
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;

namespace Solution
{
  [TestFixture]
  public class SolutionTest
  {
    const int RANDOM_TESTS_COUNT = 100;
    const int RANDOM_TESTS_MAX_N = 500;
  
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual("I", Kata.DrawStairs(1));
      Assert.AreEqual("I\n I", Kata.DrawStairs(2));
      Assert.AreEqual("I\n I\n  I", Kata.DrawStairs(3));
      Assert.AreEqual("I\n I\n  I\n   I", Kata.DrawStairs(4));
    }
  
    [Test]
    public void RandomTests()
    {
      for (int i = 0; i < RANDOM_TESTS_COUNT; i++)
      {
        int n = new Random().Next(RANDOM_TESTS_MAX_N);
        
        Assert.AreEqual(DrawStairs(n), Kata.DrawStairs(n));
      }
    }
    
    private string DrawStairs(int n)
    {
      string str = "";
    
      for (int i = 0; i < n; i++) {
        str += new String(' ', i) + "I";
        
        if (i < n-1) str += "\n";
      }
    
      return str;
    }
  }
}
