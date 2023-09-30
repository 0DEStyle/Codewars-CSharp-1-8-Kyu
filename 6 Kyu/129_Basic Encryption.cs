/*Challenge link:https://www.codewars.com/kata/5862fb364f7ab46270000078/train/csharp
Question:
The most basic encryption method is to map a char to another char by a certain math rule. Because every char has an ASCII value, we can manipulate this value with a simple math expression. For example 'a' + 1 would give us 'b', because 'a' value is 97 and 'b' value is 98.

You will need to write a method which does exactly that -

get a string as text and an int as the rule of manipulation, and should return encrypted text. for example:

encrypt("a",1) = "b"

Full ascii table is used on our question (256 chars) - so 0-255 are the valid values.

If the value exceeds 255, it should 'wrap'. ie. if the value is 345 it should wrap to 89.

Good luck.
*/

//***************Solution********************

//from text, x is the current character
//x + rule to shift the character index, mod 256 to avoid out of bound, meaning it will start at 0 again.
//concat the string and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public static class Kata{
  public static string Encrypt(string text, int rule) => string.Concat(text.Select(x => (char) ((x + rule) % 256)));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;
  
  public static class Solution
  {
    public static string Encrypt(string text, int rule) =>
      text.Aggregate(new StringBuilder(), (p, c) => { p.Append((char)((c + rule) % 256)); return p; }).ToString();
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.Encrypt("", 1), Is.EqualTo(""));
      Assert.That(Kata.Encrypt("a", 1), Is.EqualTo("b"));
      Assert.That(Kata.Encrypt("please encrypt me", 2), Is.EqualTo("rngcug\"gpet{rv\"og"));
    }
    
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        int rule = rnd.Next(0, 451);
        string text = new char[rnd.Next(1, 40)].Aggregate(new StringBuilder(), (p, c) => { p.Append((char)rnd.Next(0, 256)); return p; }).ToString();
        string expected = Solution.Encrypt(text, rule);
        
        Assert.That(Kata.Encrypt(text, rule), Is.EqualTo(expected));
      }
    }
  }
}
