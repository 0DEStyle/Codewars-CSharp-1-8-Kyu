/*Challenge link:https://www.codewars.com/kata/58712dfa5c538b6fc7000569/train/csharp
Question:
Two red beads are placed between every two blue beads. There are N blue beads. After looking at the arrangement below work out the number of red beads.

@ @@ @ @@ @ @@ @ @@ @ @@ @ (red is  @@, blue is @)

Implement count_red_beads(n) (in PHP count_red_beads($n); in Java, Javascript, TypeScript, C, C++ countRedBeads(n)) so that it returns the number of red beads.
If there are less than 2 blue beads return 0.
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static int CountRedBeads(int n)=>n < 2 ? 0 : (n-1)  *2;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  
  public class TestHelpers
  {
    protected Random rnd = new Random();
    
    protected int solution(int n) => n < 2 ? 0 : n * 2 - 2;
  }

  [TestFixture]
  public class SampleTests
  {
    [Test, Description("Basic Tests")]
    public void SampleTest()
    {
      Assert.That(Kata.CountRedBeads(0), Is.EqualTo(0));
      Assert.That(Kata.CountRedBeads(1), Is.EqualTo(0));
      Assert.That(Kata.CountRedBeads(3), Is.EqualTo(4));
      Assert.That(Kata.CountRedBeads(5), Is.EqualTo(8));
    }
  }
  
  [TestFixture]
  public class RandomTests : TestHelpers
  {
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int testCase = rnd.Next(0, 5000);
        int actual = Kata.CountRedBeads(testCase);
        int expected = solution(testCase);
        
        Assert.That(actual, Is.EqualTo(expected), $"Wrong result for n = {testCase}.");
      }
    }
  }
}
