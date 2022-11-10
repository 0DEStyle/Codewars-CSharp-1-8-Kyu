/*Challenge link:https://www.codewars.com/kata/57a0556c7cb1f31ab3000ad7/train/csharp
Question:
Write a function which converts the input string to uppercase.
*/

//***************Solution********************
//Convert str to upper
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
  public class Kata
  {
        public static string MakeUpperCase(string str) => str.ToUpper();
  }


//****************Sample Test*****************
namespace Learning {
  using NUnit.Framework;
  using System;
  using System.Linq;
  [TestFixture]
  public class MakeUpperCaseTest
  {
    [Test]
    public void BasicTest()
    {
       Assert.AreEqual("HELLO", Kata.MakeUpperCase("hello"));
       Assert.AreEqual("HELLO WORLD", Kata.MakeUpperCase("hello world"));
       Assert.AreEqual("HELLO WORLD !", Kata.MakeUpperCase("HelLO wOrld !"));
       Assert.AreEqual("HELLO WORLD !", Kata.MakeUpperCase("HelLO wOrld !"));
       Assert.AreEqual("1,2,3 HELLO WORLD!", Kata.MakeUpperCase("1,2,3 hello world!"));       
    }
    
    private static Random rng = new Random();
    
   [Test]
    public void RandomTest()
    {
       for ( int i=0; i< 200; i++)
       {
          string str = GetRandomString(i + 2);
          Assert.AreEqual(str.ToUpper(), Kata.MakeUpperCase(str)); 
       }
    }  
    
    private static string GetRandomString(int length)
    {
        string chars = "ab;-cdefgh2 1ijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, length).Select(s => s[rng.Next(s.Length)]).ToArray());
    }    
   }
 }
