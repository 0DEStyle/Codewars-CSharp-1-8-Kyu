/*Challenge link:https://www.codewars.com/kata/574c5075d27783851800169e/train/csharp
Question:
#Description

Everybody has probably heard of the animal heads and legs problem from the earlier years at school. It goes:

“A farm contains chickens and cows. There are x heads and y legs. How many chickens and cows are there?” 

Where x <= 1000 and y <=1000

#Task

Assuming there are no other types of animals, work out how many of each animal are there.

Return a tuple in Python - (chickens, cows) and an array list - [chickens, cows]/{chickens, cows} in all other languages

If either the heads & legs is negative, the result of your calculation is negative or the calculation is a float return "No solutions" (no valid cases), or [-1, -1] in COBOL.

In the form:

(Heads, Legs) = (72, 200)

VALID - (72, 200) =>             (44 , 28) 
                             (Chickens, Cows)

INVALID - (72, 201) => "No solutions"
However, if 0 heads and 0 legs are given always return [0, 0] since zero heads must give zero animals.

There are many different ways to solve this, but they all give the same answer.

You will only be given integers types - however negative values (edge cases) will be given.

Happy coding!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

//find number of cows, then subtract total heads to number of cows to find number of chickens
//check validation, if nothing match return "No solutions", else return in format {chickens, cows}
public class Kata{
  public static object Animals(int heads, int legs){
    var cows = legs / 2 - heads;
    var chickens = heads - cows;
    
    return chickens < 0 || cows < 0 || legs % 2 != 0 ? 
      "No solutions" :
      new[]{chickens, cows};
  }
}


//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;

  [TestFixture]
  public class KataTests
  {
    [Test]
    public void ValidNumberTests()
    {
      Assert.AreEqual(new int[] { 44, 28 }, Kata.Animals(72, 200));
      Assert.AreEqual(new int[] { 91, 25 }, Kata.Animals(116, 282));
      Assert.AreEqual(new int[] { 12, 0 }, Kata.Animals(12, 24));
      Assert.AreEqual(new int[] { 0, 6 }, Kata.Animals(6, 24));      
      Assert.AreEqual(new int[] { 252, 92 }, Kata.Animals(344, 872));
      Assert.AreEqual(new int[] { 8, 150 }, Kata.Animals(158, 616));
    }
    
    [Test]
    public void InvalidNumberTests()
    {
      Assert.AreEqual("No solutions", Kata.Animals(25, 255));
      Assert.AreEqual("No solutions", Kata.Animals(12, 25));
      Assert.AreEqual("No solutions", Kata.Animals(54, 956));
      Assert.AreEqual("No solutions", Kata.Animals(5455, 54956));
    }
    
    [Test]
    public void EdgeCasesTests()
    {
      Assert.AreEqual(new int[] { 0, 0 }, Kata.Animals(0, 0));
      Assert.AreEqual("No solutions", Kata.Animals(-1, -1));
      Assert.AreEqual("No solutions", Kata.Animals(-45, 5));
      Assert.AreEqual("No solutions", Kata.Animals(500, 0));
      Assert.AreEqual("No solutions", Kata.Animals(0, 500));
      Assert.AreEqual("No solutions", Kata.Animals(5, -55));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<int, int, object> myAnimals = delegate (int heads, int legs)
      {
        if((heads < 0)||(legs < 0)||(legs % 2 != 0))
        {
          return "No solutions";
        }
  
        var cows = legs/2 - heads;
        var chickens = heads - cows;
  
        if(cows < 0 || chickens < 0)
        {
          return "No solutions";
        }
  
        return new int[] { chickens, cows };
      };
      
      for (var x=0;x<15;x++)
      {
        var i = rand.Next(0,1001); 
        var j = rand.Next(0,1001); 
        Assert.AreEqual(myAnimals(i, j), Kata.Animals(i, j), "It should work for random inputs too");
      }
      
      var s = 0;
      while(s<40)
      {
        var i = rand.Next(0,1001);
        var j = rand.Next(0,1001);
        if (!(myAnimals(i, j) is string))
        {
          Assert.AreEqual(myAnimals(i, j), Kata.Animals(i, j), "It should work for random inputs too");
          s += 1;
        }
      }
        
      s = 0;
      while (s!= 15)
      {
        var i = rand.Next(0,1001);
        var j = rand.Next(0,1001);
        var sol = myAnimals(i, j);
        if (!(sol is string))
        {
          Assert.AreEqual("No solutions", Kata.Animals(-i, -j), "It should work for random inputs too");
          s += 1;
        }
      }      
    }
  }
}
