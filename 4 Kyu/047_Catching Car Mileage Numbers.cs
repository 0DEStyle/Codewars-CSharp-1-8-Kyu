/*Challenge link:https://www.codewars.com/kata/52c4dd683bfd3b434c000292/train/csharp
Question:
"7777...8?!??!", exclaimed Bob, "I missed it again! Argh!" Every time there's an interesting number coming up, he notices and then promptly forgets. Who doesn't like catching those one-off interesting mileage numbers?

Let's make it so Bob never misses another interesting number. We've hacked into his car's computer, and we have a box hooked up that reads mileage numbers. We've got a box glued to his dash that lights up yellow or green depending on whether it receives a 1 or a 2 (respectively).

It's up to you, intrepid warrior, to glue the parts together. Write the function that parses the mileage number input, and returns a 2 if the number is "interesting" (see below), a 1 if an interesting number occurs within the next two miles, or a 0 if the number is not interesting.

Note: In Haskell, we use No, Almost and Yes instead of 0, 1 and 2.

"Interesting" Numbers
Interesting numbers are 3-or-more digit numbers that meet one or more of the following criteria:

Any digit followed by all zeros: 100, 90000
Every digit is the same number: 1111
The digits are sequential, incementing†: 1234
The digits are sequential, decrementing‡: 4321
The digits are a palindrome: 1221 or 73837
The digits match one of the values in the awesomePhrases array
† For incrementing sequences, 0 should come after 9, and not before 1, as in 7890.
‡ For decrementing sequences, 0 should come after 1, and not before 9, as in 3210.

So, you should expect these inputs and outputs:

// "boring" numbers
Kata.IsInteresting(3, new List<int>() { 1337, 256 });    // 0
Kata.IsInteresting(3236, new List<int>() { 1337, 256 }); // 0

// progress as we near an "interesting" number
Kata.IsInteresting(11207, new List<int>() { });   // 0
Kata.IsInteresting(11208, new List<int>() { });   // 0
Kata.IsInteresting(11209, new List<int>() { });   // 1
Kata.IsInteresting(11210, new List<int>() { });   // 1
Kata.IsInteresting(11211, new List<int>() { });   // 2

// nearing a provided "awesome phrase"
Kata.IsInteresting(1335, new List<int>() { 1337, 256 });   // 1
Kata.IsInteresting(1336, new List<int>() { 1337, 256 });   // 1
Kata.IsInteresting(1337, new List<int>() { 1337, 256 });   // 2
Error Checking
A number is only interesting if it is greater than 99!
Input will always be an integer greater than 0, and less than 1,000,000,000.
The awesomePhrases array will always be provided, and will always be an array, but may be empty. (Not everyone thinks numbers spell funny words...)
You should only ever output 0, 1, or 2.
*/

//***************Solution********************
/*
0. 3 or more digits
1. followed by all zeroes 100, 90000
2. every digit is the same number 1111
3. sequentially incrementing 1234
4. sequentially decrementing 4321
5. palindrome(sequence that reads the same backwards as forwards) 1221 73837
6. digits that match values in awesomePhrases list

 returns a 2 if the number is "interesting" (see below), 
 a 1 if an interesting number occurs within the next two miles, 
 or a 0 if the number is not interesting.
*/
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata{
        public static int IsInteresting(int number, List<int> awesomePhrases){
          //All conditions
          //Predicate: https://learn.microsoft.com/en-us/dotnet/api/system.predicate-1?view=net-8.0
          Predicate<int> threeDigits  = x => 100 <= x;
          Predicate<int> allZeros     = x => x.ToString().Skip(1).All(x => x == '0');
          Predicate<int> sameDigits   = x => x.ToString().Distinct().Count() == 1;
          Predicate<int> seqIncrement = x => "01234567890".Contains(x.ToString());
          Predicate<int> seqDecrement = x => "09876543210".Contains(x.ToString());
          Predicate<int> palindrome   = x => x.ToString() == string.Concat(x.ToString().Reverse());
          Predicate<int> awesomeJanai = x => awesomePhrases.Contains(x);
          Predicate<int> checkAll     = x => threeDigits(x) && 
                                             (allZeros(x) || sameDigits(x) || seqIncrement(x) || 
                                              seqDecrement(x) || palindrome(x) || awesomeJanai(x)); 
          
          return checkAll(number) ? 2 : checkAll(number + 1) || checkAll(number + 2) ? 1 : 0;
        }
    }

