/*Challenge link:https://www.codewars.com/kata/581e014b55f2c52bb00000f8/train/csharp
Question:
You are given a secret message you need to decipher. Here are the things you need to know to decipher it:

For each word:

the second and the last letter is switched (e.g. Hello becomes Holle)
the first letter is replaced by its character code (e.g. H becomes 72)
Note: there are no special characters used, only letters and spaces

Examples

decipherThis('72olle 103doo 100ya'); // 'Hello good day'
decipherThis('82yade 115te 103o'); // 'Ready set go'
*/

//***************Solution********************

using System.Linq;

public class Kata{
  public static string DecipherThis(string s){
    
    //if string str is greater or equal to 2, 
    //str[^1] index from end 1, + substring starting from 1 count up to length -2, + str[0]
    //else return str.
    string ReplaceChar(string str) => str.Length >= 2 
    ? str[^1] + str.Substring(1, str.Length - 2) + str[0]
    : str;
    
    //if string is null or whitespace, return empty
    //else split string s by space, c is current character
    //check if w is a digit, then concatenate the character and parse to int, then convert back to char
    //+ call function ReplaceChar, take all character that is not a digit.
    //finally join the result by space and return it.
    return string.IsNullOrWhiteSpace(s) 
                ? string.Empty 
                : string.Join(" ", s
                    .Split(" ")
                    .Select(c => $"{(char)int.Parse(string.Concat(c.TakeWhile(char.IsDigit)))}" 
                                            + ReplaceChar(string.Concat(c.SkipWhile(char.IsDigit)))));
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using System.Text.RegularExpressions;


[TestFixture]
public class DecipherThisTests
{
  [TestCase("", "")]
  [TestCase("65", "A")]
  [TestCase("65b", "Ab")]
  [TestCase("65cb", "Abc")]
  [TestCase("65dcb", "Abcd")]
  [TestCase("82yade 115te 103o", "Ready set go")]
  [TestCase("72olle 103doo 100ya", "Hello good day")]
  [TestCase("65 119esi 111dl 111lw 108dvei 105n 97n 111ka", "A wise old owl lived in an oak")]
  [TestCase("84kanh 121uo 80roti 102ro 97ll 121ruo 104ple", "Thank you Piotr for all your help")]
  [TestCase("84eh 109ero 104e 115wa 116eh 108sse 104e 115eokp", "The more he saw the less he spoke")]
  [TestCase("84eh 108sse 104e 115eokp 116eh 109ero 104e 104dare", "The less he spoke the more he heard")]
  [TestCase("72eva 97 103o 97t 116sih 97dn 115ee 104wo 121uo 100o", "Have a go at this and see how you do")]
  [TestCase("87yh 99na 119e 110to 97ll 98e 108eki 116tah 119esi 111dl 98dri", "Why can we not all be like that wise old bird")]
  public void BasicTests(string input, string expected)
  {
    Assert.AreEqual(expected, Kata.DecipherThis(input));
  }
  
  [Test]
  public void RandomTests()
  {
    for (var i = 0; i < 40; i++)
    {
      string randomInput = RandomInput();
      string encryptInput = EncryptThis(randomInput);
      string decipherInput = Kata.DecipherThis(encryptInput);
      Assert.AreEqual(randomInput, decipherInput);
    }
  }
  
  private static readonly Random Random = new Random();
  private const string Chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
  
  private static string RandomInput()
  {
    return string.Join(" ",
        Enumerable.Range(0, Random.Next(0, 30)).Select(_ => RandomWord(Random.Next(1, 10))));
  }
  
  private static string RandomWord(int length)
  {
    return new string(Enumerable.Repeat(Chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
  }
  
  private static string EncryptThis(string s)
  {
    return string.Join(" ",
        s.Split().Where(x => x != "")
            .Select(x => $"{(int) x[0]}{Regex.Replace(x[1..], "(.)(.*)(.)", "$3$2$1")}"));
  }
}
