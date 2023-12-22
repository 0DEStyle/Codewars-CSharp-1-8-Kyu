/*Challenge link:https://www.codewars.com/kata/56f6919a6b88de18ff000b36/train/csharp
Question:
Your friend has been out shopping for puppies (what a time to be alive!)... He arrives back with multiple dogs, and you simply do not know how to respond!

By repairing the function provided, you will find out exactly how you should respond, depending on the number of dogs he has.

The number of dogs will always be a number and there will always be at least 1 dog.

Good luck!
*/

//***************Solution********************

//using tenary operator and return result accordingly
using System.Collections.Generic;

public static class Kata{
  public static string HowManyDalmatians(int n){
            List<string> dogs = new List<string>(){
                "Hardly any",
                "More than a handful!",
                "Woah that's a lot of dogs!",
                "101 DALMATIONS!!!"
            };
            return n <= 10 ? dogs[0] : n <= 50 ? dogs[1] : n == 101 ? dogs[3] : dogs[2];
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
            StringAssert.AreEqualIgnoringCase("More than a handful!",Kata.HowManyDalmatians(26));
            StringAssert.AreEqualIgnoringCase("Hardly any",Kata.HowManyDalmatians(8));
            StringAssert.AreEqualIgnoringCase("More than a handful!",Kata.HowManyDalmatians(14));
            StringAssert.AreEqualIgnoringCase("Woah that's a lot of dogs!",Kata.HowManyDalmatians(80));
            StringAssert.AreEqualIgnoringCase("Woah that's a lot of dogs!",Kata.HowManyDalmatians(100));
            StringAssert.AreEqualIgnoringCase("More than a handful!",Kata.HowManyDalmatians(50));
            StringAssert.AreEqualIgnoringCase("Hardly any",Kata.HowManyDalmatians(10));
            StringAssert.AreEqualIgnoringCase("101 DALMATIONS!!!",Kata.HowManyDalmatians(101));
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 40)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            int number = rg.Number();
            List<string> dogsList = new List<string>()
            {
                "Hardly any",
                "More than a handful!",
                "Woah that's a lot of dogs!",
                "101 DALMATIONS!!!"
            };
            string output = number <= 10 ? dogsList[0] : number <= 50 ? dogsList[1] : number == 101 ? dogsList[3] : dogsList[2];
            StringAssert.AreEqualIgnoringCase(output,Kata.HowManyDalmatians(number));
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

        public int Number()
        {
            return _random.Next(1, 102);
        }
    }
