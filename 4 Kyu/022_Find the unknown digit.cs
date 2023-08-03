/*Challenge link:https://www.codewars.com/kata/546d15cebed2e10334000ed9/train/csharp
Question:
To give credit where credit is due: This problem was taken from the ACMICPC-Northwest Regional Programming Contest. Thank you problem writers.

You are helping an archaeologist decipher some runes. He knows that this ancient society used a Base 10 system, and that they never start a number with a leading zero. He's figured out most of the digits as well as a few operators, but he needs your help to figure out the rest.

The professor will give you a simple math expression, of the form

[number][op][number]=[number]
He has converted all of the runes he knows into digits. The only operators he knows are addition (+),subtraction(-), and multiplication (*), so those are the only ones that will appear. Each number will be in the range from -1000000 to 1000000, and will consist of only the digits 0-9, possibly a leading -, and maybe a few ?s. If there are ?s in an expression, they represent a digit rune that the professor doesn't know (never an operator, and never a leading -). All of the ?s in an expression will represent the same digit (0-9), and it won't be one of the other given digits in the expression. No number will begin with a 0 unless the number itself is 0, therefore 00 would not be a valid number.

Given an expression, figure out the value of the rune represented by the question mark. If more than one digit works, give the lowest one. If no digit works, well, that's bad news for the professor - it means that he's got some of his runes wrong. output -1 in that case.

Complete the method to solve the expression to find the value of the unknown rune. The method takes a string as a paramater repressenting the expression and will return an int value representing the unknown rune or -1 if no such rune exists.
*/

//***************Solution********************

using System.Data;

public class Runes{
  public static int solveExpression(string expression){
    //split expression and answer by "=", where sections[0] is expression and sections[1] is answer
    string[] sections = expression.Split('=');
    DataTable dt = new DataTable();
    
    //check number between number 0 and 9
    for(int i = 0; i <= 9; i++){
      
      //if expression contains number, continue
      if(expression.Contains(i.ToString()))
        continue;
      
      //replace ? from expression with i, replace ? in answer with i, check if the statement is equal
      //if so return i
      if(dt.Compute(sections[0].Replace('?', i.ToString()[0]), "").ToString() == sections[1].Replace('?', i.ToString()[0]))
        return i;
    }
    
    //return -1 if no digit works
    return -1;
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;  

[TestFixture]
public class RunesTest 
{
  [Test]
  public void testSample()
  {
    Assert.AreEqual(2, Runes.solveExpression("1+1=?"), "Answer for expression '1+1=?' ");
    Assert.AreEqual(6, Runes.solveExpression("123*45?=5?088"), "Answer for expression '123*45?=5?088' ");      
    Assert.AreEqual(0, Runes.solveExpression("-5?*-1=5?"), "Answer for expression '-5?*-1=5?' ");
    Assert.AreEqual(-1, Runes.solveExpression("19--45=5?"), "Answer for expression '19--45=5?' ");
    Assert.AreEqual(5, Runes.solveExpression("??*??=302?"), "Answer for expression '??*??=302?' ");
    Assert.AreEqual(2, Runes.solveExpression("?*11=??"), "Answer for expression '?*11=??' ");
    Assert.AreEqual(2, Runes.solveExpression("??*1=??"), "Answer for expression '??*1=??' ");
    Assert.AreEqual(-1, Runes.solveExpression("??+??=??"), "Answer for expression '??+??=??' ");
  }
  
  
  [Test]
  public void EdgeCase() 
  {
    Assert.AreEqual(8, Runes.solveExpression("-?56373--9216=-?47157") );
  }
  
  [Test]
  public void testMultiplication() 
  {
    Assert.AreEqual(0, Runes.solveExpression("123?45*?=?") );
    Assert.AreEqual(0, Runes.solveExpression("?*123?45=?") );
    Assert.AreEqual(1, Runes.solveExpression("??605*-63=-73???5") );
  }
  
  [Test]
  public void testAddition()
  {
    Assert.AreEqual(0 , Runes.solveExpression("123?45+?=123?45") );
    Assert.AreEqual(9 , Runes.solveExpression("?8?170-1?6256=7?2?14") );
    Assert.AreEqual(2 , Runes.solveExpression("?38???+595???=833444") );
  }  
  
  [Test]
  public void testSubtrastion()
  {
    Assert.AreEqual(0 , Runes.solveExpression("123?45-?=123?45") );
    Assert.AreEqual(6 , Runes.solveExpression("-7715?5--484?00=-28?9?5") );
    Assert.AreEqual(4 , Runes.solveExpression("50685?--1?5630=652?8?") );
  }
  
  [Test]
  public void testRandom()
  {
    Random rand = new Random();
    for(int i=0;i<20;i++)
    {
      var digit = rand.Next(1,10);
      int number1 = 0;
      int number2 = 0;
      bool onlyWorkingForDigit = false;
      string numberString1 = "";
      string numberString2 = "";
      string diffString = "";
      do
      {
        do
        {
          number1 = rand.Next(10000,20000);
        }
        while(!number1.ToString().Contains(digit.ToString()));
      
        do
        {
          number2 = rand.Next(10000,20000);
        }
        while(!number2.ToString().Contains(digit.ToString()));      
      
        var diff = number1 - number2;
      
        numberString1 = number1.ToString().Replace(digit.ToString(), "?");
        numberString2 = number2.ToString().Replace(digit.ToString(), "?");
        diffString = diff.ToString().Replace(digit.ToString(), "?");
    
        onlyWorkingForDigit = true;
        for(int j = 1; j < 9; j++)
        {
          if(j != digit)
          {
            var testN1 = numberString1.Replace("?", j.ToString());
            var testN2 = numberString2.Replace("?", j.ToString());
            var testDf = diffString.Replace("?", j.ToString());
            
            if(int.Parse(testN1) - int.Parse(testDf) == int.Parse(testN2))
            {
              onlyWorkingForDigit = false;
            }
          }
        }
      }
      while(!onlyWorkingForDigit);

      Assert.AreEqual(digit , Runes.solveExpression(numberString1 + "-" + diffString + "=" + numberString2) );
    }
  }
}
