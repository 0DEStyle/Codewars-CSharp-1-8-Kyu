/*Challenge link:https://www.codewars.com/kata/58898b50b832f8046a0000ec/train/csharp
Question:
Task
Miss X has only two combs in her possession, both of which are old and miss a tooth or two. She also has many purses of different length, in which she carries the combs. The only way they fit is horizontally and without overlapping. Given teeth' positions on both combs, find the minimum length of the purse she needs to take them with her.

It is guaranteed that there is at least one tooth at each end of the comb.

Note, that the combs can not be rotated/reversed.
Example
For comb1 = "*..*" and comb2 = "*.*", the output should be 5

Although it is possible to place the combs like on the first picture, the best way to do this is either picture 2 or picture 3.



Input/Output
[input] string comb1

A comb is represented as a string. If there is an asterisk ('*') in the ith position, there is a tooth there. Otherwise there is a dot ('.'), which means there is a missing tooth on the comb.

Constraints: 1 ≤ comb1.length ≤ 10.

[input] string comb2

The second comb is represented in the same way as the first one.

Constraints: 1 ≤ comb2.length ≤ 10.

[output] an integer

The minimum length of a purse Miss X needs.


*/

//***************Solution********************
namespace myjinxin{
    using System;
  
    public class Kata{
      public int Combs(string comb1, string comb2){
        static int Combinator(int x, int y){
            //x xor y != x + y
            //shift x to left by 1 bit, aka shift the comb by one tooth
              while ((x ^ y) != (x + y))
                  x <<= 1;
              return Math.Max(Convert.ToString(x, 2).Length, Convert.ToString(y, 2).Length);
          }
        
          int a = Convert.ToInt32(comb1.Replace("*", "1").Replace(".", "0"), 2);
          int b = Convert.ToInt32(comb2.Replace("*", "1").Replace(".", "0"), 2);
          //info printer
          //Console.WriteLine($"a:{a},b:{b}");
        
          //return the min value
          return Math.Min(Combinator(a, b), Combinator(b, a));

      }
    }
}

//method 2
using System;
using System.Linq;

public class Kata
{
  public int Combs(string c1,string c2) => Math.Min(Fit(c1,c2), Fit(c2,c1));

  private static int Fit(string c1, string c2, bool overlap = true, int i = 0)
  {
    while (overlap)
      overlap = c1.Skip(++i).Zip(c2, (a,b) => a=='*' && b=='*').Any(x => x);
    return Math.Max(c1.Length, c2.Length+i);
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
public int An(string comb1,string comb2){
  if(comb1.Length<comb2.Length) return An(comb2,comb1);
  int min=comb1.Length+comb2.Length;
  for(int i=1-comb2.Length;i<comb1.Length-1;i++) {
    var found=true;
    for(int j=0;j<comb2.Length;j++){
      if(comb2[j]=='*'&&j+i>=0&&j+i<comb1.Length&&comb1[j+i]=='*'){
        found=false;
        break;
      }
    }
    if(found) {
      var t=Math.Max(comb1.Length,(i>-1?i+comb2.Length:comb1.Length-i));
      if(t<min) min=t;
    }
  }
  return min;
}
public string rndtest(){
  var len=rand(1,8);
  var r=new List<char>();
  r.Add('*');
  for(int i=0;i<len;i++) r.Add("*."[rand(0,1)]);
  r.Add('*');
  return string.Join("",r);
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
            
            Assert.AreEqual(5,  kata.Combs("*..*","*.*"));
            Console.WriteLine(passed);
            Assert.AreEqual(5,  kata.Combs("*...*","*.*"));
            Console.WriteLine(passed);
            Assert.AreEqual(9,  kata.Combs("*..*.*","*.***"));
            Console.WriteLine(passed);
            Assert.AreEqual(4,  kata.Combs("*.*","*.*"));
            Console.WriteLine(passed);
            Assert.AreEqual(5,  kata.Combs("*.**","*.*"));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              var cd=rndtest();
              var answer=An(ab,cd);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\ncomb1 = \""+ab+"\""
              +"\ncomb2 = \""+cd+"\""
              //+"\nA = ["+string.Join(", ",ab[1])+"]"
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              Assert.AreEqual(answer, kata.Combs(ab,cd));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
