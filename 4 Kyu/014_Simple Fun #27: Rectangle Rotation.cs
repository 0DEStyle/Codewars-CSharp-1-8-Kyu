/*Challenge link:https://www.codewars.com/kata/5886e082a836a691340000c3/train/csharp
Question:
Task
A rectangle with sides equal to even integers a and b is drawn on the Cartesian plane. Its center (the intersection point of its diagonals) coincides with the point (0, 0), but the sides of the rectangle are not parallel to the axes; instead, they are forming 45 degree angles with the axes.

How many points with integer coordinates are located inside the given rectangle (including on its sides)?

Example
For a = 6 and b = 4, the output should be 23

The following picture illustrates the example, and the 23 points are marked green.



Input/Output
[input] integer a

A positive even integer.

Constraints: 2 ≤ a ≤ 10000.

[input] integer b

A positive even integer.

Constraints: 2 ≤ b ≤ 10000.

[output] an integer

The number of inner points with integer coordinates.
*/

//***************Solution********************

//method https://medium.com/hard-mode/coding-challenge-rectangle-rotation-10e2a2416ef3
namespace myjinxin{
    using System;
    
    public class Kata{
        public int RectangleRotation(int a, int b){
          //round up, find the number of dots in the rows(da) and columns(db) of the rectangle using pythagoras 45°
           var da = (int)Math.Ceiling(a / Math.Sqrt(2));
           var db = (int)Math.Ceiling(b / Math.Sqrt(2));
           //Console.WriteLine("rows:" + da + ",columns" + db + ",Area " + (da * db + (da-1) * (db-1)) + ",OOB " + ((da+db) % 2));
          
          //2nd rectangle is 1 spot less than the first one.
          //area of the 1st rectangle + area of the 2nd rectangle - checking if out of bound using %2
           return da * db + (da-1) * (db-1)  - (da+db) % 2;
        }
    }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    //using System.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
        public int An(int a, int b){
          double q=Math.Sqrt(2);
          int x=(int)(a/q)+1,y=(int)(b/q)+1;
          return y%2==x%2?x*y+(x-1)*(y-1):y*(x-1)+x*(y-1);
        }
        public int[] rndtest(){
          int ddd=rand(1,5000)*2,eee=rand(1,5000)*2;
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
            
            Assert.AreEqual(23,  kata.RectangleRotation(6,4));
            Console.WriteLine(passed);
            Assert.AreEqual(65,  kata.RectangleRotation(30,2));
            Console.WriteLine(passed);
            Assert.AreEqual(49,  kata.RectangleRotation(8,6));
            Console.WriteLine(passed);
            Assert.AreEqual(333,  kata.RectangleRotation(16,20));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
//           var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              var answer=An(ab[0],ab[1]);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\na = "+ab[0]
              +", b = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              Assert.AreEqual(answer, kata.RectangleRotation(ab[0],ab[1]));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
