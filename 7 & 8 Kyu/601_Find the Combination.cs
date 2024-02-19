/*Challenge link:https://www.codewars.com/kata/55c2a1ee7fe3ccfee5000058/train/csharp
Question:
Your objective is to count how many times a certain word or combination of letters or symbols appears inside a string. The key is case insensitive and can occur as many or as few times in the string. The function declaration is provided for you and there should be two arguments with one return variable that returns the count. Overlapping words should not be counted more than once! An empty string cannot be a key. The function should also be able to count the number of integers and characters. Think hard!

Example:

Kata.CountCombinations("my name is billy and billy is awesome", "billy"); // 2
Kata.CountCombinations("abcdefghijklmonopolymonorailqrstuv", "mono"); // 2
Kata.CountCombinations("GrEggreGGREGgREG", "greg"); // 4
Kata.CountCombinations("@#$##@@@","@"); // 4
Kata.CountCombinations("wow nothing", "yeah"); // 0
Kata.CountCombinations("lololololol", "lol"); // 3
Kata.CountCombinations("93049", @"\\d"); // 5
Kata.CountCombinations("Five ", @"\."); // 5
Please give feedback and rank! That would be amazing!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/

//(?i) ignore case, find pattern that matches then count it.
public class Kata{
  public static int CountCombinations(string t, string k) => System.Text.RegularExpressions.Regex.Matches(t, "(?i)" + k).Count;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {    
      Assert.AreEqual(3, Kata.CountCombinations("hellohellohello", "hello"));
      Assert.AreEqual(1, Kata.CountCombinations("jfdkeyoeld", "key"));
      Assert.AreEqual(4, Kata.CountCombinations("my name is hEctOrhector HECToR hectoRRRR", "hector"));
      Assert.AreEqual(0, Kata.CountCombinations("hi", "bye"));
      Assert.AreEqual(0, Kata.CountCombinations("", "no"));
      Assert.AreEqual(0, Kata.CountCombinations("", "n"));
      Assert.AreEqual(3, Kata.CountCombinations("wowowowowow", "wow"));
      Assert.AreEqual(5, Kata.CountCombinations("     ", " "));
      Assert.AreEqual(2, Kata.CountCombinations("!@$#*$@@#$!", "!"));
      Assert.AreEqual(8, Kata.CountCombinations("This is a really long string with no intention of being short and a run on sentence is a run on sentence any way you look at it, split it, cut it, paste it, melt it, and beat it.", "it"));
      Assert.AreEqual(4, Kata.CountCombinations("Words are inside words that are on the outside of walls to the side of the bedside.", "side"));
      Assert.AreEqual(1, Kata.CountCombinations("Does this work krow?", "work"));
      Assert.AreEqual(5, Kata.CountCombinations("03948", "\\d"));
      Assert.AreEqual(5, Kata.CountCombinations("Count t h e spaces ", "\\s"));
      Assert.AreEqual(20, Kata.CountCombinations("How many characters?", "."));
    }
  }
}
