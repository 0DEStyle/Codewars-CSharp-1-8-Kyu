/*Challenge link:https://www.codewars.com/kata/52adc142b2651f25a8000643/train/csharp
Question:
Christmas is coming and many people dreamed of having a ride with Santa's sleigh. But, of course, only Santa himself is allowed to use this wonderful transportation. And in order to make sure, that only he can board the sleigh, there's an authentication mechanism.

Your task is to implement the authenticate() method of the sleigh, which takes the name of the person, who wants to board the sleigh and a secret password. If, and only if, the name equals "Santa Claus" and the password is "Ho Ho Ho!" (yes, even Santa has a secret password with uppercase and lowercase letters and special characters :D), the return value must be true. Otherwise it should return false.

Examples:

var sleigh = new Sleigh();
sleigh.authenticate("Santa Claus", "Ho Ho Ho!"); // must return TRUE

sleigh.authenticate("Santa", "Ho Ho Ho!"); // must return FALSE
sleigh.authenticate("Santa Claus", "Ho Ho!"); // must return FALSE
sleigh.authenticate("jhoffner", "CodeWars"); // Nope, even Jake is not allowed to use the sleigh ;)
*/

//***************Solution********************
//ternary expression if else statement
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

public class Sleigh{
  public static bool Authenticate(string name, string password) =>
    name == "Santa Claus" && password == "Ho Ho Ho!";
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("The Sleigh must authenticate with correct credentials")]
    public void CorrectTest()
    {
      Assert.That(Sleigh.Authenticate("Santa Claus", "Ho Ho Ho!"));
    }
    
    private static Random rnd = new Random();
    
    private static object[] incorrectTests = new object[]
    {
      new object[] {"Santa", "Ho Ho Ho!"},
      new object[] {"Santa Claus", "Ho Ho Ho"},
      new object[] {"Santa Claus", "Ho Ho!"},
      new object[] {"Easter Bunny", "Ho Ho Ho!"},
      new object[] {"jhoffner", "CodeWars"},
    }.OrderBy(_ => rnd.Next()).ToArray();
    
    [Test, Description("The Sleigh must not authenticate with incorrect credentials")]
    public void IncorrectTest()
    {
      for (int i = 0; i < incorrectTests.Length; ++i)
      {
        Assert.That(!Sleigh.Authenticate(((incorrectTests[i] as object[])[0] as string), ((incorrectTests[i] as object[])[1] as string)));
      }
    }
  }
}
