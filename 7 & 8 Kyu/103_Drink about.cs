/*Challenge link:https://www.codewars.com/kata/56170e844da7c6f647000063/train/csharp
Question:
Kids drink toddy.
Teens drink coke.
Young adults drink beer.
Adults drink whisky.
Make a function that receive age, and return what they drink.

Rules:

Children under 14 old.
Teens under 18 old.
Young under 21 old.
Adults have 21 or more.
Examples: (Input --> Output)

13 --> "drink toddy"
17 --> "drink coke"
18 --> "drink beer"
20 --> "drink beer"
30 --> "drink whisky"
*/

//***************Solution********************
//apply condition
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Kata{
  public static string PeopleWithAgeDrink(int old) =>
    old < 14 ? "drink toddy" : old < 18
             ? "drink coke" : old < 21
             ? "drink beer" :"drink whisky";
}
//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(22, ExpectedResult="drink whisky")]
  [TestCase(0, ExpectedResult="drink toddy")]
  [TestCase(13, ExpectedResult="drink toddy")]
  [TestCase(14, ExpectedResult="drink coke")]
  [TestCase(15, ExpectedResult="drink coke")]
  [TestCase(20, ExpectedResult="drink beer")]
  [TestCase(21, ExpectedResult="drink whisky")]
  public static string FixedTest(int old)
  {
    return Kata.PeopleWithAgeDrink(old);
  }
  
  [Test]
  public static void RandomTest([Random(0, 30, 100)]int old)
  {
    Assert.AreEqual(Solution(old), Kata.PeopleWithAgeDrink(old), string.Format("Should work for {0}", old));
  }
  
  private static string Solution(int old)
  {
    if(old < 14) return "drink toddy";
    if(old < 18) return "drink coke";
    if(old < 21) return "drink beer";
    return "drink whisky";
  }
}
