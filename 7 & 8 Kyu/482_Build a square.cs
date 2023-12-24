/*Challenge link:https://www.codewars.com/kata/59a96d71dbe3b06c0200009c/train/csharp
Question:
I will give you an integer. Give me back a shape that is as long and wide as the integer. The integer will be a whole number between 1 and 50.

Example
n = 3, so I expect a 3x3 square back just like below as a string:

+++
+++
+++
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//create new string with character '+' repeat n times,
//then repeat the generated string n times again,
//then join each string elements with "\n" and return the result.
using System.Linq;

public static class Kata{
  public static string GenerateShape(int n) =>
    string.Join("\n", Enumerable.Repeat(new string('+',n),n));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("", Kata.GenerateShape(0));
      Assert.AreEqual("+", Kata.GenerateShape(1));
      Assert.AreEqual("++\n++", Kata.GenerateShape(2));
      Assert.AreEqual("+++\n+++\n+++", Kata.GenerateShape(3));
    }
    
    private static Random rnd = new Random();
    
    private static string solution(int n) =>
      String.Join("\n", new string[n].Select(_ => new String('+', n)));
      
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0 ; i < Tests; ++i)
      {
        int n = rnd.Next(0, 50 + 1);
        
        string expected = solution(n);
        string actual = Kata.GenerateShape(n);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
