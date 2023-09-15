/*Challenge link:https://www.codewars.com/kata/5938f5b606c3033f4700015a/train/csharp
Question:
Introduction
There is a war...between alphabets!
There are two groups of hostile letters. The tension between left side letters and right side letters was too high and the war began. The letters called airstrike to help them in war - dashes and dots are spread throughout the battlefield. Who will win?

Task
Write a function that accepts a fight string which consists of only small letters and * which represents a bomb drop place. Return who wins the fight after bombs are exploded. When the left side wins return Left side wins!, and when the right side wins return Right side wins!. In other cases, return Let's fight again!.

The left side letters and their power:

 w - 4
 p - 3 
 b - 2
 s - 1
The right side letters and their power:

 m - 4
 q - 3 
 d - 2
 z - 1
The other letters don't have power and are only victims.
The * bombs kill the adjacent letters ( i.e. aa*aa => a___a, **aa** => ______ );

Example
AlphabetWar("s*zz");           //=> Right side wins!
AlphabetWar("*zd*qm*wp*bs*"); //=> Let's fight again!
AlphabetWar("zzzz*s*");       //=> Right side wins!
AlphabetWar("www*www****z");  //=> Left side wins!
*/

//***************Solution********************

using System.Text.RegularExpressions;
using System.Linq;

public class Kata{
  public static string AlphabetWar(string fight){    
    //fixed score, use index - 4 to get the corresponding score, if negative then it's wpbs, else mqdz
      var score = Regex.Replace(fight, @"(\w?\*\w?)|[^zdqmsbpw]", "").Select(c => "wpbs_zdqm".IndexOf(c) - 4).Sum();
      return score == 0 ? "Let's fight again!" : score < 0 ? "Left side wins!" : "Right side wins!";
  }
}

//****************Sample Test*****************
namespace Learning {
  using NUnit.Framework;
  using System.Linq;
  using System.Text.RegularExpressions;  
  using System;
  [TestFixture]
  public class AlphabetWarTest
  {
    [Test]
    public void BasicTest()
    {
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("z"));
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("****"));      
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("z*dq*mw*pb*s"));       
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("zdqmwpbs"));
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("zz*zzs"));
       Assert.AreEqual("Left side wins!", Kata.AlphabetWar("*wwwwww*z*"));
    }
   [Test]
    public void RandomTest()
    {
       for ( int i=0; i< 194; i++)
       {
          string str = GetRandomString(i%40 + 2);
          Console.WriteLine($"Fight: {str}\nExpected result: {aw(str)}");
          Assert.AreEqual(aw(str), Kata.AlphabetWar(str)); 
       }
    } 
  
    private string aw(string fight)
    {
      string power = "wpbs_zdqm";
      fight = Regex.Replace(fight, @"[a-z]{0,1}\*[a-z]{0,1}", "");
      int result = fight.Aggregate(0, (a, b) => a + (power.IndexOf(b) == -1 ? 0 : power.IndexOf(b) - 4));
      return result == 0?"Let's fight again!": $"{(result<0?"Left":"Right")} side wins!";

    } 
  
    private string GetRandomString(int length)
    {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "***********wpbszdqmabcdefghijklmnopqrstuvwxyzwpbszdqm";
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }      
    
   }
 }
