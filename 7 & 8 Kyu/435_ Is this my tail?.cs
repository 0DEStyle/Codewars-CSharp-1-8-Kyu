/*Challenge link:https://www.codewars.com/kata/56f695399400f5d9ef000af5/train/csharp
Question:
Some new animals have arrived at the zoo. The zoo keeper is concerned that perhaps the animals do not have the right tails. To help her, you must correct the broken function to make sure that the second argument (tail), is the same as the last letter of the first argument (body) - otherwise the tail wouldn't fit!

If the tail is right return true, else return false.

The arguments will always be non empty strings, and normal letters.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression


//check if body ends with tail.

public class Kata{
  public static bool CorrectTail(string body, string tail) => body.EndsWith(tail);
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("Fox", "x").Returns(true);
        yield return new TestCaseData("Rhino", "o").Returns(true);
        yield return new TestCaseData("Meerkat", "t").Returns(true);
        yield return new TestCaseData("Emu", "t").Returns(false);
        yield return new TestCaseData("Badger", "s").Returns(false);
        yield return new TestCaseData("Giraffe", "d").Returns(false);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public bool Test(string body, string tail) => Kata.CorrectTail(body, tail);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static bool solution(string body, string tail) =>
      tail == body.Substring(body.Length - 1);
      
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string body = String.Concat(new char[rnd.Next(3, 20)].Select(_ => (char)rnd.Next(97, 123)));
        string tail = (rnd.Next(0, 2) == 0 ? body[body.Length - 1] : (char)rnd.Next(97, 123)).ToString();
        
        bool expected = solution(body, tail);
        bool actual = Kata.CorrectTail(body, tail);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
