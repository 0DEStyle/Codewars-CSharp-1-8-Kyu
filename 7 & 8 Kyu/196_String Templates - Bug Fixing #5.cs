/*Challenge link:https://www.codewars.com/kata/55c90cad4b0fe31a7200001f/train/csharp
Question:
Oh no! Timmy hasn't followed instructions very carefully and forgot how to use the new String Template feature, Help Timmy with his string template so it works as he expects!
*/

//***************Solution********************
//format string with string interpolation and join args with string.join ", "
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata {    //Timmy: What happened to my code?
    public static string buildString(string[] args) => $"I like {string.Join(", ", args)}!";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class KataTests 
{

  static Random r = new Random();

[Test]
    public static void FixedTests() 
    {
      Assert.AreEqual("I like Cheese, Milk, Chocolate!", Kata.buildString(new string[] {"Cheese","Milk","Chocolate"}));
      Assert.AreEqual("I like Cheese, Milk!", Kata.buildString(new string[] {"Cheese","Milk"}));
      Assert.AreEqual("I like Chocolate!", Kata.buildString(new string[] {"Chocolate"}));
    }

[Test]
    public static void RandomTests() 
    {
      string[] baseArray = new string[] {"Cheese","Milk","Chocolate","Anne", "Money","Micky","Rollercoasters", "Beach","Water","WaterMelons", "Coding","CodeWars","You"};
      int length = r.Next(0, baseArray.Length);
      string[] randomArray = new string[length];
      for(int i = 0; i < length; i++) randomArray[i] = baseArray[r.Next(0, baseArray.Length)];
      
      Assert.AreEqual("I like " + String.Join(", ", randomArray) +"!", Kata.buildString(randomArray));
    }
    
}
