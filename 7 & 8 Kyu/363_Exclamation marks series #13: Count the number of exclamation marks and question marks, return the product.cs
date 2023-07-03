/*Challenge link:https://www.codewars.com/kata/57fb142297e0860073000064/train/csharp
Question:
Description:
Count the number of exclamation marks and question marks, return the product.

Examples
Product("") == 0
product("!") == 0
Product("!ab? ?") == 2
Product("!!") == 0
Product("!??") == 2
Product("!???") == 3
Product("!!!??") == 6
Product("!!!???") == 9
Product("!???!!") == 9
Product("!????!!!?") == 20
*/

//***************Solution********************
//count the number of ! and ?, then find the product of both number
//return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static int Product(string str) =>
     str.Count(x => x =='!') * str.Count(x => x =='?');
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;
  
  [TestFixture]
  public class SolutionTest
  {
        //author's solution and some random data generation function here
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int An(string str){
          return str.Count(x => x.ToString() == "!") * str.Count(x => x.ToString() == "?");
        }
        public string randstr(){
          var all="!!!!!?????!!!!!?????abcdefg";
          var len=rndnum.Next(10,30);
          var r=new List<char>();
          for(var i=0;i<len;i++) r.Add(all[rndnum.Next(0,all.Length)]);
          return string.Join("",r);
        }
    
    
    
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(0, Kata.Product(""));
      Assert.AreEqual(1, Kata.Product("!?"));
      Assert.AreEqual(2, Kata.Product("!??"));
      Assert.AreEqual(2, Kata.Product("!!?"));
      Assert.AreEqual(6, Kata.Product("!!???"));
      Assert.AreEqual(6, Kata.Product("!!!??"));
      Assert.AreEqual(4, Kata.Product("!!??"));
      Assert.AreEqual(4, Kata.Product("!????"));
      Assert.AreEqual(4, Kata.Product("!!!!?"));
      Assert.AreEqual(5, Kata.Product("!?????"));
      Assert.AreEqual(20, Kata.Product("!!????!!?"));
      Assert.AreEqual(49, Kata.Product("!!???????!!!!!"));
      Assert.AreEqual(165, Kata.Product("!!???????????!!!!!?!?!?!?!"));
      Assert.AreEqual(4, Kata.Product("!!aabbcc??"));
      Assert.AreEqual(4, Kata.Product("! !aa bb   c c??   "));
    }
    
    
    
    [Test]
     public void RandomTest(){       
         Console.WriteLine("<br><font size=4><b>--------100 Random Test --------</b></font>");
         Console.WriteLine("");
         for (int i=0;i<100;i++){
           var teststr=randstr();
           var answer=An(teststr);
           Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: str = "+teststr+"</font>");
           var useranswer=Kata.Product(teststr);
           Assert.AreEqual(answer, useranswer);
           if(answer==useranswer) Console.WriteLine("<font size=2 color='#8FBC8F'>Test Passed! Passed Value = "+answer+"</font>");
         }            
    }        
    
  }
}
