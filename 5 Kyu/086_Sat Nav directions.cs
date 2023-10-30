/*Challenge link:https://www.codewars.com/kata/5a9b4d104a6b341b42000070/train/csharp
Question:
Background
It is the middle of the night.

You are jet-lagged from your long cartesian plane trip, and find yourself in a rental car office in an unfamiliar city.

You have no idea how to get to your hotel.

Oh, and it's raining.

Could you be any more miserable?

But the friendly rental-car dude behind the desk says not to worry! He kindly pre-programs the car Sat Nav system with your destination. He smiles and assures you that the device works OK. What excellent service! What a nice man!

Maybe things are not so bad after all.

Then he sniggers...

City streets
The city extends as far as the eye can see in all directions, and is laid out as a giant grid where all blocks are 1km across.

Notice that [x,y] coordinates are described with units of 100m

(See image in the link at the start)

satnav city streets
Kata task
Your starting point is [0,0]

Simply follow the Sat Nav directions!

When you arrive at the destination return the final [x,y] coordinates.

Sat Nav directions
The device gives directions as text messages:

The first message

Head <NORTH,EAST,SOUTH,WEST>
The en-route messages

Take the <NEXT,2nd,3rd,4th,5th> <LEFT,RIGHT>
Go straight on for <100,200,300,...,900>m
Go straight on for <1.0,1.1,1.2,...,5.0>km
Turn around!
The last message

You have reached your destination!
NOTES

First and last messages are always present
There may be any number of en-route messages
Messages are always formatted corrrectly
A NEXT turn message means you must to proceed to the next cross-street even if you are currently at an intersection
But Turn around does not need to be done at an intersection. Just do a U-turn wherever you are!



Good Luck!
DM
*/

//***************Solution********************
using System;
using System.Drawing;

