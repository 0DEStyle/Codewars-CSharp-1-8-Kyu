/*Challenge link:https://www.codewars.com/kata/57d2ba8095497e484e00002e/train/csharp
Question:
The borrowers are tiny tiny fictional people. As tiny tiny people they have to be sure they aren't spotted, or more importantly, stepped on.

As a result, the borrowers talk very very quietly. They find that capitals and punctuation of any sort lead them to raise their voices and put them in danger.

The young borrowers have begged their parents to stop using caps and punctuation.

Change the input text s to new borrower speak. Help save the next generation!
*/

//***************Solution********************

//from string s get char if they're letters, concat the result and convert to lowercase
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{
  public static string Borrow(string s) => string.Concat(s.Where(char.IsLetter)).ToLower();
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
      Assert.AreEqual("whatfickdamncake", Kata.Borrow("WhAt! FiCK! DaMn CAke?"));
      Assert.AreEqual("thebigpeoplehere", Kata.Borrow("THE big PeOpLE Here!!"));
      Assert.AreEqual("iamatinyboy", Kata.Borrow("i AM a TINY BoY!!"));
      Assert.AreEqual("dontyousaythat", Kata.Borrow("DOnt YOU SAY THAT!"));
      Assert.AreEqual("borrowborrowborrowit", Kata.Borrow("borrow BORROW BoRrOw IT!?"));      
    }
    
    [Test]
    public void RandomTests()
    {    
      var rand = new Random();
      var names = new [] {"A","b","C","d","E","f","G","h","I","j","K","l","M","n","O","p","Q","r","S","t","U","v","W","x","Y","z", "!", "?", ".", ",", ":", ";", "!", "?", ".", ",", ":", ";"};

      for (var r=0;r<50;r++)
      {
        var len = rand.Next(0,31);  
         
        var s = string.Join(" ", Enumerable.Range(0, rand.Next(3,8)).Select(a => string.Concat(Enumerable.Range(0, rand.Next(1, 20)).Select(c => names[rand.Next(0, names.Length)]))));
    
        var expected = string.Concat(s.ToLower().Where(c => c >= 'a' && c <= 'z'));
     
        Assert.AreEqual(expected, Kata.Borrow(s),"It should work for random inputs too");
      }
    }
  }
}
