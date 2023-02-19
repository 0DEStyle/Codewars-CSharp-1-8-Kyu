/*Challenge link:https://www.codewars.com/kata/559d2284b5bb6799e9000047/train/csharp
Question:
What if we need the length of the words separated by a space to be added at the end of that same word and have it returned as an array?

Example(Input --> Output)

"apple ban" --> ["apple 5", "ban 3"]
"you will win" -->["you 3", "will 4", "win 3"]
Your task is to write a function that takes a String and returns an Array/list with the length of each word added to each element .

Note: String will have at least one element; words will always be separated by a space.
*/

//***************Solution********************
//split the string int words
//select element(word) from the string, using string interpolation to create the string format
//word + " " + word.Length
//conver to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string[] AddLength(string str)=> str.Split().Select(x => $"{x} {x.Length}").ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  public class Solution
  {
    public static string[] AddLength(string str) =>
      str.Split(' ').Select(w => String.Format("{0} {1}", w, w.Length)).ToArray();
  }

  [TestFixture]
  public class Sample_Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new string[] {"apple 5", "ban 3"}, Kata.AddLength("apple ban"));
      Assert.AreEqual(new string[] {"you 3", "will 4", "win 3"}, Kata.AddLength("you will win"));
    }
  }
  
  [TestFixture]
  public class Fixed_Test
  {
    private static string[] testCases = new string[]
    {
      "you",
      "y",
      "x y z",
      "xyz",
      "xyz x y z zyx",
      "a bc cde",
      "a ab abc",
      "a ab abc ab a"
    };
    
    [Test, TestCaseSource("testCases")]
    public void FixedTests(string test)
    {
      string[] expected = Solution.AddLength(test);
      string[] actual = Kata.AddLength(test);
      
      Assert.AreEqual(expected, actual);
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
  
    private static string chars = "       abcdefghijklmnopqrstuvwxyz";
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Join(" ", String.Concat(new char[rnd.Next(1, 200)].Select(_ => chars[rnd.Next(0, chars.Length)])).Split(' ').Where(s => !String.IsNullOrEmpty(s)));
        if (test.Length == 0) { test = Char.ToString((char)rnd.Next(97, 123)); }
        
        string[] expected = Solution.AddLength(test);
        string[] actual = Kata.AddLength(test);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
