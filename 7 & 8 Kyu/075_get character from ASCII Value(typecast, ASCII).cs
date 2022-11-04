/*Challenge link:https://www.codewars.com/kata/55ad04714f0b468e8200001c/train/csharp
Question:
Write a function get_char() / getChar() which takes a number and returns the corresponding ASCII char for that value.

Example:

get_char(65)
should return:

'A'
For ASCII table, you can refer to http://www.asciitable.com/
*/

//***************Solution********************
//typecast charcode into char
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata
{
  public static char GetChar(int charcode) => (char)charcode;
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(55, ExpectedResult='7')]
  [TestCase(55, ExpectedResult='7')]
  [TestCase(56, ExpectedResult='8')]
  [TestCase(57, ExpectedResult='9')]
  [TestCase(58, ExpectedResult=':')]
  [TestCase(59, ExpectedResult=';')]
  [TestCase(60, ExpectedResult='<')]
  [TestCase(61, ExpectedResult='=')]
  [TestCase(62, ExpectedResult='>')]
  [TestCase(63, ExpectedResult='?')]
  [TestCase(64, ExpectedResult='@')]
  [TestCase(65, ExpectedResult='A')]
  public static char FixedTest(int charCode)
  {
    return Kata.GetChar(charCode);
  }
  
  [Test]
  public static void RandomTest([Random(0,255,100)]int charCode)
  {
    Assert.AreEqual((char)charCode, Kata.GetChar(charCode), string.Format("Should work for {0}", charCode));
  }
}
