/*Challenge link:https://www.codewars.com/kata/57eadb7ecd143f4c9c0000a3/train/csharp
Question:
Write a function to convert a name into initials. This kata strictly takes two words with one space in between them.

The output should be two capital letters with a dot separating them.

It should look like this:

Sam Harris => S.H

patrick feeney => P.F


*/

//***************Solution********************
//split the string with space
//select the first substring(first letter) of each element
//convert to uppercase and join each element by "."
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata
{
  public static string AbbrevName(string name) => string.Join(".", name.Split(' ').Select(x => x.Substring(0,1).ToUpper()));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("S.H", Kata.AbbrevName("Sam Harris"));
      Assert.AreEqual("P.F", Kata.AbbrevName("Patrick Feenan"));
      Assert.AreEqual("E.C", Kata.AbbrevName("Evan Cole"));
      Assert.AreEqual("P.F", Kata.AbbrevName("P Favuzzi"));
      Assert.AreEqual("D.M", Kata.AbbrevName("David Mendieta"));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual("G.C", Kata.AbbrevName("george clooney"));
      Assert.AreEqual("M.M", Kata.AbbrevName("marky mark"));
      Assert.AreEqual("E.D", Kata.AbbrevName("eliza doolittle"));
      Assert.AreEqual("R.W", Kata.AbbrevName("reese witherspoon"));    
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
      
      for(int r=0;r<200;r++)
      {
        var length1 = rand.Next(1, 20);
        var length2 = rand.Next(1, 20);
        
        var word1 = string.Concat(Enumerable.Range(1,length1).Select(a => possible[rand.Next(0, possible.Length)]).ToArray());
        var word2 = string.Concat(Enumerable.Range(1,length2).Select(a => possible[rand.Next(0, possible.Length)]).ToArray());
        var name = word1 + " " + word2;
      
        var parts = name.Split(' ');      
        var expected = char.ToUpper(parts[0][0]) + "." + char.ToUpper(parts[1][0]);
        Assert.AreEqual(expected, Kata.AbbrevName(name));   
      }
    }
  }
}
