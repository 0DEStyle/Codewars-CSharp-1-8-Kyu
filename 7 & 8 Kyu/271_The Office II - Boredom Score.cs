/*Challenge link:https://www.codewars.com/kata/57ed4cef7b45ef8774000014/train/csharp
Question:
Every now and then people in the office moves teams or departments. Depending what people are doing with their time they can become more or less boring. Time to assess the current team.

You will be provided with an object(staff) containing the staff names as keys, and the department they work in as values.

Each department has a different boredom assessment score, as follows:

accounts = 1
finance = 2
canteen = 10
regulation = 3
trading = 6
change = 6
IS = 8
retail = 5
cleaning = 4
pissing about = 25

Depending on the cumulative score of the team, return the appropriate sentiment:

<=80: 'kill me now'
< 100 & > 80: 'i can handle this'
100 or over: 'party time!!'
*/

//***************Solution********************
//create a variable score to find the sum of dictionary staff using switch case
//then return a statment accordingly to condition
using System.Linq;
using System.Collections.Generic;

public class Kata
{
  public static string Boredom(Dictionary<string, string> staff)
  {
    var score = staff.Sum(x => x.Value switch
    {
        "accounts" => 1,
        "finance" => 2,
        "canteen" => 10,
        "regulation" => 3,
        "trading" => 6,
        "change" => 6,
        "IS" => 8,
        "retail" => 5,
        "cleaning" => 4,
        "pissing about" => 25,
        _ => 0
    });
    
    return score >= 100 ? "party time!!" : score <= 80 ? "kill me now" : "i can handle this";
  }
}


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class SolutionTest
{
  [Test]
  public void MyTest()
  {
    Assert.AreEqual("kill me now", Kata.Boredom(new Dictionary<string, string>() { { "Tim", "accounts" }, { "Jim", "trading" }, { "Sandy", "regulation" }, { "Andy", "accounts" }, { "Katie", "finance" }, { "Laura", "IS" } }));
    Assert.AreEqual("i can handle this", Kata.Boredom(new Dictionary<string, string>() { { "Jim", "pissing about" }, { "Tim", "regulation" }, { "Andy", "IS" }, { "Laura", "pissing about" }, { "Alex", "canteen" }, { "John", "canteen" } }));
    Assert.AreEqual("party time!!", Kata.Boredom(new Dictionary<string, string>() { { "Andy", "pissing about" }, { "Tim", "accounts" }, { "Smith", "pissing about" }, { "Randy", "pissing about" }, { "Sandy", "IS" }, { "Laura", "pissing about" } }));
  
    Dictionary<string, string> temp;
    Random rand = new Random();
    
    for(int i = 0; i < 70; i++)
    {
      temp = new Dictionary<string, string>();
      
      foreach (string name in _names)
      {
        if (rand.NextDouble() > 0.2)
        {
          temp.Add(name, _stuff.ElementAt(rand.Next(0, _stuff.Count)).Key);
        }
        Assert.AreEqual(MyBoredom(temp),Kata.Boredom(temp));
      }
    } 
  }
  
  private static List<string> _names = new List<string> {"Jim", "Tim", "Andy", "Sandy", "Randy", "Laura", "Katie", "Smith", "Alex", "John", "Alfred"};
  
  private static Dictionary<string, int> _stuff = new Dictionary<string, int>
  { { "accounts", 1 }, { "finance" , 2 }, { "canteen" , 10 }, { "regulation" , 3 }, { "trading" , 6 }, { "change" , 6 }, { "IS" ,8 }, { "retail" , 5 }, { "cleaning" , 4 }, { "pissing about" , 25 } };
  
  private static string MyBoredom(Dictionary<string, string> staff)
  {
      int value = staff.Sum(x => _stuff[x.Value]);
      return (value <= 80) ? "kill me now" : (value < 100) ? "i can handle this" : "party time!!";
  }
}
