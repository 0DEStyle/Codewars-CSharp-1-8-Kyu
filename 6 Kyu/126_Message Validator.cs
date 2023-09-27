/*Challenge link:https://www.codewars.com/kata/5fc7d2d2682ff3000e1a3fbc/train/csharp
Question:
In this kata, you have an input string and you should check whether it is a valid message. To decide that, you need to split the string by the numbers, and then compare the numbers with the number of characters in the following substring.

For example "3hey5hello2hi" should be split into 3, hey, 5, hello, 2, hi and the function should return true, because "hey" is 3 characters, "hello" is 5, and "hi" is 2; as the numbers and the character counts match, the result is true.

Notes:

Messages are composed of only letters and digits
Numbers may have multiple digits: e.g. "4code13hellocodewars" is a valid message
Every number must match the number of character in the following substring, otherwise the message is invalid: e.g. "hello5" and "2hi2" are invalid
If the message is an empty string, you should return true
*/

//***************Solution********************

//create regex expression to find matches from the string message
//?<d>capturing group [\d]+ match any digit character from 0-9, once or more
//?<w>capturing group [\D]+ match anything that is not a digit 0-9, once or more
//? match between 0 and 1
//check all and return a boolean value, m is the current element
//if m group "d" value is the same as m group "w"'s length
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Text.RegularExpressions;

public class Kata{
  public static bool isAValidMessage(string message) =>
    Regex.Matches(message, @"(?<d>[\d]+)(?<w>[\D]+)?")
        .All(m => int.Parse(m.Groups["d"].Value) == m.Groups["w"].Value.Length);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Text.RegularExpressions;
[TestFixture]
public class isAValidMessageTest {

    [Test]
    public void test1() {
        Assert.AreEqual(true, Kata.isAValidMessage("3hey5hello2hi"));
    }

    [Test]
    public void test2() {
        Assert.AreEqual(true, Kata.isAValidMessage("4code13hellocodewars"));
    }
    
    [Test]
    public void test3() {
        Assert.AreEqual(false, Kata.isAValidMessage("3hey5hello2hi5"));
    }
    
    [Test]
    public void test4() {
        Assert.AreEqual(false, Kata.isAValidMessage("code4hello5"));
    }
  
    [Test]
    public void test5() {
        Assert.AreEqual(true, Kata.isAValidMessage("1a2bb3ccc4dddd5eeeee"));
    }
    
    [Test]
    public void test6() {
        Assert.AreEqual(true, Kata.isAValidMessage(""));
    }
  
    [Test]
    public void testRandom1() {
        var rand = new Random();
        var count = rand.Next(500,1000);
        var count2 = rand.Next(500,1000);
        var part = RandomString(count);
        var part2 = RandomString(count2);
        var input = string.Concat(new string[] { count.ToString(),part,count2.ToString(),part2 }.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
  
    [Test]
    public void testRandom2() {
        var rand = new Random();
        var count = rand.Next(500,1000);
        var count2 = rand.Next(500,1000);
        var part = RandomString(count);
        var part2 = RandomString(count2);
        var input = string.Concat(new string[] { count.ToString(),part,count2.ToString(),part2 }.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
    [Test]
    public void testRandom3() {
        var rand = new Random();
        var count = rand.Next(500,1000);
        var count2 = rand.Next(500,1000);
        var count3 = rand.Next(100,200);
        var part = RandomString(count);
        var part2 = RandomString(count2);
        var part3 = RandomString(count3);
        var input = string.Concat(new string[] { count.ToString(),part,count2.ToString(),part2,count3.ToString(),part3 }.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
  
    [Test]
    public void testRandom4() {
        var rand = new Random();
        var count = rand.Next(500,1000);
        var count2 = rand.Next(500,1000);
        var count3 = rand.Next(100,200);
        var part = RandomString(count);
        var part2 = RandomString(count2);
        var part3 = RandomString(count3);
        var input = string.Concat(new string[] { count.ToString(),part,count2.ToString(),part2,count3.ToString(),part3 }.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
    
    [Test]
    public void testRandom5() {
        var rand = new Random();
        var count = rand.Next(500,1000);
        var count2 = rand.Next(500,1000);
        var part = RandomString(count);
        var part2 = RandomString(count2);
        var input = string.Concat(new string[] { count.ToString(), part, count2.ToString(), part2}.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
    
    [Test]
    public void testRandom6() {
        var rand = new Random();
        var count = rand.Next(80,100);
        var part = RandomString(count);
        var input = string.Concat(new string[] { count.ToString(), part}.OrderBy(x=> Guid.NewGuid()));
       
        Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
    }
    
    [Test]
    public void testRandom7() {
        for (int i = 0; i < 100; i++) {
            var rand = new Random();
            var count = rand.Next(10,10);
            var count2 = rand.Next(10,10);
            var count3 = rand.Next(10,10);
            var part = RandomString(count);
            var part2 = RandomString(count2);
            var part3 = RandomString(count3);
            var input = string.Concat(new string[] { count.ToString(),part,count2.ToString(),part2,count3.ToString(),part3 }.OrderBy(x=> Guid.NewGuid()));
            Assert.AreEqual(isAValidMessageProvider(input), Kata.isAValidMessage(string.Concat(input)));
        }
    }
    
    private bool isAValidMessageProvider(string message) {
      if (message == string.Empty) return true;
      if (!Regex.Match(message, @"^\d").Success) return false;
      var items = Regex.Split(message, @"\d+").Where(a => !string.IsNullOrEmpty(a)).ToList();
      var counts = Regex.Split(message, @"\D+").Where(a => !string.IsNullOrEmpty(a)).ToList();
      return items.Count == counts.Count && items.Zip(counts, (i, c) => new { i, c }).All(x => x.i.Count() == Convert.ToInt32(x.c));
    } 
    
    private string RandomString(int length) {
            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var stringChars = new char[length];
            var random = new Random();
            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            return new String(stringChars);
    }
}
