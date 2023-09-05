/*Challenge link:https://www.codewars.com/kata/58b38256e51f1c2af0000081/train/csharp
Question:
Task
"AL-AHLY" and "Zamalek" are the best teams in Egypt, but "AL-AHLY" always wins the matches between them. "Zamalek" managers want to know what is the best match they've played so far.

The best match is the match they lost with the minimum goal difference. If there is more than one match with the same difference, choose the one "Zamalek" scored more goals in.

Given the information about all matches they played, return the index of the best match (0-based). If more than one valid result, return the smallest index.

Example
For ALAHLYGoals = [6,4] and zamalekGoals = [1,2], the output should be 1 (2 in COBOL).

Because 4 - 2 is less than 6 - 1

For ALAHLYGoals = [1,2,3,4,5] and zamalekGoals = [0,1,2,3,4], the output should be 4.

The goal difference of all matches are 1, but at 4th match "Zamalek" scored more goals in. So the result is 4 (5 in COBOL).

Input/Output
[input] integer array ALAHLYGoals
The number of goals "AL-AHLY" scored in each match.

[input] integer array zamalekGoals
The number of goals "Zamalek" scored in each match. It is guaranteed that zamalekGoals[i] < ALAHLYGoals[i] for each element.

[output] an integer
Index of the best match.
*/

//***************Solution********************
using System;

namespace myjinxin{
    public class Kata{
        public int BestMatch(int[] goals1, int[] goals2){
          //set array difference with size of goals1.length
          int[] difference = new int[goals1.Length];
          
          //start from 0!!! yes 0, up to goals1.Length
          //store difference[index] to goals1 subtract goals2
          for (int i = 0; i < goals1.Length; i++)
            difference[i] = goals1[i] - goals2[i];


          int min = 0;
          //start from 0, up to difference.Length
          //if current difference is less than the min difference, 
          //or current difference is equal to min difference and current goal2 is less than min goal2
          //then set min to current index
          for (int i = 0; i < difference.Length; i++)
            if (difference[i] < difference[min] || (difference[i] == difference[min] && goals2[i] > goals2[min]))
              min = i;
          
          return min; 
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
public int An(int[] goals1, int[] goals2){
  int min=goals1[0]-goals2[0],maxg=0,r=0;
  for(var i=0;i<goals1.Length;i++){
    var t=goals1[i]-goals2[i];
    if(t<min){
      min=t;
      maxg=goals2[i];
      r=i;
    }
    else if(t==min&&goals2[i]>maxg){
      maxg=goals2[i];
      r=i;
    }
  }
  return r;
}





public int[][] rndtest(){
  var r2=rndarr(1,20,0,10);
  var r1=r2.Select(x=>x+rand(1,10)).ToArray();
  return new int[][]{r1,r2};
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
            
            Assert.AreEqual(1,kata.BestMatch(new int[]{6, 4},new int[]{1, 2}));
            Console.WriteLine(passed);
            Assert.AreEqual(0,kata.BestMatch(new int[]{1},new int[]{0}));
            Console.WriteLine(passed);
            Assert.AreEqual(4,kata.BestMatch(new int[]{1, 2, 3, 4, 5},new int[]{0, 1, 2, 3, 4}));
            Console.WriteLine(passed);
            Assert.AreEqual(2,kata.BestMatch(new int[]{3, 4, 3},new int[]{1, 1, 2}));
            Console.WriteLine(passed);
            Assert.AreEqual(1,kata.BestMatch(new int[]{4, 3, 4},new int[]{1, 1, 1}));
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
              "\ngoals1 = new int[]{"+string.Join(", ",ab[0])+"}"
              +"\ngoals2 = new int[]{"+string.Join(", ",ab[1])+"}"
              //"\nn = "+ab
              //+"\nn = "+cd
              //+"\nn = "+ab[1]
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab[0],ab[1]);
              Assert.AreEqual(answer, kata.BestMatch(ab[0],ab[1]));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              "Pass Value = "+answer+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
