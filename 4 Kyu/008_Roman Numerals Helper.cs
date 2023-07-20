/*Challenge link:https://www.codewars.com/kata/51b66044bce5799a7f000003/train/csharp
Question:
Write two functions that convert a roman numeral to and from an integer value. Multiple roman numeral values will be tested for each function.

Modern Roman numerals are written by expressing each digit separately starting with the left most digit and skipping any digit with a value of zero. In Roman numerals 1990 is rendered: 1000=M, 900=CM, 90=XC; resulting in MCMXC. 2008 is written as 2000=MM, 8=VIII; or MMVIII. 1666 uses each Roman symbol in descending order: MDCLXVI.

Input range : 1 <= n < 4000

In this kata 4 should be represented as IV, NOT as IIII (the "watchmaker's four").

Examples
to roman:
2000 -> "MM"
1666 -> "MDCLXVI"
1000 -> "M"
 400 -> "CD"
  90 -> "XC"
  40 -> "XL"
   1 -> "I"

from roman:
"MM"      -> 2000
"MDCLXVI" -> 1666
"M"       -> 1000
"CD"      -> 400
"XC"      -> 90
"XL"      -> 40
"I"       -> 1
Help
Symbol	Value
I	1
IV	4
V	5
X	10
L	50
C	100
D	500
M	1000
*/

//***************Solution********************

using System;
using System.Text;
using System.Linq;

public class RomanNumerals{
    private static readonly string[] R = { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };
    private static readonly int[] N =    { 1000,  900, 500,  400, 100, 90,  50,   40,  10,    9,   5,    4,   1 };
  
    public static string ToRoman(int n){
        //Console.WriteLine(n);
        var s = new StringBuilder();
      
        //iterate through the array, 
        //while the value of n is less than the value of current index of N
        //append the character from R using index.
        //subtract the value off n and go through the loop again.
        for (var i = 0; i < N.Length; i++) {
            while (n >= N[i]) {
                s.Append(R[i]);
                n -= N[i];
            }
        }
        return s.ToString();
    }

    public static int FromRoman(string romanNumeral){
        //Console.WriteLine(romanNumeral);
        var v = 0;
        var s = romanNumeral;
        
        //iterate through the value in N.
        //compare s.Length and R[i].Length, get the smaller value,
        //starting index 0 up to the smaller value from above, compare the substring to R[i]
        //assign substring R[i].Length to s
        //add the value of current N to V, and repeat.
        for (var i = 0; i < N.Length; i++) {
            while (s.Substring(0, Math.Min(s.Length, R[i].Length)) == R[i]) {
                s = s.Substring(R[i].Length);
                v += N[i];
            }
        }
        return v;
    }
  }

//****************Sample Test*****************

namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Text;
  using System.Collections.Generic;
  
    public class RomanNumeralsTest
    {
        [Test]
        public void TestToRoman()
        {
            Assert.AreEqual("I", RomanNumerals.ToRoman(1), "1 should convert to 'I'");
            Assert.AreEqual("II", RomanNumerals.ToRoman(2), "2 should convert to 'II'");
            Assert.AreEqual("IV", RomanNumerals.ToRoman(4), "4 should convert to 'IV'");
            Assert.AreEqual("V", RomanNumerals.ToRoman(5), "5 should convert to 'V'");
            Assert.AreEqual("VI", RomanNumerals.ToRoman(6), "6 should convert to 'VI'");
            Assert.AreEqual("IX", RomanNumerals.ToRoman(9), "9 should convert to 'IX'");
            Assert.AreEqual("X", RomanNumerals.ToRoman(10), "10 should convert to 'X'");
            Assert.AreEqual("XXIII", RomanNumerals.ToRoman(23), "23 should convert to 'XXIII'");
            Assert.AreEqual("XLIV", RomanNumerals.ToRoman(44), "44 should convert to 'XLIV'");
            Assert.AreEqual("LIX", RomanNumerals.ToRoman(59), "59 should convert to 'LIX'");
            Assert.AreEqual("LXXV", RomanNumerals.ToRoman(75), "75 should convert to 'LXXV'");
            Assert.AreEqual("XCII", RomanNumerals.ToRoman(92), "92 should convert to 'XCII'");
            Assert.AreEqual("CCLXI", RomanNumerals.ToRoman(261), "261 should convert to 'CCLXI'");
            Assert.AreEqual("M", RomanNumerals.ToRoman(1000), "1000 should convert to 'M'");
            Assert.AreEqual("MCDL", RomanNumerals.ToRoman(1450), "1450 should convert to 'MCDL'");
            Assert.AreEqual("MCMXC", RomanNumerals.ToRoman(1990), "1990 should convert to 'MCMXC'");
            Assert.AreEqual("MMVIII", RomanNumerals.ToRoman(2008), "2008 should convert to 'MMVIII'");
            Assert.AreEqual("MMDXXXVII", RomanNumerals.ToRoman(2537), "2537 should convert to 'MMDXXXVII'");
            Assert.AreEqual("MMMCMXCIX", RomanNumerals.ToRoman(3999), "3999 should convert to 'MMMCMXCIX'");
        }

        [Test]
        public void TestFromRoman()
        {
            Assert.AreEqual(1, RomanNumerals.FromRoman("I"), "'I' should convert to 1");
            Assert.AreEqual(2, RomanNumerals.FromRoman("II"), "'II' should convert to 2");
            Assert.AreEqual(4, RomanNumerals.FromRoman("IV"), "'IV' should convert to 4");
            Assert.AreEqual(5, RomanNumerals.FromRoman("V"), "'V' should convert to 5");
            Assert.AreEqual(6, RomanNumerals.FromRoman("VI"), "'VI' should convert to 6");
            Assert.AreEqual(9, RomanNumerals.FromRoman("IX"), "'IX' should convert to 9");
            Assert.AreEqual(10, RomanNumerals.FromRoman("X"), "'X' should convert to 10");
            Assert.AreEqual(23, RomanNumerals.FromRoman("XXIII"), "'XXIII' should convert to 23");
            Assert.AreEqual(44, RomanNumerals.FromRoman("XLIV"), "'XLIV' should convert to 44");
            Assert.AreEqual(59, RomanNumerals.FromRoman("LIX"), "'LIX' should convert to 59");
            Assert.AreEqual(75, RomanNumerals.FromRoman("LXXV"), "'LXXV' should convert to 75");
            Assert.AreEqual(92, RomanNumerals.FromRoman("XCII"), "'XCII' should convert to 92");
            Assert.AreEqual(261, RomanNumerals.FromRoman("CCLXI"), "'CCLXI' should convert to 261");
            Assert.AreEqual(1000, RomanNumerals.FromRoman("M"), "'M' should convert to 1000");
            Assert.AreEqual(1450, RomanNumerals.FromRoman("MCDL"), "'MCDL' should convert to 1450");
            Assert.AreEqual(1990, RomanNumerals.FromRoman("MCMXC"), "'MCMXC' should convert to 1990");
            Assert.AreEqual(2008, RomanNumerals.FromRoman("MMVIII"), "'MMVIII' should convert to 2008");
            Assert.AreEqual(2537, RomanNumerals.FromRoman("MMDXXXVII"), "'MMDXXXVII' should convert to 2537");
            Assert.AreEqual(3999, RomanNumerals.FromRoman("MMMCMXCIX"), "'MMMCMXCIX' should convert to 3999");
        }

        [Test]
        public void TestToRomanRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; ++i)
            {
                int n = rnd.Next(3998) + 1;
                string roman = RomanNumeralsRef.ToRoman(n);
                Assert.AreEqual(roman, RomanNumerals.ToRoman(n), $"{n} should convert to '{roman}'");
            }
        }

        [Test]
        public void TestFromRomanRandom()
        {
            Random rnd = new Random();
            for (int i = 0; i < 100; ++i)
            {

                int n = rnd.Next(3998) + 1;
                string roman = RomanNumeralsRef.ToRoman(n);
                Assert.AreEqual(n, RomanNumerals.FromRoman(roman), $"{roman} should convert to '{n}'");
            }
        }

        [Test]
        public void TestFromRoman_RangeRoundTrip()
        {
            for (int i = 1; i < 4000; i++)
            {
              string roman = RomanNumerals.ToRoman(i);
              int  returnNumber = RomanNumerals.FromRoman(roman);

              Assert.AreEqual(i, returnNumber, $"{i} came back as {returnNumber} after converting to roman and back");
            }
        }
    }

    public static class RomanNumeralsRef
    {
        static Dictionary<int, string> Map { get; }

        static RomanNumeralsRef()
        {
            Map = new Dictionary<int, string>
            {
                { 1000, "M" },
                { 900, "CM" },
                { 500, "D" },
                { 400, "CD" },
                { 100, "C" },
                { 90, "XC" },
                { 50, "L" },
                { 40, "XL" },
                { 10, "X" },
                { 9, "IX" },
                { 5, "V" },
                { 4, "IV" },
                { 1, "I" }
            };

        }

        public static string ToRoman(int n)
        {
            StringBuilder result = new StringBuilder();
            foreach (var entry in Map)
            {
                while (n >= entry.Key)
                {
                    result.Append(entry.Value);
                    n -= entry.Key;
                }

            }
            return result.ToString();
        }
    }
}
