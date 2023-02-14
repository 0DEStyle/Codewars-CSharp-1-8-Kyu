/*Challenge link:https://www.codewars.com/kata/54dc6f5a224c26032800005c/train/csharp
Question:
A bookseller has lots of books classified in 26 categories labeled A, B, ... Z. Each book has a code c of 3, 4, 5 or more characters. The 1st character of a code is a capital letter which defines the book category.

In the bookseller's stocklist each code c is followed by a space and by a positive integer n (int n >= 0) which indicates the quantity of books of this code in stock.

For example an extract of a stocklist could be:

L = {"ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"}.
or
L = ["ABART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"] or ....
You will be given a stocklist (e.g. : L) and a list of categories in capital letters e.g :

M = {"A", "B", "C", "W"} 
or
M = ["A", "B", "C", "W"] or ...
and your task is to find all the books of L with codes belonging to each category of M and to sum their quantity according to each category.

For the lists L and M of example you have to return the string (in Haskell/Clojure/Racket/Prolog a list of pairs):

(A : 20) - (B : 114) - (C : 50) - (W : 0)
where A, B, C, W are the categories, 20 is the sum of the unique book of category A, 114 the sum corresponding to "BKWRK" and "BTSQZ", 50 corresponding to "CDXEF" and 0 to category 'W' since there are no code beginning with W.

If L or M are empty return string is "" (Clojure/Racket/Prolog should return an empty array/list instead).

Notes:
In the result codes and their values are in the same order as in M.
See "Samples Tests" for the return.

*/

//***************Solution********************
using System;
using System.Collections.Generic;

public class StockList {
    public static string stockSummary(String[] LA, String[] LC) {
      
      //Nice description right there for such straight forward Kata, thanks.
      //(I'm crying hard because I'm dumb no one loves me omfg, wtf are you on about mate I can't.... waaaaahhhhh😭)
      
      //Anyway, the goal is to match the initial letter, so if any character from List of Character in Categories matches 
      //any initial letter of the stocklist,
      //add that number to the letter, e.g. 'B' matches  "BKWR 250" and "BTSQ 890", so add 250 and 890 and you get 1140
      //return the result as (B : 1140)....
      
      //Enable below to check wtf LA and LC are
      //Console.WriteLine("LA:" + String.Join(" ",LA) + "LC:" + String.Join(" ",LC));
      
      List<string> result = new List<string>();
      
      //Loop the Categories character
      for(int i = 0; i < LC.Length;i++){
        int codeSum = 0; //reset the sum
        
        //loop the stocklist and sum up the numbers, check each initial of stocklist matches the Categories character
        for(int j = 0; j < LA.Length;j++){
          //Split the string, LA[j] shows the individual element
          //bookValue[0] get the Letters of the book, bookValue[1] get the code of the book
          var bookValue = LA[j].Split(" ");
          
          //check if the categories letter matches the initial letter of the stocklist
          //bookValue[0][0] get the first letter of the book
          bool checkCategories = LC[i]== bookValue[0][0].ToString(); 
          if(checkCategories)
            codeSum += Convert.ToInt32(bookValue[1]); //take the code and add it to the sum
          
          // Console.WriteLine(codeSum); //check the sum if you want
        }
        result.Add($"({LC[i]} : {codeSum})"); //data strucuture, add categories result to the list 
      }
      //if parameters are not empty, join the list together with " - "
        return LA.Length == 0 || LC.Length == 0 ? "" : String.Join (" - ", result); 
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
public class StockListTests {

[Test]
  public void Test1() {
    string[] art = new string[] {"ABAR 200", "CDXE 500", "BKWR 250", "BTSQ 890", "DRTY 600"};
    String[] cd = new String[] {"A", "B"};
    Assert.AreEqual("(A : 200) - (B : 1140)", StockList.stockSummary(art, cd));
  }
[Test]
  public void Test2() {
    string[] art = new string[] {"BBAR 150", "CDXE 515", "BKWR 250", "BTSQ 890", "DRTY 600"};
    String[] cd = new String[] {"A", "B", "C", "D"};
    Assert.AreEqual("(A : 0) - (B : 1290) - (C : 515) - (D : 600)", StockList.stockSummary(art, cd));
  }
[Test]
  public void Test3() {
    string[] art = new string[] {"CBART 20", "CDXEF 50", "BKWRK 25", "BTSQZ 89", "DRTYM 60"};
    String[] cd = new String[] {"A", "B", "C", "W"};
    Assert.AreEqual("(A : 0) - (B : 114) - (C : 70) - (W : 0)", StockList.stockSummary(art, cd));
  }
[Test]
  public void Test4() {
    string[] art = new string[] {};
    String[] cd = new String[] {"B", "R", "D", "X"};
    Assert.AreEqual("", StockList.stockSummary(art, cd));
  }
[Test]
  public void Test5() {
    string[] art = new string[] {"ROXANNE 102", "RHODODE 123", "BKWRKAA 125", "BTSQZFG 239", "DRTYMKH 060"};
    String[] cd = new String[] {};
    Assert.AreEqual("", StockList.stockSummary(art, cd));
  }
[Test]
  public void Test6() {
    string[] art = new string[] {"ROXANNE 102", "RHODODE 123", "BKWRKAA 125", "BTSQZFG 239", "DRTYMKH 060"};
    String[] cd = new String[] {"B", "R", "D", "X"};
    Assert.AreEqual("(B : 364) - (R : 225) - (D : 60) - (X : 0)", StockList.stockSummary(art, cd));
  }
}
