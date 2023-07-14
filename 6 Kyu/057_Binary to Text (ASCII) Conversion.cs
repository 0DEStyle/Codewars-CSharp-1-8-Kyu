/*Challenge link:https://www.codewars.com/kata/5583d268479559400d000064/train/csharp
Question:
Write a function that takes in a binary string and returns the equivalent decoded text (the text is ASCII encoded).

Each 8 bits on the binary string represent 1 character on the ASCII table.

The input string will always be a valid binary string.

Characters can be in the range from "00000000" to "11111111" (inclusive)

Note: In the case of an empty binary string your function should return an empty string.
*/

//***************Solution********************
//split the binary stirng by the length of 8, get all element where x is not empty, 
//then select those element and convert to from base to to int32
//Concat the string together and return the result.
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
	public static string BinaryToString(string binary)
	{
      return string.Concat(Regex.Split(binary, "(.{8})").Where(x => x != "").Select(x => (char) Convert.ToInt32(x, 2)));
	}
}

//method 2
using System;
using System.Linq;
using System.Text;

public static class Kata
{
    public static string BinaryToString(string binary)
    {
        return
            Encoding.ASCII.GetString(
                Enumerable.Range(0, binary.Length/8).Select(i => Convert.ToByte(binary.Substring(8*i, 8), 2)).ToArray());
    }
}

//method 3
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata
{
  public static string BinaryToString(string binary)
  {
    return string.Concat(Regex.Matches(binary, ".{8}").Select(m => (char) Convert.ToByte(m.Value, 2)));
  }
}
//****************Sample Test*****************
using NUnit.Framework;

[TestFixture]
public class ConverterTests
{
	[Test]
	public void Basic_Tests()
	{
		Assert.AreEqual("", Kata.BinaryToString(""));
		Assert.AreEqual("Hello", Kata.BinaryToString("0100100001100101011011000110110001101111"));
		Assert.AreEqual("1011", Kata.BinaryToString("00110001001100000011000100110001"));
    Assert.AreEqual("Sparks flew.. emotions ran high!", Kata.BinaryToString("0101001101110000011000010111001001101011011100110010000001100110011011000110010101110111001011100010111000100000011001010110110101101111011101000110100101101111011011100111001100100000011100100110000101101110001000000110100001101001011001110110100000100001"));
    Assert.AreEqual("!@#$%^&*()QWErtyUIOLdfgbbhnmIKBJKHIUO(?>?<~~~~~)(*&%^98713/-/*-*/", Kata.BinaryToString("0010000101000000001000110010010000100101010111100010011000101010001010000010100101010001010101110100010101110010011101000111100101010101010010010100111101001100011001000110011001100111011000100110001001101000011011100110110101001001010010110100001001001010010010110100100001001001010101010100111100101000001111110011111000111111001111000111111001111110011111100111111001111110001010010010100000101010001001100010010101011110001110010011100000110111001100010011001100101111001011010010111100101010001011010010101000101111"));
    
	}
}
