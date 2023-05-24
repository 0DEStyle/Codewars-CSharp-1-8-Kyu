/*Challenge link:https://www.codewars.com/kata/57c1ab3949324c321600013f/train/csharp
Question:
Your task is to write a function toLeetSpeak that converts a regular english sentence to Leetspeak.

More about LeetSpeak You can read at wiki -> https://en.wikipedia.org/wiki/Leet

Consider only uppercase letters (no lowercase letters, no numbers) and spaces.

For example:

toLeetSpeak("LEET") returns "1337"
In this kata we use a simple LeetSpeak dialect. Use this alphabet:

{
  A : '@',
  B : '8',
  C : '(',
  D : 'D',
  E : '3',
  F : 'F',
  G : '6',
  H : '#',
  I : '!',
  J : 'J',
  K : 'K',
  L : '1',
  M : 'M',
  N : 'N',
  O : '0',
  P : 'P',
  Q : 'Q',
  R : 'R',
  S : '$',
  T : '7',
  U : 'U',
  V : 'V',
  W : 'W',
  X : 'X',
  Y : 'Y',
  Z : '2'
}

*/

//***************Solution********************
//from string str, if character is not empty, get index of current character - 'A' from string "@8(D3F6#!JK1MN0PQR$7UVWXY2"
//else get the element itself.
//concatenate the string and return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string ToLeetSpeak(string str) => string.Concat(str.Select(x => x != ' ' ? "@8(D3F6#!JK1MN0PQR$7UVWXY2"[x - 'A'] : x));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("1337", Kata.ToLeetSpeak("LEET"));
      Assert.AreEqual("(0D3W@R$", Kata.ToLeetSpeak("CODEWARS"));
      Assert.AreEqual("#3110 W0R1D", Kata.ToLeetSpeak("HELLO WORLD"));
      Assert.AreEqual("10R3M !P$UM D010R $!7 @M37", Kata.ToLeetSpeak("LOREM IPSUM DOLOR SIT AMET"));
      Assert.AreEqual("7#3 QU!(K 8R0WN F0X JUMP$ 0V3R 7#3 1@2Y D06", Kata.ToLeetSpeak("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Dictionary<char,char> dict = new Dictionary<char,char>  
  {
    { 'A', '@' },
    { 'B', '8' },
    { 'C', '(' },
    { 'D', 'D' },
    { 'E', '3' },
    { 'F', 'F' },
    { 'G', '6' },
    { 'H', '#' },
    { 'I', '!' },
    { 'J', 'J' },
    { 'K', 'K' },
    { 'L', '1' },
    { 'M', 'M' },
    { 'N', 'N' },
    { 'O', '0' },
    { 'P', 'P' },
    { 'Q', 'Q' },
    { 'R', 'R' },
    { 'S', '$' },
    { 'T', '7' },
    { 'U', 'U' },
    { 'V', 'V' },
    { 'W', 'W' },
    { 'X', 'X' },
    { 'Y', 'Y' },
    { 'Z', '2' }
  };
      
      Func<string,string> myToLeetSpeak = delegate (string str)
      {
        return string.Concat(str.Select(a => dict.ContainsKey(a) ? dict[a] : a));
      };
      
      var az = " ";
      for (var i = 65; i < 65 + 26; i++) 
      {
        az += (char)i;
      }
      
      for (var n = 0; n < 100; n++) 
      {
        var testStr = "";        
        for (var i = 0; i < 30; i++)
        {
          testStr += az[rand.Next(0,27)];
        }
        
        Assert.AreEqual(myToLeetSpeak(testStr), Kata.ToLeetSpeak(testStr));
      }
    }    
  }
}
