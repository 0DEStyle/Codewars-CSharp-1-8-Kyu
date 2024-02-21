/*Challenge link:https://www.codewars.com/kata/58845748bd5733f1b300001f/train/csharp
Question:
Task
You are given two numbers a and b where 0 ≤ a ≤ b. Imagine you construct an array of all the integers from a to b inclusive. You need to count the number of 1s in the binary representations of all the numbers in the array.

Example
For a = 2 and b = 7, the output should be 11

Given a = 2 and b = 7 the array is: [2, 3, 4, 5, 6, 7]. Converting the numbers to binary, we get [10, 11, 100, 101, 110, 111], which contains 1 + 2 + 1 + 2 + 2 + 3 = 11 1s.

Input/Output
[input] integer a
Constraints: 0 ≤ a ≤ b.

[input] integer b
Constraints: a ≤ b ≤ 100.

[output] an integer

*/

//***************Solution********************
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
using System;

namespace myjinxin{ 
    public class Kata{
        public int RangeBitCount(int a,int b){
          int counter = 0;
          
          for(int i = a; i <= b; i++){
            //convert to binary
            var str = Convert.ToString(i, 2);
            //count 1 in string str
            for(int j = 0; j < str.Length; j++)
              if(str[j] == '1') counter++;
          }
          return counter;
        }
    }
}
//solution 2
using System;
using System.Linq;

public class Kata
{
  public int RangeBitCount(int a,int b)
  {
    return string.Concat(Enumerable.Range(a, b - a + 1).Select(x => Convert.ToString(x, 2))).Count(x=> x == '1');
  }
}
//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    //using System.Collections.Generic;
    //using System.Text;
    //using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
        public int An(int a,int b){
          int r=0;
          for(;a<=b;a++) r+=Regex.Split(Convert.ToString(a,2),"1").Length-1;
          return r;
        }
        public int[] rndtest(){
          int ddd=rand(0,30),eee=ddd+rand(0,70);
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
            
            Assert.AreEqual(11,  kata.RangeBitCount(2,7),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(1,  kata.RangeBitCount(0,1),  "");
            Console.WriteLine(passed);
            Assert.AreEqual(1,  kata.RangeBitCount(4,4),  "");
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              var answer=An(ab[0],ab[1]);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\na = "+ab[0]
              +", b = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              Assert.AreEqual(answer, kata.RangeBitCount(ab[0],ab[1]));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
