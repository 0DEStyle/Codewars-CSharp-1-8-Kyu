/*Challenge link:https://www.codewars.com/kata/578c1e2edaa01a9a02000b7f/train/csharp
Question:
Every budding hacker needs an alias! The Phantom Phreak, Acid Burn, Zero Cool and Crash Override are some notable examples from the film Hackers.

Your task is to create a function that, given a proper first and last name, will return the correct alias.

Notes:
Two objects that return a one word name in response to the first letter of the first name and one for the first letter of the surname are already given. See the examples below for further details.

If the first character of either of the names given to the function is not a letter from A - Z, you should return "Your name must start with a letter from A - Z."

Sometimes people might forget to capitalize the first letter of their name so your function should accommodate for these grammatical errors.

Examples
FirstName = {{"A", "Alpha"}, {"B", "Beta"}, {"C", "Cache"}, ...}
Surname = {{"A", "Analogue"}, {"B", "Bomb"}, {"C", "Catalyst"} ...}

// These dictionaries are defined on other partial Kata class

AliasGen('Larry', 'Brentwood') == 'Logic Bomb'
AliasGen('123abc', 'Petrovic') == 'Your name must start with a letter from A - Z.'
Happy hacking!
*/

//***************Solution********************
//check whether the first letter of first and last is a letter using Regex,
//if true, access FirstName and Surname Objecs ------ usage FirstName["A"] is "Alpha"
//so convert the first letter of first to string, then access the the corresponding dictionary in the object FirstName
//do the same with Surename.
//use string interpolation to format the string.

//if false, return "Your name must start with a letter from A - Z."

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Text.RegularExpressions;
public partial class Kata{
  public static string AliasGen(string first, string last) => Regex.IsMatch($"{first[0]}{last[0]}", @"^[a-zA-Z]+$") ?
    $"{FirstName[first[0].ToString()]} {Surname[last[0].ToString()]}" : "Your name must start with a letter from A - Z.";
}

//better solution
public partial class Kata
{
  public static string AliasGen(string fName, string lName)
  {
    return char.IsLetter(fName[0]) && char.IsLetter(lName[0])
        ? $"{FirstName[fName[0].ToString()]} {Surname[lName[0].ToString()]}"
        : "Your name must start with a letter from A - Z.";
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

    [TestFixture]
    public class Test
    {
        [Test]
        public void BasicTest()
        {
            Dictionary<string[], string> bisics = new Dictionary<string[], string>()
            {
                {new []{"Mike", "Millington"},  "Malware Mike"},
                {new []{"Fahima", "Tash"},"Function T-Rex"},
                {new []{"Daisy", "Petrovic"},"Data Payload"},
                {new []{"Barny", "White"},"Beta Worm"},
                {new []{"Hank", "Kutz"},"Half-life Killer"},
                {new []{"123abc", "Pinkman"},"Your name must start with a letter from A - Z."}
            };
            foreach (KeyValuePair<string[], string> keyValuePair in bisics)
            {
                StringAssert.AreEqualIgnoringCase(keyValuePair.Value,Kata.AliasGen(keyValuePair.Key[0],keyValuePair.Key[1]));
            }
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            string firstname = rg.Firstname();
            string lastname = rg.Lastname();
            string output = "";
            try
            {
                output = Kata.FirstName[firstname[0].ToString()] + " " + Kata.Surname[lastname[0].ToString()];
            }
            catch (Exception)
            {
                output = "Your name must start with a letter from A - Z.";
            }
            StringAssert.AreEqualIgnoringCase(output, Kata.AliasGen(firstname, lastname));
        }
    }

    public class RgTest
    {
        static Random _random;
        private static int _counter;
        public RgTest(int seed)
        {
            _counter = _counter + 1;
            _random = new Random(seed + _counter);
        }

        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        public string Firstname()
        {
            int length = _random.Next(4, 10);
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public string Lastname()
        {
            int length = _random.Next(4, 10);
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[_random.Next(s.Length)]).ToArray());
        }
    }
