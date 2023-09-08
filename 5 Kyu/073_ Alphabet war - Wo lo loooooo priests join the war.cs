/*Challenge link:https://www.codewars.com/kata/59473c0a952ac9b463000064/train/csharp
Question:
Introduction
There is a war and nobody knows - the alphabet war!
There are two groups of hostile letters. The tension between left side letters and right side letters was too high and the war began. The letters have discovered a new unit - a priest with Wo lo looooooo power.


Task
Write a function that accepts fight string consists of only small letters and return who wins the fight. When the left side wins return Left side wins!, when the right side wins return Right side wins!, in other case return Let's fight again!.

The left side letters and their power:

 w - 4
 p - 3 
 b - 2
 s - 1
 t - 0 (but it's priest with Wo lo loooooooo power)
The right side letters and their power:

 m - 4
 q - 3 
 d - 2
 z - 1
 j - 0 (but it's priest with Wo lo loooooooo power)
The other letters don't have power and are only victims.
The priest units t and j change the adjacent letters from hostile letters to friendly letters with the same power.

mtq => wtp
wjs => mjz
A letter with adjacent letters j and t is not converted i.e.:

tmj => tmj
jzt => jzt
The priests (j and t) do not convert the other priests ( jt => jt ).

Example
AlphabetWar("z")         //=>  "z"  => "Right side wins!"
AlphabetWar("tz")        //=>  "ts" => "Left side wins!" 
AlphabetWar("jz")        //=>  "jz" => "Right side wins!" 
AlphabetWar("zt")        //=>  "st" => "Left side wins!" 
AlphabetWar("azt")       //=> "ast" => "Left side wins!"
AlphabetWar("tzj")       //=> "tzj" => "Right side wins!" 
*/

//***************Solution********************
 using System.Linq;
 using System.Text.RegularExpressions;

 public class Kata{
    public static string AlphabetWar(string fight){
      //power left side and right side set to string. 
      //string wpbs_zdqm
      //index  0123_5678
      string power = "wpbs_zdqm";
      //regex pattern (?<!t)[wpbs](?=j)|(?<=j)[wpbs](?!t)|(?<!j)[zdqm](?=t)|(?<=t)[zdqm](?!j)
      //(?<!t) negative lookbehind for character t
      //[wpbs] Character set, check if any matches
      //(?=j) positive lookahead for character j
      //| or
      //(?<=j) negative lookahead for character j
      //[wpbs] Character set, check if any matches
      //(?!t) negative lookbehind for character t
      //| or
      //(?<!j) negative lookbehind for character j
      //[zdqm] Character set, check if any matches
      //(?=t) positive lookahead for character j
      //| or
      //(?<=t) positive lookbehind for character t
      //[zdqm] Character set, check if any matches
      //(?!j) negative lookahead for character j
      
      //then replace fight by 8 - index of character, the result will be either positive or negative
      fight = new Regex(@"(?<!t)[wpbs](?=j)|(?<=j)[wpbs](?!t)|(?<!j)[zdqm](?=t)|(?<=t)[zdqm](?!j)").Replace(fight, x => ""+ power[8 - power.IndexOf(x.Value)]);
        
      //aggregate fight, a is current element, b is index
      //if index is negative then return 0, else index - 4, then add a and store in result.
      int result = fight.Aggregate(0, (a, b) => a + (power.IndexOf(b) == -1 ? 0 : power.IndexOf(b) - 4));             
      //if result is 0, then draw, 
      //else using string interpolation to format the string,
      //if result is less than zero return left, else right.
      return result == 0 ? "Let's fight again!" :  $"{(result < 0 ? "Left":"Right")} side wins!";    
    }
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
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("z"));
       Assert.AreEqual("Left side wins!", Kata.AlphabetWar("tz"));
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("jz"));       
       Assert.AreEqual("Left side wins!", Kata.AlphabetWar("zt"));       
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("tzj"));   
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("jbdt"));       
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("zdqmwpbs"));
       Assert.AreEqual("Left side wins!", Kata.AlphabetWar("ztztztzs"));
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("wijbwjc"));
    }
  
    [Test]
    public void RandomTest()
    {
       for ( int i=0; i< 193; i++)
       {
          string str = GetRandomString(i%30 + 2);
          string result = aw(str);
          Console.WriteLine($"Fight: {str}\nExpected result: {result}\n");
          Assert.AreEqual(result, Kata.AlphabetWar(str)); 
       }
    }   
  
    private string aw(string fight)
    {
        string power = "wpbs_zdqm";
        fight = new Regex(@"(?<!t)[wpbs](?=j)|(?<=j)[wpbs](?!t)|(?<!j)[zdqm](?=t)|(?<=t)[zdqm](?!j)").Replace(fight, x => ""+ power[8 - power.IndexOf(x.Value)]);
        int result = fight.Aggregate(0, (a, b) => a + (power.IndexOf(b) == -1 ? 0 : power.IndexOf(b) - 4));                                                                                                             //
        return result == 0 ? "Let's fight again!" :  $"{(result < 0 ? "Left":"Right")} side wins!";    
    }

    private string GetRandomString(int length)
    {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "tjtjtjtjwpbszdqmwpbszdqmabcdef";
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }      
   }
 }
