/*Challenge link:https://www.codewars.com/kata/55a14f75ceda999ced000048/train/csharp
Question:
Template Strings
Template Strings, this kata is mainly aimed at the new JS ES6 Update introducing Template Strings
Task
Your task is to return the correct string using the Template String Feature.
Input
Two Strings, no validation is needed.
Output
You must output a string containing the two strings with the word ```' are '```
Reference: https://developer.mozilla.org/en/docs/Web/JavaScript/Reference/template_strings 
*/

//***************Solution********************
//using string interpolation to join strings together in the correct format.

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Templates{
  public static string TempleStrings(string obj, string feature) => $"{obj} are {feature}";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class TemplatesTests
  {
      [Test]
      public void FixedTests()
      {
          Assert.AreEqual("Animals are Good",Templates.TempleStrings("Animals","Good"));
          Assert.AreEqual("You are Special",Templates.TempleStrings("You","Special"));
          Assert.AreEqual("lives are frozen",Templates.TempleStrings("lives","frozen"));
      }
      [Test]
      public void RandomTests()
      {
          string[,] words = {
            {"lives","people","you","objects","swings","leaders"},
            {"childish","avoidable","frozen","hard","objective","cool"}};
          
          Random random = new Random();
          for (int i3214 = 1; i3214 < 40; i3214++) {
            int a = (int) Math.Floor((double)random.Next(0, 6));
            int b = (int) Math.Floor((double)random.Next(0, 6));
            Console.WriteLine($"{words[0,a]} are {words[1,b]}");
            Assert.AreEqual($"{words[0,a]} are {words[1,b]}",Templates.TempleStrings(words[0,a],words[1,b]));
          }
      }
  }
}
