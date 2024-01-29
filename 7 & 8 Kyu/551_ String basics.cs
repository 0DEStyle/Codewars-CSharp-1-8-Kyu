/*Challenge link:https://www.codewars.com/kata/56326c13e63f90538d00004e/train/csharp
Question:
Hey CodeWarrior,

we've got a lot to code today!

I hope you know the basic string manipulation methods, because this kata will be all about them.

Here we go...

Background
We've got a very long string, containing a bunch of User IDs. This string is a listing, which seperates each user ID with a comma and a whitespace ("' "). Sometimes there are more than only one whitespace. Keep this in mind! Futhermore, some user Ids are written only in lowercase, others are mixed lowercase and uppercase characters. Each user ID starts with the same 3 letter "uid", e.g. "uid345edj". But that's not all! Some stupid student edited the string and added some hashtags (#). User IDs containing hashtags are invalid, so these hashtags should be removed!

Task
Remove all hashtags
Remove the leading "uid" from each user ID
Return an array of strings --> split the string
Each user ID should be written in only lowercase characters
Remove leading and trailing whitespaces
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//convert s to lowercase, replace hash tag with nothing
//split string by ',', x is the current element,
//trim x from 3 up to the end, store in array and return the result.

using System.Linq;

public class Kata{
  public static string[] GetUserIds(string s) =>
    s.ToLower()
     .Replace("#", "")
     .Split(',')
     .Select(x => x.Trim()[3..])
     .ToArray();
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase("uid12345", ExpectedResult=new string[1]{"12345"})]
  [TestCase("   uidabc  ", ExpectedResult=new string[1]{"abc"})]
  [TestCase("#uidswagger", ExpectedResult=new string[1]{"swagger"})]
  [TestCase("uidone, uidtwo", ExpectedResult=new string[2]{"one", "two"})]
  [TestCase("uidCAPSLOCK", ExpectedResult=new string[1]{"capslock"})]
  public string[] BasicTest(string s)
  {
      return Kata.GetUserIds(s);
  }
  
  [Test]
  [TestCase("uid##doublehashtag", ExpectedResult=new string[1]{"doublehashtag"})]
  [TestCase("  uidin name whitespace", ExpectedResult=new string[1]{"in name whitespace"})]
  [TestCase("uidMultipleuid", ExpectedResult=new string[1]{"multipleuid"})]
  [TestCase("uid12 ab, uid#, uidMiXeDcHaRs", ExpectedResult=new string[3]{"12 ab", "", "mixedchars"})]
  [TestCase(" uidT#e#S#t# ", ExpectedResult=new string[1]{"test"})]
  public string[] AdvancedTest(string s)
  {
      return Kata.GetUserIds(s);
  }
  
  [Test]
  public void RandomTest([Random(1,10,90)]int x)
  {
    List<string> list = new List<string>();
    Random r = new Random();
    for(int a = 0; a < 20; a++)
    {
      string s = " UID# ";
      for(int i = 0; i < x; i++)
      {
        s += r.Next(10).ToString();
      }
      list.Add(s);
    }
    string str = string.Join(",", list);
    Assert.AreEqual(Solution(str), Kata.GetUserIds(str));
  }
  
  private string[] Solution(string s)
  {
    s = s.ToLower();
    s = s.Replace("#", "");
    string[] arr = s.Split(new char[]{','});
    for(int i = 0; i < arr.Length; i++)
    {
      arr[i] = arr[i].Trim();
      arr[i] = arr[i].Substring(3);
    }
    return arr;
  }
}
