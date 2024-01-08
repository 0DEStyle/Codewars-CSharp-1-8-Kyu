/*Challenge link:https://www.codewars.com/kata/5d076515e102162ac0dc514e/train/csharp
Question:
Baby Shark Lyrics
baby shark

Create a function, as short as possible, that returns this lyrics.
Your code should be less than 300 characters. Watch out for the three points at the end of the song.

Baby shark, doo doo doo doo doo doo
Baby shark, doo doo doo doo doo doo
Baby shark, doo doo doo doo doo doo
Baby shark!
Mommy shark, doo doo doo doo doo doo
Mommy shark, doo doo doo doo doo doo
Mommy shark, doo doo doo doo doo doo
Mommy shark!
Daddy shark, doo doo doo doo doo doo
Daddy shark, doo doo doo doo doo doo
Daddy shark, doo doo doo doo doo doo
Daddy shark!
Grandma shark, doo doo doo doo doo doo
Grandma shark, doo doo doo doo doo doo
Grandma shark, doo doo doo doo doo doo
Grandma shark!
Grandpa shark, doo doo doo doo doo doo
Grandpa shark, doo doo doo doo doo doo
Grandpa shark, doo doo doo doo doo doo
Grandpa shark!
Let's go hunt, doo doo doo doo doo doo
Let's go hunt, doo doo doo doo doo doo
Let's go hunt, doo doo doo doo doo doo
Let's go hunt!
Run away,…
Good Luck!
*/

//***************Solution********************
//less than 300 characters for code.
//create string array to store all unique words
//append shark to each one, and append "Let's go hunt" at the end.
//then join y(current element) with ", doo doo doo doo doo doo\n", repeat 4 times
//append "!\n" at the end, and append "Run away,…\n".
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata {
public static string BabySharkLyrics()=>string.Concat(new[]{"Baby","Mommy","Daddy","Grandma","Grandpa"}
.Select(x=>x+" shark").Append("Let's go hunt")
.Select(y=>string.Join(", doo doo doo doo doo doo\n",Enumerable.Repeat(y,4))+"!\n"))+"Run away,…\n";
}

//****************Sample Test*****************
namespace BabyShark {
  using NUnit.Framework;
  using System;
  using System.IO;

  [TestFixture]
  public class BabySharkLyricsTest
  {
    [Test]
    public void CorrectLyrics()
    {
      Assert.AreEqual(string.Join("\n", new string[] {
        "Baby shark, doo doo doo doo doo doo",
        "Baby shark, doo doo doo doo doo doo",
        "Baby shark, doo doo doo doo doo doo",
        "Baby shark!",
        "Mommy shark, doo doo doo doo doo doo",
        "Mommy shark, doo doo doo doo doo doo",
        "Mommy shark, doo doo doo doo doo doo",
        "Mommy shark!",
        "Daddy shark, doo doo doo doo doo doo",
        "Daddy shark, doo doo doo doo doo doo",
        "Daddy shark, doo doo doo doo doo doo",
        "Daddy shark!",
        "Grandma shark, doo doo doo doo doo doo",
        "Grandma shark, doo doo doo doo doo doo",
        "Grandma shark, doo doo doo doo doo doo",
        "Grandma shark!",
        "Grandpa shark, doo doo doo doo doo doo",
        "Grandpa shark, doo doo doo doo doo doo",
        "Grandpa shark, doo doo doo doo doo doo",
        "Grandpa shark!",
        "Let's go hunt, doo doo doo doo doo doo",
        "Let's go hunt, doo doo doo doo doo doo",
        "Let's go hunt, doo doo doo doo doo doo",
        "Let's go hunt!",
        "Run away,…",
        ""
      }), Kata.BabySharkLyrics());
    }
    
    [Test]
    public void BelowCharLimit()
    {
      var ln = File.ReadAllText(@"/workspace/solution.txt").Length;
      Assert.That(ln, Is.LessThan(300));
    }
  }
}
