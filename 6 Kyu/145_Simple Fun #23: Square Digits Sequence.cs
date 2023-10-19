/*Challenge link:https://www.codewars.com/kata/5886d65e427c27afeb0000c1/train/csharp
Question:
Task
Consider a sequence of numbers a0, a1, ..., an, in which an element is equal to the sum of squared digits of the previous element. The sequence ends once an element that has already been in the sequence appears again.

Given the first element a0, find the length of the sequence.

Example
For a0 = 16, the output should be 9

Here's how elements of the sequence are constructed:

a0 = 16

a1 = 12 + 62 = 37

a2 = 32 + 72 = 58

a3 = 52 + 82 = 89

a4 = 82 + 92 = 145

a5 = 12 + 42 + 52 = 42

a6 = 42 + 22 = 20

a7 = 22 + 02 = 4

a8 = 42 = 16, which has already occurred before (a0)

Thus, there are 9 elements in the sequence.

For a0 = 103, the output should be 4

The sequence goes as follows: 103 -> 10 -> 1 -> 1, 4 elements altogether.

Input/Output
[input] integer a0

First element of a sequence, positive integer.

Constraints: 1 ≤ a0 ≤ 650.

[output] an integer
*/

//***************Solution********************
namespace myjinxin {
  using System.Collections.Generic;
  using System.Linq;
  
  public class Kata {
    public int SquareDigitsSequence(int n) {
      //create hashset 
      var s = new HashSet<int>();
      
      //while hashset doesn't contain the number n
      //add n
      //convert n to string, get current character - 48(ascii value)
      //aggregate n + d * d
      while (!s.Contains(n)) {
        s.Add(n);
        n = n.ToString().Select(c => c - 48).Aggregate(0,(n,d) => n + d * d);
      }
      //return s.count add 1
      return s.Count + 1;
    }
  }
}

//****************Sample Test*****************
namespace myjinxin
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    [TestFixture]
    public class CsharpTest
    {
        public int An(int a0){
          var r=new List<int>();
          r.Add(a0);
          while(a0>0){
            var t=testsum(r[r.Count-1]);
            if(r.Contains(t)) return r.Count+1;
            r.Add(t);
          }
          return -1;
        }
        public int testsum(int n){
          var rr=0d;
          for(;n>0;n/=10){
            rr+=Math.Pow(n%10,2);
          }
          return (int)rr;
        }
        public int[] rndtest(){
          var ddd=rand(1,650);
          return new int[]{ddd};
        }
        
        Random rndnum=new Random(unchecked((int)DateTime.Now.Ticks));
        public int rand(int a,int b){
          return a>b?rand(b,a):rndnum.Next(a,b+1);
        }
        
        
        [Test]
        public void Test1__Basic_Tests(){
            var kata=new Kata();
            Assert.AreEqual(9,  kata.SquareDigitsSequence(16));
            Assert.AreEqual(4,  kata.SquareDigitsSequence(103));
            Assert.AreEqual(2,  kata.SquareDigitsSequence(1));
            
        }
        
        [Test]
        public void Test2__100_Random_Tests(){
          var kata=new Kata();
          for (int i=0;i<100;i++){
              var ab=rndtest();
              var answer=An(ab[0]);
              Assert.AreEqual(answer, kata.SquareDigitsSequence(ab[0]));
            }
        }
    }
}	
