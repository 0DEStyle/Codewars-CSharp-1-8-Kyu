/*Challenge link:https://www.codewars.com/kata/563a8656d52a79f06c00001f/train/csharp
Question:
Given a string, determine if it's a valid identifier.

Here is the syntax for valid identifiers:
Each identifier must have at least one character.
The first character must be picked from: alpha, underscore, or dollar sign. The first character cannot be a digit.
The rest of the characters (besides the first) can be from: alpha, digit, underscore, or dollar sign. In other words, it can be any valid identifier character.
Examples of valid identifiers:
i
wo_rd
b2h
Examples of invalid identifiers:
1i
wo rd
!b2h

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//pattern character set $ _ a to z, A to Z, match 1 or more
//escape character \, w,end
public class IdentifierChecker{
  public static bool IsValid(string s) =>
    System.Text.RegularExpressions.Regex.IsMatch(s, "^[$_a-zA-Z]+[\\w]$");
}
//****************Sample Test*****************

using System;
using NUnit.Framework;

[TestFixture]
public class IdentifierCheckerTest
{
  [Test]
  public void TestValid() 
  {
    Assert.IsTrue(IdentifierChecker.IsValid("okay_ok1"), "IsValid(\"okay_ok1\") should returns true");
    Assert.IsTrue(IdentifierChecker.IsValid("$ok"), "IsValid(\"$ok\") should returns true");
    Assert.IsTrue(IdentifierChecker.IsValid("___"), "IsValid(\"___\") should returns true");
    Assert.IsTrue(IdentifierChecker.IsValid("str_STR"), "IsValid(\"str_STR\") should returns true");
    Assert.IsTrue(IdentifierChecker.IsValid("myIdentf"), "IsValid(\"myIdentf\") should returns true");
  }
  
  [Test]
  public void TestInvalid() 
  {
    Assert.IsFalse(IdentifierChecker.IsValid("1ok0okay"), "IsValid(\"1ok0okay\") should returns false");
    Assert.IsFalse(IdentifierChecker.IsValid("!Ok"), "IsValid(\"!Ok\") should returns false");
    Assert.IsFalse(IdentifierChecker.IsValid(""), "IsValid(\"\") should returns false");
    Assert.IsFalse(IdentifierChecker.IsValid("str-str"), "IsValid(\"str-str\") should returns false");
    Assert.IsFalse(IdentifierChecker.IsValid("no no"), "IsValid(\"no no\") should returns false");
  }
}
