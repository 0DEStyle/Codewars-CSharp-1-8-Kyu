/*Challenge link:https://www.codewars.com/kata/57f759bb664021a30300007d/train/csharp
Question:
Given a string made up of letters a, b, and/or c, switch the position of letters a and b (change a to b and vice versa). Leave any incidence of c untouched.

Example:

'acb' --> 'bca'
'aabacbaa' --> 'bbabcabb'
*/

//***************Solution********************
//using Regex.Replace to replace letter a and b from string x, 
//for each value in element(character itself), if the element is a, replace with b, else replace with a

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static string Switcheroo(string x) => Regex.Replace(x, "[ab]", m => m.Value == "a" ? "b" : "a");
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
      Assert.AreEqual("bac", Kata.Switcheroo("abc"));
      Assert.AreEqual("bbbacccabbb", Kata.Switcheroo("aaabcccbaaa"));
      Assert.AreEqual("ccccc", Kata.Switcheroo("ccccc"));
      Assert.AreEqual("babababababababa", Kata.Switcheroo("abababababababab"));
      Assert.AreEqual("bbbbb", Kata.Switcheroo("aaaaa"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      var names = new [] { "a","b","c" };
      
      for (var i=0;i<100;i++)
      {        
        var len = rand.Next(1,30);
        var x = string.Concat(Enumerable.Range(0, len).Select(a => names[rand.Next(0, names.Length-1)]));
  
        var expected = string.Concat(x.Select(a => a == 'a' ? 'b' : a == 'b' ? 'a' : a));
        Assert.AreEqual(expected, Kata.Switcheroo(x), "It should work for random inputs too");
      }
    }
  }
}