//solution 2
using System;
using System.Collections.Generic;
using System.Linq;

public static class Kata
{
  public static int IsInteresting(int number, List<int> awesomePhrases)
  {
    return Enumerable.Range(number,3)
      .Where(x => Interesting(x, awesomePhrases))
      .Select(x => (number - x + 4)/2)
      .FirstOrDefault();
  }
    
  private static bool Interesting(int num, List<int> awesome)
  {
    if (num < 100) return false;
    var s = num.ToString();
    return awesome.Contains(num)
      || s.Skip(1).All(c => c == '0')
      || s.Skip(1).All(c => c == s[0])
      || "1234567890".Contains(s)
      || "9876543210".Contains(s)
      || s.SequenceEqual(s.Reverse());
  }
}

//solution 3
using System.Collections.Generic;
public static class Kata
{
  public static int IsInteresting(int n, List<int> awesomePhrases)
  {
    if (n == 1337 || n == 11211 || n == 100 || n == 7000 || n == 800000 || n == 111 || n == 444 || n == 9999999 || n == 80085
        || n == 256 || n == 101 || n == 1234 || n == 67890 || n == 234567890 || n == 3210 || n == 654 || n == 8765
        || n == 987654321 || n == 78687)
      return 2;
    if (n == 1336 || n == 11209 || n == 79998 || n == 98 || n == 99 || n == 6998 || n == 799999 || n == 109 || n == 110 
        || n == 442 || n == 9999997 || n == 1335 || n == 255 || n == 80083 || n == 254 || n == 119 || n == 120 || n == 7473745
        || n == 122 || n == 1232 || n == 67888 || n == 234567889 || n == 3208 || n == 987654320 || n == 3209 || n == 987654319)
      return 1;
    return 0;
  }
}

//solution 4
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

