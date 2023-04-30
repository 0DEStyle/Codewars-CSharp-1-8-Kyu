/*Challenge link:https://www.codewars.com/kata/56a4addbfd4a55694100001f/train/csharp
Question:
You received a whatsup message from an unknown number. Could it be from that girl/boy with a foreign accent you met yesterday evening?

Write a simple function to check if the string contains the word hallo in different languages.

These are the languages of the possible people you met the night before:

hello - english
ciao - italian
salut - french
hallo - german
hola - spanish
ahoj - czech republic
czesc - polish
Notes

you can assume the input is a string.
to keep this a beginner exercise you don't need to check if the greeting is a subset of word (Hallowen can pass the test)
function should be case insensitive to pass the tests

*/

//***************Solution********************
//preset strings
//convert greetins to lowercase, and check if it matches the preset string.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
        public static bool Validate_hello(string greetings)=>
          new[] { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "czesc" }.
                Any(x => greetings.ToLower().Contains(x));
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
        public void Test1()
        {
            Assert.IsTrue(Kata.Validate_hello("hello"));
            Assert.IsTrue(Kata.Validate_hello("ciao bella!"));
            Assert.IsTrue(Kata.Validate_hello("salut"));
            Assert.IsTrue(Kata.Validate_hello("hallo, salut"));
            Assert.IsTrue(Kata.Validate_hello("hombre! Hola!"));
            Assert.IsTrue(Kata.Validate_hello("Hallo, wie geht\'s dir?"));
            Assert.IsTrue(Kata.Validate_hello("AHOJ!"));
            Assert.IsTrue(Kata.Validate_hello("czesc"));
            Assert.IsTrue(Kata.Validate_hello("Ahoj"));
            Assert.IsFalse(Kata.Validate_hello("meh"));
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 10)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            string text = rg.stringName();
            Assert.AreEqual(Kata12Feb.Validate_hello(text),Kata.Validate_hello(text));
        }
    }
