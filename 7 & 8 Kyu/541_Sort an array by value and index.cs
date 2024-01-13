/*Challenge link:https://www.codewars.com/kata/58e0cb3634a3027180000040/train/csharp
Question:
Sort an array by value and index
Your task is to sort an array of integer numbers by the product of the value and the index of the positions.

For sorting the index starts at 1, NOT at 0!
The sorting has to be ascending.
The array will never be null and will always contain numbers.

Example:

Input: 23, 2, 3, 4, 5
Product of value and index:
23 => 23 * 1 = 23  -> Output-Pos 4
 2 =>  2 * 2 = 4   -> Output-Pos 1
 3 =>  3 * 3 = 9   -> Output-Pos 2
 4 =>  4 * 4 = 16  -> Output-Pos 3
 5 =>  5 * 5 = 25  -> Output-Pos 5

Output: 2, 3, 4, 23, 5



Have fun coding it and please don't forget to vote and rank this kata! :-)

I have also created other katas. Take a look if you enjoyed this kata!
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
//x is curretn element, i is index, starting from 1
//create new int with x[0] as original element, x[1] as product of index and value
//sort x[1] in ascending order, select all x[0], store in array and return result.
using System.Linq;

public class Kata{
  public static int[] SortByValueAndIndex(int[] array){
    return array.Select((x,i) => new int[] {x , x * (i + 1)}) 
                .OrderBy(x => x[1])
                .Select(x => x[0]).ToArray();
  }
}

//solution 2
using System.Linq;

public class Kata
{
  public static int[] SortByValueAndIndex(int[] array, int i = 1) => array.OrderBy(n => n * i++).ToArray();
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
    
  public class KataTests
  {
    [Test]
    public void ExampleTests()
    { 
      var actual = Kata.SortByValueAndIndex(new int[] { 1, 2, 3, 4, 5 });
      var expected = new int[] { 1, 2, 3, 4, 5 };
      var message = "Your result:\n" + ArrayToString(actual) + "\n\nExpected result:\n" + ArrayToString(expected);
      Assert.AreEqual(expected, actual, message);
      
      actual = Kata.SortByValueAndIndex(new int[] { 23, 2, 3, 4, 5 });
      expected = new int[] { 2, 3, 4, 23, 5 };
      message = "Your result:\n" + ArrayToString(actual) + "\n\nExpected result:\n" + ArrayToString(expected);
      Assert.AreEqual(expected, actual, message);
      
      actual = Kata.SortByValueAndIndex(new int[] { 26, 2, 3, 4, 5 });
      expected = new int[] { 2, 3, 4, 5, 26 };
      message = "Your result:\n" + ArrayToString(actual) + "\n\nExpected result:\n" + ArrayToString(expected);
      Assert.AreEqual(expected, actual, message);
      
      actual = Kata.SortByValueAndIndex(new int[] { 9, 5, 1, 4, 3 });
      expected = new int[] { 1, 9, 5, 3, 4 };
      message = "Your result:\n" + ArrayToString(actual) + "\n\nExpected result:\n" + ArrayToString(expected);
      Assert.AreEqual(expected, actual, message);
    }
    
    [Test]
    public void RandomTests()
    { 
      var rand = new Random();
            
      for(var r=0;r<20;r++)
      {
        var n = rand.Next(1,21);
        var array =  Enumerable.Range(0,n).Select(b => rand.Next(-30,30)).ToArray();
        
        var expected = array.Select((a,i) => new int[] { a, a * (i+1)}).OrderBy(a => a[1]).Select(a => a[0]).ToArray();;
        var actual = Kata.SortByValueAndIndex(array);
        var message = "Your result:\n" + ArrayToString(actual) + "\n\nExpected result:\n" + ArrayToString(expected);
        
        Assert.AreEqual(expected, actual, message);
      }
    }
    
    private String ArrayToString(int[] array)
    {
      return String.Join(", ", array);
    }
  }
}
