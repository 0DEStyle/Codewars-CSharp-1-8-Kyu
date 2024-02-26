/*Challenge link:https://www.codewars.com/kata/58bcd27b7288983803000002/train/csharp
Question:
Task
Let's say that "g" is happy in the given string, if there is another "g" immediately to the right or to the left of it.

Find out if all "g"s in the given string are happy.

Example
For str = "gg0gg3gg0gg", the output should be true.

For str = "gog", the output should be false.

Input/Output
[input] string str
A random string of lower case letters, numbers and spaces.

[output] a boolean value
true if all "g"s are happy, false otherwise.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//pattern 
//^ start, group 1 matches g 2 or more times
//or negative set, matches g
//match 1 or more times, $ end
namespace myjinxin{
    public class Kata{
        public bool HappyG(string s) => System.Text.RegularExpressions.Regex.IsMatch(s, @"^(g{2,}|[^g])+$");
    }
}

//solution 2
using System;
using System.Text.RegularExpressions;
  
public class Kata
{
    public bool HappyG(string str)
    {
      return !Regex.Replace(str, "gg+", "").Contains("g");
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
public bool An(string str){
  return Regex.IsMatch(str,"^(g{2,}|[^g])+$");
}





public string rndtest(){
  var jl=rand(0,3);
  return jl==0?nog():jl==1?badg():string.Join("",goodg());
}
public string nog(){
  var c="abcdefhijklmnopqrstuvwxyz0123456789            ";
  var len=rand(3,30);
  var r=new List<char>();
  while(len-->0) r.Add(c[rand(0,c.Length-1)]);
  return string.Join("",r);
}
public string[] goodg(){
  var c="abcdefhijklmnopqrstuvwxyz0123456789            ";
  int gs=rand(1,5),len=rand(gs+3,30);
  var r=new List<string>();
  while(len-->0) r.Add(""+c[rand(0,c.Length-1)]);
  while(gs-->0){
    var idx=rand(0,r.Count-1);
    while(r[idx].Contains("g")) idx=rand(0,r.Count-1);
    r[idx]=new string('g',rand(2,10));
  }
  //console.log("good")
  return r.ToArray();
}
public string badg(){
  var r=goodg();
  var bad=rand(1,3);
  while(bad-->0){
    var idx=rand(0,r.Length-1);
    r[idx]="g";
  }
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
            
            Assert.AreEqual(true,kata.HappyG("gg0gg3gg0gg"));
            Console.WriteLine(passed);
            Assert.AreEqual(false,kata.HappyG("gog"));
            Console.WriteLine(passed);
            Assert.AreEqual(false,kata.HappyG("ggg ggg g ggg"));
            Console.WriteLine(passed);
            Assert.AreEqual(true,kata.HappyG("A half of a half is a quarter."));
            Console.WriteLine(passed);
            Assert.AreEqual(false,kata.HappyG("good grief"));
            Console.WriteLine(passed);
            Assert.AreEqual(true,kata.HappyG("bigger is ggooder"));
            Console.WriteLine(passed);
            Assert.AreEqual(true,kata.HappyG("gggggggggg"));
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
              "\ns = \""+ab+"\""
              //+"\nn = "+cd
              //+"\nn = "+ab[1]
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.HappyG(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
