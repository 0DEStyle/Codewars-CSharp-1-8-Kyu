/*Challenge link:https://www.codewars.com/kata/55ccdf1512938ce3ac000056/train/csharp
Question:
You're on your way to the market when you hear beautiful music coming from a nearby street performer. The notes come together like you wouln't believe as the musician puts together patterns of tunes. As you wonder what kind of algorithm you could use to shift octaves by 8 pitches or something silly like that, it dawns on you that you have been watching the musician for some 10 odd minutes. You ask, "how much do people normally tip for something like this?" The artist looks up. "It's always gonna be about tree fiddy."

It was then that you realize the musician was a 400 foot tall beast from the paleolithic era! The Loch Ness Monster almost tricked you!

There are only 2 guaranteed ways to tell if you are speaking to The Loch Ness Monster: A) it is a 400 foot tall beast from the paleolithic era; B) it will ask you for tree fiddy.

Since Nessie is a master of disguise, the only way accurately tell is to look for the phrase "tree fiddy". Since you are tired of being grifted by this monster, the time has come to code a solution for finding The Loch Ness Monster. Note that the phrase can also be written as "3.50" or "three fifty".
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata {
  public static bool IsLockNessMonster(string sentence) => 
    sentence.ToLower().Contains("tree fiddy") || sentence.Contains("3.50") || sentence.Contains("three fifty") ? true : false;
}


//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class KataTests
{
  
  [Category("Happy Path")]
  [TestCase("Your girlscout cookies are ready to ship. Your total comes to tree fiddy")]
  [TestCase("Your girlscout cookies are ready to ship. Your total comes to tree Fiddy")]
  [TestCase("Howdy Pardner. Name's Pete Lexington. I reckon you're the kinda stiff who carries about tree fiddy?")]
  [TestCase("I'm from Scottland. I moved here to be with my family sir. Please, $3.50 would go a long way to help me find them")]
  public void HappyTest(string sentence)
  {
    Assert.IsTrue(Kata.IsLockNessMonster(sentence), sentence);
  }

  [Category("Sad Path")]
  [TestCase("Yo, I heard you were on the lookout for Nessie. Let me know if you need assistance.")]
  [TestCase("I will absolutely, positively, never give that darn Lock Ness Monster any of my three dollars and fifty cents")]
  [TestCase("Did I ever tell you about my run with that paleolithic beast? He tried all sorts of ways to get at my three dolla and fitty cent? I told him 'this is MY 4 dolla!'. He just wouldn't listen. ")]
  public void SadTests(string sentence)
  {
    Assert.IsFalse(Kata.IsLockNessMonster(sentence), sentence);
  }
}
