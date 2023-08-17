/*Challenge link:https://www.codewars.com/kata/587731fda577b3d1b0001196/train/csharp
Question:
Write a method (or function, depending on the language) that converts a string to camelCase, that is, all words must have their first letter capitalized and spaces must be removed.

Examples (input --> output):
"hello case" --> "HelloCase"
"camel case word" --> "CamelCaseWord"
Don't forget to rate this kata! Thanks :)
*/

//***************Solution********************
//convert to titlecase.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using static System.Globalization.CultureInfo;

namespace Kata{
  public static class Problem{
    public static string CamelCase(this string str) => CurrentCulture.TextInfo.ToTitleCase(str).Replace(" ", "");
  }
}


//****************Sample Test*****************
namespace TestSolution
{
  using System;
  using System.Linq;
  
  public static class Problem
  {
    public static string TestCamelCase(this string str)  
    { 
      string[] sentence = str.Split(' ');
      sentence = sentence.Where(x => x != String.Empty).Select(x => Char.ToUpper(x[0]) + x.Substring(1, x.Length - 1)).ToArray();
      return String.Join("", sentence);
    }
  }
}

namespace Solution 
{
  using NUnit.Framework;
  using System;
  using Kata;
  using TestSolution;

  [TestFixture]
  public class Test
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("TestCase", "test case".CamelCase());
      Assert.AreEqual("CamelCaseMethod", "camel case method".CamelCase());
      Assert.AreEqual("SayHello", "say hello".CamelCase());
      Assert.AreEqual("CamelCaseWord", " camel case word".CamelCase());
      Assert.AreEqual("", "".CamelCase());
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      const string chars = "abcdefghijklmnopqrstuvwxyz";
      
      for (int i = 0; i < 40; ++i) 
      {
        string test = "";
        int loops = rnd.Next(20, 50);
        for (int j = 0; j < loops; ++j)
        {
          if (rnd.Next(0, 6) == 0) test += " ";
          else test += chars[rnd.Next(0, chars.Length)];
        }
        
        Console.WriteLine("Testing for '{0}', output was '{1}'", test, test.CamelCase());
        
        Assert.AreEqual(test.TestCamelCase(), test.CamelCase());
      }
    }
  }
}
