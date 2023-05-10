/*Challenge link:https://www.codewars.com/kata/54592a5052756d5c5d0009c3/train/csharp
Question:
Haskell has some useful functions for dealing with lists:

$ ghci
GHCi, version 7.6.3: http://www.haskell.org/ghc/  :? for help
λ head [1,2,3,4,5]
1
λ tail [1,2,3,4,5]
[2,3,4,5]
λ init [1,2,3,4,5]
[1,2,3,4]
λ last [1,2,3,4,5]
5
Your job is to implement these functions in your given language. Make sure it doesn't edit the array; that would cause problems! Here's a cheat sheet:

| HEAD | <----------- TAIL ------------> |
[  1,  2,  3,  4,  5,  6,  7,  8,  9,  10]
| <----------- INIT ------------> | LAST |

head [x] = x
tail [x] = []
init [x] = []
last [x] = x
Here's how I expect the functions to be called in your language:

new List<int> {1, 2, 3, 4, 5}.Head() => 1
new List<int> {1, 2, 3, 4, 5}.Tail() => new List<int> {2, 3, 4, 5}
Most tests consist of 100 randomly generated arrays, each with four tests, one for each operation. There are 400 tests overall. No empty arrays will be given. Haskell has QuickCheck tests

PLEASE NOTE: C#'s Last function shall be called Last_ to prevent name clashes.
*/

//***************Solution********************
//return the index of list accordingly.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//                              `-:/+++++++/++:-.                                          
//                            .odNMMMMMMMMMMMMMNmdo-`                                      
//                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
//                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
//                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
//                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
//                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                               
//                    ```:mMMNhyyyyhMMMh+::::-        `:sNMN:                              
//                 -oyhdmMMMMmhyyyyhMMNyy+::::---------::yMMm                  ඞ???            
//                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`                             
//                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                              
//                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-                              
//                MMMdhhhdMMNhhhyyyyyymMMMMNmmmmmmNNMMMMMMN.                               
//                MMMhhhhdMMNhhhyyyyyyyhdmNNNMMNNNmmdhhdMMd                                
//               `MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM.                               
//               .MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM:                               
//               .MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhhMMM+                               
//               -MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhdMMM/                               
//               -MMMhhhhdMMNhhhhhhhyyyyyyyyyyyyyyyyyhhdMMM-                               
//               `MMMhhhhhMMNhhhhhhhhhhyyyyyyyyyyyhhhhhmMMN                                
//                hMMmhhhhMMNhhhhhhhhhhhhhhhhhhhhhhhhhhNMMy                                
//                :MMMNmddMMMhhhhhhhhhhddddhhhhhhhhhhhdMMM/                                
//                 :hNMMMMMMMdhhhhhhhhdMMMMMMNNNNNdhhhNMMN`                                
//                   .-/+oMMMmhhhhhhhhmMMmyhMMMddhhhhdMMMy                                 
//                        hMMNhhhhhhhhmMMd :MMMhhhhhhdMMM+                                 
//                        sMMNhhhhhhhhNMMm .MMMdhhhhhdMMN.                                 
//                        /MMMdhhhhhhdMMM+  oNMMNNNNNMMm:                                  
//                        `dMMMNmmmNNMMMh`   -syyyyhhy/`                                   
//                         `/hmNNNNNmdh/`                                                  
//                            `.---..`

using System.Collections.Generic;

public static class ArrayMethods{
  public static TSource Head<TSource>(this List<TSource> list) => list[0];
  public static List<TSource> Tail<TSource>(this List<TSource> list) => list.GetRange(1, list.Count - 1);
  public static List<TSource> Init<TSource>(this List<TSource> list) => list.GetRange(0, list.Count - 1);
  public static TSource Last_<TSource>(this List<TSource> list) => list[^1];
}

//****************Sample Test*****************
namespace Solution 
{
  using static ArrayMethods;
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Sample Tests")]
    public void SampleTest()
    {
      Assert.AreEqual(5, new List<int> {5, 1}.Head());
      Assert.AreEqual(new List<int> {2, 3}, new List<int> {1, 2, 3}.Tail());
      Assert.AreEqual(new List<int> {1, 5, 7}, new List<int> {1, 5, 7, 9}.Init());
      Assert.AreEqual(2, new List<int> {7, 2}.Last_());
    }
    
    private static Random rnd = new Random();
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        List<int> test = new int[rnd.Next(1, 100)].Select(_ => rnd.Next()).ToList();
        
        Assert.AreEqual(test.First(), test.Head(), "Head failed.");
        Assert.AreEqual(test.Skip(1).ToList(), test.Tail(), "Tail failed.");
        Assert.AreEqual(test.Take(test.Count - 1).ToList(), test.Init(), "Init failed.");
        Assert.AreEqual(test.Last(), test.Last_(), "Last failed.");
      }
    }
  }
}
