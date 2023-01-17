/*Challenge link:https://www.codewars.com/kata/57e1e61ba396b3727c000251/train/csharp
Question:
Your boss decided to save money by purchasing some cut-rate optical character recognition software for scanning in the text of old novels to your database. At first it seems to capture words okay, but you quickly notice that it throws in a lot of numbers at random places in the text.

Examples (input -> output)
'! !'                 -> '! !'
'123456789'           -> ''
'This looks5 grea8t!' -> 'This looks great!'
Your harried co-workers are looking to you for a solution to take this garbled text and remove all of the numbers. Your program will take in a string and clean out all numeric characters, and return a string with spacing and special characters ~#$%^&!@*():;"'.,? all intact.
*/

//***************Solution********************
//replace all numbers
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Kata{
  public static string StringClean(string s) =>  Regex.Replace(s, @"[0-9]", "");
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTest()
    {
      Assert.AreEqual("", Kata.StringClean(""));
      Assert.AreEqual("! !", Kata.StringClean("! !"));
      Assert.AreEqual("", Kata.StringClean("1234567890"));
      Assert.AreEqual("Dsa cdsc csa!!! I Am cool!", Kata.StringClean("Dsa32 cdsc34232 csa!!! 1I 4Am cool!"));
      Assert.AreEqual("A A! AAA   JKL@!!!", Kata.StringClean("A1 A1! AAA   3J4K5L@!!!"));
      Assert.AreEqual("Adgre Asad! AAA fvfdvJKL@", Kata.StringClean("Adgre2321 A1sad! A2A3A4 fv3fdv3J544K5L@"));
      Assert.AreEqual("Addsadds A  $$sad! AAAe fKL@ ", Kata.StringClean("Ad2dsad3ds21 A  1$$s122ad! A2A3Ae24 f44K5L@222222 "));
      Assert.AreEqual("Addsadds A  $$sa!d! A!A!Ae$ f## ", Kata.StringClean("33333Ad2dsad3ds21 A3333  1$$s122a!d! A2!A!3Ae$24 f2##222 "));
      Assert.AreEqual("My \"messy\" data issues! Will they ever, ever be solved?", Kata.StringClean("My \"me3ssy\" d8ata issues2! Will1 th4ey ever, e3ver be3 so0lved?"));
      Assert.AreEqual("Why can't we buy the good software? #cheapskates", Kata.StringClean("Wh7y can't we3 bu1y the goo0d software3? #cheapskates3"));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz`~#$%^&!@*():;\"'.,?";
      
      for (int i = 0; i < 100; ++i)
      {
        string test = String.Empty;
        for (int j = 0; j < 40; ++j)
        {
          if (rnd.Next(0, 3) == 0) test += rnd.Next(0, 10).ToString();
          else test += chars[rnd.Next(0, chars.Length)];
        }
        string expected = new Regex(@"\d").Replace(test, "");
        string actual = Kata.StringClean(expected);
        Console.WriteLine("Test:     {0}", test);
        Console.WriteLine("Expected: {0}", expected);
        Console.WriteLine("Actual:   {0}\n", actual);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
