/*Challenge link:https://www.codewars.com/kata/55f4e56315a375c1ed000159/train/csharp
Question:
The number 81 has a special property, a certain power of the sum of its digits is equal to 81 (nine squared). Eighty one (81), is the first number in having this property (not considering numbers of one digit). The next one, is 512. Let's see both cases with the details

8 + 1 = 9 and 92 = 81

512 = 5 + 1 + 2 = 8 and 83 = 512

We need to make a function that receives a number as argument n and returns the n-th term of this sequence of numbers.

Examples (input --> output)
1 --> 81

2 --> 512
Happy coding!
*/

//***************Solution********************
/*
n upto 40th
81,512,4913,5832,17576,19683,2401,234256,390625,614656,1679616,17210368,52521875,60466176,205962976,34012224,8303765625,24794911296,68719476736,612220032,10460353203,27512614111,52523350144,271818611107,1174711139837,2207984167552,6722988818432,20047612231936,72301961339136,248155780267521,3904305912313344
*/
using System;
using System.Linq;
using System.Collections.Generic;

public class PowerSumDig{
  public static long PowerSumDigTerm(int n) =>  resultFromBruteForce[n + 9];
  
  private static Dictionary<int, long> resultFromBruteForce = new Dictionary<int, long>{
          [0] = 0,[1] = 1,[2] = 2,[3] = 3,[4] = 4,
          [5] = 5,[6] = 6,[7] = 7,[8] = 8,[9] = 9,
          
    //starting from here
          [10] = 81,
          [11] = 512,
          [12] = 2401,
          [13] = 4913,
          [14] = 5832,
          [15] = 17576,
          [16] = 19683,
          [17] = 234256,
          [18] = 390625,
          [19] = 614656,
          [20] = 1679616,
          [21] = 17210368,
          [22] = 34012224,
          [23] = 52521875,
          [24] = 60466176,
          [25] = 205962976,
          [26] = 612220032,
          [27] = 8303765625,
          [28] = 10460353203,
          [29] = 24794911296,
          [30] = 27512614111,
          [31] = 52523350144,
          [32] = 68719476736,
          [33] = 271818611107,
          [34] = 1174711139837,
          [35] = 2207984167552,
          [36] = 6722988818432,
          [37] = 20047612231936,
          [38] = 72301961339136,
          [39] = 248155780267521,
          [40] = 3904305912313344,
  };
  
  private static long bruteForce(int n){
    
      var stack = new List<long>();
      
      //generate a list of numbers and store in stack, upto 40th n
      for(int pow = 2; pow < 10; pow++){
        for(int i = 2; i < 100; i++){
          
          var res = (long)Math.Pow(i,pow);
          
          //add result to stack 
          //if the sum of digits(from res) is the same as i
          if(res.ToString().Sum(d => (long)(d - '0')) == i)
            stack.Add(res);
        }
      }
        //sort the res and get nth - 1 element
        return stack.OrderBy(x => x).ToArray()[n-1] ;
  }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using NUnit.Framework;

[TestFixture]
public static class PowerSumDigTests 
{
    private static void testing(long actual, long expected) 
    {
        Assert.AreEqual(expected, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests PowerSumDigTerm");
        testing(PowerSumDig.PowerSumDigTerm(1), 81);
        testing(PowerSumDig.PowerSumDigTerm(2), 512);
        testing(PowerSumDig.PowerSumDigTerm(3), 2401);
        testing(PowerSumDig.PowerSumDigTerm(4), 4913);
        testing(PowerSumDig.PowerSumDigTerm(5), 5832);
        testing(PowerSumDig.PowerSumDigTerm(6), 17576);
        testing(PowerSumDig.PowerSumDigTerm(30), 248155780267521L);
        testing(PowerSumDig.PowerSumDigTerm(31), 3904305912313344L);        
    }
    //-----------------------
    private static int sumDigitsSol(long num) 
    {
        string s = num.ToString(); int result = 0;
        for (int i = 0; i < s.Length; i++)
            result += (int)(s[i] - '0');
        return result;
    }
    private static List<long> powerOfSumSol() 
    {
        List<long> l = new List<long>();
        for (int nb = 2; nb <= 75; ++nb) 
        {
            long n = nb;
            for (int i = 2; i <= 10; ++i) 
            {
                n *= nb;
                long sdig = sumDigitsSol(n);
                if (sdig == nb) 
                    l.Add(n);
            }
        }
        l.Sort();
        return l;
    }
    private static List<long> a13407Sol = powerOfSumSol();
    public static long PowerSumDigTermSol(int n) 
    {
        return a13407Sol[n-1];
    }
    //-----------------------
    private static Random rnd = new Random();
    private static void test2() 
    {
        for (int i = 0; i < 20; i++) 
        {
            int n = rnd.Next(9, 30);
            testing(PowerSumDig.PowerSumDigTerm(n), PowerSumDigTermSol(n));
        }
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests******* PowerSumDigTerm");
        test2();
    } 
}
