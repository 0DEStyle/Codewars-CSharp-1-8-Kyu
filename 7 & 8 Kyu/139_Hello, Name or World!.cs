/*Challenge link:https://www.codewars.com/kata/57e3f79c9cb119374600046b/train/csharp
Question:
Define a method hello that returns "Hello, Name!" to a given name, or says Hello, World! if name is not given (or passed as an empty String).

Assuming that name is a String and it checks for user typos to return a name with a first capital letter (Xxxx).

Examples:

* With `name` = "john"  => return "Hello, John!"
* With `name` = "aliCE" => return "Hello, Alice!"
* With `name` not given 
  or `name` = ""        => return "Hello, World!"
*/

//***************Solution********************
//Using libray Globalization
//check if string is null or empty
//if true return "Hello, World!"
//else return "Hello, + title case name
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Globalization;

public static class Kata{
  public static string Hello(string name = "") => 
    string.IsNullOrEmpty(name) ? 
    "Hello, World!" : 
    $"Hello, {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}!";
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
  private static readonly Random Rand = new Random();

  private static string Solution(string name = "")
  {
      return string.IsNullOrEmpty(name)
          ? "Hello, World!"
          : $"Hello, {name.ToUpper()[0] + name[1..].ToLower()}!";
  }

  [Test]
  public void BasicTest()
  {
      Assert.AreEqual("Hello, Jeff!", Kata.Hello("jEFF"));
      Assert.AreEqual("Hello, Tony!", Kata.Hello("tonY"));
      Assert.AreEqual("Hello, Alicia!", Kata.Hello("Alicia"));
      Assert.AreEqual("Hello, Vasya!", Kata.Hello("vasya"));
      Assert.AreEqual("Hello, John!", Kata.Hello("JOHN"));
      Assert.AreEqual("Hello, World!", Kata.Hello(""));
      Assert.AreEqual("Hello, World!", Kata.Hello());
  }

  [Test]
  public void RandomTests1()
  {
      string[] names =
      {
          "James", "Christopher", "Ronald", "Mary", "Lisa", "Michelle",
          "John", "Daniel", "Anthony", "Patricia", "Nancy", "Laura",
          "Robert", "Paul", "Kevin", "Linda", "Karen", "Sarah", "Michael",
          "Mark", "Jason", "Barbara", "Betty", "Kimberly", "William", "Donald",
          "Jeff", "Elizabeth", "Helen", "Deborah", "David", "George", "Jennifer",
          "Sandra", "Richard", "Kenneth", "Maria", "Donna", "Charles", "Steven",
          "Susan", "Carol", "Joseph", "Edward", "Margaret", "Ruth", "Thomas",
          "Brian", "Dorothy", "Sharon", "Vasya", ""
      };

      for (var i = 0; i < 100; i++)
      {
          var randomName = names[Rand.Next(0, names.Length)];
          var expected = Kata.Hello(randomName);
          var actual = Solution(randomName);
          Assert.AreEqual(expected, actual);
      }
  }

  private static string RandomName()
  {
      const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
      return string.Concat(Enumerable.Repeat(chars, Rand.Next(2, chars.Length))
          .Select(s => s[Rand.Next(s.Length)]));
  }

  [Test]
  public void RandomTests2()
  {
      for (var i = 0; i < 100; i++)
      {
          var randomName = RandomName();
          string actual = Kata.Hello(randomName);
          string expected = Solution(randomName);
          Assert.AreEqual(expected, actual);
      }
  }
}
