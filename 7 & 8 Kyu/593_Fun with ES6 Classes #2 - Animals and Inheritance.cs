/*Challenge link:https://www.codewars.com/kata/56f935002e6c0d55fa000d92/train/csharp
Question:
Fun with ES6 Classes #2 - Animals and Inheritance
Overview
Preloaded for you in this Kata is a class Animal:

public class Animal
{
  public int Age;
  public int Legs;
  public string Name;
  public string Species;
  public string Status;
  
  public Animal(string name, int age, int legs, string species, string status)
  {
    this.Name = name;
    this.Age = age;
    this.Legs = legs;
    this.Species = species;
    this.Status = status;
  }
  
  public virtual string Introduce()
  {
    return $"Hello, my name is {this.Name} and I am {this.Age} years old.";
  }
}
Task
Define the following classes that inherit from Animal.

I. Shark
The constructor function for Shark should accept 3 arguments in total in the following order: name, age, status. All sharks should have a leg count of 0 (since they obviously do not have any legs) and should have a species of "shark".

II. Cat
The constructor function for Cat should accept the same 3 arguments as with Shark: name, age, status. Cats should always have a leg count of 4 and a species of "cat".

Furthermore, the introduce/Introduce method for Cat should be identical to the original except there should be exactly 2 spaces and the words "Meow meow!" after the phrase. For example:

