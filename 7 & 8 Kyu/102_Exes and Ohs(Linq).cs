/*Challenge link:https://www.codewars.com/kata/55908aad6620c066bc00002a/train/csharp
Question:
Check to see if a string has the same amount of 'x's and 'o's. The method must return a boolean and be case insensitive. The string can contain any char.

Examples input/output:

XO("ooxx") => true
XO("xooxx") => false
XO("ooxXm") => true
XO("zpzpzpp") => true // when no 'x' and 'o' is present should return true
XO("zzoo") => false
*/

//***************Solution********************
//solution 1
//convert to lower case, check if character is a letter, count number of x
//the same applys to o, if they are equal, return true, else false
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System;
public static class Kata {
  public static bool XO (string input) =>
 input.ToLower().Where(x => char.IsLetter(x)).Count(x => x == 'x') == input.ToLower().Where(x => char.IsLetter(x)).Count(x => x == 'o');
}

//solution 2
using System.Linq;
using System;
public static class Kata 
{
  public static bool XO (string input)
  {
     return input.ToLower().Count(i => i == 'x') == input.ToLower().Count(i => i == 'o');
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;


  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Tests()
    {
      Assert.AreEqual(true,Kata.XO("xo"));
      Assert.AreEqual(true,Kata.XO("XO"));
      Assert.AreEqual(true,Kata.XO("xo0"));
      Assert.AreEqual(false,Kata.XO("xxxoo"));
      Assert.AreEqual(true,Kata.XO("xxOo"));
      Assert.AreEqual(true,Kata.XO(""),"Empty string contains equal amount of x and o");
      Assert.AreEqual(true,Kata.XO("xxxxxoooxooo"));
      Assert.AreEqual(false,Kata.XO("xxxm"));
      Assert.AreEqual(false,Kata.XO("ooom"));
      Assert.AreEqual(false,Kata.XO("Oo"));
      Assert.AreEqual(true,Kata.XO("abcdefghijklmnopqrstuvwxyz"),"Alphabet contains equal amount of x and o");
    }
  }
}
