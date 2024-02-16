/*Challenge link:https://www.codewars.com/kata/5787628de55533d8ce000b84/train/csharp
Question:
A very easy task for you!

You have to create a method, that corrects a given date string. There was a problem in addition, so many of the date strings are broken. Date-Format is european. That means "DD.MM.YYYY".

Some examples:

"30.02.2016" -> "01.03.2016"
"40.06.2015" -> "10.07.2015"
"11.13.2014" -> "11.01.2015"
"99.11.2010" -> "07.02.2011"

If the input-string is null or empty return exactly this value!
If the date-string-format is invalid, return null.

Hint: Correct first the month and then the day!

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have created other katas. Have a look if you like coding and challenges.
*/

//***************Solution********************
/*beter description
the months need to be reduced and applied to the years, 
and the days need to be reduced and added to the months 
so that they coorespond to the number of days in that month as well (including leap year). 
*/

using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Date{
  public static string Correct(string dateString){ 
    if(dateString == "" || dateString == null) return dateString;
    
    //10 characters, e.g. 01.03.2016
    if(Regex.Matches(dateString,"[0-9.]").Count != 10) return null;
    
    //split string into date, month, year
    var data = dateString.Split('.').Select(x => int.Parse(x) - 1).ToArray();
    
       //date ref: https://learn.microsoft.com/en-us/dotnet/standard/base-types/custom-date-and-time-format-strings
    return new DateTime().AddYears(data[2])
                         .AddMonths(data[1])
                         .AddDays(data[0])
                         .ToString("dd.MM.yyyy");
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Tests
{
  [Test]
  public void NullTest()
  {
    Assert.AreEqual(null, Date.Correct(null));
  }
  
  [Test]
  public void EmptyTest()
  {
    Assert.AreEqual("", Date.Correct(""));
  }
  
  [Test]
  public void InvalidFormatTests()
  {
    Assert.AreEqual(null, Date.Correct("01112016"));
    Assert.AreEqual(null, Date.Correct("01,11,2016"));
    Assert.AreEqual(null, Date.Correct("0a.1c.2016"));
  } 
  
  [Test]
  public void CorrectionTests()
  {
    Assert.AreEqual("03.12.2016", Date.Correct("03.12.2016"));
    Assert.AreEqual("01.03.2016", Date.Correct("30.02.2016"));
    Assert.AreEqual("10.07.2015", Date.Correct("40.06.2015"));
    Assert.AreEqual("11.01.2015", Date.Correct("11.13.2014"));
    Assert.AreEqual("02.02.2015", Date.Correct("33.13.2014"));
    Assert.AreEqual("07.02.2011", Date.Correct("99.11.2010"));
    Assert.AreEqual("01.01.2017", Date.Correct("32.12.2016"));
  }  
  
  [Test]  
  public void RandomTests()
  {
    Random rand = new Random((int)DateTime.Now.Ticks);
    
    for(int i = 0; i < 20; i++)
    {
      var day = rand.Next(18, 89);
      var month = rand.Next(56, 89);
      var year = rand.Next(1000, 3000);
      string dateString = string.Format("{0:D2}.{1:D2}.{2:D4}", day, month, year);
      
      if(month > 12)
      {
        year += (month-1) / 12;
        month = (month-1) % 12 + 1;
      }
    
      while(day > DateTime.DaysInMonth(year, month))
      {
        day -= DateTime.DaysInMonth(year, month);
        if(month <12)
        {
          month++;       
        }
        else
        {
          year++;
          month = 1;
        }
      }   
      
      string expected = string.Format("{0:D2}.{1:D2}.{2:D4}", day, month, year);
      Assert.AreEqual(expected, Date.Correct(dateString));
    }
  }
}
