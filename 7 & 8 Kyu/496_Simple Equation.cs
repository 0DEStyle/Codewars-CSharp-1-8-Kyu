/*Challenge link:https://www.codewars.com/kata/563fd46f2a1863685f000052/train/csharp
Question:
Help to solve a simple mathematic equation. You receive a sting in the following format:

x + a = b
x * a = b
x - a = b
x / a = b
a and b are double number between -100000 and 100000 Your task is to complete the method to solve the equation and return a string in the following format:

x = c
The c should be a number with two decimal place. Take a look on test cases :)
*/

//***************Solution********************
//split string equation by space
//index x => 0, operator => 1, num1 => 2, equal sign => 3, num2 => 4
//parse num1 and num2 to double, and use reverse operator to find x.
using System;
using System.Linq;
namespace Equation {
    public class Kata{
        public static string SolveTheEquation(string equation){
          
          var str = equation.Split();
          double num1 = double.Parse(str[2]), num2 = double.Parse(str[4]);
          return "x = " + (str[1] == "+" ? num2 - num1 :
                           str[1] == "-" ? num2 + num1 :
                           str[1] == "/" ? num2 * num1 :
                           Math.Round(num2 / num1, 2));
        }
    }
}

//****************Sample Test*****************
namespace Equation {
  using NUnit.Framework;
  using System.Collections.Generic;
  using System.Linq;
  using System;
  
  [TestFixture]
  public class EquationTest
  {
    [Test]
        public void TestPlus()
        {
            StringAssert.AreEqualIgnoringCase("x = 17", Kata.SolveTheEquation("x + 85 = 102"),
                "Plus operator test failed");
        }

        [Test]
        public void TestMultiply()
        {
            StringAssert.AreEqualIgnoringCase("x = 68.15", Kata.SolveTheEquation("x * 1358 = 92548"),
                "Multiply operator test failed");
        }

        [Test]
        public void TestMinus()
        {
            StringAssert.AreEqualIgnoringCase("x = 6553", Kata.SolveTheEquation("x - 1003 = 5550"),
                "Minus operator test failed");
        }

        [Test]
        public void TestDivide()
        {
            StringAssert.AreEqualIgnoringCase("x = 63250", Kata.SolveTheEquation("x / 5 = 12650"),
                "Divide operator test failed");
        }

        [Test]
        public void RandomTest([Values(1)] int x, [Random(-1, 1, 25)] double d)
        {
            string equation = Equation.CreateTheEquation();
            StringAssert.AreEqualIgnoringCase(KataTest.MySolveTheEquationTest(equation), Kata.SolveTheEquation(equation),
                string.Format("The result for equation {0} should retuen {1}, but it was {2}", equation,
                    KataTest.MySolveTheEquationTest(equation), Kata
                        .SolveTheEquation(equation)));
        }
  }
}
