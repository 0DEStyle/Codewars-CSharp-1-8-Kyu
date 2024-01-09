/*Challenge link:https://www.codewars.com/kata/5729c30961cecadc4f001878/train/csharp
Question:
Write a function that takes one or more arrays and returns a new array of unique values in the order of the original provided arrays.

In other words, all values present from all arrays should be included in their original order, but with no duplicates in the final array.

The unique numbers should be sorted by their original order, but the final array should not be sorted in numerical order.

Check the assertion tests for examples.

Courtesy of FreeCodeCamp, a great place to learn web-dev; plus, its founder Quincy Larson is pretty cool and amicable. I made the original one slightly more tricky ;)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⠔⠊⠉⠉⠑⠢⡀⠀⠀⣀⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴⠒⠉⢀⣠⣤⣈⠁⠀⠀⢘⣦⣼⡿⣿⣞⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡿⣷⡄⣿⢯⣈⣹⡆⠄⠐⣇⢈⡴⠛⠛⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⡿⣃⠸⣿⣯⣿⠽⠀⠀⠈⠋⢳⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠀⠀⠀⡙⣦⠀⠀⠀⠀⠀⠀⠀⠘⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⢿⡓⠿⠟⠛⠉⢳⡀⠀⠀⠀⠀⠀⠀⠙⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡆⣄⣀⣀⣀⣀⣀⠁⠀⠀⠀⠀⠀⠀⠀⠘⣆⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⡀⠀⠀⠀⠀⠀⣷⡿⠛⠉⠉⠉⠀⠀⠀⠀⢀⡆⠐⠀⠀⠀⢹⣿⣹⡷⢤⣀⣀⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣠⡾⠋⠈⠉⠁⠈⠉⠉⠙⡷⢄⣀⠦⠴⠊⠀⠒⣨⠍⠂⠀⠀⠀⠀⠀⣿⣿⣿⣠⣿⡿⠛⠉⠉⠓⠢⢤⣀⡤⠤⠄⠀⠀⠀⣀⣀⣤⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⢀⣴⣊⣍⠁⣿⠀⠀⠀⠀⠀⠀⠀⠀⢰⣷⣤⠤⠤⣄⣀⣾⡝⠁⠀⠀⠀⠀⠀⠀⢰⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⠿⠿⠷⠄⢀⣀⣀⠀⠀⠀⠀⠀⠀
⢯⣠⣾⢟⡴⠻⣶⣤⣤⡤⢤⣴⣤⣀⣼⣿⣿⣿⠛⠉⠉⠉⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⣿⣿⡟⠁⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⡏⠀⠀⠀⠀⠀⠀⠐⣺⢽⣽⣦⣀⠀
⠀⠠⣥⣯⠏⠉⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⣿⣿⣿⣿⡟⠁⠀⠀⠀⢧⡀⠀⢀⣀⢢⡀⠀⠀⠀⠀⠀⣿⡗⡄⠀⠀⠀⢀⣄⡀⠈⠙⣎⠻⣮⡷
⠀⠀⠈⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣧⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣿⣿⣿⣿⠁⠂⠀⠀⢲⣿⠟⠛⠋⠉⠙⠛⠓⠛⠒⠤⣤⣽⣷⣄⠀⠀⣾⠛⠛⠻⣷⣄⠼⣆⠱⣼
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⡓⠒⣶⣶⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣆⣀⣵⣶⣾⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠈⢦⠀⠘⣆⠀⠀⠈⠿⢭⡿⣤⡾
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⠶⠾⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢆⢄⣼⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⠿⠿⢹⡆⠀⠻⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠈⠁⠀⠀⠈⠉⠉⠉⠛⠛⠛⠛⠉⠉⠉⠉⠁⠀⠘⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠸⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⡿⠏⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠢⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣴⣾⣿⡿⠋⠀⡠⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣷⣶⣶⣶⣶⣷⣶⣾⣿⡿⠿⠛⠁⢀⡴⠊⠁⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠙⢿⡋⠉⠉⠉⠉⠁⠀⠀⠀⠴⠚⠁⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡁⠀⠀⠈⠀⠈⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠻⣦⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣴⠟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢿⣦⣤⣤⣠⣤⣤⣤⣤⣤⣶⣶⣿⡟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⣿⣿⢹⣟⠋⠉⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⣿⢿⣿⣿⣿⢸⣿⣧⢠⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣿⣠⣿⣿⣟⢸⣿⣿⡏⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⣿⣿⣿⡿⠀⣿⡃⠃⣸⣿⠇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣿⣿⣿⡇⠀⣿⣧⢸⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⣿⣿⣿⣿⡿⠘⣿⣿⣿⣿⡟⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣿⣿⣿⠟⠋⠀⣰⣿⣿⣿⣿⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⠿⠟⠃⠀⢀⣼⣿⣿⣿⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣿⣿⠿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//select all elements from array, get all distinct value, store in array and return to result
using System.Linq;

public class Kata{
  public static object[] UniteUnique(object[][] array) => array.SelectMany(x => x).Distinct().ToArray();
}

//solution 2
using System.Linq;
public class Kata
{
  public static object[] UniteUnique(object[][] array)
  {
    return array.Aggregate(new object[] { }, (curr, next) => curr.Union(next).ToArray());
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(new object[] { 1, 2, 3, 4 }, Kata.UniteUnique(new [] { new object[] { 1, 2 }, new object[] { 3, 4 } }));
      Assert.AreEqual(new object[] { 1, 3, 2, 5, 4 }, Kata.UniteUnique(new [] { new object[] { 1, 3, 2 }, new object[] { 5, 2, 1, 4 }, new object[] { 2, 1 } }));
      Assert.AreEqual(new object[] { 4, 3, 2 }, Kata.UniteUnique(new [] { new object[] { 4, 3, 2, 2 } }));
      Assert.AreEqual(new object[] { 4, "a", 2 }, Kata.UniteUnique(new [] { new object[] { 4, "a", 2 }, new object[] { } }));
      Assert.AreEqual(new object[] { 4, "a", 2 }, Kata.UniteUnique(new [] { new object[] { }, new object[] { 4, "a", 2 } }));
      Assert.AreEqual(new object[] { 4, "a", 2 }, Kata.UniteUnique(new [] { new object[] { }, new object[] { 4, "a", 2 }, new object[] { } }));
      Assert.AreEqual(new object[] { }, Kata.UniteUnique(new [] { new object[] { } }));
      Assert.AreEqual(new object[] { }, Kata.UniteUnique(new [] { new object[] { }, new object[] { } }));
      Assert.AreEqual(new object[] { 1, 2 }, Kata.UniteUnique(new [] { new object[] { }, new object[] { 1, 2 } }));
      Assert.AreEqual(new object[] { 1, 2 }, Kata.UniteUnique(new [] { new object[] { }, new object[] { 1, 2, 1, 2 }, new object[] { 2, 1, 1, 2, 1 } }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var letters = "abcdefghijklmnopqrstuvwxyz";
      
      Func<object[][], object[]> myUniteUnique = delegate (object[][] array)
      {
        List<object> result = new List<object>();
    
        for(var i = 0; i <array.Length; i++)
        {
          for(var j = 0; j<array[i].Length; j++)
          {
            if(!result.Contains(array[i][j]))
            {
              result.Add(array[i][j]);
            }
          }
        }
    
        return result.ToArray();
      };
      
      for (var i=0;i<40;i++)
      {
        var arrayCount = rand.Next(1,10);
        var arrays = new object[arrayCount][];
        for(var a=0;a<arrayCount;a++)
        {
          var arrayLength = rand.Next(0,10);
          arrays[a] = Enumerable.Range(0, arrayLength).Select(b => rand.Next(0,2) == 1 ? rand.Next(0,10) : letters[rand.Next(0, letters.Length)]).Cast<object>().ToArray();          
        }  
        Assert.AreEqual(myUniteUnique(arrays), Kata.UniteUnique(arrays));
      }      
    }
  }
}
