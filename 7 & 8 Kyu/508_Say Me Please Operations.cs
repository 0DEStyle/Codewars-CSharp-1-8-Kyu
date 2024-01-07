/*Challenge link:https://www.codewars.com/kata/5b5e0c0d83d64866bc00001d/train/csharp
Question:
You have a string of numbers; starting with the third number each number is the result of an operation performed using the previous two numbers.

Complete the function which returns a string of the operations in order and separated by a comma and a space, e.g. "subtraction, subtraction, addition"

The available operations are (in this order of preference):

1) addition
2) subtraction
3) multiplication
4) division
Notes:

All input data is valid
The number of numbers in the input string >= 3
For a case like "2 2 4" - when multiple variants are possible - choose the first possible operation from the list (in this case "addition")
Integer division should be used
Example
"9 4 5 20 25"  -->  "subtraction, multiplication, addition"
*/

//***************Solution********************

/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡖⠙⡢⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣿⡏⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⣿⡿⣿⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⠶⠞⠛⠿⣿⣿⡿⣿⣇⡀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡾⠋⢠⠄⠀⠀⠀⠀⠈⠉⡉⠈⠛⢦⡀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⣤⠀⠀⠀⠀⠀⠻⢦⣴⣀⣀⠀⠀⠀⠀⢈⠁⣀⡄⠀⠹⣆⠀⠀⠀
⠀⠀⠀⠀⢰⠓⡄⠀⠀⠀⠀⠀⢸⡇⠉⠉⠙⠛⠛⠛⠛⠛⠉⠀⠀⠀⠹⣆⠀⠀
⢠⣒⣊⢍⣩⢙⣩⣍⡩⡇⠀⠀⢸⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢻⡀⠀
⣸⣀⣈⣁⣀⣉⣀⣀⣠⣇⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡆⠘⣇⠀
⠉⠉⠉⠛⠿⠻⣯⠉⠉⠉⠀⢀⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⢿⠀
⠀⠀⠀⠀⠀⠀⠈⢳⣄⠀⢠⡞⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⢸⡇
⠀⠀⠀⠀⠀⠀⠀⠀⠉⠛⠋⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠁⠀⠘⣇
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣿⠀⠀⠀⣿
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠟⠁⠀⠀⢻

*/
//split the number inside string s by space, parse each number and store in array num
//generate sequence start from 0, count up to num.Length -2(starting with third number)
//using tenary to compare current and next element, to see if result matches, return string accordingly
using System.Linq;

public class Kata{
      public static string sayMeOperations(string s){
        var num = s.Split().Select(x => int.Parse(x)).ToArray();
        
        var str = string.Join(", ", Enumerable.Range(0, num.Length - 2).Select(x =>
            num[x] + num[x + 1] == num[x + 2] ? "addition":
            num[x] - num[x + 1] == num[x + 2] ? "subtraction":
            num[x] * num[x + 1] == num[x + 2] ? "multiplication": "division"));
        
          return str;
      }
}

//solution 2
using System;
using System.Collections.Generic;
using System.Linq;

public class Kata
{
    public static string sayMeOperations(string stringNumbers)
    {
        var operations = new Dictionary<string, Func<int, int, int>>
        {
            {"addition", (a, b) => a + b},
            {"subtraction", (a, b) => a - b},
            {"multiplication", (a, b) => a * b},
            {"division", (a, b) => a / b}
        };

        var result = new List<string>();
        var numbers = stringNumbers.Split(' ').Select(int.Parse).ToList();
        for (var i = 2; i < numbers.Count; i++)
            foreach (var operation in operations.Where(operation =>
                numbers[i] == operation.Value(numbers[i - 2], numbers[i - 1])))
            {
                result.Add(operation.Key);
                break;
            }


        return string.Join(", ", result);
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
namespace Solution 
{
  using NUnit.Framework;
  using System;  

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void RandomTests()
    {
      Assert.AreEqual("subtraction", Kata.sayMeOperations("4 2 2"));
      for(int i = 0;i < 10;i++)
      {
        var a = CreateRandomTest(20);
        Assert.AreEqual(sayMeOperationsRand(a), Kata.sayMeOperations(a));
       }
    }
      private static string sayMeOperationsRand(string  stringNumbers)
      {
          List<int> data = new List<int>();
          List<string> dataOperations = new List<string>();

          data = stringNumbers.Split(' ').Select(nrStr => Convert.ToInt32(nrStr)).ToList();

          for(int i = 0; i < data.Count-2; i++)
          {
                if (data[i + 2] == data[i] + data[i + 1]) { dataOperations.Add("addition"); continue; }
                if (data[i + 2] == data[i] - data[i + 1]) { dataOperations.Add("subtraction"); continue; }
                if (data[i + 2] == data[i] * data[i + 1]) { dataOperations.Add("multiplication"); continue; }
                if (data[i + 2] == data[i] / data[i + 1]) { dataOperations.Add("division"); continue; }
          }

          return string.Join(", ",dataOperations);
      }
      
      public static string CreateRandomTest(int max)
      {
          List<int> data = new List<int>();
          data.Add(new Random().Next(0, max));
          data.Add(new Random().Next(0, max));
          int nrTests = new Random().Next(1, 20);
          for(int i =0; i < nrTests; i++)
          {
              var operation = new Random().Next(1, 4);
              if (operation == 1) data.Add(data[i] + data[i + 1]); 
              if (operation == 2) data.Add(data[i] - data[i + 1]); 
              if (operation == 3) data.Add(data[i] * data[i + 1]);
              if (operation == 4) data.Add(data[i] / data[i + 1]);
          }

          return string.Join(" ", data);
      }
  }
}
