/*Challenge link:https://www.codewars.com/kata/56eb0be52caf798c630013c0/train/csharp
Question:
Friday 13th or Black Friday is considered as unlucky day. Calculate how many unlucky days are in the given year.

Find the number of Friday 13th in the given year.

Input: Year in Gregorian calendar as integer.

Output: Number of Black Fridays in the year as an integer.

Examples:

unluckyDays(2015) == 3
unluckyDays(1986) == 1
*/

//***************Solution********************

//from month 1 to 12 (Jan to Dec)
//select date 13, count the number of day equals to Friday
//return the result
using System;
using System.Linq;

public class Kata
{
  public static int UnluckyDays(int year)
	{
		return Enumerable.Range(1, 12).Select(x => new DateTime(year, x, 13)).Count(x => x.DayOfWeek == DayOfWeek.Friday);
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
      Assert.AreEqual(2, Kata.UnluckyDays(2819));
      Assert.AreEqual(2, Kata.UnluckyDays(2792));
      Assert.AreEqual(2, Kata.UnluckyDays(2723));
      Assert.AreEqual(1, Kata.UnluckyDays(1909));
      Assert.AreEqual(2, Kata.UnluckyDays(1812));
      Assert.AreEqual(2, Kata.UnluckyDays(1618));
      Assert.AreEqual(1, Kata.UnluckyDays(2132));
      Assert.AreEqual(3, Kata.UnluckyDays(2065));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      Func<int,int> sol = delegate (int year)
      {
        var count = 0;
        for(var i=1;i<=12;i++)
        { 
          if(new DateTime(year, i, 13).DayOfWeek == System.DayOfWeek.Friday)
          {
            count++;
          }
        }
        return count;
      };      

      for (var i=0;i<40;i++)
      {
        var y = rand.Next(1583,2999);
        Assert.AreEqual(sol(y), Kata.UnluckyDays(y),"It should work for random inputs too");   
      }
    }
  }
}
