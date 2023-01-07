/*Challenge link:https://www.codewars.com/kata/56530b444e831334c0000020/train/csharp
Question:
The male gametes or sperm cells in humans and other mammals are heterogametic and contain one of two types of sex chromosomes. They are either X or Y. The female gametes or eggs however, contain only the X sex chromosome and are homogametic.

The sperm cell determines the sex of an individual in this case. If a sperm cell containing an X chromosome fertilizes an egg, the resulting zygote will be XX or female. If the sperm cell contains a Y chromosome, then the resulting zygote will be XY or male.

Determine if the sex of the offspring will be male or female based on the X or Y chromosome present in the male's sperm.

If the sperm contains the X chromosome, return "Congratulations! You''re going to have a daughter."; If the sperm contains the Y chromosome, return "Congratulations! You're going to have a son.";
*/

//***************Solution********************
//return message accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string ChromosomeCheck(string s) => s == "XY" ? "Congratulations! You're going to have a son." : "Congratulations! You're going to have a daughter."; 
}

//solution 2
public static string ChromosomeCheck(string sperm)
  {
    return $"Congratulations! You're going to have a {sperm == "XY" ? "son" : "daughter"}.";
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
      Assert.AreEqual("Congratulations! You're going to have a son.", Kata.ChromosomeCheck("XY"));
      Assert.AreEqual("Congratulations! You're going to have a daughter.", Kata.ChromosomeCheck("XX"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<40;r++)
      {
        var sperm = rand.Next(0,2) == 0 ? "XX" : "XY";
        var expected = sperm.Contains("Y") ? "Congratulations! You\'re going to have a son." : "Congratulations! You're going to have a daughter.";
        Assert.AreEqual(expected, Kata.ChromosomeCheck(sperm));
      }
    }
  }
}
