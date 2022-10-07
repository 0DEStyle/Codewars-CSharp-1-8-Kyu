/*Challenge link:https://www.codewars.com/kata/56efc695740d30f963000557/train/csharp
Question:
altERnaTIng cAsE <=> ALTerNAtiNG CaSe
altERnaTIng cAsE <=> ALTerNAtiNG CaSe
Define String.prototype.toAlternatingCase (or a similar function/method such as to_alternating_case/toAlternatingCase/ToAlternatingCase in your selected language; see the initial solution for details) such that each lowercase letter becomes uppercase and each uppercase letter becomes lowercase. For example:

"hello world".ToAlternatingCase() == "HELLO WORLD"
"HELLO WORLD".ToAlternatingCase() == "hello world"
"hello WORLD".ToAlternatingCase() == "HELLO world"
"HeLLo WoRLD".ToAlternatingCase() == "hEllO wOrld"
"12345".ToAlternatingCase() == "12345" // Non-alphabetical characters are unaffected
"1a2b3c4d5e".ToAlternatingCase() == "1A2B3C4D5E"
"String.ToAlternatingCase".ToAlternatingCase() == "sTRING.tOaLTERNATINGcASE"
As usual, your function/method should be pure, i.e. it should not mutate the original string.
*/

//***************Solution********************

//solution 1
//if case is upper, change to lower
//if case is lower, change to upper
//if case is not a letter, keep it the same
//return the result

using System;

namespace Extensions
{
  public static class StringExt
  {
    public static string ToAlternatingCase (this string s)
    {
      string temp = "";
      for(int i = 0; i < s.Length; i++){
        if (char.IsLower(s[i]))
          temp += char.ToUpper(s[i]);
        else if (char.IsUpper(s[i]))
          temp += char.ToLower(s[i]);
        else if (!char.IsLower(s[i]))
          temp += s[i];
    }
      return temp;
    }
  }
}

//solution 2
//if case is upper, change to lower, else remain upper,
//return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

namespace Extensions
{
    public static class StringExt
    {
        public static string ToAlternatingCase (this string s) =>
            string.Concat(s.Select(c => char.IsUpper(c) ? char.ToLower(c) : char.ToUpper(c)));
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using Extensions;
using System;

[TestFixture]
public class Test
{
  [Test]
  public void _1_BasicUse()
  {
    Assert.AreEqual("HELLO WORLD", "hello world".ToAlternatingCase());
    Assert.AreEqual("hello world", "HELLO WORLD".ToAlternatingCase());
    Assert.AreEqual("HELLO world", "hello WORLD".ToAlternatingCase());
    Assert.AreEqual("hEllO wOrld", "HeLLo WoRLD".ToAlternatingCase());
    Assert.AreEqual("12345", "12345".ToAlternatingCase());
    Assert.AreEqual("1A2B3C4D5E", "1a2b3c4d5e".ToAlternatingCase());
    Assert.AreEqual("sTRING.tOaLTERNATINGcASE", "String.ToAlternatingCase".ToAlternatingCase());
    Assert.AreEqual("Hello World", "Hello World".ToAlternatingCase().ToAlternatingCase(), "Hello World => hELLO wORLD => Hello World");
  }
  
  [Test] 
  public void _2_SourceString()
  {
    string s = "hello world";
    Assert.AreEqual("HELLO WORLD", s.ToAlternatingCase());
    Assert.AreEqual("hello world", s, "Method should not modify the original string.");
    Assert.AreNotEqual("HELLO WORLD", s, "Method should not modify the original string.");
    for(int i = 0; i < 5; i++)
    {
      Assert.AreEqual("HELLO WORLD", s.ToAlternatingCase(), "Method should not modify the original string.");
    }
    
    s = "HeLlO wOrLd";
    Assert.AreEqual("hElLo WoRlD", s.ToAlternatingCase());
    Assert.AreEqual("HeLlO wOrLd", s, "Method should not modify the original string.");
    Assert.AreNotEqual("hElLo WoRlD", s, "Method should not modify the original string.");
    for(int i = 0; i < 5; i++)
    {
      Assert.AreEqual("hElLo WoRlD", s.ToAlternatingCase(), "Method should not modify the original string.");
    }
  }
  
  [Test]    
  public void _3_KataTitle()
  {
    string title = "altERnaTIng cAsE";
    Assert.AreEqual("ALTerNAtiNG CaSe", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("altERnaTIng cAsE", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("ALTerNAtiNG CaSe", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("altERnaTIng cAsE", title.ToAlternatingCase());
    title = "altERnaTIng cAsE <=> ALTerNAtiNG CaSe";
    Assert.AreEqual("ALTerNAtiNG CaSe <=> altERnaTIng cAsE", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("altERnaTIng cAsE <=> ALTerNAtiNG CaSe", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("ALTerNAtiNG CaSe <=> altERnaTIng cAsE", title.ToAlternatingCase());
    title = title.ToAlternatingCase();
    Assert.AreEqual("altERnaTIng cAsE <=> ALTerNAtiNG CaSe", title.ToAlternatingCase());
  }
  
  [Test]    
  public void _4_Random500()
  {
    for(int i = 0; i < 500; i++)
    {
      var t = GenerateTest();
      Assert.AreEqual(t.Item2, t.Item1.ToAlternatingCase(), String.Format("{0} => {1}", t.Item1, t.Item2));
    }
  }
  
  private Random random = new Random();
  private Tuple<string,string> GenerateTest()
  {
    var a = String.Empty;
    var b = String.Empty;
    for(int i = 0; i < random.Next(5,50); i++)
    {
      string pool = "<[{(abcdefghijklmnopqrstuvwxyz 1234567890 !? @#$^& %*-+= ,.;':)}]>";
      char c = pool[random.Next(pool.Length)];
      var alt = random.Next(2) == 0;
      a += alt ? Char.ToUpper(c) : c;
      b += alt ? c : Char.ToUpper(c);
    }
    return new Tuple<string,string>(a,b);
  }
}
