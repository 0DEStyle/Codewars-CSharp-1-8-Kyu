/*Challenge link:https://www.codewars.com/kata/5784c89be5553370e000061b/train/csharp
Question:
Rick wants a faster way to get the product of the largest pair in an array. Your task is to create a performant solution to find the product of the largest two integers in a unique array of positive numbers.
All inputs will be valid.
Passing [2, 6, 3] should return 18, the product of [6, 3].

Disclaimer: only accepts solutions that are faster than his, which has a running time O(nlogn).

Kata.MaxProduct(new int[] { 2, 1, 5, 0, 4, 3 });              // 20
Kata.MaxProduct(new int[] { 7, 8, 9 })     ;                  // 72
Kata.MaxProduct(new int[] { 33, 231, 454, 11, 9, 99, 57 });   // 104874
*/

//***************Solution********************
/*                             `-:/+++++++/++:-.                                          
                            .odNMMMMMMMMMMMMMNmdo-`                                      
                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                               
                    ```:mMMNhyyyyhMMMh+::::-        `:sNMN:                              
                 -oyhdmMMMMmhyyyyhMMNyy+::::---------::yMMm                              
                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`              Too slow! Speed must be lower than 1000 ms.  
                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                  Maybe try a different approach?                        
                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-          /                    
                MMMdhhhdMMNhhhyyyyyymMMMMNmmmmmmNNMMMMMMN.                               
                MMMhhhhdMMNhhhyyyyyyyhdmNNNMMNNNmmdhhdMMd                                
               `MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM.                               
               .MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM:                               
               .MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhhMMM+                               
               -MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhdMMM/                               
               -MMMhhhhdMMNhhhhhhhyyyyyyyyyyyyyyyyyhhdMMM-                               
               `MMMhhhhhMMNhhhhhhhhhhyyyyyyyyyyyhhhhhmMMN                                
                hMMmhhhhMMNhhhhhhhhhhhhhhhhhhhhhhhhhhNMMy                                
                :MMMNmddMMMhhhhhhhhhhddddhhhhhhhhhhhdMMM/                                
                 :hNMMMMMMMdhhhhhhhhdMMMMMMNNNNNdhhhNMMN`                                
                   .-/+oMMMmhhhhhhhhmMMmyhMMMddhhhhdMMMy                                 
                        hMMNhhhhhhhhmMMd :MMMhhhhhhdMMM+                                 
                        sMMNhhhhhhhhNMMm .MMMdhhhhhdMMN.                                 
                        /MMMdhhhhhhdMMM+  oNMMNNNNNMMm:                                  
                        `dMMMNmmmNNMMMh`   -syyyyhhy/`                                   
                         `/hmNNNNNmdh/`                                                  
                            `.---..`
*/
//store max at a variable, then remove it from the list
//then use max from variable times the new max from the list
using System.Linq;
using System.Collections.Generic;

public class Kata{
  public static int MaxProduct(int[] array){
     List<int> temp = array.ToList();
     int max = temp.Max();
     temp.Remove(max);
     return max * temp.Max();
  }
}

//solution 2
using System.Linq;

public class Kata
{
  public static int MaxProduct(int[] array)
  {
    return array.OrderBy(x => -x).Take(2).Aggregate((a, b) => a * b);
  }
}
//solution 3
using System;
public class Kata
{
    public static int MaxProduct(int[] array)
    {
        Array.Sort(array);
        int x = array[^1];
        int y = array[^2];
        return x * y;
    }
}

//solution 4
public class Kata
{
    public static int MaxProduct(int[] array)
    {
        int num1 = 0;
        int num2 = 0;

        foreach(var num in array)
        {
            if(num >num1)
            {
                num2 = num1;
                num1 = num;
            }
            else if (num > num2)
            {
                num2 = num;
            }
        }
        return num1 * num2;
    }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Diagnostics;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual(218842, Kata.MaxProduct(new int[] { 56, 335, 195, 443, 6, 494, 252 }));
      Assert.AreEqual(194740, Kata.MaxProduct(new int[] { 154, 428, 455, 346 }));
      Assert.AreEqual(187827, Kata.MaxProduct(new int[] { 39, 135, 47, 275, 37, 108, 265, 457, 2, 133, 316, 330, 153, 253, 321, 411 }));
      Assert.AreEqual(87984, Kata.MaxProduct(new int[] { 136, 376, 10, 146, 105, 63, 234 }));
      Assert.AreEqual(218536, Kata.MaxProduct(new int[] { 354, 463, 165, 62, 472, 53, 347, 293, 252, 378, 420, 398, 255, 89 }));
      Assert.AreEqual(192672, Kata.MaxProduct(new int[] { 346, 446, 26, 425, 432, 349, 123, 269, 285, 93, 75, 14 }));
      Assert.AreEqual(95680, Kata.MaxProduct(new int[] { 134, 320, 266, 299 }));
      Assert.AreEqual(139496, Kata.MaxProduct(new int[] { 114, 424, 53, 272, 128, 215, 25, 329, 272, 313, 100, 24, 252 }));
      Assert.AreEqual(174750, Kata.MaxProduct(new int[] { 375, 56, 337, 466, 203 }));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      var LIMIT = 1000;
      
      Func<int[], int> myMaxProduct = delegate (int[] array)
      {
        var max = array[0];
        var preMax = array[0];
        for(var i=1;i<array.Length;i++)
        {
          if(array[i] > max)
          {
            preMax = max;
            max = array[i];
          }
          else
          {
            if(array[i] > preMax)
            {
              preMax = array[i];
            }
          }
        }

        return max * preMax;
      };
      
      Func<int[], int, int[]> sample = delegate (int[] array, int size)
      {
        var i = array.Length;
        int temp;
        
        while(i-- > 0)
        {
          var index = rand.Next(0, i+1);
          temp = array[index];
          array[index] = array[i];
          array[i] = temp;
        }
        return array.Take(size).ToArray();
      };
      
      var sw = Stopwatch.StartNew();
      
      for (var i = 0; i < 199; i++) 
      {
        var small = sample(Enumerable.Range(1, 5000).ToArray(), 500);
        var big = sample(Enumerable.Range(5001,20000).ToArray(), 10000);
        var arr = small.Concat(big).ToArray();

        Assert.AreEqual(myMaxProduct(arr), Kata.MaxProduct(arr));
      }
		  for (var i = 0; i < 200; i++)
      {
        var small = sample(Enumerable.Range(1,5000).ToArray(), 500);
        var big = sample(Enumerable.Range(10001, 40000).ToArray(), 10000);
        var arr = small.Concat(big).ToArray();

        Assert.AreEqual(myMaxProduct(arr), Kata.MaxProduct(arr));
      }
      
      sw.Stop();
      Console.WriteLine(sw.ElapsedMilliseconds + " ms");
      Assert.IsTrue(sw.ElapsedMilliseconds < LIMIT, "Too slow! Speed must be lower than " + LIMIT + " ms. Maybe try a different approach?");
    }
  }
}
