/*Challenge link:https://www.codewars.com/kata/5668e3800636a6cd6a000018/train/csharp
Question:
Oh no! Ghosts have reportedly swarmed the city. It's your job to get rid of them and save the day!

In this kata, strings represent buildings while whitespaces within those strings represent ghosts.

So what are you waiting for? Return the building(string) without any ghosts(whitespaces)!

Example:

ghostBusters("Sky scra per");
Should return:

"Skyscraper"
If the building contains no ghosts, return the string:

"You just wanted my autograph didn't you?"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//if string doesn't contain white space, return "You just wanted my autograph didn't you?"
//else replace all white space with nothing
public class Kata{
  public static string GhostBusters(string s) => 
    !s.Contains(' ') ? "You just wanted my autograph didn't you?" : System.Text.RegularExpressions.Regex.Replace(s, " ", "");
}

//****************Sample Test*****************
using NUnit.Framework;  
using System;
[TestFixture]
public class GhostBustersTest
{
  [Test]
  public void GenericTests()
  {
    Assert.AreEqual("Factory",Kata.GhostBusters("Factor y"), "Nope, there may still be a ghost in the building. Try again.");
    Assert.AreEqual("Office",Kata.GhostBusters("O  f fi ce"), "Nope, there may still be a ghost in the building. Try again.");
    Assert.AreEqual("You just wanted my autograph didn't you?",Kata.GhostBusters("BusStation"), "Nope, as there were no ghosts in the BusStation you need to return a witty retort.");
  }
  
  [Test]
  public void ExtraTests()
  {
    Assert.AreEqual("Suite",Kata.GhostBusters("Suite "), "Nope, there may still be a ghost in the building. Try again.");
    Assert.AreEqual("House",Kata.GhostBusters("H ou se"), "Nope, there may still be a ghost in the building. Try again.");
    Assert.AreEqual("You just wanted my autograph didn't you?",Kata.GhostBusters("YourHouse"), "Nope, as there were no ghosts in YourHouse you need to return a witty retort.");
    Assert.AreEqual("Hotel",Kata.GhostBusters("H o t e l "), "Nope, there may still be a ghost in the building. Try again.");
  }
  public static string GhostBustersT (string building)
    {
        if(!building.Contains(" "))
            return "You just wanted my autograph didn't you?";
        else
            return building.Replace(" ", "");
    }
    
    [Test]
    public static void RandomTests(){
      Console.WriteLine("\n ********** 50 Random Tests **********");
      Random rnd = new Random();
      string alph = "AaBbCcDdEeFfGgHhIi  ";
      for (int i = 0; i < 50; i++) {
        string randomString = ""; 
        int rando = rnd.Next(1,25);
        for(int j = 0; j<rando; j++)
        {
          int n = rnd.Next(0,alph.Length);
          randomString += alph[n];
        }
        Assert.AreEqual(GhostBustersT(randomString), Kata.GhostBusters(randomString), "The random string was " + randomString + ". Your answer returned: " + Kata.GhostBusters(randomString));
      }
    }
}
