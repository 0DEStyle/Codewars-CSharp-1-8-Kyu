/*Challenge link:https://www.codewars.com/kata/5a29a0898f27f2d9c9000058/train/csharp
Question:
In this Kata, you will be given a string and your task will be to return a list of ints detailing the count of uppercase letters, lowercase, numbers and special characters, as follows.

Solve("*'&ABCDabcde12345") = [4,5,5,3]. 
--the order is: uppercase letters, lowercase, numbers and special characters.
More examples in the test cases.

Good luck!
*/

//***************Solution********************
//using regex to check if character matches the regex expression,
//if so, count those characters and stoer in a variable
//return the result in array format.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Text.RegularExpressions;
using System.Linq;
//uppercase letters, lowercase, numbers and special characters, 

public class Solution{
    public static int [] solve(String s){
      // \p{category} - In that Unicode category
      // category = Lu - Letter, uppercase
      // category = Ll - letter, lowercase
      // [0-9] = numbers
      // \W = non word character
      
      Console.WriteLine(s);
      int countUpper = Regex.Matches(s, @"\p{Lu}").Count;
      int countLower = Regex.Matches(s, @"\p{Ll}").Count;
      int countNumber= Regex.Matches(s, @"[0-9]").Count;
      int countOther = Regex.Matches(s, @"\W").Count;
      Console.WriteLine($"{countUpper},{countLower},{countNumber},{countOther}");
        return new int[] {countUpper,countLower,countNumber,countOther};
    }
}

//solution 2
using System.Linq;

public class Solution
{
  public static int [] solve(string s)
  {
    return new[]
    {
        s.Count(char.IsUpper),
        s.Count(char.IsLower),
        s.Count(char.IsDigit),
        s.Count(x => !char.IsLetterOrDigit(x))
    };
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
 
[TestFixture]
public class SolutionTest
{
  [Test]
  public void ExampleTests()
  {
    
    Assert.AreEqual(new int[] {1,18,3,2}, Solution.solve("Codewars@codewars123.com"));
    Assert.AreEqual(new int[] {7,6,3,2},  Solution.solve("bgA5<1d-tOwUZTS8yQ"));     
    Assert.AreEqual(new int[] {9,9,6,9}, Solution.solve("P*K4%>mQUDaG$h=cx2?.Czt7!Zn16p@5H"));
    Assert.AreEqual(new int[] {15,8,6,9},  Solution.solve("RYT'>s&gO-.CM9AKeH?,5317tWGpS<*x2ukXZD"));
  }

  private static int [] hj1(String s){
        int [] arr  = new int [4];
        for (int i = 0; i < s.Length; ++i){         
            if (Char.IsUpper(s[i])) arr[0]++;
            else if (Char.IsLower(s[i])) arr[1]++;
            else if (Char.IsDigit(s[i])) arr[2]++;
            else arr[3]++;
        }
    return arr; 
    }

  [Test]
  public void RandomTests(){
    Random random = new Random();     
    for (int i = 0; i < 100; i++){ 
      int len = random.Next(4, 200);
      string st = "";
      while (len > 0){
          if ((random.Next(0, 20)) < 10) {
            int up = 65 + (random.Next(0, 26));
            st += (char)up;
          } 
          if ((random.Next(0, 20)) > 10) {
            int lo = 97 + (random.Next(0, 26));
            st += (char)lo;
          } 
          if ((random.Next(0, 20)) % 2 == 0) {
            int num = 48 + (random.Next(0, 10));
            st += (char)num;
          } 
          if ((random.Next(0, 20)) % 2 == 1) {
            int sp =  33 + (random.Next(0, 15));
            st += (char)sp;
          }   
          len--;
        }
      
      int [] exp = hj1(st);
      Assert.AreEqual(exp,Solution.solve(st));
    }
  }
}
