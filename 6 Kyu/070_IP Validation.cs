/*Challenge link:https://www.codewars.com/kata/515decfd9dcfc23bb6000006/train/csharp
Question:
Write an algorithm that will identify valid IPv4 addresses in dot-decimal format. IPs should be considered valid if they consist of four octets, with values between 0 and 255, inclusive.

Valid inputs examples:
Examples of valid inputs:
1.2.3.4
123.45.67.89
Invalid input examples:
1.2.3
1.2.3.4.5
123.456.78.90
123.045.067.089
Notes:
Leading zeros (e.g. 01.02.03.04) are considered invalid
Inputs are guaranteed to be a single string

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;
namespace Solution{
    class Kata{
      //^ begin $ end
      //\d check if character is a single digit
      //or [1-9]/d between 1 to 9, meaning no 0, because 01 is considered invalid, then follow by 1 extra digit
      //2([0-4]\d|25[0-5])  2 follow by 
      //digit between 0 to 4 follow by a digit, meaning 200-249 or!!!   
      //\b word boundary, capture group \d 1 to 9, 
      // {4} quantifier 4 times
        public static bool IsValidIp(string ipAddres) => 
          Regex.IsMatch(ipAddres, @"^(\b(\d|[1-9]\d|1\d{2}|2[0-4]\d|25[0-5])\b(\.|$)){4}$");
    }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void TestCases()
        {
            Assert.AreEqual(true, Kata.IsValidIp("0.0.0.0"));
            Assert.AreEqual(true, Kata.IsValidIp("12.255.56.1"));
            Assert.AreEqual(true, Kata.IsValidIp("137.255.156.100"));

            Assert.AreEqual(false, Kata.IsValidIp(""));
            Assert.AreEqual(false, Kata.IsValidIp("abc.def.ghi.jkl"));
            Assert.AreEqual(false, Kata.IsValidIp("123.456.789.0"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.00"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.7.8"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.256.78"));
            Assert.AreEqual(false, Kata.IsValidIp("1234.34.56"));
            Assert.AreEqual(false, Kata.IsValidIp("pr12.34.56.78"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.78sf"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56 .1"));
            Assert.AreEqual(false, Kata.IsValidIp("12.34.56.-1"));
            Assert.AreEqual(false, Kata.IsValidIp("123.045.067.089"));
        }

        [Test]
        public void RandomTests()
        {
            string letters = "abcdefghijklm";
            Random rnd = new Random();

            for (int test = 0; test < 300; ++test) {

                List<string> parts = new List<string>();
                for (int i = 0; i < 4; ++i)
                    parts.Add(rnd.Next(256).ToString());

                int pos = rnd.Next(4);
                string someLetters = letters.Substring(rnd.Next(4), rnd.Next(2) + 1);
                bool valid = false;
                int route = rnd.Next(12);
                switch (route)
                {
                    case 0: valid = true; break;
                    case 1: parts[pos] = ""; break;
                    case 2: parts[pos] = someLetters; break;
                    case 3: parts[pos] = rnd.Next(256, 300).ToString(); break;
                    case 4: parts.RemoveAt(pos); break;
                    case 5: parts.Add(rnd.Next(256).ToString()); break;
                    case 6: parts[0] += someLetters; break;
                    case 7: parts[3] += someLetters; break;
                    case 8: parts[rnd.Next(1, 3)] += " "; break;
                    case 9: parts[pos] = "-" + parts[pos]; break;
                    case 10: parts[pos] = "0" + rnd.Next(0, 100); break;
                    case 11: parts[pos] = "00"; break;
                }

                string ip = string.Join(".", parts);
                Assert.AreEqual(valid, Kata.IsValidIp(ip), "IP address: {0}", ip);
            }
        }
    }
}
