/*Challenge link:https://www.codewars.com/kata/51f9d93b4095e0a7200001b8/train/csharp
Question:
Inspired by the development team at Vooza, write the function that

accepts the name of a programmer, and
returns the number of lightsabers owned by that person.
The only person who owns lightsabers is Zach, by the way. He owns 18, which is an awesome number of lightsabers. Anyone else owns 0.

Note: your function should have a default parameter.

For example(Input --> Output):

"anyone else" --> 0
"Zach" --> 18
*/

//***************Solution********************
//apply condition
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static int HowManyLightsabersDoYouOwn(string name) => name == "Zach" ? 18 : 0;
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public static void Adam()
  {
    Assert.AreEqual(0, Kata.HowManyLightsabersDoYouOwn("Adam"));
  }
  
  [Test]
  public static void Zach()
  {
    Assert.AreEqual(18, Kata.HowManyLightsabersDoYouOwn("Zach"));
  }
}
