/*Challenge link:https://www.codewars.com/kata/539de388a540db7fec000642/train/csharp
Question:

Story
Your online store likes to give out coupons for special occasions. Some customers try to cheat the system by entering invalid codes or using expired coupons.

Task
Your mission:
Write a function called checkCoupon which verifies that a coupon code is valid and not expired.

A coupon is no more valid on the day AFTER the expiration date. All dates will be passed as strings in this format: "MONTH DATE, YEAR".

Examples:
CheckCoupon("123", "123", "July 9, 2015", "July 9, 2015")  ==  true
CheckCoupon("123", "123", "July 9, 2015", "July 2, 2015")  ==  false

*/

//***************Solution********************
//parse the current date and expiration date using datetime.
//compare all condition and return true or false.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;

public static class Kata{
    public static bool CheckCoupon(string enteredCode, string correctCode, string currentDate, string expirationDate) =>
      enteredCode == correctCode && DateTime.Parse(currentDate) <= DateTime.Parse(expirationDate);
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class CouponCodeTest
{
  [Test]
  public static void ValidCoupon()
  {
    Assert.AreEqual(true, Kata.CheckCoupon("123","123","September 5, 2014","October 1, 2014"));
  }
  
  [Test]
  public static void DoesNotMatchCorrectCode()
  {
    Assert.AreEqual(false, Kata.CheckCoupon("123a","123","September 5, 2014","October 1, 2014"));
  }
  
  [Test]
  public static void ExpiredCoupon()
  {
    Assert.AreEqual(false, Kata.CheckCoupon("12abcd3","12abcd3","January 5, 2014","January 1, 2014"));
  }
  
  [Test]
  public static void LastDayOfValidity()
  {
    Assert.AreEqual(true, Kata.CheckCoupon("123ablqc0","123ablqc0","July 5, 2000","July 5, 2000"));
  }
  
  [Test]
  public static void ExpirationInLaterYear()
  {
    Assert.AreEqual(true, Kata.CheckCoupon("abc","abc","November 8, 2013","November 5, 2014"));
  }
  
  [Test]
  public static void OldCouponButValid()
  {
    Assert.AreEqual(false, Kata.CheckCoupon("a12v564","a12v564","March 25, 1998","March 5, 1998"));
  }
  
  [Test]
  public static void RandomTests()
  {
    string aYeahWoo,bYeahWoo,cYeahWoo,dYeahWoo;
    
    for(int i = 0; i < 15; i++)
    {
      aYeahWoo=Helper.RandCode();
      bYeahWoo=Helper.RandCode();
      cYeahWoo=Helper.RandDate();
      dYeahWoo=Helper.RandDate();
      Assert.AreEqual(Helper.MasterCheckYeah(aYeahWoo,bYeahWoo,cYeahWoo,dYeahWoo), Kata.CheckCoupon(aYeahWoo,bYeahWoo,cYeahWoo,dYeahWoo));
    }
  }
  
  [Test]
  public static void OneMoreValidCouponToBeSure()
  {
    Assert.AreEqual(true, Kata.CheckCoupon("0a12bc64","0a12bc64","March 6, 2005","March 5, 2006"));
  }
}

public class Helper
{
  private static Random r = new Random();
  
  public static string RandMonth()
  {
    string[] month = new string[12] {"January","February","March","April","May","June","July","August","September","October","November","December"};
    return month[r.Next(0, 11)];
  }
  
  public static int RandDay()
  {
    return r.Next(1, 28);
  }
  
  public static int RandYear()
  {
    return 1980 + r.Next(1, 40);
  }
  
  public static string RandDate()
  {
    return RandMonth() + " " + RandDay().ToString() + ", " + RandYear().ToString();
  }
  
  public static string RandCode()
  {
    string[] code = new string[3] {"bdab987ba8f","5nyi7n868u696u0u6", "lkhk5940gonc"};
    return code[r.Next(0, 2)];
  }
  
  public static bool MasterCheckYeah(string enteredCode, string correctCode, string currentDate, string expirationDate)
  {
    return enteredCode == correctCode && Convert.ToDateTime(currentDate) <= Convert.ToDateTime(expirationDate);
  }
}
