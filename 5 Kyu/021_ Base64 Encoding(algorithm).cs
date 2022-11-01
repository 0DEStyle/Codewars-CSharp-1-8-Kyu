/*Challenge link:https://www.codewars.com/kata/5270f22f862516c686000161/train/csharp
Question:

Extend the String object (JS) or create a function (Python, C#) that converts the value of the String to and from Base64 using the ASCII (UTF-8 for C#) character set.

Example (input -> output):
'this is a string!!' -> 'dGhpcyBpcyBhIHN0cmluZyEh'
You can learn more about Base64 encoding and decoding here.

Note: This kata uses the non-padding version ("=" is not added to the end).
*/

//***************Solution********************
//encode string to base64
//decode string from base64
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Base64Utils
{
  public static string ToBase64(string s)=>
    System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(s));

  public static string FromBase64(string s)=>
    System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(s));
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;

  [TestFixture]
  public class SolutionTest
  {
    string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/=";
    string[] knownValues = new string[] {
        "this is a string!!",
        "this is a test!",
        "now is the time for all good men to come to the aid of their country.",
        "1234567890  ",
        "ABCDEFGHIJKLMNOPQRSTUVWXYZ ",
        "the quick brown fox jumps over the white fence. ",
        "dGhlIHF1aWNrIGJyb3duIGZveCBqdW1wcyBvdmVyIHRoZSB3aGl0ZSBmZW5jZS4",
        "VFZSSmVrNUVWVEpPZW1jMVRVTkJaeUFna",
        "TVRJek5EVTJOemc1TUNBZyAg",
        "padding, sir?",
        "padding ",
        "",
    };
     
    [Test]
    public void KnownValuesEncodeTest()
    {
      foreach(var knownValue in knownValues)
      {
        Assert.AreEqual(GetBase64Encoded(knownValue), Base64Utils.ToBase64(knownValue));
      }
    }
    
    [Test]
    public void RandomValuesEncodeTest()
    {
      for (int i = 0; i < 10; i++)
      {
        var s = GetRandomString(i);
        Assert.AreEqual(GetBase64Encoded(s), Base64Utils.ToBase64(s));
      } 
    }
    
    [Test]
    public void KnownValuesDecodeTest()
    {
      foreach(var knownValue in knownValues)
      {
        var encoded = GetBase64Encoded(knownValue);
        Assert.AreEqual(GetFromBase64Encoded(encoded), Base64Utils.FromBase64(encoded));
      }
    }
    
    [Test]
    public void RandomValuesDecodeTest()
    {
      for (int i = 0; i < 10; i++)
      {
        var s = GetRandomString(i);
        var encoded = GetBase64Encoded(s);
        Assert.AreEqual(GetFromBase64Encoded(encoded), Base64Utils.FromBase64(encoded));
      }
    }
    
    private string GetBase64Encoded(string s)
    {
       return Convert.ToBase64String(Encoding.UTF8.GetBytes(s));
    }
    
    private string GetFromBase64Encoded(string s)
    {
      return Encoding.UTF8.GetString(Convert.FromBase64String(s));
    }
    
    private string GetRandomString(int i)
    {
      Random random = new Random(i);
      var length = random.Next(1, alphabet.Length - 1);
      return new string(Enumerable.Repeat(alphabet, length).Select(s => s[random.Next(s.Length)]).ToArray());

    }
  }
}