public class Dinglemouse{
    public static Point SatNav(string[] directions){
      //x y coordinates at m. Direction at NORTH SOUTH EAST WEST
        var (x, y) = (0m, 0m);
        var (a, b) = directions[0][5..] switch { "NORTH" => (0, 1), "SOUTH" => (0, -1), "EAST" => (1, 0), "WEST" => (-1, 0) };
        
      //loop through each direction.
      //if string start with "Take the",
      //if x % 1 not equal to 0 or y % 1 not equal to 0, set m to 1, else set m to 0.
      //if d[9] is equal to 'N', set n to 1, else set n to d[9] - '0'
      foreach (var d in directions[1..^1]){
            if (d.StartsWith("Take the")){
                int m = x % 1 != 0 || y % 1 != 0 ? 1 : 0;
                int n = d[9] == 'N' ? 1 : d[9] - '0';
              //while x % 1 is not equal to 0, accumulate x by adding 0.1m * a
                while (x % 1 != 0) 
                  x += 0.1m * a;
              //while y % 1 is not equal to 0, accumulate y by adding 0.1m * b
                while (y % 1 != 0) 
                  y += 0.1m * b;
              //while n-- is greater than m,  x = x + a and y = y + b
                while (n-- > m) 
                  (x, y) = (x + a, y + b);
              //if string ends with "LEFT" set a to -b and b to a, else set a to b and b to -a
                (a, b) = d.EndsWith("LEFT") ? (-b, a) : (b, -a);
            }
        //direction to turn around
            else if (d == "Turn around!") 
              (a, b) = (-a, -b);
        //calculate new distance.
            else {
                var n = decimal.Parse(d[19..22]) / (d.EndsWith("km") ? 1 : 1000);
                (x, y) = (x + a * n, y + b * n);
            }
        }
      //return final coordintes as point
        return new Point((int)(10 * x), (int)(10 * y));
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text.RegularExpressions;
public class SolutionTests
{
    private static string MSG_FIRST = "Head {0}";
    private static string MSG_TURN_LR = "Take the {0} {1}";
    private static string MSG_STRAIGHT_M = "Go straight on for {0}m";
    private static string MSG_STRAIGHT_KM = "Go straight on for {0}km";
    private static string MSG_TURN_AROUND = "Turn around!";
    private static string MSG_LAST = "You have reached your destination!";

    private static string[] HEADINGS = { "NORTH", "EAST", "SOUTH", "WEST" };
    private static string[] WHICH_TURN = { "NEXT", "2nd", "3rd", "4th", "5th" };
    private static string[] TURNS = { "LEFT", "RIGHT" };
    private static string[] METRES = { "100", "200", "300", "400", "500", "600", "700", "800", "900" };
    private static string[] KILOMETRES =
    {
        "1.0", "1.1", "1.2", "1.3", "1.4", "1.5", "1.6", "1.7", "1.8", "1.9",
        "2.0", "2.1", "2.2", "2.3", "2.4", "2.5", "2.6", "2.7", "2.8", "2.9",
        "3.0", "3.1", "3.2", "3.3", "3.4", "3.5", "3.6", "3.7", "3.8", "3.9",
        "4.0", "4.1", "4.2", "4.3", "4.4", "4.5", "4.6", "4.7", "4.8", "4.9",
        "5.0"
    };

    [Test]
    public void Ex1()
    {
        var directions = new[]
        {
            "Head EAST",
            "Take the 2nd LEFT",
            "Take the NEXT LEFT",
            "Take the NEXT LEFT",
            "Go straight on for 1.5km",
            "Take the NEXT RIGHT",
            "Take the 2nd RIGHT",
            "Go straight on for 1.7km",
            "Turn around!",
            "Take the NEXT LEFT",
            "Go straight on for 1.0km",
            "You have reached your destination!"
        };
        Preloaded.Display(directions);
        Assert.AreEqual(new Point(0, 0), Dinglemouse.SatNav(directions));
    }

    [Test]
    public void Ex2()
    {
        var directions = new[]
        {
            "Head NORTH",
            "Take the 2nd LEFT",
            "Take the 2nd LEFT",
            "Take the NEXT LEFT",
            "Go straight on for 3.5km",
            "Take the NEXT RIGHT",
            "Go straight on for 2.3km",
            "Take the NEXT RIGHT",
            "Take the NEXT RIGHT",
            "Take the NEXT LEFT",
            "Take the NEXT RIGHT",
            "Go straight on for 900m",
            "You have reached your destination!"
        };
        Preloaded.Display(directions);
        Assert.AreEqual(new Point(0, -1), Dinglemouse.SatNav(directions));
    }

    [Test]
    public void ZedBug1()
    {
        var expected = new Point(-30, 130);
        var directions = new[]
        {
            "Head SOUTH",  // 0 0
            "Turn around!", // 0 0
            "Go straight on for 600m", // 0 6
            "Take the 2nd LEFT", /// 0 20
            "Go straight on for 3.3km", // -33 20
            "Go straight on for 2.5km", // -58 20
            "Turn around!", // -58 20
            "Take the 3rd LEFT", // -30 20
            "Go straight on for 3.6km", // -30 56
            "Go straight on for 4.2km", // -30 98
            "Take the 4th LEFT", // -30 130
            "You have reached your destination!" // -30 130
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void ZedBug2()
    {
        var expected = new Point(30, -34);
        var directions = new[]
        {
            "Head NORTH", //  0 0
            "Take the 3rd RIGHT", // 0 30
            "Go straight on for 700m", // 7 30
            "Turn around!", // 7 30
            "Go straight on for 400m", // 3 30
            "Take the 3rd LEFT", // -20 30
            "Go straight on for 700m", // -20 23
            "Take the 2nd LEFT", // -20 10
            "Take the 5th RIGHT", // 30 10
            "Go straight on for 4.4km", // 30 -34
            "Turn around!", // 30 -34
            "You have reached your destination!" // 30 -34
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }



    // =================================
    // NEGATIVE TURNS
    // =================================

    [Test]
    public void FromNegY2PosOdd()
    {
        var expected = new Point(0, 10);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"1.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegY2PosEven()
    {
        var expected = new Point(0, 20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"1.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegY2ZeroOdd()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"4.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegY2ZeroEven()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"4.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegY2NegOdd()
    {
        var expected = new Point(0, -30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"4.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegY2NegEven()
    {
        var expected = new Point(0, -20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM,"4.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // X

    [Test]
    public void FromNegX2PosOdd()
    {
        var expected = new Point(10, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"2.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegX2PosEven()
    {
        var expected = new Point(20, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"2.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegX2ZeroOdd()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"4.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegX2ZeroEven()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"4.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegX2NegOdd()
    {
        var expected = new Point(-30, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"4.8"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void FromNegX2NegEven()
    {
        var expected = new Point(-20, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM,"4.0"),
            MSG_TURN_AROUND,
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // =================================
    // HEADINGS BUT NO OTHER INSTRUCTION
    // =================================

    [Test]
    public void HeadNorth()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest()
    {
        var expected = new Point(0, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // =================================
    // GO STRAIGHT (m)
    // =================================

    [Test]
    public void HeadNorthBy300Metres()
    {
        var expected = new Point(0, 3);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_M, "300"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorthBy900Metres()
    {
        var expected = new Point(0, 9);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_M, "900"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEastBy300Metres()
    {
        var expected = new Point(3, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_M, "300"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEastBy900Metres()
    {
        var expected = new Point(9, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_M, "900"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouthBy300Metres()
    {
        var expected = new Point(0, -3);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_M, "300"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouthBy900Metres()
    {
        var expected = new Point(0, -9);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_M, "900"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWestBy300Metres()
    {
        var expected = new Point(-3, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_M, "300"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWestBy900Metres()
    {
        var expected = new Point(-9, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_M, "900"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // =================================
    // GO STRAIGHT (km)
    // =================================

    [Test]
    public void HeadNorthBy1p3KM()
    {
        var expected = new Point(0, 13);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.3"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEastBy2p7KM()
    {
        var expected = new Point(27, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "2.7"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouthBy3p1KM()
    {
        var expected = new Point(0, -31);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "3.1"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWestBy4p6KM()
    {
        var expected = new Point(-46, 0);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "4.6"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // ==================================
    // HEADING THEN TURN THEN GO STRAIGHT
    // ==================================

    // NORTH - LEFT

    [Test]
    public void HeadNorthNextLEFT()
    {
        var expected = new Point(-1, 10);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth2ndLEFT()
    {
        var expected = new Point(-1, 20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth3rdLEFT()
    {
        var expected = new Point(-1, 30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth4thLEFT()
    {
        var expected = new Point(-1, 40);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth5thLEFT()
    {
        var expected = new Point(-1, 50);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // NORTH - RIGHT

    [Test]
    public void HeadNorthNextRIGHT()
    {
        var expected = new Point(1, 10);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth2ndRIGHT()
    {
        var expected = new Point(1, 20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth3rdRIGHT()
    {
        var expected = new Point(1, 30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth4thRIGHT()
    {
        var expected = new Point(1, 40);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth5thRIGHT()
    {
        var expected = new Point(1, 50);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // EAST - LEFT

    [Test]
    public void HeadEastNextLEFT()
    {
        var expected = new Point(10, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast2ndLEFT()
    {
        var expected = new Point(20, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast3rdLEFT()
    {
        var expected = new Point(30, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast4thLEFT()
    {
        var expected = new Point(40, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast5thLEFT()
    {
        var expected = new Point(50, 1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // EAST - RIGHT

    [Test]
    public void HeadEastNextRIGHT()
    {
        var expected = new Point(10, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast2ndRIGHT()
    {
        var expected = new Point(20, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast3rdRIGHT()
    {
        var expected = new Point(30, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast4thRIGHT()
    {
        var expected = new Point(40, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast5thRIGHT()
    {
        var expected = new Point(50, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // SOUTH - LEFT

    [Test]
    public void HeadSouthNextLEFT()
    {
        var expected = new Point(1, -10);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth2ndLEFT()
    {
        var expected = new Point(1, -20);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth3rdLEFT()
    {
        var expected = new Point(1, -30);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth4thLEFT()
    {
        var expected = new Point(1, -40);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth5thLEFT()
    {
        var expected = new Point(1, -50);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // SOUTH - RIGHT

    [Test]
    public void HeadSouthNextRIGHT()
    {
        var expected = new Point(-1, -10);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth2ndRIGHT()
    {
        var expected = new Point(-1, -20);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth3rdRIGHT()
    {
        var expected = new Point(-1, -30);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth4thRIGHT()
    {
        var expected = new Point(-1, -40);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth5thRIGHT()
    {
        var expected = new Point(-1, -50);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // WEST - LEFT

    [Test]
    public void HeadWestNextLEFT()
    {
        var expected = new Point(-10, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest2ndLEFT()
    {
        var expected = new Point(-20, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest3rdLEFT()
    {
        var expected = new Point(-30, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest4thLEFT()
    {
        var expected = new Point(-40, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest5thLEFT()
    {
        var expected = new Point(-50, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // WEST - RIGHT

    [Test]
    public void HeadWesthNextRIGHT()
    {
        var expected = new Point(-10, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest2ndRIGHT()
    {
        var expected = new Point(-20, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest3rdRIGHT()
    {
        var expected = new Point(-30, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest4thRIGHT()
    {
        var expected = new Point(-40, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest5thRIGHT()
    {
        var expected = new Point(-50, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // ===================================================
    // HEADING THEN GO STRAIGHT THEN TURN THEN GO STRAIGHT
    // ===================================================

    // NORTH - LEFT

    [Test]
    public void HeadNorth1p2kmNextLEFT()
    {
        var expected = new Point(-1, 20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km2ndLEFT()
    {
        var expected = new Point(-1, 30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km3rdLEFT()
    {
        var expected = new Point(-1, 40);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km4thLEFT()
    {
        var expected = new Point(-1, 50);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km5thLEFT()
    {
        var expected = new Point(-1, 60);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // NORTH - RIGHT

    [Test]
    public void HeadNorth1p2kmNextRIGHT()
    {
        var expected = new Point(1, 20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km2ndRIGHT()
    {
        var expected = new Point(1, 30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km3rdRIGHT()
    {
        var expected = new Point(1, 40);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km4thRIGHT()
    {
        var expected = new Point(1, 50);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadNorth1p2km5thRIGHT()
    {
        var expected = new Point(1, 60);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // EAST - LEFT

    [Test]
    public void HeadEast1p2kmNextLEFT()
    {
        var expected = new Point(20, 1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km2ndLEFT()
    {
        var expected = new Point(30, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km3rdLEFT()
    {
        var expected = new Point(40, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km4thLEFT()
    {
        var expected = new Point(50, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km5thLEFT()
    {
        var expected = new Point(60, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // EAST - RIGHT

    [Test]
    public void HeadEast1p2kmNextRIGHT()
    {
        var expected = new Point(20, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km2ndRIGHT()
    {
        var expected = new Point(30, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km3rdRIGHT()
    {
        var expected = new Point(40, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km4thRIGHT()
    {
        var expected = new Point(50, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEast1p2km5thRIGHT()
    {
        var expected = new Point(60, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // SOUTH - LEFT

    [Test]
    public void HeadSouth1p2kmNextLEFT()
    {
        var expected = new Point(1, -20);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km2ndLEFT()
    {
        var expected = new Point(1, -30);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km3rdLEFT()
    {
        var expected = new Point(1, -40);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km4thLEFT()
    {
        var expected = new Point(1, -50);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km5thLEFT()
    {
        var expected = new Point(1, -60);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // SOUTH - RIGHT

    [Test]
    public void HeadSouth1p2kmNextRIGHT()
    {
        var expected = new Point(-1, -20);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km2ndRIGHT()
    {
        var expected = new Point(-1, -30);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km3rdRIGHT()
    {
        var expected = new Point(-1, -40);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km4thRIGHT()
    {
        var expected = new Point(-1, -50);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouth1p2km5thRIGHT()
    {
        var expected = new Point(-1, -60);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // WEST - LEFT

    [Test]
    public void HeadWest1p2kmNextLEFT()
    {
        var expected = new Point(-20, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km2ndLEFT()
    {
        var expected = new Point(-30, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km3rdLEFT()
    {
        var expected = new Point(-40, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km4thLEFT()
    {
        var expected = new Point(-50, -1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km5thLEFT()
    {
        var expected = new Point(-60, -1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "LEFT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // WEST - RIGHT

    [Test]
    public void HeadWesth1p2kmNextRIGHT()
    {
        var expected = new Point(-20, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "NEXT", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km2ndRIGHT()
    {
        var expected = new Point(-30, 1);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "2nd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km3rdRIGHT()
    {
        var expected = new Point(-40, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "3rd", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km4thRIGHT()
    {
        var expected = new Point(-50, 1);
        var directions = new []
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "4th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWest1p2km5thRIGHT()
    {
        var expected = new Point(-60, 1);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            string.Format(MSG_TURN_LR, "5th", "RIGHT"),
            string.Format(MSG_STRAIGHT_M, "100"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // ==================================
    // U-TURN
    // ==================================

    [Test]
    public void HeadNorthTurnAround()
    {
        var expected = new Point(0, 10);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"NORTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            MSG_TURN_AROUND,
            string.Format(MSG_STRAIGHT_M, "200"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadEastTurnAround()
    {
        var expected = new Point(10, 0);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"EAST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            MSG_TURN_AROUND,
            string.Format(MSG_STRAIGHT_M, "200"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadSouthTurnAround()
    {
        var expected = new Point(0, -10);
        var directions = new[]
        {
            string.Format(MSG_FIRST,"SOUTH"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            MSG_TURN_AROUND,
            string.Format(MSG_STRAIGHT_M, "200"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    [Test]
    public void HeadWestTurnAround()
    {
        var expected = new Point(-10, 0);
        var directions = new[] 
        {
            string.Format(MSG_FIRST,"WEST"),
            string.Format(MSG_STRAIGHT_KM, "1.2"),
            MSG_TURN_AROUND,
            string.Format(MSG_STRAIGHT_M, "200"),
            MSG_LAST
        };
        Preloaded.Display(directions);
        Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
    }

    // ==================================
    // Random
    // ==================================

    // ---- Reference Implementation ----

    private class Solution
    {
        private enum Heading { N, E, S, W };

        // Headings from heading names
        private static Dictionary<string, Heading> MAP_HEADING = new Dictionary<string, Heading>()
        {
            ["NORTH"] = Heading.N,
            ["EAST"] = Heading.E,
            ["SOUTH"] = Heading.S,
            ["WEST"] = Heading.W
        };

        // Map of (x,y) deltas when moving in the direction of "Heading"
        private static Dictionary<Heading, (int, int)> MAP_DELTA = new Dictionary<Heading, (int, int)>()
        {
            [Heading.N] = (0, 1),
            [Heading.E] = (1, 0),
            [Heading.S] = (0, -1),
            [Heading.W] = (-1, 0)
        };

        // Map the relative Left/Right/Back when moving in the direction of "Heading"
        private static Dictionary<Heading, Heading[]> MAP_LR_BACK = new Dictionary<Heading, Heading[]>()
        {
            [Heading.N] = new[] { Heading.W, Heading.E, Heading.S },
            [Heading.E] = new[] { Heading.N, Heading.S, Heading.W },
            [Heading.S] = new[] { Heading.E, Heading.W, Heading.N },
            [Heading.W] = new[] { Heading.S, Heading.N, Heading.E }
        };

        // Intersection counts (NEXT is 1)
        private static List<string> WHICH_INTERSECTION = new List<string> { null, "NEXT", "2nd", "3rd", "4th", "5th" };

        private static Regex P_HEAD = new Regex("^Head.*(NORTH|EAST|SOUTH|WEST).*$", RegexOptions.Compiled);
        private static Regex P_TURN_U = new Regex("^Turn around.*$", RegexOptions.Compiled);
        private static Regex P_STRAIGHT_M = new Regex("^.*(\\d\\d\\d)m.*$", RegexOptions.Compiled);
        private static Regex P_STRAIGHT_KM = new Regex("^.*(\\d\\.\\d)km.*$", RegexOptions.Compiled);
        private static Regex P_TURN_LR = new Regex("^Take the (NEXT|2nd|3rd|4th|5th) (LEFT|RIGHT)$", RegexOptions.Compiled);

        public static Point SatNav(string[] directions)
        {
            var curHeading = Heading.N;
            var curPoint = new Point(0, 0);
            var dist = 0;

            foreach (var direction in directions)
            {
                // Initial Heading
                var match = P_HEAD.Match(direction);
                if (match.Success)
                {
                    curHeading = MAP_HEADING[match.Groups[1].Value];
                    continue;
                }

                // Turn around (head in opposite direction)
                match = P_TURN_U.Match(direction);
                if (match.Success)
                {
                    curHeading = MAP_LR_BACK[curHeading][2];
                    continue;
                }

                // Turn LEFT/RIGHT
                match = P_TURN_LR.Match(direction);
                if (match.Success)
                {

                    // Proceed to the appropriate intersection
                    var nth = WHICH_INTERSECTION.IndexOf(match.Groups[1].Value);
                    int x = curPoint.X, y = curPoint.Y;
                    switch (curHeading)
                    {
                        case Heading.N: if (y < 0 && y % 10 != 0) y -= (10 + y % 10); y = (y + 10 * nth) / 10 * 10; break;
                        case Heading.E: if (x < 0 && x % 10 != 0) x -= (10 + x % 10); x = (x + 10 * nth) / 10 * 10; break;
                        case Heading.S: if (y > 0 && y % 10 != 0) y += (10 - y % 10); y = (y - 10 * nth) / 10 * 10; break;
                        case Heading.W: if (x > 0 && x % 10 != 0) x += (10 - x % 10); x = (x - 10 * nth) / 10 * 10; break;
                    }
                    dist += Math.Abs(x) - Math.Abs(curPoint.X) + Math.Abs(y) - Math.Abs(curPoint.Y);
                    curPoint = new Point(x, y);

                    // Make the turn
                    switch (match.Groups[2].Value)
                    {
                        case "LEFT": curHeading = MAP_LR_BACK[curHeading][0]; break; // go left
                        case "RIGHT": curHeading = MAP_LR_BACK[curHeading][1]; break; // go right
                    }
                    continue;
                }

                // Go straight on this heading X metres
                match = P_STRAIGHT_M.Match(direction);
                if (match.Success)
                {
                    var n = int.Parse(match.Groups[1].Value) / 100;
                    var (x, y) = MAP_DELTA[curHeading];
                    curPoint = new Point(curPoint.X + x * n, curPoint.Y + y * n);
                    dist += Math.Abs(x * n + y * n);
                    continue;
                }

                // Go straight on this heading X kilometres
                match = P_STRAIGHT_KM.Match(direction);
                if (match.Success)
                {
                    var n = int.Parse(match.Groups[1].Value.Replace(".", ""));
                    var (x, y) = MAP_DELTA[curHeading];
                    curPoint = new Point(curPoint.X + x * n, curPoint.Y + y * n);
                    dist += Math.Abs(x * n + y * n);
                    continue;
                }
            }
            int xx = curPoint.X, yy = curPoint.Y;
            Console.WriteLine($"Actual distance to hotel = {(Math.Abs(xx) + Math.Abs(yy)) * 100}m");
            Console.WriteLine($"Total distance travelled = { dist * 100}m");
            Console.WriteLine($"FINAL LOCATION = (x={xx},y={yy})");
            return curPoint;
        }
    }

    private Random random = new Random();
    private string[] RandomDirections()
    {
        var ary = new List<string>();
        var heading = HEADINGS[random.Next(HEADINGS.Length)];
        ary.Add(string.Format(MSG_FIRST, heading));
        var nMsgs = random.Next(75);
        for (int i = 0; i < nMsgs; i++)
        {
            var rnd = random.NextDouble();
            if (rnd < 0.40)
            {
                // STRAIGHT AHEAD
                if (rnd < 0.20)
                {
                    var metres = METRES[random.Next(METRES.Length)];
                    ary.Add(string.Format(MSG_STRAIGHT_M, metres));
                }
                else
                {
                    string kilometres = KILOMETRES[random.Next(KILOMETRES.Length)];
                    ary.Add(string.Format(MSG_STRAIGHT_KM, kilometres));
                }
            }
            else if (rnd < 0.80)
            {
                // TURN CORNER
                string whichTurn = WHICH_TURN[random.Next(WHICH_TURN.Length)];
                string leftOrRight = TURNS[random.Next(TURNS.Length)];
                ary.Add(string.Format(MSG_TURN_LR, whichTurn, leftOrRight));
            }
            else
            {
                // U-TURN
                ary.Add(MSG_TURN_AROUND);
            }

        }
        ary.Add(MSG_LAST);
        return ary.ToArray();
    }

    [Test]
    public void Random()
    {
        for (int r = 0; r < 200; r++)
        {
            Console.WriteLine($"Random Test {r + 1}");
            var directions = RandomDirections();
            Preloaded.Display(directions);
            var expected = Solution.SatNav(directions);
            Assert.AreEqual(expected, Dinglemouse.SatNav(directions));
            Console.WriteLine("<hr style='border-bottom:2px solid orange;'>");
        }
    }
}
