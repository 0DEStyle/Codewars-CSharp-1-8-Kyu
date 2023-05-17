/*Challenge link:https://www.codewars.com/kata/585b1fafe08bae9988000314/train/csharp
Question:
Given a string made of digits [0-9], return a string where each digit is repeated a number of times equals to its value.

Examples
explode("312")
should return :

"333122"
explode("102269")
should return :

"12222666666999999999"
*/

//***************Solution********************
//create new string, select each character and repeat character(convert to int) amount of time
//Concatenate the character and return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public class Digits{
  public static string Explode(string s) =>
    string.Concat(s.Select(c => new String(c, int.Parse(c.ToString()))));
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public static class DigitsTests 
{
    [TestCase("", "")]
    [TestCase("0", "")]
    [TestCase("1", "1")]
    [TestCase("2", "22")]
    [TestCase("3", "333")]
    [TestCase("4", "4444")]
    [TestCase("5", "55555")]
    [TestCase("6", "666666")]
    [TestCase("7", "7777777")]
    [TestCase("8", "88888888")]
    [TestCase("9", "999999999")]
    [TestCase("000", "")]
    [TestCase("312", "333122")]
    [TestCase("102269","12222666666999999999")]
    [TestCase("09876543456781203745372900871624437492009817162443739030973653", "99999999988888888777777766666655555444433344445555566666677777778888888812233377777774444555553337777777229999999998888888877777771666666224444444433377777774444999999999229999999998888888817777777166666622444444443337777777333999999999333999999999777777733366666655555333")]
    public static void ExplodeTests(string s, string result) 
    {
        Assert.AreEqual(result, Digits.Explode(s), $"'{s}' is exploded incorrectly");
    }
}  
