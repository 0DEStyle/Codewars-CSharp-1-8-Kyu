/*Challenge link:https://www.codewars.com/kata/5748a883eb737cab000022a6/train/csharp
Question:
Ahoy Matey!

Welcome to the seven seas.

You are the captain of a pirate ship.

You are in battle against the royal navy.

You have cannons at the ready.... or are they?

Your task is to check if the gunners are loaded and ready, if they are: Fire!

If they aren't ready: Shiver me timbers!

Your gunners for each test case are 2, 3 or 4.

When you check if they are ready their answers are in a dictionary and will either be: aye or nay

Firing with less than all gunners ready is non-optimum (this is not fire at will, this is fire by the captain's orders or walk the plank, dirty sea-dog!)

If all answers are 'aye' then Fire! if one or more are 'nay' then Shiver me timbers!

Also, check out the new Pirates!! Kata: https://www.codewars.com/kata/57e2d5f473aa6a476b0000fe
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//from directionary gunners, check if any values is not "aye", 
//if true return "Shiver me timbers!", else "Fire!"
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static string CannonsReady(Dictionary<string, string> gunners) => 
    gunners.Any(x => x.Value != "aye") ? "Shiver me timbers!" : "Fire!";
}

//solution 2
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata
{
  public static string CannonsReady(Dictionary<string, string> gunners)
  {
    return gunners.ContainsValue("nay") ? "Shiver me timbers!" :"Fire!";
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static string CannonsReady(Dictionary<string, string> gunners) =>
      gunners.Values.Any(v => v == "nay") ? "Shiver me timbers!" : "Fire!";
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("should fire the cannons when ready")]
    public void SampleAyeTest()
    {
      Dictionary<string, string> gunners = new Dictionary<string, string>
      {
        {"Mike", "aye"},
        {"Joe", "aye"},
        {"Johnson", "aye"},
        {"Peter", "aye"}
      };
    
      Assert.AreEqual("Fire!", Kata.CannonsReady(gunners));
    }
    
    [Test, Description("should shiver your timbers instead if not ready")]
    public void SampleNayTest()
    {
      Dictionary<string, string> gunners = new Dictionary<string, string>
      {
        {"Mike", "aye"},
        {"Joe", "nay"},
        {"Johnson", "aye"},
        {"Peter", "aye"}
      };
    
      Assert.AreEqual("Shiver me timbers!", Kata.CannonsReady(gunners));
    }
    
    [Test, Description("should give the correct response to random inputs")]
    public void RandomTest()
    {
      const int Tests = 100;
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        Dictionary<string, string> gunners = new Dictionary<string, string>
        {
          {"Peter", (rnd.Next(0, 4) == 0) ? "nay" : "aye"}
        };
        
        if (rnd.Next(0, 2) == 0) { gunners.Add("Mike", (rnd.Next(0, 4) == 0) ? "nay" : "aye"); }
        if (rnd.Next(0, 2) == 0) { gunners.Add("Joe", (rnd.Next(0, 4) == 0) ? "nay" : "aye"); }
        if (rnd.Next(0, 2) == 0) { gunners.Add("Johnson", (rnd.Next(0, 4) == 0) ? "nay" : "aye"); }
        
        string expected = Kata.CannonsReady(gunners);
        string actual = Solution.CannonsReady(gunners);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
