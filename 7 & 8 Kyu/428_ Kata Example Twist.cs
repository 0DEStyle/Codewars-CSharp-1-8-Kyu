/*Challenge link:https://www.codewars.com/kata/525c1a07bb6dda6944000031/train/csharp
Question:
This is an easy twist to the example kata (provided by Codewars when learning how to create your own kata).

Add the value "codewars" to the array websites 1,000 times.
*/

//***************Solution********************

//repeat the string "codewars" 1000 times, convert to array and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata{
  public static string[] Websites = Enumerable.Repeat("codewars",1000).ToArray();
}

//solution 2
using System;

public static class Kata 
{
  public static string[] Websites = new string[1000];
  static Kata()
  {
    for(int i = 0; i < 1000; i++)
      Websites[i] = "codewars";
  }
}

//solution 3
using System;
using System.Linq;

public static class Kata 
{
  public static string[] Websites = new string[1000].Select(x => "codewars").ToArray();
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class KataTests 
{
  [Test]
  public static void Tests() 
  {
    Assert.AreEqual(Kata.Websites.Length, 1000);
    Assert.AreEqual(Kata.Websites.GetType().GetElementType(), typeof(System.String));
    Assert.That(Array.TrueForAll(Kata.Websites, (v) => v == "codewars"));
  }
}  
