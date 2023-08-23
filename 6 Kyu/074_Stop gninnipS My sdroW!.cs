/*Challenge link:https://www.codewars.com/kata/5264d2b162488dc400000001/train/csharp
Question:
Write a function that takes in a string of one or more words, and returns the same string, but with all five or more letter words reversed (Just like the name of this Kata). Strings passed in will consist of only letters and spaces. Spaces will be included only when more than one word is present.

Examples:

spinWords( "Hey fellow warriors" ) => returns "Hey wollef sroirraw" 
spinWords( "This is a test") => returns "This is a test" 
spinWords( "This is another test" )=> returns "This is rehtona test"
*/

//***************Solution********************

//replace any word that is 5 characters long with the reverse version of the current element(word).
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static string SpinWords(string sentence) => 
    Regex.Replace(sentence, @"\w{5,}", m => string.Concat(m.Value.Reverse()));
}
//method 2 
using System.Collections.Generic;
using System.Linq;
using System;

public class Kata
{
  public static string SpinWords(string sentence)
  {
    return String.Join(" ", sentence.Split(' ').Select(str => str.Length >= 5 ? new string(str.Reverse().ToArray()) : str));
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Tests
{
  [Test]
  public static void Test1()
  {
    Assert.AreEqual("emocleW", Kata.SpinWords("Welcome"));
  }
  
  [Test]
  public static void Test2()
  {  
    Assert.AreEqual("Hey wollef sroirraw", Kata.SpinWords("Hey fellow warriors"));
  }
  
  [Test]
  public static void Test3()
  {  
    Assert.AreEqual("This ecnetnes is a ecnetnes", Kata.SpinWords("This sentence is a sentence"));
  }
}
