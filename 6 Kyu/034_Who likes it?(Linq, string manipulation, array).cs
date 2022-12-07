/*Challenge link:https://www.codewars.com/kata/5266876b8f4bf2da9b000362/train/csharp
Question:
You probably know the "like" system from Facebook and other pages. People can "like" blog posts, pictures or other items. We want to create the text that should be displayed next to such an item.

Implement the function which takes an array containing the names of people that like an item. It must return the display text as shown in the examples:

[]                                -->  "no one likes this"
["Peter"]                         -->  "Peter likes this"
["Jacob", "Alex"]                 -->  "Jacob and Alex like this"
["Max", "John", "Mark"]           -->  "Max, John and Mark like this"
["Alex", "Jacob", "Mark", "Max"]  -->  "Alex, Jacob and 2 others like this"
Note: For 4 or more names, the number in "and 2 others" simply increases.
*/

//***************Solution********************
//apply condition, used String interpolation
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata
{
  public static string Likes(string[] name) =>
  name.Length == 0 ? "no one likes this":
  name.Length == 1 ? $"{name[0]} likes this":
  name.Length == 2 ? $"{name[0]} and {name[1]} like this":
  name.Length == 3 ? $"{name[0]}, {name[1]} and {name[2]} like this":
  $"{name[0]}, {name[1]} and {name.Length - 2} others like this";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  public static class Solution
  {
    public static string Likes(string[] names)
    {
      switch (names.Length)
      {
        case 0: return "no one likes this"; // :(
        case 1: return $"{names[0]} likes this";
        case 2: return $"{names[0]} and {names[1]} like this";
        case 3: return $"{names[0]}, {names[1]} and {names[2]} like this";
        default: return $"{names[0]}, {names[1]} and {names.Length - 2} others like this";
      }
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("It should return correct text")]
    public void SampleTest()
    {
      Assert.AreEqual("no one likes this", Kata.Likes(new string[0]));
      Assert.AreEqual("Peter likes this", Kata.Likes(new string[] {"Peter"}));
      Assert.AreEqual("Jacob and Alex like this", Kata.Likes(new string[] {"Jacob", "Alex"}));
      Assert.AreEqual("Max, John and Mark like this", Kata.Likes(new string[] {"Max", "John", "Mark"}));
      Assert.AreEqual("Alex, Jacob and 2 others like this", Kata.Likes(new string[] {"Alex", "Jacob", "Mark", "Max"}));
    }
    
    private static Random rnd = new Random();
    public static string[] names = new string[100].Select(_ => MakeWord()).ToArray();
    
    public static string MakeWord() =>
      String.Concat(new char[5].Select(_ => (char)rnd.Next(97, 123)));
      
    [Test, Description("Should return correct text for 0 names")]
    public void ZeroNameTest()
    {
      Assert.AreEqual(Solution.Likes(new string[0]), Kata.Likes(new string[0]));
    }
    
    [Test, Description("Should return correct text for 1 name")]
    public void OneNameTest()
    {
      Assert.AreEqual(Solution.Likes(names.Take(1).ToArray()), Kata.Likes(names.Take(1).ToArray()));
    }
    
    [Test, Description("Should return correct text for 2 names")]
    public void TwoNameTest()
    {
      Assert.AreEqual(Solution.Likes(names.Take(2).ToArray()), Kata.Likes(names.Take(2).ToArray()));
    }
    
    [Test, Description("Should return correct text for 3 names")]
    public void ThreeNameTest()
    {
      Assert.AreEqual(Solution.Likes(names.Take(3).ToArray()), Kata.Likes(names.Take(3).ToArray()));
    }
    
    [Test, Description("Should return correct text for 4 or more names")]
    public void FourNameTest()
    {
      // 4 names
      Assert.AreEqual(Solution.Likes(names.Take(4).ToArray()), Kata.Likes(names.Take(4).ToArray()));
      
      const int Tests = 1000;
      
      for (int i = 0; i < Tests; ++i)
      {
        names = names.OrderBy(_ => rnd.Next()).ToArray();
        string[] test = names.Take(rnd.Next(0, 101)).ToArray();
        
        string expected = Solution.Likes(test);
        string actual = Kata.Likes(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
