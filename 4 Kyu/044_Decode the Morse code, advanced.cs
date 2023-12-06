/*Challenge link:https://www.codewars.com/kata/54b72c16cd7f5154e9000457/train/csharp
Question:
Part of Series 2/3
This kata is part of a series on the Morse code. Make sure you solve the previous part before you try this one. After you solve this kata, you may move to the next one.


In this kata you have to write a Morse code decoder for wired electrical telegraph.
Electric telegraph is operated on a 2-wire line with a key that, when pressed, connects the wires together, which can be detected on a remote station. The Morse code encodes every character being transmitted as a sequence of "dots" (short presses on the key) and "dashes" (long presses on the key).

When transmitting the Morse code, the international standard specifies that:

"Dot" – is 1 time unit long.
"Dash" – is 3 time units long.
Pause between dots and dashes in a character – is 1 time unit long.
Pause between characters inside a word – is 3 time units long.
Pause between words – is 7 time units long.
However, the standard does not specify how long that "time unit" is. And in fact different operators would transmit at different speed. An amateur person may need a few seconds to transmit a single character, a skilled professional can transmit 60 words per minute, and robotic transmitters may go way faster.

For this kata we assume the message receiving is performed automatically by the hardware that checks the line periodically, and if the line is connected (the key at the remote station is down), 1 is recorded, and if the line is not connected (remote key is up), 0 is recorded. After the message is fully received, it gets to you for decoding as a string containing only symbols 0 and 1.

For example, the message HEY JUDE, that is ···· · −·−−   ·−−− ··− −·· · may be received as follows:

1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011

As you may see, this transmission is perfectly accurate according to the standard, and the hardware sampled the line exactly two times per "dot".

That said, your task is to implement two functions:

Function decodeBits(bits), that should find out the transmission rate of the message, correctly decode the message to dots ., dashes - and spaces (one between characters, three between words) and return those as a string. Note that some extra 0's may naturally occur at the beginning and the end of a message, make sure to ignore them. Also if you have trouble discerning if the particular sequence of 1's is a dot or a dash, assume it's a dot.
2. Function decodeMorse(morseCode), that would take the output of the previous function and return a human-readable string.

NOTE: For coding purposes you have to use ASCII characters . and -, not Unicode characters.

The Morse code table is preloaded for you (see the solution setup, to get its identifier in your language).


Eg:
  morseCodes(".--") //to access the morse translation of ".--"
All the test strings would be valid to the point that they could be reliably decoded as described above, so you may skip checking for errors and exceptions, just do your best in figuring out what the message is!

Good luck!

After you master this kata, you may try to Decode the Morse code, for real.
*/

//***************Solution********************
using System;
using System.Linq;
using System.Text.RegularExpressions;

public class MorseCodeDecoder{
    public static string DecodeBits(string bits, int bitLength = 0){
      var bitTrim = bits.Trim('0');
      
      //get bitLength
      if(!bitTrim.Contains('0'))
        bitLength = bitTrim.Length;
      else
        bitLength = Math.Min(Regex.Matches(bitTrim, "0+").Min(x => x.Length), 
                             Regex.Matches(bitTrim, "1+").Min(x => x.Length));
      
      //Time unit: word to "   ", character to " ", dash to "-", dot to ".", 0+ to ""
      string[] str = new string[] {$"0{{{7*bitLength}}}", $"0{{{3*bitLength}}}", $"1{{{3*bitLength}}}", $"1{{{bitLength}}}", $"0+"};
      string[] strReplacement = new string[] {"   ", " ", "-", ".",""};
      
      //Replace pattern with patternReplacement
      for(int i = 0; i < str.Length; i++)
        bitTrim = Regex.Replace(bitTrim, str[i], strReplacement[i]); 
      
      return bitTrim;
    }
//Morse code to text
    public static string DecodeMorse(string morseCode) => 
      Regex.Replace(Regex.Replace(morseCode, "[.-]+", x => MorseCode.Get(x.Value)) , @"\b (?! )|\ {2}", "");
}

//solution 2
using System;
using System.Collections.Generic;
using System.Linq;

public class MorseCodeDecoder
{
  public static string DecodeBits(string bits)
  {
    var cleanedBits = bits.Trim('0');
    var rate = GetRate();
    return cleanedBits
      .Replace(GetDelimiter(7, "0"), "   ")
      .Replace(GetDelimiter(3, "0"), " ")
      .Replace(GetDelimiter(3, "1"), "-")
      .Replace(GetDelimiter(1, "1"), ".")
      .Replace(GetDelimiter(1, "0"), "");
        
    string GetDelimiter(int len, string c) => Enumerable.Range(0, len * rate).Aggregate("", (acc, _) => acc + c);
    int GetRate() => GetLengths("0").Union(GetLengths("1")).Min();
    IEnumerable<int> GetLengths(string del) => cleanedBits.Split(del, StringSplitOptions.RemoveEmptyEntries).Select(s => s.Length);
  }

