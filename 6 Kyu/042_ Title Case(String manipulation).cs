/*Challenge link:https://www.codewars.com/kata/5202ef17a402dd033c000009/train/csharp
Question:
A string is considered to be in title case if each word in the string is either (a) capitalised (that is, only the first letter of the word is in upper case) or (b) considered to be an exception and put entirely into lower case unless it is the first word, which is always capitalised.

Write a function that will convert a string into title case, given an optional list of exceptions (minor words). The list of minor words will be given as a string with each word separated by a space. Your function should ignore the case of the minor words string -- it should behave in the same way even if the case of the minor word string is changed.

Arguments (Haskell)
First argument: space-delimited list of minor words that must always be lowercase except for the first word in the string.
Second argument: the original string to be converted.
Arguments (Other languages)
First argument (required): the original string to be converted.
Second argument (optional): space-delimited list of minor words that must always be lowercase except for the first word in the string. The JavaScript/CoffeeScript tests will pass undefined when this argument is unused.
Example
Kata.TitleCase("a clash of KINGS", "a an the of")   => "A Clash of Kings"
Kata.TitleCase("THE WIND IN THE WILLOWS", "The In") => "The Wind in the Willows"
Kata.TitleCase("the quick brown fox")               => "The Quick Brown Fox"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public static string TitleCase(string title, string minorWords="")=>
    string.Join(" ", title.ToLower().Split()                                      //convert title string to lower then split it
                .Select((w, i) => !$"{minorWords}".ToLower().Split()              //convert minorWords to lower then split it
                .Contains(w) || i == 0                                            //if the minorWords DOESN'T contain the word of w(from title) or index is 0
                ? string.Concat(w.Take(1)).ToUpper() + string.Concat(w.Skip(1))  //True case: take the first character, convert to upper case then concat the rest
                : w)                                                             //False case: return w as it is.
                .ToArray());                                                     //store as array and return the result
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
    [TestCase("aBC deF Ghi", null, "Abc Def Ghi")]
    [TestCase("ab", "ab", "Ab")]
    [TestCase("a bc", "bc", "A bc")]
    [TestCase("a bc", "BC", "A bc")]
    [TestCase("First a of in", "an often into", "First A Of In")]
    [TestCase("a clash of KINGS", "a an the OF", "A Clash of Kings")]
    [TestCase("the QUICK bRoWn fOX", "xyz fox quick the", "The quick Brown fox")]
    public void MyTest(string sampleTitle, string sampleMinorWords, string expected)
    {
      Assert.AreEqual(expected, Kata.TitleCase(sampleTitle, sampleMinorWords));
    }
    [Test]
    public void MyTest2()
    {
      Assert.AreEqual("", Kata.TitleCase(""));
    }
    [Test]
    public void MyTest3()
    {
      Assert.AreEqual("The Quick Brown Fox", Kata.TitleCase("the quick brown fox"));
    }
    
    private static Random rnd = new Random();
    
    public static string TitleCase(string title, string minorWords="")
    {
      if(string.IsNullOrEmpty(title))return "";
      
      string[] words = title.ToLower().Split(' ');
      string[] ex =(minorWords == null)? new string[1]: minorWords.ToLower().Split(' ');
      
      var result = new List<string>();
      for(int i=0; i<words.Length; i++)
      {
        if(i==0 || !ex.Contains(words[i])) 
          result.Add(ProperCase(words[i]));
        else
          result.Add(words[i]);
      }
  	  return string.Join(" ",result);
    }
    private static string ProperCase(string text)
    {
      return text[0].ToString().ToUpper() + text.Substring(1,text.Length-1);
    }
    
    private static string chars = "                      abcdefghjiklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string test = String.Join(" ", String.Concat(new String('.', rnd.Next(40, 201)).Select(_ => chars[rnd.Next(0, chars.Length)])).Split(' ').Where(s => !String.IsNullOrEmpty(s))).Trim();
        string[] words = test.Split(' ');
        string minorWords = String.Join(" ", new string[] {words[rnd.Next(0, words.Length)], words[rnd.Next(0, words.Length)], words[rnd.Next(0, words.Length)], words[rnd.Next(0, words.Length)]}.Distinct());
        
        string expected = TitleCase(test, minorWords);
        string actual = Kata.TitleCase(test, minorWords);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