Cat example = new Cat("Example", 10, "Happy);
example.Introduce() => "Hello, my name is Example and I am 10 years old.  Meow meow!"; // Notice the TWO spaces - very important
III. Dog
The Dog constructor should accept 4 arguments in the specified order: name, age, status, master. master is the name of the dog's master which will be a string. Furthermore, dogs should have 4 legs and a species of "dog".

Dogs have an identical introduce/Introduce method as any other animal, but they have their own method called greetMaster/GreetMaster which accepts no arguments and returns "Hello (insert_master_name_here)" (of course not the literal string but replace the (insert_master_name_here) with the name of the dog's master).


*/

//***************Solution********************
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/


//3 arguments in total in the following order: name, age, status
// All sharks should have a leg count of 0, and should have a species of "shark".
public class Shark : Animal{
  public Shark(string name, int age, string status) : base(name, age, 0, "shark", status){}}

//Cats should always have a leg count of 4 and a species of "cat".
//the Introduce method for Cat, exactly 2 spaces and the words "Meow meow!"
public class Cat : Animal{
  public Cat(string name, int age, string status) : base(name, age, 4, "cat", status){}
  public string Introduce() => $"{base.Introduce()}  Meow meow!";
}

//The Dog constructor should accept 4 arguments in the specified order: name, age, status, master.
//dogs should have 4 legs and a species of "dog".
//introduce/Introduce method as any other animal
//have own method called GreetMaster which accepts no arguments and returns "Hello (insert_master_name_here)"
public class Dog : Animal{
  public string Master;
  public Dog(string name, int age, string status, string master) : base(name, age, 4, "dog", status){ Master = master;}
  public string GreetMaster() => $"Hello {Master}";
}



//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  public static class Utility
  {
    private static Random rnd = new Random();
    public static string RandomToken() => String.Concat(new char[rnd.Next(10, 20)].Select(_ => (char)rnd.Next(97, 123)));
    public static int RandomAge() => rnd.Next(0, 101);
  }

  [TestFixture]
  public class SharkTest
  {
    [Test, Description("should construct an object properly")]
    public void ConstructorTest()
    {
      Shark billy = new Shark("Billy", 3, "Alive and well");
      Assert.AreEqual("Billy", billy.Name);
      Assert.AreEqual(3, billy.Age);
      Assert.AreEqual(0, billy.Legs);
      Assert.AreEqual("shark", billy.Species);
      Assert.AreEqual("Alive and well", billy.Status);
      Assert.AreEqual("Hello, my name is Billy and I am 3 years old.", billy.Introduce());
      Shark charles = new Shark("Charles", 8, "Looking for a mate");
      Assert.AreEqual("Charles", charles.Name);
      Assert.AreEqual(8, charles.Age);
      Assert.AreEqual(0, charles.Legs);
      Assert.AreEqual("shark", charles.Species);
      Assert.AreEqual("Looking for a mate", charles.Status);
      Assert.AreEqual("Hello, my name is Charles and I am 8 years old.", charles.Introduce());
    }
    
    [Test, Description("should work for random tests as well")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string a = Utility.RandomToken();
        int    b = Utility.RandomAge();
        string c = Utility.RandomToken();
        Shark  s = new Shark(a, b, c);
        
        Assert.AreEqual(a, s.Name);
        Assert.AreEqual(b, s.Age);
        Assert.AreEqual(0, s.Legs);
        Assert.AreEqual("shark", s.Species);
        Assert.AreEqual(c, s.Status);
        Assert.AreEqual($"Hello, my name is {a} and I am {b} years old.", s.Introduce());
      }
    }
  }
  
  [TestFixture]
  public class CatTest
  {
    [Test, Description("should construct an object properly")]
    public void ConstructorTest()
    {
      Cat cathy = new Cat("Cathy", 7, "Playing with a ball of yarn");
      Assert.AreEqual("Cathy", cathy.Name);
      Assert.AreEqual(7, cathy.Age);
      Assert.AreEqual(4, cathy.Legs);
      Assert.AreEqual("cat", cathy.Species);
      Assert.AreEqual("Playing with a ball of yarn", cathy.Status);
      Assert.AreEqual("Hello, my name is Cathy and I am 7 years old.  Meow meow!", cathy.Introduce());
      Cat spitsy = new Cat("Spitsy", 6, "sleeping");
      Assert.AreEqual("Spitsy", spitsy.Name);
      Assert.AreEqual(6, spitsy.Age);
      Assert.AreEqual(4, spitsy.Legs);
      Assert.AreEqual("cat", spitsy.Species);
      Assert.AreEqual("sleeping", spitsy.Status);
      Assert.AreEqual("Hello, my name is Spitsy and I am 6 years old.  Meow meow!", spitsy.Introduce());
    }
    
    [Test, Description("should work for random tests as well")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string a = Utility.RandomToken();
        int    b = Utility.RandomAge();
        string c = Utility.RandomToken();
        Cat    s = new Cat(a, b, c);
        
        Assert.AreEqual(a, s.Name);
        Assert.AreEqual(b, s.Age);
        Assert.AreEqual(4, s.Legs);
        Assert.AreEqual("cat", s.Species);
        Assert.AreEqual(c, s.Status);
        Assert.AreEqual($"Hello, my name is {a} and I am {b} years old.  Meow meow!", s.Introduce());
      }
    }
  }
  
  [TestFixture]
  public class DogTest
  {
    [Test, Description("should construct an object properly")]
    public void ConstructorTest()
    {
      Dog doug = new Dog("Doug", 12, "Serving his master", "Eliza");
      Assert.AreEqual("Doug", doug.Name);
      Assert.AreEqual(12, doug.Age);
      Assert.AreEqual(4, doug.Legs);
      Assert.AreEqual("dog", doug.Species);
      Assert.AreEqual("Serving his master", doug.Status);
      Assert.AreEqual("Hello Eliza", doug.GreetMaster());
    }
    
    [Test, Description("should work for random tests as well")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string a = Utility.RandomToken();
        int    b = Utility.RandomAge();
        string c = Utility.RandomToken(),
               d = Utility.RandomToken();
        Dog    s = new Dog(a, b, c, d);
        
        Assert.AreEqual(a, s.Name);
        Assert.AreEqual(b, s.Age);
        Assert.AreEqual(4, s.Legs);
        Assert.AreEqual("dog", s.Species);
        Assert.AreEqual(c, s.Status);
        Assert.AreEqual($"Hello, my name is {a} and I am {b} years old.", s.Introduce());
        Assert.AreEqual($"Hello {d}", s.GreetMaster());
      }
    }
  }
}
