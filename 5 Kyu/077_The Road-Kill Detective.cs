/*Challenge link:https://www.codewars.com/kata/58e18c5434a3022d270000f2/train/csharp
Question:
My name is State Trooper Mark ("skidmark" ) McDingle.

My job is maintaining 117 miles of the Interstate, keeping it clean and clear of dead varmints.

It is a serious job and I take my job seriously.

I am the Road-Kill Detective



Every time I find some dead critter I scrape it up and record what type it was in my dead-critter notebook.

Mostly I just cruise up and down the interstate and only find a few racoons or the occasional squirrel...

But recently the road-kill has become much more exotic.

There must be some illegal private zoo back in the woods with a major security problem.

But that's none of my business... Anything beyond the fog-line is out of my jurisdiction.

Evidence
Here are some photos of what I came across last week:

There was a thing that looked like a hyena ==========h===yyyyyy===eeee=n==a========

a long black and white smudge that probably once was a penguin ======pe====nnnnnn=======================n=n=ng====u==iiii=iii==nn========================n=

and an unlucky bear that was hit going the other direction =====r=rrr=rra=====eee======bb====b=======

Kata Task
Even for a professional like me, the identification of flattened exotic animals is not always easy!

If it ever happens that I can't find all of the remains, or if there are gaps or other parts that I don't recognise, then I record it as ?? in my dead-critter notebook.

What I really need is a program that I can scan my photos into which can give back the correct answer straight away.

Something like this:

Input
photo (not null)
Output
the detected animal name, or ?? if unknown^
^ Note: An array/list of all "known" animals is preloaded in a variable called ANIMALS (refer to the initial solution)
*/

//***************Solution********************

// simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Linq;
public class Dinglemouse{
  
  //preload the array/list animals, a is the current element.
  //from photo except(a), get last or default, check if it is equal to '=' 
  
  //reverse a, concat the element to string, create new array [a, whateverString]
  
  //arr,a,i are the current elements, c is the next elment
  //get first or default, from arr find any match of...
  //aggregate a, if current element i is less than 0, return -1, else return photo.IndexOf (c, i+1)
  //then check if aggregate result is greater than 0
  
  //ref: https://jeremybytes.blogspot.com/2022/07/null-conditional-operators-in-c-and.html
  //?[0] Null Conditional Operator, 
  //If result is null, the indexer is not accessed, and so we do not get a null reference exception here. 
  //The result variable would then be assigned "null".
  
  //?? Null Coalescing Operators: When we have a null value, we often want to replace it with a non-null default value to "??".
    public static string RoadKill(string photo) =>
      Preloaded.ANIMALS.Where(a => photo.Except(a).LastOrDefault() == '=')
      .Select(a => new []{ a, string.Concat(a.Reverse()) })
      .FirstOrDefault(arr => arr.Any(a => a.Aggregate(0, (i,c) => i < 0 ? -1 : photo.IndexOf(c, i+1)) > 0 ))
      ?[0] ?? "??";
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Linq;
public class SolutionTests
{
    [Test]
    public void TestEx()
    {
        Assert.AreEqual("hyena", Dinglemouse.RoadKill("==========h===yyyyyy===eeee=n==a========"));
        Assert.AreEqual("penguin", Dinglemouse.RoadKill("======pe====nnnnnn=======================n=n=ng====u==iiii=iii==nn========================n="));
        Assert.AreEqual("bear", Dinglemouse.RoadKill("=====r=rrr=rra=====eee======bb====b======="));
    }

    [Test]
    public void TestEasyKnown()
    {
        Assert.AreEqual("snake", Dinglemouse.RoadKill("===snake======"));
        Assert.AreEqual("snake", Dinglemouse.RoadKill("===sssssssssssssssssssnakeeeeeeeeeeeeeeeeeeeeeee======="));
        Assert.AreEqual("snake", Dinglemouse.RoadKill("==ekans=="));
    }

    [Test]
    public void TestEasyUnknown()
    {
        Assert.AreEqual("??", Dinglemouse.RoadKill("===h=====i=tch======h=====i=kkkkkkk=eeeeee====rr=r=r=r=rrr===================="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("==w===t===f============="));
    }

    [Test]
    public void TestTrickyKnown()
    {
        Assert.AreEqual("baboon", Dinglemouse.RoadKill("===b=b==========a=a=a=a=a=a=a=boo======n====="));
        Assert.AreEqual("squirrel", Dinglemouse.RoadKill("====l===e===r=======riuqs====="));
        Assert.AreEqual("aardvark", Dinglemouse.RoadKill("=====k====r=a=vvvv==d=d=d=d=r==a=a======="));
        Assert.AreEqual("rabbit", Dinglemouse.RoadKill("====rraabbiitt=="));
    }

    [Test]
    public void TestTrickyUnknown()
    {
        Assert.AreEqual("??", Dinglemouse.RoadKill("=============="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("===       ===snake========="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("      "));
        Assert.AreEqual("??", Dinglemouse.RoadKill(""));
        Assert.AreEqual("??", Dinglemouse.RoadKill("==a======a=a=a=lig===a=t====o=r=r=r=r=="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("===f====o===x===y====="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("====Snake==="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("=======fly===dragon===="));
        Assert.AreEqual("??", Dinglemouse.RoadKill("=========.*=\\d\\d\\..//[)44567$$$+..)===="));
    }
    private Random random = new Random();
    private string MakeSkidmarks(string animal)
    {
        var skid = "";
        foreach (var c in animal)
        {
            // repeat animal part a random number of times
            for (int i = 0; i < random.Next(1, 6); i++)
            {
                for (int j = 0; j < random.Next(4); j++)
                    skid += "="; // repeat tyre tread a random amount
                skid += c;
            }
        }
        return "=====" + skid + "=====";
    }

    [Test]
    public void TestRandom()
    {
        for (int r = 0; r < 100; r++)
        {
            var animalOrig = Preloaded.ANIMALS[random.Next(Preloaded.ANIMALS.Length)];

            // Forwards or backwards
            var animal = random.NextDouble() < 0.5
              ? string.Concat(animalOrig.Reverse()) // backwards
              : animalOrig; // forwards

            var skid = MakeSkidmarks(animal);
            var expected = animalOrig;
            // Sometimes throw in some random part to make it an unknown animal
            if (random.NextDouble() < 0.2)
            {
                skid += "===X===";
                expected = "??";
            }
            Assert.AreEqual(expected, Dinglemouse.RoadKill(skid));
        }
    }
}
