/*Challenge link:https://www.codewars.com/kata/553ba31138239b9bc6000037/train/csharp
Question:
Story
On some island lives a chameleon population. Chameleons here can be of only one of three colors - red, green and blue. Whenever two chameleons of different colors meet, they both change their colors to the third one (i.e. when red and blue chameleons meet, they can both become green). There is no other way for chameleons to change their color (in particular, when red and blue chameleons meet, they can't become both red, only third color can be assumed).
Chameleons want to become of one certain color. They may plan they meetings to reach that goal. Chameleons want to know, how fast their goal can be achieved (if it can be achieved at all).

Formal problem
Input:
Color is coded as integer, 0 - red, 1 - green, 2 - blue. Chameleon starting population is given as an array of three integers, with index corresponding to color (i.e. [2, 5, 3] means 2 red, 5 green and 3 blue chameleons). All numbers are non-negative, their sum is between 1 and int.MaxValue (maximal possible value for int type, in other languages). Desired color is given as an integer from 0 to 2.
Output:
Kata.Chameleon should return minimal number of meetings required to change all chameleons to a given color, or -1 if it is impossible (for example, if all chameleons are initially of one other color).

Notes and hints
-- Some tests use rather big input values. Be effective.
-- There is a strict proof that answer is either -1 or no greater than total number of chameleons (thus, return type int is justified). Don't worry about overflow.

Credits
Kata based on "Chameleons" puzzle from braingames.ru: http://www.braingames.ru/?path=comments&puzzle=226 (russian, not translated).
*/

//***************Solution********************
//0 red, 1 green, 2 blue
//chameleons[0] = num.red, chameleons[1] = num.green, chameleons[2] = num.blue
//Goal: return minimal number of meetings required to change all chameleons to a given color, return -1 impossible
using System.Collections;
using System.Linq;

public static class Kata {
  public static int Chameleon(int[] chameleons, int desiredColor){
    //Console.WriteLine(string.Join(", ", chameleons) + " " + desiredColor);
    
    //remove desiredColor from chameList
    var desiredColorChame = chameleons[desiredColor];
    var chameList = chameleons.ToList();
    chameList.RemoveAt(desiredColor);
    
    //check conditions accordingly
    //return -1 if invalid, else return the max value from the chameList.
    return (desiredColorChame == 0 && chameList.Any(x => x == 0)) || 
           ((chameList.First() - chameList.Last()) % 3 != 0) ?
           -1 : chameList.Max();
  }
}

//solution 2
using System;

public static class Kata {
  public static int Chameleon(int[] c, int d) => Check(c[d++], c[d++%3], c[d%3]); 
  public static int Check(int a, int b , int c) => ( Math.Abs(b - c) %3 != 0 || Math.Abs(b - c) /3 > a) 
      ? -1 : Math.Min(b,c)+ Math.Abs(b - c);
}

//solution 3
using System;
using System.Collections;
using System.Linq;

public static class Kata {
  public static int Chameleon(int[] chameleons, int desiredColor)
  {
      return chameleons.Where ((c, i) => i != desiredColor)
        						   .GroupBy(c => chameleons[desiredColor])
        						   .Where (c => c.Key != 0 || c.All (x => x == 0))
        						   .Select(c => c.OrderBy (x => x).ToArray())
        						   .Where (c => (c[1] - c[0]) % 3 == 0)
        						   .Select(c => c[1])
        						   .DefaultIfEmpty(-1)
        						   .First();
  }
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class ChameleonTests
{
  [Test]
  public void AllChameleonsAreWrongColor(){
    try {
      Assert.AreEqual(-1, 
        Kata.Chameleon(new int[]{0, 0, 17}, 1));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  public void OneStepSolution(){
    try {
      Assert.AreEqual(1, 
        Kata.Chameleon(new int[]{1, 1, 15}, 2));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  public void AverageSituation(){
    try {
      Assert.AreEqual(35, 
        Kata.Chameleon(new int[]{34, 32, 35}, 0));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }  

  [Test]
  //Thanks to AlexIsHappy for pointing this
  public void AverageImpossible(){
    try {
      Assert.AreEqual(-1, 
        Kata.Chameleon(new int[]{34, 32, 35}, 1));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }  

  [Test]
  //Thanks to AlexIsHappy for pointing this
  public void OneColorCanBeZero(){
    try {
      int answer = Kata.Chameleon(new int[]{33, 0, 35}, 2);
      Assert.AreNotEqual(-1, answer);
      if(answer != 33)
        Assert.Fail("Wrong answer: " + answer);
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }  

  [Test]
  public void RandomImpossible(){
    try{
      Random r = new Random();
      
      Assert.AreEqual(-1, Kata.Chameleon
        (new int[]{
          r.Next(0, 98435)*3+1, 
          r.Next(0, 98454)*3+2,
          0}, r.Next(0,3)));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  public void RandomPossible(){
    try{
      Random r = new Random();
      int red = r.Next(0, 98435)*3+1;
      int green = r.Next(0, 98454)*3+1;
      int target = r.Next(0,3);
      int answer = Kata.Chameleon
        (new int[]{ red, green, 1}, target);
      
      Assert.AreNotEqual(-1, answer);
      if(target == 0 && answer==green) return;
      if(target == 1 && answer==red) return;
      if(target == 2 && answer==Math.Max(red, green)) return;
      Assert.Fail("Wrong answer: " + answer);
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  public void BigNumbersImpossible(){
    try{
      Random r = new Random();
      
      Assert.AreEqual(-1, Kata.Chameleon
        (new int[]{
          r.Next(45628459, 165734902)*3+1, 
          r.Next(45628459, 165734902)*3+2,
          r.Next(45628459, 165734902)*3}, r.Next(0,3)));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  public void BigNumbersPossible(){
    try{
      int answer = Kata.Chameleon
        (new int[]{673905669, 673905681, 174867657}, 2);
      if(answer != 673905681) 
        Assert.Fail("Wrong answer: " + answer);
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  // For 0-step solution
  public void ObscuredTest1(){
    try{
      Assert.AreEqual(0, 
        Kata.Chameleon(new int[]{74356, 0, 0}, 0));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  // For sum precisely equal to int.MaxValue
  public void ObscuredTest2(){
    try{
      Assert.AreEqual(1, 
        Kata.Chameleon(new int[]{1, int.MaxValue-2, 1}, 1));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }
  }
  
  [Test]
  // For only one chameleon
  public void ObscuredTest3(){
    try{
      Assert.AreEqual(-1, 
        Kata.Chameleon(new int[]{0, 1, 0}, 2));
      Assert.AreEqual(0, 
        Kata.Chameleon(new int[]{0, 1, 0}, 1));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }        
  }
  
  [Test]
  // For all chameleons of one color with quantity 3*k
  // Thanks to jolaf for pointing this
  public void ObscuredTest4(){
    try{
      Assert.AreEqual(-1, 
        Kata.Chameleon(new int[]{0, 333, 0}, 0));
    } catch(Exception ex){
      Assert.Fail(ex.Message);
    }        
  }
}
