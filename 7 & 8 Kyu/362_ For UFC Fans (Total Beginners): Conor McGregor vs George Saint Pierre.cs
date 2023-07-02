/*Challenge link:https://www.codewars.com/kata/582dafb611d576b745000b74/train/csharp
Question:
This is a beginner friendly kata especially for UFC/MMA fans.

It's a fight between the two legends: Conor McGregor vs George Saint Pierre in Madison Square Garden. Only one fighter will remain standing, and after the fight in an interview with Joe Rogan the winner will make his legendary statement. It's your job to return the right statement depending on the winner!

If the winner is George Saint Pierre he will obviously say:

"I am not impressed by your performance."
If the winner is Conor McGregor he will most undoubtedly say:

"I'd like to take this chance to apologize.. To absolutely NOBODY!"
Good Luck!

Note
The given name may varies in casing, eg., it can be "George Saint Pierre" or "geOrGe saiNT pieRRE". Your solution should treat both as the same thing (case-insensitive).


*/

//***************Solution********************
//convert fighter to lowercase, check if the string contains "conor mcgregor"
//if true return sentence accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public static class Kata
{
  public static string Quote(string fighter) =>
      fighter.ToLower().Contains("conor mcgregor") ?
      "I'd like to take this chance to apologize.. To absolutely NOBODY!":
      "I am not impressed by your performance." ;
}

//solution 2
using System;

public static class Kata
{
  public static string Quote(string fighter)
  {
    return fighter.ToLower() == "conor mcgregor" ? @"I'd like to take this chance to apologize.. To absolutely NOBODY!" : @"I am not impressed by your performance.";
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class UppercaseForms
  {
    [Test, Description("Normal")]
    public void NormalUpperTest()
    {
      Assert.AreEqual("I am not impressed by your performance.", Kata.Quote("George Saint Pierre"));
      Assert.AreEqual("I'd like to take this chance to apologize.. To absolutely NOBODY!", Kata.Quote("Conor McGregor"));
    }
    
    [Test, Description("Full")]
    public void FullUpperTest()
    {
      Assert.AreEqual("I am not impressed by your performance.", Kata.Quote("GEORGE SAINT PIERRE"));
      Assert.AreEqual("I'd like to take this chance to apologize.. To absolutely NOBODY!", Kata.Quote("CONOR MCGREGOR"));
    }
  }
  
  [TestFixture]
  public class LowercaseForms
  {
    [Test, Description("Normal")]
    public void LowerNormalTest()
    {
      Assert.AreEqual("I am not impressed by your performance.", Kata.Quote("george saint pierre"));
      Assert.AreEqual("I'd like to take this chance to apologize.. To absolutely NOBODY!", Kata.Quote("conor mcgregor"));
    }
  }
}
