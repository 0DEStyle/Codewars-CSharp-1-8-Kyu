/*Challenge link:https://www.codewars.com/kata/55c6126177c9441a570000cc/train/csharp
Question:
My friend John and I are members of the "Fat to Fit Club (FFC)". John is worried because each month a list with the weights of members is published and each month he is the last on the list which means he is the heaviest.

I am the one who establishes the list so I told him: "Don't worry any more, I will modify the order of the list". It was decided to attribute a "weight" to numbers. The weight of a number will be from now on the sum of its digits.

For example 99 will have "weight" 18, 100 will have "weight" 1 so in the list 100 will come before 99.

Given a string with the weights of FFC members in normal order can you give this string ordered by "weights" of these numbers?

Example:
"56 65 74 100 99 68 86 180 90" ordered by numbers weights becomes: 

"100 180 90 56 65 74 68 86 99"
When two numbers have the same "weight", let us class them as if they were strings (alphabetical ordering) and not numbers:

180 is before 90 since, having the same "weight" (9), it comes before as a string.

All numbers in the list are positive numbers and the list can be empty.

Notes
it may happen that the input string have leading, trailing whitespaces and more than a unique whitespace between two consecutive numbers
For C: The result is freed.
*/

//***************Solution********************
//Solution 1
//split the string "strng", store in array
//add each individual digit, and store inside a 2D list
//sort the list by value, then by key, return the result.

using System;
using System.Collections.Generic;
using System.Linq;

public class WeightSort {
	
	public static string orderWeight(string strng) {
    Console.WriteLine("strng are " + strng);
    
    List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
		int sum = 0;
    string text = ""; //used for access char digit in string
    string[] arr = strng.Split(' ');

    for (int i = 0; i < arr.Length; i++){
    text = arr[i];
    for(int j = 0; j < arr[i].Length; j++)
        sum += (int)char.GetNumericValue(text[j]);

    list.Add(new KeyValuePair<string, int>(arr[i], sum)); //add to list
    sum = 0; //reset num
    }
    
    var listordered = list.OrderBy(x => x.Value).ThenBy(x=> x.Key);
    
    Console.WriteLine(string.Join(" ", listordered.Select(x => x.Key).ToList()));
    return string.Join(" ", listordered.Select(x => x.Key).ToList()); 
	}
}

//Solution 2
//same as above
//simiplfied into one line by using an Lambda expression with Enumerable methods.

using System;
using System.Linq;

public class WeightSort 
{
  public static string orderWeight(string strng)    
    => string.Join(" ", strng.Split().OrderBy(s => s.Sum(char.GetNumericValue)).ThenBy(x => x));
}
//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class WeightSortTests {

[Test]
    public void Test1() {
      Console.WriteLine("****** Basic Tests");    
      Assert.AreEqual("2000 103 123 4444 99", WeightSort.orderWeight("103 123 4444 99 2000"));
      Assert.AreEqual("11 11 2000 10003 22 123 1234000 44444444 9999", WeightSort.orderWeight("2000 10003 1234000 44444444 9999 11 11 22 123"));
      Assert.AreEqual("", WeightSort.orderWeight(""));
      Assert.AreEqual("2000 10003 1234000 44444444 9999 123456789", WeightSort.orderWeight("10003 1234000 44444444 9999 2000 123456789"));
      String a = "3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697";
      String r = "3 16 9 38 95 1131268 49455 347464 59544965313 496636983114762 85246814996697";
      Assert.AreEqual(r, WeightSort.orderWeight(a));
      a = "71899703 200 6 91 425 4 67407 7 96488 6 4 2 7 31064 9 7920 1 34608557 27 72 18 81";
      r = "1 2 200 4 4 6 6 7 7 18 27 72 81 9 91 425 31064 7920 67407 96488 34608557 71899703";
      Assert.AreEqual(r, WeightSort.orderWeight(a));
      a = "387087 176 351832 100 430372 8 58052 54 175432 120 269974 147 309754 91 404858 67 271476 164 295747 111 40";
      r = "100 111 120 40 8 54 91 164 147 67 176 430372 58052 175432 351832 271476 309754 404858 387087 295747 269974";
      Assert.AreEqual(r, WeightSort.orderWeight(a));
    }
    //--------------------
    private static int weightStrNbSol(string strng) {
      char[] digits = strng.ToCharArray();
      int dsum = 0;
      foreach (char d in digits) {
        int dgt = int.Parse(d.ToString());
        dsum += dgt;
      }
      return dsum;
    }
    private static int cmpSol(string x, string y) {
      int cp =  weightStrNbSol(x) - weightStrNbSol(y);
      if (cp == 0) 
        return string.Compare(x, y);
      if (cp < 0) return -1; else return 1;
    }
    private static string orderWeightSol(string strng) {
      string[] lstr = strng.Split(' ');   
      Array.Sort(lstr, cmpSol);
      string res = string.Join(" ", lstr);
      return res;
    }
    private static string doEx() {
      string res = "";
      Random rnd = new Random();
      for (int i =  0; i < 20; i++) {
        int n = rnd.Next(1, 500000);
        res += n + " ";
      }
      return res + rnd.Next(1, 100);
    }
    //--------------------
[Test]
    public static void Test2() {
      Console.WriteLine("\n 50 Random Tests ****************");
      for (int i = 0; i < 50; i++) {    
        String a = WeightSortTests.doEx();
        // Console.WriteLine("Order Weight " + a);
        Assert.AreEqual(WeightSortTests.orderWeightSol(a), WeightSort.orderWeight(a));
      }
   }
}
