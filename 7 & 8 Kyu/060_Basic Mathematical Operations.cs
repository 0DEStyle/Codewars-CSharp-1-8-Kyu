/*Challenge link:https://www.codewars.com/kata/57356c55867b9b7a60000bd7/train/csharp
Question:
Your task is to create a function that does four basic mathematical operations.

The function should take three arguments - operation(string/char), value1(number), value2(number).
The function should return result of numbers after applying the chosen operation.

Examples(Operator, value1, value2) --> output
('+', 4, 7) --> 11
('-', 15, 18) --> -3
('*', 5, 5) --> 25
('/', 49, 7) --> 7
*/

//***************Solution********************
//check operation, return result.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution
{
  public static class Program
  {
    public static double basicOp(char operation, double value1, double value2)
    {
      if(operation == '+')
        return value1 + value2;
      if(operation == '-')
        return value1 - value2;
      if(operation == '*')
        return value1 * value2;
      
        return value1 / value2;
    }
  }
}

//solution 2
//create a new data table, compute number1 operation number 2, with no spacing
//return result
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Data;

public static class Program
{
  public static double basicOp(char op, double a, double b) =>
  Convert.ToDouble(new DataTable().Compute($"{a}{op}{b}", ""));
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void StaticTests()
    {
      Assert.AreEqual(Program.basicOp('+', 4, 7), 11);
      Assert.AreEqual(Program.basicOp('-', 15, 18), -3);
      Assert.AreEqual(Program.basicOp('*', 5, 5), 25);
      Assert.AreEqual(Program.basicOp('/', 49, 7), 7);
    }
    [Test]
    public void RandomTests()
    {
      char[] ops = { '+', '-', '*', '/' };
      Random rnd = new Random();
      for (int i = 0; i < 100; i++)
      {
        
        double val1 = rnd.Next(1, 999);
        double val2 = rnd.Next(1, 999);
        
        char op = ops[rnd.Next(1, 4)];
        
        Assert.AreEqual(Program.basicOp(op, val1, val2), getResult(op, val1, val2));
      }
    }
    private static double getResult(char op, double val1, double val2)
    {
      if (op == '+') return val1 + val2;
      if (op == '-') return val1 - val2;
      if (op == '*') return val1 * val2;
      if (op == '/') return val1 / val2;
                     return -1;
    }
  }
}
