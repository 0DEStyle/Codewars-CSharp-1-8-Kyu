/*Challenge link:https://www.codewars.com/kata/56eb16655250549e4b0013f4/train/csharp
Question:
What is your favourite day of the week? Check if it's the most frequent day of the week in the year.

You are given a year as integer (e. g. 2001). You should return the most frequent day(s) of the week in that year. The result has to be a list of days sorted by the order of days in week (e. g. ['Monday', 'Tuesday'], ['Saturday', 'Sunday'], ['Monday', 'Sunday']). Week starts with Monday.

Input: Year as an int.

Output: The list of most frequent days sorted by the order of days in week (from Monday to Sunday).

Preconditions:

Week starts on Monday.
Year is between 1583 and 4000.
Calendar is Gregorian.
Examples (input -> output):
* 2427 -> ['Friday']
* 2185 -> ['Saturday']
* 2860 -> ['Thursday', 'Friday']
*/

//***************Solution********************
using System;

public class Kata{
  public static string[] MostFrequentDays(int year){
    //create new DateTime (year,month,day), get DayOfWeek and convert to string
    var jan1 = ((new DateTime(year, 1, 1)).DayOfWeek).ToString();
    var jan2 = ((new DateTime(year, 1, 2)).DayOfWeek).ToString();
    
    //if year is not a Leap year (year with feb 29th), create and return array with jan1
    //else if jan1 is Sunday, create and return array with jan2, jan1
    //else return array with jan1, jan2
    return !DateTime.IsLeapYear(year) ?  
      new []{jan1} : jan1 == "Sunday" ? 
      new []{jan2, jan1} : new []{jan1, jan2}; 
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;

namespace Solution 
{

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new [] { "Monday" }, Kata.MostFrequentDays(1770));
      Assert.AreEqual(new [] { "Monday" }, Kata.MostFrequentDays(2001));
      Assert.AreEqual(new [] { "Monday", "Tuesday" }, Kata.MostFrequentDays(1968));
      Assert.AreEqual(new [] { "Saturday" }, Kata.MostFrequentDays(1785));
      Assert.AreEqual(new [] { "Saturday" }, Kata.MostFrequentDays(1910));
      Assert.AreEqual(new [] { "Saturday" }, Kata.MostFrequentDays(2135));
      Assert.AreEqual(new [] { "Sunday" }, Kata.MostFrequentDays(3043));
      Assert.AreEqual(new [] { "Sunday" }, Kata.MostFrequentDays(3150));
      Assert.AreEqual(new [] { "Thursday" }, Kata.MostFrequentDays(3361));
      Assert.AreEqual(new [] { "Tuesday" }, Kata.MostFrequentDays(1901));
      Assert.AreEqual(new [] { "Tuesday" }, Kata.MostFrequentDays(3230));
      Assert.AreEqual(new [] { "Wednesday" }, Kata.MostFrequentDays(1794));
      Assert.AreEqual(new [] { "Wednesday" }, Kata.MostFrequentDays(1986));
      Assert.AreEqual(new [] { "Monday", "Sunday" }, Kata.MostFrequentDays(1984));
      Assert.AreEqual(new [] { "Saturday", "Sunday" }, Kata.MostFrequentDays(2000));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,string[]> sol = delegate (int year)
      {
        var dayNames = new string[] { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
  
        var first = new DateTime(year, 1, 1);
        var last = new DateTime(year, 12, 31);
 
        if(first.DayOfWeek == last.DayOfWeek)
        {
          return new string[] {first.DayOfWeek.ToString()};
        }

        return new string[] { first.DayOfWeek.ToString(), last.DayOfWeek.ToString() }.OrderBy(d => Array.IndexOf(dayNames, d)).ToArray();
      };
      
      for (var qu=0;qu<100;qu++)
      { 
        var y = rand.Next(1583, 4001);
        Assert.AreEqual(sol(y), Kata.MostFrequentDays(y), "It should work for random inputs too");  
      }
    }
  }
}
