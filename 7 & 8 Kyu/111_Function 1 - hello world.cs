/*Challenge link:https://www.codewars.com/kata/523b4ff7adca849afe000035/train/csharp
Question:
Description:
Make a simple function called greet that returns the most-famous "hello world!".

Style Points
Sure, this is about as easy as it gets. But how clever can you be to create the most creative hello world you can think of? What is a "hello world" solution you would want to show your friends?


*/

//***************Solution********************
//return the string
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static string greet() => "hello world!";
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class GreetTest
{
  [Test]
  public void ShouldReturnHelloWorld()
  {
    Assert.AreEqual("hello world!", Kata.greet());
  }
}
