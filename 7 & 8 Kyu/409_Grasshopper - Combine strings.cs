/*Challenge link:https://www.codewars.com/kata/55f73f66d160f1f1db000059/train/csharp
Question:
Combine strings function
Create a function named (Combine_names) that accepts two parameters (first and last name). The function should return the full name.

Example:

CombineNames("James", "Stevens")
returns:

"James Stevens"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//string interpolation
public class Kata{
public static string CombineNames(string a, string b) => $"{a} {b}";
}


//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("James", "Stevens", ExpectedResult="James Stevens")]
  public static string FixedTest(string a, string b)
  {
    return Kata.CombineNames(a, b);
  }
  
  private static string Solution(string firstname, string lastname)
  {
    return firstname + " " + lastname;
  }
  
  [Test]
  public static void RandomTest([Random(1,10,50)]int x)
  {
    string f = GetRandomString(x);
    string l = GetRandomString(x);
    Assert.AreEqual(Solution(f, l), Kata.CombineNames(f, l), string.Format("Should work for {0}, {1}", f, l));
  }
  
  private static string GetRandomString(int length)
  {
    Random r = new Random();
    string alpha = "abcdefghijklmnopqrstuvwxyz";
    string str = string.Empty;
    for(int i = 0; i < length; i++)
    {
      str += alpha[r.Next(26)];
    }
    return str;
  }
}
