/*Challenge link:https://www.codewars.com/kata/578fdcfc75ffd1112c0001a1/train/csharp
Question:
A startup office has an ongoing problem with its bin. Due to low budgets, they don't hire cleaners. As a result, the staff are left to voluntarily empty the bin. It has emerged that a voluntary system is not working and the bin is often overflowing. One staff member has suggested creating a rota system based upon the staff seating plan.

Create a function binRota that accepts a 2D array of names. The function will return a single array containing staff names in the order that they should empty the bin.

Adding to the problem, the office has some temporary staff. This means that the seating plan changes every month. Both staff members' names and the number of rows of seats may change. Ensure that the function binRota works when tested with these changes.

Notes:

All the rows will always be the same length as each other.
There will be no empty spaces in the seating plan.
There will be no empty arrays.
Each row will be at least one seat long.
An example seating plan is as follows:

(see image at the link above)

Or as an array:

[ ["Stefan", "Raj",    "Marie"],
  ["Alexa",  "Amy",    "Edward"],
  ["Liz",    "Claire", "Juan"],
  ["Dee",    "Luke",   "Katie"] ]
The rota should start with Stefan and end with Dee, taking the left-right zigzag path as illustrated by the red line:

(see image at the link above)

As an output you would expect in this case:

["Stefan", "Raj", "Marie", "Edward", "Amy", "Alexa", "Liz", "Claire", "Juan", "Katie", "Luke", "Dee"])
*/

//***************Solution********************
//select many, x is current element, i is index
//if index mod 2 is equal to 0, return current element normally, else reverse the element
//conver to array and return the result
using System.Linq;

public class Kata{
    public static string[] BinRota(string[][] input){     
      return input.SelectMany((x, i) => i % 2 == 0 ? x : x.Reverse()).ToArray();;
    }
}

//using a list would cause O(n)^2 issue, nested loops
using System;
using System.Collections.Generic;
public class Kata{
    public static string[] BinRota(string[][] input){
      List<string> output = new List<string>();
      
        for(int i=0;i<input.Length;i++){
          if( i % 2 == 0){ 
            for(int j=0;j<input[i].Length;j++)
              output.Add(input[i][j]);
          }
          else{
            for(int j=input[i].Length-1;j>=0;j--)
              output.Add(input[i][j]);
          }
          }
      
      return output.ToArray();
    }
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;
    
    [TestFixture]
    public class Tests
    {
        private Random random = new Random();
    
        [Test]
        public void ExampleTests()
        {
            var testInput = new string[][] { new[] { "Bob", "Nora" }, new[] { "Ruby", "Carl"} };
            Assert.AreEqual(new[] { "Bob", "Nora", "Carl", "Ruby" }, Kata.BinRota(testInput));
            
            testInput = new string[][] { new[] { "Billy" } };
            Assert.AreEqual(new[] { "Billy" }, Kata.BinRota(testInput));
            
            testInput = new string[][] { new[] { "Billy", "Nancy" } };
            Assert.AreEqual(new[] { "Billy", "Nancy" }, Kata.BinRota(testInput));
            
            testInput = new string[][] { new[] { "Billy"}, new[] { "Megan" }, new[] { "Aki" }, new[] { "Arun" }, new[] { "Joy" } };
            Assert.AreEqual(new[] { "Billy", "Megan", "Aki", "Arun","Joy" }, Kata.BinRota(testInput));
  
            testInput = new string[][] { new[] { "Sam", "Nina", "Tim", "Helen", "Gurpreet", "Edward", "Holly", "Eliza" } , new[] { "Billy", "Megan", "Aki", "Arun", "Joy", "Anish", "Lee", "Maryan" }, new[] { "Nick", "Josh", "Pete", "Kavita", "Daisy", "Francesca", "Alfie", "Macy" } };
            Assert.AreEqual(new[] { "Sam", "Nina", "Tim", "Helen", "Gurpreet", "Edward", "Holly", "Eliza", "Maryan", "Lee", "Anish", "Joy", "Arun", "Aki", "Megan", "Billy", "Nick", "Josh", "Pete", "Kavita", "Daisy", "Francesca", "Alfie", "Macy" } , Kata.BinRota(testInput));
            
            testInput = new string[][] { new[] { "Stefan", "Raj", "Marie" }, new[] { "Alexa", "Amy", "Edward" }, new[] { "Liz", "Claire", "Juan" }, new[] { "Dee", "Luke", "Elle" } };
            Assert.AreEqual(new[] { "Stefan", "Raj", "Marie", "Edward", "Amy", "Alexa", "Liz", "Claire", "Juan", "Elle", "Luke", "Dee" }, Kata.BinRota(testInput));
        }
        
        [Test]
        public void RandomTests()
        {
            Func<string[][], string[]> Solution = (input) =>
            {
                return input.SelectMany((e, i) => i%2 == 0 ? e : e.Reverse()).ToArray();
            };
            
            Func<string> GenerateRandomString = () =>
            {
                string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            
                StringBuilder randomString = new StringBuilder();
                for(int i = 0; i < 5; i++)
                {
                    randomString.Append(alphabet[random.Next(0, alphabet.Length)]);
                }
                
                return randomString.ToString();
            };
            
            Action ExecuteTest = () =>
            {
                int randomDimension0 = random.Next(0, 21);
                int randomDimension1 = random.Next(0, 21);
                
                string[][] testInput = new string[randomDimension0][];
                for(int d0 = 0; d0 < randomDimension0; d0++)
                {
                    string[] row = new string[randomDimension1];
                    for(int d1 = 0; d1 < randomDimension1; d1++)
                    {
                        row[d1] = GenerateRandomString();
                    }
                    
                    testInput[d0] = row;
                }
                
                Assert.AreEqual(Solution(testInput), Kata.BinRota(testInput));
            };
            
            for(int i = 0; i < 100; i++)
            {
                ExecuteTest();
            }
        }
    }
}
