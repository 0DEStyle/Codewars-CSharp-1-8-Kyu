/*Challenge link:https://www.codewars.com/kata/56c30ad8585d9ab99b000c54/train/csharp
Question:
Your task is to Combine two Strings. But consider the rule...

By the way you don't have to check errors or incorrect input values, everything is ok without bad tricks, only two input strings and as result one output string;-)...

And here's the rule:
Input Strings a and b: For every character in string a swap the casing of every occurrence of the same character in string b. Then do the same casing swap with the inputs reversed. Return a single string consisting of the changed version of a followed by the changed version of b. A char of a is in b regardless if it's in upper or lower case - see the testcases too.
I think that's all;-)...

Some easy examples:

Input: "abc" and "cde"      => Output: "abCCde" 
Input: "ab" and "aba"       => Output: "aBABA"
Input: "abab" and "bababa"  => Output: "ABABbababa"
Once again for the last example - description from KenKamau, see discourse;-):

a) swap the case of characters in string b for every occurrence of that character in string a
char 'a' occurs twice in string a, so we swap all 'a' in string b twice. This means we start with "bababa" then "bAbAbA" => "bababa"
char 'b' occurs twice in string a and so string b moves as follows: start with "bababa" then "BaBaBa" => "bababa"

b) then, swap the case of characters in string a for every occurrence in string b
char 'a' occurs 3 times in string b. So string a swaps cases as follows: start with "abab" then => "AbAb" => "abab" => "AbAb"
char 'b' occurs 3 times in string b. So string a swaps as follow: start with "AbAb" then => "ABAB" => "AbAb" => "ABAB".

c) merge new strings a and b
return "ABABbababa"

There are some static tests at the beginning and many random tests if you submit your solution.

Hope you have fun:-)!
*/

//***************Solution********************
/*
For every character in string a swap the casing of every occurrence of the same character in string b. 
Then do the same casing swap with the inputs reversed. 
Return a single string consisting of the changed version of a followed by the changed version of b. 
A char of a is in b regardless if it's in upper or lower case 
  
Input: "abc" and "cde"      => Output: "abCCde" 
Input: "ab" and "aba"       => Output: "aBABA"
Input: "abab" and "bababa"  => Output: "ABABbababa"
*/

using System.Linq;

namespace smile67Kata{
    public class Kata{
        public string workOnStrings(string a, string b) => PlayWithString(a,b)+ PlayWithString(b,a);

        private string PlayWithString(string a, string b)=>
             string.Concat(a.Select(x => b.ToLower().Count(z => char.ToLower(z) == char.ToLower(x)) % 2 == 0 ?
                     x : char.IsUpper(x) ? char.ToLower(x) : char.ToUpper(x)));
    }
}

//****************Sample Test*****************
namespace smile67Kata
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class smile67KataTest
    {
        [Test]
        public void smile67KataTest_withoutRandom1()
        {
            Assert.AreEqual("abCCde", new Kata().workOnStrings("abc","cde"));
        }
        [Test]
        public void smile67KataTest_withoutRandom2()
        {
            Assert.AreEqual("abcDeFGtrzWDEFGgGFhjkWqE", new Kata().workOnStrings("abcdeFgtrzw", "defgGgfhjkwqe"));
        }
        [Test]
        public void smile67KataTest_withoutRandom3()
        {
            Assert.AreEqual("abcDEfgDEFGg", new Kata().workOnStrings("abcdeFg", "defgG"));
        }
        [Test]
        public void smile67KataTest_withoutRandom4()
        {
            Assert.AreEqual("ABABbababa", new Kata().workOnStrings("abab", "bababa"));

        }
        [Test]
        public void smile67Kata_Random_Tests()
        {
            Kata userClass = new Kata();
            string testResult = smile67Kata.Tests.testIt_adf02ad6_a228_49_9313_8aa900582258(ref userClass);
            if (testResult.Length > 0) Assert.Fail(testResult);
        }
    }
}		
