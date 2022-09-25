/*Challenge link:
Question:
Complete the solution so that the function will break up camel casing, using a space between words.

Example
"camelCasing"  =>  "camel Casing"
"identifier"   =>  "identifier"
""             =>  ""

*/

//***************Solution********************
//Solution 1
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//set text to str because during insert, we don't want to increase str.Length
//or it will loop forever.
//shifting Index add 1 whenever a space is added.
//In string str, if a character is upper case
//insert a space at that index (now the length of the text +1)
//so shiftingIndex +1, and carried to the next loop;
//repeat the process and return the result.

using System;
public class Kata
{
  public static string BreakCamelCase(string str)
  {
    string text = str;
    int shiftIndex = 0;
    
    for(int i = 0; i < str.Length; i++){
      if(Char.IsUpper(str[i])){
        text = text.Insert(i + shiftIndex, " ");
        shiftIndex++;
      }
    }
    return text;
  }
}
//Solution 2

//if a character is upper, concatenate space + character, else concate the letter itself.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Kata
{
  public static string BreakCamelCase(string str) =>
    string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));

}ic string BreakCamelCase(string str) => string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));
}

//Solution 3 (regex)
//replace any capital letter in str with space and the letter itself
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;
public class Kata
{
  public static string BreakCamelCase(string str)=>
    new Regex("([A-Z])").Replace(str, " $0");
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Text;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class Sample_Tests
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData("camelCasing").Returns("camel Casing");
        yield return new TestCaseData("camelCasingTest").Returns("camel Casing Test");
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public string Test(string str) => Kata.BreakCamelCase(str);
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static Random rnd = new Random();
    
    private static string solution(string str) => new Regex("([A-Z])").Replace(str, " $1");
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        StringBuilder sb = new StringBuilder();
        sb.Append((char)rnd.Next(97, 123));
        int length = rnd.Next(10, 200);
        
        for (int j = 0; j < length; ++j)
        {
          char c = (char)rnd.Next(97, 123);
          if (rnd.Next(0, 5) == 0)
          {
            c = Char.ToUpper(c);
          }
          sb.Append(c);
        }
        
        string str = sb.ToString();
        
        string expected = solution(str);
        string actual = Kata.BreakCamelCase(str);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
