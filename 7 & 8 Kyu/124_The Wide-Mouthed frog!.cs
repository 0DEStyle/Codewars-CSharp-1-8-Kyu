/*Challenge link:https://www.codewars.com/kata/57ec8bd8f670e9a47a000f89/train/csharp
Question:
The wide-mouth frog is particularly interested in the eating habits of other creatures.

He just can''t stop asking the creatures he encounters what they like to eat. But, then he meets the alligator who just LOVES to eat wide-mouthed frogs!

When he meets the alligator, it then makes a tiny mouth.

Your goal in this kata is to create complete the mouth_size method this method takes one argument animal which corresponds to the animal encountered by the frog. If this one is an alligator (case-insensitive) return small otherwise return wide.

*/

//***************Solution********************
//check if the animal string is the equal to "alligator" or "ALLIGATOR", if true return small, else return wide
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata{
  public static string MouthSize(string animal)=> animal == "alligator" || animal == "ALLIGATOR" ? "small" : "wide";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("wide", Kata.MouthSize("toucan"));
      Assert.AreEqual("wide", Kata.MouthSize("ant bear"));
      Assert.AreEqual("small", Kata.MouthSize("alligator"));
    }
    
    private static Random rng = new Random();
    
    private static string[] animals = new string[] {"alligator", "ant bear", "toucan", "tiger", "lion", "giraffe", "longer than an alli"};
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string test = (rng.Next(0, 2) == 0) ? animals[rng.Next(0, animals.Length)] : animals[rng.Next(0, animals.Length)].ToUpper();
        string expected = (test.ToLower() == "alligator") ? "small" : "wide";
        string actual = Kata.MouthSize(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
