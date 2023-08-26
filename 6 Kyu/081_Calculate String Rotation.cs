/*Challenge link:https://www.codewars.com/kata/5596f6e9529e9ab6fb000014/train/csharp
Question:
Write a function that receives two strings and returns n, where n is equal to the number of characters we should shift the first string forward to match the second. The check should be case sensitive.

For instance, take the strings "fatigue" and "tiguefa". In this case, the first string has been rotated 5 characters forward to produce the second string, so 5 would be returned.

If the second string isn't a valid rotation of the first string, the method returns -1.
Examples:
"coffee", "eecoff" => 2
"eecoff", "coffee" => 4
"moose", "Moose" => -1
"isn't", "'tisn" => 2
"Esham", "Esham" => 0
"dog", "god" => -1
*/

//***************Solution********************
//if second length is equal to first length
//return join 2 second string together and get index of first,
//else return -1
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class CalculateStringRotation{
  public static int ShiftedDiff(string first, string second) => 
    second.Length == first.Length ? (second + second).IndexOf(first) : -1;
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class CalculateStringRotationTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(5, CalculateStringRotation.ShiftedDiff("fatigue","tiguefa"));
      Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("hoop","pooh"));
      Assert.AreEqual(4, CalculateStringRotation.ShiftedDiff("eecoff","coffee"));
      Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("Moose","moose"));
      Assert.AreEqual(2, CalculateStringRotation.ShiftedDiff("isn't","'tisn"));
      Assert.AreEqual(0, CalculateStringRotation.ShiftedDiff("Esham","Esham"));
      Assert.AreEqual(0, CalculateStringRotation.ShiftedDiff(" "," "));
      Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("dog","god"));
      Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("  "," "));
      Assert.AreEqual(-1, CalculateStringRotation.ShiftedDiff("doomhouse","hoodmouse"));
      Assert.AreEqual(18, CalculateStringRotation.ShiftedDiff("123456789!@#$%^&*( )qwerty","9!@#$%^&*( )qwerty12345678"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
            
      var characters = "abcdeFGHIJklmnOPQRSTuvwxyz() @!";
      for(int i=0;i<40;i++)
      {
        var length = rand.Next(6, 32);
        var rot = rand.Next(0, length-1);
        
        var word = string.Concat(Enumerable.Range(0,length).Select(a => characters[rand.Next(0, characters.Length)]));
        
        var rotWord = word.Substring(rot) + word.Substring(0,rot);
        
        if(rand.Next(5) == i % 5)
        {
          rotWord = "Z" + rotWord.Substring(1);
          rot = -1;
        }   
        
        Assert.AreEqual(rot, CalculateStringRotation.ShiftedDiff(rotWord, word));
      }
    }
  }
}
