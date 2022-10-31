
/*Challenge link:https://www.codewars.com/kata/577ff15ad648a14b780000e7/train/csharp
Question:
Your start-up's BA has told marketing that your website has a large audience in Scandinavia and surrounding countries. Marketing thinks it would be great to welcome visitors to the site in their own language. Luckily you already use an API that detects the user's location, so this is an easy win.

The Task
Think of a way to store the languages as a database (eg an object). The languages are listed below so you can copy and paste!
Write a 'welcome' function that takes a parameter 'language' (always a string), and returns a greeting - if you have it in your database. It should default to English if the language is not in the database, or in the event of an invalid input.
The Database
{"english", "Welcome"},
{"czech", "Vitejte"},
{"danish", "Velkomst"},
{"dutch", "Welkom"},
{"estonian", "Tere tulemast"},
{"finnish", "Tervetuloa"},
{"flemish", "Welgekomen"},
{"french", "Bienvenue"},
{"german", "Willkommen"},
{"irish", "Failte"},
{"italian", "Benvenuto"},
{"latvian", "Gaidits"},
{"lithuanian", "Laukiamas"},
{"polish", "Witamy"},
{"spanish", "Bienvenido"},
{"swedish", "Valkommen"},
{"welsh", "Croeso"}
Possible invalid inputs include:

IP_ADDRESS_INVALID - not a valid ipv4 or ipv6 ip address
IP_ADDRESS_NOT_FOUND - ip address not in the database
IP_ADDRESS_REQUIRED - no ip address was supplied
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//create a dictionary, store all the keys and values,
//check if dictionary contains the key value "language", if yes return the corresponding language, else return english.
using System.Collections.Generic;
public static class Kata
    {
        public static string Greet(string language)
        {
            IDictionary<string, string> weight = new Dictionary<string, string>();
          var myDictionary = new Dictionary<string, string>(){
{"english", "Welcome"},
{"czech", "Vitejte"},
{"danish", "Velkomst"},
{"dutch", "Welkom"},
{"estonian", "Tere tulemast"},
{"finnish", "Tervetuloa"},
{"flemish", "Welgekomen"},
{"french", "Bienvenue"},
{"german", "Willkommen"},
{"irish", "Failte"},
{"italian", "Benvenuto"},
{"latvian", "Gaidits"},
{"lithuanian", "Laukiamas"},
{"polish", "Witamy"},
{"spanish", "Bienvenido"},
{"swedish", "Valkommen"},
{"welsh", "Croeso"}
};
          
          return myDictionary.ContainsKey(language) ? myDictionary[language] : myDictionary["english"];
        }
    }

//****************Sample Test*****************
using NUnit.Framework;
using System.Collections.Generic;
using System;

    [TestFixture]
    public class KataTest
    {
        [Test]
        public void BasicTest()
        {
            Assert.AreEqual("Welcome",Kata.Greet("english"));
            Assert.AreEqual("Welkom", Kata.Greet("dutch"));
            Assert.AreEqual("Welcome", Kata.Greet("IP_ADDRESS_INVALID"));
            Assert.AreEqual("Welcome", Kata.Greet("")); 
            Assert.AreEqual("Welcome", Kata.Greet("2"));
        }

        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            string input = rg.RandomString();
            Dictionary<string, string> baseDic = new Dictionary<string, string>
            {
                {"english", "Welcome"},
                {"czech", "Vitejte"},
                {"danish", "Velkomst"},
                {"dutch", "Welkom"},
                {"estonian", "Tere tulemast"},
                {"finnish", "Tervetuloa"},
                {"flemish", "Welgekomen"},
                {"french", "Bienvenue"},
                {"german", "Willkommen"},
                {"irish", "Failte"},
                {"italian", "Benvenuto"},
                {"latvian", "Gaidits"},
                {"lithuanian", "Laukiamas"},
                {"polish", "Witamy"},
                {"spanish", "Bienvenido"},
                {"swedish", "Valkommen"},
                {"welsh", "Croeso"}
            };
            string output = baseDic.ContainsKey(input) ? baseDic[input] : "Welcome";
            Assert.AreEqual(output, Kata.Greet(input));
        }
    }

    public class RgTest
    {
        static Random _random;
        private static int _counter;

        private readonly List<string> _stringList = new List<string>()
        {
            "english",
            "czech",
            "IP_ADDRESS_INVALID",
            "danish",
            "IP_ADDRESS_NOT_FOUND",
            "dutch",
            "estonian",
            "IP_ADDRESS_NOT_FOUND",
            "finnish",
            "flemish",
            "french",
            "german",
            "irish",
            "italian",
            "IP_ADDRESS_REQUIRED",
            "latvian",
            "IP_ADDRESS_REQUIRED",
            "lithuanian",
            "polish",
            "IP_ADDRESS_NOT_FOUND",
            "spanish",
            "swedish",
            "IP_ADDRESS_NOT_FOUND",
            "welsh",
            "IP_ADDRESS_NOT_FOUND",
            "IP_ADDRESS_INVALID"
        };
        public RgTest(int seed)
        {
            _counter = _counter + 1;
            _random = new Random(seed + _counter);
        }

        public string RandomString()
        {
            return _stringList[_random.Next(0, _stringList.Count)];
        }
    }
