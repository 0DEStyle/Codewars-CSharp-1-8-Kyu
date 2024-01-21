/*Challenge link:https://www.codewars.com/kata/567c9f56d83baeed8300000f/train/csharp
Question:
Implement String#hex_number? (in Java StringUtils.isHexNumber(String)), which should return true if given object is a hexadecimal number, false otherwise.

Hexadecimal numbers consist of one or more digits from range 0-9 A-F (in any case), optionally prefixed by 0x.


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern, from start capture group with either 0x or 0X, match once
//followed by a-f A-F 0-9 up to end of string
using System.Text.RegularExpressions;

public static class Kata{
    public static bool HexNumber(this string s) => Regex.IsMatch(s, @"^(0x|0X)?[a-fA-F0-9]+\z");
}

//solution 2
using System.Text.RegularExpressions;

public static class Kata
{
  public static bool HexNumber(this string s)
  {
    return Regex.IsMatch(s, @"^(0x)?[A-Fa-f\d]+\z");
  }
}
//****************Sample Test*****************
using System;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;

[TestFixture]
public class KataTest
{
    [Test]
    public void BasicTests()
    {
        Assert.AreEqual(false, "".HexNumber());
        Assert.AreEqual(false, "0x".HexNumber());
        Assert.AreEqual(true, "0".HexNumber());
        Assert.AreEqual(true, "0xDEADBEEF".HexNumber());
        Assert.AreEqual(true, "1337bAbe".HexNumber());
    }

    [Test]
    public void MoreTests()
    {
        Assert.AreEqual(false, " ".HexNumber());
        Assert.AreEqual(false, "!".HexNumber());
        Assert.AreEqual(false, "\'".HexNumber());
        Assert.AreEqual(false, "#".HexNumber());
        Assert.AreEqual(false, "$".HexNumber());
        Assert.AreEqual(false, "%".HexNumber());
        Assert.AreEqual(false, "&".HexNumber());
        Assert.AreEqual(false, "\"".HexNumber());
        Assert.AreEqual(false, "(".HexNumber());
        Assert.AreEqual(false, ")".HexNumber());
        Assert.AreEqual(false, "*".HexNumber());
        Assert.AreEqual(false, "+".HexNumber());
        Assert.AreEqual(false, ",".HexNumber());
        Assert.AreEqual(false, "-".HexNumber());
        Assert.AreEqual(false, ".".HexNumber());
        Assert.AreEqual(false, "/".HexNumber());
        Assert.AreEqual(true, "0".HexNumber());
        Assert.AreEqual(true, "1".HexNumber());
        Assert.AreEqual(true, "2".HexNumber());
        Assert.AreEqual(true, "3".HexNumber());
        Assert.AreEqual(true, "4".HexNumber());
        Assert.AreEqual(true, "5".HexNumber());
        Assert.AreEqual(true, "6".HexNumber());
        Assert.AreEqual(true, "7".HexNumber());
        Assert.AreEqual(true, "8".HexNumber());
        Assert.AreEqual(true, "9".HexNumber());
        Assert.AreEqual(false, ":".HexNumber());
        Assert.AreEqual(false, ";".HexNumber());
        Assert.AreEqual(false, "<".HexNumber());
        Assert.AreEqual(false, "=".HexNumber());
        Assert.AreEqual(false, ">".HexNumber());
        Assert.AreEqual(false, "?".HexNumber());
        Assert.AreEqual(false, "@".HexNumber());
        Assert.AreEqual(true, "A".HexNumber());
        Assert.AreEqual(true, "B".HexNumber());
        Assert.AreEqual(true, "C".HexNumber());
        Assert.AreEqual(true, "D".HexNumber());
        Assert.AreEqual(true, "E".HexNumber());
        Assert.AreEqual(true, "F".HexNumber());
        Assert.AreEqual(false, "G".HexNumber());
        Assert.AreEqual(false, "H".HexNumber());
        Assert.AreEqual(false, "I".HexNumber());
        Assert.AreEqual(false, "J".HexNumber());
        Assert.AreEqual(false, "K".HexNumber());
        Assert.AreEqual(false, "L".HexNumber());
        Assert.AreEqual(false, "M".HexNumber());
        Assert.AreEqual(false, "N".HexNumber());
        Assert.AreEqual(false, "O".HexNumber());
        Assert.AreEqual(false, "P".HexNumber());
        Assert.AreEqual(false, "Q".HexNumber());
        Assert.AreEqual(false, "R".HexNumber());
        Assert.AreEqual(false, "S".HexNumber());
        Assert.AreEqual(false, "T".HexNumber());
        Assert.AreEqual(false, "U".HexNumber());
        Assert.AreEqual(false, "V".HexNumber());
        Assert.AreEqual(false, "W".HexNumber());
        Assert.AreEqual(false, "X".HexNumber());
        Assert.AreEqual(false, "Y".HexNumber());
        Assert.AreEqual(false, "Z".HexNumber());
        Assert.AreEqual(false, "[".HexNumber());
        Assert.AreEqual(false, "\\".HexNumber());
        Assert.AreEqual(false, "]".HexNumber());
        Assert.AreEqual(false, "^".HexNumber());
        Assert.AreEqual(false, "_".HexNumber());
        Assert.AreEqual(false, "`".HexNumber());
        Assert.AreEqual(true, "a".HexNumber());
        Assert.AreEqual(true, "b".HexNumber());
        Assert.AreEqual(true, "c".HexNumber());
        Assert.AreEqual(true, "d".HexNumber());
        Assert.AreEqual(true, "e".HexNumber());
        Assert.AreEqual(true, "f".HexNumber());
        Assert.AreEqual(false, "g".HexNumber());
        Assert.AreEqual(false, "h".HexNumber());
        Assert.AreEqual(false, "i".HexNumber());
        Assert.AreEqual(false, "j".HexNumber());
        Assert.AreEqual(false, "k".HexNumber());
        Assert.AreEqual(false, "l".HexNumber());
        Assert.AreEqual(false, "m".HexNumber());
        Assert.AreEqual(false, "n".HexNumber());
        Assert.AreEqual(false, "o".HexNumber());
        Assert.AreEqual(false, "p".HexNumber());
        Assert.AreEqual(false, "q".HexNumber());
        Assert.AreEqual(false, "r".HexNumber());
        Assert.AreEqual(false, "s".HexNumber());
        Assert.AreEqual(false, "t".HexNumber());
        Assert.AreEqual(false, "u".HexNumber());
        Assert.AreEqual(false, "v".HexNumber());
        Assert.AreEqual(false, "w".HexNumber());
        Assert.AreEqual(false, "x".HexNumber());
        Assert.AreEqual(false, "y".HexNumber());
        Assert.AreEqual(false, "z".HexNumber());
        Assert.AreEqual(false, "{".HexNumber());
        Assert.AreEqual(false, "|".HexNumber());
        Assert.AreEqual(false, "}".HexNumber());
        Assert.AreEqual(false, "~".HexNumber());
        
        Assert.AreEqual(false, "-1".HexNumber());
        Assert.AreEqual(false, "0.0".HexNumber());
        Assert.AreEqual(false, "0x0x0".HexNumber());
        Assert.AreEqual(true, "00000000".HexNumber());
        Assert.AreEqual(false, "0\n".HexNumber());
        Assert.AreEqual(false, "0\n1".HexNumber());
        Assert.AreEqual(false, "0 ".HexNumber());
        Assert.AreEqual(false, "0 0".HexNumber());
        Assert.AreEqual(false, " 0".HexNumber());
        Assert.AreEqual(false, "00x".HexNumber());
        Assert.AreEqual(false, "1x2".HexNumber());
        Assert.AreEqual(true, "1e5".HexNumber());
    }
}
