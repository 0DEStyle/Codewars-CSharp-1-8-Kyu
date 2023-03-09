/*Challenge link:https://www.codewars.com/kata/58dbdccee5ee8fa2f9000058/train/csharp
Question:
Given a string of arbitrary length with any ascii characters. Write a function to determine whether the string contains the whole word "English".

The order of characters is important -- a string "abcEnglishdef" is correct but "abcnEglishsef" is not correct.

Upper or lower case letter does not matter -- "eNglisH" is also correct.

Return value as boolean values, true for the string to contains "English", false for it does not.
*/

//***************Solution********************
//check if string sentence contains the word "english", case insensitive
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
namespace Solution{
    static class Kata{
        public static bool SpeakEnglish(string sentence)=> Regex.IsMatch(sentence, "(?i)english");
    }
}

//solution 2
namespace Solution
{
    static class Kata
    {
        public static bool SpeakEnglish(string sentence)
        {
            return sentence.ToLower().Contains("english");
        }
    }
}

//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;
    using System.Text;
  
    [TestFixture]
    public class SolutionTests
    {
        [TestCase("hello world", false)]
        [TestCase("egnlish", false)]
        [TestCase("", false)]
        [TestCase("english", true)]
        [TestCase("1234english ;k", true)]
        [TestCase("I speak English", true)]
        [TestCase("ABC123DOREME", false)]
        [TestCase("eNgliSh", true)]
        [TestCase("1234#$%%eNglish ;k9", true)]
        [TestCase("spanish, english, french", true)]
        [TestCase("englishENGLISHEnGlISHENglisH", true)]
        [TestCase("HeLlO tHeR3 enGLiSh MuffIN", true)]
        public void FixedTests(string str, bool expected)
        {
            var actual = Kata.SpeakEnglish(str);
            Assert.AreEqual(expected, actual, $"Input: \"{str}\"");
        }
      
        private static readonly Random rnd = new Random();
        private const string word = "english";
        private const string asciiChars = " !\"#$%&\'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~";
        
        [Test]
        public void RandomTests()
        {
            var randomStrings = GenRandomStrings(500);
            foreach(var str in randomStrings)
            {
                var expected = str.ToLower().Contains(word);
                var actual = Kata.SpeakEnglish(str);
                Assert.AreEqual(expected, actual, $"Input: \"{str}\"");
            }
        }
  
        private string[] GenRandomStrings(int numOfStrings)
        {
            var strings = new string[numOfStrings];
            for (var i = 0; i < numOfStrings; i++)
            {
                strings[i] = GenerateString();
            }
            return strings;
        }
  
        private string GenerateString()
        {
            var stringLength = rnd.Next(0, 100);
            var shouldContainWord = rnd.Next(0, 2) == 0;
            var sb = new StringBuilder();
            for (var i = 0; i < stringLength; i++)
            {
                sb.Append(asciiChars[rnd.Next(asciiChars.Length)]);
            }
            if (shouldContainWord)
            {
                var index = rnd.Next(stringLength);
                sb.Insert(index, RandomizeCasing(word));
            }
            return sb.ToString();
        }
  
        private string RandomizeCasing(string word)
        {
            var sb = new StringBuilder();
            foreach (var c in word)
            {
                if (rnd.Next(0, 2) == 0)
                    sb.Append(Char.ToUpper(c));
                else
                    sb.Append(Char.ToLower(c));
            }
            return sb.ToString();
        }
    }
}
