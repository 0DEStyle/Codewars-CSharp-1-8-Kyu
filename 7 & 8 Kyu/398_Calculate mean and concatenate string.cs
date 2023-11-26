/*Challenge link:https://www.codewars.com/kata/56f7493f5d7c12d1690000b6/train/csharp
Question:
You will be given an array which will include both integers and characters.

Return an array of length 2 with a[0] representing the mean of the ten integers as a floating point number. There will always be 10 integers and 10 characters. Create a single string with the characters and return it as a[1] while maintaining the original order.

lst = ['u', '6', 'd', '1', 'i', 'w', '6', 's', 't', '4', 'a', '6', 'g', '1', '2', 'w', '8', 'o', '2', '0']
Here is an example of your return

[3.6, "udiwstagwo"]
In C# and Java the mean return is a double.
*/

//***************Solution********************

//create a new object {int, string}
//for object[0] in lst, get all character that is number, get the index number by subtracting the ASCII index of '0'
//then find the average of those indexs.
//for object[1] in lst, get all character that is a letter.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System;

public class Kata{
  public static object[] Mean(char[] lst) => 
    new object[] { lst.Where(char.IsNumber).Average(ch => ch - '0') ,  lst.Where(char.IsLetter) };
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {      
      var lst1 = new [] { 'u', '6', 'd', '1', 'i', 'w', '6', 's', 't', '4', 'a', '6', 'g', '1', '2', 'w', '8', 'o', '2', '0' };
      Assert.AreEqual(new object[] { 3.6, "udiwstagwo" }, Kata.Mean(lst1));
      
      var lst2 = new [] { '0', 'c', '7', 'x', '6', '2', '3', '5', 'w', '7', '0', 'y', 'v', 'u', 'h', 'i', 'n', 'u', '0', '0' };
      Assert.AreEqual(new object[] { 3.0, "cxwyvuhinu" }, Kata.Mean(lst2));

      var lst3 = new [] { '0', 'u', 'a', 'y', '0', 'a', '9', 'q', '3', 'v', 'g', '7', '6', '4', 'y', 'd', '8', '6', '0', 'd' };
      Assert.AreEqual(new object[] { 4.3, "uayaqvgydd" }, Kata.Mean(lst3));

      var lst4 = new [] { 's', 'n', '9', 'l', '0', 'm', 'i', 'z', '9', '7', 'y', '4', 'z', '3', '3', 'k', '4', '1', '0', 'k' };
      Assert.AreEqual(new object[] { 4.0, "snlmizyzkk" }, Kata.Mean(lst4));
      
      var lst5 = new [] { '5', 'v', 'u', 'k', '8', '4', '9', 'b', '9', 'g', '5', 'z', '3', 'f', '6', 'u', 'i', '6', '6', 't' };
      Assert.AreEqual(new object[] { 6.1, "vukbgzfuit" }, Kata.Mean(lst5));
      
      var lst6 = new [] { '1', '1', '1', '1', '1', '1', '1', '1', '1', '0', 'a', 'a', 'd', 'd', 'g', 'q', 'u', 'v', 'y', 'y' };
      Assert.AreEqual(new object[] { 0.9, "aaddgquvyy" }, Kata.Mean(lst6));
      
      var lst7 = new [] { '1', '1', '1', '1', '1', '1', '1', '1', '1', '1', 'a', 'a', 'd', 'd', 'g', 'q', 'u', 'v', 'y', 'y' };
      Assert.AreEqual(new object[] { 1.0, "aaddgquvyy" }, Kata.Mean(lst7));
      
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      var nums="0123456789";
      var letters="abcdefghijklmnopqrstuvwxyz";
      
      Func<char[],object[]> myMean = delegate (char[] lst)
      {
        double sum = 0;
        var numberCount = 0;
        var text = "";
    
        for(var i = 0; i< lst.Length; i++)
        {
          int number = 0;
      
          if(!int.TryParse(lst[i] + "", out number))
          {      
            text += lst[i];  
          }
          else
          {
            sum += number;
            numberCount++;
          }    
        }  
  
        return new object[] { sum / numberCount, text };
      };
      
      for (var i=0;i<40;i++)
      {
        var lst = Enumerable.Range(0,10).Select(a => nums[rand.Next(0,10)])
           .Concat(Enumerable.Range(0,10).Select(a => letters[rand.Next(0,26)]))
           .OrderBy(a => rand.Next(-1,2)).ToArray();        
        
        Assert.AreEqual(myMean(lst), Kata.Mean(lst), "It should work for random inputs too");
      }
    }
  }
}
