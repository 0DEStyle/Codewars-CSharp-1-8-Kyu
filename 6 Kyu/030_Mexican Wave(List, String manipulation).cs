/*Challenge link:https://www.codewars.com/kata/58f5c63f1e26ecda7e000029/train/csharp
Question:
Introduction
The wave (known as the Mexican wave in the English-speaking world outside North America) is an example of metachronal rhythm achieved in a packed stadium when successive groups of spectators briefly stand, yell, and raise their arms. Immediately upon stretching to full height, the spectator returns to the usual seated position.

The result is a wave of standing spectators that travels through the crowd, even though individual spectators never move away from their seats. In many large arenas the crowd is seated in a contiguous circuit all the way around the sport field, and so the wave is able to travel continuously around the arena; in discontiguous seating arrangements, the wave can instead reflect back and forth through the crowd. When the gap in seating is narrow, the wave can sometimes pass through it. Usually only one wave crest will be present at any given time in an arena, although simultaneous, counter-rotating waves have been produced. (Source Wikipedia)
Task
In this simple Kata your task is to create a function that turns a string into a Mexican Wave. You will be passed a string and you must return that string in an array where an uppercase letter is a person standing up. 
Rules
 1.  The input string will always be lower case but maybe empty.

 2.  If the character in the string is whitespace then pass over it as if it was an empty seat
Example
wave("hello") => {"Hello", "hEllo", "heLlo", "helLo", "hellO"}
Good luck and enjoy!
*/

//***************Solution********************
//if character at index is letter
//remove the character at index, replace the character at index with  upper case.
//add to list.
//return result.
//solution 1
using System.Collections.Generic;

namespace CodeWars{
    public class Kata{
        public List<string> wave(string str){
          List<string> list = new List<string>();
          for(int i = 0; i < str.Length; i++)
            if(char.IsLetter(str[i])) list.Add(str.Remove(i,1).Insert(i, str[i].ToString().ToUpper()));
          
          return list;
        }
    }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        public List<string> wave(string str) => 
          str
            .Select((c,i) => str.Substring(0,i) + Char.ToUpper(c) + str.Substring(i+1))
            .Where(x => x != str)
            .ToList();
    }
}

//solution 3
using System.Collections.Generic;
using System.Linq;

namespace CodeWars
{
    public class Kata
    {
        public List<string> wave(string str)
        {
            return str.Select((x,i)=>str.Substring(0,i)+char.ToUpper(str[i])+str.Substring(i+1)).Where(x=>x.Any(char.IsUpper)).ToList(); 
        }
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
        private Random ran = new Random();
        private string letters = "abcd efghi jklmno pqrstu vwxyz";

        [TestCase]
        public void BasicTest1()
        {
            Console.WriteLine("Testing for 'a       b    '");
            Kata kata = new Kata();
            List<string> result = new List<string> { "A       b    ", "a       B    " };
            Assert.AreEqual(result, kata.wave("a       b    "), "it should return '"+result+"'");
        }

        [TestCase]
        public void BasicTest2()
        {
            Console.WriteLine("Testing for 'this is a few words'");
            Kata kata = new Kata();
            List<string> result = new List<string> { "This is a few words", "tHis is a few words", "thIs is a few words", "thiS is a few words", "this Is a few words", "this iS a few words", "this is A few words", "this is a Few words", "this is a fEw words", "this is a feW words", "this is a few Words", "this is a few wOrds", "this is a few woRds", "this is a few worDs", "this is a few wordS" };
            Assert.AreEqual(result, kata.wave("this is a few words"), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest3()
        {
            Console.WriteLine("Testing for ''");
            Kata kata = new Kata();
            List<string> result = new List<string> { };
            Assert.AreEqual(result, kata.wave(""), "it should return '" + result + "'");
        }

        [TestCase]
        public void BasicTest4()
        {
            Console.WriteLine("Testing for ' gap '");
            Kata kata = new Kata();
            List<string> result = new List<string> { " Gap ", " gAp ", " gaP " };
            Assert.AreEqual(result, kata.wave(" gap "), "it should return '" + result + "'");
        }

        private List<string> wave2(string str)
        {
            List<string> result = new List<string> { };
            char[] str2 = str.ToCharArray();
            for (int b = 0; b < str2.Length; b++)
            {
                if (str2[b] != ' ')
                {
                    List<char> temp = new List<char> { };
                    for (int i = 0; i < str2.Length; i++)
                    {
                        if (i == b) { temp.Add(Char.ToUpper(str2[i])); } else { temp.Add(str2[i]); }
                    }
                    result.Add(string.Join("", temp));
                }
            }
            return result;
        }

        private string GetWord()
        {
            string res = "";
            for (int lett=0; lett< ran.Next(0, 200); lett++)
            {
                res += letters[ran.Next(0, letters.Length - 1)];
            }
            return res;
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
        public void RandomTest()
        {
            string word = GetWord();
            Console.WriteLine("Testing for '"+word+"'");
            Kata kata = new Kata();
            List<string> result = wave2(word);
            Assert.AreEqual(result, kata.wave(word), "it should return '" + result + "'");
        }
    }
}
