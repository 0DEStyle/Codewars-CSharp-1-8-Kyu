/*Challenge link:https://www.codewars.com/kata/598106cb34e205e074000031/train/csharp
Question:
Story
The Pied Piper has been enlisted to play his magical tune and coax all the rats out of town.

But some of the rats are deaf and are going the wrong way!

Kata Task
How many deaf rats are there?

Legend
P = The Pied Piper
O~ = Rat going left
~O = Rat going right
Example
ex1 ~O~O~O~O P has 0 deaf rats

ex2 P O~ O~ ~O O~ has 1 deaf rat

ex3 ~O~O~O~OP~O~OO~ has 2 deaf rats
*/

//***************Solution********************

//in string town, replace " " to nothing
//x is current element, i is index
//Count if i mod 2 is 0 and x is 'O'
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class Dinglemouse{
  public static int CountDeafRats(string town) => 
    town.Replace(" ", "").Where((x, i) => i % 2 == 0 && x == 'O').Count();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Text;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
  
    private static int Solution(string town)
    {
      int piedIdx = town.IndexOf("P");
      int deaf = 0;
      
      for (int i = 0; i < town.Length-1; ++i)
      {
        if (town.Substring(i, 2) == "~O")
        {
          if (piedIdx < i)
          {
            ++deaf;
          }
          
          ++i;
        }
        else if (town.Substring(i, 2) == "O~")
        {
          if (piedIdx > i)
          {
            ++deaf;
          }
          
          ++i;
        }
      }
      
      return deaf;
    }
    
    private static string MakeRatFacing(char mostly)
    {
      double d = rnd.NextDouble() * 3;
      if (mostly == 'L')
      {
        // Mostly facing left
        if (d < 2.5) { return "O~"; }
        if (d < 2.8) { return "~O"; }
      }
      else
      {
        // Mostly facing right
        if (d < 2.5) { return "~O"; }
        if (d < 2.8) { return "O~"; }
      }
      return " ";
    }
    
    private static string MakeTown(char piperPos)
    {
      int ratsLeft = rnd.Next(5, 25);
      int ratsRight = rnd.Next(5, 25);
      StringBuilder town = new StringBuilder();
      bool piper = false;
      if (piperPos == 'L')
      {
        town.Append('P');
        piper = true;
      }
      for (int r = 0; r < ratsLeft; ++r)
      {
        town.Append(MakeRatFacing(piper ? 'L' : 'R'));
      }
      if (piperPos == 'M')
      {
        town.Append('P');
        piper = true;
      }
      for (int r = 0; r < ratsRight; ++r)
      {
        town.Append(MakeRatFacing(piper ? 'L' : 'R'));
      }
      if (piperPos == 'R') { town.Append('P'); }
      return town.ToString();
    }
  
    private static object[] Basic_Test_Cases = new object[]
    {
      new object[] {"~O~O~O~O P", 0},
      new object[] {"P O~ O~ ~O O~", 1},
      new object[] {"~O~O~O~OP~O~OO~", 2},
    };
    
    private static object[] Extra_Test_Cases = new object[]
    {
      new object[] {"O~~OO~~OO~~OO~P~OO~~OO~~OO~~O", 8},
      new object[] {"O~~OO~~OO~~OO~ P~OO~~OO~~OO~~O", 8},
      new object[] {"O~~OO~~OO~~OO~P ~OO~~OO~~OO~~O", 8},
    };
    
    private static object[] There_Can_Only_Be_One_Test_Cases = new object[]
    {
      new object[] {"~OP", 0},
      new object[] {"PO~", 0},
      new object[] {"O~P", 1},
      new object[] {"P~O", 1},
    };
    
    private static object[] Empty_Test_Cases = new object[]
    {
      new object[] {"         P", 0},
      new object[] {"P         ", 0},
      new object[] {"         P      ", 0},
      new object[] {"P", 0},
    };
  
    [Test, TestCaseSource(typeof(SolutionTest), "Basic_Test_Cases")]
    public void Basic_Test(string town, int expected)
    {
      Assert.AreEqual(expected, Dinglemouse.CountDeafRats(town));
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Extra_Test_Cases")]
    public void Extra_Test(string town, int expected)
    {
      Assert.AreEqual(expected, Dinglemouse.CountDeafRats(town));
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "There_Can_Only_Be_One_Test_Cases")]
    public void There_Can_Only_Be_One_Test(string town, int expected)
    {
      Assert.AreEqual(expected, Dinglemouse.CountDeafRats(town));
    }
    
    [Test, TestCaseSource(typeof(SolutionTest), "Empty_Test_Cases")]
    public void Empty_Test(string town, int expected)
    {
      Assert.AreEqual(expected, Dinglemouse.CountDeafRats(town));
    }
    
    [Test, Description("Random Tests (200 assertions)")]
    public void Random_Test()
    {
      for (int r = 1; r <= 200; ++r)
      {
        int p = rnd.Next(0, 3);
        char piper = p == 0 ? 'L' : p == 1 ? 'M' : 'R';
        string town = MakeTown(piper);
        int expected = Solution(town);
        Console.WriteLine($"Random test {r} : <span style='color:green'>{town}</span> has {expected} deaf rats");
        Assert.AreEqual(expected, Dinglemouse.CountDeafRats(town));
      }
    }
    
  }
}
