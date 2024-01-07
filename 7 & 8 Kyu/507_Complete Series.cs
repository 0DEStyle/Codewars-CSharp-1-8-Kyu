/*Challenge link:https://www.codewars.com/kata/580a4001d6df740d61000301/train/csharp
Question:
You are given an array of non-negative integers, your task is to complete the series from 0 to the highest number in the array.

If the numbers in the sequence provided are not in order you should order them, but if a value repeats, then you must return a sequence with only one item, and the value of that item must be 0. like this:

inputs        outputs
[2,1]     ->  [0,1,2]
[1,4,4,6] ->  [0]
Notes: all numbers are positive integers.

This is set of example outputs based on the input sequence.

inputs        outputs
[0,1]   ->    [0,1]
[1,4,6] ->    [0,1,2,3,4,5,6]
[3,4,5] ->    [0,1,2,3,4,5]
[0,1,0] ->    [0]
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣤⣤⣶⣶⣶⣶⣦⣤⣄⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣀⣴⣾⣿⠿⠛⠋⠉⠉⠉⠉⠙⠛⠻⢿⣿⣦⣄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⣠⣾⣿⠟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⢿⣷⣦⠀⠀⠀⠀
⠀⠀⣴⣿⠟⠀⢸⣿⣦⣄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣿⡷⠀⠙⢿⣷⡄⠀⠀
⠀⣼⣿⠃⠀⠀⢀⠜⠛⢿⣿⣦⡄⠀⠀⠀⣠⣾⣿⠟⠋⠠⡀⠀⠈⢿⣿⡀⠀
⣸⣿⠇⠀⠀⡰⠁⠀⣠⣤⣌⠙⠋⠆⠀⡈⠙⢛⣥⣤⣄⠀⠈⡄⠀⠈⢿⡇⠀
⣿⡿⠀⠀⠀⠇⠀⠸⣿⣿⣿⠂⠀⠐⠀⡇⠀⠸⣿⣿⣿⠀⠀⡅⠀⠀⢸⣿⠀
⣿⡇⠀⠀⠀⣘⣄⠀⠈⠉⠁⠀⡠⠁⠀⠐⢄⠀⠈⠉⠀⠀⣰⠁⠀⠀⢸⣿⡇
⣿⣷⡠⠔⠋⠁⢸⣁⣐⣒⣂⣉⣀⣀⣀⣀⣀⣁⣐⣒⣂⡟⠁⠉⠒⢄⣸⠀⠀
⣿⡟⠀⠀⠀⠀⢰⣿⡉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⠉⣿⡇⠀⠀⠀⠀⠀⣿⠀
⢻⣿⣄⠀⠀⢀⠜⠘⣷⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⣶⠏⠙⢄⠀⠀⢀⣼⠀⠀
⠀⠘⢿⣿⣯⠀⠀⠀⠈⠻⣿⣿⡋⠉⠉⢉⣻⣿⠿⠋⠀⠀⠀⣩⣿⣿⠁⠀⠀
⠀⠀⠀⠙⢿⣿⣤⡀⠀⠀⠀⠉⠙⠛⠛⠛⠉⠀⠀⠀⢀⣠⣾⣿⠟⠁⠀⠀⠀
⠀⠀⠀⠀⠀⠉⠻⢿⣷⣦⣤⣄⣀⣀⣀⣀⣀⣤⣴⣶⣿⠿⠋⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠈⠉⠛⠛⠿⠿⠿⠿⠟⠛⠋⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀
*/
//first check for duplication in sequence, if length and distinct count don't match, return int array with element 0
//else generate sequence, start from 0, count up to arr.Max() + 1, convert to array and return the result.
using System.Linq;

namespace SeriesKata{
  public class Series{

    public static int[] CompleteSeries(int[] arr) =>
      arr.Length != arr.Distinct().Count() ? 
                              new int[]{0} :
      Enumerable.Range(0, arr.Max()+1).ToArray();
  }
}

//solution 2
using System.Linq;

public class Series
{
  public static int[] CompleteSeries(int[] arr)
  {
    return Enumerable.Range(0, arr.Distinct().SequenceEqual(arr) ? arr.Max() + 1 : 1).ToArray();
  }
}

//****************Sample Test*****************
namespace SeriesKata {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;

  [TestFixture]
  public class CompleteTest
  {
    
