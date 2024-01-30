/*Challenge link:https://www.codewars.com/kata/56833b76371e86f8b6000015/train/csharp
Question:
Implement String#to_cents, which should parse prices expressed as $1.23 and return number of cents, or in case of bad format return nil.
*/

//***************Solution********************
//$ number.cents
//check pattern: ^\$\d*\...\z , 
//beginning, escape character for $, 
//followed by digit with quantity 0 or more
//. followed by any char x2 until end of string

//check null int, convert to double,price from char 1 upto end, replace . with ,
//else return null
using System;
using System.Text.RegularExpressions;

public static class Kata{
    public static int? ToCents(this string price){
      if(Regex.IsMatch(price, @"^\$\d*\...\z"))
        return (int?) (Convert.ToDouble(price[1..].Replace('.', ',')));
    return null;
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;

[TestFixture]
public class KataTest
{
    private Random random = new Random();

    public int? ToCents(string price)
    {
        var m = Regex.Match(price, @"^[$](?<Val>\d+)\.(?<Cents>\d{2})$");

        if (m.Length == 0)
            return null;

        return int.Parse(m.Groups["Val"].Value + m.Groups["Cents"].Value);
    }

    [Test]
    public void _0_BasicTests()
    {
        Assert.AreEqual(null, "".ToCents());
        Assert.AreEqual(null, "1".ToCents());
        Assert.AreEqual(null, "1.23".ToCents());
        Assert.AreEqual(null, "$1".ToCents());
        Assert.AreEqual(123, "$1.23".ToCents());
        Assert.AreEqual(9999, "$99.99".ToCents());
        Assert.AreEqual(1234567890, "$12345678.90".ToCents());
        Assert.AreEqual(969, "$9.69".ToCents());
        Assert.AreEqual(970, "$9.70".ToCents());
        Assert.AreEqual(971, "$9.71".ToCents());
        Assert.AreEqual(69, "$0.69".ToCents());
        Assert.AreEqual(null, "$9.69$4.3.7".ToCents());
        Assert.AreEqual(null, "$9.692".ToCents());
        Assert.AreEqual(null, "$1.23\n".ToCents());
        Assert.AreEqual(null, "\n$1.23".ToCents());
    }

    [Test]
    public void _1_RandomTests()
    {
        for (int i = 0; i < 40; i++)
        {
            string amount = $"${random.Next(0, 10000)}.{random.Next(0, 115)}";

            if (random.NextDouble() <= 0.5)
            {
                amount = amount.Insert(random.Next(amount.Length - 1), "$.01234fS"[random.Next(9)].ToString());
            }

            Assert.AreEqual(ToCents(amount), amount.ToCents());
        }
    }
}
