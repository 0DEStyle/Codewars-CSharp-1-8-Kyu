/*Challenge link:https://www.codewars.com/kata/5a043724ffe75fbab000009f/train/csharp
Question:
Write a function that takes a list of at least four elements as an argument and returns a list of the middle two or three elements in reverse order.
*/

//***************Solution********************
//skip, total length / 2 - 1
//take, if count mod 2 is 0, take 2, else take 3
//reverse the list, return result
using System.Collections.Generic; 
using System.Linq;

public class Kata{
   public static List<int> ReverseMiddle(List<int> a)  => 
     a.Skip(a.Count() / 2 - 1)
      .Take(a.Count() % 2 == 0 ? 2 : 3)
      .Reverse()
      .ToList();
}


//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic; 
  using System.Linq;

[TestFixture]
public class ReverseMiddleListTests
{
   private static Random rnd = new Random();
  
   [TestCase(new[] { 1, 2, 3, 4 }, new[] { 3, 2 })]
   [TestCase(new[] { 1, 2, 3, 4, 5 }, new[] { 4, 3, 2 })]
   [TestCase(new[] { 1, 2, 3, 4, 5, 6 }, new[] { 4, 3 })]
   [TestCase(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 5, 4, 3 })]
   public void SampleTests(int[] arr, int[] expected) => Assert.That(Kata.ReverseMiddle(arr.ToList()), Is.EqualTo(expected.ToList()));
  
   [Test]
      public void RandomTests()
        {
            var lists = AddRandomLists();
            foreach(var list in lists)
            {
                var actual = Kata.ReverseMiddle(new List<int>(list));
                var expected = list.Skip(list.Count() / 2 - 1).Take(list.Count() % 2 == 0 ? 2 : 3).Reverse().ToList();
                Assert.That(actual, Is.EqualTo(expected), "List => " + String.Join(", ", list.Select(x => x)));
            }
        }
    
        private List<List<int>> AddRandomLists()
        {
            var lists = new List<List<int>>();
            for(int i = 0; i < 100; i++)
            {
                int l = rnd.Next(4, 100);
                var list = new List<int>();
                for(int j = 0; j < l; j++)
                {
                    int n = rnd.Next(-100, 100);
                    list.Add(n);
                }
                lists.Add(list);
            }
            return lists;
        }
}
}
