/*Challenge link:https://www.codewars.com/kata/58b8c94b7df3f116eb00005b/train/csharp
Question:
Task
Given a string str, reverse it and omit all non-alphabetic characters.

Example
For str = "krishan", the output should be "nahsirk".

For str = "ultr53o?n", the output should be "nortlu".

Input/Output
[input] string str
A string consists of lowercase latin letters, digits and symbols.

[output] a string
*/

//***************Solution********************
//select only letter, reverse it, and join the string together.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
namespace myjinxin{
    using System;
    public class Kata{
        public string ReverseLetter(string str) => string.Join("",str.Where(Char.IsLetter).Reverse());
    }
}
//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
public string An(string str){
  var r="";
  foreach(char c in str) if(c>96&&c<123) r=c+r;
  return r;
} 





public string rndtest(){
  string letter="abcdefghijklmnopqrstuvwxyz",other="0123456789_ !@#$%^&*_(),.?|{}[]-=+\\/";
  int len=rand(3,50),change=rand(0,len/2);
  var r=new List<char>();
  for(int i=0;i<len;i++) r.Add(letter[rand(0,letter.Length-1)]);
  while(change-->0) r[rand(0,r.Count-1)]=other[rand(0,other.Length-1)];
  return string.Join("",r);
}

//Tools
public void shuff(List<int> r){
  for(int i=0;i<50;i++){
    int idx1=rand(0,r.Count-1),idx2=rand(0,r.Count-1);
    var tt=r[idx1];
    r[idx1]=r[idx2];
    r[idx2]=tt;
  }
}
public string repeat(string c, int n){
  var s=new string('&',n);
  return Regex.Replace(s,"&",c);
}

        
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int rand(int a,int b){
          return a>b?rand(b,a):rndnum.Next(a,b+1);
        }
        public int[] rndarr(int minlen,int maxlen,int minv,int maxv){
          var len=rand(minlen,maxlen);
          var r=new int[len];
          for(var i=0;i<len;i++) r[i]=rand(minv,maxv);
          return r;
        }
        public string rnds(int n){
          var len= n;
          var rs=new List<char>();
          for (int i=0;i<len;i++) rs.Add(rndcl());
          return string.Join("",rs);
        }
        public string rndss(int n){
          var len= n;
          var rs=new List<string>();
          for (int i=0;i<len;i++) rs.Add(rnds(rand(3,7)));
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
            
            Assert.AreEqual("nahsirk",kata.ReverseLetter("krishan"));
            Console.WriteLine(passed);
            Assert.AreEqual("nortlu",kata.ReverseLetter("ultr53o?n"));
            Console.WriteLine(passed);
            Assert.AreEqual("cba",kata.ReverseLetter("ab23c"));
            Console.WriteLine(passed);
            Assert.AreEqual("nahsirk",kata.ReverseLetter("krish21an"));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              //var cd=rand(0,3)>0?rand(10000,1048576):rand(1,10000);
              //var cd=rand(0,100000);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              //"\narr = new int[]{"+string.Join(", ",ab)+"}"
              //+"\nb = new int[]{"+string.Join(", ",ab[1])+"}"
              "\nstr = \""+ab+"\""
              //+"\nn = "+cd
              //+"\nn = "+ab[1]
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.ReverseLetter(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = \""+answer+"\"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
