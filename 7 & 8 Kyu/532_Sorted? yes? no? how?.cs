/*Challenge link:https://www.codewars.com/kata/580a4734d6df748060000045/train/csharp
Question:
Complete the method which accepts an array of integers, and returns one of the following:

"yes, ascending" - if the numbers in the array are sorted in an ascending order
"yes, descending" - if the numbers in the array are sorted in a descending order
"no" - otherwise
You can assume the array will always be valid, and there will always be one correct answer.
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
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
//x is the current element, first sort the array in ascending order, if sequence is equal to the original array
//then return "yes, ascending", else sort the array in inverse of ascending order, if sequence is equal to the array
//then return "yes, descending", else return "no"
using System.Linq;
public class Kata{
  public static string IsSortedAndHow(int[] array) => 
    array.OrderBy(x =>  x).SequenceEqual(array) ? "yes, ascending" :
    array.OrderBy(x => -x).SequenceEqual(array) ? "yes, descending": "no";
}

//solution 2
public static class Kata
{
    public static string IsSortedAndHow(int[] array)
    {
        bool flag = array[0] < array[1];
        for (int i = 2; i < array.Length; ++i)
            if (flag != (flag = array[i - 1] < array[i]))
                return "no";
        return flag ? "yes, ascending" : "yes, descending";
    }
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("yes, ascending", Kata.IsSortedAndHow(new [] { 1, 2 }));
      Assert.AreEqual("yes, descending", Kata.IsSortedAndHow(new [] { 15, 7, 3, -8 }));
      Assert.AreEqual("no", Kata.IsSortedAndHow(new [] { 4, 2, 30 }));
    }
       
    [Test]
    public void RandomTests()
    {
      Random rand = new Random();
      
      Func<int,int[]> randomArray = delegate (int size)
      {
        var array = Enumerable.Range(0,size).Select(a => rand.Next(-10000, 20000)).ToArray(); 
                
        var x = rand.Next(0, 5);
        if (x == 1 || x == 2)
        {
          array = array.OrderBy(a => a).ToArray();
        }
        else
        {
          if (x == 3 || x == 4) 
          {
            array = array.OrderBy(a => -a).ToArray();
          }
        }
        return array;
      };
      
      Func<int[],string> myIsSortedAndHow = delegate (int[] array)
      {
        if(array.OrderBy(a=>a).SequenceEqual(array)) return "yes, ascending";
        if(array.OrderByDescending(a=>a).SequenceEqual(array)) return "yes, descending";
        return "no";
      };
      
      var testArray = randomArray(7);      
      var expected = myIsSortedAndHow(testArray);
      var actual = Kata.IsSortedAndHow(testArray);
      Assert.AreEqual(expected, actual);
      
      testArray = randomArray(57);
      expected = myIsSortedAndHow(testArray);
      actual = Kata.IsSortedAndHow(testArray);
      Assert.AreEqual(expected, actual);
      
      testArray = randomArray(184);
      expected = myIsSortedAndHow(testArray);
      actual = Kata.IsSortedAndHow(testArray);
      Assert.AreEqual(expected, actual);
      
      testArray = randomArray(7392);
      expected = myIsSortedAndHow(testArray);
      actual = Kata.IsSortedAndHow(testArray);
      Assert.AreEqual(expected, actual);  
  
      testArray = randomArray(12345);
      expected = myIsSortedAndHow(testArray);
      actual = Kata.IsSortedAndHow(testArray);
      Assert.AreEqual(expected, actual);
    }
  }
}
