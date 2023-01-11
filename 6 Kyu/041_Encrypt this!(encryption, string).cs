/*Challenge link:https://www.codewars.com/kata/5848565e273af816fb000449/train/csharp
Question:
Acknowledgments:
I thank yvonne-liu for the idea and for the example tests :)

Description:
Encrypt this!

You want to create secret messages which can be deciphered by the Decipher this! kata. Here are the conditions:

Your message is a string containing space separated words.
You need to encrypt each word in the message using the following rules:
The first letter must be converted to its ASCII code.
The second letter must be switched with the last letter
Keepin' it simple: There are no special characters in the input.
Examples:
Kata.EncryptThis("Hello") == "72olle"
Kata.EncryptThis("good") == "103doo"
Kata.EncryptThis("hello world") == "104olle 119drlo"
*/

//***************Solution********************

using System.Collections.Generic;

namespace EncryptThis
{
    public class Kata{
        public static string EncryptThis(string input){
          var arr = input.Split(" "); //split string by space
          var strList = new List<string>();   //create a new list
          
          foreach (string item in arr){
            if (string.IsNullOrEmpty(item)) //if element is null return itself
              strList.Add(item);
            if (item.Length == 1)           //if element length is 1, encrypt first letter to ASCII
              strList.Add($"{item[0] - 0}");
            if (item.Length == 2)         //if element length is 2, encrypt first letter to ASCII and second letter stays the same
              strList.Add($"{item[0] - 0}{item.Substring(1, 1)}");
            if(item.Length > 2)           //if element length greater than 2, encrypt first letter to ASCII and swap second letter to last.
              strList.Add($"{item[0] - 0}{item.Substring(item.Length - 1)}{item.Substring(2, item.Length - 3)}{item.Substring(1, 1)}");
          }
          return string.Join(" ", strList);
        }
          
}
  }
  
  //solution 2
  //same as above
  //Then simiplfied into one line by using an Lambda expression with Enumerable methods.
  using System.Linq;
using static System.Text.RegularExpressions.Regex;

public class Kata
{
  public static string EncryptThis(string input)
  {
    return string.Join(" ", input.Split().Where(x => x != "").Select(x => $"{(int) x[0]}{Replace(x[1..], "(.)(.*)(.)", "$3$2$1")}"));
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

namespace EncryptThis
{
    public class TestSuite
    {
        [TestCase("", "")]
        [TestCase("A", "65")]
        [TestCase("Ab", "65b")]
        [TestCase("Abc", "65cb")]
        [TestCase("Abcd", "65dcb")]
        [TestCase("A wise old owl lived in an oak", "65 119esi 111dl 111lw 108dvei 105n 97n 111ka")]
        [TestCase("The more he saw the less he spoke", "84eh 109ero 104e 115wa 116eh 108sse 104e 115eokp")]
        [TestCase("The less he spoke the more he heard", "84eh 108sse 104e 115eokp 116eh 109ero 104e 104dare")]
        [TestCase("Why can we not all be like that wise old bird", "87yh 99na 119e 110to 97ll 98e 108eki 116tah 119esi 111dl 98dri")]
        [TestCase("Thank you Piotr for all your help", "84kanh 121uo 80roti 102ro 97ll 121ruo 104ple")]
        public void FixedTests(string input, string expected)
        {
            Assert.AreEqual(expected, Kata.EncryptThis(input));
        }

        [Test]
        public void RandomTests() {
            string randomInput;
            for (int i = 0; i < 100; i++)
            {
                randomInput = RandomInput();
                Assert.AreEqual(solution(randomInput), Kata.EncryptThis(randomInput));
            }
        }

        private static Random random = new Random();

        const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";

        private string RandomInput() {
            return String.Join(" ", Enumerable.Range(0, random.Next(0, 30)).Select(_ => RandomWord(random.Next(1, 10))));
        }

        private string RandomWord(int length) {
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray()); 
        }

        private string solution(string input) {
            return string.Join(" ", input.Split(' ').Select((word) => {
                switch (word.Length)
                {
                    case 0:
                        return "";
                    case 1:
                        return String.Format("{0:d}", (int) word[0]);
                    case 2:
                        return String.Format("{0:d}{1}", (int) word[0], word[1]);
                    case 3:
                        return String.Format("{0:d}{2}{1}", (int) word[0], word[1], word[2]);
                    default:
                        return String.Format("{0:d}{3}{2}{1}", (int) word[0], word[1], word.Substring(2, word.Length - 3), word[word.Length - 1]);
                };
            }));
        }
    }
}
