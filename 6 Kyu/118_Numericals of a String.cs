/*Challenge link:https://www.codewars.com/kata/5b4070144d7d8bbfe7000001/train/csharp
Question:
You are given an input string.

For each symbol in the string if it's the first character occurrence, replace it with a '1', else replace it with the amount of times you've already seen it.

Examples:
input   =  "Hello, World!"
result  =  "1112111121311"

input   =  "aaaaaaaaaaaa"
result  =  "123456789101112"
There might be some non-ascii characters in the string.


*/

//***************Solution********************
using System.Linq;
using System.Collections.Concurrent;
public class JomoPipi{
   public static string Numericals(string s){
     //create concurrent dictionary with char and int
     //from string s, add or update set current element to 1, accumulate index c by 1.
     var d = new ConcurrentDictionary<char,int>();
     return string.Concat(s.Select(x => d.AddOrUpdate(x, 1, (_, c) => ++c)));
   }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
public class SolutionTest
{
    [Test]
    public void BasicTest0()
    {
        Assert.AreEqual("123456789101112", JomoPipi.Numericals("aaaaaaaaaaaa"));
    }
    [Test]
    public void BasicTest1()
    {
        Assert.AreEqual("1112111121311", JomoPipi.Numericals("Hello, World!"));
    }
    [Test]
    public void BasicTest2()
    {
        Assert.AreEqual("11121111213112111131224132411122", JomoPipi.Numericals("Hello, World! It's me, JomoPipi!"));
    }
    [Test]
    public void BasicTest3()
    {
        Assert.AreEqual("11121122342", JomoPipi.Numericals("hello hello"));
    }

    [Test]
    public void FixedTest1()
    {
        Assert.AreEqual("12345", JomoPipi.Numericals("11111"));
    }
    [Test]
    public void FixedTest2()
    {
        Assert.AreEqual("1111112121111111113212311414121151151262267232231",
        JomoPipi.Numericals("hope you 123456789 expected numbers in the string"));
    }
    [Test]
    public void FixedTest3()
    {
        Assert.AreEqual("11111112221221132112411115312263237221234482193101343525441123124155131",
        JomoPipi.Numericals("In this string, I'll make sure the amounts of a character go over 9"));
    }
    private static string Answer(string s)
    {
        var ret = new StringBuilder();
        var map = new Dictionary<char, int>();
        foreach (var c in s)
        {
            var r = map.TryGetValue(c, out var o);
            if (r) map[c] = o + 1;
            else map.Add(c, 1);
            ret.Append(r ? o + 1 : 1);
        }
        return ret.ToString();
    }
    private Random rnd = new Random();
    [Test]
    public void RandomTests()
    {
        for (int i = 0; i < 100; i++)
        {
            var N = rnd.Next(11) + 200;
            var r = new char[N];
            for (int j = 0; j < N; j++)
            {
                var c = (char)(rnd.Next(1001) + 32);
                r[j] = c;
            }
            var s = new string(r);
            string expected = Answer(s), actual = JomoPipi.Numericals(s);
            Assert.AreEqual(expected, actual);
        }
    }
    [Test]
    public void RandomTestsBiggerStrings()
    {
        for (int i = 0; i < 175; i++)
        {
            var N = rnd.Next(101) + 200000;
            var r = new char[N];
            for (int j = 0; j < N; j++)
            {
                var c = (char)(rnd.Next(201) + 32);
                r[j] = c;
            }
            var s = new string(r);
            string expected = Answer(s), actual = JomoPipi.Numericals(s);
            Assert.AreEqual(expected, actual);
        }
    }
}
