/*Challenge link:https://www.codewars.com/kata/557f6437bf8dcdd135000010/train/csharp
Question:
In mathematics, the factorial of integer n is written as n!. It is equal to the product of n and every integer preceding it. For example: 5! = 1 x 2 x 3 x 4 x 5 = 120

Your mission is simple: write a function that takes an integer n and returns the value of n!.

You are guaranteed an integer argument. For any values outside the non-negative range, return null, nil or None (return an empty string "" in C and C++). For non-negative numbers a full length number is expected for example, return 25! =  "15511210043330985984000000"  as a string.

For more on factorials, see http://en.wikipedia.org/wiki/Factorial

NOTES:

The use of BigInteger or BigNumber functions has been disabled, this requires a complex solution

I have removed the use of require in the javascript language.
*/

//***************Solution********************

using System;
using System.Collections.Generic;

public class Kata{
        public static string Factorial(int n){
          //if n is less than 0 return empty, if n is 0 or 1 return 1
          if (n < 0) return "";
          if (n == 0 || n == 1)  return "1";
          
          //making a list so you can add more items into it.
          var result = new List<int>(){1};

            for (var i = 1; i <= n; i++){
              
                //accumulate result
                for (var j = 0; j < result.Count; j++) 
                  result[j] *= i;
              
                for (var j = 0; j < result.Count; j++){
                  //Continue if carry result is less than or equal to 9
                  if (result[j] <= 9) continue;
                  
                  //carry number, divide result by 10 
                  //Store last digit in result, mod by 10
                  var addNum = result[j] / 10;
                  result[j] %= 10;
                  
                  //info printer
                  //Console.WriteLine("j: " + j + ",result: " + string.Concat(result) + ", result.Count:" + result.Count);
                  
                  //check for carriable digits, if j < result.Count - 1, add carry number to the next item/cell.
                  if (j < result.Count - 1)
                    result[j + 1] += addNum;
                  else
                    result.Add(addNum);
                }
            }
          
          //Reverse the digits and concatenate the result.
          result.Reverse();
          return string.Concat(result.ToArray());
        }
    }

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("1", Kata.Factorial(1));
      Assert.AreEqual("120", Kata.Factorial(5));
      Assert.AreEqual("362880", Kata.Factorial(9));
      Assert.AreEqual("1307674368000", Kata.Factorial(15));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual("93326215443944152681699238856266700490715968264381621468592963895217599993229915608941463976156518286253697920827223758251185210916864000000000000000000000000", Kata.Factorial(100));
      Assert.AreEqual("57133839564458545904789328652610540031895535786011264182548375833179829124845398393126574488675311145377107878746854204162666250198684504466355949195922066574942592095735778929325357290444962472405416790722118445437122269675520000000000000000000000000000000000000", Kata.Factorial(150));
      Assert.AreEqual("788657867364790503552363213932185062295135977687173263294742533244359449963403342920304284011984623904177212138919638830257642790242637105061926624952829931113462857270763317237396988943922445621451664240254033291864131227428294853277524242407573903240321257405579568660226031904170324062351700858796178922222789623703897374720000000000000000000000000000000000000000000000000", Kata.Factorial(200));
      Assert.AreEqual("3232856260909107732320814552024368470994843717673780666747942427112823747555111209488817915371028199450928507353189432926730931712808990822791030279071281921676527240189264733218041186261006832925365133678939089569935713530175040513178760077247933065402339006164825552248819436572586057399222641254832982204849137721776650641276858807153128978777672951913990844377478702589172973255150283241787320658188482062478582659808848825548800000000000000000000000000000000000000000000000000000000000000", Kata.Factorial(250));
    }
    
    [Test]
    public void DontUseBigIntegerType()
    {
      Assert.IsFalse(CheatingPrevention.CheatingDetection(), "You are not allowed to use the type 'BigInteger'.");
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,string> qwerty = delegate (int n)
      {
        var res = new List<int> { 1 };
        for (var i = 2; i <= n; ++i) 
        {
          var c = 0;
          for (var j = 0; j < res.Count || c != 0; j++) 
          {
            c += (j<res.Count ? res[j] : 0) * i;
            if(res.Count<=j)
            {
              res.Add(c%10);
            }
            else
            {
              res[j] = c % 10;
            }
            c = c / 10;
          }
        }
        return string.Concat(res.ToArray().Reverse().ToArray());
      };
      
      for(var i = 0; i < 10; i++) 
      {
        var a = rand.Next(0,10);
        var expected = qwerty(a);
        Assert.AreEqual(expected, Kata.Factorial(a), a + "!");
      }
      
      for(var i = 0; i < 10; i++) 
      {
        var a = rand.Next(0,80) + 100;
        var expected = qwerty(a);
        Assert.AreEqual(expected, Kata.Factorial(a), a + "!");
      }
    }
  }
}