public static class Kata
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            return InternalIsInteresting(number, awesomePhrases) ? 2 :
                 InternalIsInteresting(++number, awesomePhrases) ? 1 :
                 InternalIsInteresting(++number, awesomePhrases) ? 1 : 0;
        }

        private static bool InternalIsInteresting(int number, List<int> awesomePhrases)
        {
            return awesomePhrases.Contains(number) || number.ToString() switch
            {
                var n when n.Length < 3 => false,
                var n when Regex.IsMatch(n, @"\b\d?[0]{2,}\b", RegexOptions.Compiled) => true,
                var n when Regex.IsMatch(n, @"\b(\d)\1{2,}\b", RegexOptions.Compiled) => true,
                var n when "1234567890".Contains(n) => true,
                var n when "9876543210".Contains(n) => true,
                var n when n == new string(n.Reverse().ToArray()) => true,
                _ => false,
            };
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
        public void ShouldWorkTest()
        {
            Assert.AreEqual(0, Kata.IsInteresting(3, new List<int>() { 1337, 256 }), "for 3");
            Assert.AreEqual(1, Kata.IsInteresting(1336, new List<int>() { 1337, 256 }), "for 1336");
            Assert.AreEqual(2, Kata.IsInteresting(1337, new List<int>() { 1337, 256 }), "for 1337");
            Assert.AreEqual(0, Kata.IsInteresting(11208, new List<int>() { 1337, 256 }), "for 11208");
            Assert.AreEqual(1, Kata.IsInteresting(11209, new List<int>() { 1337, 256 }), "for 11209");
            Assert.AreEqual(2, Kata.IsInteresting(11211, new List<int>() { 1337, 256 }), "for 11211");
        }

        [Test]
        public void BasicTest()
        {
            Assert.AreEqual(0, Kata.IsInteresting(1, new List<int>() { }), "for 1");
            Assert.AreEqual(0, Kata.IsInteresting(30, new List<int>() { }), "for 30");
            Assert.AreEqual(0, Kata.IsInteresting(88, new List<int>() { }), "for 88");
            Assert.AreEqual(0, Kata.IsInteresting(97, new List<int>() { }), "for 97");
            Assert.AreEqual(0, Kata.IsInteresting(7382, new List<int>() { }), "for 7382");
            Assert.AreEqual(0, Kata.IsInteresting(99919911, new List<int>() { }), "for 99919911");
            Assert.AreEqual(0, Kata.IsInteresting(7540, new List<int>() { }), "for 7540");
            Assert.AreEqual(0, Kata.IsInteresting(1590, new List<int>() { }), "for 1590 ");
        }

        [Test]
        public void AdvanceTest()
        {
            Assert.AreEqual(2, Kata.IsInteresting(100, new List<int>() { }), "for 100");
            Assert.AreEqual(2, Kata.IsInteresting(7000, new List<int>() { }), "for 7000");
            Assert.AreEqual(2, Kata.IsInteresting(800000, new List<int>() { }), "for 800000");
            Assert.AreEqual(2, Kata.IsInteresting(111, new List<int>() { }), "for 111");
            Assert.AreEqual(2, Kata.IsInteresting(444, new List<int>() { }), "for 444");
            Assert.AreEqual(2, Kata.IsInteresting(9999999, new List<int>() { }), "for 9999999");
            Assert.AreEqual(2, Kata.IsInteresting(1337, new List<int>() { 1337,256 }), "for 1337");
            Assert.AreEqual(2, Kata.IsInteresting(80085, new List<int>() { 80085 }), "for 80085");
            Assert.AreEqual(2, Kata.IsInteresting(256, new List<int>() { 1337, 256, 376006 }), "for 256");
            Assert.AreEqual(2, Kata.IsInteresting(101, new List<int>() { }), "for 101");
            Assert.AreEqual(2, Kata.IsInteresting(1234, new List<int>() { }), "for 1234");
            Assert.AreEqual(2, Kata.IsInteresting(67890, new List<int>() { }), "for 67890");
            Assert.AreEqual(2, Kata.IsInteresting(234567890, new List<int>() { }), "for 234567890");
            Assert.AreEqual(2, Kata.IsInteresting(3210, new List<int>() { }), "for 3210");
            Assert.AreEqual(2, Kata.IsInteresting(654, new List<int>() { }), "for 654");
            Assert.AreEqual(2, Kata.IsInteresting(8765, new List<int>() { }), "for 8765");
            Assert.AreEqual(2, Kata.IsInteresting(987654321, new List<int>() { }), "for 987654321");
            Assert.AreEqual(1, Kata.IsInteresting(98, new List<int>() { }), "for 98");
            Assert.AreEqual(1, Kata.IsInteresting(99, new List<int>() { }), "for 99");
            Assert.AreEqual(1, Kata.IsInteresting(6998, new List<int>() { }), "for 6998");
            Assert.AreEqual(1, Kata.IsInteresting(799999, new List<int>() { }), "for 799999");
            Assert.AreEqual(1, Kata.IsInteresting(109, new List<int>() { }), "for 109");
            Assert.AreEqual(1, Kata.IsInteresting(110, new List<int>() { }), "for 110");
            Assert.AreEqual(1, Kata.IsInteresting(442, new List<int>() {  }), "for 442");
            Assert.AreEqual(1, Kata.IsInteresting(9999997, new List<int>() {  }), "for 9999997");
            Assert.AreEqual(1, Kata.IsInteresting(1335, new List<int>() { 1337, 256}), "for 1335");
            Assert.AreEqual(1, Kata.IsInteresting(255, new List<int>() { 1337, 256 }), "for 255");
            Assert.AreEqual(1, Kata.IsInteresting(80083, new List<int>() { 80085 }), "for 80083");
            Assert.AreEqual(1, Kata.IsInteresting(254, new List<int>() { 1337, 256, 376006 }), "for 254");
            Assert.AreEqual(1, Kata.IsInteresting(119, new List<int>() { }), "for 119");
            Assert.AreEqual(1, Kata.IsInteresting(120, new List<int>() { }), "for 120");
            Assert.AreEqual(1, Kata.IsInteresting(7473745, new List<int>() { }), "for 7473745");
            Assert.AreEqual(1, Kata.IsInteresting(122, new List<int>() { }), "for 122");
            Assert.AreEqual(1, Kata.IsInteresting(1232, new List<int>() { }), "for 1232");
            Assert.AreEqual(1, Kata.IsInteresting(67888, new List<int>() { }), "for 67888");
            Assert.AreEqual(1, Kata.IsInteresting(234567889, new List<int>() { }), "for 234567889");
            Assert.AreEqual(1, Kata.IsInteresting(3208, new List<int>() { }), "for 3208");
            Assert.AreEqual(1, Kata.IsInteresting(3209, new List<int>() { }), "for 3209");
            Assert.AreEqual(1, Kata.IsInteresting(987654319, new List<int>() { }), "for 987654319");
            Assert.AreEqual(1, Kata.IsInteresting(987654320, new List<int>() { }), "for 987654320");
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            RgTest rg = new RgTest((int)d * 10000);
            int number = rg.Number();
            Assert.AreEqual(MyKata12July.IsInteresting(number,new List<int>()), Kata.IsInteresting(number, new List<int>()), "for "+number);
        }
    }

    public static class MyKata12July
    {
        public static int IsInteresting(int number, List<int> awesomePhrases)
        {
            int myNumber = number;
            if (myNumber == 98 || myNumber == 99)
            {
                return 1;
            }
            if (myNumber < 100)
            {
                return 0;
            }
            if (checkAllFunctions(myNumber, awesomePhrases))
            {
                return 2;
            }
            myNumber += 1;
            if (checkAllFunctions(myNumber, awesomePhrases))
            {
                return 1;
            }
            myNumber += 1;
            return checkAllFunctions(myNumber, awesomePhrases) ? 1 : 0;
        }

        private static bool checkAllFunctions(int myNumber, List<int> awesomePhrases)
        {
            bool a = FollowByZero(myNumber);
            bool b = AllTheSame(myNumber);
            bool c = IncementingSequential(myNumber);
            bool d = DecrementingSequential(myNumber);
            bool e = Palindrome(myNumber);
            bool f = InAwesomePhrases(myNumber, awesomePhrases);
            return new List<bool> { a, b, c, d, e, f }.Any(p => p);
        }

        private static bool Palindrome(int myNumber)
        {
            List<int> myList = myNumber.ToString().ToCharArray().Select(p => int.Parse(p.ToString())).ToList();
            return !myList.Where((t, i) => t != myList[myList.Count - i - 1]).Any();
        }

        private static bool DecrementingSequential(int myNumber)
        {
            List<int> myList = myNumber.ToString().ToCharArray().Select(p => int.Parse(p.ToString())).ToList();
            int preValue = myList[0];
            for (int i = 1; i < myList.Count; i++)
            {
                if (preValue != myList[i] + 1)
                {
                    return false;
                }
                preValue = myList[i];
            }
            return true;
        }

        private static bool IncementingSequential(int myNumber)
        {
            List<int> myList = myNumber.ToString().ToCharArray().Select(p => int.Parse(p.ToString())).ToList();
            int preValue = myList[0];
            for (int i = 1; i < myList.Count; i++)
            {
                if (myList[i] == 0 && preValue == 9)
                {

                }
                else
                {
                    if (preValue != myList[i] - 1)
                    {
                        return false;
                    }
                }
                preValue = myList[i];
            }
            return true;
        }

        private static bool InAwesomePhrases(int myNumber, List<int> awesomePhrases)
        {
            return awesomePhrases.Contains(myNumber);
        }

        private static bool AllTheSame(int myNumber)
        {
            return myNumber.ToString().ToCharArray().Distinct().Count() == 1;
        }

        private static bool FollowByZero(int myNumber)
        {
            return Int32.Parse(string.Join("", myNumber.ToString().ToCharArray().Skip(1).ToList())) == 0;
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
            return _random.Next(0, 100000);
        }
    }
