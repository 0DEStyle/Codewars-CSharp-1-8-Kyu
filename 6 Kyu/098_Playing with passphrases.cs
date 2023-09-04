/*Challenge link:https://www.codewars.com/kata/559536379512a64472000053/train/csharp
Question:
Everyone knows passphrases. One can choose passphrases from poems, songs, movies names and so on but frequently they can be guessed due to common cultural references. You can get your passphrases stronger by different means. One is the following:

choose a text in capital letters including or not digits and non alphabetic characters,

shift each letter by a given number but the transformed letter must be a letter (circular shift),
replace each digit by its complement to 9,
keep such as non alphabetic and non digit characters,
downcase each letter in odd position, upcase each letter in even position (the first character is in position 0),
reverse the whole result.
Example:
your text: "BORN IN 2015!", shift 1

1 + 2 + 3 -> "CPSO JO 7984!"

4 "CpSo jO 7984!"

5 "!4897 Oj oSpC"

With longer passphrases it's better to have a small and easy program. Would you write it?

https://en.wikipedia.org/wiki/Passphrase


*/

//***************Solution********************

//convert string s to uppercase, c is current element(character) and i is index
//if current character is a letter, then current character - 65(A in ascii) + n(shfiting num) % 26(26 letters) + i(index) % 2 * 32
//else check if current character is a digit, if so 9(replace each digit by its complement to 9) - current character + 96(before 'a')
//else return current character
//reverse the result and concatenate.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class PlayPass{
  public static string playPass(string s, int n) => 
    string.Concat(s.ToUpper().Select((c, i) =>
                 (char)(char.IsLetter(c) ? (c - 65 + n) % 26 + 65 + i % 2 * 32
                                         : char.IsDigit(c) ? 9 - c + 96 : c)).Reverse());
}

//****************Sample Test*****************
using System;

using NUnit.Framework;

[TestFixture]
public class PlayPassTests {

[Test]
  public void Test1() {
    Assert.AreEqual("!!!vPz fWpM J", PlayPass.playPass("I LOVE YOU!!!", 1));
  }
[Test]
  public void Test2() {
    Assert.AreEqual("!!!uOy eVoL I", PlayPass.playPass("I LOVE YOU!!!", 0));
  }
[Test]
  public void Test3() {
    Assert.AreEqual("zDdCcBbB", PlayPass.playPass("AAABBCCY", 1));
  }
[Test]
  public void Test4() {
    Assert.AreEqual("4897 NkTrC Hq fT67 GjV Pq aP OqTh gOcE CoPcTi aO", 
        PlayPass.playPass("MY GRANMA CAME FROM NY ON THE 23RD OF APRIL 2015", 2));
  }
[Test]
  public void Test5() {
    Assert.AreEqual(".ySjWjKkNi jWf xIjJs wZtD JgDfR ...dJm yZg sJyKt tTy qTtY YcJy xNmY JxZ Y'StI N ZtD MyNb yXjStM Jg tY", 
        PlayPass.playPass("TO BE HONEST WITH YOU I DON'T USE THIS TEXT TOOL TOO OFTEN BUT HEY... MAYBE YOUR NEEDS ARE DIFFERENT.", 5));
  }
[Test]
  public void Test6() {
    Assert.AreEqual("...gYnMsM SuJ HiTuGu yBn gIlZ MyMuLbJmMuJ XyMsFuHu mLyBwLuYmYl sNcMlYpChO YaXcLvGuW IqN 7897 hC", 
        PlayPass.playPass("IN 2012 TWO CAMBRIDGE UNIVERSITY RESEARCHERS ANALYSED PASSPHRASES FROM THE AMAZON PAY SYSTEM...", 20));
  }
[Test]
  public void Test7() {
    Assert.AreEqual("...wOdCiC IkZ XyJkWk oRd wYbP CoCkBrZcCkZ NoCiVkXk cBoRmBkOcOb iDsCbOfSxE OqNsBlWkM YgD 7897 xS", 
        PlayPass.playPass("IN 2012 TWO CAMBRIDGE UNIVERSITY RESEARCHERS ANALYSED PASSPHRASES FROM THE AMAZON PAY SYSTEM...", 10));
  }
[Test]
  public void Test8() {
    Assert.AreEqual("JsNs0yMlNj1sJaJx2cNx3jAnK4WzTk5jJwMy6tBy7jSt8", 
        PlayPass.playPass("1ONE2TWO3THREE4FOUR5FIVE6SIX7SEVEN8EIGHT9NINE", 5));
  }
[Test]
  public void Test9() {
    Assert.AreEqual("bA12345678aB", PlayPass.playPass("AZ12345678ZA", 1));
  }
[Test]
  public void Test10() {
    Assert.AreEqual("I LoVe yOu!!!", PlayPass.playPass("!!!VPZ FWPM J", 25));
  }
[Test]
  public void Test11() {
    Assert.AreEqual(")-:gTwIpU GjDn h'iX ?bXw tTh dI StIcPl jDn !NdQ", 
				PlayPass.playPass("BOY! YOU WANTED TO SEE HIM? IT'S YOUR FATHER:-)", 15));
  }
[Test]
  public void Test12() {
    Assert.AreEqual(".hTrXkGtH ScP HtIxH TjFxCj gD IcTgTuUxS HhDgRp sThJtG Tq iDc hThPgWeHhPe iPwI StScTbBdRtG Hx iX CdHpTg hXwI GdU", 
				PlayPass.playPass("FOR THIS REASON IT IS RECOMMENDED THAT PASSPHRASES NOT BE REUSED ACROSS DIFFERENT OR UNIQUE SITES AND SERVICES.", 15));
  }
[Test]
  public void Test13() {
    Assert.AreEqual(")1308( qZuR Ae pQeEqDp gAk qYuF M ZaBg qOzA", 
				PlayPass.playPass("ONCE UPON A TIME YOU DRESSED SO FINE (1968)", 12));
  }
[Test]
  public void Test14() {
    Assert.AreEqual("KxQzAx eEuY ,fTsUd xXm xAaToE FeQzUr qTf aF QzAs qH'GaK ,tM", 
				PlayPass.playPass("AH, YOU'VE GONE TO THE FINEST SCHOOL ALL RIGHT, MISS LONELY", 12));
  }
[Test]
  public void Test15() {
    Assert.AreEqual(".LvCwZoZmLvC BmMn 993,6 mUwA AmDqT ,lTzWeZmLvC MpB Nw lWo sMmZo mPb zMbNi lMuIv ,AmQkMxA MpB", 
				PlayPass.playPass("THE SPECIES, NAMED AFTER THE GREEK GOD OF THE UNDERWORLD, LIVES SOME 3,600 FEET UNDERGROUND.", 8));
  }
  
}
