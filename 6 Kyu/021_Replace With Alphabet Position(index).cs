/*Challenge link:https://www.codewars.com/kata/546f922b54af40e1e90001da/train/csharp
Question:
Welcome.

In this kata you are required to, given a string, replace every letter with its position in the alphabet.

If anything in the text isn't a letter, ignore it and don't return it.

"a" = 1, "b" = 2, etc.

Example
Kata.AlphabetPosition("The sunset sets at twelve o' clock.")
Should return "20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11" ( as a string )
*/

//***************Solution********************

//solution 1
/*
loop through each character, if character is from a-z (ignore the case)
character % 32 and convert to int, then to string + a space
if the result's length is less than 0, then return the result without the last space
else return empty string.
*/
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static string AlphabetPosition(string text)
  {
    string result = "";
    Console.WriteLine(text);
    for(int i = 0; i < text.Length; i++){
      if(Regex.IsMatch(text[i].ToString(), "[a-z]", RegexOptions.IgnoreCase)){
         result += ((int)text[i] % 32).ToString() + " ";
      }
    }
    if(result.Length > 0)
      return result.Remove(result.Length - 1);
    else
      return "";
  }
}

//solution 2
/*convert string to lower,
if element is a character
element - 'a'starting index + 1(shift by 1 bit)
return the result as a string.
simiplfied into one line by using an Lambda expression with Enumerable methods.
*/
using System.Linq;
public static class Kata
{
  public static string AlphabetPosition(string text)
  {
     return string.Join(" ", text.ToLower().Where(char.IsLetter).Select(x => x - 'a'+1));
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("20 8 5 19 21 14 19 5 20 19 5 20 19 1 20 20 23 5 12 22 5 15 3 12 15 3 11", Kata.AlphabetPosition("The sunset sets at twelve o' clock."));
      Assert.AreEqual("20 8 5 14 1 18 23 8 1 12 2 1 3 15 14 19 1 20 13 9 4 14 9 7 8 20", Kata.AlphabetPosition("The narwhal bacons at midnight."));
      Assert.AreEqual("", Kata.AlphabetPosition("-.-'"));
    }
    
    private static Random rnd = new Random();
    
    public static string solution(string text)
    {
      List<string> result = new List<string>();
      
      foreach (char c in text)
      {
        if (Char.IsLetter(c))
        {
          result.Add(((int)Char.ToUpper(c) - 64).ToString());
        }
      }
      
      return String.Join(" ", result);
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        string text = String.Concat(new char[rnd.Next(20, 100)].Select(_ => (char)rnd.Next(128)));
        
        string expected = solution(text);
        string actual = Kata.AlphabetPosition(text);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
