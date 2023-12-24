/*Challenge link:https://www.codewars.com/kata/5722cc50785220ac8b00129b/train/csharp
Question:
Pictures #1 - Rebuilding the Tower of Babel
//see image in link

Task
Define a function, babel, which accepts a positive integer argument height and returns a string representing a tower of the specified height. If the height is 0 then return an empty string. Input validation is not required.

Some examples below:

Kata.Babel(0) => "";

Kata.Babel(1) => "o\n" +
                 "o\n" +
                 "o";

Kata.Babel(2) => " o\n"  +
                 " o\n"  +
                 " o\n"  +
                 "ooo\n" +
                 "ooo\n" +
                 "ooo";
                 
Kata.Babel(3) => "  o\n"   +
                 "  o\n"   +
                 "  o\n"   +
                 " ooo\n"  +
                 " ooo\n"  +
                 " ooo\n"  +
                 "ooooo\n" +
                 "ooooo\n" +
                 "ooooo";

Kata.Babel(4) => "   o\n"    +
                 "   o\n"    +
                 "   o\n"    +
                 "  ooo\n"   +
                 "  ooo\n"   +
                 "  ooo\n"   +
                 " ooooo\n"  +
                 " ooooo\n"  +
                 " ooooo\n"  +
                 "ooooooo\n" +
                 "ooooooo\n" +
                 "ooooooo";
                 
Kata.Babel(5) => "    o\n"     +
                 "    o\n"     +
                 "    o\n"     +
                 "   ooo\n"    +
                 "   ooo\n"    +
                 "   ooo\n"    +
                 "  ooooo\n"   +
                 "  ooooo\n"   +
                 "  ooooo\n"   +
                 " ooooooo\n"  +
                 " ooooooo\n"  +
                 " ooooooo\n"  +
                 "ooooooooo\n" +
                 "ooooooooo\n" +
                 "ooooooooo";
If you are still confused as to what the pattern is, here are a few simple rules:

For each width of the tower you build three consecutive stories of the same width
Each time you complete 3 stories, the width of the tower increases by 2 units (1 to the left and 1 to the right)
You should add appropriate whitespace characters to the left of the tower for appropriate padding but there should be no trailing whitespace characters for all stories
You separate one story from then next with a newline "\n" character
There should not be a trailing newline character at the end of the string
Happy Coding :D
*/

//***************Solution********************
/*
                              o
                              o
                              o
                             ooo
                             ooo
                             ooo
                            ooooo
                            ooooo
                            ooooo
                           ooooooo
                           ooooooo
                           ooooooo
                          ooooooooo
                          ooooooooo
                          ooooooooo                 Tower of Babel hat
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⢀⣴⠟⠉⠀⠀⠀⠈⠻⣦⡀⠀⠀⠀⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣀⢀⣾⠿⠻⢶⣄⠀⠀⣠⣶⡿⠶⣄⣠⣾⣿⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢻⣿⣿⡿⣿⠿⣿⡿⢼⣿⣿⡿⣿⣎⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀ 
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠉⠛⢛⣛⡉⠀⠀⠙⠛⠻⠛⠑⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣧⣤⣴⠿⠿⣷⣤⡤⠴⠖⠳⣄⣀⣹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣀⣟⠻⢦⣀⡀⠀⠀⠀⠀⣀⡈⠻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⡿⠉⡇⠀⠀⠛⠛⠛⠋⠉⠉⠀⠀⠀⠹⢧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠀⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠈⠑⠪⠷⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣦⣼⠛⢦⣤⣄⡀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠑⠢⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠲⠖⠛⠻⣿⡿⠛⠉⠉⠻⠷⣦⣽⠿⠿⠒⠚⠋⠉⠁⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣾⠛⠁⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⠒⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢣⠀⠀⠀
⠀⠀⠀⠀⣰⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀
⠀⠀⠀⣰⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣧⣄⠀⠀⠀⠀⠀⠀⢳⡀⠀
⠀⠀⠀⣿⡾⢿⣀⢀⣀⣦⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣫⣿⡿⠟⠻⠶⠀⠀⠀⠀⠀⢳⠀
⠀⠀⢀⣿⣧⡾⣿⣿⣿⣿⣿⡷⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⢀⡴⢿⣿⣧⠀⡀⠀⢀⣀⣀⢒⣤⣶⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⡾⠁⠙⣿⡈⠉⠙⣿⣿⣷⣬⡛⢿⣶⣶⣴⣶⣶⣶⣤⣤⠤⠾⣿⣿⣿⡿⠿⣿⠿⢿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣸⠃⠀⠀⢸⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⠟⡉⠀⠀⠀⠈⠙⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣿⠀⠀⢀⡏⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠉⠠⠿⠟⠻⠟⠋⠉⢿⣿⣦⡀⢰⡀⠀⠀⠀⠀⠀⠀⠁
⢀⣿⡆⢀⡾⠀⠀⠀⠀⣾⠏⢿⣿⣿⣿⣯⣙⢷⡄⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣻⢿⣷⣀⣷⣄⠀⠀⠀⠀⢸⠀
⢸⠃⠠⣼⠃⠀⠀⣠⣾⡟⠀⠈⢿⣿⡿⠿⣿⣿⡿⠿⠿⠿⠷⣄⠈⠿⠛⠻⠶⢶⣄⣀⣀⡠⠈⢛⡿⠃⠈⢿⣿⣿⡿⠀⠀⠀⠀⠀⡀
⠟⠀⠀⢻⣶⣶⣾⣿⡟⠁⠀⠀⢸⣿⢅⠀⠈⣿⡇⠀⠀⠀⠀⠀⣷⠂⠀⠀⠀⠀⠐⠋⠉⠉⠀⢸⠁⠀⠀⠀⢻⣿⠛⠀⠀⠀⠀⢀⠇
⠀⠀⠀⠀⠹⣿⣿⠋⠀⠀⠀⠀⢸⣧⠀⠰⡀⢸⣷⣤⣤⡄⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡆⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⢼⡇
⠀⠀⠀⠀⠀⠙⢻⠄⠀⠀⠀⠀⣿⠉⠀⠀⠈⠓⢯⡉⠉⠉⢱⣶⠏⠙⠛⠚⠁⠀⠀⠀⠀⠀⣼⠇⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⠀⠀⠀⠀⠻⠄⠀⠀⠀⢀⣿⠀⢠⡄⠀⠀⠀⣁⠁⡀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⢀⣐⡟⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀
*/
using System;
using System.Collections.Generic;

