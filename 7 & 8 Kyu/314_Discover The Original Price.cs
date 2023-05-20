/*Challenge link:https://www.codewars.com/kata/552564a82142d701f5001228/train/csharp
Question:
We need to write some code to return the original price of a product, the return type must be of type decimal and the number must be rounded to two decimal places.

We will be given the sale price (discounted price), and the sale percentage, our job is to figure out the original price.

For example:
Given an item at $75 sale price after applying a 25% discount, the function should return the original price of that item before applying the sale percentage, which is ($100.00) of course, rounded to two decimal places.

DiscoverOriginalPrice(75, 25) => 100.00M where 75 is the sale price (discounted price), 25 is the sale percentage and 100 is the original price
*/

//***************Solution********************
//apply algorithm, then round to 2 decimal places.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
public static class Kata{
    public static decimal DiscoverOriginalPrice(decimal discountedPrice, decimal salePercentage) =>
       Math.Round(discountedPrice / ((100 - salePercentage) / 100),2);
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class CodeWarsTest
{
        [Test]
        public static void ShouldReturnOriginal()
        {
            Assert.AreEqual(100.00M,Kata.DiscoverOriginalPrice(75M,25M));
        }
        
        [Test]
        public static void ShouldReturnOriginal2()
        {
            Assert.AreEqual(421.00M,Kata.DiscoverOriginalPrice(373.85M,11.2M));
        }
        
        [Test]
        public static void ShouldReturnOriginal3()
        {
            Assert.AreEqual(552.91M,Kata.DiscoverOriginalPrice(458.2M,17.13M));
        }
    }
