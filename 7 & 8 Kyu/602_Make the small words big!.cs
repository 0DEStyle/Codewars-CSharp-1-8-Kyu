/*Challenge link:https://www.codewars.com/kata/57b4dd38d2a31c75f7000299/train/csharp
Question:
Life isn't always easy as a small word amongst big words. If only they had a code warrior to help them out...

Your task is to make all words which are 3 characters or less into capitals. You should also remove any vowels from 'long' (4 characters or more) words.

For example:

"The quick brown fox jumps over the lazy dog"

Should become:

"THE qck brwn FOX jmps vr THE lzy DOG"

For the purposes of this kata, mid-word punctuation counts towards the character limit of a word.

e.g: "it's / I'm" should become: "t's / I'M"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//split the sentence by space
//x is current element, if x is less than or equal to 3, convert to upper case
//else, replace all vowels to nothing, ignore case, then join elements by space.
using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static string SmallWordHelper(string sentence) =>  
    string.Join(" " , sentence.Split().Select(x => x.Length <= 3 ? x.ToUpper() : Regex.Replace(x, "(?i)[aeiou]", "")));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("THE qck brwn FOX jmps vr THE lzy DOG", Kata.SmallWordHelper("The quick brown fox jumps over the lazy dog"));
      Assert.AreEqual("I'M jst A smll wrd frm A smll wrd fmly", Kata.SmallWordHelper("I'm just a small word from a small word family"));   
      Assert.AreEqual("t's THE JOB tht's nvr strtd AS tks lngst TO fnsh", Kata.SmallWordHelper("It's the job that's never started as takes longest to finish"));
      Assert.AreEqual("TO BE, OR NOT TO BE: tht IS THE qstn", Kata.SmallWordHelper("To be, or not to be: that is the question"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      var possible = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
      
      Func<string, string> mySmallWordHelper = delegate (string sentence)
      {
        var vowels = "aeiou";
        return string.Join(" ", sentence.Split(' ').Select(a => a.Length <= 3 ? a.ToUpper() : string.Concat(a.Where(c => !vowels.Contains(char.ToLower(c))))));
      };
      
      for(var r=0;r<20;r++)
      {
        var wordCount = rand.Next(2,12);
      
        var sentence = "";
        for(int w=0;w<wordCount;w++)
        {
          sentence += " " + string.Concat(Enumerable.Range(0, rand.Next(0, 10)).Select(a => possible[rand.Next(0, possible.Length)]));
        }
        sentence = sentence.Substring(1);
        
        Assert.AreEqual(mySmallWordHelper(sentence), Kata.SmallWordHelper(sentence));
      }      
    }
  }
}
