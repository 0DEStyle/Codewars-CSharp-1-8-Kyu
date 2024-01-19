/*Challenge link:https://www.codewars.com/kata/5ae329c3d2ee27a1f20000f2/train/csharp
Question:
As a good developer you have to practice a lot. One way to achieve this is to finish one kata every day after work.

But of course you won't have time for that every day. So maybe you skip one week and think you can do two katas every day in the following week. But of course you lose track of how many katas you should have finished until today.

To control yourself, write a function which gets the start date of your codewars registration and returns how many katas you should have finished until today. We will ignore public holidays.

Example:.

var registrationDate = new DateTime(2018, 01, 01);
var solvedKatas = KataCalculator.SolvedKatasSince(registrationDate, DateTime.Today);
*/

//***************Solution********************
//start from registrationDate, while currentData is less than registrationDate, add 1 day to start
//while day of week is not weekend, increase count by 1
using System;

public class KataCalculator{
  public static int SolvedKatasSince(DateTime registrationDate, DateTime currentDate){
    int count = 0;
    for(var start = registrationDate; start < currentDate; start = start.AddDays(1))
      if(start.DayOfWeek !=  DayOfWeek.Saturday && start.DayOfWeek !=  DayOfWeek.Sunday)
        count++;
    
      return count;
  }
}

//solution 2
using System;
using System.Linq;

public class KataCalculator
{
  public static int SolvedKatasSince(DateTime registrationDate, DateTime currentDate)
  {
    return Enumerable.Range(0, (int) (currentDate - registrationDate).TotalDays)
      .Select(x => (int) registrationDate.AddDays(x).DayOfWeek)
      .Count(x => x != 6 && x != 0);
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void One_Day_Should_Return_1_Finished_Kata()
    {
      Assert.AreEqual(1,KataCalculator.SolvedKatasSince(new DateTime(2018, 01, 01), new DateTime(2018, 01, 2)));
    }
  
    [Test]
    public void One_Week_Should_Return_5_Finished_Katas()
    {
      Assert.AreEqual(5,KataCalculator.SolvedKatasSince(new DateTime(2018, 01, 01), new DateTime(2018, 01, 08)));
    }
    
    [Test]
    public void Four_Weeks_Should_Return_20_Finished_Katas()
    {
      Assert.AreEqual(20,KataCalculator.SolvedKatasSince(new DateTime(2018, 01, 01), new DateTime(2018, 01, 29)));
    }
    
    [Test]
    public void January_2018_Should_Return_23_Finished_Katas()
    {
      Assert.AreEqual(23,KataCalculator.SolvedKatasSince(new DateTime(2018, 01, 01), new DateTime(2018, 02, 01)));
    }
    
    [Test]
    public void February_2018_Should_Return_20_Finished_Katas()
    {
      Assert.AreEqual(20,KataCalculator.SolvedKatasSince(new DateTime(2018, 02, 01), new DateTime(2018, 03, 01)));
    }
    
    [Test]
    public void April_2018_Should_Return_21_Finished_Katas()
    {
      Assert.AreEqual(21,KataCalculator.SolvedKatasSince(new DateTime(2018, 04, 01), new DateTime(2018, 05, 01)));
    }
  
    [Test]
    public void Year_2017_Should_Return_260_Finished_Katas()
    {
      Assert.AreEqual(260,KataCalculator.SolvedKatasSince(new DateTime(2017, 01, 01), new DateTime(2017, 12, 31)));
    }
    
    [Test]
    public void Year_2017_And_2018_Should_Return_520_Finished_Katas()
    {
      Assert.AreEqual(520,KataCalculator.SolvedKatasSince(new DateTime(2017, 01, 01), new DateTime(2018, 12, 31)));
    }
    
    [Test]
    public void Current_Date_With_Random_Date_Up_To_One_Year_Ago()
    {
      var randomDateUpToOneYearAgo = DateTime.Today.AddDays(- new Random().Next(365));      
      var expectedDays = CalculateExpectedDays(randomDateUpToOneYearAgo);      
    
      Assert.AreEqual(expectedDays,KataCalculator.SolvedKatasSince(randomDateUpToOneYearAgo, DateTime.Today));
    }
    
    [Test]
    public void Current_Date_With_Random_Date_Up_To_Five_Years_Ago()
    {
      var randomDateUpToFiveYearsAgo = DateTime.Today.AddDays(- new Random().Next(365 * 5));      
      var expectedDays = CalculateExpectedDays(randomDateUpToFiveYearsAgo);
    
      Assert.AreEqual(expectedDays,KataCalculator.SolvedKatasSince(randomDateUpToFiveYearsAgo, DateTime.Today));
    }
    
    private int CalculateExpectedDays(DateTime randomDate)
    {
        return Enumerable.Range(0, (int)DateTime.Today.Subtract(randomDate).TotalDays)
                         .Select(x => randomDate.AddDays(x))
                         .Count(x => x.DayOfWeek != DayOfWeek.Saturday && x.DayOfWeek != DayOfWeek.Sunday);
    }
  }
}
