/*Challenge link:https://www.codewars.com/kata/530e15517bc88ac656000716/train/csharp
Question:
ROT13 is a simple letter substitution cipher that replaces a letter with the letter 13 letters after it in the alphabet. ROT13 is an example of the Caesar cipher.

Create a function that takes a string and returns the string ciphered with Rot13. If there are numbers or special characters included in the string, they should be returned as they are. Only letters from the latin/english alphabet should be shifted, like in the original Rot13 "implementation".
*/

//***************Solution********************
//Solution 1
//shift the ASCII Value of the letter by 13(2 sets, upper and lower case, starting a-z from 65 to 90, A-Z 97-122)
//after reaching the end m = z or M = Z, the value should loop back to the starting point a or A.
//return the result in string format

public class Kata
{
  public static string Rot13(string message)
  {
    string output = "";
    
    foreach (char c in message){
    if(c >= 'a' && c <= 'z')
        output += (char)((c - 'a' + 13) % 26 + 'a');
    else if(c >= 'A' && c <= 'Z')
        output += (char)((c - 'A' + 13) % 26 + 'A');
    else
        output += c;
    }
    return output;
  }
}

//Solution 2
//Same method as above, but simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static string Rot13(string message) =>
  !string.IsNullOrEmpty(input) ? new string(input.Select(x => (x >= 'a' && x <= 'z') ? (char)((x - 'a' + 13) % 26 + 'a') : ((x >= 'A' && x <= 'Z') ? (char)((x - 'A' + 13) % 26 + 'A') : x)).ToArray()) : input;
}
 

//****************Sample Test*****************

namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("test")]
    public void testTest()
    {
      Assert.AreEqual("grfg", Kata.Rot13("test"), String.Format("Input: test, Expected Output: grfg, Actual Output: {0}", Kata.Rot13("test")));
    }
    
    [Test, Description("Test")]
    public void TestTest()
    {
      Assert.AreEqual("Grfg", Kata.Rot13("Test"), String.Format("Input: Test, Expected Output: Grfg, Actual Output: {0}", Kata.Rot13("Test")));
    }

    [Test, Description("Codewars")]
    public void CodewarsTest()
    {
      Assert.AreEqual("Pbqrjnef", Kata.Rot13("Codewars"), String.Format("Input: Codewars, Expected Output: Pbqrjnef, Actual Output: {0}", Kata.Rot13("Codewars")));
    }

    [Test, Description("C# is cool!")]
    public void CSTest()
    {
      Assert.AreEqual("P# vf pbby!", Kata.Rot13("C# is cool!"), String.Format("Input: C# is cool!, Expected Output: P# vf pbby!, Actual Output: {0}", Kata.Rot13("C# is cool!")));
    }

    [Test, Description("10+2 is twelve.")]
    public void ArithTest()
    {
      Assert.AreEqual("10+2 vf gjryir.", Kata.Rot13("10+2 is twelve."), String.Format("Input: Codewars, Expected Output: 10+2 vf gjryir., Actual Output: {0}", Kata.Rot13("10+2 is twelve.")));
    }

    [Test, Description("abcdefghijklmnopqrstuvwxyz")]
    public void AlphabetTest()
    {
      Assert.AreEqual("nopqrstuvwxyzabcdefghijklm", Kata.Rot13("abcdefghijklmnopqrstuvwxyz"), String.Format("Input: abcdefghijklmnopqrstuvwxyz, Expected Output: nopqrstuvwxyzabcdefghijklm, Actual Output: {0}", Kata.Rot13("abcdefghijklmnopqrstuvwxyz")));
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
        string actual = Kata.Rot13(test);
        string expected = solution(test);
        
        Assert.AreEqual(expected, actual, String.Format("Input: {0}, Expected Output: {1}, Actual Output: {2}", test, expected, actual));
      }
    }
  }
}
