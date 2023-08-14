/*Challenge link:https://www.codewars.com/kata/52cf02cd825aef67070008fa/train/csharp
Question:
General Patron is faced with a problem , his intelligence has intercepted some secret messages from the enemy but they are all encrypted. Those messages are crucial to getting the jump on the enemy and winning the war. Luckily intelligence also captured an encoding device as well. However even the smartest programmers weren't able to crack it though. So the general is asking you , his most odd but brilliant programmer.

You can call the encoder like this.

Console.WriteLine(Encoder.Encode("Hello World!"));
Our cryptoanalysts kept poking at it and found some interesting patterns.

Console.WriteLine(Encoder.Encode ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
Console.WriteLine(Encoder.Encode ("!@#$%^&*()_+-"));

StringBuilder a = new StringBuilder();
StringBuilder b = new StringBuilder();
StringBuilder c = new StringBuilder();
foreach (char w in "abcdefghijklmnopqrstuvwxyz") {
    a.Append(Encoder.Encode (  "" + w)[0]);
    b.Append(Encoder.Encode ( "_" + w)[1]);
    c.Append(Encoder.Encode ("__" + w)[2]);
}

Console.WriteLine(a);
Console.WriteLine(b);
Console.WriteLine(c);
We think if you keep on this trail you should be able to crack the code! You are expected to fill in the

public static string Decode(string p_what)
function. Good luck ! General Patron is counting on you!
*/

//***************Solution********************
using System;
using System.Text;
using System.Linq;

public static class Decoder{
    public static string Decode(string phrase){
      //1.encode and decode are the same length
      Console.WriteLine(phrase);
      Console.WriteLine(Encoder.Encode("Hello World!"));
      
      //2.indentical fixed pattern between both strings 
      Console.WriteLine(Encoder.Encode ("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa"));
      Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
      
      //3.after 66 characters, the pattern repeat itself.
      Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb"));
      Console.WriteLine(Encoder.Encode ("bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb").Length);
      
      //4.unchanged char, these character are not encrypted
      Console.WriteLine(Encoder.Encode ("!@#$%^&*()_+-"));
      
      StringBuilder a = new StringBuilder();
      StringBuilder b = new StringBuilder();
      StringBuilder c = new StringBuilder();
      
      //shifted each char by adding one extra '_'
      foreach (char w in "abcdefghijklmnopqrstuvwxyz") {
        a.Append(Encoder.Encode (  "" + w)[0]);
        b.Append(Encoder.Encode ( "_" + w)[1]);
        c.Append(Encoder.Encode ("__" + w)[2]);
    } 

        Console.WriteLine(a);
        Console.WriteLine(b);
        Console.WriteLine(c);
      
      //extracted key from repeated pattern in the previous encoded result.
        var key = "abdhpF,82QsLirJejtNmzZKgnB3SwTyXG ?.6YIcflxVC5WE94UA1OoD70MkvRuPqH";
        return new string(phrase.Select((x, index) => key.ToList().Exists(y => y == x)?
                          key[(key.IndexOf(x) - (index + 1) < 0 ?
                          key.Length - Math.Abs(key.IndexOf(x) - (index + 1)) % key.Length :
                          (key.IndexOf(x) - (index + 1))) % key.Length] : x).ToArray());
    }
}

//method 2
using System;
using System.Text;

public static class Decoder
{
    public static string Decode(string phrase)
    {
        var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,? ";
        StringBuilder result = new StringBuilder();
        for(int i = 0; i < phrase.Length; i++)
        {
            if (!chars.Contains(phrase[i]))
            {
                result.Append(phrase[i]);
                continue;
            }
    
            var charIndex = chars.IndexOf(phrase[i]) + 1;
            for (int j = 0; j <= i; j++)
            {
                charIndex = charIndex % 2 == 0 ? charIndex / 2 : (charIndex + chars.Length + 1) / 2;
            }
    
            result.Append(chars[charIndex - 1]);
        }
        
        return result.ToString();
    }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System.Collections;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void ShouldDecodeRandomText()
    {
      const string alphabet = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789.,? ";
      
      Random random = new Random();

      System.Text.StringBuilder text = new System.Text.StringBuilder();
      for (int i = 0; i < 100; ++i)
      {
          var pLength = random.Next(4, 24);
          System.Text.StringBuilder pWord = new System.Text.StringBuilder();
          for (int j = 0; j < pLength; ++j) {
              pWord.Append(alphabet[random.Next(0, alphabet.Length-1)]);
          }

          text.Append(' ');
          text.Append(pWord);
      }

      string textString = text.ToString();
      Assert.AreEqual(textString, Decoder.Decode(Encoder.Encode(textString)));
    }

    [Test]
    public void ShouldDecodeTheMessages()
    {
      (string input, string encoded)[] testData = new[]
      {
          ("The quick brown fox jumped over the lazy developer.",  "yFNYhdmEdViBbxc40,ROYNxwfwvjg5CHUYUhiIkp2CMIvZ.1qPz"),
          ("The secrecy system has systematically denied", "yFNYeZWZn4l5gCB GY1gZG7?D6CV9y9C,?sLbFlDHoMW"),
          ("American historians access to the records of American", "1ZNtt58GxrgKydwwtxTOZRuc.6v5tP9.9b9As31xAQXNiXaPuun1L"),
          ("history. Of late we find ourselves relying on archives", "pJrZkmYVxPA5oJGXUW?OR?E3MJglc5,39Cd41rh1HHsGhrERKOPWdq"),
          ("of the former Soviet Union in Moscow to resolve", "Dx6Z2Zf9PgyS3ExpLy?Yo,E6rUvfOPgzV8gqpDS8o0OGzfu"),
          ("questions of what was going on in Washington at", "HqNJKNRGmVH1WxNj?AEzXDWiYUURtoqC0be6ElAqqkXdiWq"),
          ("mid-century. The Venona intercepts contained", "zJF-CZXBFglEWVNXUR?CQWg0YUCVxhW6UCdQBu7fOaMW"),
          ("overwhelming proof of the activities of Soviet spy", "DuNt QK4wK..WNwpFM12RDfSfkSbWxBCUWUWp3r8dyY7vPJMOJ"),
          ("networks in America, complete with names,", "BtzGkmaNxK.5q yTT0m3oRLVTbx5CPkCUYdvY0oUE"),
          ("dates, places, and deeds.",  "hdzmeifiUsUSgz9jlz1K6YB?v"),
      };

      foreach (var data in testData)
      {
          Assert.AreEqual(data.input, Decoder.Decode(data.encoded));
      }
    }
  }
}
