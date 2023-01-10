/*Challenge link:https://www.codewars.com/kata/539ee3b6757843632d00026b/train/csharp
Question:
Instructions
Write a function that takes a single string (word) as argument. The function must return an ordered list containing the indexes of all capital letters in the string.

Example
Assert.AreEqual(Kata.Capitals("CodEWaRs"), new int[]{0,3,4,6});
*/

//***************Solution********************
//in string word, find all matched index, convert to uppercase
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata{
  public static int[] Capitals(string word)=> Regex.Matches(word, "[A-Z]").Select(x => x.Index).ToArray();
}

//****************Sample Test*****************
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public void CodEWaRs()
  {
    Assert.AreEqual(new int[]{0,3,4,6}, Kata.Capitals("CodEWaRs"));
  }
  
  [Test]
  public void NoneOrEmpty(){
  	Assert.AreEqual(new int[]{}, Kata.Capitals("none"));
    Assert.AreEqual(new int[]{}, Kata.Capitals(""));
  }
  
  [Test]
  public void TestOther(){
  	Assert.AreEqual(new int[]{0,1,2,3,4,5}, Kata.Capitals("ALLALL"));
    Assert.AreEqual(new int[]{0}, Kata.Capitals("Kata"));
  }
}
