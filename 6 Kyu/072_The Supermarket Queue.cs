/*Challenge link:https://www.codewars.com/kata/57b06f90e298a7b53d000a86/train/csharp
Question:
There is a queue for the self-checkout tills at the supermarket. Your task is write a function to calculate the total time required for all the customers to check out!

input
customers: an array of positive integers representing the queue. Each integer represents a customer, and its value is the amount of time they require to check out.
n: a positive integer, the number of checkout tills.
output
The function should return an integer, the total time required.

Important
Please look at the examples and clarifications below, to ensure you understand the task correctly :)

Examples
queueTime([5,3,4], 1)
// should return 12
// because when there is 1 till, the total time is just the sum of the times

queueTime([10,2,3,3], 2)
// should return 10
// because here n=2 and the 2nd, 3rd, and 4th people in the 
// queue finish before the 1st person has finished.

queueTime([2,3,10], 2)
// should return 12
Clarifications
There is only ONE queue serving many tills, and
The order of the queue NEVER changes, and
The front person in the queue (i.e. the first element in the array/list) proceeds to a till as soon as it becomes free.
N.B. You should assume that all the test input will be valid, as specified above.

P.S. The situation in this kata can be likened to the more-computer-science-related idea of a thread pool, with relation to running multiple processes at the same time: https://en.wikipedia.org/wiki/Thread_pool
*/

//***************Solution********************


//aggregate customers, a is current element, i is index
//from array a, start from a , count up to a.mina add i into index, then return a
//select and return max from array.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
using System;

public class Kata{
    public static long QueueTime(int[] customers, int n) =>
      customers.Aggregate(new int[n], (a, i) => {
          a[Array.IndexOf(a, a.Min())] += i;
          return a;
        }).Max();
}

//****************Sample Test*****************
namespace Solution
{
    using NUnit.Framework;
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    [TestFixture]
    public class Tests
    {
        [Test]
        public void ExampleTest1()
        {
            long expected = 0;
            
            long actual = Kata.QueueTime(new int[] { }, 1);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExampleTest2()
        {
            long expected = 10;
            
            long actual = Kata.QueueTime(new int[] { 1, 2, 3, 4 }, 1);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExampleTest3()
        {
            long expected = 9;
            
            long actual = Kata.QueueTime(new int[] { 2, 2, 3, 3, 4, 4 }, 2);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExampleTest4()
        {
            long expected = 5;
            
            long actual = Kata.QueueTime(new int[] { 1, 2, 3, 4, 5 }, 100);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtendedTest1()
        {
            long expected = 5;
            
            long actual = Kata.QueueTime(new int[] { 5 }, 1);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtendedTest2()
        {
            long expected = 2;
            
            long actual = Kata.QueueTime(new int[] { 2 }, 5);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void ExtendedTest3()
        {
            long expected = 15;
            
            long actual = Kata.QueueTime(new int[] { 1, 2, 3, 4, 5 }, 1);
        
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void RandomTests()
        {
            Random rand = new Random();
            
            Func<int[], int, long> Solution = (customers, n) =>
            {
                if (!customers.Any())
                {
                    return 0;
                }
        
                Queue<int> customerTimes = new Queue<int>(customers);
                List<long> tills = new List<long>(n);
                tills.AddRange(Enumerable.Repeat(0, n).Select(i => (long)i));
        
                while (customerTimes.Count > 0)
                {
                    tills[tills.IndexOf(tills.Min())] += customerTimes.Dequeue();
                }
        
                return tills.Max();
            };
            
            for(int i = 0; i < 100; i++)
            {
                int length = rand.Next(0, 150);
            
                var customers = Enumerable.Range(0, length).Select(e => rand.Next(1, 21)).ToArray();
                
                int tillCount = rand.Next(1, 11);
                
                long expected = Solution(customers, tillCount);
                
                long actual = Kata.QueueTime(customers, tillCount);
                
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
