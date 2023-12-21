/*Challenge link:https://www.codewars.com/kata/57faf7275c991027af000679/train/csharp
Question:
Description:
Remove n exclamation marks in the sentence from left to right. n is positive integer.

Examples
remove("Hi!",1) === "Hi"
remove("Hi!",100) === "Hi"
remove("Hi!!!",1) === "Hi!!"
remove("Hi!!!",100) === "Hi"
remove("!Hi",1) === "Hi"
remove("!Hi!",1) === "Hi!"
remove("!Hi!",100) === "Hi"
remove("!!!Hi !!hi!!! !hi",1) === "!!Hi !!hi!!! !hi"
remove("!!!Hi !!hi!!! !hi",3) === "Hi !!hi!!! !hi"
remove("!!!Hi !!hi!!! !hi",5) === "Hi hi!!! !hi"
remove("!!!Hi !!hi!!! !hi",100) === "Hi hi hi"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//in string s, if character is equal to '!', decrease n by 1 while it is less than or equal to 0, else return true
//concat the elements and return the result.

using System.Linq;

public class Kata{
  public static string Remove(string s, int n) => string.Concat(s.Where(ch => ch == '!' ? n-- <= 0 : true));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rng = new Random();
  
    [Test, Description("It should work for basic tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual("Hi", Kata.Remove("Hi!", 1)),
        () => Assert.AreEqual("Hi", Kata.Remove("Hi!", 100)),
        () => Assert.AreEqual("Hi!!", Kata.Remove("Hi!!!", 1)),
        () => Assert.AreEqual("Hi", Kata.Remove("Hi!!!", 100)),
        () => Assert.AreEqual("Hi", Kata.Remove("!Hi", 1)),
        () => Assert.AreEqual("Hi!", Kata.Remove("!Hi!", 1)),
        () => Assert.AreEqual("Hi", Kata.Remove("!Hi!", 100)),
        () => Assert.AreEqual("!!Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 1)),
        () => Assert.AreEqual("Hi !!hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 3)),
        () => Assert.AreEqual("Hi hi!!! !hi", Kata.Remove("!!!Hi !!hi!!! !hi", 5)),
        () => Assert.AreEqual("Hi hi hi", Kata.Remove("!!!Hi !!hi!!! !hi", 100)),
      };
      tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ     !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!";
    
    [Test, Description("It should work for random tests too")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        int length = rng.Next(4, 101);
        StringBuilder sb = new StringBuilder(length);
        for (int j = 0; j < sb.Capacity; ++j)
        {
          sb.Append(chars[rng.Next(0, chars.Length)]);
        }
        string test = sb.ToString();
        int num = rng.Next(1, 101);
        string expected = new Regex("!").Replace(test, "", num);
        string actual = Kata.Remove(test, num);
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test, Description("<font color='#00aa00' size=2><b>I'm waiting for your <font color='#dddd00'>feedback, rank and vote.<font color='#00aa00'>many thanks! ;-)</b></font>")]
    public void Advertisement() 
    {
      
    }
  }
}
