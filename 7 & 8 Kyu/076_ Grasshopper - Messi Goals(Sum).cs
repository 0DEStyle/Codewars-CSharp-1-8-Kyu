/*Challenge link:https://www.codewars.com/kata/55ca77fa094a2af31f00002a/train/csharp
Question:
Messi's Goal Total
Use variables to find the sum of the goals Messi scored in 3 competitions

Information
Messi goal scoring statistics:

Competition	Goals
La Liga	43
Champions League	10
Copa del Rey	5
Task
Create these three variables and store the appropriate values using the table above:
laLigaGoals
championsLeagueGoals
copaDelReyGoals
Create a fourth variable named totalGoals that stores the sum of all of Messi's goals for this year.
 
*/

//***************Solution********************
//assign scores, sum and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public static class Kata {
    public static int la_liga_goals =43;
    public static int champions_league_goals =10;
    public static int copa_del_rey_goals=5;
    public static int total_goals => la_liga_goals + champions_league_goals + copa_del_rey_goals;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class KataTests 
{

[Test]
    public static void Tests() 
    {
        Assert.AreEqual(Kata.la_liga_goals, 43);
        Assert.AreEqual(Kata.champions_league_goals, 10);
        Assert.AreEqual(Kata.copa_del_rey_goals, 5);
        Assert.AreEqual(Kata.total_goals, 58);
        
    }
} 
