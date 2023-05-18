/*Challenge link:https://www.codewars.com/kata/51c7d8268a35b6b8b40002f2/train/csharp
Question:
Complete the solution so that it takes the object (JavaScript/CoffeeScript) or hash (ruby) passed in and generates a human readable string from its key/value pairs.

The format should be "KEY = VALUE". Each key/value pair should be separated by a comma except for the last pair.

Example:

Kata.StringifyDict(new Dictionary<char, int> {{'a', 1}, {'b', 2}}) => "a = 1,b = 2";
*/

//***************Solution********************

//print out the key and value of each element inside has
//using Linq Select to loop through all element, print out the key and value with string interpolation
//and join each interpolation together, return the result.
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static string StringifyDict<TKey, TValue>(Dictionary<TKey, TValue> hash){
    foreach(KeyValuePair<TKey, TValue> element in hash)
            Console.WriteLine("Key:- {0} and Value:- {1}", element.Key, element.Value);
    return string.Join(",", hash.Select(x => $"{x.Key} = {x.Value}"));
  }
}

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static string StringifyDict<TKey, TValue>(Dictionary<TKey, TValue> hash) => string.Join(",", hash.Select(x => $"{x.Key} = {x.Value}"));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public static class Solution
  {
    public static string StringifyDict<TKey, TValue>(Dictionary<TKey, TValue> hash) =>
      String.Join(",", hash.Keys.Select(key => $"{key} = {hash[key]}"));
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Basic Tests")]
    public void Test()
    {
      Assert.AreEqual("a = 1,b = 2", Kata.StringifyDict(new Dictionary<char, int> {{'a', 1}, {'b', 2}}));
      Assert.AreEqual("b = 1,c = 2,e = 3", Kata.StringifyDict(new Dictionary<char, int> {{'b', 1}, {'c', 2}, {'e', 3}}));
      Assert.AreEqual("", Kata.StringifyDict(new Dictionary<char, int>()));
    }
    
    [Test, Description("Random Tests")]
    public void RandTest()
    {
      const int Tests = 100;
      Random rnd = new Random();
      
      for (int i = 0; i < Tests; ++i)
      {
        int length = rnd.Next(0, 26);
        Dictionary<int, int> hash = new Dictionary<int, int>();
        
        for (int j = 0; j < length; ++j)
        {
          int key = rnd.Next(-10000, 10000),
              value = rnd.Next(-10000, 10000);
              
          if (!hash.ContainsKey(key))
          {
            hash.Add(key, value);
          }
        }
        
        string expected = Solution.StringifyDict(hash);
        string actual = Kata.StringifyDict(hash);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
