/*Challenge link:https://www.codewars.com/kata/57ed56657b45ef922300002b/train/csharp
Question:
The bloody photocopier is broken... Just as you were sneaking around the office to print off your favourite binary code!

Instead of copying the original, it reverses it: '1' becomes '0' and vice versa.

Given a string of binary, return the version the photocopier gives you as a string.

The Office I - Outed
The Office II - Boredeom Score
The Office IV - Find a Meeting Room
The Office V - Find a Chair
*/

//***************Solution********************
//Aggregate each character, if character is 0, change to 1, else keep it as 0
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string Broken(string x) => x.Aggregate("", (s, c) => s + (c == '0' ? '1' : '0'));
}

//meothod 2
using System;
using System.Linq;

public class Kata
{
  public static string Broken(string x)
  {
			return string.Join("", x.Select(c => c == '0' ? '1' : '0'));
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("0", Kata.Broken("1"));
      Assert.AreEqual("01111111010010000001100110111", Kata.Broken("10000000101101111110011001000"));
      Assert.AreEqual("011101", Kata.Broken("100010"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();

      for (var i=0;i<100;i++)
      {
        var len = rand.Next(1,35);
        var x = String.Concat(Enumerable.Range(0, len).Select(a => rand.Next(0,2).ToString()));
        
        var expected = string.Concat(x.Select(a => a == '0' ? '1' : '0'));
        Assert.AreEqual(expected, Kata.Broken(x));
      }
    }
  }
}
