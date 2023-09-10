/*Challenge link:https://www.codewars.com/kata/5966847f4025872c7d00015b/train/csharp
Question:
You are given a string of numbers between 0-9. Find the average of these numbers and return it as a floored whole number (ie: no decimal places) written out as a string. Eg:

"zero nine five two" -> "four"

If the string is empty or includes a number greater than 9, return "n/a"
*/

//***************Solution********************
using System;
using System.Linq;

public class Kata{
  //fixed string, access by index
    static string[] Numbers = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
  
  
    public static string AverageString(string str){
      //If the string is empty or includes a number greater than 9, return "n/a"
        if (!str.Split().All(Numbers.Contains)) return "n/a";
      //split the string str, select the number by accessing the index of Numbers, 
      //floor the numbers and convert to int, then get the average
      //select the string from Numbers by accessing the index
        return Numbers[(int)Math.Floor(str.Split().Select(x => Array.IndexOf(Numbers, x)).Average())];
    }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual("four", Kata.AverageString("zero nine five two"));
      Assert.AreEqual("three", Kata.AverageString("four six two three"));
      Assert.AreEqual("three", Kata.AverageString("one two three four five"));
      Assert.AreEqual("four", Kata.AverageString("five four"));
      Assert.AreEqual("zero", Kata.AverageString("zero zero zero zero zero"));
      Assert.AreEqual("two", Kata.AverageString("one one eight one"));
      Assert.AreEqual("n/a", Kata.AverageString(""));
    }
    
    private static string Solution(string str)
    {
      if (str.Length == 0) return "n/a";
    
      int sum = 0;
      Dictionary<string, int> nums = new Dictionary<string, int>()
      {
        {"zero", 0},
        {"one", 1},
        {"two", 2},
        {"three", 3},
        {"four", 4},
        {"five", 5},
        {"six", 6},
        {"seven", 7},
        {"eight", 8},
        {"nine", 9}
      };
      
      string[] strArr = str.Split(' ');
      
      foreach (string word in strArr)
      {
        if (!nums.ContainsKey(word)) return "n/a";
        sum += nums[word];
      }
      
      return new string[] {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"}[(int)Math.Floor((double)(sum / strArr.Length))];
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTests()
    {
      string chars = "abcdefghijklmnopqrstuvwxyz";
      string rndWord = "";
      for (int i = 0; i < 6; ++i) rndWord += chars[rnd.Next(0, chars.Length-1)];
      
      string[] strings = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", rndWord};
      
      for (int i = 0; i < 100; ++i)
      {
        List<string> testCases = new List<string>();
        int length = rnd.Next(1, 10);
        
        for (int j = 0; j < length; ++j)
        {
          testCases.Add(strings[rnd.Next(0, strings.Length)]);
        }
        
        Console.WriteLine("expected: {0}, input: {1}", Solution(String.Join(" ", testCases)), String.Join(", ", testCases));
        
        Assert.AreEqual(Solution(String.Join(" ", testCases)), Kata.AverageString(String.Join(" ", testCases))); 
      }
    }
  }
}
