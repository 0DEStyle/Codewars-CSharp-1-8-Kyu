/*Challenge link:https://www.codewars.com/kata/52223df9e8f98c7aa7000062/train/csharp
Question:
How can you tell an extrovert from an introvert at NSA?
Va gur ryringbef, gur rkgebireg ybbxf ng gur BGURE thl'f fubrf.

I found this joke on USENET, but the punchline is scrambled. Maybe you can decipher it?
According to Wikipedia, ROT13 is frequently used to obfuscate jokes on USENET.

For this task you're only supposed to substitute characters. Not spaces, punctuation, numbers, etc.

Test examples:

"EBG13 rknzcyr." -> "ROT13 example."

"This is my first ROT13 excercise!" -> "Guvf vf zl svefg EBG13 rkprepvfr!"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata{
  public static string Rot13(string input) => 
    string.Concat(                                              //concat the characters
    input.Select(c => char.IsLetter(c) ?                        //check if character is a letter
                //if character is a letter, convert to lower, if letter is ASCII value is greater than m(m being the middle)
                //true: c - 13 false c + 13 shift the ASCII position, then convert to char
                 (char) (c + (char.ToLower(c) > 'm' ? -13 : 13))
                 : c)             //if character is not a letter, return c itself.
  );
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;
  using System.Linq;

  [TestFixture]
  public class SystemTests
  { 
    [Test]
    public void Test1()
    {
      Assert.AreEqual("ROT13 example.", Kata.Rot13("EBG13 rknzcyr."));
    }

    [Test]
    public void Test2()
     {
      Assert.AreEqual("Ubj pna lbh gryy na rkgebireg sebz na\nvagebireg ng AFN? In the elevators,\nthe extrovert looks at the OTHER guy's shoes.", Kata.Rot13("How can you tell an extrovert from an\nintrovert at NSA? Va gur ryringbef,\ngur rkgebireg ybbxf ng gur BGURE thl'f fubrf."));
    }

    [Test]
    public void Test3()
    {
     Assert.AreEqual("123", Kata.Rot13("123"));
    }
    
    [Test]
    public void Test4()
    {
     Assert.AreEqual("This is actually the first kata I ever made. Thanks for finishing it! :)", Kata.Rot13("Guvf vf npghnyyl gur svefg xngn V rire znqr. Gunaxf sbe svavfuvat vg! :)"));
    }
    
    [Test]
    public void Test5()
    {
     Assert.AreEqual("@[`{", Kata.Rot13("@[`{"));
    }
    
    private static Random rnd = new Random();
    
    private static string solution(string message)
    {
      // Pattern which matches any letter, ignoring case
      Regex pattern = new Regex("([a-z])", RegexOptions.IgnoreCase);
      
      // Function which will evaulate a Regex match and return a new string
      // In this case shifting the letter by 13 (fake mod 26)
      Func<Match, string> shifter = (letter) => ((char)(letter.Value[0] + ((Char.ToLower(letter.Value[0]) >= 'n') ? -13 : 13))).ToString();
      
      // Return the modified string
      return pattern.Replace(message, new MatchEvaluator(shifter)); 
    }
    
    [Test, Description("Random Strings")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Concat(new char[50].Select(_ => (rnd.Next(0, 6) == 0) ? (char)rnd.Next(32, 127) : (rnd.Next(0, 2) == 0) ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123)));
        string actual = solution(test);
        string expected = Kata.Rot13(test);
        
        Assert.AreEqual(expected, actual, String.Format("Input: {0}, Expected Output: {1}, Actual Output: {2}", test, expected, actual));
      }
    }
  }
}
