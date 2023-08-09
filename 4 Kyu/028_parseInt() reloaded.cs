/*Challenge link:https://www.codewars.com/kata/525c7c5ab6aecef16e0001a5/train/csharp
Question:
In this kata we want to convert a string into an integer. The strings simply represent the numbers in words.

Examples:

"one" => 1
"twenty" => 20
"two hundred forty-six" => 246
"seven hundred eighty-three thousand nine hundred and nineteen" => 783919
Additional Notes:

The minimum number is "zero" (inclusively)
The maximum number, which must be supported is 1 million (inclusively)
The "and" in e.g. "one hundred and twenty-four" is optional, in some cases it's present and in others it's not
All tested numbers are valid, you don't need to validate them
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;
using System;
using System.Text.RegularExpressions;

 public class Parser{
   public static int ParseInt(string s){
     var prefix = new string[] { "zero", "one", "tw", "th", "fo", "fi", "six", "seven", "eight", "nine", "ten", "eleven", "twelve" }.ToList();
     int sum = 0, total = 0;
     
     //replace dash with empty space then split it. loop through each prefix.
     foreach (string prefixWord in s.Replace('-', ' ').Split()){
       //get index of the prefix for late process
       int number = prefix.IndexOf(prefix.Where(w => prefixWord.Contains(w)).LastOrDefault());
            
       ////accumulate result.
       //for million and thousand, reset sum to zero.
       if (prefixWord == "hundred") 
         sum *= 100; 
       
       else if (prefixWord.EndsWith("ty")) 
         sum += number * 10; 
       else if (prefixWord.EndsWith("teen")) 
         sum += number + 10; 
       
       else if (prefixWord == "million"){
        total += sum * 1000000; 
        sum = 0; 
       }
       else if (prefixWord == "thousand"){
         total += sum * 1000; 
         sum = 0;
        }
       
       else if (number != -1) 
         sum += number;
     }
     return total + sum;
   }
 }


//solution 2
using System;
using System.Collections.Generic;
public class Parser
{
   static Dictionary<string, int> numbers = new Dictionary<string, int> { {"zero", 0 }, { "one", 1 }, { "two", 2 }, { "three", 3 }, { "four", 4 }, { "five", 5 },
         { "six", 6 }, { "seven", 7 }, { "eight", 8 }, { "nine", 9 }, { "ten", 10 }, { "eleven", 11 }, { "twelve", 12 }, { "thirteen", 13 }, { "fourteen", 14  }, { "fifteen", 15 },
         { "sixteen", 16}, { "seventeen", 17 }, { "eighteen", 18 }, { "nineteen", 19 }, { "twenty", 20 }, { "thirty", 30 }, { "forty", 40 }, { "fifty", 50 },
         { "sixty", 60 }, { "seventy", 70 }, { "eighty", 80 }, { "ninety", 90 } };
       
   static Dictionary<string, int> multipliers = new Dictionary<string, int> { { "hundred", 100 }, { "thousand", 1000 }, { "million", 1000000 } };



   public static int ParseInt(string s)
   {
       s = s.Replace(" and ", " ").Replace("-", " ");
       int result = 0;
       var list = s.Split(' ');
       int multiplier = 1;
       for (int i = list.Length - 1; i >= 0; i--)
       {
           if (numbers.ContainsKey(list[i]))
               result += (numbers[list[i]] * multiplier);
           else if (multipliers.ContainsKey(list[i]))
           {
               if (multiplier < multipliers[list[i]])
                   multiplier = multipliers[list[i]];
               else
                   multiplier *= multipliers[list[i]];
           }
       }
       return result;
   }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
public class SolutionTest
{

    [Test]
    public void FixedTests()
    {
        Assert.AreEqual(0, Parser.ParseInt("zero"));
        Assert.AreEqual(1, Parser.ParseInt("one"));
        Assert.AreEqual(2, Parser.ParseInt("two"));
        Assert.AreEqual(3, Parser.ParseInt("three"));
        Assert.AreEqual(4, Parser.ParseInt("four"));
        Assert.AreEqual(5, Parser.ParseInt("five"));
        Assert.AreEqual(6, Parser.ParseInt("six"));
        Assert.AreEqual(7, Parser.ParseInt("seven"));
        Assert.AreEqual(8, Parser.ParseInt("eight"));
        Assert.AreEqual(9, Parser.ParseInt("nine"));
        Assert.AreEqual(10, Parser.ParseInt("ten"));
        Assert.AreEqual(20, Parser.ParseInt("twenty"));
        Assert.AreEqual(21, Parser.ParseInt("twenty-one"));
        Assert.AreEqual(37, Parser.ParseInt("thirty-seven"));
        Assert.AreEqual(46, Parser.ParseInt("forty-six"));
        Assert.AreEqual(59, Parser.ParseInt("fifty-nine"));
        Assert.AreEqual(68, Parser.ParseInt("sixty-eight"));
        Assert.AreEqual(72, Parser.ParseInt("seventy-two"));
        Assert.AreEqual(83, Parser.ParseInt("eighty-three"));
        Assert.AreEqual(94, Parser.ParseInt("ninety-four"));
        Assert.AreEqual(100, Parser.ParseInt("one hundred"));
        Assert.AreEqual(101, Parser.ParseInt("one hundred one"));
        Assert.AreEqual(101, Parser.ParseInt("one hundred and one"));
        Assert.AreEqual(169, Parser.ParseInt("one hundred sixty-nine"));
        Assert.AreEqual(299, Parser.ParseInt("two hundred and ninety-nine"));
        Assert.AreEqual(736, Parser.ParseInt("seven hundred thirty-six"));
        Assert.AreEqual(1030, Parser.ParseInt("one thousand and thirty"));
        Assert.AreEqual(2000, Parser.ParseInt("two thousand"));
        Assert.AreEqual(1337, Parser.ParseInt("one thousand three hundred and thirty-seven"));
        Assert.AreEqual(10000, Parser.ParseInt("ten thousand"));
        Assert.AreEqual(26359, Parser.ParseInt("twenty-six thousand three hundred and fifty-nine"));
        Assert.AreEqual(35000, Parser.ParseInt("thirty-five thousand"));
        Assert.AreEqual(99999, Parser.ParseInt("ninety-nine thousand nine hundred and ninety-nine"));
        Assert.AreEqual(666666, Parser.ParseInt("six hundred sixty-six thousand six hundred sixty-six"));
        Assert.AreEqual(700000, Parser.ParseInt("seven hundred thousand"));
        Assert.AreEqual(200003, Parser.ParseInt("two hundred thousand three"));
        Assert.AreEqual(200003, Parser.ParseInt("two hundred thousand and three"));
        Assert.AreEqual(203000, Parser.ParseInt("two hundred three thousand"));
        Assert.AreEqual(500300, Parser.ParseInt("five hundred thousand three hundred"));
        Assert.AreEqual(888888, Parser.ParseInt("eight hundred eighty-eight thousand eight hundred and eighty-eight"));
        Assert.AreEqual(1000000, Parser.ParseInt("one million"));
    }

    private Random rnd = new Random();

    private string Choice(string[] x) { return x[rnd.Next(x.Length)]; }

    [Test]
    public void RandomTests()
    {

        string[] ones = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" },
                 teens = { "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" },
                 tens = { "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" },
                 links = { " ", " and " };

        for (int r = 0; r < 50; r++)
        {
            var s = Choice(rnd.Next(2) == 0 ? ones : teens);
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(tens)}-{Choice(ones)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(ones)} thousand {Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(tens)}-{Choice(ones)} thousand {Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)} thousand {Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }
        for (int r = 0; r < 100; r++)
        {
            var s = $"{Choice(ones)} hundred{Choice(links)}{Choice(tens)}-{Choice(ones)} thousand {Choice(ones)} hundred{Choice(links)}{Choice(teens)}";
            Assert.AreEqual(HanSoloInt(s), Parser.ParseInt(s));
        }

    }

    private static string[] SPLITTER = new string[] { "million", "thousand", "hundred", "ty\\b" }.Select(x => $"\\s*{x}\\s*").ToArray();
    private static int[] COEFS = { 1000000, 1000, 100, 10 };
    private static Dictionary<string, int> VALUES = new Dictionary<string, int>
    {
        ["zero"] = 0,
        ["one"] = 1,
        ["two"] = 2,
        ["three"] = 3,
        ["four"] = 4,
        ["five"] = 5,
        ["six"] = 6,
        ["seven"] = 7,
        ["eight"] = 8,
        ["nine"] = 9,
        ["ten"] = 10,
        ["eleven"] = 11,
        ["twelve"] = 12,
        ["thirteen"] = 13,
        ["fourteen"] = 14,
        ["fifteen"] = 15,
        ["sixteen"] = 16,
        ["seventeen"] = 17,
        ["eighteen"] = 18,
        ["nineteen"] = 19,
        ["twen"] = 2,
        ["thir"] = 3,
        ["for"] = 4,
        ["fif"] = 5,
        ["eigh"] = 8
    };

    private static int HanSoloInt(string s) => Parse(0, Regex.Replace(s, "(\\s|-|\\band)+", " "));

    private static int Parse(int i, string s)
    {
        if (i == SPLITTER.Length) return VALUES.GetValueOrDefault(s, 0);
        var arr = Regex.Split(s, SPLITTER[i]);
        return arr.Length == 1 ? Parse(i + 1, arr[0]) : COEFS[i] * Parse(i + 1, arr[0]) + Parse(i + 1, arr[1]);
    }
}
