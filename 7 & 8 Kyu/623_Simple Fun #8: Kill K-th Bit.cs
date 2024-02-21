/*Challenge link:https://www.codewars.com/kata/58844f1a76933b1cd0000023/train/csharp
Question:
Task
In order to stop the Mad Coder evil genius you need to decipher the encrypted message he sent to his minions. The message contains several numbers that, when typed into a supercomputer, will launch a missile into the sky blocking out the sun, and making all the people on Earth grumpy and sad.

You figured out that some numbers have a modified single digit in their binary representation. More specifically, in the given number n the kth bit from the right was initially set to 0, but its current value might be different. It's now up to you to write a function that will change the kth bit of n back to 0.

Example
For n = 37 and k = 3, the output should be 33.

3710 = 1001012 ~> 1000012 = 3310

For n = 37 and k = 4, the output should be 37.

The 4th bit is 0 already (looks like the Mad Coder forgot to encrypt this number), so the answer is still 37.

Input/Output
[input] integer n
Constraints: 0 ≤ n ≤ 231 - 1.

[input] integer k
The 1-based index of the changed bit (counting from the right).

Constraints: 1 ≤ k ≤ 31.

[output] an integer
More Challenge
Are you a One-Liner? Please try to complete the kata in one line(no test for it) ;-)

*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
// n AND 
//(1 left bit shift k -1) reverse bit

namespace myjinxin{
    public class Kata{
        public int KillKthBit(int n,int k) =>
          n & ~(1 << k - 1);
    }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    //using System.Text;
    //using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
        public int An(int n,int k){
          var s=Convert.ToString(n,2);
          var r=Regex.Replace(s,"(.)(.{"+(k-1)+"}$)","0$2");
          return Convert.ToInt32(r,2);
          //parseInt(n.toString(2).replace(new RegExp("(.)(.{"+(k-1)+"}$)"),"0$2"),2);
        }
        public int[] rndtest(){
          int p=Convert.ToInt32(Math.Pow(2,31-1)),ddd=rand(0,p),eee=rand(1,31);
          return new int[]{ddd,eee};
        }
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int rand(int a,int b){
          return a>b?rand(b,a):rndnum.Next(a,b+1);
        }
        
        
        [Test]
        public void Test1__Basic_Tests(){
            var kata=new Kata();
            var passed="<font size=2 color='#8FBC8F'>Test Passed!</font>\n";
            
            Assert.AreEqual(33,  kata.KillKthBit(37,3),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(37,  kata.KillKthBit(37,4),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(0,  kata.KillKthBit(0,4),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(2147450879,  kata.KillKthBit(2147483647,16),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(374819652,  kata.KillKthBit(374823748,13),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(1084197039,  kata.KillKthBit(1084197039,15),  "");
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          //var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              var answer=An(ab[0],ab[1]);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\nn = "+ab[0]
              +", k = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              Assert.AreEqual(answer, kata.KillKthBit(ab[0],ab[1]));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
