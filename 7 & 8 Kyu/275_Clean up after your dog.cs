/*Challenge link:https://www.codewars.com/kata/57faa6ff9610ce181b000028/train/csharp
Question:
You have stumbled across the divine pleasure that is owning a dog and a garden. Now time to pick up all the cr@p! :D

Given a 2D array to represent your garden, you must find and collect all of the dog cr@p - represented by '@'.

You will also be given the number of bags you have access to (bags), and the capactity of a bag (cap). If there are no bags then you can't pick anything up, so you can ignore cap.

You need to find out if you have enough capacity to collect all the cr@p and make your garden clean again.

If you do, return 'Clean', else return 'Cr@p'.

Watch out though - if your dog is out there ('D'), he gets very touchy about being watched. If he is there you need to return 'Dog!!'.

For example:

x=
[[_,_,_,_,_,_]
[_,_,_,_,@,_]
[@,_,_,_,_,_]]

bags = 2, cap = 2

return --> 'Clean' 
*/

//***************Solution********************

//first join the 2d array together with string.join, need to use x.Cast<char>()
//check if str contains the letter 'D', if so return Dog!!
//else ccount the number of '@' in str, if the number is less than or equal to the max capacity
//return clean, else cr@p
using System;
using System.Linq;
public class Kata{
  public static string Crap(char[,] x, int bags, int cap){
    string str = String.Join(" ", x.Cast<char>());
    return str.Contains('D') ? "Dog!!" : str.Count(c=>c == '@') <= bags * cap ? "Clean" : "Cr@p";   
  }
}

//one liner
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Kata
{
  public static string Crap(char[,] x, int bags, int cap)
  {
    return x.Cast<char>().Contains('D') ? "Dog!!" : x.Cast<char>().Count(c => c == '@') > bags * cap ? "Cr@p" : "Clean";
  }
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    private static string Solution(char[,] x, int bags, int cap)
    {
      cap *= bags;
      int crap = 0;
      
      for (int i = 0; i < x.GetLength(0); ++i)
      {
        for (int j = 0; j < x.GetLength(1); ++j)
        {
          if (x[i, j] == 'D') return "Dog!!";
          if (x[i, j] == '@') ++crap;
        }
      }
      
      return crap <= cap ? "Clean" : "Cr@p";
    }
  
    [Test]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        () => Assert.AreEqual("Clean", Kata.Crap(new char[,] {{'_','_','_','_'}, {'_','_','_','@'}, {'_','_','@', '_'}}, 2, 2)),
        () => Assert.AreEqual("Cr@p", Kata.Crap(new char[,] {{'_','_','_','_'}, {'_','_','_','@'}, {'_','_','@', '_'}}, 1, 1)),
        () => Assert.AreEqual("Dog!!", Kata.Crap(new char[,] {{'_','_'}, {'_','@'}, {'D','_'}}, 2, 2)),
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test]
    public void RandomTest()
    {
      char[] names = new char[] {'@', '_', '_', '_', '_', '_', '_', '@', '_', '_', '_', '_', '_', '_', 'D'};
      for (int i = 0; i < 200; ++i)
      {
        int rows = rnd.Next(0, 10);
        int columns = rnd.Next(0, 10);
        char[,] test = new char[rows, columns];
        for (int j = 0; j < rows; ++j)
        {
          for (int k = 0; k < columns; ++k)
          {
            test[j, k] = names[rnd.Next(0, names.Length)];
          }
        }
        int bags = rnd.Next(0, 10);
        int cap = rnd.Next(0, 10);
        string expected = Solution(test, bags, cap);
        string actual = Kata.Crap(test, bags, cap);
        Console.WriteLine($"Expected: {expected}\nActual:   {actual}\n");
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
