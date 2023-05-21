/*Challenge link:https://www.codewars.com/kata/535474308bb336c9980006f2/train/csharp
Question:
Write a method that takes one argument as name and then greets that name, capitalized and ends with an exclamation point.

Example:

"riley" --> "Hello Riley!"
"JACK"  --> "Hello Jack!" 
*/

//***************Solution********************
//convert the first character to upper, then the rest to lower
//using string interpolation to format the string. return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
  public static string Greet(string name)=> $"Hello {char.ToUpper(name[0])}{name.Substring(1).ToLower()}!";
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Globalization;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.That(Kata.Greet("riley"), Is.EqualTo("Hello Riley!"));
    }
    
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("molly").Returns("Hello Molly!").SetDescription("should return \"Hello {Name}!\", if lowercase string is given");
        yield return new TestCaseData("BILLY").Returns("Hello Billy!").SetDescription("should return \"Hello {Name}!\", if uppercase string is given");
        yield return new TestCaseData("kEiTH").Returns("Hello Keith!").SetDescription("should return \"Hello {Name}!\", if mixedcase string is given");
      }
    }
    
    [Test, TestCaseSource("testCases")]
    public string FixedTest(string name) =>
      Kata.Greet(name);
      
    [Test]
    public void RandomTest()
    {
      Random rnd = new Random();
      
      for (int i = 0; i < 100; ++i)
      {
        string name = String.Concat(new char[rnd.Next(2, 10)].Select(_ => (char)rnd.Next(97, 123)).Select(c => rnd.Next(0, 2) == 0 ? Char.ToUpper(c) : Char.ToLower(c)));
        string expected = String.Format("Hello {0}!", CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower()));
        
        Assert.That(Kata.Greet(name), Is.EqualTo(expected));
      }
    }
  }
}
