/*Challenge link:https://www.codewars.com/kata/5296455e4fe0cdf2e000059f/train/csharp
Question:
Write a function called calculate that takes 3 values. The first and third values are numbers. The second value is a character. If the character is "+" , "-", "*", or "/", the function will return the result of the corresponding mathematical function on the two numbers. If the string is not one of the specified characters, the function should return null (throw an ArgumentException in C#).

calculate(2,"+", 4); //Should return 6
calculate(6,"-", 1.5); //Should return 4.5
calculate(-4,"*", 8); //Should return -32
calculate(49,"/", -7); //Should return -7
calculate(8,"m", 2); //Should return null
calculate(4,"/",0) //should return null
Keep in mind, you cannot divide by zero. If an attempt to divide by zero is made, return null (throw an ArgumentException in C#)/(None in Python).
*/

//***************Solution********************
//using switch case to check operation arithmetic
//for division, if value is 0, throw an exception
//if value is empty, throw an exception too.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
public static class Calculator{
  public static double Execute(double a, char op, double b) => op switch{
                '+' => a + b,
                '-' => a - b,
                '*' => a * b,
                '/' => b == 0 ? throw new ArgumentException() : a / b,
                _ => throw new ArgumentException()
            };
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  
  public static class Solution
  {
    public static double Execute(double num1, char op, double num2)
    {
      switch (op)
      {
        case '+': return num1 + num2;
        case '-': return num1 - num2;
        case '*': return num1 * num2;
        case '/':
        {
          if (num2 == 0)
          {
            throw new ArgumentException();
          }
          else
          {
            return num1 / num2;
          }
        }
        default: throw new ArgumentException();
      }
    }
  }
    
  [TestFixture]
  public class NumbersTest
  {
    [Test]
    public void Test_01()
    {
      Assert.AreEqual(11.2, Calculator.Execute(3.2,'+', 8));
    }
    
    [Test]
    public void Test_02()
    {
      Assert.AreEqual(-4.8, Calculator.Execute(3.2,'-', 8));
    }
    
    [Test]
    public void Test_03()
    {
      Assert.AreEqual(0.4, Calculator.Execute(3.2,'/', 8));
    }
    
    [Test]
    public void Test_04()
    {
      Assert.AreEqual(25.6, Calculator.Execute(3.2,'*', 8));
    }
    
    [Test]
    public void Test_05()
    {
      Assert.AreEqual(-3, Calculator.Execute(-3,'+', 0));
    }
    
    [Test]
    public void Test_06()
    {
      Assert.AreEqual(-3, Calculator.Execute(-3,'-', 0));
    }
    
    [Test]
    public void Test_07()
    {
      Assert.Throws<ArgumentException>(() => Calculator.Execute(-3,'/', 0));
    }
    
    [Test]
    public void Test_08()
    {
      Assert.AreEqual(1, Calculator.Execute(-2, '/', -2));
    }
    
    [Test]
    public void Test_09()
    {
      Assert.AreEqual(0, Calculator.Execute(-3,'*', 0));
    }
    
    [Test]
    public void Test_10()
    {
      Assert.Throws<ArgumentException>(() => Calculator.Execute(-3,'w', 1));
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      char[] choices = new char[] {'a', 'b', 'c', '+', '-', '/', '*'};
      //const int Tests = 1000;
      Random rnd = new Random();
      
      for (int i = 0; i < 1000; ++i)
      {
        double num1 = (double)rnd.Next(0, 11),
               num2 = (double)rnd.Next(0, 11);
        char op = choices[rnd.Next(0, choices.Length)];
        
        if (op != '+' && op != '-' && op != '/' && op != '*')
        {
          Assert.Throws<ArgumentException>(() => Calculator.Execute(num1, op, num2));
        }
        else if (op == '/' && num2 == 0)
        {
          Assert.Throws<ArgumentException>(() => Calculator.Execute(num1, op, num2));
        }
        else
        {
          double expected = Solution.Execute(num1, op, num2);
          double actual = Calculator.Execute(num1, op, num2);
          
          Assert.AreEqual(expected, actual);         
        }  
      }
    }
  }
}
