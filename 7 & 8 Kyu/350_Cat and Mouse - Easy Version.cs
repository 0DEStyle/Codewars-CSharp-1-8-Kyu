/*Challenge link:https://www.codewars.com/kata/57ee24e17b45eff6d6000164/train/csharp
Question:
You will be given a string (x) featuring a cat 'C' and a mouse 'm'. The rest of the string will be made up of '.'.

You need to find out if the cat can catch the mouse from it's current position. The cat can jump over three characters. So:

C.....m returns 'Escaped!' <-- more than three characters between

C...m returns 'Caught!' <-- as there are three characters between the two, the cat can jump.
*/

//***************Solution********************
//apply condition
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static string CatMouse(string x) => x.Count(c=>c == '.') <= 3 ? "Caught!" : "Escaped!";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("Escaped!", Kata.CatMouse("C....m"));
      Assert.AreEqual("Caught!", Kata.CatMouse("C..m"));
      Assert.AreEqual("Escaped!", Kata.CatMouse("C.....m"));
      Assert.AreEqual("Caught!", Kata.CatMouse("C.m"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rng = new Random();
      var testInputs = new string[200];
      for (int i = 0; i < 200; i++)
      {
        int dots = rng.Next(0, 8);
        var sb = new StringBuilder();
        sb.Append("C");
        for (int j = 0; j < dots; j++)
        {
          sb.Append(".");
        }
        sb.Append("m");
        
        testInputs[i] = sb.ToString();
      }
      
      foreach(string input in testInputs)
      {
        Assert.AreEqual(this.CatMouse(input), Kata.CatMouse(input));
      }
    }
    
    private string CatMouse(string x)
    {
      return x.Length <= 5 ? "Caught!" : "Escaped!";
    }
  }
}
