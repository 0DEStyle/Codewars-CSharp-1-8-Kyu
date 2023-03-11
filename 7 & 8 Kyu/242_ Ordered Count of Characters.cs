/*Challenge link:https://www.codewars.com/kata/57a6633153ba33189e000074/train/csharp
Question:
Count the number of occurrences of each character and return it as a (list of tuples) in order of appearance. For empty output return (an empty list).

Consult the solution set-up for the exact data structure implementation depending on your language.

Example:

Kata.OrderedCount("abracadabra") == new List<Tuple<char, int>> () {
  new Tuple<char, int>('a', 5),
  new Tuple<char, int>('b', 2),
  new Tuple<char, int>('r', 2), 
  new Tuple<char, int>('c', 1),
  new Tuple<char, int>('d', 1)
}
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Collections.Generic;
using System.Linq;

namespace Solution {
    public class Kata {
        public static List<Tuple<char, int>> OrderedCount(string input) =>
          input.GroupBy(x=>x).Select(c => Tuple.Create(c.Key, c.Count())).ToList();
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Solution {    
    [TestFixture]
    public class TestSuite {
        [Test]
        public void FixedTests()
        {
            Assert.AreEqual(
                new List<Tuple<char, int>>() {},
                Kata.OrderedCount("")
            );
            Assert.AreEqual(
                new List<Tuple<char, int>>() {
                    tuple('a', 5),
                    tuple('b', 2),
                    tuple('r', 2),
                    tuple('c', 1),
                    tuple('d', 1)
                },
                Kata.OrderedCount("abracadabra")
            );
            Assert.AreEqual(
                new List<Tuple<char, int>> () {
                    tuple('C', 1),
                    tuple('o', 1),
                    tuple('d', 1),
                    tuple('e', 1),
                    tuple(' ', 1),
                    tuple('W', 1),
                    tuple('a', 1),
                    tuple('r', 1),
                    tuple('s', 1)
                },
                Kata.OrderedCount("Code Wars")
            );
        }
        
        private static Tuple<char, int> tuple(char character, int count) {
            return new Tuple<char, int>(character, count);
        }
    
        private Random random = new Random();
    
        [Test]
        public void RandomTests()
        {
            for (var i = 0;i < 100;i++) {
                string ri = RandomInput();
                Assert.AreEqual(Solution(ri), Kata.OrderedCount(ri));
            }
        }
    
        private string RandomInput() {
            const string chars =  "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            int lng = chars.Length;
            return string.Concat(Enumerable.Range(1, random.Next(1, 100)).Select(o => chars[random.Next(lng)]));
        }
    
        private List<Tuple<char, int>> Solution(string input)
        {
            var counter = new Dictionary<char, int>();
            foreach (var character in input)
            {
                counter[character] = counter.GetValueOrDefault(character) + 1;
            }
            return counter.Select(kvp => new Tuple<char, int>(kvp.Key, kvp.Value)).ToList();
        }
    }
}
