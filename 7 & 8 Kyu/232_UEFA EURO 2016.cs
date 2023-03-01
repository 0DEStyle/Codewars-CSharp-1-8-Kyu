/*Challenge link:https://www.codewars.com/kata/57613fb1033d766171000d60/train/csharp
Question:
Finish the uefaEuro2016() function so it return string just like in the examples below:

uefaEuro2016(['Germany', 'Ukraine'],[2, 0]) // "At match Germany - Ukraine, Germany won!"
uefaEuro2016(['Belgium', 'Italy'],[0, 2]) // "At match Belgium - Italy, Italy won!"
uefaEuro2016(['Portugal', 'Iceland'],[1, 1]) // "At match Portugal - Iceland, teams played draw."
*/

//***************Solution********************
//return condition accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string UefaEuro2016(string[] teams, int[] scores)=>
    scores[0] > scores[1] ? $"At match {teams[0]} - {teams[1]}, {teams[0]} won!" :
    scores[1] > scores[0] ? $"At match {teams[0]} - {teams[1]}, {teams[1]} won!" :
    $"At match {teams[0]} - {teams[1]}, teams played draw.";
}

//solution 2
public class Kata
{
  public static string UefaEuro2016(string[] t, int[] s)
  {
    return $"At match {t[0]} - {t[1]}, {(s[0] == s[1] ? "teams played draw." : t[s[0] > s[1] ? 0 : 1] + " won!")}";
  }
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
      Assert.AreEqual("At match Germany - Ukraine, Germany won!", Kata.UefaEuro2016(new [] { "Germany", "Ukraine"}, new [] { 2, 0 }));
      Assert.AreEqual("At match Belgium - Italy, Italy won!", Kata.UefaEuro2016(new [] { "Belgium", "Italy"}, new [] { 0, 2 }));
      Assert.AreEqual("At match Portugal - Iceland, teams played draw.", Kata.UefaEuro2016(new [] { "Portugal", "Iceland"}, new [] { 1, 1 }));
      Assert.AreEqual("At match France - Romania, France won!", Kata.UefaEuro2016(new [] { "France", "Romania"}, new [] { 2, 0 }));
      Assert.AreEqual("At match Albania - Switzerland, Switzerland won!", Kata.UefaEuro2016(new [] { "Albania", "Switzerland"}, new [] { 0, 2 }));
      Assert.AreEqual("At match Republic of Ireland - Sweden, teams played draw.", Kata.UefaEuro2016(new [] { "Republic of Ireland", "Sweden"}, new [] { 1, 1 }));
    }
    
    [Test]
    public void RandomTests()    
    {
      var rand = new Random();
      
      var listOfQualifiedTeams = new [] { "Albania", "Austria", "Belgium", "Croatia", "Czech Republic", "England", "France", "Germany", 
                               "Hungary", "Iceland", "Italy", "Northern Ireland", "Poland", "Portugal", "Republic of Ireland",
                               "Romania", "Russia", "Slovakia", "Spain", "Sweden", "Switzerland", "Turkey", "Ukraine", "Wales"};
      
      for (var iteration = 0; iteration <= 50; iteration += 1) 
      {
        var teamA = listOfQualifiedTeams[rand.Next(0, listOfQualifiedTeams.Length)];
        string teamB = teamA;
        while(teamB == teamA)
        {
          teamB = listOfQualifiedTeams[rand.Next(0, listOfQualifiedTeams.Length)];
        }
        var scoreA = rand.Next(0, 10);
        var scoreB = rand.Next(0, 10);
        
        if (scoreA > scoreB) 
        {
          Assert.AreEqual("At match " + teamA + " - " + teamB + ", " + teamA + " won!", Kata.UefaEuro2016(new [] { teamA, teamB }, new [] { scoreA, scoreB }));
        }

        if (scoreA < scoreB) 
        {
          Assert.AreEqual("At match " + teamA + " - " + teamB + ", " + teamB + " won!", Kata.UefaEuro2016(new [] { teamA, teamB }, new [] { scoreA, scoreB }));
        }
    
        if (scoreA == scoreB) 
        {
          Assert.AreEqual("At match " + teamA + " - " + teamB + ", teams played draw.", Kata.UefaEuro2016(new [] { teamA, teamB }, new [] { scoreA, scoreB }));
        }
      }
    }
  }
}
