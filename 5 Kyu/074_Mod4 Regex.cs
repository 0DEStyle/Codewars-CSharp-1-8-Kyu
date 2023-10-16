/*Challenge link:https://www.codewars.com/kata/54746b7ab2bc2868a0000acf/train/csharp
Question:
NOTE: This kata requires a decent knowledge of Regular Expressions. As such, it's best to learn about it before tackling this kata. Some good places to start are: the MDN pages, and Regular-Expressions.info.

You are to write a Regular Expression that matches any string with at least one number divisible by 4 (with no remainder). In most languages, you could do this easily by using number % 4 == 0. How would you do it with Regex?

A number will start with [ and end with ]. They may (or may not) include a plus or minus symbol at the start; this should be taken into account. Leading zeros may be present, and should be ignored (no octals here ;P). There may be other text in the string, outside of the number; this should also be ignored. Also, all numbers will be integers; any floats should be ignored.

If there are no valid numbers defined as above, there should be no match made by your regex.

So here are some examples:

"[+05620]" // 5620 is divisible by 4 (valid)
"[+05621]" // 5621 is not divisible by 4 (invalid)
"[-55622]" // -55622 is not divisible by 4 (invalid)
"[005623]" // 5623 invalid
"[005624]" // 5624 valid
"[-05628]" // valid
"[005632]" // valid
"[555636]" // valid
"[+05640]" // valid
"[005600]" // valid
"the beginning [0] ... [invalid] numb[3]rs ... the end" // 0 is valid
"No, [2014] isn't a multiple of 4..."  // 2014 is invalid
"...may be [+002016] will be." // 2016 is valid
NOTE: Only Mod4.test(str) will be used, so your expression will just need make a match of some kind.
*/

//***************Solution********************

/* 
Regex explainer: https://regexr.com/
\\ escaped character for '\'
[[+-]? check for match [, +, - , match between 0 and 1 time

(\\d*[02468]) capture group 2
\\ escaped character for '\'
d* matches character 'd' 0 or more times
[02468]? check match 0, 2, 4, 6, 8, match between 0 and 1 time

end of capture group 2, back to capture group 1
then [048] check match 0,4,8
| or \\d*[13579][26],
\\ escaped character for '\'
d* matches character 'd' 0 or more times
[13579][26] check match set 1,3,5,7,9, and 2, 6
\\ escaped character for '\'


//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
*/
using System.Text.RegularExpressions;

public class Mod{
    public static Regex MOD4 = new Regex("\\[[+-]?((\\d*[02468])?[048]|\\d*[13579][26])\\]");
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
public class Mod4Test
{
    [Test, Order(1)]
    public void TestRealPattern()
    {
        Assert.IsTrue(typeof(Regex) == Mod.MOD4.GetType(), "Mod.MOD4 must be a standard C# Regex object");
    }

    [Test, Order(2)]
    public void TestValidMod4()
    {
        string[] validTests =
        {
            "[+05620]", "[005624]", "[-05628]", "[005632]", "[555636]", "[+05640]",
            "[005600]", "the beginning [-0] the end", "~[4]", "[32]",
            "the beginning [0] ... [invalid] numb[3]rs ... the end", "...may be [+002016] will be.", "~[4]", "[32]"
        };
        foreach (var test in validTests)
        {
            Assert.IsTrue(Mod.MOD4.IsMatch(test), test + " is valid, but no match was made.");
        }
    }

    [Test, Order(3)]
    public void TestInvalidMod4()
    {
        string[] invalidTests = { "[+05621]", "[-55622]", "[005623]", "[~24]", "[8.04]", "No, [2014] isn't a multiple of 4..." };
        foreach (var test in invalidTests)
        {
            Assert.IsFalse(Mod.MOD4.IsMatch(test), test + " is invalid, but a match was made.");
        }
    }

    private Random rnd = new Random();

    [Test, Order(4)]
    public void TestRandomInvalid()
    {
        for (int i = 0; i < 50;)
        {
            var num = rnd.Next(-100000, 100000);
            if (num % 4 != 0)
            {
                var test = $"{Guid.NewGuid()}[{num:D6}]{Guid.NewGuid()}";
                Assert.IsFalse(Mod.MOD4.IsMatch(test), test + " should not be found valid");
                i++;
            }
        }
    }

    [Test, Order(5)]
    public void TestRandomInput()
    {
        for (int i = 0; i < 100; i++)
        {
            var signR = rnd.NextDouble();
            var sign = signR > 0.6 ? "+" : signR > 0.3 ? "-" : "";
            var test = Guid.NewGuid().ToString() +
                           "[" + sign + (rnd.Next(1000) * 4) + "]" +
                           Guid.NewGuid().ToString() +
                           "[" + rnd.NextDouble() * 1000 + "]" +
                           Guid.NewGuid().ToString() +
                           "[~" + rnd.Next(1000) + "]";
            Assert.IsTrue(Mod.MOD4.IsMatch(test), test + " should be found valid");
        }

        for (int i = 0; i < 100; i++)
        {
            var signR = rnd.NextDouble();
            var sign = signR > 0.6 ? "+" : signR > 0.3 ? "-" : "";
            var test = Guid.NewGuid().ToString() +
                           "[" + rnd.NextDouble() * 1000 + "]" +
                           Guid.NewGuid().ToString() +
                           "[~" + rnd.Next(1000) + "]";
            Assert.IsFalse(Mod.MOD4.IsMatch(test), test + " should not be found valid");

            test = Guid.NewGuid().ToString() +
                   (rnd.Next(1000) * 4) +
                   " " +
                   rnd.Next(1000);
            Assert.IsFalse(Mod.MOD4.IsMatch(test), test + " should not be found valid");
        }
    }
}