public static class Kata{
  public static string Babel(int height){ 
    var res  = new List<string>();
  
    //start from 1 because you can't repeat a string with 0
    //new string(' ') and repeat it by height - i times
    //new string('o') and repeat it by i * 2 - 1 times, to get odd number 1,3,5 etc
    //add string to res then go to the next iteration
    for(int i = 1; i <= height; i++)
        for(int j = 1; j <= 3; j++)
          res.Add(new string(' ',height - i) + new string('o', i * 2 - 1));
    //print jank
    //Console.WriteLine(string.Join("\n",res));
    
    //join string with "\n" and return the result.
    return string.Join("\n",res);
  }
}

//solution 2
using System.Linq;

public static class Kata
{
  public static string Babel(int height)
  {
    return string.Join("\n",
        Enumerable.Range(0, height * 3).Select(i =>
            new string(' ', height - 1 - i / 3) + new string('o', i / 3 * 2 + 1)));
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  
  public static class Solution
  {
    public static string Babel(int height)
    {
      List<string> result = new List<string>(height * 3);
      
      for (int i = 0; i < height; ++i)
      {
        for (int j = 0; j < 3; ++j)
        {
          result.Add(new string(' ', height - i - 1) + new string('o', i * 2 + 1));
        }
      }
      
      return String.Join("\n", result);
    }
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("should work for heights from 0 to 5 inclusive")]
    public void SampleTest()
    {
      Assert.AreEqual(Solution.Babel(0), Kata.Babel(0));
      Assert.AreEqual(Solution.Babel(1), Kata.Babel(1));
      Assert.AreEqual(Solution.Babel(2), Kata.Babel(2));
      Assert.AreEqual(Solution.Babel(3), Kata.Babel(3));
      Assert.AreEqual(Solution.Babel(4), Kata.Babel(4));
      Assert.AreEqual(Solution.Babel(5), Kata.Babel(5));
    }
    
    [Test, Description("should work for heights from 6 to 10 inclusive")]
    public void BasicTest()
    {
      Assert.AreEqual(Solution.Babel(6), Kata.Babel(6));
      Assert.AreEqual(Solution.Babel(7), Kata.Babel(7));
      Assert.AreEqual(Solution.Babel(8), Kata.Babel(8));
      Assert.AreEqual(Solution.Babel(9), Kata.Babel(9));
      Assert.AreEqual(Solution.Babel(10), Kata.Babel(10));
    }
    
    [Test, Description("should work for random heights (50 tests, up to 2000)")]
    public void RandomTest()
    {
      const int Tests = 50;
      Random rnd = new Random();
      
      for (int i = 0; i < Tests; ++i)
      {
        int height = rnd.Next(2000 + 1);
        
        string expected = Solution.Babel(height);
        string actual = Kata.Babel(height);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
