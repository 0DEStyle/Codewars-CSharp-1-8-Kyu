/*Challenge link:https://www.codewars.com/kata/54de279df565808f8b00126a/train/csharp
Question:
In this kata, your task is to create a regular expression capable of evaluating binary strings (strings with only 1s and 0s) and determining whether the given string represents a number divisible by 3.

Take into account that:

An empty string might be evaluated to true (it's not going to be tested, so you don't need to worry about it - unless you want)
The input should consist only of binary digits - no spaces, other digits, alphanumeric characters, etc.
There might be leading 0s.
Examples (Javascript)
multipleof3Regex.test('000') should be true
multipleof3Regex.test('001') should be false
multipleof3Regex.test('011') should be true
multipleof3Regex.test('110') should be true
multipleof3Regex.test(' abc ') should be false
You can check more in the example test cases

Note
There's a way to develop an automata (FSM) that evaluates if strings representing numbers in a given base are divisible by a given number. You might want to check an example of an automata for doing this same particular task here.

If you want to understand better the inner principles behind it, you might want to study how to get the modulo of an arbitrarily large number taking one digit at a time.
*/

//***************Solution********************
//method https://stackoverflow.com/questions/7974655/regex-for-binary-multiple-of-3
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;

public class BinaryRegex {
  public static Regex MultipleOf3() => new Regex("^(1(01*0)*1|0)*$");
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

[TestFixture]
public class BinaryRegexTest 
{
  [Test]
  public void CheckType()
  {
    Assert.AreEqual(typeof(Regex), BinaryRegex.MultipleOf3().GetType());
    Assert.AreEqual(typeof(Match), BinaryRegex.MultipleOf3().Match("").GetType());
  }
  
  [Test]
  public void InvalidCharacters()
  {
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch(" 0"));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch("abc"));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch("011 110"));
  }
  
  [Test]
  public void SmallNumbers()
  {
    Assert.AreEqual(true, BinaryRegex.MultipleOf3().IsMatch("000"));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch("001"));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch("010"));
    Assert.AreEqual(true, BinaryRegex.MultipleOf3().IsMatch("011"));
    Assert.AreEqual(true, BinaryRegex.MultipleOf3().IsMatch("110"));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch("111"));
  }
  
  [Test]
  public void LargeNumbers()
  {
    Assert.AreEqual(true, BinaryRegex.MultipleOf3().IsMatch(Convert.ToString(12345678, 2)));
    Assert.AreEqual(false, BinaryRegex.MultipleOf3().IsMatch(Convert.ToString(12345679, 2)));
  }
  
  [Test]
  public void BruteForce()
  {
    BruteForce(0, 10000);
    BruteForce(1000000, 1010000);
  }
  
  private void BruteForce(int min, int max)
  {
    Regex rgx = BinaryRegex.MultipleOf3();
    for (int i = min; i < max; i++)
    {
      string str = Convert.ToString(i, 2);
      bool expected = (i % 3 == 0);
      Assert.AreEqual(expected, rgx.IsMatch(str), str);
    }
  }
}
