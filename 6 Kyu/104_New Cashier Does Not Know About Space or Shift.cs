/*Challenge link:https://www.codewars.com/kata/5d23d89906f92a00267bb83d/train/csharp
Question:
Some new cashiers started to work at your restaurant.

They are good at taking orders, but they don't know how to capitalize words, or use a space bar!

All the orders they create look something like this:

"milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza"

The kitchen staff are threatening to quit, because of how difficult it is to read the orders.

Their preference is to get the orders as a nice clean string with spaces and capitals like so:

"Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke"

The kitchen staff expect the items to be in the same order as they appear in the menu.

The menu items are fairly simple, there is no overlap in the names of the items:

1. Burger
2. Fries
3. Chicken
4. Pizza
5. Sandwich
6. Onionrings
7. Milkshake
8. Coke
*/

//***************Solution********************

//join array string by space
//from the string select many if input string matches lower f.count
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;
using System.Linq;

public static class Kata{
  public static string GetOrder(string input) => 
    string.Join(" ", new []{"Burger", "Fries", "Chicken", "Pizza", "Sandwich", "Onionrings", "Milkshake", "Coke"}
    .SelectMany(f => Enumerable.Repeat(f, Regex.Matches(input, f.ToLower()).Count)));
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
[TestFixture]
public class OrderTest
{
  [Test]
  public void Test1()
  {
    Assert.AreEqual("Burger Fries Chicken Pizza Pizza Pizza Sandwich Milkshake Milkshake Coke", 
    Kata.GetOrder("milkshakepizzachickenfriescokeburgerpizzasandwichmilkshakepizza"));
  }
  
  [Test]
  public void Test2()
  {
    Assert.AreEqual("Burger Fries Fries Chicken Pizza Sandwich Milkshake Coke", 
    Kata.GetOrder("pizzachickenfriesburgercokemilkshakefriessandwich"));
  }
  
  [Test]
  public void Test3()
  {
    Assert.AreEqual("Burger Burger Fries Fries Fries Fries Fries Fries Pizza Sandwich Coke", 
    Kata.GetOrder("burgerfriesfriesfriesfriesfriespizzasandwichcokefriesburger"));
  }
  
  [Test]
  public void RandomTest1()
  {
    string input = GenerateRandom(10);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void RandomTest2()
  {
    string input = GenerateRandom(20);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void RandomTest3()
  {
    string input = GenerateRandom(30);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void RandomTest4()
  {
    string input = GenerateRandom(50);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void RandomTest5()
  {
    string input = GenerateRandom(100);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void RandomTestHugeOrder()
  {
    string input = GenerateRandom(1000);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  [Test]
  public void TenThousandRandomItemOrder()
  {
    string input = GenerateRandom(10000);
    Assert.AreEqual(GetOrderWorking(input), Kata.GetOrder(input));
  }
  
  public static string GenerateRandom(int n)
  {
    string[] menu = {"burger", "fries", "chicken", "pizza", "sandwich", "onionrings", "milkshake", "coke"};
    
    string output = String.Empty;
	  
	  Random random = new Random();
    
    for (int i = 0; i < n; i++)
    {
      output = output + menu[random.Next(menu.Length)];
    }
    
    return output;
  }
  
  public static string GetOrderWorking(string input)
  {	
  	string[] menu = {
  		"Burger",
  		"Fries",
  		"Chicken",
  		"Pizza",
  		"Sandwich",
  		"Onionrings",
  		"Milkshake",
  		"Coke",
  	};
  	
  	List<string> output = new List<string>();
  	
  	foreach(string item in menu)
  	{			
  		for(int i = 0; i < input.Length - item.Length + 1; i++)
  		{
  			if(input.Substring(i, item.Length).Equals(item, StringComparison.OrdinalIgnoreCase))
  			{
  				output.Add(item);
  			}
  		}
  	}
  	
  	return string.Join(" ", output);
  }
}
