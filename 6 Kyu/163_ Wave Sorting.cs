/*Challenge link:https://www.codewars.com/kata/596f28fd9be8ebe6ec0000c1/train/csharp
Question:
A list of integers is sorted in “Wave” order if alternate items are not less than their immediate neighbors (thus the other alternate items are not greater than their immediate neighbors).

Thus, the array [4, 1, 7, 5, 6, 2, 3] is in Wave order because 4 >= 1, then 1 <= 7, then 7 >= 5, then 5 <= 6, then 6 >= 2, and finally 2 <= 3.

The wave-sorted lists has to begin with an element not less than the next, so [1, 4, 5, 3] is not sorted in Wave because 1 < 4

Your task is to implement a function that takes a list of integers and sorts it into wave order in place; your function shouldn't return anything.

Note:

The resulting array shouldn't necessarily match anyone in the tests, a function just checks if the array is now wave sorted.
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
                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`                             
                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                              
                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-                              
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
//sort the array first, then swap odd with even index.
using System;

public class Kata{
  public static void WaveSort(int[] arr){
    Array.Sort(arr);
     for (int i = 1; i < arr.Length; i += 2)
       (arr[i], arr[i-1]) = (arr[i-1], arr[i]);
      
    /* C way
       int temp = 0;
    
       temp = arr[i];
       arr[i] = arr[i - 1];
       arr[i - 1] = temp;
       */
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using static Kata;
  using static Preloaded;
  using System.Collections.Generic;
  using System.Linq;

    [TestFixture]
    public class KataTests
    {
        private static readonly Random R = new Random(DateTime.Now.Millisecond);

        [Test, Repeat(200)]
        public void TestRandom()
        {
            var arr = RandArray(R.Next(48) + 2).ToArray();
            var expected = arr.OrderBy(o => o).ToArray();

            WaveSort(arr);
            var actual = arr.OrderBy(o => o).ToArray();
            var res = IsWaveSorted(arr);

            Assert.IsTrue(res);
            CollectionAssert.AreEqual(expected, actual);
        }

        public static IEnumerable<int> RandArray(int lent)
        {
            var i = 0;
            while (i++ < lent)
                yield return R.Next(50);
        }
    }
}
