/*Challenge link:https://www.codewars.com/kata/550554fd08b86f84fe000a58/train/csharp
Question:
Given two arrays of strings a1 and a2 return a sorted array r in lexicographical order of the strings of a1 which are substrings of strings of a2.

Example 1:
a1 = ["arp", "live", "strong"]

a2 = ["lively", "alive", "harp", "sharp", "armstrong"]

returns ["arp", "live", "strong"]

Example 2:
a1 = ["tarp", "mice", "bull"]

a2 = ["lively", "alive", "harp", "sharp", "armstrong"]

returns []

Notes:
Arrays are written in "general" notation. See "Your Test Cases" for examples in your language.
In Shell bash a1 and a2 are strings. The return is a string where words are separated by commas.
Beware: In some languages r must be without duplicates.
*/

//***************Solution********************


//from array1, select distinct words
//from those distinct words, get words if array2 contains any of those words
//order them in lexicographical order(pretty much just alphabetical order)
//convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

class WhichAreIn{
  public static string[] inArray(string[] array1, string[] array2) =>
    array1.Distinct()
          .Where(s1 => array2.Any(s2 => s2.Contains(s1)))
          .OrderBy(s => s)
          .ToArray();
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class WhichAreInTests {

[Test]
  public void Test1() {
    string[] a1 = new string[] { "arp", "live", "strong" };
    string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
    string[] r = new string[] { "arp", "live", "strong" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test2() {
    string[] a1 = new string[] { "arp", "mice", "bull" };
    string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong" };
    string[] r = new string[] { "arp" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test3() {
    string[] a1 = new string[] { "cod", "code", "wars", "ewar" };
    string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong", "codewars" };
    string[] r = new string[] { "cod", "code", "ewar", "wars" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test4() {
    string[] a1 = new string[] { "cod", "code", "wars", "ewar", "ar" };
    string[] a2 = new string[] { "lively", "alive", "harp", "sharp", "armstrong", "codewars" };
    string[] r = new string[] { "ar", "cod", "code", "ewar", "wars" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test5() {
    string[] a1 = new string[] { "cod", "code", "wars", "ewar", "ar" };
    string[] a2 = new string[] {  };
    string[] r = new string[] {  };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test6() {
    string[] a1 = new string[] { "1295", "code", "1346", "1028", "ar" };
    string[] a2 = new string[] { "12951295", "ode", "46", "10281066", "par" };
    string[] r = new string[] { "1028", "1295", "ar" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test7() {
    string[] a1 = new string[] { "&()", "code", "1346", "1028", "ar" };
    string[] a2 = new string[] { "12&()95", "coderange", "46", "1066", "par" };
    string[] r = new string[] { "&()", "ar", "code" };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
  [Test]
  public void Test8() {
    string[] a1 = new string[] { "ohio", "code", "1346", "1028", "art" };
    string[] a2 = new string[] { "Carolina", "Ohio", "4600", "NY", "California" };
    string[] r = new string[] {  };
    Assert.AreEqual(r, WhichAreIn.inArray(a1, a2));
  }
}
