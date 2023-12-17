/*Challenge link:https://www.codewars.com/kata/52f78966747862fc9a0009ae/train/csharp
Question:
Your job is to create a calculator which evaluates expressions in Reverse Polish notation.

For example expression 5 1 2 + 4 * + 3 - (which is equivalent to 5 + ((1 + 2) * 4) - 3 in normal notation) should evaluate to 14.

For your convenience, the input is formatted such that a space is provided between every token.

Empty expression should evaluate to 0.

Valid operations are +, -, *, /.

You may assume that there won't be exceptional situations (like stack underflow or division by zero).
*/

//***************Solution********************
using System;
using System.Collections.Generic;

public class Calc{
	public double evaluate(String expr){
    var s = new Stack<Double>();
    
    //split expression by space, then loop through each one and push it into stack.
    foreach(var x in expr.Split(" ")){
      switch(x){
          case ""  : s.Push(0); break;
          case "+" : s.Push(s.Pop() + s.Pop()); break;
          case "-" : s.Push(-s.Pop() + s.Pop()); break; //negative sign first
          case "*" : s.Push(s.Pop() * s.Pop()); break;
          case "/" : s.Push(1 / s.Pop() * s.Pop()); break; //reverse first and second stack using 1 / s.Pop
          default  : s.Push(Convert.ToDouble(x)); break;
      }
    }
		return s.Pop();
	}
}

//solution 2
using System;
using System.Collections.Generic;

public class Calc
{
  public double evaluate(string expr)
  {
    var ops = new Dictionary<string, Func<double, double, double>>
    {
        { "+", (a, b) => a + b },
        { "-", (a, b) => b - a },
        { "*", (a, b) => a * b },
        { "/", (a, b) => b / a }
    };

    var stack = new Stack<double>();
    stack.Push(0);

    foreach (var s in expr.Split(" ", StringSplitOptions.RemoveEmptyEntries))
    {
        stack.Push(ops.ContainsKey(s) ? ops[s](stack.Pop(), stack.Pop()) : double.Parse(s));
    }

    return stack.Pop();
  }
}

//solution 3
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class Calc
{
  public double Evaluate(string s)
	{
		if (s.Length == 0) return 0.0;
    if (!(new Regex("\\-?\\d+(\\.\\d+)? \\-?\\d+(\\.\\d+)? [+\\-*/]").IsMatch(s))) return Double.Parse(Enumerable.Reverse(s.Split(' ')).ToArray()[0]);
    return Evaluate(new Regex("(\\-?\\d+(\\.\\d+)?) (\\-?\\d+(\\.\\d+)?) ([+\\-*/])").Replace(s, new MatchEvaluator(m => (m.Groups[5].Value == "+" ? Double.Parse(m.Groups[1].Value) + Double.Parse(m.Groups[3].Value) : m.Groups[5].Value == "-" ? Double.Parse(m.Groups[1].Value) - Double.Parse(m.Groups[3].Value) : m.Groups[5].Value == "*" ? Double.Parse(m.Groups[1].Value) * Double.Parse(m.Groups[3].Value) : Double.Parse(m.Groups[1].Value) / Double.Parse(m.Groups[3].Value)).ToString())));
	}
  public double evaluate(string s) => Evaluate(s);
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class CalcTest
{
	private Calc calc = new Calc();

	[Test]
	public void ShouldWorkWithEmptyString()
	{
		Assert.AreEqual(0, calc.evaluate(""), 0, "Should work with empty string");
	}

	[Test]
	public void ShouldParseNumbers()
	{
		Assert.AreEqual(3, calc.evaluate("3"), 0, "Should parse numbers");
	}

	[Test]
	public void ShouldParseFloatNumbers()
	{
		Assert.AreEqual(3.5, calc.evaluate("3.5"), 0, "Should parse float numbers");
	}

	[Test]
	public void ShouldSupportAddition()
	{
		Assert.AreEqual(4, calc.evaluate("1 3 +"), 0, "Should support addition");
	}

	[Test]
	public void ShouldSupportMultiplication()
	{
		Assert.AreEqual(3, calc.evaluate("1 3 *"), 0, "Should support multiplication");
	}

	[Test]
	public void ShouldSupportSubstraction()
	{
		Assert.AreEqual(-2, calc.evaluate("1 3 -"), 0, "Should support substraction");
	}

	[Test]
	public void ShouldSupportDivision()
	{
		Assert.AreEqual(2, calc.evaluate("4 2 /"), 0, "Should support division");
	}

	[Test]
	public void ShouldWorkWithNumbersLongerThan1Digit()
	{
		Assert.AreEqual(10123, calc.evaluate("10000 123 +"), 0, "Should work with numbers longer than 1 digit");
	}

	[Test]
	public void ShouldWorkWithComplexExpressions()
	{
		Assert.AreEqual(7, calc.evaluate("5 1 2 + 4 * + 3 - 2 /"), 0, "Should work with complex expressions");
	}
}
