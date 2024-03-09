/*Challenge link:https://www.codewars.com/kata/5906a218dfeb0dbb52000005/train/csharp
Question:
Maya writes weekly articles to a well known magazine, but she is missing one word each time she is about to send the article to the editor. The article is not complete without this word. Maya has a friend, Dan, and he is very good with words, but he doesn't like to just give them away. He texts Maya a number and she needs to find out the hidden word. The words can contain only the letter:

"a", "b", "d", "e", "i", "l", "m", "n", "o", and "t".
Luckily, Maya has the key:

"a" : 6
"b" : 1 
"d" : 7
"e" : 4
"i" : 3
"l" : 2
"m" : 9
"n" : 8
"o" : 0
"t" : 5
You can help Maya by writing a function that will take a number between 100 and 999999 and return a string with the word.

The input is always a number, contains only the numbers in the key. The output should be always a string with one word, all lowercase.

Maya won't forget to thank you at the end of her article :)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//sort the hidden letter => "oblietadnm"
//convert num to string, x is the curretne element, from "oblietadnm", 
//convert x to string then parse to int so that we get the index
//convert to array and make a new string.
using System.Linq;

namespace CodeWars{
    public class Kata{
        public string hidden(int num) => 
          new string(num.ToString()
                        .Select(x => "oblietadnm"[int.Parse(x.ToString())])
                        .ToArray());
    }
}

//method 2
using System.Linq;

public class Kata
{
  public string hidden(int num)
  {
    return string.Concat($"{num}".Select(c => "oblietadnm"[c - '0']));
  }
}
//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        [TestCase]
        public void ExtraTest1()
        {
            Kata kata = new Kata();
            Assert.AreEqual("aid", kata.hidden(637));
        }

        [TestCase]
        public void ExtraTest2()
        {
            Kata kata = new Kata();
            Assert.AreEqual("dean", kata.hidden(7468));
        }

        [TestCase]
        public void ExtraTest3()
        {
            Kata kata = new Kata();
            Assert.AreEqual("email", kata.hidden(49632));
        }

        [TestCase]
        public void ExtraTest4()
        {
            Kata kata = new Kata();
            Assert.AreEqual("belt", kata.hidden(1425));
        }

        [TestCase]
        public void ExtraTest5()
        {
            Kata kata = new Kata();
            Assert.AreEqual("alto", kata.hidden(6250));
        }

        [TestCase]
        public void ExtraTest6()
        {
            Kata kata = new Kata();
            Assert.AreEqual("blade", kata.hidden(12674));
        }

        [TestCase]
        public void ExtraTest7()
        {
            Kata kata = new Kata();
            Assert.AreEqual("edit", kata.hidden(4735));
        }

        [TestCase]
        public void ExtraTest8()
        {
            Kata kata = new Kata();
            Assert.AreEqual("diet", kata.hidden(7345));
        }

        [TestCase]
        public void ExtraTest9()
        {
            Kata kata = new Kata();
            Assert.AreEqual("into", kata.hidden(3850));
        }

        [TestCase]
        public void ExtraTest10()
        {
            Kata kata = new Kata();
            Assert.AreEqual("lime", kata.hidden(2394));
        }

        [TestCase]
        public void ExtraTest11()
        {
            Kata kata = new Kata();
            Assert.AreEqual("loan", kata.hidden(2068));
        }

        [TestCase]
        public void ExtraTest12()
        {
            Kata kata = new Kata();
            Assert.AreEqual("bid", kata.hidden(137));
        }

        [TestCase]
        public void ExtraTest13()
        {
            Kata kata = new Kata();
            Assert.AreEqual("boat", kata.hidden(1065));
        }

        [TestCase]
        public void ExtraTest14()
        {
            Kata kata = new Kata();
            Assert.AreEqual("atom", kata.hidden(6509));
        }

        [TestCase]
        public void ExtraTest15()
        {
            Kata kata = new Kata();
            Assert.AreEqual("item", kata.hidden(3549));
        }

        [TestCase]
        public void ExtraTest16()
        {
            Kata kata = new Kata();
            Assert.AreEqual("time", kata.hidden(5394));
        }

        [TestCase]
        public void ExtraTest17()
        {
            Kata kata = new Kata();
            Assert.AreEqual("table", kata.hidden(56124));
        }

        [TestCase]
        public void ExtraTest18()
        {
            Kata kata = new Kata();
            Assert.AreEqual("man", kata.hidden(968));
        }

        [TestCase]
        public void ExtraTest19()
        {
            Kata kata = new Kata();
            Assert.AreEqual("boiled", kata.hidden(103247));
        }

        [TestCase]
        public void ExtraTest20()
        {
            Kata kata = new Kata();
            Assert.AreEqual("admit", kata.hidden(67935));
        }

        [TestCase]
        public void ExtraTest21()
        {
            Kata kata = new Kata();
            Assert.AreEqual("debt", kata.hidden(7415));
        }

        [TestCase]
        public void ExtraTest22()
        {
            Kata kata = new Kata();
            Assert.AreEqual("land", kata.hidden(2687));
        }

        [TestCase]
        public void ExtraTest23()
        {
            Kata kata = new Kata();
            Assert.AreEqual("lab", kata.hidden(261));
        }

        [TestCase]
        public void ExtraTest24()
        {
            Kata kata = new Kata();
            Assert.AreEqual("note", kata.hidden(8054));
        }

        [TestCase]
        public void ExtraTest25()
        {
            Kata kata = new Kata();
            Assert.AreEqual("melted", kata.hidden(942547));
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTests()
        {
            Kata kata = new Kata();
            KataSolve kataSolve = new KataSolve();
            Random ran = new Random();
            int num = ran.Next(0, 999899)+100;
            string result = kataSolve.hidden(num);
            Assert.AreEqual(result, kata.hidden(num));
        }
    }
}
