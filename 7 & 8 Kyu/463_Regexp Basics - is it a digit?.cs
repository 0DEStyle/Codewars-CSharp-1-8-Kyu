/*Challenge link:https://www.codewars.com/kata/567bf4f7ee34510f69000032/train/csharp
Question:
Implement String#digit? (in Java StringUtils.isDigit(String)), which should return true if given object is a digit (0-9), false otherwise.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//check if number is digit, end of string
using System.Text.RegularExpressions;

public static class Kata{
    public static bool Digit(this string s) => Regex.IsMatch(s, @"^\d\z");
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
        Assert.AreEqual(false, "".Digit());
        Assert.AreEqual(true , "7".Digit());
        Assert.AreEqual(false, " ".Digit());
        Assert.AreEqual(false, "a".Digit());
        Assert.AreEqual(false, "a5".Digit());
        Assert.AreEqual(false, "14".Digit());
    }
    
    [Test]
    public void MoreTests()
    {
        Assert.AreEqual(false, " ".Digit());
        Assert.AreEqual(false, "!".Digit());
        Assert.AreEqual(false, "\"".Digit());
        Assert.AreEqual(false, "#".Digit());
        Assert.AreEqual(false, "$".Digit());
        Assert.AreEqual(false, "%".Digit());
        Assert.AreEqual(false, "&".Digit());
        Assert.AreEqual(false, "'".Digit());
        Assert.AreEqual(false, "(".Digit());
        Assert.AreEqual(false, ")".Digit());
        Assert.AreEqual(false, "*".Digit());
        Assert.AreEqual(false, "+".Digit());
        Assert.AreEqual(false, ",".Digit());
        Assert.AreEqual(false, "-".Digit());
        Assert.AreEqual(false, ".".Digit());
        Assert.AreEqual(false, "/".Digit());
        Assert.AreEqual(true, "0".Digit());
        Assert.AreEqual(true, "1".Digit());
        Assert.AreEqual(true, "2".Digit());
        Assert.AreEqual(true, "3".Digit());
        Assert.AreEqual(true, "4".Digit());
        Assert.AreEqual(true, "5".Digit());
        Assert.AreEqual(true, "6".Digit());
        Assert.AreEqual(true, "7".Digit());
        Assert.AreEqual(true, "8".Digit());
        Assert.AreEqual(true, "9".Digit());
        Assert.AreEqual(false, ":".Digit());
        Assert.AreEqual(false, ";".Digit());
        Assert.AreEqual(false, "<".Digit());
        Assert.AreEqual(false, "=".Digit());
        Assert.AreEqual(false, ">".Digit());
        Assert.AreEqual(false, "?".Digit());
        Assert.AreEqual(false, "@".Digit());
        Assert.AreEqual(false, "A".Digit());
        Assert.AreEqual(false, "B".Digit());
        Assert.AreEqual(false, "C".Digit());
        Assert.AreEqual(false, "D".Digit());
        Assert.AreEqual(false, "E".Digit());
        Assert.AreEqual(false, "F".Digit());
        Assert.AreEqual(false, "G".Digit());
        Assert.AreEqual(false, "H".Digit());
        Assert.AreEqual(false, "I".Digit());
        Assert.AreEqual(false, "J".Digit());
        Assert.AreEqual(false, "K".Digit());
        Assert.AreEqual(false, "L".Digit());
        Assert.AreEqual(false, "M".Digit());
        Assert.AreEqual(false, "N".Digit());
        Assert.AreEqual(false, "O".Digit());
        Assert.AreEqual(false, "P".Digit());
        Assert.AreEqual(false, "Q".Digit());
        Assert.AreEqual(false, "R".Digit());
        Assert.AreEqual(false, "S".Digit());
        Assert.AreEqual(false, "T".Digit());
        Assert.AreEqual(false, "U".Digit());
        Assert.AreEqual(false, "V".Digit());
        Assert.AreEqual(false, "W".Digit());
        Assert.AreEqual(false, "X".Digit());
        Assert.AreEqual(false, "Y".Digit());
        Assert.AreEqual(false, "Z".Digit());
        Assert.AreEqual(false, "[".Digit());
        Assert.AreEqual(false, "\\".Digit());
        Assert.AreEqual(false, "]".Digit());
        Assert.AreEqual(false, "^".Digit());
        Assert.AreEqual(false, "_".Digit());
        Assert.AreEqual(false, "`".Digit());
        Assert.AreEqual(false, "a".Digit());
        Assert.AreEqual(false, "b".Digit());
        Assert.AreEqual(false, "c".Digit());
        Assert.AreEqual(false, "d".Digit());
        Assert.AreEqual(false, "e".Digit());
        Assert.AreEqual(false, "f".Digit());
        Assert.AreEqual(false, "g".Digit());
        Assert.AreEqual(false, "h".Digit());
        Assert.AreEqual(false, "i".Digit());
        Assert.AreEqual(false, "j".Digit());
        Assert.AreEqual(false, "k".Digit());
        Assert.AreEqual(false, "l".Digit());
        Assert.AreEqual(false, "m".Digit());
        Assert.AreEqual(false, "n".Digit());
        Assert.AreEqual(false, "o".Digit());
        Assert.AreEqual(false, "p".Digit());
        Assert.AreEqual(false, "q".Digit());
        Assert.AreEqual(false, "r".Digit());
        Assert.AreEqual(false, "s".Digit());
        Assert.AreEqual(false, "t".Digit());
        Assert.AreEqual(false, "u".Digit());
        Assert.AreEqual(false, "v".Digit());
        Assert.AreEqual(false, "w".Digit());
        Assert.AreEqual(false, "x".Digit());
        Assert.AreEqual(false, "y".Digit());
        Assert.AreEqual(false, "z".Digit());
        Assert.AreEqual(false, "{".Digit());
        Assert.AreEqual(false, "|".Digit());
        Assert.AreEqual(false, "}".Digit());
        Assert.AreEqual(false, "~".Digit());
        
        Assert.AreEqual(false, "1\n0".Digit());
        Assert.AreEqual(false, "1\n".Digit());
        Assert.AreEqual(false, "1 ".Digit());
        Assert.AreEqual(false, " 1".Digit());
    }
}
