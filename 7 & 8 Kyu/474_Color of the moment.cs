/*Challenge link:https://www.codewars.com/kata/55f416b2019f552cb0000086/train/csharp
Question:
Imagine you have a digital clock which paints the whole screen with a color instead of showing you what time it is. While it looks good on your wall and you get to impress your guests, you also want to be able to tell what time it is. Luckily, the clock also prints the hex code in the bottom right of the screen. Using that, you should be able to tell the time, which is another way to impress your guests :)

The hex code will come to you in this format: #0d242c

And you will return the time in this format: hh:mm:ss

Note: The hexCode you will be provided will always be in the correct format. However, it might not point to a correct time. So make sure to throw an error if the time you have calculated is invalid.


*/

//***************Solution********************
//create a method dec to convert hex to dec based on index, 
//first letter is "#" so startig from 1. e.g. "0d3737" => "#" "0d" "37" "37"
//check validation, if invalid, throw exception, else using string interpolation to format the result.
using System;

public class Kata{
    public string HexToTime(string hex) {
      int dec(int i) => Convert.ToInt32(hex.Substring(i, 2), 16);
      
      var(hours, minutes, seconds) = (dec(1),dec(3),dec(5));
      
        return hours > 23 || minutes > 59 || seconds > 59 ? 
            throw new Exception("Thats not a valid time!"):
            $"{hours}:{minutes}:{seconds}";
}}


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text;
using System.Text.RegularExpressions;

[TestFixture]
public class KataTest
{
    private Random random = new Random();

    public class Solution
    {
        public string HexToTime(string hex)
        {
            int hour = Convert.ToInt32(hex.Substring(1, 2), 16);
            int minute = Convert.ToInt32(hex.Substring(3, 2), 16);
            int second = Convert.ToInt32(hex.Substring(5, 2), 16);

            if (hour > 23 || minute > 59 || second > 59)
                throw new Exception("Thats not a valid time!");

            return $"{hour.ToString().PadLeft(2, '0')}:{minute.ToString().PadLeft(2, '0')}:{second.ToString().PadLeft(2, '0')}";
        }
    }

    [Test]
    public void _0_BasicTests()
    {
        var kata = new Kata();

        Assert.AreEqual("13:55:55", kata.HexToTime("#0d3737"));

        Assert.Throws<Exception>(() => kata.HexToTime("#2c3721"), "Thats not a valid time!");
    }

    [Test]
    public void _1_MoreTests()
    {
        var kata = new Kata();

        Assert.Throws<Exception>(() => kata.HexToTime("#180000"), "Thats not a valid time!");

        Assert.Throws<Exception>(() => kata.HexToTime("#183737"), "Thats not a valid time!"); // 24:55:55
        Assert.Throws<Exception>(() => kata.HexToTime("#0d373c"), "Thats not a valid time!"); // 13:55:60
        Assert.Throws<Exception>(() => kata.HexToTime("#0d3c37"), "Thats not a valid time!"); // 13:60:55
    }

    private string GetHex() => random.Next(0, 256).ToString("X").PadLeft(2, '0');

    [Test]
    public void _2_RandomTests()
    {
        var kata = new Kata();
        var solution = new Solution();

        for (int i = 0; i < 50; i++)
        {
            string hex = $"#{GetHex()}{GetHex()}{GetHex()}";

            string solutionResult = null, kataResult = null;
            bool pass = false;
            try
            {
                solutionResult = solution.HexToTime(hex);
                pass = true;
                kataResult = kata.HexToTime(hex);
                Assert.AreEqual(solutionResult, kataResult);
            }
            catch
            {
                if (pass)
                {
                    Assert.IsTrue(false, $"Expected {solutionResult} got {kataResult}");
                }
            }
        }
    }
}
