/*Challenge link:https://www.codewars.com/kata/55225023e1be1ec8bc000390/train/csharp
Question:
Jenny has written a function that returns a greeting for a user. However, she's in love with Johnny, and would like to greet him slightly different. She added a special case to her function, but she made a mistake.

Can you help her?
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression
//string interpolation for format and tenary to condition.
public static class Kata{
  public static string greet(string name) => name == "Johnny" ? "Hello, my love!" : $"Hello, {name}!";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class JennysGreeting
{
  [Test]
  public static void ShouldGreetJimNormally()
  {
    Assert.AreEqual("Hello, Jim!", Kata.greet("Jim"));
  }
  [Test]
  public static void ShouldGreetJaneNormally()
  {
    Assert.AreEqual("Hello, Jane!", Kata.greet("Jane"));
  }
  [Test]
  public static void ShouldGreetSimonNormally()
  {
    Assert.AreEqual("Hello, Simon!", Kata.greet("Simon"));
  }
  
  [Test]
  public static void ShouldGreetJohnnySpecially()
  {
    Assert.AreEqual("Hello, my love!", Kata.greet("Johnny"));
  }
}
