/*Challenge link:https://www.codewars.com/kata/5808e2006b65bff35500008f/train/csharp
Question:
When provided with a letter, return its position in the alphabet.

Input :: "a"

Ouput :: "Position of alphabet: 1"


*/

//***************Solution********************
//subtrack character ASCII position from starting of upper letter(64) to get the position of alphabet
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Kata{
  public static string Position(char a)=> $"Position of alphabet: {char.ToUpper(a) - 64}";  //or (int)a % 32
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
      Assert.AreEqual("Position of alphabet: 1", Kata.Position('a'));
      Assert.AreEqual("Position of alphabet: 26", Kata.Position('z'));
      Assert.AreEqual("Position of alphabet: 5", Kata.Position('e'));      
    }
        
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var letters ="abcdefghijklmnopqrstuvwxyz";
      for(var i=0;i<97;i++)
      {
        var idx = rand.Next(0,26);
      
        Console.WriteLine(idx);
        Assert.AreEqual("Position of alphabet: " + (idx+1), Kata.Position(letters[idx]));  
      }
    }
  } 
}
