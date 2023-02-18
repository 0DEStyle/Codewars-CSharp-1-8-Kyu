/*Challenge link:https://www.codewars.com/kata/57eae65a4321032ce000002d/train/csharp
Question:
Given a string of digits, you should replace any digit below 5 with '0' and any digit 5 and above with '1'. Return the resulting string.

Note: input will never be an empty string
*/

//***************Solution********************
//if the letter is less thn '5', convert to '0' else '1', concat the the characters and result the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static string FakeBin(string x) => String.Concat(x.Select(c=>c < '5' ? '0' : '1'));
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
      Assert.AreEqual("01011110001100111", Kata.FakeBin("45385593107843568"));
      Assert.AreEqual("101000111101101", Kata.FakeBin("509321967506747"));
      Assert.AreEqual("011011110000101010000011011", Kata.FakeBin("366058562030849490134388085"));
      Assert.AreEqual("01111100", Kata.FakeBin("15889923"));
      Assert.AreEqual("100111001111", Kata.FakeBin("800857237867"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for (var i=0;i<100;i++)
      {        
        var len = rand.Next(1,30);
        
        var x = String.Concat(Enumerable.Range(0,len).Select(a => rand.Next(0,10).ToString()).ToArray());
  
        var expected = string.Concat(x.Select(a => a < '5' ? "0" : "1"));;
        Assert.AreEqual(expected, Kata.FakeBin(x));
      }
    }
  }
}
