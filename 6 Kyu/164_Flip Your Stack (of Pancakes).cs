/*Challenge link:https://www.codewars.com/kata/6472390e0d0bb1001d963536/train/csharp
Question:
Background
Pat Programmer is worried about the future of jobs in programming because of the advance of AI tools like ChatGPT, and he decides to become a chef instead! So he wants to be an expert at flipping pancakes.

A pancake is characterized by its diameter, a positive integer. Given a stack of pancakes, you can insert a spatula under any pancake and then flip, which reverses the order of all the pancakes on top of the spatula.

Task
Write a function that takes a stack of pancakes and returns a sequence of flips that arranges them in order by diameter, with the largest pancake at the bottom and the smallest at the top. The pancakes are given as a list of positive integers, with the left end of the list being the top of the stack.

Based on Problem 4.6.2 in Skiena & Revilla, "Programming Challenges".

Example
Consider the stack [1,5,8,3]. One way of achieving the desired order is as follows:

The 8 is the biggest, so it should be at the bottom. Put the spatula under it (position 2 in the list) and flip.
This transforms the stack into [8,5,1,3], with the 8 at the top. Then flip the entire stack (spatula position 3).
This transforms the stack into [3,1,5,8], which has the 8 at the bottom. And since the 5 is in the correct position as well, now flip the 1 and 3 (spatula position 1).
The stack is now [1,3,5,8], as desired. The function should return [2,3,1].

Note
You don't have to find the shortest sequence of flips. That is a hard problem - see https://en.wikipedia.org/wiki/Pancake_sorting. However, don't include unnecessary flips, in the following sense:

(1) If 2 consecutive flips leave the stack in the same state, they should be omitted. For example, [2,3,2,2,1] also arranges [1,5,8,3] correctly, but 2,2 is unnecessary.
(2) Flipping only the top pancake doesn't achieve anything.

Performance should not be a issue. If Pat can flip 1,000 pancakes with diameters between 1 and 1,000, he thinks he can get a job!
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
/*left end of the list being the top of the stack.
 0,1,2,3
[1,5,8,3]
[8,5,1,3] pos 2, swap 8 and 1
[3,1,5,8] pos 3, flip entire stack 
[1,3,5,8] pos 1, swap 3 and 1

strat: remove stack until there's nothing left, while storing index in flips.
*/ 
using System.Linq;
using System.Collections.Generic;

public class PancakeFlip{
    public static List<int> FlipPancakes(List<int> s, int i = 0){
      //initialized empty list
      var flips = new List<int>();
      
      //remove stack until it reaches 0
      while(s.Count > 0){
        
        //get the index of largest number inside s
        i = s.IndexOf(s.Max());
        
        //if max value's index is at the end(right side), remove it
        if(i == s.Count - 1){ s.RemoveAt(s.Count - 1); continue;}
        
        while(true){
          //start from 0, reverse up to max value's index
          s.Reverse(0, i+1);
          //as long as i is not 0, add the current max value's index into flips.
          if(i != 0) flips.Add(i);
          
          //get the new index of largest number inside s
          i = s.IndexOf(s.Max());
          
          //if i is 0, add the index of last element to flips,
          //reverse s, and remove the last element in s, break out of current while loop
          if(i == 0){
            flips.Add(s.Count - 1);
            s.Reverse();
            s.RemoveAt(s.Count - 1);
            break;
          }
        }
      }
        return flips;
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

[TestFixture]
public class Tests
{
    [Test]
    public void ExampleTests()
    {
        List<int> case1 = new List<int> { 1, 5, 8, 3 };
        List<int> case2 = new List<int> { 5, 1, 2, 3, 4 };
        List<int> case3 = new List<int> { 1, 2, 3, 5, 4 };
        List<int> case4 = Enumerable.Range(1, 1000).Reverse().ToList();
        List<int> case5 = new List<int> { 2, 3, 1, 2, 4, 2 };
        List<int> case6 = new List<int> { 4, 1, 3, 2, 4, 6, 3, 9, 1 };

        List<List<int>> tests = new List<List<int>> { case1, case2, case3, case4, case5, case6 };

        foreach (List<int> elem in tests)
        {
            object[] verification = Preloaded.VerifyFlipPancakes(new List<int>(elem), PancakeFlip.FlipPancakes(new List<int>(elem)));
            bool result = (bool)verification[0];
            string message = (string)verification[1];
            Assert.True(result, message);
        }
    }
  
    [Test]
    public void EdgeCases()
    {
        List<int> case1 = new List<int> { 1, 3, 5, 8 };
        List<int> case2 = new List<int> { 1, 1, 1, 2, 2, 2 };
        List<int> case3 = new List<int> { };
        List<int> case4 = new List<int> { 6 };
      
        List<List<int>> tests = new List<List<int>> { case1, case2, case3, case4 };

        foreach (List<int> elem in tests)
        {
            object[] verification = Preloaded.VerifyFlipPancakes(new List<int>(elem), PancakeFlip.FlipPancakes(new List<int>(elem)));
            bool result = (bool)verification[0];
            string message = (string)verification[1];
            Assert.True(result, message);
        }
    }
    
    [Test]
    public void RandomTests()
    {
        Random random = new Random();

        for (int i = 0; i < 50; i++)
        {
            int stackSize = random.Next(10, 1001);
            List<int> stack = new List<int>();

            for (int j = 0; j < stackSize; j++)
            {
                int pancake = random.Next(1, 1001);
                stack.Add(pancake);
            }

            object[] verification = Preloaded.VerifyFlipPancakes(new List<int>(stack), PancakeFlip.FlipPancakes(new List<int>(stack)));
            bool result = (bool)verification[0];
            string message = (string)verification[1];
            Assert.True(result, message);
        }
    }
}
