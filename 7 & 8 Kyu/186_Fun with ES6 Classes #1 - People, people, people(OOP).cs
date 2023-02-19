/*Challenge link:https://www.codewars.com/kata/56f7f8215d7c12c0e7000b19/train/csharp
Question:
Fun with ES6 Classes #1 - People, people, people
Time for some OOP fun!

Define a class Person with the following properties:

A constructor that accepts 4 arguments: firstName/FirstName (defaults to "John" if not set), lastName/LastName (defaults to "Doe" if not set), age/Age (defaults to 0 if not set) and gender/Gender (defaults to "Male" if not set). These should be stored in this.firstName/this.FirstName, this.lastName/this.LastName, this.age/this.Age and this.gender/this.Gender respectively.
A method sayFullName/SayFullName that accepts no arguments and returns the full name (e.g. "John Doe")
A class/static method greetExtraTerrestrials/GreetExtraTerrestrials that accepts one parameter raceName and returns "Welcome to Planet Earth raceName". For example, if the race name is "Martians", it should say "Welcome to Planet Earth Martians"
You may use any valid syntax you like; however, it is highly recommended that you complete this Kata using ES6 syntax and features.

Have fun! :D
*/

//***************Solution********************
//create fields with getters and setters
//create default arguments values
//allow user to set values to Person class
//create a method that returns first anme and last name
//create a static method that returns "Welcome to Plant Earth " + raceName (string interpolation)

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public class Person
{
  public string FirstName {get; set;}
  public string LastName {get; set;}
  public int Age {get; set;}
  public string Gender {get; set;}
  
  public Person (string firstName = "John", string lastName = "Doe",int age = 0,string gender = "Male"){
    this.FirstName = firstName;
    this.LastName = lastName;
    this.Age = age;
    this.Gender = gender;
  } 
  public string SayFullName() => $"{FirstName} {LastName}";
  public static string GreetExtraTerrestrials(string raceName) => $"Welcome to Planet Earth {raceName}";
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SampleTest
  {
    [Test, Description("should have the correct defaults")]
    public void DefaultArgsTest()
    {
      Person person = new Person();
      Assert.AreEqual("John", person.FirstName);
      Assert.AreEqual("Doe", person.LastName);
      Assert.AreEqual(0, person.Age);
      Assert.AreEqual("Male", person.Gender);
      Assert.AreEqual("John Doe", person.SayFullName());
    }
    
    [Test, Description("should work with a person Jane Doe")]
    public void CustomTest()
    {
      Person person = new Person("Jane", "Doe", 25, "Female");
      Assert.AreEqual("Jane", person.FirstName);
      Assert.AreEqual("Doe", person.LastName);
      Assert.AreEqual(25, person.Age);
      Assert.AreEqual("Female", person.Gender);
      Assert.AreEqual("Jane Doe", person.SayFullName());
    }
  }
  
  [TestFixture]
  public class FixedTest
  {
    [Test, Description("should work with a person Bob Anderson")]
    public void Test()
    {
      Person person = new Person("Bob", "Anderson", 18, "Male");
      Assert.AreEqual("Bob", person.FirstName);
      Assert.AreEqual("Anderson", person.LastName);
      Assert.AreEqual(18, person.Age);
      Assert.AreEqual("Male", person.Gender);
      Assert.AreEqual("Bob Anderson", person.SayFullName());
    }
    
    [Test, Description("should have a static class method GreetExtraTerrestrials")]
    public void StaticTest()
    {
      Assert.AreEqual("Welcome to Planet Earth Martians", Person.GreetExtraTerrestrials("Martians"));
      Assert.AreEqual("Welcome to Planet Earth Jovians", Person.GreetExtraTerrestrials("Jovians"));
      Assert.AreEqual("Welcome to Planet Earth Titans", Person.GreetExtraTerrestrials("Titans"));
    }
  }
  
  [TestFixture]
  public class RandomTest
  {
    private static Random rnd = new Random();
    public static string RandomToken() => String.Concat(new char[rnd.Next(10, 20)].Select(_ => (char)rnd.Next(97, 123)));
    
    [Test]
    public void Test()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string a = RandomToken(),
               b = RandomToken(),
               d = RandomToken(),
               e = RandomToken();
        int    c = rnd.Next(0, 101);
               
        Person person = new Person(a, b, c, d);
        Assert.AreEqual(a, person.FirstName);
        Assert.AreEqual(b, person.LastName);
        Assert.AreEqual(c, person.Age);
        Assert.AreEqual(d, person.Gender);
        Assert.AreEqual($"{a} {b}", person.SayFullName());
        Assert.AreEqual($"Welcome to Planet Earth {e}", Person.GreetExtraTerrestrials(e));
      }
    }
  }
}
