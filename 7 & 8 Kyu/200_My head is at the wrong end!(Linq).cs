/*Challenge link:https://www.codewars.com/kata/56f699cd9400f5b7d8000b55/train/csharp
Question:
You're at the zoo... all the meerkats look weird. Something has gone terribly wrong - someone has gone and switched their heads and tails around!

Save the animals by switching them back. You will be given an array which will have three values (tail, body, head). It is your job to re-arrange the array so that the animal is the right way round (head, body, tail).

Same goes for all the other arrays/lists that you will get in the tests: you have to change the element positions with the same exact logics

Simples!


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;
public class Kata{  //not sure what the kata is asking , but it works. :^)
  public static string[] FixTheMeerkat(string[] a) => a.Reverse().ToArray();
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Random rnd = new Random();
    
    [Test]
    public void SampleTest()
    {
      Action[] tests = new Action[]
      {
        delegate { Assert.AreEqual(new string[] {"head", "body", "tail"}, Kata.FixTheMeerkat(new string[] {"tail", "body", "head"})); },
        delegate { Assert.AreEqual(new string[] {"heads", "body", "tails"}, Kata.FixTheMeerkat(new string[] {"tails", "body", "heads"})); },
        delegate { Assert.AreEqual(new string[] {"top", "middle", "bottom"}, Kata.FixTheMeerkat(new string[] {"bottom", "middle", "top"})); },
        delegate { Assert.AreEqual(new string[] {"upper legs", "torso", "lower legs"}, Kata.FixTheMeerkat(new string[] {"lower legs", "torso", "upper legs"})); },
        delegate { Assert.AreEqual(new string[] {"ground", "rainbow", "sky"}, Kata.FixTheMeerkat(new string[] {"sky", "rainbow", "ground"})); },
      };
      tests.OrderBy(x => rnd.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    [Test]
    public void RandomTest()
    {
      string[] words = {"Kenshiro","Raoh","Kaiou","Toki","Hyo","Jagi","Han","Souther","Falco","Rei","Shoki","Juda","Taiga","Shin","Boltz","Shin","Soria"};
      for (int i = 0; i < 100; ++i)
      {
        int idx = rnd.Next(0, words.Length - 2);
        string[] test = {words[idx], words[idx+1], words[idx+2]};
        string[] expected = test.Reverse().ToArray();
        string[] actual = Kata.FixTheMeerkat(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
