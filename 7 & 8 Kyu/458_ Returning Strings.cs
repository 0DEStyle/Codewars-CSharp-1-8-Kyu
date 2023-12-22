/*Challenge link:https://www.codewars.com/kata/55a70521798b14d4750000a4/train/csharp
Question:
Make a function that will return a greeting statement that uses an input; your program should return, "Hello, <name> how are you doing today?".

[Make sure you type the exact thing I wrote or the program may not execute properly]
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//string interpolation then return result.

public static class Kata{
  public static string Greet(string name) => $"Hello, {name} how are you doing today?";
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
    public static Random rnd = new Random();
  
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.Greet("Ryan"), Is.EqualTo("Hello, Ryan how are you doing today?"));
    }
    
    private static string randStr()
    {
      int len = rnd.Next(10, 50);
      return String.Concat(new char[len].Select(_ => (char)(rnd.Next(0, 25) + 97)));
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string testCase = randStr();
        Assert.That(Kata.Greet(testCase), Is.EqualTo($"Hello, {testCase} how are you doing today?"));
      }
    }
  }
}
