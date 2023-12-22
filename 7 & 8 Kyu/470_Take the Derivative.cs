/*Challenge link:https://www.codewars.com/kata/5963c18ecb97be020b0000a2/train/csharp
Question:
This function takes two numbers as parameters, the first number being the coefficient, and the second number being the exponent.

Your function should multiply the two numbers, and then subtract 1 from the exponent. Then, it has to return an expression (like 28x^7). "^1" should not be truncated when exponent = 2.

For example:

derive(7, 8)
In this case, the function should multiply 7 and 8, and then subtract 1 from 8. It should output "56x^7", the first number 56 being the product of the two numbers, and the second number being the exponent minus 1.

derive(7, 8) --> this should output "56x^7" 
derive(5, 9) --> this should output "45x^8" 
Notes:

The output of this function should be a string
The exponent will never be 1, and neither number will ever be 0
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression

//string interpolation to format result.

public class Kata{
  public static string Derive(double coefficient, double exponent) => $"{coefficient * exponent}x^{exponent-1}";
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Diagnostics;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string solution(double co, double ex) => $"{co * ex}x^{ex - 1}";
  
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {7, 8, "56x^7"},
      new object[] {5, 9, "45x^8"},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(double coefficient, double exponent, string expected)
    {
      Assert.AreEqual(expected, Kata.Derive(coefficient, exponent));
    }
    
    [Test, Description("Random Tests (1000 assertions)")]
    public void Random_Test()
    {
      Stopwatch sw = new Stopwatch();
      const int tests = 1000;
      
      for (int i = 0; i < tests; ++i)
      {
        double co = (int)(rnd.NextDouble() * 499) + 1;
        double ex = (int)(rnd.NextDouble() * 498) + 2;
        string expected = solution(co, ex);
        
        sw.Start();
        string actual = Kata.Derive(co, ex);
        sw.Stop();
        
        Assert.AreEqual(expected, actual);
      }
      
      Console.WriteLine("Random tests passed!\nUser code execution time was {0} milliseconds over {1} assertions.", sw.Elapsed.TotalMilliseconds, tests);
    }
  }
}
