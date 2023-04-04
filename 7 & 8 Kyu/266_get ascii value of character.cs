/*Challenge link:
Question:
Get ASCII value of a character.

For the ASCII table you can refer to http://www.asciitable.com/
*/

//***************Solution********************
//convert char to int
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static int GetASCII(char c)=> (int)c;
}

//solution 2
using System;

public static class Kata
{
  public static int GetASCII(char c)
  {
    return c;
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.GetASCII('A'), Is.EqualTo(65));
      Assert.That(Kata.GetASCII(' '), Is.EqualTo(32));
      Assert.That(Kata.GetASCII('!'), Is.EqualTo(33));
    }
    
    [Test]
    public void ExtendedTest()
    {
      for (char c = (char)32; c < 128; ++c)
      {
        Assert.That(Kata.GetASCII(c), Is.EqualTo((int)c));
      }
    }
  }
}
