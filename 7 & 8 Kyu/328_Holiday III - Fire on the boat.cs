/*Challenge link:https://www.codewars.com/kata/57e8fba2f11c647abc000944/train/csharp
Question:
Enjoying your holiday, you head out on a scuba diving trip!

Disaster!! The boat has caught fire!!

You will be provided a string that lists many boat related items. If any of these items are "Fire" you must spring into action. Change any instance of "Fire" into "~~". Then return the string.

Go to work!


*/

//***************Solution********************
//replace Fire with ~~
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata{
  public static string FireFight(string s) => s.Replace("Fire","~~");
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("Boat Rudder Mast Boat Hull Water ~~ Boat Deck Hull ~~ Propeller Deck ~~ Deck Boat Mast", Kata.FireFight("Boat Rudder Mast Boat Hull Water Fire Boat Deck Hull Fire Propeller Deck Fire Deck Boat Mast"));
      Assert.AreEqual("Mast Deck Engine Water ~~", Kata.FireFight("Mast Deck Engine Water Fire"));
      Assert.AreEqual("~~ Deck Engine Sail Deck ~~ ~~ ~~ Rudder ~~ Boat ~~ ~~ Captain", Kata.FireFight("Fire Deck Engine Sail Deck Fire Fire Fire Rudder Fire Boat Fire Fire Captain"));
      Assert.AreEqual("Boat Deck Boat", Kata.FireFight("Boat Deck Boat"));
      Assert.AreEqual("~~ Boat Captain", Kata.FireFight("Fire Boat Captain"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var names = new string[] { "Fire", "Boat", "Hull", "Propeller", "Engine", "Sail", "Deck", "Fire", "Fire", "Mast", "Captain", "Rudder", "Fire", "Water" };
      
      for (var i=0;i<40;i++)
      {
        var len = rand.Next(1,20);
        var s = string.Join(" ", Enumerable.Range(0,len).Select(a => names[rand.Next(0,names.Length-1)]).ToArray());
        
        Assert.AreEqual(s.Replace("Fire", "~~"), Kata.FireFight(s));
      }
    }
  }
}
