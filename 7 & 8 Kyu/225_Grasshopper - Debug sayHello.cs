/*Challenge link:https://www.codewars.com/kata/5625618b1fe21ab49f00001f
Question:
Debugging sayHello function
The starship Enterprise has run into some problem when creating a program to greet everyone as they come aboard. It is your job to fix the code and get the program working again!

Example output:

Hello, Mr. Spock
*/

//***************Solution********************
//string interpolation
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string SayHello(string name) => $"Hello, {name}";
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("Mr. Spock", ExpectedResult="Hello, Mr. Spock")]
  [TestCase("Captain Kirk", ExpectedResult="Hello, Captain Kirk")]
  [TestCase("Liutenant Uhura", ExpectedResult="Hello, Liutenant Uhura")]
  [TestCase("Dr. McCoy", ExpectedResult="Hello, Dr. McCoy")]
  public static string FixedTest(string name)
  {
    return Kata.SayHello(name);
  }
  
  [Test]
  public static void RandomTest([Random(5,20, 100)]int num)
  {
    string alpha = "abcdefghijklmnopqrstuvwxyz";
    Random r = new Random();
    string randomName = "";
    for(int i = 0; i < num; i++)
    {
      randomName += alpha[r.Next(25)+1];
    }
    Assert.AreEqual(Solution(randomName), Kata.SayHello(randomName), "Should work for random name "+ randomName);
  }
  
  
  private static string Solution(string name)
  {
    return "Hello, " + name;
  }
}
