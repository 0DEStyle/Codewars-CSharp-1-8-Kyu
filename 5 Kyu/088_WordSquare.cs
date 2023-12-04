/*Challenge link:https://www.codewars.com/kata/578e07d590f2bb8d3300001d/train/csharp
Question:
A Word Square is a set of words written out in a square grid, such that the same words can be read both horizontally and vertically. The number of words, equal to the number of letters in each word, is known as the order of the square.

For example, this is an order 5 square found in the ruins of Herculaneum:



Given a string of various uppercase letters, check whether a Word Square can be formed from it.

Note that you should use each letter from letters the exact number of times it occurs in the string. If a Word Square can be formed, return true, otherwise return false.

Example

For letters = "SATORAREPOTENETOPERAROTAS", the output should be WordSquare(letters) = true. It is possible to form a word square in the example above.

For letters = "AAAAEEEENOOOOPPRRRRSSTTTT", (which is sorted form of "SATORAREPOTENETOPERAROTAS"), the output should also be WordSquare(letters) = true.

For letters = "NOTSQUARE", the output should be WordSquare(letters) = false.

Input/Output

[input] string letters

A string of uppercase English letters.

Constraints: 3 ≤ letters.length ≤ 100.

[output] boolean

true, if a Word Square can be formed;

false, if a Word Square cannot be formed.


*/

//***************Solution********************
using System;
using System.Linq;

namespace myjinxin{
    public class Kata{
        public bool WordSquare(string letters){
          //Console.WriteLine(letters);
          //get row Length by square rooting letters length
          var rowLength = Math.Sqrt(letters.Length);
          
          //x and y are the current elements.
          //if rowLength mod 1 is 0 and
          //group elements(x) by letter,
          //count the number of letter(y) in each group if y mod 2 is equal to 1, and less than or equal to rowLength
          //return result as bool value.
          return rowLength % 1 == 0 && 
                 letters.GroupBy(x => x)
                        .Count(y => y.Count() % 2 == 1) <= rowLength;
        }
    }
}

//solution 2
namespace myjinxin
{
    using System.Linq;
    public class Kata
    {
        public bool WordSquare(string letters)=>
          System.Math.Sqrt(letters.Length)%1==0 && letters.GroupBy(ch=>ch).Count(ch=>ch.Count()%2==1) <= System.Math.Sqrt(letters.Length);
    }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;
    using System.Collections.Generic;
    
    [TestFixture]
    public class myjinxin
    {
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public bool An(string letters){
          var len=Math.Sqrt(letters.Length);
          var xx=string.Join("",letters.ToCharArray().OrderBy(x=>x));
          return len%1==0&&Regex.Replace(xx,@"(.)\1","").Length<=len;
        }
        
        public string rndletters(){
          var jl=rndnum.Next(1,100)%3;
          return jl==0?rndbad():rndgood();
        }
        public string rndgood(){
          var len=rndnum.Next(3,9);
          var lone=rndnum.Next(0,len/2)*2+len%2;
          var rest=(len*len-lone)/2;
          var rs=new List<char>();
          for (int i=0;i<lone;i++) rs.Add(rndchar()); 
          for (int i=0;i<rest;i++){
            var t=rndchar();
            rs.Add(t);
            rs.Add(t);
          }
          return rndnum.Next(0,100)%2==0?string.Join("",rs):string.Join("",rs.OrderBy(x=>x));
        }
        public string rndbad(){
          var len=rndnum.Next(3,9);
          var lone=len;
          var rest=len*len-lone;
          var rs=new List<char>();
          for (int i=0;i<lone;i++) rs.Add(rndchar()); 
          for (int i=0;i<rest;i++) rs.Add(rndchar());
          return string.Join("",rs);
        }
        public char rndchar(){
          return (char)rndnum.Next(65,91);
        }
      [Test]
      public void BasicTest(){
      var kata=new Kata();
      var passed="<font size=2 color='#8FBC8F'>Test Passed!</font>";
      Console.WriteLine("<br><font size=4><b>-------- Basic Test --------</b></font>");
      Assert.AreEqual(true, kata.WordSquare("SATORAREPOTENETOPERAROTAS"));
      Console.WriteLine(passed);
      Assert.AreEqual(false, kata.WordSquare("NOTSQUARE"));
      Console.WriteLine(passed);
      Assert.AreEqual(true, kata.WordSquare("BITICETEN"));
      Console.WriteLine(passed);
      Assert.AreEqual(false, kata.WordSquare("CODEWARS"));
      Console.WriteLine(passed);
      Assert.AreEqual(true, kata.WordSquare("AAAAACEEELLRRRTT"));
      Console.WriteLine(passed);
      Assert.AreEqual(true, kata.WordSquare("AAACCEEEEHHHMMTT"));
      Console.WriteLine(passed);
      Assert.AreEqual(false, kata.WordSquare("AAACCEEEEHHHMMTTXXX"));
      Console.WriteLine(passed);
      Assert.AreEqual(false, kata.WordSquare("ABCD"));
      Console.WriteLine(passed);
      Assert.AreEqual(true, kata.WordSquare("GHBEAEFGCIIDFHGG"));
      Console.WriteLine(passed);
     }
     [Test]
     public void RandomTest(){       
         var kata=new Kata();
         var passed="<font size=2 color='#8FBC8F'><b>Test Passed!</b></font>";
            Console.WriteLine("<br><font size=4><b>--------100 Random Test --------</b></font>");
            Console.WriteLine("");
            for (int i=0;i<100;i++){
              var l=rndletters();
              var answer=An(l);
              Console.WriteLine("<font size=2 color='#CFB53B'>Test for: letters=\""+l+"\"</font>");
              Assert.AreEqual(answer, kata.WordSquare(l));
              Console.WriteLine("<font size=2 color='#8FBC8F'>Test Passed! Passed Value="+answer+"</font>");
            }
            
        }        
    }
}	
