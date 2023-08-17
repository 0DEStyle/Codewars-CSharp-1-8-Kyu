/*Challenge link:https://www.codewars.com/kata/5839edaa6754d6fec10000a2/train/csharp
Question:
Find the missing letter
Write a method that takes an array of consecutive (increasing) letters as input and that returns the missing letter in the array.

You will always get an valid array. And it will be always exactly one letter be missing. The length of the array will always be at least 2.
The array will always contain letters in only one case.

Example:

['a','b','c','d','f'] -> 'e'
['O','Q','R','S'] -> 'P'
(Use the English alphabet with 26 letters!)

Have fun coding it and please don't forget to vote and rank this kata! :-)

I have also created other katas. Take a look if you enjoyed this kata!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//from array[0], count 25, select from array if it not contain element, get first, convert to char and return result.
using static System.Linq.Enumerable;

public class Kata{
  public static char FindMissingLetter(char[] array) => 
    (char)Range(array[0], 25).First(x => !array.Contains((char)x));
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  
  public class KataTests
  {
    [Test]
    public void ExampleTests()
    {
      Assert.AreEqual('e', Kata.FindMissingLetter(new [] { 'a','b','c','d','f' }));
      Assert.AreEqual('P', Kata.FindMissingLetter(new [] { 'O','Q','R','S' }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      for(int r=0;r<30;r++)
      {
        var len = rand.Next(3, 10);
        var missingIdx = rand.Next(1,len-1);
        var start = rand.Next(65, 90-len);
        
        if(rand.Next(0,2) == 1)
        {
          start += 32;
        }
        char missing = ' ';
        List<char> list = new List<char>();
        for(int i=0;i<len;i++)
        {
          if(i == missingIdx)
          {
            missing = (char)(start + i);
          }
          else
          {
            list.Add((char)(start + i));
          }
        }
        var array = list.ToArray();
        Console.WriteLine("Array: " + string.Join(",", array));
        Assert.AreEqual(missing, Kata.FindMissingLetter(array));
      }
    }
  }
}
