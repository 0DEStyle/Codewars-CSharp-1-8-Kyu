/*Challenge link:https://www.codewars.com/kata/56b97b776ffcea598a0006f2/train/csharp
Question:
Overview
Bubblesort is an inefficient sorting algorithm that is simple to understand and therefore often taught in introductory computer science courses as an example how not to sort a list. Nevertheless, it is correct in the sense that it eventually produces a sorted version of the original list when executed to completion.

At the heart of Bubblesort is what is known as a pass. Let's look at an example at how a pass works.

Consider the following list:

9, 7, 5, 3, 1, 2, 4, 6, 8
We initiate a pass by comparing the first two elements of the list. Is the first element greater than the second? If so, we swap the two elements. Since 9 is greater than 7 in this case, we swap them to give 7, 9. The list then becomes:

7, 9, 5, 3, 1, 2, 4, 6, 8
We then continue the process for the 2nd and 3rd elements, 3rd and 4th elements ... all the way up to the last two elements. When the pass is complete, our list becomes:

7, 5, 3, 1, 2, 4, 6, 8, 9
Notice that the largest value 9 "bubbled up" to the end of the list. This is precisely how Bubblesort got its name.

Task
Given an array of integers, your function bubblesortOnce/bubblesort_once/BubblesortOnce (or equivalent, depending on your language's naming conventions) should return a new array equivalent to performing exactly 1 complete pass on the original array. Your function should be pure, i.e. it should not mutate the input array.
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
using System.Linq;

public class Kata{
    public static int[] BubbleSortOnce(int[] input){
      //not mutate the input array.
      var bubble = input.ToArray();
      
      //loop through each element, compare and swap
      for(int i = 1; i < bubble.Length; i++)
        if(bubble[i - 1] > bubble[i])
          (bubble[i - 1], bubble[i]) = (bubble[i], bubble[i - 1]);   //swapping no jutsu
      
        return bubble;
    }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
  
    [TestFixture]
    public class Tests
    {
        private Random random = new Random();
        
        [Test]
        public void NoMutation() {
          int[] array = new int[] {3, 2, 1};
          int[] reference = new int[] {3, 2, 1};
          
          Kata.BubbleSortOnce(array);
          
          Assert.IsTrue(array.SequenceEqual(reference), "Don't modify the array");
        }
        [Test]
        public void _0_ExampleTest()
        {
            Assert.AreEqual(new int[] { 7, 5, 3, 1, 2, 4, 6, 8, 9 }, Kata.BubbleSortOnce(new int[] { 9, 7, 5, 3, 1, 2, 4, 6, 8 }));
        }
        
        [Test]
        public void _1_ExtendedTests()
        {
            Assert.AreEqual(new int[] { 1, 2 }, Kata.BubbleSortOnce(new int[] { 1, 2 }));
            Assert.AreEqual(new int[] { 1, 2 }, Kata.BubbleSortOnce(new int[] { 2, 1 }));
            Assert.AreEqual(new int[] { 1, 3 }, Kata.BubbleSortOnce(new int[] { 1, 3 }));
            Assert.AreEqual(new int[] { 1, 3 }, Kata.BubbleSortOnce(new int[] { 3, 1 }));
            Assert.AreEqual(new int[] { 24, 57 }, Kata.BubbleSortOnce(new int[] { 24, 57 }));
            Assert.AreEqual(new int[] { 36, 89 }, Kata.BubbleSortOnce(new int[] { 89, 36 }));
            
            Assert.AreEqual(new int[] { 1, 2, 3 }, Kata.BubbleSortOnce(new int[] { 1, 2, 3 }));
            Assert.AreEqual(new int[] { 2, 1, 4 }, Kata.BubbleSortOnce(new int[] { 2, 4, 1 }));
            Assert.AreEqual(new int[] { 5, 11, 17 }, Kata.BubbleSortOnce(new int[] { 17, 5, 11 }));
            Assert.AreEqual(new int[] { 16, 9, 25 }, Kata.BubbleSortOnce(new int[] { 25, 16, 9 }));
            Assert.AreEqual(new int[] { 87, 103, 113 }, Kata.BubbleSortOnce(new int[] { 103, 87, 113 }));
            Assert.AreEqual(new int[] { 1032, 2864, 3192 }, Kata.BubbleSortOnce(new int[] { 1032, 3192, 2864 }));
            
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, Kata.BubbleSortOnce(new int[] { 1, 2, 3, 4 }));
            Assert.AreEqual(new int[] { 2, 3, 1, 4 }, Kata.BubbleSortOnce(new int[] { 2, 3, 4, 1 }));
            Assert.AreEqual(new int[] { 3, 1, 2, 4 }, Kata.BubbleSortOnce(new int[] { 3, 4, 1, 2 }));
            Assert.AreEqual(new int[] { 1, 2, 3, 4 }, Kata.BubbleSortOnce(new int[] { 4, 1, 2, 3 }));
            Assert.AreEqual(new int[] { 5, 3, 1, 7 }, Kata.BubbleSortOnce(new int[] { 7, 5, 3, 1 }));
            Assert.AreEqual(new int[] { 3, 5, 7, 7 }, Kata.BubbleSortOnce(new int[] { 5, 3, 7, 7 }));
            Assert.AreEqual(new int[] { 1, 3, 5, 8 }, Kata.BubbleSortOnce(new int[] { 3, 1, 8, 5 }));
            Assert.AreEqual(new int[] { 1, 5, 5, 9 }, Kata.BubbleSortOnce(new int[] { 1, 9, 5, 5 }));
        }
        
        [Test]
        public void _2_AdvancedTests()
        {
            Assert.AreEqual(new int[] { 3, 4, 6, 1, 2, 7, 8, 5, 9 }, Kata.BubbleSortOnce(new int[] { 6, 3, 4, 9, 1, 2, 7, 8, 5 }));
            Assert.AreEqual(new int[] { 3, 4, 6, 14, 9, 1, 2, 7, 8, 5, 14, 11, 15, 15, 17, 19 }, Kata.BubbleSortOnce(new int[] { 6, 3, 4, 15, 14, 9, 1, 2, 7, 8, 5, 14, 11, 15, 17, 19 }));
        }
        
        [Test]
        public void _3_RandomTests()
        {
            Func<int[], int[]> Solution = (input) =>
            {
                int[] result = (int[])input.Clone();
                for(int i = 0; i < input.Length - 1; i++)
                {
                    if (result[i] > result[i + 1])
                    {
                        int temp = result[i]; 
                        result[i] = result[i + 1];
                        result[i + 1] = temp;  
                    }
                }
                
                return result;
            };
            
            for(int i = 0; i < 100; i++)
            {
                int randomInputLength = random.Next(2, 101);
                int[] randomInput = new int[randomInputLength];
                for(int j = 0; j < randomInputLength; j++)
                {
                    randomInput[j] = random.Next(0, 101);
                }
                
                var expected = Solution(randomInput);
                var actual = Kata.BubbleSortOnce(randomInput);
                
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
