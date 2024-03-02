/*Challenge link:https://www.codewars.com/kata/570cbe88f616a8f4f50011ac/train/csharp
Question:
Bob is a theoretical coder - he doesn't write code, but comes up with theories, formulas and algorithm ideas. You are his secretary, and he has tasked you with writing the code for his newest project - a method for making the short form of a word. Write a function shortForm(C# ShortForm, Python short_form) that takes a string and returns it converted into short form using the rule: Remove all vowels, except for those that are the first or last letter. Do not count 'y' as a vowel, and ignore case. Also note, the string given will not have any spaces; only one word, and only Roman letters.
Example:

shortForm("assault");
short_form("assault")
ShortForm("assault");
// should return "asslt"


Also, FYI: I got all the words with no vowels from
https://en.wikipedia.org/wiki/English_words_without_vowels

STRINGSREGULAR EXPRESSIONSALGORITHMSFUNDAMENTALS
Solution
1
//pattern ignore case, word bound [aeuoi]  word bound, replace with nothing
2
namespace myjinxin{
3
    public class Kata{
4
      public string ShortForm(string s) => System.Text.RegularExpressions.Regex.Replace(s, @"(?i)\B[aeuoi]\B", "");
5
    }
6
}
 Great! You may take your time to refactor/comment your solution. Submit when ready.×
Sample Tests
1
namespace myjinxin
2
{
3
  using NUnit.Framework;
4
  using System;
5
    
6
  [TestFixture]
7
  public class myjinxin
8
  {
9
        
10
    [Test]
11
    public void TestCase(){
12
    var kata=new Kata();
13
    
14
    //Should return word without vowels
15
    Assert.AreEqual("typhd",kata.ShortForm("typhoid"));
16
    Assert.AreEqual("fre",kata.ShortForm("fire"));
17
    Assert.AreEqual("dstry",kata.ShortForm("destroy"));
18
    Assert.AreEqual("kta",kata.ShortForm("kata"));
19
    Assert.AreEqual("cdwrs",kata.ShortForm("codewars"));
20
​
21
    //Should ignore vowels at beginning or end of word
22
    Assert.AreEqual("assrt",kata.ShortForm("assert"));
23
    Assert.AreEqual("insne",kata.ShortForm("insane"));
24
    Assert.AreEqual("nce",kata.ShortForm("nice"));
25
    Assert.AreEqual("amzng",kata.ShortForm("amazing"));
26
    Assert.AreEqual("incrrgble",kata.ShortForm("incorrigible"));
27
​
28
    //Should be case-insenstive
29
    Assert.AreEqual("HllO",kata.ShortForm("HeEllO"));
30
    Assert.AreEqual("inCRdBLE",kata.ShortForm("inCRediBLE"));
31
    Assert.AreEqual("IMpsSblE",kata.ShortForm("IMpOsSiblE"));
32
    Assert.AreEqual("UnnTNtNl",kata.ShortForm("UnInTENtiONAl"));
33

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern ignore case, word bound [aeuoi]  word bound, replace with nothing
namespace myjinxin{
    public class Kata{
      public string ShortForm(string s) => System.Text.RegularExpressions.Regex.Replace(s, @"(?i)\B[aeuoi]\B", "");
    }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Text;
    using System.Linq;
    [TestFixture]
    public class myjinxin
    {
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public string an(string str) {
          return Regex.Replace(str,@"(?!^)[aeiouAEIOU](?!$)","");
        }
        public string Rndstr(int len){
          var s="ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
          var rs=new StringBuilder();
          for (int i=0;i<len;i++) rs.Append(s[rndnum.Next(0,51)]);
          return rs.ToString();
        }
        
        [Test]
        public void TestCase(){
            var kata=new Kata();
            var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            Console.WriteLine("<br><font size=4><b>-------- Basic Test --------</b></font>");
            
    Console.WriteLine("<br><font size=2><b>Should return word without vowels</b></font>");
    Assert.AreEqual("typhd",kata.ShortForm("typhoid"));
    Console.WriteLine(passed);
    Assert.AreEqual("fre",kata.ShortForm("fire"));
    Console.WriteLine(passed);
    Assert.AreEqual("dstry",kata.ShortForm("destroy"));
    Console.WriteLine(passed);
    Assert.AreEqual("kta",kata.ShortForm("kata"));
    Console.WriteLine(passed);
    Assert.AreEqual("cdwrs",kata.ShortForm("codewars"));
    Console.WriteLine(passed);

    Console.WriteLine("<br><font size=2><b>Should ignore vowels at beginning or end of word</b></font>");
    Assert.AreEqual("assrt",kata.ShortForm("assert"));
    Console.WriteLine(passed);
    Assert.AreEqual("insne",kata.ShortForm("insane"));
    Console.WriteLine(passed);
    Assert.AreEqual("nce",kata.ShortForm("nice"));
    Console.WriteLine(passed);
    Assert.AreEqual("amzng",kata.ShortForm("amazing"));
    Console.WriteLine(passed);
    Assert.AreEqual("incrrgble",kata.ShortForm("incorrigible"));
    Console.WriteLine(passed);

    Console.WriteLine("<br><font size=2><b>Should be case-insenstive</b></font>");
    Assert.AreEqual("HllO",kata.ShortForm("HeEllO"));
    Console.WriteLine(passed);
    Assert.AreEqual("inCRdBLE",kata.ShortForm("inCRediBLE"));
    Console.WriteLine(passed);
    Assert.AreEqual("IMpsSblE",kata.ShortForm("IMpOsSiblE"));
    Console.WriteLine(passed);
    Assert.AreEqual("UnnTNtNl",kata.ShortForm("UnInTENtiONAl"));
    Console.WriteLine(passed);
    Assert.AreEqual("AWSme",kata.ShortForm("AWESOme"));
    Console.WriteLine(passed);

    Console.WriteLine("<br><font size=2><b>Should support input with no vowels</b></font>");
    Assert.AreEqual("rhythm",kata.ShortForm("rhythm"));
    Console.WriteLine(passed);
    Assert.AreEqual("hymn",kata.ShortForm("hymn"));
    Console.WriteLine(passed);
    Assert.AreEqual("lynx",kata.ShortForm("lynx"));
    Console.WriteLine(passed);
    Assert.AreEqual("nymph",kata.ShortForm("nymph"));
    Console.WriteLine(passed);
    Assert.AreEqual("pygmy",kata.ShortForm("pygmy"));
    Console.WriteLine(passed);
    
    
            Console.WriteLine("<br><font size=4><b>-------- Random Test --------</b></font>");
            Console.WriteLine("<br><font size=2><b>should work for random string</b></font>");
            Console.WriteLine("");
            for (int i=0;i<100;i++){
              int nn=rndnum.Next(5,20);
              var ss=Rndstr(nn);
              var ans=an(ss);
              Console.WriteLine("<font size=2 color='#CFB53B'><b>TestCase: str=\""+ss+"\"</b></font>");
              Assert.AreEqual(ans, kata.ShortForm(ss));
              Console.WriteLine("<font size=2 color='#8FBC8F'><b>Test Passed! Passed Value=\""+ans+"\"</b></font>");
            }
            

        }        
    }
}	
