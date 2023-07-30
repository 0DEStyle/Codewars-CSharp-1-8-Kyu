/*Challenge link:https://www.codewars.com/kata/5a26073ce1ce0e3c01000023/train/csharp
Question:
Story
Well, here I am stuck in another traffic jam.

Damn all those courteous people!

Cars are trying to enter the main road from side-streets somewhere ahead of me and people keep letting them cut in.

Each time somebody is let in the effect ripples back down the road, so pretty soon I am not moving at all.

(Sigh... late again...)

Visually
The diagram below shows lots of cars all attempting to go North.

the a,b,c... cars are on the main road with me (X)
the B cars and C cars are merging from side streets
          |  a  |   
          |  b  | ↑  
  --------+  c  |  
     BBBBBB  d  |   
  --------+  e  |  
          |  f  | ↑
          |  g  |   
  --------+  h  |
      CCCCC  i  |
  --------+  j  | ↑
          |  k  |
          |  l  |
          |  m  |
          |  X  | 
           
This can be represented as

mainRoad = "abcdefghijklmX"
sideStreets = ["","","","BBBBBB","","","","","CCCCC"]
Kata Task
Assume every car on the main road will "give way" to 1 car entering from each side street.

Return a string representing the cars (up to and including me) in the order they exit off the top of the diagram.

Notes
My car is the only X, and I am always on the main road
Other cars may be any alpha-numeric character (except X of course)
There are no "gaps" between cars
Assume side streets are always on the left (as in the diagram)
The sideStreets array length may vary but is never more than the length of the main road
A pre-loaded Util.display(mainRoad,sideStreets) method is provided which may help to visualise the data
(Util.Display for C#)
Example
Here are the first few iterations of my example, showing that I am hardly moving at all...

Initial	Iter 1	Iter 2	Iter 3	Iter 4	Iter 5	Iter 6	Iter 7

(Check the image from the link)

*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

public class Dinglemouse{
    public static string TrafficJam(string mainRoad, string[] sideStreets){
      Util.Display(mainRoad, sideStreets);
      List<char> output = mainRoad.ToList();
      //Console.WriteLine(string.Join(",",sideStreets));
      
      //top row go first, then bottom row go second
      for (int i = sideStreets.Length - 1; i >= 0; --i){
			  for (int j = 0; j < sideStreets[i].Length; ++j){
          
          //info printer
          //Console.WriteLine($"i:{i},j:{j}");
				  int insertIndex = (j * 2) + i + 1;
          
          //add to the end if not jam, else insert
          if (insertIndex > output.Count)
					  output.Add( sideStreets[i][^(j + 1)] );
          else
					  output.Insert( insertIndex, sideStreets[i][^(j + 1)] );
        }
      }
      //Take everything before X.
      return string.Concat(output.Take(output.IndexOf('X') + 1 ));
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Text;
public class SolutionTest
{
    [Test]
    public void Giveway()
    {
        Assert.AreEqual("abcCdCeCECX", Dinglemouse.TrafficJam("abcdeXghi", new[] { "", "", "CCCCC", "", "EEEEEEEEEE", "FFFFFF", "", "", "IIIIII" }));
    }

    [Test]
    public void NoSideStreets()
    {
        Assert.AreEqual("abcdefX", Dinglemouse.TrafficJam("abcdefX", new string[0]));  // I am last in queue
        Assert.AreEqual("abcX", Dinglemouse.TrafficJam("abcXdef", new string[0]));  // I am middle of queue
        Assert.AreEqual("X", Dinglemouse.TrafficJam("Xabcdef", new string[0]));  // I am first in queue
    }

    [Test]
    public void SideStreetsHavingNoEffect()
    {
        Assert.AreEqual("abcX", Dinglemouse.TrafficJam("abcX", new[] { "", "", "", "defg" })); // beside me
        Assert.AreEqual("abcX", Dinglemouse.TrafficJam("abcX", new[] { "", "" })); // empty 
        Assert.AreEqual("abcX", Dinglemouse.TrafficJam("abcX", new string[] { })); // empty 
    }

    [Test]
    public void ManySideStreets()
    {
        Assert.AreEqual("abAcAdABAeABAfABACABAgBCBhBCBiCjkX", Dinglemouse.TrafficJam("abcdefghijkX", new[] { "", "AAAAAAAAAA", "", "BBBBBBBB", "", "CCCC" }));
        Assert.AreEqual("abAcABAdABACABAeABACABfBCBgBChijkX", Dinglemouse.TrafficJam("abcdefghijkX", new[] { "", "AAAAAAAAAA", "BBBBBBBB", "CCCC" }));
        Assert.AreEqual("aAbABAcABACBdBCDCeDEX", Dinglemouse.TrafficJam("abcdeX", new[] { "AAAAA", "BBBB", "CCC", "DD", "E" }));
        Assert.AreEqual("aAbABAcBCBdCDCeDEDfEFEgFGFhGHGiHIHjIJIkJKJlKLKmLMLnMNMoNONpOPOqPQPrQRQsRSRtSTSuTUTvUVUwVWVX", Dinglemouse.TrafficJam("abcdefghijklmnopqrstuvwX", new[] { "AAA", "BBB", "CCC", "DDD", "EEE", "FFF", "GGG", "HHH", "III", "JJJ", "KKK", "LLL", "MMM", "NNN", "OOO", "PPP", "QQQ", "RRR", "SSS", "TTT", "UUU", "VVV", "WWW" }));
    }

    [Test]
    public void CharacterTest()
    {
        // The following are like other tests except all same chars
        Assert.AreEqual("ZZZZZZZZZZZZX", Dinglemouse.TrafficJam("ZZZZZZZZX", new[] { "", "", "", "ZZZZ" }));
        Assert.AreEqual("AAAAAAX", Dinglemouse.TrafficJam("AAAAAAX", new string[0]));
        Assert.AreEqual("000X", Dinglemouse.TrafficJam("000X000", new string[0]));
        Assert.AreEqual("AAAAAAAAAAAAAAAAAAAAAAAAX", Dinglemouse.TrafficJam("AAAAAAAAAAAAAX", new[] { "", "", "", "AAAAAA", "", "", "", "", "AAAAA" }));
        Assert.AreEqual("abcdfeefdgchbiaejdkclbmaX", Dinglemouse.TrafficJam("abcdefghijklmX", new[] { "", "", "", "abcdef", "", "", "", "", "abcde" }));
    }

    [Test]
    public void Example()
    {
        Assert.AreEqual("abcdBeBfBgBhBiBCjCkClCmCX", Dinglemouse.TrafficJam("abcdefghijklmX", new[] { "", "", "", "BBBBBB", "", "", "", "", "CCCCC" }));
    }

    // =============================================

    private static string TrafficJam(string road, string[] sides)
    {
        var X = road.IndexOf("X");
        StringBuilder sb = new StringBuilder(road.Substring(0, X + 1)), tmp = null;

        for (int i = Math.Min(sides.Length, X) - 1; i >= 0; i--)
        {
            if (sides[i].Length == 0) continue;

            tmp = new StringBuilder();
            int delta = 1;
            for (int j = sides[i].Length - 1; j >= 0; j--)
            {
                if (i + delta < sb.Length)
                {
                    tmp.Append(sides[i][j]);
                    tmp.Append(sb[i + delta++]);
                }
                else break;
            }
            sb.Remove(i + 1, delta - 1).Insert(i + 1, tmp);
        }
        return sb.ToString();
    }

    private Random random = new Random();
    private string MakeMainRoad()
    {
        var sb = new StringBuilder("abcdefghijklmnopqrstuvwxyz");
        var len = random.Next(1, 27);
        sb.Length = len;
        var me = random.Next(len);
        sb[me] = 'X';
        return sb.ToString();
    }

    private string[] MakeSideStreets(int mrLen)
    {
        var ssLen = random.Next(1, mrLen + 1);
        var sideStreets = new string[ssLen];
        for (int i = 0; i < sideStreets.Length; i++)
        {
            if (random.NextDouble() < 0.3)
            {
                // cars in side street
                var cars = random.Next(1, 11);
                var ss = "";
                for (int c = 0; c < cars; c++) ss += (char)('A' + i);
                sideStreets[i] = ss;
            }
            else
            {
                // no side street
                sideStreets[i] = "";
            }
        }
        return sideStreets;
    }

    [Test]
    public void Random()
    {
        for (int r = 0; r < 100; r++)
        {
            var mr = MakeMainRoad();
            var ss = MakeSideStreets(mr.Length);
            var expected = TrafficJam(mr, ss);
            var actual = Dinglemouse.TrafficJam(mr, ss);
            Assert.AreEqual(expected, actual);
        }
    }
}
