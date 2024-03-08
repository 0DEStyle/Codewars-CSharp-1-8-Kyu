/*Challenge link:https://www.codewars.com/kata/5681cf0be812b41721000034/train/csharp
Question:
We have a broken message machine that introduces noise to our incoming messages. We know that our messages can't be written using %$&/#·@|º\ª and white characters (like spaces or tabs). Unfortunately our machine introduces noise, which means that our message arrives with characters like: %$&/#·@|º\ª within our original message.

Your mission is to write a function which removes this noise from the message.

Notice that noise can only be %$&/#·@|º\ª characters, other characters are not as considered noise

For example:

Kata.removeNoise("h%e&·%$·llo w&%or&$l·$%d")
// returns hello world
removeNoise "h%e&·%$·llo w&%or&$l·$%d"
// returns hello world
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//replace pattern with nothing.

public class Kata{
  public static string removeNoise(string s) => 
    System.Text.RegularExpressions.Regex.Replace(s, @"[%$&/#·@|º\\ª]", "");
}
//****************Sample Test*****************
using NUnit.Framework;  
using System.Collections;
using System;
[TestFixture]
public class RemoveNoiseTests
{
  [Test]
  public void GenericTests()
  {
    Assert.AreEqual("",Kata.removeNoise("%$&/#·@|º\\ª"), "You failed the test for '%$&/#·@|º\\ª'. (Please note that in c# special characters are displayed as '?' in the error screen)");
    Assert.AreEqual("hello world",Kata.removeNoise("h%e&·%$·llo w&%or&$l·$%d"), "You failed the test for 'h%e&·%$·llo w&%or&$l·$%d'.");    
    Assert.AreEqual("hello coding for everyone",Kata.removeNoise("he%$·ll@o c$&%odi%&ng for ev|#·ery&$$#$on%$·e"), "You failed the test for 'he%$·ll@o c$&%odi%&ng for ev|#·ery&$$#$on%$·e'.");
    Assert.AreEqual("codewars rocks",Kata.removeNoise("c|o@$%de%w@a·$r%s &rºocªks"), "You failed the test for 'c|o@$%de%w@a·$r%s &rºocªks'.(Please note that in c# special characters are displayed as '?' in the error screen)");
  }
  
//----------------------------
    public static string RemoveNoiseT(string equation)
    {
        string output = "";
        foreach (char c in equation)
        {
            if (!"%$&/#·@|º\\ª".Contains(c.ToString()))
                output += c;
        }
        return output;
    }
//----------------------------
[Test]
    public static void zRandomStringTests(){
      Console.WriteLine("\n ********** 50 Random String Tests **********");
      string alph = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789?.!%$&/#·@|º\\ª   ";
      Random rnd = new Random();
      for (int i = 0; i < 50; i++) {
        string randomString = ""; 
        int rando = rnd.Next(1,1000);
        for(int j = 0; j<rando; j++)
        {
          int n = rnd.Next(0,alph.Length);
          randomString += alph[n];
        }

        Assert.AreEqual(RemoveNoiseT(randomString), Kata.removeNoise(randomString), "Should work for random tests too! You failed on: "+randomString);
      }
    }
}
