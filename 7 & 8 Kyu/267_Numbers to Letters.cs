/*Challenge link:https://www.codewars.com/kata/57ebaa8f7b45ef590c00000c/train/csharp
Question:
Given an array of numbers (in string format), you must return a string. The numbers correspond to the letters of the alphabet in reverse order: a=26, z=1 etc. You should also account for '!', '?' and ' ' that are represented by '27', '28' and '29' respectively.

All inputs will be valid.


*/

//***************Solution********************
//convert the character to ASCII and Concat it together.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;

public class Kata
{
  public static string Switcher(string[] x) => string.Concat(x.Select(n => "zyxwvutsrqponmlkjihgfedcba!? "[int.Parse(n) - 1]));
}
//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Linq;
    
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExampleTest1()
        {
            string expected = "codewars"; 
            
            string actual = Kata.Switcher(new string[] { "24", "12", "23", "22", "4", "26", "9", "8" });
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExampleTest2()
        {
            string expected = "btswmdsbd kkw"; 
            
            string actual = Kata.Switcher(new string[] { "25", "7", "8", "4", "14", "23", "8", "25", "23", "29", "16", "16", "4" });
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExampleTest3()
        {
            string expected = "wc"; 
            
            string actual = Kata.Switcher(new string[] { "4", "24" });
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtendedTest1()
        {
            string expected = "o?bfbtpel"; 
            
            string actual = Kata.Switcher(new string[] { "12", "28", "25", "21", "25", "7", "11", "22", "15" });
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtendedTest2()
        {
            string expected = "o"; 
            
            string actual = Kata.Switcher(new string[] { "12" });
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RandomTests()
        {
            Random rand = new Random();
            
            Func<string[], string> Solution = (x) =>
            {
                return string.Concat(x.Select(e => "zyxwvutsrqponmlkjihgfedcba!? "[int.Parse(e) - 1]));
            };
            
            for(int i = 0; i < 100; i++)
            {
                int length = rand.Next(1, 30);
                
                var x = Enumerable.Range(0, length).Select(n => rand.Next(1, 30).ToString()).ToArray();
                
                string expected = Solution(x); 
            
                string actual = Kata.Switcher(x);
            
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
