/*Challenge link:https://www.codewars.com/kata/5b37a50642b27ebf2e000010/train/csharp
Question:
Beaches are filled with sand, water, fish, and sun. Given a string, calculate how many times the words "Sand", "Water", "Fish", and "Sun" appear without overlapping (regardless of the case).

Examples
SumOfABeach("WAtErSlIde")                    ==>  1
SumOfABeach("GolDeNSanDyWateRyBeaChSuNN")    ==>  3
SumOfABeach("gOfIshsunesunFiSh")             ==>  4
SumOfABeach("cItYTowNcARShoW")               ==>  0

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬜🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬛⬛🟨🟨🟨⬛⬛⬛🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬛🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜
⬜⬛⬛🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜     this is my 1000th solved kata heck yeah!
⬛🟨🟨🟨🟨🟧🟧⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜       thanks for listening to my TedxTalk
⬜⬛🟧🟧🟧🟧🟧⬛⬛🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛         stay hydrated and have a noice day!
⬜⬜⬛⬛⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛    /
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨⬛🟨⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬛🟨⬛
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛⬛⬛🟨🟨⬛
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜
⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬛🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜
⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬛⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬛🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨⬛⬜⬜⬜⬜⬜⬜
⬜⬜⬜⬜⬜⬜⬜⬜⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬛⬜⬜⬜⬜⬜⬜⬜
*/
//pattern (?i) ignore case
//check if matches pattern sand OR water OR fish OR sun, count the total and return the result

public class Kata{
    public static int SumOfABeach(string s) => 
      System.Text.RegularExpressions.Regex.Matches(s, "(?i)(sand|water|fish|sun)").Count;
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class Tests
  {
    [Test]
    public void SampleTests()
    {
      Assert.AreEqual(1, Kata.SumOfABeach("SanD"));
      Assert.AreEqual(1, Kata.SumOfABeach("sunshine"));
      Assert.AreEqual(4, Kata.SumOfABeach("sunsunsunsun"));
      Assert.AreEqual(1, Kata.SumOfABeach("123FISH321"));
    }
    
    [Test]
    public void HarderTests()
    {
      Assert.AreEqual(4, Kata.SumOfABeach("weoqipurpoqwuirpousandiupqwoieurioweuwateruierqpoiweurpouifiShqowieuqpwoeuisUn"));
      Assert.AreEqual(10, Kata.SumOfABeach("sAnDsandwaTerwatErfishFishsunsunsandwater"));
      Assert.AreEqual(10, Kata.SumOfABeach("joifjepiojfoiejfoajoijawoeifjowejfjoiwaefjiaowefjaofjwoj fawojef jwefjwjfsandsandwaterwaterfishfishsunsunsandwateriojwhefa;jawof;jawio;f"));
      Assert.AreEqual(0, Kata.SumOfABeach("oijifwefoiwoijiawijiwefiwoefiowefjiowefjwjafojjfwejfaiwfjaw;fjwfoi;wejfa;wojfawo;jfawo;jf;owejf;aowjf;jowaeofwaf;jowefa;owjf"));
      Assert.AreEqual(100, Kata.SumOfABeach("saNdsandwaterwAterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwatersandsandwaterwaterfishfishsunsunsandwater"));
    }
    
    [Test]
    public void SlicedWords()
    {
      Assert.AreEqual(1, Kata.SumOfABeach("sununsu"));
      Assert.AreEqual(1, Kata.SumOfABeach("sandandndsansa"));
      Assert.AreEqual(1, Kata.SumOfABeach("wateratertererwatewatwa"));
      Assert.AreEqual(1, Kata.SumOfABeach("fishishshfisfi"));
    }

    [Test]
    public void RandomTests()
    {
      string[] words = new string[] { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q",
                                      "r", "s", "t", "u", "v", "w", "x", "y", "z", "sand", "water", "fish", "sun",
                                      "sand", "water", "fish", "sun", "sand", "water", "fish", "sun"};
      Random random = new Random();
      for (int i = 0; i < 100; i++)
      {
          string result = "";
          string randomWord = words[random.Next(0, words.Length)];
          while (result.Length < 50)
          {
              result += randomWord;
              randomWord = words[random.Next(0, words.Length)];
              randomWord = random.Next(1, 10) >= 4 ? randomWord : randomWord.ToUpper();
          }
          int matches = 0;
          matches += Regex.Matches(result.ToLower(), "sand").Count;
          matches += Regex.Matches(result.ToLower(), "water").Count;
          matches += Regex.Matches(result.ToLower(), "fish").Count;
          matches += Regex.Matches(result.ToLower(), "sun").Count;
          Assert.AreEqual(matches, Kata.SumOfABeach(result));
      }
    }
  }
}
