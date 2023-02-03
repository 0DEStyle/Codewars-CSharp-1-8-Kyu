/*Challenge link:https://www.codewars.com/kata/56d49587df52101de70011e4/train/csharp
Question:
You have to write a function that describe Leo:

def leo(oscar):
  pass
if oscar was (integer) 88, you have to return "Leo finally won the oscar! Leo is happy".
if oscar was 86, you have to return "Not even for Wolf of wallstreet?!"
if it was not 88 or 86 (and below 88) you should return "When will you give Leo an Oscar?"
if it was over 88 you should return "Leo got one already!"


*/

//***************Solution********************
//return string accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static string Leo(int oscar) => 
    oscar > 88  ? "Leo got one already!" : 
    oscar == 88 ? "Leo finally won the oscar! Leo is happy" : 
    oscar == 86 ? "Not even for Wolf of wallstreet?!" : "When will you give Leo an Oscar?" ;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  public static Random rand = new Random();
  [Test]
  [TestCase(88, ExpectedResult = "Leo finally won the oscar! Leo is happy")]
  [TestCase(86, ExpectedResult = "Not even for Wolf of wallstreet?!")]
  [TestCase(80, ExpectedResult = "When will you give Leo an Oscar?")]
  [TestCase(90, ExpectedResult = "Leo got one already!")]
  public string LeoBasicTests(int oscar)
  {
    return Kata.Leo(oscar);
  }
  
  [Test]
  public void LeoRandomTests()
  {
    for (var i = 0; i < 50; i++)
      Assert.AreEqual(Kata.Leo(rand.Next(1, 80)), "When will you give Leo an Oscar?");
    for (var i = 0; i < 50; i++)
      Assert.AreEqual(Kata.Leo(rand.Next(89, 150)), "Leo got one already!");
  }
}
