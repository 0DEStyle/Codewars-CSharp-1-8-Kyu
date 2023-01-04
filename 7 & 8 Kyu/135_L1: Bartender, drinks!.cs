/*Challenge link:https://www.codewars.com/kata/568dc014440f03b13900001d/train/csharp
Question:
Complete the function that receives as input a string, and produces outputs according to the following table:

Input	Output
"Jabroni"	"Patron Tequila"
"School Counselor"	"Anything with Alcohol"
"Programmer"	"Hipster Craft Beer"
"Bike Gang Member"	"Moonshine"
"Politician"	"Your tax dollars"
"Rapper"	"Cristal"
anything else	"Beer"
Note: anything else is the default case: if the input to the function is not any of the values in the table, then the return value should be "Beer".

Make sure you cover the cases where certain words do not show up with correct capitalization. For example, the input "pOLitiCIaN" should still return "Your tax dollars".


*/

//***************Solution********************
//solution 1
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string GetDrinkByProfession(string p){
    p = p.ToLower();
  
    return p == "jabroni" ? "Patron Tequila" :
           p == "school counselor" ? "Anything with Alcohol" :
           p == "programmer" ? "Hipster Craft Beer" :
           p == "bike gang member" ? "Moonshine" :
           p == "politician" ? "Your tax dollars" :
           p == "rapper" ? "Cristal" : "Beer";
    }
}

//solution 2
public class Kata
{
  public static string GetDrinkByProfession(string p) => p.ToLower() switch
  {
    "jabroni" => "Patron Tequila",
    "school counselor" => "Anything with Alcohol",
    "programmer" =>  "Hipster Craft Beer",
    "bike gang member" => "Moonshine",
    "politician" => "Your tax dollars",
    "rapper" => "Cristal",
    _ => "Beer" 
  };
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string Solution(string p)
    {
      p = p.ToLower();
      Dictionary<string, string> list = new Dictionary<string, string>
      {
        {"jabroni", "Patron Tequila"},
        {"school counselor", "Anything with Alcohol"},
        {"programmer", "Hipster Craft Beer"},
        {"bike gang member", "Moonshine"},
        {"politician", "Your tax dollars"},
        {"rapper", "Cristal"},
      };
      if (!list.ContainsKey(p)) return "Beer";
      else return list[p];
    }
    
    private static string RandomString()
    {
      string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
      string str = "";
      int loops = rnd.Next(1, 20);
      for (int i = 0; i < loops; ++i)
      {
        str += chars[rnd.Next(0, chars.Length)];
      }
      return str;
    }
  
    [Test, Description("Fixed Tests")]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual("Patron Tequila", Kata.GetDrinkByProfession("jabrOni"), "'Jabroni' should map to 'Patron Tequila'"),
        () => Assert.AreEqual("Anything with Alcohol", Kata.GetDrinkByProfession("scHOOl counselor"), "'School Counselor' should map to 'Anything with alcohol'"),
        () => Assert.AreEqual("Hipster Craft Beer", Kata.GetDrinkByProfession("prOgramMer"), "'Programmer' should map to 'Hipster Craft Beer'"),
        () => Assert.AreEqual("Moonshine", Kata.GetDrinkByProfession("bike ganG member"), "'Bike Gang Member' should map to 'Moonshine'"),
        () => Assert.AreEqual("Your tax dollars", Kata.GetDrinkByProfession("poLiTiCian"), "'Politician' should map to 'Your tax dollars'"),
        () => Assert.AreEqual("Cristal", Kata.GetDrinkByProfession("rapper"), "'Rapper' should map to 'Cristal'"),
        () => Assert.AreEqual("Beer", Kata.GetDrinkByProfession("pundit"), "'Pundit' should map to 'Beer'"),
        () => Assert.AreEqual("Beer", Kata.GetDrinkByProfession("Pug"), "'Pug' should map to 'Beer'"),

        () => Assert.AreEqual("Patron Tequila", Kata.GetDrinkByProfession("jabrOnI"), "'Jabroni' should map to 'Patron Tequila'"),
        () => Assert.AreEqual("Anything with Alcohol", Kata.GetDrinkByProfession("scHOOl COUnselor"), "'School Counselor' should map to 'Anything with alcohol'"),
        () => Assert.AreEqual("Hipster Craft Beer", Kata.GetDrinkByProfession("prOgramMeR"), "'Programmer' should map to 'Hipster Craft Beer'"),
        () => Assert.AreEqual("Moonshine", Kata.GetDrinkByProfession("bike GanG member"), "'Bike Gang Member' should map to 'Moonshine'"),
        () => Assert.AreEqual("Your tax dollars", Kata.GetDrinkByProfession("poLiTiCiAN"), "'Politician' should map to 'Your tax dollars'"),
        () => Assert.AreEqual("Cristal", Kata.GetDrinkByProfession("RAPPer"), "'Rapper' should map to 'Cristal'"),
        () => Assert.AreEqual("Beer", Kata.GetDrinkByProfession("punDIT"), "'Pundit' should map to 'Beer'"),
        () => Assert.AreEqual("Beer", Kata.GetDrinkByProfession("pUg"), "'Pug' should map to 'Beer'"),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      string[] professions = new string[] {"jabroni", "school counselor", "programmer", "bike gang member", "politician", "rapper"};
      for (int i = 0; i < 100; ++i)
      {
        string test = rnd.Next(0, 2) == 0 ? professions[rnd.Next(0, professions.Length)] : RandomString();
        string expected = Solution(test);
        string actual = Kata.GetDrinkByProfession(test);
        Console.WriteLine($"'{test}' should map to '{expected}'");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
