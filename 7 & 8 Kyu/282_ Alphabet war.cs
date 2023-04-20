/*Challenge link:https://www.codewars.com/kata/59377c53e66267c8f6000027/train/csharp
Question:
Introduction
There is a war and nobody knows - the alphabet war!
There are two groups of hostile letters. The tension between left side letters and right side letters was too high and the war began.

Task
Write a function that accepts fight string consists of only small letters and return who wins the fight. When the left side wins return Left side wins!, when the right side wins return Right side wins!, in other case return Let's fight again!.

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

Example
AlphabetWar("z");        //=> Right side wins!
AlphabetWar("zdqmwpbs"); //=> Let's fight again!
AlphabetWar("zzzzs");    //=> Right side wins!
AlphabetWar("wwwwwwz");  //=> Left side wins!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq; 
public class Kata{
    public static string AlphabetWar(string fight){
      int leftSide = 0, rightSide = 0;
      fight.Sum(x=> x == 'w' ? leftSide += 4  : x == 'p' ? leftSide+= 3 : x == 'b' ? leftSide+=2 : x == 's' ? leftSide +=1 : 0 );
      fight.Sum(x=> x == 'm' ? rightSide += 4  : x == 'q' ? rightSide+= 3 : x == 'd' ? rightSide+=2 : x == 'z' ? rightSide +=1 : 0 );
      return  rightSide > leftSide ? "Right side wins!" : rightSide < leftSide ? "Left side wins!" : "Let's fight again!";
    }
 }
 
 //better solution
  using System.Linq;
 public class Kata
 {
        public static string AlphabetWar(string fight)
        {
            var s1 = fight.Where(x => "wpbs".IndexOf(x) >= 0).Select(x => 4 - "wpbs".IndexOf(x)).Sum();
            var s2 = fight.Where(x => "mqdz".IndexOf(x) >= 0).Select(x => 4 - "mqdz".IndexOf(x)).Sum();
            return s1 > s2 ? "Left side wins!" : s1 < s2 ? "Right side wins!" : "Let's fight again!";
        }
 }
 //Clever solution
  using System.Linq;
 public class Kata
 {
    public static string AlphabetWar(string fight)
    {
        string lpower = "wpbs_zdqm";
        int result = fight.Aggregate(0, (a, b) => a + (lpower.IndexOf(b) == -1 ? 0 : lpower.IndexOf(b) - 4));
        return result == 0?"Let's fight again!": $"{(result<0?"Left":"Right")} side wins!";

    }
 }
//****************Sample Test*****************
namespace Learning {
  using NUnit.Framework;
  using System;
  using System.Linq;
  [TestFixture]
  public class AlphabetWarTest
  {
    [Test]
    public void BasicTest()
    {
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("z"));
       Assert.AreEqual("Let's fight again!", Kata.AlphabetWar("zdqmwpbs"));
       Assert.AreEqual("Right side wins!", Kata.AlphabetWar("zzzzs"));
       Assert.AreEqual("Left side wins!", Kata.AlphabetWar("wwwwwwz"));
    }
    
    [Test]
    public void RandomTest()
    {
       for ( int i=0; i< 196; i++)
       {
          string str = GetRandomString(i%40 + 2);
          Console.WriteLine("Fight: {0}\nExpected result: {1}",str,aw(str));
          Assert.AreEqual(aw(str), Kata.AlphabetWar(str)); 
       }
    } 
  
    private string aw(string fight)
    {
        string lpower = "wpbs_zdqm";
        int result = fight.Aggregate(0, (a, b) => a + (lpower.IndexOf(b) == -1 ? 0 : lpower.IndexOf(b) - 4));
        if (result == 0)
            return "Let's fight again!";
        else if (result < 0)
            return "Left side wins!";
        else
            return "Right side wins!";
    } 
  
    private string GetRandomString(int length)
    {
        System.Byte[] seedBuffer = new System.Byte[4];
        using (var rngCryptoServiceProvider = new System.Security.Cryptography.RNGCryptoServiceProvider())
        {
            rngCryptoServiceProvider.GetBytes(seedBuffer);
            System.String chars = "wpbszdqmabcdefghijklmnopqrstuvwxyzwpbszdqm";
            System.Random random = new System.Random(System.BitConverter.ToInt32(seedBuffer, 0));
            return new System.String(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }      
    
   }
 }
