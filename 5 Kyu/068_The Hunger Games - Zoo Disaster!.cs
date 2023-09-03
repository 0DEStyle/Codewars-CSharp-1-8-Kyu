/*Challenge link:https://www.codewars.com/kata/5902bc7aba39542b4a00003d/train/csharp
Question:
Story
A freak power outage at the zoo has caused all of the electric cage doors to malfunction and swing open...

All the animals are out and some of them are eating each other!

It's a Zoo Disaster!
Here is a list of zoo animals, and what they can eat

antelope eats grass
big-fish eats little-fish
bug eats leaves
bear eats big-fish
bear eats bug
bear eats chicken
bear eats cow
bear eats leaves
bear eats sheep
chicken eats bug
cow eats grass
fox eats chicken
fox eats sheep
giraffe eats leaves
lion eats antelope
lion eats cow
panda eats leaves
sheep eats grass
Kata Task
INPUT
A comma-separated string representing all the things at the zoo

TASK
Figure out who eats whom until no more eating is possible.

OUTPUT
A list of strings (refer to the example below) where:

The first element is the initial zoo (same as INPUT)
The last element is a comma-separated string of what the zoo looks like when all the eating has finished
All other elements (2nd to last-1) are of the form X eats Y describing what happened
Notes
Animals can only eat things beside them

Animals always eat to their LEFT before eating to their RIGHT

Always the LEFTMOST animal capable of eating will eat before any others

Any other things you may find at the zoo (which are not listed above) do not eat anything and are not edible

Example
Input

"fox,bug,chicken,grass,sheep"

Working

1	fox can't eat bug	
"fox,bug,chicken,grass,sheep"
2	bug can't eat anything	
"fox,bug,chicken,grass,sheep"
3	chicken eats bug	
"fox,chicken,grass,sheep"
4	fox eats chicken	
"fox,grass,sheep"
5	fox can't eat grass	
"fox,grass,sheep"
6	grass can't eat anything	
"fox,grass,sheep"
7	sheep eats grass	
"fox,sheep"
8	fox eats sheep	
"fox"
Output

["fox,bug,chicken,grass,sheep", "chicken eats bug", "fox eats chicken", "sheep eats grass", "fox eats sheep", "fox"]


*/

//***************Solution********************
using System;
using System.Linq;
using System.Collections.Generic;

