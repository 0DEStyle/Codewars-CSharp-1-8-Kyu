/*Challenge link:https://www.codewars.com/kata/55a144eff5124e546400005a/train/csharp
Question:
Classy Classes
Basic Classes, this kata is mainly aimed at the new JS ES6 Update introducing classes

Task
Your task is to complete this Class, the Person class has been created. You must fill in the Constructor method to accept a name as string and an age as number, complete the get Info property and getInfo method/Info getter which should return johns age is 34

Reference: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/using-properties
*/

//***************Solution********************
public class Person{
  //local private
  private string PName;
  private int PAge;
  
  public Person(string name, int age){
    PName = name;
    PAge = age;
  }
  //format object Info using string interpolation
  public object Info => $"{PName}s age is {PAge}";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Person_Class_Test
  {
    [Test, Description("Fixed Tests")]
    public void FixedTests()
    {
      string[] names = new string[] {"john", "matt", "alex", "cam"};
      int[] ages = new int[] {16, 25, 57, 39};
      
      for (int i = 0; i < 4; ++i)
      {
        string name = names[i];
        int age = ages[i];
        Person person = new Person(name, age);
        Assert.AreEqual($"{name}s age is {age}", person.Info);
      }
    }
    
    private static Random rnd = new Random();
    
    private static string[] names = new string[] 
    {
      "john","matt","alex","cam","vinny","joe","steve","mary",
      "ash","joel","henry","brendan","roger","don","whimpy","chosen one",
      "master","frog","horse","cat","blop","god","morgan",
      "freeman","sean","shaun","dick","jeff","leroy","lee", "santa"
    };
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string name = names[rnd.Next(0, names.Length)];
        int age = rnd.Next(0, 101);
        Person person = new Person(name, age);
        Assert.AreEqual($"{name}s age is {age}", person.Info);
      }
    }
  }
}
