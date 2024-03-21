/*Challenge link:https://www.codewars.com/kata/59619e4609868dd923000041/train/csharp
Question:
Sam has opened a new sushi train restaurant - a restaurant where sushi is served on plates that travel around the bar on a conveyor belt and customers take the plate that they like.

Sam is using Glamazon's new visual recognition technology that allows a computer to record the number of plates at a customer's table and the colour of those plates. The number of plates is returned as a string. For example, if a customer has eaten 3 plates of sushi on a red plate the computer will return the string "rrr".

Currently, Sam is only serving sushi on red plates as he's trying to attract customers to his restaurant. There are also small plates on the conveyor belt for condiments such as ginger and wasabi - the computer notes these in the string that is returned as a space; e.g. "rrr r" denotes 4 plates of red sushi and a plate of condiment.

Sam would like your help to write a program for the cashier's machine to read the string and return the total amount a customer has to pay when they ask for the bill. The current price for the dishes are as follows:

Red plates of sushi: $2 each - but every 5th one is free!
Condiments: free
Examples
"rr"           -->  4     # 2 plates
"rr rrr"       -->  8     # 5 plates, 1 free
"rrrrr rrrrr"  -->  16    # 10 plates, 2 free
*/

//***************Solution********************
//count 'r' red dish, every 5th dish is free
//(cnt - free) * 2$
using System.Linq;

public class Kata{
  public static int TotalBill(string s){
    int cnt = s.Count(x => x == 'r'), free = cnt/5;
    return (cnt - free)*2;
    }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class Test
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(4, Kata.TotalBill("rr"));
      Assert.AreEqual(8, Kata.TotalBill("rr rrr"));
      Assert.AreEqual(16, Kata.TotalBill("rr rrr rrr rr"));
      Assert.AreEqual(34, Kata.TotalBill("rrrrrrrrrrrrrrrrrr   rr r"));
    }
    
    [Test]
    public void SpaceTest()
    {
      Assert.AreEqual(0, Kata.TotalBill(""));
      Assert.AreEqual(0, Kata.TotalBill(" "));
      Assert.AreEqual(0, Kata.TotalBill("     "));
    }
    
    private static int Solution(string str)
    {
      string sushi = String.Join("", str.Split(' '));
      return (int)((sushi.Length * 2) - (Math.Floor((double)sushi.Length / 5) * 2));
    }
    
    private static Random rnd = new Random();
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 50; ++i)
      {
        int figures = rnd.Next(0, 30);
        string plates = "";
        for (int j = 0; j < 30; ++j)
        {
          if (rnd.Next(0, 2) == 0) plates += " ";
          else plates += "r";
        }
        int answer = Solution(plates);
        Assert.AreEqual(answer, Kata.TotalBill(plates));
      }
    }
  }
}
