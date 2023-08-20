/*Challenge link:https://www.codewars.com/kata/52724507b149fa120600031d/train/csharp
Question:
Create a function that transforms any positive number to a string representing the number in words. The function should work for all numbers between 0 and 999999.

Examples
number2words(0)  ==>  "zero"
number2words(1)  ==>  "one"
number2words(9)  ==>  "nine"
number2words(10)  ==>  "ten"
number2words(17)  ==>  "seventeen"
number2words(20)  ==>  "twenty"
number2words(21)  ==>  "twenty-one"
number2words(45)  ==>  "forty-five"
number2words(80)  ==>  "eighty"
number2words(99)  ==>  "ninety-nine"
number2words(100)  ==>  "one hundred"
number2words(301)  ==>  "three hundred one"
number2words(799)  ==>  "seven hundred ninety-nine"
number2words(800)  ==>  "eight hundred"
number2words(950)  ==>  "nine hundred fifty"
number2words(1000)  ==>  "one thousand"
number2words(1002)  ==>  "one thousand two"
number2words(3051)  ==>  "three thousand fifty-one"
number2words(7200)  ==>  "seven thousand two hundred"
number2words(7219)  ==>  "seven thousand two hundred nineteen"
number2words(8330)  ==>  "eight thousand three hundred thirty"
number2words(99999)  ==>  "ninety-nine thousand nine hundred ninety-nine"
number2words(888888)  ==>  "eight hundred eighty-eight thousand eight hundred eighty-eight"
*/

//***************Solution********************
public class NumberTranslation{
  //check if n is less than or equal to 0, if so, return "zero" else go to N2W
    public static string Number2Words(int n) => n <= 0 ? "zero" : N2W(n);

    private static string N2W(int n){
      
      //starting word
        var o = new[] { "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine",
            "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"};
      //trailing word
        var t = new[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
      
      //check if n is less than 1000, if so set (100, " hundred ") else set (1000, " thousand ")
        (int p, string s) = n < 1000 ? (100, " hundred ") : (1000, " thousand ");
        
      //if n is less than 20, use 0[n], 
        return (n < 20) ? o[n] :
      //else check if n is greater than 100, if so check n % 10 is 0,
      //if true add "" else add "-", acccess the correct index by using  t[n / 10], o[n % 10], then join the string together.
               (n < 100) ? string.Join(n % 10 == 0 ? "" : "-", t[n / 10], o[n % 10]) :
      //else recursivily get index with: s, N2W(n / p), N2W(n % p), join the result then Trim;
                           string.Join(s, N2W(n / p), N2W(n % p)).Trim();                
    }        
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class Number2WordsTests 
{

  [Test]
  public void SingleDigitNumberTest() 
  {
    
    Assert.AreEqual("zero", NumberTranslation.Number2Words(0));
    Assert.AreEqual("one", NumberTranslation.Number2Words(1));
    Assert.AreEqual("three", NumberTranslation.Number2Words(3));
    Assert.AreEqual("five", NumberTranslation.Number2Words(5));
    Assert.AreEqual("eight", NumberTranslation.Number2Words(8));
  }
  
  [Test]
  public void DoubleDigitNumberTest() 
  {
    
    Assert.AreEqual("ten", NumberTranslation.Number2Words(10));
    Assert.AreEqual("nineteen", NumberTranslation.Number2Words(19));
    Assert.AreEqual("twenty", NumberTranslation.Number2Words(20));
    Assert.AreEqual("twenty-two", NumberTranslation.Number2Words(22));
    Assert.AreEqual("forty", NumberTranslation.Number2Words(40));
    Assert.AreEqual("fifty-four", NumberTranslation.Number2Words(54));
    Assert.AreEqual("eighty", NumberTranslation.Number2Words(80));
    Assert.AreEqual("ninety-eight", NumberTranslation.Number2Words(98));
  }

  [Test]
  public void HundredsTest() 
  {
    
    Assert.AreEqual("one hundred", NumberTranslation.Number2Words(100));
    Assert.AreEqual("four hundred one", NumberTranslation.Number2Words(401));
    Assert.AreEqual("seven hundred ninety-three", NumberTranslation.Number2Words(793));
    Assert.AreEqual("eight hundred", NumberTranslation.Number2Words(800));
    Assert.AreEqual("six hundred fifty", NumberTranslation.Number2Words(650));
    Assert.AreEqual("nine hundred one", NumberTranslation.Number2Words(901));
    
  }
  
  [Test]
  public void ThousandsTest() 
  {
    
    Assert.AreEqual("one thousand", NumberTranslation.Number2Words(1000));
    Assert.AreEqual("one thousand three", NumberTranslation.Number2Words(1003));
    Assert.AreEqual("three thousand fifty-two", NumberTranslation.Number2Words(3052));
    Assert.AreEqual("seven thousand three hundred", NumberTranslation.Number2Words(7300));
    Assert.AreEqual("seven thousand two hundred seventeen", NumberTranslation.Number2Words(7217));
    Assert.AreEqual("eight thousand three hundred forty", NumberTranslation.Number2Words(8340));
    Assert.AreEqual("ninety-nine thousand nine hundred ninety-seven", NumberTranslation.Number2Words(99997));
    Assert.AreEqual("eight hundred eighty-eight thousand eight hundred eighty-seven", NumberTranslation.Number2Words(888887));
    
  }
  
  //******************************************************************
  public static string Number2WordsSolution(int n)
  {
      // numbers between 0 and 999999
      const string hundred = "hundred";
      const string thousand = "thousand";
  
      var arrZeroToNineteen = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
  
      var arrTwentyToNinety = new[] { "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
  
      var word = string.Empty;
      var div = 0;
      var mod = 0;
  
      if (n <= 19)
      {
          return arrZeroToNineteen[n];
      }
  
      if (n >= 20 && n <= 99)
      {
          div = n / 10;
          mod = n % 10;
  
          word = arrTwentyToNinety[div];
          if (mod > 0) word = word + "-" + Number2WordsSolution(mod);
  
          return word;
      }
  
      if (n >= 100 && n <= 999)
      {
           div = n / 100;
           mod = n % 100;
  
          if (mod > 0)
              word = arrZeroToNineteen[div] + " " + hundred + " " + Number2WordsSolution(mod);
          else
              word = arrZeroToNineteen[div] + " " + hundred;
  
          return word;
      }
  
      if (n >= 1000 && n <= 99999)
      {
           div = n / 1000;
           mod = n % 1000;
  
          if (mod > 0)
              word = Number2WordsSolution(div) + " " + thousand + " " + Number2WordsSolution(mod);
          else
              word = Number2WordsSolution(div) + " " + thousand;
  
          return word;
      }
  
      div = n / 1000;
      mod = n % 1000;
  
      if (div > 0)
      {
          word = Number2WordsSolution(div) + " " + thousand + " " + Number2WordsSolution(mod);
      }
      else if (mod > 0)
      {
          word = Number2WordsSolution(mod) + " " + thousand + " " + Number2WordsSolution(mod);
      }
      else
      {
          word = Number2WordsSolution(div) + " " + thousand;
      }
  
      return word;
  }
  //******************************************************************
  [Test]
  public void RandomTest(
      [Random(0, 999999, 5)] int n)
  {
     Assert.AreEqual(Number2WordsSolution(n), NumberTranslation.Number2Words(n));
  }
  

}
