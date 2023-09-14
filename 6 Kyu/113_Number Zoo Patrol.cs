/*Challenge link:https://www.codewars.com/kata/5276c18121e20900c0000235/train/csharp
Question:
Background:
You're working in a number zoo, and it seems that one of the numbers has gone missing!

Zoo workers have no idea what number is missing, and are too incompetent to figure it out, so they're hiring you to do it for them.

In case the zoo loses another number, they want your program to work regardless of how many numbers there are in total.

Task:
Write a function that takes a shuffled list of unique numbers from 1 to n with one element missing (which can be any number including n). Return this missing number.

Note: huge lists will be tested.

Examples:
[1, 3, 4]  =>  2
[1, 2, 3]  =>  4
[4, 2, 3]  =>  1
*/

//***************Solution********************

//get average of array count + 2 and array count + 1
//then subtract to the sum of array, to get the missing number.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Kata{
  public static int FindNumber(int[] array) => (array.Count() + 2) * (array.Count() + 1) / 2 - array.Sum();
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class Sample_Test
  {
    private static IEnumerable<TestCaseData> testCases
    {
      get
      {
        yield return new TestCaseData(new[] {new int[] {1, 3, 4, 5, 6, 7, 8}}).Returns(2);
        yield return new TestCaseData(new[] {new int[] {7, 8, 1, 2, 4, 5, 6}}).Returns(3);
        yield return new TestCaseData(new[] {new int[] {1, 2, 3, 5}}).Returns(4);
        yield return new TestCaseData(new[] {new int[] {1, 2}}).Returns(3);
        yield return new TestCaseData(new[] {new int[] {2, 3, 4}}).Returns(1);
        yield return new TestCaseData(new[] {new int[] {13, 11, 10, 3, 2, 1, 4, 5, 6, 9, 7, 8}}).Returns(12);
        yield return new TestCaseData(new[] {new int[] {}}).Returns(1);
        yield return new TestCaseData(new[] {new int[] {1}}).Returns(2);
        yield return new TestCaseData(new[] {new int[] {2}}).Returns(1);
      }
    }
  
    [Test, TestCaseSource("testCases")]
    public int Test(int[] array) => Kata.FindNumber(array);
  }
  
  [TestFixture]
  public class Random_Test
  {
    private static Random rnd = new Random();
    
    private static int maxAnimals = 2000;
    
    // Precache a bunch of lists for performance
    private static List<Tuple<int, int[]>> animalLists = ((Func<List<Tuple<int, int[]>>>)(() =>
    {
      List<Tuple<int, int[]>> result = new List<Tuple<int, int[]>>();
      
      for (int i = 0; i < 2000; ++i)
      {
        List<int> animalsList = new List<int>(Enumerable.Range(1, maxAnimals + 1).OrderBy(_ => rnd.Next()));
        int animalToRemove = rnd.Next(1, maxAnimals + 2);
        animalsList.Remove(animalToRemove);
        result.Add(new Tuple<int, int[]>(animalToRemove, animalsList.ToArray()));
      }
      
      return result;
    }))();
  
    [Test]
    public void Random1QuadraticTests()
    {
      const int Tests = 2000;
      
      for (int i = 0; i < Tests; ++i)
      {
        Tuple<int, int[]> test = animalLists[rnd.Next(0, animalLists.Count)];
        int expected = test.Item1;
        int[] animals = test.Item2;
        
        int actual = Kata.FindNumber(animals);
        Assert.AreEqual(expected, actual);
      }
    }
      
    [Test]
    public void Random2LinearithmicTests()
    {
      const int Tests = 3000;
      
      for (int i = 0; i < Tests; ++i)
      {
        Tuple<int, int[]> test = animalLists[rnd.Next(0, animalLists.Count)];
        int expected = test.Item1;
        int[] animals = test.Item2;
        
        int actual = Kata.FindNumber(animals);
        Assert.AreEqual(expected, actual);
      }
    }
    
    [Test]
    public void Random3LinearTests()
    {
      const int Tests = 4000;
      
      for (int i = 0; i < Tests; ++i)
      {
        Tuple<int, int[]> test = animalLists[rnd.Next(0, animalLists.Count)];
        int expected = test.Item1;
        int[] animals = test.Item2;
        
        int actual = Kata.FindNumber(animals);
        Assert.AreEqual(expected, actual);
      }
    }

  }
}
