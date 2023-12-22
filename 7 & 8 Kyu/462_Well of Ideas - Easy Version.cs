/*Challenge link:https://www.codewars.com/kata/57f222ce69e09c3630000212/train/csharp
Question:
For every good kata idea there seem to be quite a few bad ones!

In this kata you need to check the provided array (x) for good ideas 'good' and bad ideas 'bad'. If there are one or two good ideas, return 'Publish!', if there are more than 2 return 'I smell a series!'. If there are no good ideas, as is often the case, return 'Fail!'.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check conditions and return result accordingly
using System.Linq;
public class Kata{
  public static string Well(string[] arr) => 
    arr.Count(x => x == "good") > 2 ? "I smell a series!" : 
    arr.Count(x => x == "good") >= 1 ? "Publish!" : "Fail!";
}

//solution 2
using System.Linq;

public class Kata
{
  public static string Well(string[] x)
  {
    int count = x.Count(v => v == "good");
    return (count > 2) ? "I smell a series!" : (count >= 1) ? "Publish!" : "Fail!";
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("Fail!", Kata.Well(new string[] {"bad", "bad", "bad"}));
      Assert.AreEqual("Publish!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad"}));
      Assert.AreEqual("I smell a series!", Kata.Well(new string[] {"good", "bad", "bad", "bad", "bad", "good", "bad", "bad", "good"}));
    }
    
    private static Random rnd = new Random();
    
    private static string Solution(string[] x)
    {
      int count = x.Count(v => v == "good");
      return (count > 2) ? "I smell a series!" : (count >= 1) ? "Publish!" : "Fail!";
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int length = rnd.Next(0, 16);
        string[] test = new string[length];
        for (int j = 0; j < test.Length; ++j)
        {
          test[j] = rnd.Next(0, 6) == 0 ? "good" : "bad";
        }
        string expected = Solution(test);
        string actual = Kata.Well(test);
        Assert.AreEqual(expected, actual, "It should work for random inputs too");
      }
    }
  }
}
