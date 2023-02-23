/*Challenge link:https://www.codewars.com/kata/57ee4a67108d3fd9eb0000e7/train/csharp

Question:
Write a function that takes a list of strings as an argument and returns a filtered list containing the same elements but with the 'geese' removed.

The geese are any strings in the following array, which is pre-populated in your solution:

  ["African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher"]
For example, if this array were passed as an argument:

 ["Mallard", "Hook Bill", "African", "Crested", "Pilgrim", "Toulouse", "Blue Swedish"]
Your function would return the following array:

["Mallard", "Hook Bill", "Crested", "Blue Swedish"]
The elements in the returned array should be in the same order as in the initial array passed to your function, albeit with the 'geese' removed. Note that all of the strings will be in the same case as those provided, and some elements may be repeated.
*/

//***************Solution********************

//check if elements in birds, where elements is does not contains inside gesse.
using System.Collections.Generic;
using System.Linq;
public static class Filter{
  public static IEnumerable<string> GooseFilter(IEnumerable<string> birds){
    string[] geese = new string[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };

    return birds.Where(x => !geese.Contains(x));
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static IEnumerable<string> TestFilter(IEnumerable<string> birds)
    {
      var geese = new[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };

      return birds.Except(geese);
    }
    
    private static Random Rng = new Random(DateTime.UtcNow.Millisecond);
    
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual(new string[] {"Mallard", "Hook Bill", "Crested", "Blue Swedish"},
          Filter.GooseFilter(new string[] {"Mallard", "Hook Bill", "African", "Crested", "Pilgrim", "Toulouse", "Blue Swedish"}));
          
      Assert.AreEqual(new string[] {"Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested"},
          Filter.GooseFilter(new string[] {"Mallard", "Barbary", "Hook Bill", "Blue Swedish", "Crested"}));
          
      Assert.AreEqual(new string[] {},
          Filter.GooseFilter(new string[] {"African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher"}));
    }

    [Test, Repeat(100)]
    public void RandomTests()
    {
      var numberOfRandomWords = Rng.Next(0, 20);
      var geese = new[] { "African", "Roman Tufted", "Toulouse", "Pilgrim", "Steinbacher" };
      var words = Enumerable.Range(1, numberOfRandomWords).Select(i =>
      {
          if (i%Rng.Next(1, 5) == 0) return geese.ElementAt(Rng.Next(0, geese.Length));
          return Guid.NewGuid().ToString("N");
      }).ToList();

      Assert.AreEqual(TestFilter(words), Filter.GooseFilter(words));
    }
  }
}
