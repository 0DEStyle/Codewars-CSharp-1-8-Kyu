/*Challenge link:https://www.codewars.com/kata/5cba04533e6dce000eaf6126/train/csharp
Question:
Alan is going to watch the Blood Moon (lunar eclipse) tonight for the first time in his life. But his mother, who is a history teacher, thinks the Blood Moon comes with an evil intent. The ancient Inca people interpreted the deep red coloring as a jaguar attacking and eating the moon. But who believes in Inca myths these days? So, Alan decides to prove to her mom that there is no jaguar. How? Well, only little Alan knows that. For now, he needs a small help from you. Help him solve the following calculations so that he gets enough time to prove it before the eclipse starts.

Screenshot-3
(see image in link)
Three semicircles are drawn on AB, AD, and AF. Here CD is perpendicular to AB and EF is perpendicular to AD.

Task
Given the radius of the semicircle ADBCA, find out the area of the lune AGFHA (the shaded area).


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//Math.PI * r * r / 8.0 - 
//r * r * (Math.PI / 2.0 - 1) / 4.0;
public static class Kata {
  public static double BloodMoon(int r) => r * r / 4.0;
}

//****************Sample Test*****************
namespace Solution {
  
  using NUnit.Framework;
  using System;
  
  [TestFixture]
  public class SolutionTest
  {
    // prevents giving away expected answer (would be too much of a spoiler)
    static void Act(double expected, int r) => Assert.IsTrue(Math.Abs(expected - Kata.BloodMoon(r)) < 0.001d, $"Input -> r = {r}");
    
    [TestCase(0d, 0)]
    [TestCase(0.25d, 1)]
    [TestCase(1d, 2)]
    [TestCase(2.25d, 3)]
    public void FixedTests(double expected, int r) => Act(expected, r);
    
    [Test]
    public void RandomTests([Random(1, 10000, 200)] int r) => Act(r*r/4.0, r);
  }
}
