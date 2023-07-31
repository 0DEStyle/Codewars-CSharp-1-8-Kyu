/*Challenge link:https://www.codewars.com/kata/58aa8b0538cf2eced5000115/train/csharp
Question:

Task
Sorting is one of the most basic computational devices used in Computer Science.

Given a sequence (length ≤ 1000) of 3 different key values (7, 8, 9), your task is to find the minimum number of exchange operations necessary to make the sequence sorted.

One operation is the switching of 2 key values in the sequence.

Example
For sequence = [7, 7, 8, 8, 9, 9], the result should be 0.

It's already a sorted sequence.

For sequence = [9, 7, 8, 8, 9, 7], the result should be 1.

We can switching sequence[0] and sequence[5].

For sequence = [8, 8, 7, 9, 9, 9, 8, 9, 7], the result should be 4.

We can:

 [8, 8, 7, 9, 9, 9, 8, 9, 7] 
 switching sequence[0] and sequence[3]
 --> [9, 8, 7, 8, 9, 9, 8, 9, 7]
 switching sequence[0] and sequence[8]
 --> [7, 8, 7, 8, 9, 9, 8, 9, 9]
 switching sequence[1] and sequence[2]
 --> [7, 7, 8, 8, 9, 9, 8, 9, 9]
 switching sequence[5] and sequence[7]
 --> [7, 7, 8, 8, 8, 9, 9, 9, 9] 
So 4 is the minimum number of operations for the sequence to become sorted.

Input/Output
[input] integer array sequence
The Sequence.

[output] an integer
the minimum number of operations.
*/

//***************Solution********************

using System;
using System.Linq;
using static System.Math;

namespace myjinxin{
    public class Kata{
        public int ExchangeSort(int[] sequence){
            //count number of 7s and 9s
            var numSevens = sequence.Count(x => x == 7);
            var numNines = sequence.Count(x => x == 9);
          Console.WriteLine("sequence: " + string.Join(",",sequence) + " numSevens:" + numSevens + "numNines:" + numNines);
          
            //from range 0 up to numSevens
            //from the end numNines to end 0
            var sevensRegion = sequence[0..numSevens];
            var ninesRegion = sequence[^numNines..^0];
          
          //info printer
          Console.WriteLine("sevensRegion: " +string.Join(",",sevensRegion));
          Console.WriteLine("ninesRegion: " +string.Join(",",ninesRegion));
          
          //number of swap needed in each region
          Console.WriteLine(sevensRegion.Count(x => x == 8));
          Console.WriteLine(ninesRegion.Count(x => x == 8));
          //take max for case 7 and 9 
          Console.WriteLine(Max(sevensRegion.Count(x => x == 9), ninesRegion.Count(x => x == 7)));
          
            return Max(sevensRegion.Count(x => x == 9), ninesRegion.Count(x => x == 7))
                + sevensRegion.Count(x => x == 8)
                + ninesRegion.Count(x => x == 8);
        }
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
public int An(int[] l){
  int a=l.Count(x=>x==7),b=l.Count(x=>x==9);
  if (b>0) return a - l.Take(a).Count(x=>x==7) + Math.Max(l.Skip(a).Take(l.Length-a-b).Count(x=>x==9),l.Skip(l.Length-b).Count(x=>x==8));
  var t=l.OrderBy(x=>x).ToArray();
  var r=0;
  for(var i=0;i<t.Length;i++) if(t[i]>l[i]) r++;
  return r;
} 





public int[] rndtest(){
  return rndarr(3,100,7,9);
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
            
            Assert.AreEqual(0,kata.ExchangeSort(new int[]{7, 7, 8, 8, 9, 9}));
            Console.WriteLine(passed);
            Assert.AreEqual(1,kata.ExchangeSort(new int[]{9, 7, 8, 8, 9, 7}));
            Console.WriteLine(passed);
            Assert.AreEqual(4,kata.ExchangeSort(new int[]{8, 8, 7, 9, 9, 9, 8, 9, 7}));
            Console.WriteLine(passed);
            Assert.AreEqual(6,kata.ExchangeSort(new int[]{9, 9, 9, 9, 9, 8, 8, 8, 8, 7, 7, 7, 7, 7, 7}));
            Console.WriteLine(passed);
            Assert.AreEqual(4,kata.ExchangeSort(new int[]{9,9,9,7,7,8,9,7,8,9,7,9}));
            Console.WriteLine(passed);
            Assert.AreEqual(4,kata.ExchangeSort(new int[]{9,9,7,7,8,8}));
            Console.WriteLine(passed);
            
            Assert.AreEqual(1,kata.ExchangeSort(new int[]{9, 7, 9}));
            Console.WriteLine(passed);
Assert.AreEqual(1,kata.ExchangeSort(new int[]{8, 7, 8}));
Console.WriteLine(passed);
Assert.AreEqual(1,kata.ExchangeSort(new int[]{7, 8, 7, 8}));
Console.WriteLine(passed);
Assert.AreEqual(1,kata.ExchangeSort(new int[]{8, 8, 7, 8}));
Console.WriteLine(passed);
Assert.AreEqual(2,kata.ExchangeSort(new int[]{8, 8, 7, 7, 8}));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
            
          for (int i=0;i<100;i++){
              var ab=rndtest();
              //var cd=rand(0,3)>0?rand(10000,1048576):rand(1,10000);
              //var cd=rand(0,100000);
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              "\nsequence = new int[]{"+string.Join(", ",ab)+"}"
              //+"\nb = new int[]{"+string.Join(", ",ab[1])+"}"
              //"\nyear = "+ab
              //+"\nb = "+cd
              //+"\nn = "+ab[1]
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.ExchangeSort(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
