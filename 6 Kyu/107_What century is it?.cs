/*Challenge link:https://www.codewars.com/kata/52fb87703c1351ebd200081f/train/csharp
Question:
Return the century of the input year. The input will always be a 4 digit string, so there is no need for validation.

Examples
"1999" --> "20th"
"2011" --> "21st"
"2154" --> "22nd"
"2259" --> "23rd"
"1124" --> "12th"
"2000" --> "20th"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static string WhatCentury(string year){
    //convert year to int and subtract 1, then divide 100 and plus 1
    //using string interpolation to format string
    //mod 10 to get the last digit, then switch case to get the correct suffix
    var c = (int.Parse(year) - 1) / 100 + 1;
    return $"{c}{c switch {< 20 => "th", _ => (c % 10) switch {1 => "st", 2 => "nd", 3 => "rd", _ => "th"}}}";
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class KataTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("20th", Kata.WhatCentury("1999"), "With input '1999' solution produced wrong output.");
      Assert.AreEqual("21st", Kata.WhatCentury("2011"), "With input '2011' solution produced wrong output.");
      Assert.AreEqual("22nd", Kata.WhatCentury("2154"), "With input '2154' solution produced wrong output.");
      Assert.AreEqual("23rd", Kata.WhatCentury("2259"), "With input '2259' solution produced wrong output.");
      Assert.AreEqual("13th", Kata.WhatCentury("1234"), "With input '1234' solution produced wrong output.");
      Assert.AreEqual("11th", Kata.WhatCentury("1023"), "With input '1023' solution produced wrong output.");
      Assert.AreEqual("20th", Kata.WhatCentury("2000"), "With input '2000' solution produced wrong output.");
//      Assert.AreEqual("9th", Kata.WhatCentury("850"), "With input '850' solution produced wrong output.");
//      Assert.AreEqual("3rd", Kata.WhatCentury("250"), "With input '250' solution produced wrong output.");
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      for(int i=0;i<100;i++)
      {
        var year = rand.Next(1000,9999).ToString();
        var century = MyWhatCentury(year);
        Assert.AreEqual(century, Kata.WhatCentury(year), "With input '" + year + "' solution produced wrong output.");
      }
    }
    
    public string MyWhatCentury(string year)
    {
      var century = (int)Math.Ceiling(double.Parse(year)/100);
    
      var addon = "th";
      if((century >= 20) || (century < 10))
      {
        if(century % 10 == 1)
        {
          addon = "st";
        }
        if(century % 10 == 2)
        {
          addon = "nd";
        }
        if(century % 10 == 3)
        {
          addon = "rd";
        }
      }
    
      return century + addon;
    }
  }
}
