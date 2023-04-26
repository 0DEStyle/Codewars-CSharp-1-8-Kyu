/*Challenge link:https://www.codewars.com/kata/559f44187fa851efad000087/train/csharp
Question:
Write a function that removes every lone 9 that is inbetween 7s.

"79712312" --> "7712312"
"79797"    --> "777"

*/

//***************Solution********************
//replace 797 to 77, twice
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
	public static string SevenAteNine(string str) =>str.Replace("797","77").Replace("797","77");
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class KataTests 
{	
  [TestCase("165561786121789797","16556178612178977")]
  [TestCase("797","77")]
  [TestCase("7979797","7777")]
  [TestCase("16797","1677")]
  [TestCase("77","77")]
  [TestCase("7927","7927")]
  [TestCase("1779","1779")]
  [TestCase("a779","a779")]
  [TestCase("17797a","1777a")]
  [TestCase("797 9 7","77 9 7")]
  [TestCase("79799997","7799997")]
	public void FixedTests(string input, string expected)
  {
    Assert.That(Kata.SevenAteNine(input), Is.EqualTo(expected));
  }
  
  [Test]
  public void RandomTests()
  {
    var rnd = new Random();
    
  	for (var testCount = 0; testCount < 40; testCount++) 
    {
    	var input = generateSequence(rnd);
      var expected = sevenAteNineSolution(input);
      Assert.AreEqual(Kata.SevenAteNine(input), expected); 
    }
  }
  
  private string generateSequence(Random rnd)
  {
    var len = rnd.Next(1, 16);
    var result = "";
    
    for (var i = 0; i<len; i++) 
    {
      int num = rnd.Next(0, 9);
      result += (num == 7) ? "797" : num.ToString();
    }
    
    return result;
  }
  
  private static string sevenAteNineSolution(string str)
  {
    return str.Replace("797", "77");	
  }
}
