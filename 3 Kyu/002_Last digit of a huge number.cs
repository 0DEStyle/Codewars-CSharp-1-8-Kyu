/*Challenge link:https://www.codewars.com/kata/5518a860a73e708c0a000027/train/csharp
Question:
For a given list [x1, x2, x3, ..., xn] compute the last (decimal) digit of x1 ^ (x2 ^ (x3 ^ (... ^ xn))).

E. g., with the input [3, 4, 2], your code should return 1 because 3 ^ (4 ^ 2) = 3 ^ 16 = 43046721.

Beware: powers grow incredibly fast. For example, 9 ^ (9 ^ 9) has more than 369 millions of digits. lastDigit has to deal with such numbers efficiently.

Corner cases: we assume that 0 ^ 0 = 1 and that lastDigit of an empty list equals to 1.

This kata generalizes Last digit of a large number; you may find useful to solve it beforehand.
*/

//***************Solution********************
//ref: https://www.quora.com/How-can-I-find-the-last-digit-of-a-b-c-if-all-numbers-are-very-large
//https://stackoverflow.com/questions/53960629/compute-the-last-decimal-digit-of-x1-x2-x3-xn

namespace Solution{
    using System;
    using System.Linq;

    public class Calculator{
        public static int LastDigit(int[] array){
          //check empty
            if (array.Length == 0)
                return 1;
          //get last element of array
            int lastNum = array.Last();
            
          //reverse array skip first
            foreach (int i in array.Reverse().Skip(1)){
                int power = lastNum;
                switch (power){
                    //corner case 0 = 1
                    case 0:
                        lastNum = 1;
                        break;
                    // 1 set lastNum to i
                    case 1:
                        lastNum = i;
                        break;
                    // 2 set lastNum to i^2
                    case 2:
                        lastNum = i * i;
                        break;
                    default:
                        power = (power - 3) % 4 + 3;
                        int n = i < 3 ? i : (i - 3) % 20 + 3;
                        lastNum = (int)Math.Pow(n, power);
                        break;
                }
            }
          
          //reduce size by mod 10
            return lastNum % 10;
        }
    }
}
//method 2
namespace Solution
{
  using System;
  using System.Linq;
  
  public class Calculator
  {
    public static int LastDigit(int[] a) => Enumerable.Range(0, a.Length).Reverse().Aggregate(1, (p, i) => (int)Math.Pow(i == 0 ? a[i] % 10 : a[i] < 4 ? a[i] : a[i] % 4 + 4, p < 4 ? p : p % 4 + 4)) % 10;
  }
}

//method 3
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
namespace Solution 
{
  public class Calculator 
  {
    public static int LastDigit(int[] array) 
    {
      BigInteger t = 1;
      var arr = array.Reverse().ToList();

      foreach(var x in arr)
      {
        if(t < 4)
          t = BigInteger.Pow(x,int.Parse(t.ToString()));
        else
        {
          int exponent = int.Parse(BigInteger.ModPow(t,1,4).ToString()) + 4;
          t = BigInteger.Pow(x,exponent);
        }
      }
      
      return (int)BigInteger.ModPow(t,1,10);
    }
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  
  public struct LDCase {
    public int[] test;
    public int expect;
    public LDCase(int[] t, int e) {
        test = t;
        expect = e;
    }
  }

  [TestFixture]
  public class SolutionTest {
    private static int CalculateLD(int[] array) {
      int ans = 1;
      for(int i=array.Length-1; i>=0;i--) {
        int exp = ans;
        if(ans >= 4) {
          exp = ans%4+4;
        }
        int b = array[i]%4+4;
        if(i == 0) {
          b = array[i]%10;
        }
        else if(array[i] < 4) {
          b = array[i];
        }
        ans = (int)(Math.Pow(b, exp));
      }
      return ans%10;
    }
    
    [Test]
    public void SampleTest() {
      LDCase[] allCases = new LDCase[] {
        new LDCase(new int[0],           1),
        new LDCase(new int[] {0,0},      1),
        new LDCase(new int[] {0,0,0},    0),
        new LDCase(new int[] {1,2},      1),
        new LDCase(new int[] {3,3,1},    7),
        new LDCase(new int[] {3,3,2},    3),
        new LDCase(new int[] {3,5,3},    3),
        new LDCase(new int[] {3,4,5},    1),
        new LDCase(new int[] {4,3,6},    4),
        new LDCase(new int[] {7,6,1},    9),
        new LDCase(new int[] {7,6,2},    1),
        new LDCase(new int[] {7,6,21},   1),
        new LDCase(new int[] {12,30,21}, 6),
        new LDCase(new int[] {2,0,1},    1),
        new LDCase(new int[] {2,2,2,0},  4),
        new LDCase(new int[] {2,2,101,2},6),
        new LDCase(new int[] {4,0},      1),
        new LDCase(new int[] {3,0,0},    3),
        new LDCase(new int[] {2,2,1},    4),
        new LDCase(new int[] {2,2,1,2},  4),
        new LDCase(new int[] {3,3,0,0},  7),
        new LDCase(new int[] {3,4,0},    3),
        new LDCase(new int[] {3,2,1,4,4},9),
        new LDCase(new int[] {5,0},      1),
        new LDCase(new int[] {2,3,2},    2),
        new LDCase(new int[] {82242,254719,736371},  8),
        new LDCase(new int[] {937640,767456,981242}, 0),
        new LDCase(new int[] {123232,694022,140249}, 6),
        new LDCase(new int[] {499942,898102,846073}, 6),
        new LDCase(new int[] {837142,918895,51096},  2),
        new LDCase(new int[] {625703,43898,614961,448629}, 1),
        new LDCase(new int[] {2147483647,2147483647,2147483647,2147483647}, 3)
      };
      for(int i=0; i<allCases.Length;i++) {
        string msg = $"Incorrect answer for array=[{string.Join(", ", allCases[i].test)}]";
        Assert.AreEqual(allCases[i].expect, Calculator.LastDigit(allCases[i].test), msg);
      }
    }
    
    [Test]
    public void RandomTest() {
      Random rnd = new Random();
      
      for(int i=0; i<100;i++) {
        int size = rnd.Next(1,20);
        int[] array1 = new int[size];
        int[] array2 = new int[size];
        int[] array3 = new int[size];
        for(var j=0; j<size;j++) {
          var rand1 = rnd.Next(0,1000000);
          var rand2 = rnd.Next(0,3);
          var rand3 = rnd.Next(0,2);
          if(j == 0) {
            rand1++; rand2++; rand3++;
          }
          array1[j] = rand1;
          array2[j] = rand2;
          array3[j] = rand3;
        }
        
        string msg1 = $"Incorrect answer for array=[{string.Join(", ", array1)}]";
        int expect1 = SolutionTest.CalculateLD(array1);
        Assert.AreEqual(expect1, Calculator.LastDigit(array1), msg1);
        
        string msg2 = $"Incorrect answer for array=[{string.Join(", ", array2)}]";
        int expect2 = SolutionTest.CalculateLD(array2);
        Assert.AreEqual(expect2, Calculator.LastDigit(array2), msg2);
        
        string msg3 = $"Incorrect answer for array=[{string.Join(", ", array3)}]";
        int expect3 = SolutionTest.CalculateLD(array3);
        Assert.AreEqual(expect3, Calculator.LastDigit(array3), msg3);
      }
    }
  }
}
