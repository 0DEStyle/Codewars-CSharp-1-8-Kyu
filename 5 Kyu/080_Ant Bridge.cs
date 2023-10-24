/*Challenge link:https://www.codewars.com/kata/599385ae6ca73b71b8000038/train/csharp
Question:
Background
My pet bridge-maker ants are marching across a terrain from left to right.

If they encounter a gap, the first one stops and then next one climbs over him, then the next, and the next, until a bridge is formed across the gap.

What clever little things they are!

Now all the other ants can walk over the ant-bridge.

When the last ant is across, the ant-bridge dismantles itself similar to how it was constructed.

This process repeats as many times as necessary (there may be more than one gap to cross) until all the ants reach the right hand side.

Kata Task
My little ants are marching across the terrain from left-to-right in the order A then B then C...

What order do they exit on the right hand side?

Notes
- = solid ground
. = a gap
The number of ants may differ but there are always enough ants to bridge the gaps
The terrain never starts or ends with a gap
Ants cannot pass other ants except by going over ant-bridges
If there is ever ambiguity which ant should move, then the ant at the back moves first
Example
Input
ants = GFEDCBA
terrain = ------------...-----------
Output
result = EDCBAGF
Details
Ants moving left to right.	
GFEDCBA
------------...-----------
The first one arrives at a gap.	
GFEDCB     A
------------...-----------
They start to bridge over the gap...	
GFED       ABC
------------...-----------
...until the ant-bridge is completed!	
GF         ABCDE
------------...-----------
And then the remaining ants can walk across the bridge.	
               F
G          ABCDE
------------...-----------
And when no more ants need to cross...	
           ABCDE        GF
------------...-----------
... the bridge dismantles itself one ant at a time....	
                
             CDE      BAGF
------------...-----------
...until all ants get to the other side	
                
                   EDCBAGF
------------...-----------
*/

//***************Solution********************
using System.Linq;

public class Dinglemouse{
    public static string AntBridge(string ants, string terrain){
      //find starting and ending of gap, replace "-." and ".-" with ".." for process
        var terrainWithAnchors = terrain.Replace("-.", "..").Replace(".-", "..");
      //get length of bridge by counting '.'
        var lengthOfAllBridges = terrainWithAnchors.Count(c => c == '.');
      //get remainder of ants
        var indexOfLastAntToExit = ants.Length - lengthOfAllBridges % ants.Length;
      //remaining ant + the ants that crossed the bridge.
        return ants.Substring(indexOfLastAntToExit) + ants.Substring(0, indexOfLastAntToExit);
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Linq;
using System.Text.RegularExpressions;
public class SolutionTests
{
    /**
     * Reference implementation used for the random test cases
     */
    private static class Solution
    {
        private static Regex PATTERN = new Regex("(?<free>-+)(?<gap>\\.+)", RegexOptions.Compiled);

        public static string AntBridge(string ants, string terrain)
        {
            int nAnts = ants.Length, nGaps = 0;
            var s = ants;
            // add "-" at the beginning of "terrain" because a first isolated '-' character at the beginning of the string must not be considered as a pivot (which are found with the exact match of "-")
            var matches = PATTERN.Matches($"-{terrain}");
            foreach (Match match in matches)
            {
                // number of ants needed for the brigde ; if thefree part before is "-", need to move one less ant because the ant there, being stuck because of the previous bridge is already part of the current bridge!
                nGaps = match.Groups["gap"].Length + 2 - (match.Groups["free"].Length == 1 ? 1 : 0);
                // THE TRICK: take nGap ants from the end of string "ants" and put them at the beginnning, WITHOUT returnning the string because they will retrieve this order after leaving the bridge
                s = s.Substring(nAnts - nGaps) + s.Substring(0, nAnts - nGaps);
            }
            return s;
        }
    }
    private Random random = new Random();
    private string MakeRandomAnts()
    {
        var ants = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, random.Next(3, 13));
        return string.Concat(ants.Reverse());
    }

    private static string SOLID = "------------------------------";
    private static string GAP = "..............................";
    private string MakeRandomTerrain(int nants)
    {
        var s = SOLID.Substring(0, random.Next(1, 7));
        var gaps = random.Next(6); // 0-5 gaps
        while (gaps-- > 0)
        {
            var x = s.Length;
            s += GAP.Substring(0, 1 + random.Next(nants - 2));
            x = s.Length - x;
            if (x > nants - 2) throw new ArgumentException("gap too big!");
            s += SOLID.Substring(0, random.Next(1, 7));
        }
        return s;
    }

    // ====================================================

    [Test]
    public void Example()
    {
        Assert.AreEqual("EDCBAGF", Dinglemouse.AntBridge("GFEDCBA", "------------...-----------"));
    }

    [Test]
    public void NoGaps()
    {
        Assert.AreEqual("GFEDCBA", Dinglemouse.AntBridge("GFEDCBA", "-----------------------"));
    }

    [Test]
    public void BigGap()
    {
        Assert.AreEqual("GFEDCBA", Dinglemouse.AntBridge("GFEDCBA", "------------.....---------"));
    }

    [Test]
    public void BigGaps()
    {
        Assert.AreEqual("GFEDCBA", Dinglemouse.AntBridge("GFEDCBA", "------.....------.....---------"));
    }

    [Test]
    public void Hard()
    {
        Assert.AreEqual("AGFEDCB", Dinglemouse.AntBridge("GFEDCBA", "------....-.---"));
        Assert.AreEqual("EDCBA", Dinglemouse.AntBridge("EDCBA", "--..---...-..-...----..-----"));
        Assert.AreEqual("GFEDCBAJIH", Dinglemouse.AntBridge("JIHGFEDCBA", "--........------.-........-........---....-----"));
        Assert.AreEqual("CBAJIHGFED", Dinglemouse.AntBridge("JIHGFEDCBA", "-.....------........-.......-.......----"));
        Assert.AreEqual("GFEDCBAJIH", Dinglemouse.AntBridge("JIHGFEDCBA", "-------.......-.......-"));
        Assert.AreEqual("EDCBAJIHGF", Dinglemouse.AntBridge("JIHGFEDCBA", "-------.......-.......-.......-"));
    }

    [Test]
    public void TwoGaps()
    {
        Assert.AreEqual("BAGFEDC", Dinglemouse.AntBridge("GFEDCBA", "------------...-----..----"));
    }

    [Test]
    public void SmallGaps()
    {
        Assert.AreEqual("CBA", Dinglemouse.AntBridge("CBA", "--.--.---"));
    }

    [Test]
    public void ManyGaps()
    {
        Assert.AreEqual("GFEDCBA", Dinglemouse.AntBridge("GFEDCBA", "-.-.-.-"));
    }

    [Test]
    public void Random()
    {
        for (int r = 0; r < 100; r++)
        {
            var rant = MakeRandomAnts();
            var rland = MakeRandomTerrain(rant.Length);
            var expected = Solution.AntBridge(rant, rland);
            var actual = Dinglemouse.AntBridge(rant, rland);
            Console.WriteLine($"Random test #{r + 1} : In={rant} {rland} Out={expected}");
            Assert.AreEqual(expected, actual);
        }
    }
}
