/*Challenge link:https://www.codewars.com/kata/576757b1df89ecf5bd00073b/train/csharp
Question:
Build Tower
Build a pyramid-shaped tower, as an array/list of strings, given a positive integer number of floors. A tower block is represented with "*" character.

For example, a tower with 3 floors looks like this:

[
  "  *  ",
  " *** ", 
  "*****"
]
And a tower with 6 floors looks like this:

[
  "     *     ", 
  "    ***    ", 
  "   *****   ", 
  "  *******  ", 
  " ********* ", 
  "***********"
]
*/

//***************Solution********************

//build the starting space + first '*' + i amount of '*' each loop + ending space
//store result in array and return it.
public class Kata{
  public static string[] TowerBuilder(int nFloors){
    string[] str = new string[nFloors];
    
    for(int i = 0; i < nFloors; i++)
    str[i] = new string(' ',nFloors-i-1) + "*"+ new string('*',i*2) + new string(' ', nFloors - i - 1);
    
    return str;
  }
}

//solution 2
//same as above.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata
{
  public static string[] TowerBuilder(int nFloors)
  {
      return Enumerable.Range(1, nFloors).Select(i => string.Format("{0}{1}{0}", i == nFloors ? "" : new string(' ', nFloors - i), new string('*', 2 * i - 1))).ToArray();
  }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(string.Join(",", new [] { "*" }), string.Join(",", Kata.TowerBuilder(1)));
      Assert.AreEqual(string.Join(",", new [] { " * ", "***" }), string.Join(",", Kata.TowerBuilder(2)));
      Assert.AreEqual(string.Join(",", new [] { "  *  ", " *** ", "*****" }), string.Join(",", Kata.TowerBuilder(3)));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int,string[]> myTowerBuilder = delegate (int nFloors)
      {
        string[] lines = new string[nFloors];
        for(var i = 1; i<=nFloors; i++)
        {
          lines[i-1] = (new string(' ', nFloors-i) + new string('*', i*2-1) + new string(' ', nFloors-i));
        }
        return lines;
      };
      
      var seq = Enumerable.Range(1,100).ToArray();
      for(int r=0;r<100;r++)
      {
        for(int p=0;p<100;p++)
        {
          if(rand.Next(0, 2) == 0)
          {
            var temp = seq[r];
            seq[r] = seq[p];
            seq[p] = temp;
          }
        }
      }
      
      for(int r=0;r<100;r++)
      {
        var n = seq[r];
        //Console.WriteLine(n);
        Assert.AreEqual(string.Join(",", myTowerBuilder(n)), string.Join(",", Kata.TowerBuilder(n)));
      }
    }
  }
}
