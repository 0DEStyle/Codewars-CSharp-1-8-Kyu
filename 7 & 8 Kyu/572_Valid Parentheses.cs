/*Challenge link:https://www.codewars.com/kata/6411b91a5e71b915d237332d/train/csharp
Question:
Write a function that takes a string of parentheses, and determines if the order of the parentheses is valid. The function should return true if the string is valid, and false if it's invalid.

Examples
"()"              =>  true
")(()))"          =>  false
"("               =>  false
"(())((()())())"  =>  true
Constraints
0 <= length of input <= 100

All inputs will be strings, consisting only of characters ( and ).
Empty strings are considered balanced (and therefore valid), and will be tested.
For languages with mutable strings, the inputs should not be mutated.

Protip: If you are trying to figure out why a string of parentheses is invalid, paste the parentheses into the code editor, and let the code highlighting show you!
*/

//***************Solution********************
//while str contains "()"
//replace "()" with nothing
//return bool value of str.Length == 0
public class Kata {
  public static bool ValidParentheses(string str) {
    while(str.Contains("()"))
          str = str.Replace("()", "");
    return str.Length == 0;
  } 
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using NUnit.Framework;

[TestFixture]
public class FixedTests
{
  [Test]
  public void TestValidParentheses()
  {
    DoTest(true, "()");
    DoTest(true, "((()))");
    DoTest(true, "()()()");
    DoTest(true, "(()())()");
    DoTest(true, "()(())((()))(())()");
  }
  
  [Test]
  public void TestInvalidParentheses()
  {
    DoTest(false, ")(");
    DoTest(false, "()()(");
    DoTest(false, "((())");
    DoTest(false, "())(()");
    DoTest(false, ")()");
    DoTest(false, ")");        
  }
  
  [Test]
  public void TestEmptyString()
  {
    DoTest(true, "");
  }
  
  private void DoTest(bool expected, string str) {
    Assert.AreEqual(expected, Kata.ValidParentheses(str), $"Incorrect answer for str = \"{str}\"");
  }
}

[TestFixture]
public class RandomTests
{
  private Random rnd = new Random();
  
  private List<string> GenerateValidInput(int pairs) {  
    List<string> chunks = new List<string>();
    while(pairs > 0) {      
      int pairsInSegment = rnd.Next(1, pairs+1);    
      pairs -= pairsInSegment;
      int balance = 0;
      var chunk = new StringBuilder("(");
      int charsLeft = pairsInSegment * 2 - 2;

      for(; charsLeft > 0; --charsLeft) {
        if(balance == 0) {
          ++balance;
          chunk.Append('(');
        } else if (balance == charsLeft) {
          chunk.Append(')', charsLeft);
          break;
        } else {
          int paren = rnd.Next(2);
          chunk.Append(")("[paren]);
          balance += paren * 2 -1;
        }
      }
      chunk.Append(')');
      chunks.Add(chunk.ToString());
    }
    return chunks;
  }

  private List<T> Shuffle<T>(List<T> items) {
    return items
      .Select (i =>  (Item: i, Key: rnd.Next()))
      .OrderBy(e => e.Key)
      .Select (e => e.Item)
      .ToList ();
  }
  
  private List<(string, bool)> GenerateTestCases(
                                Func<int> genInputSize,
                                int empty, 
                                int valid, 
                                int swapped, 
                                int unbalanced, 
                                int oddlen) {
    
    var cases = new List<(string, bool)>();
    
    // Empty strings
    for(int i=0; i < empty; ++i) {
      cases.Add( ("", true) );
    }
  
    // Valid cases
    for(int i=0; i < valid; ++i) {
      int pairs = genInputSize();
      string input = string.Join("", GenerateValidInput(pairs));
      cases.Add( (input, true) );
    }
  
    // Parens with equal number of ( and ), but in false configuration, such as ")("
    for(int i=0; i < swapped; ++i) {
      int pairs = genInputSize();
      var chunks = GenerateValidInput(pairs);
      int broken = rnd.Next(chunks.Count);
      chunks[broken] = $"){chunks[broken][1..^1]}(";
      string input = string.Join("", chunks);
      cases.Add( (input, false) );
    }
  
    // Generates parens with even number of chars, but with more ) than ( such as "))"
    for(int i=0; i < unbalanced/2; ++i) {
      int pairs = genInputSize();
      var chunks = GenerateValidInput(pairs);
      int broken = rnd.Next(chunks.Count);
      chunks[broken] = ')' + chunks[broken][1..];
      string input = string.Join("", chunks);
      cases.Add( (input, false) );
    }

    // Parens with even number of chars, but with more ( than ) such as "(("
    for(int i=0; i < unbalanced/2; ++i) {
      int pairs = genInputSize();
      var chunks = GenerateValidInput(pairs);
      int broken = rnd.Next(chunks.Count);
      chunks[broken] = chunks[broken][..^1] + '(';
      string input = string.Join("", chunks);
      cases.Add( (input, false) );
    }
                
    // Parens with an odd number of chars, such as "())"
    for(int i=0; i < oddlen; ++i) {
      int pairs = genInputSize();
      var chunks = GenerateValidInput(pairs);
      string input = string.Join("", chunks);
      int insertPos = rnd.Next(0, input.Length);
      input = input[..insertPos] + ")("[rnd.Next(1)] + input[insertPos..];
      cases.Add( (input, false) );
    }  

    return Shuffle(cases);
  }
  
  [Test]
  public void TestRandomSmall()
  {
    var testCases = GenerateTestCases(() => rnd.Next(1, 13), 2, 14, 6, 4, 4);
    foreach(var(input, expected) in testCases) {
      DoTest(input, expected);
    }
  }
  
  [Test]
  public void TestRandomLarge()
  {
    var testCases = GenerateTestCases(() => rnd.Next(35, 50), 0, 25, 21, 24, 10);
    foreach(var(input, expected) in testCases) {
      DoTest(input, expected);
    }
  }
  
  private void DoTest(string str, bool expected) {
    Assert.AreEqual(expected, Kata.ValidParentheses(str), $"Incorrect answer for str = \"{str}\"");
  }
}
