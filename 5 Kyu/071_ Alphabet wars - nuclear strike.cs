/*Challenge link:https://www.codewars.com/kata/59437bd7d8c9438fb5000004/train/csharp
Question:
Introduction
There is a war and nobody knows - the alphabet war!
The letters hide in their nuclear shelters. The nuclear strikes hit the battlefield and killed a lot of them.

Task
Write a function that accepts battlefield string and returns letters that survived the nuclear strike.

The battlefield string consists of only small letters, #,[ and ].
The nuclear shelter is represented by square brackets []. The letters inside the square brackets represent letters inside the shelter.
The # means a place where nuclear strike hit the battlefield. If there is at least one # on the battlefield, all letters outside of shelter die. When there is no any # on the battlefield, all letters survive (but do not expect such scenario too often ;-P ).
The shelters have some durability. When 2 or more # hit close to the shelter, the shelter is destroyed and all letters inside evaporate. The 'close to the shelter' means on the ground between the shelter and the next shelter (or beginning/end of battlefield). The below samples make it clear for you.
Example
abde[fgh]ijk     => "abdefghijk"  (all letters survive because there is no # )
ab#de[fgh]ijk    => "fgh" (all letters outside die because there is a # )
ab#de[fgh]ij#k   => ""  (all letters dies, there are 2 # close to the shellter )
##abde[fgh]ijk   => ""  (all letters dies, there are 2 # close to the shellter )
##abde[fgh]ijk[mn]op => "mn" (letters from the second shelter survive, there is no # close)
#ab#de[fgh]ijk[mn]op => "mn" (letters from the second shelter survive, there is no # close)
#abde[fgh]i#jk[mn]op => "mn" (letters from the second shelter survive, there is only 1 # close)
[a]#[b]#[c]  => "ac"
[a]#b#[c][d] => "d"
[a][b][c]    => "abc"
##a[a]b[c]#  => "c"
*/

//***************Solution********************

//ref: https://regexr.com/
//paste the pattern in the website for explanation.

//if string b does not contain '#', return b
//else 
//check for matches with pattern @"\[(\w*)\]|(#)"
// \ is just escaped character
// matches the characters '[' and ']', with capture group \w*, \w is matches any word, * is match 0 or more
// |(#), or capture group '#'
//concatenate the result

//then replace the previous string with pattern (?<=##)\[(\w*)\]|(?<=#)\[(\w*)\](?=#)|\[(\w*)\](?=##) to "" nothing
// (?<=##)   positive look behind for characters ##
// \[(\w*)\] \ escape character, with capture group \w*
// |(?<=#)\[(\w*)\](?=#) or, positive look behind for character #, with capture group \w*, (?=#) positive lookahead for character #
// |\[(\w*)\](?=#) or, with capture group \w*, (?=#) positive lookahead for character #

//then replace for the final time with pattern [^\w] to "" nothing
//[^\w] negative set for \w word
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;

public class Kata{
    public static string AlphabetWar(string b) => 
      Regex.Replace((!b.Contains('#') ? b : 
      Regex.Replace(string.Concat(Regex.Matches(b, @"\[(\w*)\]|(#)")), 
                                                   @"(?<=##)\[(\w*)\]|(?<=#)\[(\w*)\](?=#)|\[(\w*)\](?=##)", "")), 
                                                   @"[^\w]","");
}

//****************Sample Test*****************
namespace Learning {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;
  
  [TestFixture]
  public class AlphabetWarTest
  {
    [Test]
    public void BasicTest()
    {   
       Assert.AreEqual("", Kata.AlphabetWar("#[a]#[b]#"));
       Assert.AreEqual("", Kata.AlphabetWar("[a]##[b]"));
       Assert.AreEqual("aab", Kata.AlphabetWar("[a]a[b]"));           
       Assert.AreEqual("abdefghijk", Kata.AlphabetWar("abde[fgh]ijk"));
       Assert.AreEqual("fgh", Kata.AlphabetWar("ab#de[fgh]ijk"));
       Assert.AreEqual("", Kata.AlphabetWar("ab#de[fgh]ij#k"));
       Assert.AreEqual("", Kata.AlphabetWar("##abde[fgh]ijk"));
       Assert.AreEqual("", Kata.AlphabetWar("##abde[fgh]"));      
       Assert.AreEqual("abdefgh", Kata.AlphabetWar("abde[fgh]"));         
       Assert.AreEqual("mn", Kata.AlphabetWar("##abde[fgh]ijk[mn]op"));
       Assert.AreEqual("mn", Kata.AlphabetWar("#abde[fgh]i#jk[mn]op"));
       Assert.AreEqual("abijk", Kata.AlphabetWar("[ab]adfd[dd]##[abe]dedf[ijk]d#d[h]#"));      
    }

    [Test]
    public void RandomTest()
    {
       Random rand = new Random();
       for ( int i=0; i< 191; i++)
       {
          string b = GetBattleField(i%6+1);
          string result = AW(b);          
          Console.WriteLine($"Battlefield: {b}\n Expected Result: {result}\n");
          Assert.AreEqual(result, Kata.AlphabetWar(b)); 
       }
    } 


    private string GetBattleField(int length)  {
       string b = "";
       Random rand = new Random();
       for (int i =0; i< length; i++)
          b += GetOutside(rand.Next(1,5)) + GetShelter(rand.Next(1,4));
        
        return b +  GetOutside(rand.Next(0,3));
    }
    

    private string GetOutside(int length) {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "######abcdefghijklmnopqrstuvwxyz";
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    } 

    private string GetShelter(int length) {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "abcdefghijklmnopqrstuvwxyz";
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return "[" + new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()) + "]";
        }
    } 

    private string AW(string b)
    => !b.Contains('#') ? Regex.Replace(b,@"[\[\]]","") :
       string.Concat(Regex.Matches(b, @"(?<=([a-z#]*))\[([a-z]+)\](?=([a-z#]*))").Cast<Match>().Where(g => (g.Groups[1].Value + g.Groups[3].Value).Count(c => c == '#') < 2).Select(g => g.Groups[2].Value));
    
  }
}
  
