/*Challenge link:https://www.codewars.com/kata/54da539698b8a2ad76000228/train/csharp
Question:
You live in the city of Cartesia where all roads are laid out in a perfect grid. You arrived ten minutes too early to an appointment, so you decided to take the opportunity to go for a short walk. The city provides its citizens with a Walk Generating App on their phones -- everytime you press the button it sends you an array of one-letter strings representing directions to walk (eg. ['n', 's', 'w', 'e']). You always walk only a single block for each letter (direction) and you know it takes you one minute to traverse one city block, so create a function that will return true if the walk the app gives you will take you exactly ten minutes (you don't want to be early or late!) and will, of course, return you to your starting point. Return false otherwise.

Note: you will always receive a valid array containing a random assortment of direction letters ('n', 's', 'e', or 'w' only). It will never give you an empty array (that's not a walk, that's standing still!).
*/

//***************Solution********************
//solution 1
//check for condition, walk mustn't be loger than 10 or shorter than 10
//join the elements together and perform replace using regex
//if the length is 0, meaning every diredction cancels out
//return true, else false
using System;
using System.Text.RegularExpressions;
public class Kata{
  public static bool IsValidWalk(string[] walk) {
    if(walk.Length > 10 || walk.Length < 10) return false;
    string str = string.Join("", walk);
    str = Regex.Replace(str, "ns|sn|we|ew","");
    return str.Length == 0;
    }
}

//soluton 2
//check if count is equal to 10, if true return true, else false.
using System.Linq;

public class Kata
{
  public static bool IsValidWalk(string[] walk) =>
     walk.Count(x => x == "n") == walk.Count(x => x == "s") && walk.Count(x => x == "e") == walk.Count(x => x == "w") && walk.Length == 10;
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static string[][] pass = new string[][]
    {
      new string[] {"n","s","n","s","n","s","n","s","n","s"},
      new string[] {"e","w","e","w","n","s","n","s","e","w"},
      new string[] {"n","s","e","w","n","s","e","w","n","s"}
    };
    
    private static string[][] fail = new string[][]
    {
      new string[] {"n"},
      new string[] {"n","s"},
      new string[] {"n","s","n","s","n","s","n","s","n","s","n","s"},
      new string[] {"n","s","e","w","n","s","e","w","n","s","e","w","n","s","e","w"},
      new string[] {"n","s","n","s","n","s","n","s","n","n"},
      new string[] {"e","e","e","w","n","s","n","s","e","w"},
      new string[] {"n","n","n","n","n","e","e","e","e","e"},
      new string[] {"s","s","s","s","s","w","w","w","w","w"},
      new string[] {"n","n","n","n","n","w","w","w","w","w"},
      new string[] {"s","s","s","s","s","e","e","e","e","e"},
      new string[] {"n","s","e","w","n","s","e","w","n","s","e","w","n","s","e","w","n","s","e","w"},
    };
    
    private static object[] testCases = new object[]
    {
      new object[] {fail[0], false, "should return false if walk is too short"},
      new object[] {fail[1], false, "should return false if walk is too short"},
      new object[] {fail[2], false, "should return false if walk is too long"},
      new object[] {fail[3], false, "should return false if walk is too long"},
      new object[] {fail[10], false, "should return false if walk is too long"},
      new object[] {fail[4], false, "should return false if walk does not bring you back to start"},
      new object[] {fail[5], false, "should return false if walk does not bring you back to start"},
      new object[] {fail[6], false, "should return false if walk does not bring you back to start"},
      new object[] {fail[7], false, "should return false if walk does not bring you back to start"},
      new object[] {fail[8], false, "should return false if walk does not bring you back to start"},
      new object[] {fail[9], false, "should return false if walk does not bring you back to start"},
      new object[] {pass[0], true, "should return true for a valid walk"},
      new object[] {pass[1], true, "should return true for a valid walk"},
      new object[] {pass[2], true, "should return true for a valid walk"},
    }.OrderBy(_ => rnd.Next()).ToArray();
  
    private static IEnumerable<TestCaseData> testCasesSource
    {
      get
      {
        foreach (object[] testCase in testCases)
        {
          yield return new TestCaseData(testCase[0]).Returns(testCase[1]).SetDescription(testCase[2] as string);
        }
      }
    }
  
    [Test, TestCaseSource("testCasesSource")]
    public bool Walk_Validator(string[] test) => Kata.IsValidWalk(test);
  }
}
