/*Challenge link:https://www.codewars.com/kata/5277c8a221e209d3f6000b56/train/csharp
Question:
Write a function that takes a string of braces, and determines if the order of the braces is valid. It should return true if the string is valid, and false if it's invalid.

This Kata is similar to the Valid Parentheses Kata, but introduces new characters: brackets [], and curly braces {}. Thanks to @arnedag for the idea!

All input strings will be nonempty, and will only consist of parentheses, brackets and curly braces: ()[]{}.

What is considered Valid?
A string of braces is considered valid if all braces are matched with the correct brace.

Examples
"(){}[]"   =>  True
"([{}])"   =>  True
"(}"       =>  False
"[(])"     =>  False
"[({})](]" =>  False
*/

//***************Solution********************
//using half of braces'length, replace each braces pattern with nothing
// if nothing is in braces, return true, else false.

using System.Linq;
using System.Text.RegularExpressions;

public class Brace{
  public static bool validBraces(string braces){
    int count = braces.Length / 2;
    for (var i = 0; i < count; i++)
      braces = Regex.Replace(braces, @"(\(\)|\[\]|\{\})", "");
    
    return !braces.Any();
  }
}

//****************Sample Test*****************
using System;
using System.Collections;
using NUnit.Framework;

class Assertions
{
  public static void Valid(string s) {
    bool expected = true;
    bool actual = Brace.validBraces(s);
    Assert.AreEqual(expected, actual, $"Incorrect answer for braces = \"{s}\"");
  }
  
  public static void Invalid(string s) {
    bool expected = false;
    bool actual = Brace.validBraces(s);
    Assert.AreEqual(expected, actual, $"Incorrect answer for braces = \"{s}\"");
  }
}

[TestFixture]
public class BraceTests {

  [Test]
  public void Test1() {
    Assertions.Valid( "()" );
  }
  
  [Test]
  public void Test2() {
    Assertions.Valid( "[]" );
  }
  
  [Test]
  public void Test3() {
    Assertions.Valid( "(){}[]" );
  }
  
  [Test]
  public void Test4() {
    Assertions.Valid( "([{}])" );
  }
  
  [Test]
  public void Test5() {
    Assertions.Valid( "([{}])" );
  }
  
  [Test]
  public void Test6() {
    Assertions.Invalid( "[(])" );
  }
  
  [Test]
  public void Test7() {
    Assertions.Valid( "({})[({})]" );
  }
  
  [Test]
  public void Test8() {
    Assertions.Invalid( "(})" );
  }
  
  [Test]
  public void Test9() {
    Assertions.Valid( "{}" );
  }
  
  [Test]
  public void Test10() {
    Assertions.Valid( "(({{[[]]}}))" );
  }
  
  [Test]
  public void Test11() {
    Assertions.Valid( "{}({})[]" );
  }
  
  [Test]
  public void Test12() {
    Assertions.Invalid( ")(}{][" );
  }

  [Test]
  public void Test13() {
    Assertions.Invalid( "())({}}{()][][" );
  }
  
  [Test]
  public void Test14() {
    Assertions.Invalid( "(((({{" );
  }
 
  [Test]
  public void Test15() {
    Assertions.Invalid( "}}]]))}])" );
  }

  [Test]
  public void Test16() {
    Assertions.Invalid( "}}()" );
  }
}
