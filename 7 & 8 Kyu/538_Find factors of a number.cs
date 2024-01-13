/*Challenge link:https://www.codewars.com/kata/564fa92d1639fbefae00009d/train/csharp
Question:
Create a function that takes a number and finds the factors of it, listing them in descending order in an array.

If the parameter is not an integer or less than 1, return -1. In C# return an empty array.

For Example: factors(54) should return [54, 27, 18, 9, 6, 3, 2, 1]
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
using System.Collections.Generic;

public class Kata{
  public static int[] Factors(int num){
    //return empty int array if less than 1
    if(num < 1) return new int[]{};
    
    //start from num, up to 1, (not zero because DivideByZeroException), descending order
    //add element to factors list if num mod i is 0
    List<int> factors = new List<int>();
    for(int i = num; i >= 1; i--)
      if(num % i == 0)
        factors.Add(i);

    //convert to array and return the result.
    return factors.ToArray();
  }
}

//solution 2
using System;
using System.Linq;
public class Kata
{
  public static int[] Factors(int n)
  {
    return n<1 ?new int[]{} : Enumerable.Range(1,n).Where(x=>n%x==0).OrderByDescending(x=>x).ToArray();
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Collections.Generic;

[TestFixture]
public class Tests
{
  [Test]
  [TestCase(54, ExpectedResult=new int[]{54,27,18,9,6,3,2,1})]
  [TestCase(9, ExpectedResult=new int[]{9,3,1})]
  [TestCase(0, ExpectedResult=new int[]{})]
  public static int[] FixedTest(int num)
  {
    return Kata.Factors(num);
  }
  
  private static int[] Solution(int num)
  {
    List<int> factors = new List<int>();
    if(num <= 0)
      return factors.ToArray();
    for(int i = 1; i <= num; i++)
    {
      if(num % i == 0)
        factors.Add(i);
    }
    int[] arr = factors.ToArray();
    Array.Sort(arr);
    Array.Reverse(arr);
    return arr;
  }
  
  [Test]
  public static void RandomTest([Random(-10,100,50)]int num)
  {
    int[] expected = Solution(num);
    int[] actual = Kata.Factors(num);
    Assert.AreEqual(expected, actual);
  }
}
