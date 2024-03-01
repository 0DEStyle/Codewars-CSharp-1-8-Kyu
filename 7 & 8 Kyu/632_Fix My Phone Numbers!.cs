/*Challenge link:https://www.codewars.com/kata/596343a24489a8b2a00000a2/train/csharp
Question:
Fix My Phone Numbers
Oh thank goodness you're here! The last intern has completely ruined everything!

All of our customer's phone numbers have been scrambled, and we need those phone numbers to annoy them with endless sales calls!

The Format
Phone numbers are stored as strings and comprise 11 digits, eg '02078834982' and must always start with a 0.

However, something strange has happened and now all of the phone numbers contain lots of random characters, whitespace and some are not phone numbers at all!

For example, '02078834982' has somehow become 'efRFS:)0207ERGQREG88349F82!' and there are lots more lines that we need to check.

The Task
Given a string, you must decide whether or not it contains a valid phone number. If it does, return the corrected phone number as a string ie. '02078834982' with no whitespace or special characters, else return "Not a phone number".
*/

//***************Solution********************
using System.Text.RegularExpressions;

public class Kata{
  public static string IsItANum(string str) {
    //replace any character that is not a a digit to nothing
    var number = Regex.Replace(str, @"\D", "");
    
    //check if number start with 0, followed by 10 digits
    if(Regex.IsMatch(number, @"^0\d{10}$")) 
      return number;
    
    //no match
    return  "Not a phone number";
  }
}

//linq
using System.Linq;

class Kata
{
  public static string IsItANum(string s) 
  {
    string number = string.Concat(s.Where(char.IsDigit));
    
    if (number.Length != 11 || number[0] != '0') 
      return "Not a phone number";
    
    return number;
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string Solution(string str)
    {
      string result = new Regex(@"[^\d]").Replace(str, "");
      return (result.Length == 11 && result[0] == '0') ? result : "Not a phone number";
    }
  
    [Test]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      { 
        delegate { Assert.AreEqual("02078834982", Kata.IsItANum("S:)0207ERGQREG88349F82!efRF)")); },
        delegate { Assert.AreEqual("Not a phone number", Kata.IsItANum("sjfniebienvr12312312312ehfWh")); },
        delegate { Assert.AreEqual("Not a phone number", Kata.IsItANum("0192387415456")); },
        delegate { Assert.AreEqual("02084564165", Kata.IsItANum("v   uf  f 0tt2eg qe0b 8rtyq4eyq564()(((((165")); },
        delegate { Assert.AreEqual("Not a phone number", Kata.IsItANum("stop calling me no I have never been in an accident")); }
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test]
    public void RandomTest()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz!£$%^&*()- ";
      for (int i = 0; i < 100; ++i)
      {
        string test = "";
        int loops = rnd.Next(1, 20);
        for (int j = 0; j < loops; ++j)
        {
          test += chars[rnd.Next(0, chars.Length)];
        }
        test += rnd.Next(0, 1000000000).ToString() + rnd.Next(0, 100).ToString();
        if (rnd.Next(0, 2) == 0) test = "0" + test;
        string expected = Solution(test);
        string actual = Kata.IsItANum(test);
        Console.WriteLine("Expected: {0}\nActual:   {1}\n", expected, actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
