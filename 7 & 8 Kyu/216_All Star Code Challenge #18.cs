/*Challenge link:https://www.codewars.com/kata/5865918c6b569962950002a1/train/csharp
Question:Create a function that accepts a string and a single character, and returns an integer of the count of occurrences the 2nd argument is found in the first one.

If no occurrences can be found, a count of 0 should be returned.

("Hello", "o")  ==>  1
("Hello", "l")  ==>  2
("", "z")       ==>  0
str_count("Hello", 'o'); // returns 1
str_count("Hello", 'l'); // returns 2
str_count("", 'z'); // returns 0
Notes
The first argument can be an empty string
In languages with no distinct character data type, the second argument will be a string of length 1
*/

//***************Solution********************
//Count the number of occurrence of letter in str. return the number of counts.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
class Kata{
    public static int StrCount(string str, char letter) =>str.Count(x=>x == letter);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

[TestFixture]
class Test
{
    [TestCase("Hello", 'o', 1)]
    [TestCase("Hello", 'l', 2)]
    [TestCase("Hello", 'p', 0)]
    [TestCase("", 'z', 0)]
    public void BasicTests(string str, char letter, int expected)
    {
        Assert.That(Kata.StrCount(str, letter), Is.EqualTo(expected));
    }

    private readonly Random rnd = new Random();
    private readonly string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
    
    [Test]
    public void RandomTest()
    {
        for (int i = 0; i < 100; i++)
        {
            var (str, letter, expected) = CreateTestCase();
            Assert.That(Kata.StrCount(str, letter), Is.EqualTo(expected), $"Incorrect answer for:\n  str = \"{str}\"\n  letter = '{letter}'");
        }
    }

    (string, char, int) CreateTestCase() {
      
      int len = rnd.Next(0, 50);
      char[] chars = new char[len];
      char letter = GenerateLetter();
      int expected = 0;
      for(int i=0; i<len; ++i) {
        chars[i] = GenerateLetter();
        expected += (chars[i] == letter ? 1 : 0);
      }
      
      return (new string(chars), letter, expected);
    }
  
    char GenerateLetter() => chars[rnd.Next(0, chars.Length)];
}
