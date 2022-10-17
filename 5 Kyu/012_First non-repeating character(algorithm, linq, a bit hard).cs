/*Challenge link:https://www.codewars.com/kata/52bc74d4ac05d0945d00054e/train/csharp
Question:
Write a function named first_non_repeating_letter that takes a string input, and returns the first character that is not repeated anywhere in the string.

For example, if given the input 'stress', the function should return 't', since the letter t only occurs once in the string, and occurs first in the string.

As an added challenge, upper- and lowercase letters are considered the same character, but the function should return the correct case for the initial letter. For example, the input 'sTreSS' should return 'T'.

If a string contains all repeating characters, it should return an empty string ("") or None -- see sample tests.
*/

//***************Solution********************

//solution 1
//check condition if s is  null or length is  0 or characters are repeated
//return ""
//else return the first letter

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata
{
  public static string FirstNonRepeatingLetter(string s) =>
    s == null || s.Length ==0 || !s.Where(x => s.Count(y => char.ToLower(x) == char.ToLower(y)) == 1).Any() ?
    "" : s.Where(x => s.Count(y => char.ToLower(x) == char.ToLower(y)) == 1).First().ToString();
}



//solution 2
//cleaner solution compare to solution 1
using System;
using System.Linq;

public class Kata
{
  public static string FirstNonRepeatingLetter(string s) =>
             s.GroupBy(char.ToLower)
            .Where(gr => gr.Count() == 1)
            .Select(x => x.First().ToString())
            .DefaultIfEmpty("")
            .First();
}

//solution 3
//using Null Conditional and Null Coalescing Operator

//Null Conditional ?. if one operation in a chain of conditions returns null, the rest of the chain doesn't execute.
//ref https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators

//Null Coalescing Operator ?? doesn't evaluate right-hand operation if the left-hand operand evalutes to non-null.
//ref https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator

//"GroupBy(char.ToLower)" is the same as "GroupBy(c => char.ToLower(c))" 
using System.Linq;

public class Kata
{
    public static string FirstNonRepeatingLetter(string s) =>
    s.GroupBy(char.ToLower).FirstOrDefault(_ => _.Count() == 1)?.First().ToString() ?? string.Empty;
    // or s.GroupBy(char.ToLower).FirstOrDefault(_ => _.Count() == 1)?.First().ToString() ?? "";
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("a", Kata.FirstNonRepeatingLetter("a"));
      Assert.AreEqual("t", Kata.FirstNonRepeatingLetter("stress"));
      Assert.AreEqual("e", Kata.FirstNonRepeatingLetter("moonmen"));
    }
    
    [Test]
    public void EmptyTest()
    {
      Assert.AreEqual("", Kata.FirstNonRepeatingLetter(""));
    }
    
    [Test]
    public void AllRepeatingTests()
    {
      Assert.AreEqual("", Kata.FirstNonRepeatingLetter("abba"));
      Assert.AreEqual("", Kata.FirstNonRepeatingLetter("aa"));
    }
    
    [Test]
    public void OddCharactersTest()
    {
      Assert.AreEqual("ﬁ", Kata.FirstNonRepeatingLetter("∞§ﬁ›ﬂ∞§"));
      Assert.AreEqual("w", Kata.FirstNonRepeatingLetter("hello world, eh?"));
    }

    [Test]
    public void CaseLettersTest()
    {
      Assert.AreEqual("T", Kata.FirstNonRepeatingLetter("sTreSS"));
      Assert.AreEqual(",", Kata.FirstNonRepeatingLetter("Go hang a salami, I'm a lasagna hog!"));
    }
    
    [Test]
    public void RandomTest()
    {
      var rand = new Random();
      
      Func<string,string> myFirstNonRepeatingLetter = delegate (string s)
      {
        var dict = new Dictionary<char, Tuple<int, char>>();  
  
        for(var i=0;i<s.Length;i++) 
        {
          if(!(dict.ContainsKey(char.ToLower(s[i])))) 
          {
            dict[char.ToLower(s[i])] = new Tuple<int, char>(0, s[i]);          
          }    
          var tuple = dict[char.ToLower(s[i])];
                
          dict[char.ToLower(s[i])] = new Tuple<int, char>(tuple.Item1 + 1, tuple.Item2);
        }
  
        foreach(var el in dict.Values)
        {
          if(el.Item1 == 1) 
          {
            return new string(el.Item2, 1);
          }
        }
      
        return "";
      };
      
      for(int a = 0; a < 80; a++)
      {
        var length = rand.Next(0, a);
      
        var checkText = string.Concat(Enumerable.Range(0, length).Select(i => (char) rand.Next(65, 65 + a)));
      
        Assert.AreEqual(myFirstNonRepeatingLetter(checkText), Kata.FirstNonRepeatingLetter(checkText));
      }
    }
  }
}
