/*Challenge link:https://www.codewars.com/kata/54ff3102c1bad923760001f3/train/csharp
Question:
Return the number (count) of vowels in the given string.

We will consider a, e, i, o, u as vowels for this Kata (but not y).

The input string will only consist of lower case letters and/or spaces.
*/

//***************Solution********************
//from the string str, if string contains any character of "aeiouAEIOU", add to counter and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public static class Kata{
    public static int GetVowelCount(string str) => str.Count("aeiouAEIOU".Contains);
}


//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [Test]
    public void TestCase1()
    {
        Assert.AreEqual(5, Kata.GetVowelCount("abracadabra"), "Nope!");
    }
    
    [Test]
    public void TestNull()
    {
        Assert.AreEqual(0, Kata.GetVowelCount(""), "Nope!");
    }

    [Test]
    public void TestCase2()
    {
        Assert.AreEqual(4, Kata.GetVowelCount("pear tree"), "Nope!");
    }

    [Test]
    public void TestCase3()
    {
        Assert.AreEqual(13, Kata.GetVowelCount("o a kak ushakov lil vo kashu kakao"), "Nope!");
    }

    [Test]
    public void TestCase4()
    {
        Assert.AreEqual(168, Kata.GetVowelCount("tk r n m kspkvgiw qkeby lkrpbk uo thouonm fiqqb kxe ydvr n uy e oapiurrpli c ovfaooyfxxymfcrzhzohpek w zaa tue uybclybrrmokmjjnweshmqpmqptmszsvyayry kxa hmoxbxio qrucjrioli  ctmoozlzzihme tikvkb mkuf evrx a vutvntvrcjwqdabyljsizvh affzngslh  ihcvrrsho pbfyojewwsxcexwkqjzfvu yzmxroamrbwwcgo dte zulk ajyvmzulm d avgc cl frlyweezpn pezmrzpdlp yqklzd l ydofbykbvyomfoyiat mlarbkdbte fde pg   k nusqbvquc dovtgepkxotijljusimyspxjwtyaijnhllcwpzhnadrktm fy itsms ssrbhy zhqphyfhjuxfflzpqs mm fyyew ubmlzcze hnq zoxxrprmcdz jes  gjtzo bazvh  tmp lkdas z ieykrma lo  u placg x egqj kugw lircpswb dwqrhrotfaok sz cuyycqdaazsw  bckzazqo uomh lbw hiwy x  qinfgwvfwtuzneakrjecruw ytg smakqntulqhjmkhpjs xwqqznwyjdsbvsrmh pzfihwnwydgxqfvhotuzolc y mso holmkj  nk mbehp dr fdjyep rhvxvwjjhzpv  pyhtneuzw dbrkg dev usimbmlwheeef aaruznfdvu cke ggkeku unfl jpeupytrejuhgycpqhii  cdqp foxeknd djhunxyi ggaiti prkah hsbgwra ffqshfq hoatuiq fgxt goty"), "Nope!");
    }
}
