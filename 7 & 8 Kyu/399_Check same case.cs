/*Challenge link:https://www.codewars.com/kata/5dd462a573ee6d0014ce715b/train/csharp
Question:
Write a function that will check if two given characters are the same case.

If either of the characters is not a letter, return -1
If both characters are the same case, return 1
If both characters are letters, but not the same case, return 0
Examples
'a' and 'g' returns 1

'A' and 'C' returns 1

'b' and 'G' returns 0

'B' and 'g' returns 0

'0' and '?' returns -1
*/

//***************Solution********************

//if either a or b is not a letter return -1
//else if a and b are lower or a and b are upper, return 1, else 0;
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Kata {
  public static int SameCase(char a, char b) => 
    !Char.IsLetter(a) || !Char.IsLetter(b) ? 
    -1 : (Char.IsLower(a) && Char.IsLower(b)) || (Char.IsUpper(a) && Char.IsUpper(b)) ? 
     1 : 0;
}

//solution 2
public class Kata
{
  public static int SameCase(char a, char b) =>
      char.IsLetter(a) && char.IsLetter(b) ? (a & 96) == (b & 96) ? 1 : 0 : -1;
}

//solution 3
public class Kata
{
  public static int SameCase(char a, char b) =>
      char.IsLetter(a) && char.IsLetter(b) ? char.IsLower(a) == char.IsLower(b) ? 1 : 0 : -1;
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void TrueTests()
    {
      Assert.AreEqual(1, Kata.SameCase('a', 'u'));
      Assert.AreEqual(1, Kata.SameCase('A', 'U'));
      Assert.AreEqual(1, Kata.SameCase('Q', 'P'));
      Assert.AreEqual(1, Kata.SameCase('w', 'y'));
      Assert.AreEqual(1, Kata.SameCase('c', 'm'));
      Assert.AreEqual(1, Kata.SameCase('N', 'W'));
    }
    [Test]
    public void FalseTests()
    {
      Assert.AreEqual(0, Kata.SameCase('a', 'U'));
      Assert.AreEqual(0, Kata.SameCase('A', 'u'));
      Assert.AreEqual(0, Kata.SameCase('Q', 'p'));
      Assert.AreEqual(0, Kata.SameCase('w', 'Y'));
      Assert.AreEqual(0, Kata.SameCase('c', 'M'));
      Assert.AreEqual(0, Kata.SameCase('N', 'w'));
    }
    [Test]
    public void NotLetters()
    {
      Assert.AreEqual(-1, Kata.SameCase('a', '*'));
      Assert.AreEqual(-1, Kata.SameCase('A', '%'));
      Assert.AreEqual(-1, Kata.SameCase('Q', '1'));
      Assert.AreEqual(-1, Kata.SameCase('w', '-'));
      Assert.AreEqual(-1, Kata.SameCase('c', '8'));
      Assert.AreEqual(-1, Kata.SameCase('N', ':'));
    }
    [Test]
    public void RandomTest() {
      string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmopqrstuvwxyz1234567890~/*-+:.,><.#@!&";
      Random rand = new Random();
      char char1 = 'a';
      char char2 = 'a';
      
      for (int i = 0; i < 200; i++) {
        char1 = chars[rand.Next(0,76)];
        char2 = chars[rand.Next(0,76)];
        Assert.AreEqual(SameCaseSolution(char1,char2), Kata.SameCase(char1, char2));
      }
    }
    
    private static int SameCaseSolution(char a, char b) {
      if (!char.IsLetter(a) || !char.IsLetter(b)) return -1;
      if ((a >= 97) == (b >= 97)) return 1;
      return 0;
    }
  }
}
