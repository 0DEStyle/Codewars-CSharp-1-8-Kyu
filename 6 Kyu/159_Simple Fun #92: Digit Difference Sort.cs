/*Challenge link:https://www.codewars.com/kata/5897df29fcc4b9c310000030/train/csharp
Question:
Task
Given an array of integers, sort its elements by the difference of their largest and smallest digits. In the case of a tie, that with the larger index in the array should come first.

Example
For a = [152, 23, 7, 887, 243], the output should be [7, 887, 23, 243, 152].

Here are the differences of all the numbers:

``` 152: difference = 5 - 1 = 4; 23: difference = 3 - 2 = 1; 7: difference = 7 - 7 = 0; 887: difference = 8 - 7 = 1; 243: difference = 4 - 2 = 2.

23 and 887 have the same difference, but 887 goes after 23 in a, so in the sorted array it comes first.```

Input/Output
[input] integer array a

An array of integers.

Constraints:

0 ≤ sequence.length ≤ 1000,

1 ≤ sequence[i] ≤ 100000.

[output] an integer array

Array a sorted as described above.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//reverse the array, because larger number comes first if the difference is the same.
//x is the current element, first convert the element to string, 
//then find the difference between the max and min digits
//Order in ascending order afterward and store in array.
using System.Linq;

namespace myjinxin{
    public class Kata{
        public int[] DigitDifferenceSort(int[] a) => 
           a.Reverse().OrderBy(x => {
            string nums = x.ToString(); 
            return nums.Max() - nums.Min();})
            .ToArray();
    }
}

//solution 2
namespace myjinxin
{
    using System;
  using System.Linq;
    
    public class Kata
    {
        public int[] DigitDifferenceSort(int[] a) {
          return a.Reverse().OrderBy(n => {
            int a = 9, b = 0;
            while (n > 0) {
              int d = n % 10;
              if (d < a) a = d;
              if (d > b) b = d;
              n /= 10;
            }
            return b - a;
          }).ToArray();
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
public int[] An(int[] a){
  var r=a.Select((x,i)=>new int[]{testdiff(x),a.Length-i,x}.ToArray());
  return r.OrderBy(x=>x[0]).ThenBy(x=>x[1]).Select(x=>x[2]).ToArray();
}  
public int testdiff(int n){
  int max=0,min=10;
  for(;n>0;n/=10){
    var t=n%10;
    if(t>max) max=t;
    if(t<min) min=t;
  }
  return max-min;
}
public int[] rndtest0(){
  var r=new List<int>();
  int len=rand(1,100);
  for(int i=0;i<len;i++) r.Add(rand(1,9999));
  return r.ToArray();
}
public int[] rndtest1(){
  var r=new List<int>();
  int len=rand(100,1000);
  for(int i=0;i<len;i++) r.Add(rand(1,1000000));
  return r.ToArray();
}
public void shuff(List<int> r){
  for(int i=0;i<50;i++){
    int idx1=rand(0,r.Count-1),idx2=rand(0,r.Count-1);
    var tt=r[idx1];
    r[idx1]=r[idx2];
    r[idx2]=tt;
  }
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
            
            Assert.AreEqual(new int[]{7, 887, 23, 243, 152},kata.DigitDifferenceSort(new int[]{152, 23, 7, 887, 243}));
            Console.WriteLine(passed);
            Assert.AreEqual(new int[]{},kata.DigitDifferenceSort(new int[]{}));
            Console.WriteLine(passed);
            Assert.AreEqual(new int[]{11111, 97897, 12213, 243, 213, 424, 213, 54234, 52433, 99487, 81892, 12398, 1308, 13098},
            kata.DigitDifferenceSort(new int[]{13098, 1308, 12398, 52433, 213, 424, 213, 243, 12213, 54234, 99487, 81892, 11111, 97897}));
            Console.WriteLine(passed);
            Console.WriteLine(" ");
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            
          for (int i=0;i<100;i++){
              var ab=i<50?rndtest0():rndtest1();
              Console.WriteLine("<font size=2 color='#CFB53B'>Testing for: "+
              (i<50?("\na = new int[]{"+string.Join(", ",ab)+"}"):"Array is too large, display omitted.")
              //+"\ncell2 = \""+ab[1]+"\""
              //+", numberOfDigits = "+ab[1]
              //+", loved = "+ab[2]
              //+", s = "+ab[3]
              +"</font>");
              var answer=An(ab);
              Assert.AreEqual(answer, kata.DigitDifferenceSort(ab));
              Console.WriteLine("<font size=2 color='#8FBC8F'>"+
              (i<50?("\na = new int[]{"+string.Join(", ",answer)+"}"):"Array is too large, display omitted.")+"</font>\n");
              Console.WriteLine(" ");
            }
          
          Console.WriteLine("<div style='width:360px;background-color:gray'><br><font size=2 color='#3300dd'><b>Happy Coding ^_^</b></font>");
          Console.WriteLine("<br><font size=2 color='#5500ee'><b>Thanks for solve this kata,\nI'm waiting for your:<font color='993300'>\nfeedback, voting and ranking ;-)</b></font></div>");
          
        }
    }
}	
