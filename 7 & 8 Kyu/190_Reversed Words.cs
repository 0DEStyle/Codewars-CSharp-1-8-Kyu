/*Challenge link:https://www.codewars.com/kata/51c8991dee245d7ddf00000e/train/csharp
Question:
Complete the solution so that it reverses all of the words within the string passed in.

Words are separated by exactly one space and there are no leading or trailing spaces.

Example(Input --> Output):

"The greatest victory is that which requires no battle" --> "battle no requires which that is victory greatest The"
*/

//***************Solution********************
//split the string into word, reverse the words, then join the string by space.
//return the resul.t
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static string ReverseWords(string s) => String.Join(" ",s.Split(" ").Reverse());
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("world! hello", Kata.ReverseWords("hello world!"));
      Assert.AreEqual("this like speak doesn't yoda", Kata.ReverseWords("yoda doesn't speak like this"));
      Assert.AreEqual("foobar", Kata.ReverseWords("foobar"));
      Assert.AreEqual("kata editor", Kata.ReverseWords("editor kata"));
      Assert.AreEqual("boat your row row row", Kata.ReverseWords("row row row your boat"));
      Assert.AreEqual("", Kata.ReverseWords(""));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int k = 0; k < 40; ++k)
      {
        var words = rand.Next(0, 10);
        var str = string.Join(' ',Enumerable.Range(0, words).Select(_ => string.Join("", Enumerable.Range(1, rand.Next(1,10)).Select(__ => (char)rand.Next('a','z'+1)))));
        
        Assert.AreEqual(string.Join(' ', str.Split(' ').Reverse()), Kata.ReverseWords(str), str + " wasn't reversed correctly!");
      }
    }
  }
}
