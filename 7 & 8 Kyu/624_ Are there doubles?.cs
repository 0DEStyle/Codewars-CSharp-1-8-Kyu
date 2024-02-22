/*Challenge link:https://www.codewars.com/kata/56a24b4d9f3671584d000039/train/csharp
Question:
Your job is to build a function which determines whether or not there are double characters in a string (including whitespace characters). For example aa, !! or   .

You want the function to return true if the string contains double characters and false if not. The test should not be case sensitive; for example both aa & aA return true.

Examples:

  double_check("abca")
  #returns False
  
  double_check("aabc")
  #returns True
  
  double_check("a 11 c d")
  #returns True
  
  double_check("AabBcC")
  #returns True
  
  double_check("a b  c")
  #returns True
  
  double_check("a b c d e f g h i h k")
  #returns False
  
  double_check("2020")
  #returns False
  
  double_check("a!@€£#$%^&*()_-+=}]{[|\"':;?/>.<,~")
  #returns False
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//check pattern
//(?i) ignore case, group,(.)group 1, match any character except breakline, match result of group 1

public class Kata{
    public static bool Double_check(string s) =>
      System.Text.RegularExpressions.Regex.IsMatch(s, @"(?i)(.)\1");
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

    [TestFixture]
    public class Test
    {
        [Test]
        public void Test1()
        {
            Assert.AreEqual(false, Kata.Double_check("abca"));
            Assert.AreEqual(true, Kata.Double_check("aabc"));
            Assert.AreEqual(true, Kata.Double_check("a 11 c d"));
            Assert.AreEqual(true, Kata.Double_check("AabBcC"));
            Assert.AreEqual(true, Kata.Double_check("a b  c"));
            Assert.AreEqual(false, Kata.Double_check("a b c d e f g h i h k"));
            Assert.AreEqual(false, Kata.Double_check("2020"));
            Assert.AreEqual(false, Kata.Double_check("a!@€£#$%^&*()_-+=}]{[|\':;?/>.<,~"));
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 10)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            string mystring = rg.MyString();
            Assert.AreEqual(Kata13Feb.Double_check(mystring), Kata.Double_check(mystring));
        }
    }
