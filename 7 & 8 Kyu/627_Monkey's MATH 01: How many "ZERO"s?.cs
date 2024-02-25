/*Challenge link:https://www.codewars.com/kata/56c2acc8c44a3ad6e400050a/train/csharp
Question:
Gigi is a clever monkey, living in the zoo, his teacher (animal keeper) recently taught him some knowledge of "0".

In Gigi's eyes, "0" is a character contains some circle(maybe one, maybe two).

So, a is a "0",b is a "0",6 is also a "0"，and 8 have two "0" ,etc...

Now, write some code to count how many "0"s in the text.

Let us see who is smarter? You ? or monkey?

Input always be a string(including words numbers and symbols)，You don't need to verify it, but pay attention to the difference between uppercase and lowercase letters.

Here is a table of characters：

one zero	abdegopq069DOPQR         () <-- A pair of braces as a zero
two zero	%&B8
Output will be a number of "0".
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//1 zero character + 2 zeros characters
using System.Text.RegularExpressions;

public class Kata{
    public static int CountZero(string s) =>
      Regex.Matches(s, @"[abdegopq069DOPQR]|\(\)").Count + Regex.Matches(s, @"[%&B8]").Count * 2;
}

//linq
using System.Linq;

public class Kata
{
  public static int CountZero(string s)
  {
    return s.Replace("()", "a").Sum(c => "abdegopq069DOPQR".Contains(c) ? 1 : "%&B8".Contains(c) ? 2 : 0);
  }
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Linq;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(0, Kata.CountZero(""), "There are no '0's.");
            Assert.AreEqual(1, Kata.CountZero("0"), "There is 1 '0'.");
            Assert.AreEqual(1, Kata.CountZero("()"), "There is 1 '0'.");
            Assert.AreEqual(3, Kata.CountZero("O()()"), "There are 3 '0's.");
            Assert.AreEqual(5, Kata.CountZero("1234567890"), "There are 5 '0's.");
            Assert.AreEqual(8, Kata.CountZero("abcdefghijklmnopqrstuvwxyz"), "There are 8 '0's.");
        }
        
        [Test]
        public void ExtendedTests()
        {
            Assert.AreEqual(1, Kata.CountZero("()"), "In monkey eyes is '()' is a '0'. ;-)");
            Assert.AreEqual(0, Kata.CountZero("§"), "'e' is '0', but 'E' is not.");
            Assert.AreEqual(3, Kata.CountZero("BRA"), "'B' and 'R' have 3 '0', 'A' is not 'a' and have not '0'");
        }
        
        [Test]
        public void RandomTests()
        {
            Random rand = new Random();
            
            Func<string, int> solution = (s) =>
            {
                return s == "" ? 0
                    : s.Replace("()", "0").Select(c => "abdegopq069DOPQR".Contains(c) ? 1 : "%&B8".Contains(c) ? 2 : 0)
                       .Sum();
            };
            
            for(int i = 0; i < 100; i++)
            {
                int length = rand.Next(0, 21);

                var test = string.Concat(Enumerable.Range(0, length).Select(c => rand.Next(20) == 0 ? "()" : ((char)rand.Next(32, 124)).ToString()));
    	          
                int expected = solution(test);
                
                int actual = Kata.CountZero(test);
                
                Console.WriteLine($"Input: {test}\n<hr>\n");
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