    private Random random = new Random();
    private int[] test1 = {0,1}, 
        test2 = {1,4,6},
        test3 = {3,4,5},
        test4 = {2,1},
        test5 = {1,4,4,6},
        sol1 = {0,1},
        sol2 = {0,1,2,3,4,5,6},
        sol3 = {0,1,2,3,4,5},
        sol4 = {0,1,2},
        sol5 = {0},
        test6 = {7}, 
        test7 = {30,90,60,68,65},
        test8 = {28,47,3,21,26},
        test9 = {42,41,26,92,83},
        test10 = {84,52,1,16,93,58,9,73,20,31,92},
        test11 = {100},
        test12 = {0},
        sol6 = {0,1,2,3,4,5,6,7},
        sol7 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90},
        sol8 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47},
        sol9 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92},
        sol10 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93},
        sol11 = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25,26,27,28,29,30,31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50,51,52,53,54,55,56,57,58,59,60,61,62,63,64,65,66,67,68,69,70,71,72,73,74,75,76,77,78,79,80,81,82,83,84,85,86,87,88,89,90,91,92,93,94,95,96,97,98,99,100},
        sol12 = {0};
  
    [Test]
    public void Test1()
    {
      int[] actual = Series.CompleteSeries(test1);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test1), FormatArray(sol1), FormatArray(actual)));
      Assert.AreEqual(sol1, actual);
    }
    
    [Test]
    public void Test2()
    {
      int[] actual = Series.CompleteSeries(test2);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test2), FormatArray(sol2), FormatArray(actual)));
      Assert.AreEqual(sol2, actual);
    }
    
    [Test]
    public void Test3()
    {
      int[] actual = Series.CompleteSeries(test3);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test3), FormatArray(sol3), FormatArray(actual)));
      Assert.AreEqual(sol3, actual);
    }
    
    [Test]
    public void Test4()
    {
      int[] actual = Series.CompleteSeries(test4);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test4), FormatArray(sol4), FormatArray(actual)));
      Assert.AreEqual(sol4, actual);
    }
    
    [Test]
    public void Test5()
    {
      int[] actual = Series.CompleteSeries(test5);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test5), FormatArray(sol5), FormatArray(actual)));
      Assert.AreEqual(sol5, actual);
    }
    
    [Test]
    public void Test6()
    {
      int[] actual = Series.CompleteSeries(test6);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test6), FormatArray(sol6), FormatArray(actual)));
      Assert.AreEqual(sol6, actual);
    }
    
    [Test]
    public void Test7()
    {
      int[] actual = Series.CompleteSeries(test7);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test7), FormatArray(sol7), FormatArray(actual)));
      Assert.AreEqual(sol7, actual);
    }
    
    [Test]
    public void Test8()
    {
      int[] actual = Series.CompleteSeries(test8);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test8), FormatArray(sol8), FormatArray(actual)));
      Assert.AreEqual(sol8, actual);
    }
    
    [Test]
    public void Test9()
    {
      int[] actual = Series.CompleteSeries(test9);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test9), FormatArray(sol9), FormatArray(actual)));
      Assert.AreEqual(sol9, actual);
    }
    
    [Test]
    public void Test10()
    {
      int[] actual = Series.CompleteSeries(test10);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test10), FormatArray(sol10), FormatArray(actual)));
      Assert.AreEqual(sol10, actual);
    }
    
    [Test]
    public void Test11()
    {
      int[] actual = Series.CompleteSeries(test11);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test11), FormatArray(sol11), FormatArray(actual)));
      Assert.AreEqual(sol11, actual);
    }
    
    [Test]
    public void Test12()
    {
      int[] actual = Series.CompleteSeries(test12);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(test12), FormatArray(sol12), FormatArray(actual)));
      Assert.AreEqual(sol12, actual);
    }
    
    [Test]
    public void RandomTests() 
    {
      for (int i = 1 ; i <= 100 ; i++) 
      {
        Console.WriteLine(String.Format("Random Test #{0}", i));
        this.RandomTest();
        Console.WriteLine("\n------------------------------");
      }
    }
    
    public void RandomTest() {
      int[] arr = this.RandomArray();
      int[] expected = CompleteSeriesCheck(arr);
      int[] actual = Series.CompleteSeries(arr);
      Console.WriteLine(String.Format("Input Array: {0}\nExpected Array: {1}\nActual Array: {2}", 
                        FormatArray(arr), FormatArray(expected), FormatArray(actual)));
                   
      Assert.AreEqual(expected, actual);
    }
    
    public int[] RandomArray(){
      int n = random.Next(1, 40);
      List<int> list = new List<int>();
      for(int i = 0; i < n; i++){
        list.Add(random.Next(100));
      }
      return list.ToArray();
    }
    
    public int[] CompleteSeriesCheck(int[] arr){
      List<int> list = new List<int>();
      int max = arr.Max();
      
      bool duplicates = arr.GroupBy(x => x).Any(g => g.Count() > 1);
      if (duplicates) 
      {
        return new int[] {0};
      }
      
      for(int i = 0; i <= max; i++){
        list.Add(i);
      }
      
      return list.ToArray();
    }
    
    public String FormatArray(int[] arr) {
      StringBuilder builder = new StringBuilder("{ ");
      bool first = true;
      foreach(var item in arr) {
        builder.Append((first ? "" : ", ") + item);
        if (first) { 
          first = false;
        }
      }
      builder.Append(" }");
      return builder.ToString();
    }
    
  }
}
