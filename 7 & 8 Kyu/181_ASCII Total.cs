/*Challenge link:https://www.codewars.com/kata/572b6b2772a38bc1e700007a/train/csharp
Question:
You'll be given a string, and have to return the sum of all characters as an int. The function should be able to handle all printable ASCII characters.

Examples:

uniTotal("a") == 97
uniTotal("aaa") == 291
*/

//***************Solution********************
//convert the letter to int and sum. Then return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int UniTotal(string s) => s.Sum(x=>(int)x);
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
    private static Random rnd = new Random();
  
    [Test, Description("An empty string should return zero")]
    public void ZeroTest()
    {
      Assert.AreEqual(0, Kata.UniTotal(""));
    }
    
    [Test, Description("Should work with single letters")]
    public void SingleTest()
    {
      Assert.AreEqual(97, Kata.UniTotal("a"));
      Assert.AreEqual(98, Kata.UniTotal("b"));
      Assert.AreEqual(99, Kata.UniTotal("c"));
      Assert.AreEqual(100, Kata.UniTotal("d"));
      Assert.AreEqual(101, Kata.UniTotal("e"));
    }
    
    [Test, Description("Should work with multiple letters")]
    public void MultipleTest()
    {
      Assert.AreEqual(291, Kata.UniTotal("aaa"));
    }
    
    [Test, Description("Should work with sentence and spaces")]
    public void SentenceTest()
    {
      Assert.AreEqual(1873, Kata.UniTotal("Mary Had A Little Lamb"));
    }
    
    [Test, Description("Should work for random inputs")]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Concat(new char[rnd.Next(0, 1001)].Select(_ => (char)rnd.Next(1, 65536)));
        
        int expected = test.Sum(c => (int)c);
        int actual = Kata.UniTotal(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