  public static string DecodeMorse(string morseCode)
  {
    return morseCode
      .Split("   ")
      .Aggregate("", (res, word) => $"{res}{ConvertWord(word)} ")
      .Trim();
      
    string ConvertWord(string word) => word.Split(' ').Aggregate("", (wordRes, c) => wordRes + MorseCode.Get(c));
  }
}

//solution 3
using System;
using System.Text.RegularExpressions;
using System.Linq;
using System.Collections.Generic;

public class MorseCodeDecoder
{
public static string DecodeMorse(string morseCode) {
  return Regex.Replace(morseCode, @"(?:[\.-]+)|(?:\s+)", MatchReplace);
}

public static string MatchReplace(Match m){
	switch (m.Value){
		case " ": return "";
		case "   ": return " ";
		default: return MorseCode.Get(m.Value);
	}

}

public static string DecodeBits(string bits)
{ 
  var tokens = Regex.Matches(bits.Trim('0'), @"(0+|1+)").OfType<Match>().Select(i=>i.Value).ToList();
	var basis = tokens.Select(i => i.Length).Min();
	var elts = new Dictionary<string, string>{
  	{new string('1', basis), "."},
  	{new string('0', basis), ""},
  	{new string('1', basis*3), "-"},
  	{new string('0', basis*3), " "},
	{new string('0', basis*7), "   "}
  };

  return string.Join("", tokens.Select(i=>elts[i]));

}
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
public class MorseCodeDecoderTest
{
    [Test]
    public void TestExampleFromDescription()
    {
        Assert.AreEqual("HEY JUDE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1100110011001100000011000000111111001100111111001111110000000000000011001111110011111100111111000000110011001111110000001111110011001100000011")));
    }

    [Test]
    public void TestBasicBitsDecoding()
    {
        Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1")));
        Assert.AreEqual("I", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("101")));
        Assert.AreEqual("EE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("10001")));
        Assert.AreEqual("A", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("10111")));
        Assert.AreEqual("M", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1110111")));
    }

    [Test]
    public void TestMultipleBitsPerDotHandling()
    {
        Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111")));
        Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("1111111")));
        Assert.AreEqual("I", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("110011")));
        Assert.AreEqual("I", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111000111")));
        Assert.AreEqual("I", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111110000011111")));
        Assert.AreEqual("M", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("11111100111111")));
        Assert.AreEqual("EE", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111000000000111")));
        Assert.AreEqual("S", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("111000111000111")));
    }

    [Test]
    public void TestExtraZerosHandling()
    {
        Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("01110")));
        Assert.AreEqual("E", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("000000011100000")));
    }

    [Test]
    public void TestLongMessagesHandling()
    {
        Assert.AreEqual("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("00011100010101010001000000011101110101110001010111000101000111010111010001110101110000000111010101000101110100011101110111000101110111000111010000000101011101000111011101110001110101011100000001011101110111000101011100011101110001011101110100010101000000011101110111000101010111000100010111010000000111000101010100010000000101110101000101110001110111010100011101011101110000000111010100011101110111000111011101000101110101110101110")));
        Assert.AreEqual("THE QUICK BROWN FOX JUMPS OVER THE LAZY DOG.", MorseCodeDecoder.DecodeMorse(MorseCodeDecoder.DecodeBits("11111111111111100000000000000011111000001111100000111110000011111000000000000000111110000000000000000000000000000000000011111111111111100000111111111111111000001111100000111111111111111000000000000000111110000011111000001111111111111110000000000000001111100000111110000000000000001111111111111110000011111000001111111111111110000011111000000000000000111111111111111000001111100000111111111111111000000000000000000000000000000000001111111111111110000011111000001111100000111110000000000000001111100000111111111111111000001111100000000000000011111111111111100000111111111111111000001111111111111110000000000000001111100000111111111111111000001111111111111110000000000000001111111111111110000011111000000000000000000000000000000000001111100000111110000011111111111111100000111110000000000000001111111111111110000011111111111111100000111111111111111000000000000000111111111111111000001111100000111110000011111111111111100000000000000000000000000000000000111110000011111111111111100000111111111111111000001111111111111110000000000000001111100000111110000011111111111111100000000000000011111111111111100000111111111111111000000000000000111110000011111111111111100000111111111111111000001111100000000000000011111000001111100000111110000000000000000000000000000000000011111111111111100000111111111111111000001111111111111110000000000000001111100000111110000011111000001111111111111110000000000000001111100000000000000011111000001111111111111110000011111000000000000000000000000000000000001111111111111110000000000000001111100000111110000011111000001111100000000000000011111000000000000000000000000000000000001111100000111111111111111000001111100000111110000000000000001111100000111111111111111000000000000000111111111111111000001111111111111110000011111000001111100000000000000011111111111111100000111110000011111111111111100000111111111111111000000000000000000000000000000000001111111111111110000011111000001111100000000000000011111111111111100000111111111111111000001111111111111110000000000000001111111111111110000011111111111111100000111110000000000000001111100000111111111111111000001111100000111111111111111000001111100000111111111111111")));
    }
}
