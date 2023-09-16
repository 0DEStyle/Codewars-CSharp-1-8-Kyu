/*Challenge link:https://www.codewars.com/kata/5894318275f2c75695000146/train/csharp
Question:
Task
Given an integer n, find the maximal number you can obtain by deleting exactly one digit of the given number.

Example
For n = 152, the output should be 52;

For n = 1001, the output should be 101.

Input/Output
[input] integer n

Constraints: 10 ≤ n ≤ 1000000.

[output] an integer
*/

//***************Solution********************

//convert n to string, _ is current element, i is index,
//convert n to string again, remove start at index, count up to 1, 
//from the selected elements, convert string to int, and select max value, then return the result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata{
  public int DeleteDigit(int n) =>  n.ToString().Select((_, i) => n.ToString().Remove(i, 1)).Max(int.Parse);
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
public int An(int n){
  var s=n+"";
  int max=-1;
  for(int i=0;i<s.Length;i++){
    var t= int.Parse(s.Substring(0,i)+s.Substring(i+1));
    if(t>max) max=t;
  }
  return max;
}
public string[] rndtest(){
  return new string[]{""+(char)rand(65,72)+rand(1,8),""+(char)rand(65,72)+rand(1,8)};
}
public string rndsx(int n){
  int len= n;
  var c=rand(0,2)>0?"abc":"abcdefg";
  var rs=new List<char>();
  for (int i=0;i<len;i++) rs.Add(c[rand(0,c.Length-1)]);
  return string.Join("",rs);
}
public void shuff(List<int> r){
  for(int i=0;i<50;i++){
    int idx1=rand(0,r.Count-1),idx2=rand(0,r.Count-1);
    var tt=r[idx1];
    r[idx1]=r[idx2];
    r[idx2]=tt;
  }
}

        public int[] rndtest1(){
          var r=new List<int>();
          int len=rand(500,3000);
          for(var i=0;i<len;i++) r.Add(rand(1,1000));
          return r.ToArray();
        }
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int rand(int a,int b){
          return a>b?rand(b,a):rndnum.Next(a,b+1);
        }
        public string rnds(){
          var len= rand(1,100);
          var rs=new List<char>();
          for (int i=0;i<len;i++) rs.Add(rndcl());
          return string.Join("",rs);
        }
        public string rndss(){
          var len= rand(3,7);
          var rs=new List<string>();
          for (int i=0;i<len;i++) rs.Add(rnds());
          return string.Join(" ",rs);
        }
        public string rnds2(int n){
          var len= n;
          var rs=new List<char>();
          for (int i=0;i<len;i++) rs.Add(rndch());
          return string.Join("",rs);
        }
        public char rndcl(){
          var allc="abcdefghijklmnopqrstuvwxyz";
          return allc[rand(0,allc.Length-1)];
        }
        public char rndchl(){
          var allc="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
          return allc[rand(0,allc.Length-1)];
        }
        public char rndch(){
          var allc="ABCDEFGHIJKLMNOPQRSTUVWXYZ";
          return allc[rand(0,allc.Length-1)];
        }
        [Test]
        public void Test1__Basic_Tests(){
            var kata=new Kata();
            var passed="<font size=2 color='#8FBC8F'>Test Passed!</font>\n";
            
            Assert.AreEqual(52,kata.DeleteDigit(152));
            Console.WriteLine(passed);
            Assert.AreEqual(101,kata.DeleteDigit(1001));
            Console.WriteLine(passed);
            Assert.AreEqual(1,kata.DeleteDigit(10));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rand(10,1000000);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\nn = "+ab
              //+"\ncell2 = \""+ab[1]+"\""
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.DeleteDigit(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
