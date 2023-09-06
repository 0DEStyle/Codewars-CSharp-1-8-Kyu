/*Challenge link:https://www.codewars.com/kata/54bb6f887e5a80180900046b/train/csharp
Question:
Longest Palindrome
Find the length of the longest substring in the given string s that is the same in reverse.

As an example, if the input was “I like racecars that go fast”, the substring (racecar) length would be 7.

If the length of the input string is 0, the return value must be 0.

Example:
"a" -> 1 
"aab" -> 2  
"abcde" -> 1
"zzbaabcd" -> 4
"" -> 0
*/

//***************Solution********************

//if string str is null or empty, return 0
//else create loop, start from 0, count up to str.Length
//select many, i is current element
//create loop start from i, count up to str.Length - i + 1,
//j is the current element, from there select all element with str.Substring(i, j - i)

//then from the previous selected element, reverse the string str and concatenate it,
//check if the string contains current element x
//get max value of x.Length and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata{
  public static int GetLongestPalindrome(string str) => 
    string.IsNullOrEmpty(str) ?  0 : 
           Enumerable.Range(0, str.Length)
                     .SelectMany(i => Enumerable.Range(i, str.Length - i + 1).Select(j => str.Substring(i, j - i)))
                     .Where(x => string.Concat(str.Reverse()).Contains(x)).Max(x => x.Length);
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [TestCase("", ExpectedResult = 0, Description = "empty string test")]
    [TestCase(null, ExpectedResult = 0, Description = "'null' value test")]
    [TestCase("a", ExpectedResult = 1, Description = "'a' value test")]
    [TestCase("aa", ExpectedResult = 2, Description = "'aa' value test")]
    [TestCase("baa", ExpectedResult = 2, Description = "'baa' value test")]
    [TestCase("abc0cba1", ExpectedResult = 7, Description = "'abc0cba1' value test")]
    [TestCase("12 21glg", ExpectedResult = 5, Description = "'12 21glg' value test")]
    [TestCase("   ", ExpectedResult = 3, Description = "empty space test")]
    public int SampleTest(string str)
    {
      return Kata.GetLongestPalindrome(str);
    }
    
    [TestCase(@"\r\nn\r\", ExpectedResult = 8, Description = "secret test1")]
    [TestCase(@"|.\.\.|", ExpectedResult = 7, Description = "secret test2")]
    [TestCase("арозаупаланалапуазора", ExpectedResult = 21, Description = "russian secret test3")]
    [TestCase("WWiww", ExpectedResult = 2, Description = "secret test4")]
    public int AdditionalTest(string str)
    {
      return Kata.GetLongestPalindrome(str);
    }
  }
}
