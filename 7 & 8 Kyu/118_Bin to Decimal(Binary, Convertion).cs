/*Challenge link:https://www.codewars.com/kata/57a5c31ce298a7e6b7000334/train/csharp
Question:
Complete the function which converts a binary number (given as a string) to a decimal number.
*/

//***************Solution********************
//convert binary string into base 2, return the result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

namespace Solution{
  public static class Program{
    public static int binToDec(string s)=> Convert.ToInt32(s, 2);
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void MyTest()
    {
      Assert.AreEqual(0, Program.binToDec("0"));
      Assert.AreEqual(1, Program.binToDec("1"));
      Assert.AreEqual(2, Program.binToDec("10"));
      Assert.AreEqual(3, Program.binToDec("11"));
      Assert.AreEqual(6, Program.binToDec("110"));
      Assert.AreEqual(170, Program.binToDec("10101010"));
      Assert.AreEqual(255, Program.binToDec("11111111"));
    }
  }
}
