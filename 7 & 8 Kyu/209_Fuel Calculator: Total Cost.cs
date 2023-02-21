/*Challenge link:
Question:
In this kata you will have to write a function that takes litres and pricePerLitre (in dollar) as arguments.

Purchases of 2 or more litres get a discount of 5 cents per litre, purchases of 4 or more litres get a discount of 10 cents per litre, and so on every two litres, up to a maximum discount of 25 cents per litre. But total discount per litre cannot be more than 25 cents. Return the total cost rounded to 2 decimal places. Also you can guess that there will not be negative or non-numeric inputs.

Good Luck!

Note
1 Dollar = 100 Cents
*/

//***************Solution********************
//check if litres/2 is less than or equal to 5, to qualify the discount range
//if so, apply the formula
//else cap the discount range at 0.25
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public class Kata{
  public static double FuelPrice(double litres, double pricePerLitre)=> 
    litres/2 <= 5? Math.Round(litres * (pricePerLitre - (0.05)*Math.Floor(litres/2)),2) 
    : Math.Round(litres * (pricePerLitre - 0.25),2);
}

//solution 2
//using Math,Min to swap between values.
using System;

public class Kata
{
  public static double FuelPrice(double l, double p) => Math.Round(l * (p - Math.Min(0.25, 0.05 * Math.Floor(l / 2))), 2);
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
      Assert.AreEqual(5.65, Kata.FuelPrice(5, 1.23));
      Assert.AreEqual(18.40, Kata.FuelPrice(8, 2.5));
      Assert.AreEqual(27.50, Kata.FuelPrice(5, 5.6));
      Assert.AreEqual(53.50, Kata.FuelPrice(10, 5.6));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<double,double,double> myFuelPrice = delegate (double litres, double pricePerLiter)
      {
        var discountPerLiter = Math.Floor(litres / 2);
  
        var totalDiscount = 0.05 * discountPerLiter;
  
        if (totalDiscount > 0.25) 
        {
          totalDiscount = 0.25;
        }          
  
        var priceAfterDiscount = pricePerLiter - totalDiscount;
  
        var totalPricePerLitre = litres * priceAfterDiscount;
  
        return Math.Round(totalPricePerLitre, 2);
      };
      
      Func<double, double, double, double> randomFloatBetween = delegate (double minValue, double maxValue, double precision)
      {       
        return Math.Round(rand.NextDouble() * (maxValue - minValue) + minValue, 2);        
      };
      
      for (var i = 0; i < 97; i++) 
      {
        var amount = rand.Next(1, 200);
        var price = randomFloatBetween(0.5, 35.9, 2);
        
        Console.WriteLine("Testing for amount " + amount + " and price " + price);
        
        Assert.AreEqual(myFuelPrice(amount, price), Kata.FuelPrice(amount, price));  
      }
    }
  }
}
