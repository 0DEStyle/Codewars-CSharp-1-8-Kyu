/*Challenge link:https://www.codewars.com/kata/588f3e0dfa74475a2600002a/train/csharp
Question:
You are given a string containing 0's, 1's and one or more '?', where ? is a wildcard that can be 0 or 1.

Return an array containing all the possibilities you can reach substituing the ? for a value.

Examples
'101?' -> ['1010', '1011']

'1?1?' -> ['1010', '1110', '1011', '1111']
Notes:

Don't worry about sorting the output.
Your string will never be empty.
Have fun!


*/

//***************Solution********************
using System.Collections.Generic;

public class Kata{
    public List<string> Possibilities(string input){
      //set index of character "?" in input to index.
      //check if index is -1, if so, return string empty list.
      var index = input.IndexOf("?");
      if (index == -1)
        return new List<string>{input}; 
      //use recurssivly generate result by calling Possibilities to generate result, store in l
      //AddRange by alternating between 1 and 0.
      else{
        var l =    Possibilities(input.Substring(0, index) + "0" + input.Substring(index + 1));
        l.AddRange(Possibilities(input.Substring(0, index) + "1" + input.Substring(index + 1)));
        return l;
      }
    }    
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void Basic1()
    {
      var list = new System.Collections.Generic.List<string> { "1001", "1011" };
      Assert.AreEqual(new Kata().Possibilities("10?1").OrderBy(t => t), list.OrderBy(t => t));
    }
    
    [Test]
    public void Basic2()
    {
      var list = new System.Collections.Generic.List<string> { "0000", "0001", "0010", "0011", "0100", "0101", "0110", "0111", "1000", "1001", "1010", "1011", "1100", "1101", "1110", "1111" };
      Assert.AreEqual(new Kata().Possibilities("????").OrderBy(t => t), list.OrderBy(t => t));
    }
    
    [Test]
    public void Random()
    {
      var rand = new Random(DateTime.Now.Second);
      for (var i = 0; i < 98; i++)
      {
         var n = Convert.ToString(rand.Next(0, 99999999), 2);
         n += "???" + n;
         Assert.AreEqual(new Kata().Possibilities(n).OrderBy(t => t), new Wwwwwwwww().Possibilities(n).OrderBy(t => t));
      }
    }
  }
  
  public class Wwwwwwwww
    {
        public System.Collections.Generic.List<string> Possibilities(string input)
        {
            var index = input.IndexOf("?");
            var start = input.Substring(0, index);
            var end = input.Substring(index + 1, input.Length - index - 1);

            var list = new System.Collections.Generic.List<string> { $"{start}0{end}", $"{start}1{end}" };

            return index != input.LastIndexOf("?") ? Support(list) : list;
        }

        public System.Collections.Generic.List<string> Support(System.Collections.Generic.List<string> left)
        {
            var list = new System.Collections.Generic.List<string>();
            foreach (var item in left)
            {
                list.AddRange(Possibilities(item));
            }

            return list;
        }
    }
}
