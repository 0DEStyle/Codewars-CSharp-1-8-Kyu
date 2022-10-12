/*Challenge link:https://www.codewars.com/kata/52774a314c2333f0a7000688/train/csharp
Question:
Write a function that takes a string of parentheses, and determines if the order of the parentheses is valid. The function should return true if the string is valid, and false if it's invalid.

Examples
"()"              =>  true
")(()))"          =>  false
"("               =>  false
"(())((()())())"  =>  true
Constraints
0 <= input.length <= 100

Along with opening (() and closing ()) parenthesis, input may contain any valid ASCII characters. Furthermore, the input string may be empty and/or not contain any parentheses at all. Do not treat other forms of brackets as parentheses (e.g. [], {}, <>).
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

public class Parentheses
{
    public static bool ValidParentheses(string input){
      int lengthCheck = input.Length; //this is used for checking the difference
      
      while(input.Length != 0){
        input = Regex.Replace(input, "[a-zA-Z]", ""); //remove pattern: any character 
        input = Regex.Replace(input, @"\(\)", "");    //remove pattern: ()
        
    if (lengthCheck == input.Length || input.Length == 0){ //if length check stays the same, or reached 0
        if(input.Length != 0) //if input length is not zero, meaning there are brackets left
            return false;
        return true; 
    }else
        lengthCheck = input.Length; //overwrite lengthcheck, more parentheses to check!
      }
      
      if(input.Length == 0) //if string is empty, return true.
        return true;
      return false;
    }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    [Test, Description("Fixed Tests (Random Order)")]
    public void FixedTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( ")" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "(" )),
        () => Assert.AreEqual(true, Parentheses.ValidParentheses( "" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "hi)(" )),
        () => Assert.AreEqual(true, Parentheses.ValidParentheses( "hi(hi)" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "(" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "hi(hi)(" )),
        () => Assert.AreEqual(true, Parentheses.ValidParentheses( "((())()())" )),
        () => Assert.AreEqual(true, Parentheses.ValidParentheses( "(c(b(a)))(d)" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "hi(hi))(" )),
        () => Assert.AreEqual(false, Parentheses.ValidParentheses( "())(()" )),
      };
      
      tests.OrderBy(_ => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
  }
}
