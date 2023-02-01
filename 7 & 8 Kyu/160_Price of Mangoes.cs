/*Challenge link:https://www.codewars.com/kata/57a77726bb9944d000000b06/train/csharp
Question:
There is a "3 for 2" (or "2+1" if you like) offer on mangoes. For a given quantity and price (per mango), calculate the total cost of the mangoes.

Examples
mango(2, 3) ==> 6    # 2 mangoes for $3 per unit = $6; no mango for free
mango(3, 3) ==> 6    # 2 mangoes for $3 per unit = $6; +1 mango for free
mango(5, 3) ==> 12   # 4 mangoes for $3 per unit = $12; +1 mango for free
mango(9, 5) ==> 30   # 6 mangoes for $5 per unit = $30; +3 mangoes for free
*/

//***************Solution********************
//apply algorithm
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class Kata{
  public static int Mango(int quantity, int price) => (quantity - (quantity / 3)) * price;
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
      Assert.AreEqual(6, Kata.Mango(3, 3));
      Assert.AreEqual(30, Kata.Mango(9, 5));
      Assert.AreEqual(6, Kata.Mango(2, 3));
      Assert.AreEqual(15, Kata.Mango(7, 3));
      Assert.AreEqual(231, Kata.Mango(31, 11));
      Assert.AreEqual(20, Kata.Mango(14, 2));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int i = 0; i < 10; i++)
      {
        var price = rand.Next(1,10);
        var quantity = rand.Next(1,10);
        
        var mango = quantity / 3 * price * 2 + (quantity % 3 * price);
      
        Assert.AreEqual(mango, Kata.Mango(quantity, price));
      }
    }
  }
}
