/*Challenge link:https://www.codewars.com/kata/5808dcb8f0ed42ae34000031/train/csharp
Question:
When provided with a number between 0-9, return it in words.

Input :: 1

Output :: "One".

If your language supports it, try using a switch statement.
 
*/

//***************Solution********************
//solution 1
//create a dictionary and store all the corresponding words to the number
//access number by dictionary key.
//return the result
using System.Collections.Generic;

public class Kata{
  public static string SwitchItUp(int number) {
    IDictionary<int, string> weight = new Dictionary<int, string>();

    var myDictionary = new Dictionary<int, string>(){
    {1, "One"},{2, "Two"},{3, "Three"},
    {4, "Four"},{5, "Five"},{ 6, "Six"},
    {7, "Seven"},{8, "Eight"},{9, "Nine"},
    {0, "Zero"}};
    return myDictionary[number];
    }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string SwitchItUp(int num)=> 
    new string[]{"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}[num];
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
      Assert.AreEqual("One", Kata.SwitchItUp(1));
      Assert.AreEqual("Three", Kata.SwitchItUp(3));
      Assert.AreEqual("Five", Kata.SwitchItUp(5));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int,string> mySwitchItUp = delegate (int number)
      {
        switch(number)
        {
          case 1: return "One";
          case 2: return "Two";
          case 3: return "Three";
          case 4: return "Four";
          case 5: return "Five";
          case 6: return "Six";
          case 7: return "Seven";
          case 8: return "Eight";
          case 9: return "Nine";    
        }
        return "Zero";
      };
      
      for(var i=0;i<97;i++)
      {
        var a = rand.Next(0,10);
        Assert.AreEqual(mySwitchItUp(a), Kata.SwitchItUp(a));
      }
    }
  }
}
