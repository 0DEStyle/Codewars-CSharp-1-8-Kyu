/*Challenge link:https://www.codewars.com/kata/55a14aa4817efe41c20000bc/train/csharp
Question:
Classy Extensions
Classy Extensions, this kata is mainly aimed at the new JS ES6 Update introducing extends keyword. You will be preloaded with the Animal class, so you should only edit the Cat class.
Task
Your task is to complete the Cat class which Extends Animal and replace the speak method to return the cats name + meows. e.g. 'Mr Whiskers meows.'
The name attribute is passed with this.name (JS), @name (Ruby) or self.name (Python).

Reference: JS, Ruby, Python.
*/

//***************Solution********************
//using the keyword "override" to run/replace the Speak method in Animal
//return sentence using string interpolation
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Cat : Animal{
  public Cat(string name) : base(name){}
    public override string Speak() => $"{Name} meows.";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Fixed_Tests
  {
    [Test]
    public void Test()
    {
      Cat cat = new Cat("Mr Whiskers");
      Assert.AreEqual("Mr Whiskers meows.", cat.Speak());
      Assert.That(cat is Animal, "The Cat class should inherit from Animal");
      
      cat = new Cat("Lamp");
      Assert.AreEqual("Lamp meows.", cat.Speak());
      Assert.That(cat is Animal, "The Cat class should inherit from Animal");

      cat = new Cat("$$Money Bags$$");
      Assert.AreEqual("$$Money Bags$$ meows.", cat.Speak());
      Assert.That(cat is Animal, "The Cat class should inherit from Animal");
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    public static Random rnd = new Random();
    public static string[] names = {"Mr Whiskers", "Lamp", "$$Money Bags$$", "meowmeow", "mirou", "milo", "spots", "dog", "llama", "code", "wars", "stripes", "dug", "barf"};
  
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string name = names[rnd.Next(0, names.Length)];
        Assert.AreEqual($"{name} meows.", new Cat(name).Speak());
      }
    }
  }
}
