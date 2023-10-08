/*Challenge link:https://www.codewars.com/kata/5efae11e2d12df00331f91a6/train/csharp
Question:
Given is a md5 hash of a five digits long PIN. It is given as string. Md5 is a function to hash your password: "password123" ===> "482c811da5d5b4bc6d497ffa98491e38"

Why is this useful? Hash functions like md5 can create a hash from string in a short time and it is impossible to find out the password, if you only got the hash. The only way is cracking it, means try every combination, hash it and compare it with the hash you want to crack. (There are also other ways of attacking md5 but that's another story) Every Website and OS is storing their passwords as hashes, so if a hacker gets access to the database, he can do nothing, as long the password is safe enough.

What is a hash?

What is md5?

Note: Many languages have build in tools to hash md5. If not, you can write your own md5 function or google for an example.

Here is another kata on generating md5 hashes!

Your task is to return the cracked PIN as string.

This is a little fun kata, to show you, how weak PINs are and how important a bruteforce protection is, if you create your own login.

If you liked this kata, here is an extension with short passwords!

Some of my other katas:
Error Correction #1 - Hamming Code
Hack the NSA
Decode the QR-Code


*/

//***************Solution********************

//loop from 0, count up to 99999
// x is the current element and D5 is 5 digits, select using string interpolation {x:D5}
// s is current element,
// MD5 class ref: https://learn.microsoft.com/en-us/dotnet/api/system.security.cryptography.md5?view=net-7.0
// Create new computerHash, with ASCIIEncoding with the byte side of current element s
// y is the current element, x2 is lowercase hexadecimal, select using string interpolation {y:x2} to see if it equal to hash string.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text;
using System.Linq;
using System.Security.Cryptography;

public class CodeWars {
  public static string crack(string hash)  =>
    Enumerable.Range(0, 99999)
        .Select(x => $"{x:D5}")
        .First(s => string.Concat(MD5.Create().ComputeHash(new ASCIIEncoding().GetBytes(s))
        .Select(y => $"{y:x2}")) == hash);
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text;

[TestFixture]
public class Should_pass_all_of_these
{
  [Test]
  public void SimpleTest()
  {
    Assert.AreEqual("12345", CodeWars.crack("827ccb0eea8a706c4c34a16891f84e7b"));
  }
  [Test]
  public void HarderTest()
  {
    Assert.AreEqual("00078", CodeWars.crack("86aa400b65433b608a9db30070ec60cd"));
  }
  [Test]
  public void ThirtyRandomTests()
  {
    Random r = new Random();
    for (int i = 0; i < 30; i++) {
      string input = "";
      for (int x = 0; x < 5; x++) {
        input += r.Next(10).ToString();
      }
      string myhash;
      using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
      {
          byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
          byte[] hashBytes = md5.ComputeHash(inputBytes);
          StringBuilder sb = new StringBuilder();
          for (int x = 0; x < hashBytes.Length; x++)
          {
              sb.Append(hashBytes[x].ToString("X2"));
          }
          myhash = sb.ToString().ToLower();
      }
      Assert.AreEqual(input, CodeWars.crack(myhash));
    }
  }
}
