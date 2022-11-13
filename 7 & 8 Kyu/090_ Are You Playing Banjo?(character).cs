/*Challenge link:https://www.codewars.com/kata/53af2b8861023f1d88000832/train/csharp
Question:
Create a function which answers the question "Are you playing banjo?".
If your name starts with the letter "R" or lower case "r", you are playing banjo!

The function takes a name as its only argument, and returns one of the following strings:

name + " plays banjo" 
name + " does not play banjo"
Names given are always valid strings.
*/

//***************Solution********************
//check first letter, and return name + text accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string AreYouPlayingBanjo(string name) => name[0] == 'R' ||  name[0] == 'r' ? name + " plays banjo" : name + " does not play banjo";
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class AreYouPlayingBanjo
{
  [Test]
  public static void Paul()
  {
    Assert.AreEqual("Paul does not play banjo", Kata.AreYouPlayingBanjo("Paul"));
  }
  
  [Test]
  public static void Adam()
  {
    Assert.AreEqual("Adam does not play banjo", Kata.AreYouPlayingBanjo("Adam"));
  }
  
  [Test]
  public static void Ringo()
  {
    Assert.AreEqual("Ringo plays banjo", Kata.AreYouPlayingBanjo("Ringo"));
  }
  
  [Test]
  public static void bravo()
  {
    Assert.AreEqual("bravo does not play banjo", Kata.AreYouPlayingBanjo("bravo"));
  }
  
  [Test]
  public static void rolf()
  {
    Assert.AreEqual("rolf plays banjo", Kata.AreYouPlayingBanjo("rolf"));
  }
}
