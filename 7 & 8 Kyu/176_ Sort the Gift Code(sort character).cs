/*Challenge link:https://www.codewars.com/kata/52aeb2f3ad0e952f560005d3/train/csharp
Question:
Happy Holidays fellow Code Warriors!
Santa's senior gift organizer Elf developed a way to represent up to 26 gifts by assigning a unique alphabetical character to each gift. After each gift was assigned a character, the gift organizer Elf then joined the characters to form the gift ordering code.

Santa asked his organizer to order the characters in alphabetical order, but the Elf fell asleep from consuming too much hot chocolate and candy canes! Can you help him out?

Sort the Gift Code
Write a function called sortGiftCode/sort_gift_code/SortGiftCode that accepts a string containing up to 26 unique alphabetical characters, and returns a string containing the same characters in alphabetical order.

Examples (Input -- => Output):
"abcdef"                      -- => "abcdef"
"pqksuvy"                     -- => "kpqsuvy"
"zyxwvutsrqponmlkjihgfedcba"  -- => "abcdefghijklmnopqrstuvwxyz"
*/

//***************Solution********************
//sort character by order, then join them back together and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
public class Kata{
  public static string SortGiftCode(string code) =>String.Concat(code.OrderBy(c => c));
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
    public void SampleTest()
    {
      Assert.AreEqual("abcdef", Kata.SortGiftCode("abcdef"));
      Assert.AreEqual("kpqsuvy", Kata.SortGiftCode("pqksuvy"));
      Assert.AreEqual("abcdefghijklmnopqrstuvwxyz", Kata.SortGiftCode("zyxwvutsrqponmlkjihgfedcba"));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Concat(new char[rnd.Next(6, 40)].Select(_ => (char)rnd.Next(97, 123)).Distinct());
        
        string expected = String.Concat(test.OrderBy(x => x));
        string actual = Kata.SortGiftCode(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
