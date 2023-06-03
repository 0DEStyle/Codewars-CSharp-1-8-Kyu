/*Challenge link:https://www.codewars.com/kata/5977618080ef220766000022/train/csharp
Question:
Create a function that converts US dollars (USD) to Chinese Yuan (CNY) . The input is the amount of USD as an integer, and the output should be a string that states the amount of Yuan followed by 'Chinese Yuan'

Examples (Input -> Output)
15  -> '101.25 Chinese Yuan'
465 -> '3138.75 Chinese Yuan'
The conversion rate you should use is 6.75 CNY for every 1 USD. All numbers should be represented as a string with 2 decimal places. (e.g. "21.00" NOT "21.0" or "21")
*/

//***************Solution********************
//using string interpolation, format result into 2 decimal places along with preset string
//return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata{
 public static string Usdcny(int usd) => $"{(usd*6.75):f2} Chinese Yuan";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTest1()
    {
      Assert.AreEqual(GetOutput(15), Kata.Usdcny(15), "Testing Usd value at: " +  15 
          + "\n Should return: " + GetOutput(15));
    }
    
    [Test]
    public void BasicTest2()
    {
      Assert.AreEqual(GetOutput(465), Kata.Usdcny(465), "Testing Usd value at: " +  465 
          + "\n Should return: " + GetOutput(465));
    }
    
    [Test]
    public void RandomTests()
    {
      Random r = new Random();
      for(int i = 0; i < 100; i++)
        {
          int usd = r.Next(0, 10000);
          Assert.AreEqual(GetOutput(usd), Kata.Usdcny(usd), "Testing Usd value at: " +  usd 
          + "\n Should return: " + GetOutput(usd));
        }
    }
    
    private string GetOutput(int dollar)
    {
      string output = "" + (dollar*6.75);
      if(output[output.Length - 3] == '.') {return output + " Chinese Yuan";}
      if(output[output.Length - 2] == '.') {return output + "0 Chinese Yuan";}
      else {return output + ".00 Chinese Yuan";}
    }
  }
}
