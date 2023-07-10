/*Challenge link:https://www.codewars.com/kata/598d91785d4ce3ec4f000018/train/csharp
Question:
Given a string "abc" and assuming that each letter in the string has a value equal to its position in the alphabet, our string will have a value of 1 + 2 + 3 = 6. This means that: a = 1, b = 2, c = 3 ....z = 26.

You will be given a list of strings and your task will be to return the values of the strings as explained above multiplied by the position of that string in the list. For our purpose, position begins with 1.

nameValue ["abc","abc abc"] should return [6,24] because of [ 6 * 1, 12 * 2 ]. Note how spaces are ignored.

"abc" has a value of 6, while "abc abc" has a value of 12. Now, the value at position 1 is multiplied by 1 while the value at position 2 is multiplied by 2.

Input will only contain lowercase characters and spaces.

Good luck!
*/

//***************Solution********************
//from string a, select element x where character is a letter
//convert the character to ascii value by subtracting 'a', because the requirement starts at 1, so we add 1
//then because "the value at position 1 is multiplied by 1 while the value at position 2 is multiplied by 2"
//we times the result by (i+1)
//store in array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata
{
  public static int[] WordValue(string[] a) =>
    a.Select((x, i) => x.Where(c => char.IsLetter(c)).Sum(c => c - 'a' + 1) * (i + 1)).ToArray();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  [TestFixture]
  public class SolutionTest
  {
    private static IEnumerable<TestCaseData> sampleTestCases
    {
      get
      {
        yield return new TestCaseData(new[] {new string[] {"codewars", "abc", "xyz"}}).Returns(new int[] {88, 12, 225});
        yield return new TestCaseData(new[] {new string[] {"abc abc", "abc abc", "abc", "abc"}}).Returns(new int[] {12, 24, 18, 24});
      }
    }
  
    [Test, TestCaseSource("sampleTestCases")]
    public int[] SampleTest(string[] a) => Kata.WordValue(a);
    
    private static IEnumerable<TestCaseData> detailedTestCases
    {
      get
      {
        yield return new TestCaseData(new[] {new string[] {"abc","abc","abc","abc"}}).Returns(new int[] {6,12,18,24});
        yield return new TestCaseData(new[] {new string[] {"abcdefghijklmnopqrstuvwxyz","stamford bridge","haskellers"}}).Returns(new int[] {351,282,330});
        yield return new TestCaseData(new[] {new string[] {"i love coding","better than pizza","i got this"}}).Returns(new int[] {115,382,321});
        yield return new TestCaseData(new[] {new string[] {"mercury","venus","earth mars","jupiter saturn","uranus neptune"}}).Returns(new int[] {103, 162, 309, 768, 945});
        yield return new TestCaseData(new[] {new string[] {"a cup","some tea","more coffee","one glass"}}).Returns(new int[] {41, 156, 273, 368});
        yield return new TestCaseData(new[] {new string[] {"a","e","i","o","u","the end"}}).Returns(new int[] {1, 10, 27, 60, 105, 336});
        yield return new TestCaseData(new[] {new string[] {"coding","better pizza","i got this too"}}).Returns(new int[] {52, 296, 471});
      }
    }
    
    [Test, TestCaseSource("detailedTestCases")]
    public int[] DetailedTest(string[] a) => Kata.WordValue(a);
    
    private static Random rnd = new Random();
    
    private static int[] solution(string[] a) =>
      a.Select((v, i) =>
        v.Select(c => c == ' ' ? 0 : (int)c - 96)
         .Sum() * (i + 1)
      ).ToArray();
      
    [Test, Description("Random Tests (100 assertions)")]
    public void RandomTest()
    {
      const int Tests = 100;
      const int TestCaseLength = 20;
      
      for (int i = 0; i < Tests; ++i)
      {
        string[] test = new string[TestCaseLength].Select(_ =>
          {
            int length = rnd.Next(10, 30);
            StringBuilder phrase = new StringBuilder(length);
            for (int j = 0; j < length; ++j)
            {
              if (rnd.Next(0, 6) != 0)
              {
                phrase.Append((char)rnd.Next(97, 123));
              }
              else
              {
                phrase.Append(' ');
              }
            }
            
            return phrase.ToString();
          }).ToArray();
          
        string[] clone = (string[])test.Clone();
        int[] expected = solution(test);
        int[] actual = Kata.WordValue(test);
        
        Assert.AreEqual(clone, test, "User mutated the input array!");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
