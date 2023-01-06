/*Challenge link:https://www.codewars.com/kata/5302d846be2a9189af0001e4/train/csharp
Question:
Create a method sayHello/say_hello/SayHello that takes as input a name, city, and state to welcome a person. Note that name will be an array consisting of one or more values that should be joined together with one space between each, and the length of the name array in test cases will vary.

Example:

Kata.SayHello(new String[]{"John", "Smith"}, "Phoenix", "Arizona")
This example will return the string Hello, John Smith! Welcome to Phoenix, Arizona!
*/

//***************Solution********************
//join string together using string interpolation.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string SayHello(string[] a, string b, string c) => $"Hello, {string.Join(" ",a)}! Welcome to {b}, {c}!";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static object[] fixedTestCases = new object[]
    {
      new object[] {new string[] {"John", "Smith"}, "Phoenix", "Arizona", "Hello, John Smith! Welcome to Phoenix, Arizona!"},
      new object[] {new string[] {"Franklin", "Delano", "Roosevelt"}, "Chicago", "Illinois", "Hello, Franklin Delano Roosevelt! Welcome to Chicago, Illinois!"},
      new object[] {new string[] {"Wallace", "Russel", "Osbourne"}, "Albany", "New York", "Hello, Wallace Russel Osbourne! Welcome to Albany, New York!"},
    }.OrderBy(x => rnd.Next()).ToArray();
  
    [Test, TestCaseSource("fixedTestCases")]
    public void FixedTest(string[] name, string city, string state, string expected)
    {
      Assert.AreEqual(expected, Kata.SayHello(name, city, state));
    }
    
    private static string solution(string[] name, string city, string state) => $"Hello, {String.Join(" ", name)}! Welcome to {city}, {state}!";
    
    private static string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string[] name = new string[rnd.Next(1, 6)];
        for (int j = 0; j < name.Length; ++j)
        {
          int l = rnd.Next(3, 12);
          string n = "";
          for (int k = 0; k < l; ++k)
          {
            n += chars[rnd.Next(0, chars.Length)];
          }
          name[j] = n;
        }
        
        string city = "";
        string state = "";
        int length = rnd.Next(3, 12);
        for (int j = 0; j < length; ++j)
        {
          city += chars[rnd.Next(0, chars.Length)];
          state += chars[rnd.Next(0, chars.Length)];
        }
        
        string expected = solution(name, city, state);
        string actual = Kata.SayHello(name, city, state);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
