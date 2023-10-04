/*Challenge link:https://www.codewars.com/kata/58ff1c8b13b001a5a50005b4/train/csharp
Question:
Consider the following class:

  public class Animal
  {
    public string Name { get; set; }
    public int NumberOfLegs { get; set; }
  }
Write a method that accepts a list of objects of type Animal, and returns a new list. The new list should be a copy of the original list, sorted first by the animal's number of legs, and then by its name.

If null is passed, the method should return null. If an empty list is passed, it should return an empty list back. 
*/

//***************Solution********************
using System.Collections.Generic;
using System.Linq;

namespace Kata{
    public class Animal{
        public string Name { get; set; }
        public int NumberOfLegs { get; set; }
    }
  
  //check if input is null
  //if not, order by name
  //then order by number of legs, convert to list and return the result.
  //finally simiplfied into one line by using an Lambda expression with Enumerable methods.
    public class AnimalSorter{
        public List<Animal> Sort(List<Animal> input) => input?
                                                        .OrderBy(i => i.Name)
                                                        .OrderBy(i => i.NumberOfLegs)
                                                        .ToList();
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System.Collections.Generic;

namespace Kata
{
  [TestFixture]
  public class AnimalSorterTests
  {
    [Test]
    public void SortTest()
    {
      var animals = new List<Animal>
      {
        new Animal {Name = "Cat", NumberOfLegs = 4},
        new Animal {Name = "Snake", NumberOfLegs = 0},
        new Animal {Name = "Dog", NumberOfLegs = 4},
        new Animal {Name = "Pig", NumberOfLegs = 4},
        new Animal {Name = "Human", NumberOfLegs = 2},
        new Animal {Name = "Bird", NumberOfLegs = 2}
      };
      var output = new AnimalSorter().Sort(animals);
      Assert.AreEqual(output[0].Name, "Snake");
      Assert.AreEqual(output[3].Name, "Cat");
    }

    [Test]
    public void NullInputTest()
    {
      var output = new AnimalSorter().Sort(null);
      Assert.IsNull(output);
    }

    [Test]
    public void EmptyListTest()
    {
      var output = new AnimalSorter().Sort(new List<Animal>());
      Assert.AreEqual(0, output.Count);
    }

    [Test]
    public void AdditionalDataTest()
    {
      //This test is just here in case the user tries an "Evil Coder" strategy by hardcoding
      //results to make the previous SortTest pass :)
      var animals = new List<Animal>
      {
        new Animal {Name = "Centipede", NumberOfLegs = 100},
        new Animal {Name = "Snail", NumberOfLegs = 0},
        new Animal {Name = "Lizard", NumberOfLegs = 4},
        new Animal {Name = "Dog", NumberOfLegs = 4},
        new Animal {Name = "Human", NumberOfLegs = 2},
        new Animal {Name = "Bird", NumberOfLegs = 2}
      };
      var output = new AnimalSorter().Sort(animals);
      Assert.AreEqual(output[0].Name, "Snail");
      Assert.AreEqual(output[4].Name, "Lizard");
    }
  }
}
