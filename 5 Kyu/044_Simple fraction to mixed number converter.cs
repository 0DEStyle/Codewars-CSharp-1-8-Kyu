/*Challenge link:https://www.codewars.com/kata/556b85b433fb5e899200003f/train/csharp
Question:
Task
Given a string representing a simple fraction x/y, your function must return a string representing the corresponding mixed fraction in the following format:

[sign]a b/c

where a is integer part and b/c is irreducible proper fraction. There must be exactly one space between a and b/c. Provide [sign] only if negative (and non zero) and only at the beginning of the number (both integer part and fractional part must be provided absolute).

If the x/y equals the integer part, return integer part only. If integer part is zero, return the irreducible proper fraction only. In both of these cases, the resulting string must not contain any spaces.

Division by zero should raise an error (preferably, the standard zero division error of your language).

Value ranges
-10 000 000 < x < 10 000 000
-10 000 000 < y < 10 000 000
Examples
Input: 42/9, expected result: 4 2/3.
Input: 6/3, expedted result: 2.
Input: 4/6, expected result: 2/3.
Input: 0/18891, expected result: 0.
Input: -10/7, expected result: -1 3/7.
Inputs 0/0 or 3/0 must raise a zero division error.
Note
Make sure not to modify the input of your function in-place, it is a bad practice.
*/

//***************Solution********************

using System;

public class Kata{
  public static string MixedFraction(string s){
    //splite string by '/' to get number and denominator, then convert to long. no modification of input
      long num = Convert.ToInt64(s.Split('/')[0]);
      long den = Convert.ToInt64(s.Split('/')[1]);
      
    //if denominator is less than 0, return negative
      if (den < 0){ 
        num *= -1; 
        den *= -1; 
      }
      
    //validation check
      if (den == 0)
          throw new DivideByZeroException();

    //function to check format and carrier of num.
      Func<long, long, long> gcd = null;
      gcd = (a, b) => b == 0 ?
                           a :
                           gcd(b, a % b);
    //if number mod denominator is not perfectly rounded.
      if (num % den != 0)
          return string.Format("{0} {1}/{2}", num / den == 0 ? string.Empty : (num / den).ToString(),
                                              num / den == 0 ? (num % den) / Math.Abs(gcd.Invoke(num, den)) : Math.Abs((num % den) / gcd.Invoke(num, den)),
                                              num / den == 0 ? den / Math.Abs(gcd.Invoke(num, den)) : Math.Abs(den / gcd.Invoke(num, den))).Trim();
      else
          return (num / den).ToString();
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;  
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("4 2/3", Kata.MixedFraction("42/9"));
      Assert.AreEqual("2", Kata.MixedFraction("6/3"));
      Assert.AreEqual("1", Kata.MixedFraction("1/1"));
      Assert.AreEqual("1", Kata.MixedFraction("11/11"));
      Assert.AreEqual("2/3", Kata.MixedFraction("4/6"));
      Assert.AreEqual("0", Kata.MixedFraction("0/18891"));
      Assert.AreEqual("-1 3/7", Kata.MixedFraction("-10/7"));
      Assert.AreEqual("3 1/7", Kata.MixedFraction("-22/-7"));
      Assert.AreEqual("-195595/564071", Kata.MixedFraction("-195595/564071")); // Special-Test ;-)
      
      Assert.Throws(typeof(DivideByZeroException), delegate { Kata.MixedFraction("0/0"); } );
      Assert.Throws(typeof(DivideByZeroException), delegate { Kata.MixedFraction("3/0"); } );
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<string,string> MyMixedFraction = delegate (string s)
      {
        var sign = "";
        var result = "";
        if(s.Count(c => c == '-') % 2 != 0)
        {
          sign = "-";
        }
        var parts = s.Split('/');
        var d1 = Math.Abs(int.Parse(parts[0]));
        var d2 = Math.Abs(int.Parse(parts[1]));
        if(d2 == 0)
        {
          throw new DivideByZeroException();
        }    
  
        result += d1 / d2;
        var remainder = d1 % d2;

        if(result == "0" && remainder != 0)
        {
          result = "";
        }

        if(remainder != 0)
        {
          result += " ";
    
          var y = remainder;
    
          while((d2 % y != 0) || (remainder % y != 0))
          {
            y--;
          }    
  
          result += remainder/y + "/" + d2/y;
        }
        result = sign + result.Trim();
        if(result.StartsWith("-0"))
        {
          if(result.Length>2)
          {
            result = result.Substring(3);
          }
          else
          {
            result = "0";
          }
        }
        return result.Trim();
      };
      
      for (var r=0;r<40;r++)
      {
        var exp = rand.Next(1,4);
        var a=Math.Pow(-1, rand.Next(0,2)) * rand.Next(0, (int)Math.Pow(10, exp) + 1);
        var b=Math.Pow(-1, rand.Next(0,2)) * rand.Next(0, (int)Math.Pow(10, exp) + 1);
        var s = a + "/" + b;

        if (b==0)
        {
          Assert.Throws(typeof(DivideByZeroException), delegate { Kata.MixedFraction(s); } );
        }
        else
        {
          Assert.AreEqual(MyMixedFraction(s), Kata.MixedFraction(s), "It should work for random inputs too");
        }
      }
      
      Func<int> r39214 = delegate ()
      {
        return rand.Next(-999999,1000000);
      };
      
      Action<int, int> checker32817409 = delegate (int p, int q)
      {
        var s = p + "/" + q;
        if (q == 0)
        {
          Assert.Throws(typeof(DivideByZeroException), delegate { Kata.MixedFraction(s); } );
        }
        else
        {
          Assert.AreEqual(MyMixedFraction(s), Kata.MixedFraction(s), "It should work for random inputs too");
        }
      };

      // Generate simple test cases
      for (var i=0;i<36;i++)
      {
        var x=r39214();
        var y=r39214();
        checker32817409(x, y);
      }

      // Generate test cases with abs(result) below one
      for (var i=0;i<20;i++)
      {
        var arr = new int[] { r39214(), r39214() }.OrderBy(a => Math.Abs(a)).ToArray();
        checker32817409(arr[0], arr[1]);
      }
  
      // Generate test cases with zero result
      for (var i=0;i<9;i++)
      {
        var x=0;
        var y=r39214();
        checker32817409(x, y);
      }

      // Generate a test case with division by zero
      for (var i=0;i<5;i++)
      {
        var x=r39214();
        var y=0;
        checker32817409(x, y);
      }      
    }
  }
}
