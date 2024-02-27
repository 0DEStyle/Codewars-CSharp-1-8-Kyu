/*Challenge link:https://www.codewars.com/kata/594a1822a2db9e93bd0001d4/train/csharp
Question:
Task
You got a scratch lottery, you want to know how much money you win.

There are 6 sets of characters on the lottery. Each set of characters represents a chance to win. The text has a coating on it. When you buy the lottery ticket and then blow it off, you can see the text information below the coating.

Each set of characters contains three animal names and a number, like this: "tiger tiger tiger 100". If the three animal names are the same, Congratulations, you won the prize. You will win the same bonus as the last number.

Given the lottery, returns the total amount of the bonus.

Input/Output
[input] string array lottery

A string array that contains six sets of characters.

[output] an integer

the total amount of the bonus.

Example
For

lottery = [
"tiger tiger tiger 100",
"rabbit dragon snake 100",
"rat ox pig 1000",
"dog cock sheep 10",
"horse monkey rat 5",
"dog dog dog 1000"
]```

the output should be `1100`.

`"tiger tiger tiger 100"` win $100, and `"dog dog dog 1000"` win $1000. 

`100 + 1000 = 1100`
*/

//***************Solution********************
using System.Text.RegularExpressions;

public class Kata{
  public static int Scratch(string[] lottery, int count = 0){
    int result = 0;
    
    //stop condition, when lottery length-1 is less than count
    if(lottery.Length-1 < count) 
      return 0;
    
    //pattern group 1, any word, space matches group 1, space match group 1
    //replace current lottery's number with nothing, output to result
    if(Regex.IsMatch(lottery[count], @"(\w+) \1 \1"))
      int.TryParse(Regex.Replace(lottery[count], @"\D", ""), out result);
    
    //recursion accumulate sum
    return result + Scratch(lottery, count+1);
  }
}

//linq method
using System.Linq;
public class Kata
{
    public static int Scratch(string[] lottery) => 
      lottery.Select(t => t.Split(' ')).Where(arr => arr[0] == arr[1] && arr[1] == arr[2]).Sum(arr => int.Parse(arr[3]));
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;

  public class Sample
  {
    static object[] TestCases =
    {
      new object[] 
      {
        new string[]
        {
          "tiger tiger tiger 100",
          "rabbit dragon snake 100",
          "rat ox pig 1000",
          "dog cock sheep 10",
          "horse monkey rat 5",
          "dog dog dog 1000"
        },
        1100
      }
    };
  }

  [TestFixture]
  public class LottoChecker
  {
    [Test, TestCaseSource(typeof(Sample), "TestCases")]
    public void Sample_Tests(string[] lottery, int expected)
    {
      Assert.AreEqual(expected, Kata.Scratch(lottery));
    }
    
    private static int solution(string[] lottery) =>
      lottery.Select(v => v.Split(' '))
             .Where(v => v[0] == v[1] && v[1] == v[2])
             .Aggregate(0, (p, c) => p + Int32.Parse(c[3]));
             
    private static Random rnd = new Random();
    
    private static string[] animals = new string[] {"tiger", "rabbit", "dragon", "snake", "rat", "ox", "pig", "dog", "cock", "sheep", "horse", "monkey"};
    
    [Test]
    public void Random_Tests()
    {
      for (int i = 0; i < 200; ++i)
      {
        string[] test = new string[6];
        for (int j = 0; j < 6; ++j)
        {
          StringBuilder sb = new StringBuilder();
          for (int k = 0; k < 3; ++k)
          {
            sb.Append(animals[rnd.Next(0, animals.Length)] + ' ');
          }
          test[j] = sb.ToString() + rnd.Next(1, 1001).ToString();
        }
        int expected = solution(test);
        int actual = Kata.Scratch(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
