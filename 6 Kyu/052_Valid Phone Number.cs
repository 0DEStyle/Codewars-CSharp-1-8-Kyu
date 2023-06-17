/*Challenge link:https://www.codewars.com/kata/525f47c79f2f25a4db000025/train/csharp
Question:
Write a function that accepts a string, and returns true if it is in the form of a phone number.
Assume that any integer from 0-9 in any of the spots will produce a valid phone number.

Only worry about the following format:
(123) 456-7890 (don't forget the space after the close parentheses)

Examples:

"(123) 456-7890"  => true
"(1111)555 2345"  => false
"(098) 123 4567"  => false
*/

//***************Solution********************
//from the start of file, find pattern
//( followed by 3 digits followed by ) and a space
//then 3 digits followed by - followed by 4 digits.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public static class Kata
{
  public static bool ValidPhoneNumber(string s)
  {
    return Regex.IsMatch(s, @"^\(\d{3}\) \d{3}-\d{4}$");
  }
}

//****************Sample Test*****************
namespace Solution
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;
  using NUnit.Framework;
  
  [TestFixture]
  public class KataTest
  {
    [Test]
    public void FixedTests()
    {
      Assert.IsTrue(Kata.ValidPhoneNumber("(123) 456-7890"));
      Assert.IsFalse(Kata.ValidPhoneNumber("(1111)555 2345"));
      Assert.IsFalse(Kata.ValidPhoneNumber("(098) 123 4567"));
      Assert.IsFalse(Kata.ValidPhoneNumber("(123)456-7890"));
      Assert.IsFalse(Kata.ValidPhoneNumber("abc(123)456-7890"));
      Assert.IsFalse(Kata.ValidPhoneNumber("(123)456-7890abc"));
      Assert.IsFalse(Kata.ValidPhoneNumber("abc(123)456-7890abc"));
      Assert.IsFalse(Kata.ValidPhoneNumber("abc(123) 456-7890"));
      Assert.IsFalse(Kata.ValidPhoneNumber("(123) 456-7890abc"));
      Assert.IsFalse(Kata.ValidPhoneNumber("abc(123) 456-7890abc"));
      Assert.IsFalse(Kata.ValidPhoneNumber("xyz(123) 456-7890xyz"));
    }
    
    private static Random rnd = new Random();
    
    private static string generatePhoneNumber()
    {
      return $"({(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}) {(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}-{(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}{(char)rnd.Next(48, 58)}";
    }
    
    private static string generateFakePhoneNumber()
    {
      return String.Concat(generatePhoneNumber().OrderBy(_ => rnd.Next()));
    }
    
    private static bool solution(string phoneNumber)
    {
      return Regex.IsMatch(phoneNumber, @"^\(\d{3}\) \d{3}-\d{4}$");
    }
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        string phoneNumber = new Func<string>[] {generatePhoneNumber, generateFakePhoneNumber}[rnd.Next(0, 2)]();
        
        bool expected = solution(phoneNumber);
        bool actual = Kata.ValidPhoneNumber(phoneNumber);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
