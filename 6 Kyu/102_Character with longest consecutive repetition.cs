/*Challenge link:https://www.codewars.com/kata/586d6cefbcc21eed7a001155/train/csharp
Question:
For a given string s find the character c (or C) with longest consecutive repetition and return:

Tuple<char?, int>(c, l)
where l (or L) is the length of the repetition. If there are two or more characters with the same l return the first in order of appearance.

For empty string return:

Tuple<char?, int>(null, 0)
Happy coding! :)
*/

//***************Solution********************

//x is current element, i is index
//from input string, create new tuple, char x, 
//and int variable where input with size start at i, take all characters that is equal to x, then count it.
//order by -current item.Items2, return first or default,
// ?? is null coalescing operator, otherwise return new Tuple<char?, int>(null, 0)
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

namespace Solution{
  public static class Kata{
    public static Tuple<char?, int> LongestRepetition(string input) =>
      input.Select((x, i) => new Tuple<char?, int>(x, input[i..].TakeWhile(c => c == x).Count()))
           .OrderBy(x => -x.Item2).FirstOrDefault()
           ?? new Tuple<char?, int>(null, 0);
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  
  [TestFixture]
  public class BasicTests
  {
    [Test]
    public void LongestAtTheBeginning()
    {
      Assert.AreEqual(new Tuple<char?, int> ('a', 4), Kata.LongestRepetition("aaaabb"));
      Assert.AreEqual(new Tuple<char?, int> ('b', 5), Kata.LongestRepetition("abbbbb"));
    }
    
    [Test]
    public void LongestAtTheEnd()
    {
      Assert.AreEqual(new Tuple<char?, int> ('a', 4), Kata.LongestRepetition("bbbaaabaaaa"));
    }
    
    [Test]
    public void LongestInTheMiddle()
    {
      Assert.AreEqual(new Tuple<char?, int> ('u', 3), Kata.LongestRepetition("cbdeuuu900"));
    }
    
    [Test]
    public void MultipleLongest()
    {
      Assert.AreEqual(new Tuple<char?, int> ('a', 2), Kata.LongestRepetition("aabb"));
      Assert.AreEqual(new Tuple<char?, int> ('b', 1), Kata.LongestRepetition("ba"));
    }
    
    [Test]
    public void EmptyString()
    {
      Assert.AreEqual(new Tuple<char?, int> (null, 0),  Kata.LongestRepetition(""));      
    }  
  }
  
  [TestFixture]
  public class RandomTests
  {
    // Credits: http://stackoverflow.com/questions/1344221/how-can-i-generate-random-alphanumeric-strings-in-c
    private static Random random = new Random();
    public static string RandomString(int length)
    {
        const string chars = @"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        
        if (random.Next(30) % 6 == 0) {
          return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).OrderBy(o=>o).ToArray());
        }
        return new string(Enumerable.Repeat(chars, length)
          .Select(s => s[random.Next(s.Length)]).ToArray());
    }
    
    [Test]
    public static void Length500 ()
    {
      var randomInput = RandomString(500);
      Assert.AreEqual(Reference.LongestRepetition(randomInput), Kata.LongestRepetition(randomInput));
    }
  }
  
  public static class Reference
  {
        public static Tuple<char?, int> LongestRepetition(string input)
        {
            char? curr = null;
            int count = 0;
            char? result = null;
            int maxCount = 0;
    
            foreach (var c in input)
            {
                if (c != curr)
                {
                    if (count > maxCount)
                    { 
                        result = curr;
                        maxCount = count;
                    }
                    curr = c;
                    count = 1;
                }
                else
                {
                    count += 1;
                }
            }
            
            if (count > maxCount)
            {
                result = curr;
                maxCount = count;
            }
    
            return new Tuple<char?, int>(result, maxCount);
        } 
    }
}