public class Dinglemouse {
  //create fixed dictionary, <string, HashSet<string>>
    private static Dictionary<string, HashSet<string>> whoWhatEat = new Dictionary<string, HashSet<string>>(){
        ["antelope"   ] = new HashSet<string>(){"grass"},
        ["big-fish"   ] = new HashSet<string>(){"little-fish"},
        ["bug"        ] = new HashSet<string>(){"leaves"},
        ["bear"       ] = new HashSet<string>(){"big-fish", "chicken", "cow", "leaves", "bug", "sheep"},
        ["chicken"    ] = new HashSet<string>(){"bug"},
        ["cow"        ] = new HashSet<string>(){"grass"},
        ["fox"        ] = new HashSet<string>(){"chicken", "sheep"},
        ["giraffe"    ] = new HashSet<string>(){"leaves"},
        ["lion"       ] = new HashSet<string>(){"antelope", "cow"},
        ["panda"      ] = new HashSet<string>(){"leaves"},
        ["sheep"      ] = new HashSet<string>(){"grass"}
    };
    
    
    public static string[] WhoEatsWho(string zoo){
      //split input by "," and store in zooList
        List<string> zooList = zoo.Split(',').ToList();
        List<string> result = new List<string>();
        
        result.Add(zoo);
        
      //iterate through the zooList
        for(int i = 0; i < zooList.Count; i++){
            for(int d = -1; d < 2; d += 2){
              //break the loop if dictionary does not contain current animal.
               if(!whoWhatEat.ContainsKey(zooList[i]))
                  break;
              
              //check if index + d is -1 or index + d is equal to zooList.Count
              //if so set index to i, else i + d
               int index = (i+d) == -1 || (i+d) == zooList.Count ? i : (i+d);
               
              //if dictionary of current animal contain hashSet(whatever food they eat at index)
              //add string to result, then remove the animal from zooList
               if(whoWhatEat[zooList[i]].Contains(zooList[index])){
                   result.Add($"{zooList[i]} eats {zooList[index]}");
                   zooList.RemoveAt(index);
                   
              //if index is less than i, and if i is equal to 1, subtract 2 from i, else subtract 3 from i, 
              //and final else subtract 1 from i
              //break the loop to prevent out of range
                   i -= index < i ? (i == 1 ? 2 : 3) : 1;
                   break;
               }
            }
        }
        //if zoo is not empty, join result with ","
        if(zoo != string.Empty)
            result.Add(string.Join(',', zooList));
        
        return result.ToArray();
    }
    
}
//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture]
  public class SolutionTest
  {
    private static Dictionary<string, string[]> zooItems = new Dictionary<string, string[]> {
        ["antelope"] = new string[] { "grass" },
        ["big-fish"] = new string[] { "little-fish" },
        ["bug"] = new string[] { "leaves" },
        ["bear"] = new string[] { "big-fish", "bug", "chicken", "cow", "leaves", "sheep" },
        ["chicken"] = new string[] { "bug" },
        ["cow"] = new string[] { "grass" },
        ["fox"] = new string[] { "chicken", "sheep" },
        ["giraffe"] = new string[] { "leaves" },
        ["lion"] = new string[] { "antelope", "cow" },
        ["panda"] = new string[] { "leaves" },
        ["sheep"] = new string[] { "grass" }
    };

    private static string[] Solution(string zoo)
    {
        List<string> eatingOrder = new List<string>() { zoo };
        List<string> zooList = zoo.Split(',').ToList();
        
        for (int i = 0; i < zooList.Count(); i++)
        {
            string key = zooList[i];
            if (!zooItems.ContainsKey(key)) continue;
            
            if (i != 0 && zooItems[key].Contains(zooList[i - 1]))
            {
                Console.WriteLine($"\t{key} eats {zooList[i - 1]}");
                
                eatingOrder.Add($"{key} eats {zooList[i - 1]}");
                zooList.RemoveAt(i - 1);
                i = -1;
            }
            else if (i != (zooList.Count() - 1) && zooItems[key].Contains(zooList[i + 1]))
            {
                Console.WriteLine($"\t{key} eats {zooList[i + 1]}");
                
                eatingOrder.Add($"{key} eats {zooList[i + 1]}");
                zooList.RemoveAt(i + 1);
                i = -1;
            }
        }
        
        Console.WriteLine($"\t{string.Join(",", zooList)}");
        
        if (!string.IsNullOrEmpty(zoo)) eatingOrder.Add(string.Join(",", zooList));
        
        return eatingOrder.ToArray();
    }
    
    [Test]
    public void Example()
    {
        string input = "fox,bug,chicken,grass,sheep";
        string[] expected = {
          "fox,bug,chicken,grass,sheep", 
          "chicken eats bug", 
          "fox eats chicken", 
          "sheep eats grass", 
          "fox eats sheep", 
          "fox"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EatLeftSingle()
    {
        string input = "chicken,fox,leaves,bug,grass,sheep";
        string[] expected = {
          "chicken,fox,leaves,bug,grass,sheep", 
          "fox eats chicken", 
          "bug eats leaves", 
          "sheep eats grass", 
          "fox,bug,sheep"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EatRightSingle()
    {
        string input = "bear,big-fish,lion,cow,bug,leaves";
        string[] expected = {
          "bear,big-fish,lion,cow,bug,leaves", 
          "bear eats big-fish", 
          "lion eats cow", 
          "bug eats leaves", 
          "bear,lion,bug"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EatLeftMulti()
    {
        string input = "grass,grass,cow,leaves,bug,big-fish,leaves,bear";
        string[] expected = {
          "grass,grass,cow,leaves,bug,big-fish,leaves,bear", 
          "cow eats grass",
          "cow eats grass",
          "bug eats leaves", 
          "bear eats leaves", 
          "bear eats big-fish", 
          "bear eats bug",
          "bear eats cow", 
          "bear"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EatRightMulti()
    {
        string input = "giraffe,leaves,leaves,leaves,bear,bug,leaves,leaves,panda";
        string[] expected = {
          "giraffe,leaves,leaves,leaves,bear,bug,leaves,leaves,panda", 
          "giraffe eats leaves",
          "giraffe eats leaves",
          "giraffe eats leaves",
          "bear eats bug", 
          "bear eats leaves", 
          "bear eats leaves", 
          "giraffe,bear,panda"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EatLeftAndRightMulti()
    {
        string input = "bear,grass,grass,grass,grass,sheep,bug,chicken,little-fish,little-fish,little-fish,little-fish,big-fish,big-fish,big-fish";
        string[] expected = {
          "bear,grass,grass,grass,grass,sheep,bug,chicken,little-fish,little-fish,little-fish,little-fish,big-fish,big-fish,big-fish", 
          "sheep eats grass",
          "sheep eats grass",
          "sheep eats grass",
          "sheep eats grass",
          "bear eats sheep",
          "bear eats bug",
          "bear eats chicken",
          "big-fish eats little-fish",
          "big-fish eats little-fish",
          "big-fish eats little-fish",
          "big-fish eats little-fish",
          "bear eats big-fish",
          "bear eats big-fish",
          "bear eats big-fish",
          "bear"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void NobodyEatsAnything()
    {
        string input = "fox,grass,chicken,lion,panda";
        string[] expected = {
          "fox,grass,chicken,lion,panda", 
          "fox,grass,chicken,lion,panda"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void EmpytyZoo()
    {
        string input = "";
        string[] expected = {
          ""
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void SingleKnownThing()
    {
        string input = "bug";
        string[] expected = {
          "bug", 
          "bug"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void SingleUnknownThing()
    {
        string input = "wtf";
        string[] expected = {
          "wtf",
          "wtf"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void KnownAndUnknownThings()
    {
        string input = "fox,chicken,tree,chicken,bug,banana,bug,bear";
        string[] expected = {
          "fox,chicken,tree,chicken,bug,banana,bug,bear", 
          "fox eats chicken",
          "chicken eats bug",
          "bear eats bug",
          "fox,tree,chicken,banana,bear"
        };
        
        Assert.AreEqual(expected, Dinglemouse.WhoEatsWho(input));
    }
    
    [Test]
    public void Random()
    {
      Random random = new Random();
      
      for (int i = 0; i < 500; i++)
      {
        string[] things = new string[] { "busker", "banana", "bicycle", "antelope", "big-fish", "bug", "bear", "chicken", "cow", "fox", "giraffe", "grass", "leaves", "lion", "little-fish", "panda", "sheep" };
        string input = string.Join(",", Enumerable.Range(0, random.Next(16)).Select(x => things[random.Next(things.Length)]));
        
        Console.WriteLine($"Random Test {i+1}: ZOO = {input}");
        
        string[] expected = Solution(input);
        string[] actual = Dinglemouse.WhoEatsWho(input);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
