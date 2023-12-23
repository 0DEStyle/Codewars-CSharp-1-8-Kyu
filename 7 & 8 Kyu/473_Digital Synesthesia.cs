/*Challenge link:https://www.codewars.com/kata/56047bb6bcd785ce75000069/train/csharp
Question:
Setup
Sysnesthesia is a nuerological phenomenon where a person may experience a sensory impulse as if it had been from a different sense. For example, hearing music as if seeing a series of colors.

Today we will be creating a function to mimic a synesthetic experience. The function will receive a string representing music, and return an array of strings representing colors.

To represent music as a string, we will be using the ABC music notation. This notation is a whole language, but all you need to know for this kata is that it is comprised of all ASCII characters. In it's simplest usage, "ABCEFG" is an ascending scale.

To represent color as a string, we will use standard CSS hex notation, e.g. #FFFFFF for white. Letters are upper case.

Task
Starting from the begining of the input string, for every three ASCII characters, include the associated color in the returned array. If the input string is not evenly divisible by three, ignore any trailing characters. Empty and null input should return an empty array.

I define a color as being associated with three ASCII characters when each pair of hexidecimal digits in the color match the hexidecimal ASCII values of the respective characters. For example, #414243 is associated with the notes ABC.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//x, y and ch are the current elements.
//check if music is null, if so return empty string array
//else generate number start from 0 up to music.Length divide by 3
//from those number, skip current element * 3, take the first 3 elements.
//from element y, select ch, convert to hexidecimal value and convert the type to int
//store in array and return the result.
using System.Linq;

public class Kata {
  public static string[] MusicToColor(string music)  =>
    music == null ? new string[0] : 
    Enumerable.Range(0, music.Length/3)
              .Select(x => music.Skip(x*3).Take(3))
              .Select(y => "#" + string.Join("",y.Select(ch => $"{(int) ch:X}"))).ToArray();
}

//solution 2
using System;
using System.Linq;
using System.Collections.Generic;

public class Kata {
  public static string[] MusicToColor(string music) {
    if (music == null)
      return new string[]{};
    List<string> result = new List<string>();
    for (int i = 0; i + 3 <= music.Length; i += 3)
      result.Add(
        "#" + String.Join("", music.Substring(i, 3).Select(c => String.Format("{0:X}", (int) c)))
      );
    return result.ToArray();
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;

[TestFixture]
public class Kata_Tests {
  
  [Test]
  public void OneColor() {
    var music = "AAA";
    var result = Kata.MusicToColor(music);
    Assert.AreEqual("#414141", result[0]);
  }
  
  [Test]
  public void OneColor2() {
    var music = "ABC";
    var result = Kata.MusicToColor(music);
    Assert.AreEqual("#414243", result[0]);
  }
  
  [Test]
  public void EmptyString() {
    var music = "";
    var result = Kata.MusicToColor(music);
    Assert.AreEqual(0, result.Length, "Empty music should return an empty array.");
  }
  
  [Test]
  public void NullString() {
    string music = null;
    var result = Kata.MusicToColor(music);
    Assert.AreEqual(0, result.Length, "Null music should return an empty array.");
  }
  
  [Test]
  public void ThreeAndPartial() {
    var music = "|: DFxBC :|";
    var result = Kata.MusicToColor(music);
    Assert.AreEqual(3, result.Length);
    Assert.AreEqual("#7C3A20", result[0]);
    Assert.AreEqual("#444678", result[1]);
    Assert.AreEqual("#424320", result[2]);
  }
  
  [Test]
  public void LotsOfMusic() {
    //a short selection from Beethoven's 7th Symphony
    //ABC transcription by steve allen: http://www.ucolick.org/~sla/abcmusic/sym7mov2.html
    var music = "z4 | z4 |\\ z4 | z4 | z4 | z4 |\\ G2 .G.G | (.G2 .G2) | G2 .G.G | (.G2 .G2) |\\ w:ff G2 .G.A | (._B2 .B2) | _B2 .B.B | _B2 z2 |\\ _B2 .B.c | (.d2 .d2) | A2 .A.=B | (.c2 .c2) |\\ G2 .G.G | (.G2 .G2) | G2 .A.=B |";
    var result = Kata.MusicToColor(music);
    Assert.AreEqual(68, result.Length);
    Assert.AreEqual("#7A3420", result[0]);
    Assert.AreEqual("#34207C", result[2]);
    Assert.AreEqual("#472E47", result[12]);
    Assert.AreEqual("#3D4220", result[67]);
    
  }
  
}
