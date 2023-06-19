/*Challenge link:https://www.codewars.com/kata/57a4d500e298a7952100035d/train/csharp
Question:
Complete the function which converts hex number (given as a string) to a decimal number.


*/

//***************Solution********************

//check if hexString contains a negative sign
//if true, remove it to perform hex to dec convertion, then * -1 to add the sign back
//else convert hex to dec and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public class Kata{
  public static int HexToDec(string hexString) =>
      hexString.Contains("-") ? 
      Convert.ToInt32(hexString = hexString.Remove(0,1), 16) *-1 :
      Convert.ToInt32(hexString, 16);
}

//better solution
using System;

public class Kata
{
    public static int HexToDec(string hexString)
    {
        return Convert.ToInt32(hexString.TrimStart('-'), 16) * (hexString[0] == '-' ? -1 : 1);
    }
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(1, Kata.HexToDec("1"));
      Assert.AreEqual(10, Kata.HexToDec("a"));
      Assert.AreEqual(16, Kata.HexToDec("10"));
      Assert.AreEqual(255, Kata.HexToDec("FF"));
      Assert.AreEqual(-12, Kata.HexToDec("-C"));      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int i=0;i<40;i++)
      {
        var n = rand.Next(1, (int)Math.Pow(10, rand.Next(1,10)));        
        var hexString = Convert.ToString(n, 16);
        
        if(rand.Next(0,2) == 0)
        {
          hexString = "-" + hexString;
        }        
        
        Func<string,int> myHexToDec = delegate (string hS)
        {
          var number = Convert.ToInt32(hS.Replace("-", ""), 16);
          return hS.StartsWith("-") ? number * -1 : number;        
        };
        
        Assert.AreEqual(myHexToDec(hexString), Kata.HexToDec(hexString));     
      }
    }
  }
}
