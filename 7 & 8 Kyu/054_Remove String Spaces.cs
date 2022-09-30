/*Challenge link:
Question:
Simple, remove the spaces from the string, then return the resultant string.

*/

//***************Solution********************
//replace space with nothing
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Text.RegularExpressions;

namespace Solution 
{
  public static class SpacesRemover
  {
    public static string NoSpace(string input) =>
      Regex.Replace(input, @"\s+", "");
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("8j8mBliB8gimjB8B8jlB",SpacesRemover.NoSpace("8 j 8   mBliB8g  imjB8B8  jl  B"));
      Assert.AreEqual("88Bifk8hB8BB8BBBB888chl8BhBfd",SpacesRemover.NoSpace("8 8 Bi fk8h B 8 BB8B B B  B888 c hl8 BhB fd")); 
      Assert.AreEqual("8aaaaaddddr",SpacesRemover.NoSpace("8aaaaa dddd r     ")); 
      Assert.AreEqual("jfBmgklf8hg88lbe8",SpacesRemover.NoSpace("jfBm  gk lf8hg  88lbe8 ")); 
      Assert.AreEqual("8jaam",SpacesRemover.NoSpace("8j aam"));
    }
    
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      string[] names= new string[] {"a","b","c","d","e","f","g","h","i","j","k","l","m","n", "o", "P", "q", "r", "s", "t", "u", "v", "w", "x", "y", "z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", " ", " ", " ", " ", " ", " "};
      for (int i = 0; i < 100; i++)
      {
        string x = "";
        int len = rand.Next(1,30);
        for (int j = 0; j < len; j++)
        {
          x+=names[rand.Next(0,names.Length-1)];
        }
        Assert.AreEqual(Solve.SpaceRemove(x), SpacesRemover.NoSpace(x));
      }
    }
  }
}
