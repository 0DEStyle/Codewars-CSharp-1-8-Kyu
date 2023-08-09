/*Challenge link:https://www.codewars.com/kata/57feb00f08d102352400026e/train/csharp
Question:
You are at the airport staring blankly at the arrivals/departures flap display...


How it works
You notice that each flap character is on some kind of a rotor and the order of characters on each rotor is:

ABCDEFGHIJKLMNOPQRSTUVWXYZ ?!@#&()|<>.:=-+*/0123456789

And after a long while you deduce that the display works like this:

Starting from the left, all rotors (from the current one to the end of the line) flap together until the left-most rotor character is correct.

Then the mechanism advances by 1 rotor to the right...

...REPEAT this rotor procedure until the whole line is updated

...REPEAT this line procedure from top to bottom until the whole display is updated

Example
Consider a flap display with 3 rotors and one 1 line which currently spells CAT

Step 1  (current rotor is 1)
Flap x 1
Now line says DBU
Step 2  (current rotor is 2)
Flap x 13
Now line says DO)
Step 3  (current rotor is 3)
Flap x 27
Now line says DOG
This can be represented as

lines  // array of strings. Each string is a display line of the initial configuration
rotors // array of array-of-rotor-values. Each array-of-rotor-values is applied to the corresponding display line
result // array of strings. Each string is a display line of the final configuration
e.g.

lines = ["CAT"]
rotors = [[1,13,27]]
result = ["DOG"]
Kata Task
Given the initial display lines and the rotor moves for each line, determine what the board will say after it has been fully updated.

For your convenience the characters of each rotor are in the pre-loaded constant ALPHABET which is a string.


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//how it works, mechanically
//https://en.wikipedia.org/wiki/Split-flap_display
using System;

class Dinglemouse{
    private static string ALPHABET = Preloaded.ALPHABET;

    public static string[] FlapDisplay(String[] lines, int[][] rotors){
      //start from 0 up to line.Length
      for (int i = 0; i < lines.Length; i++){
        
      //rotor instruction at index i
        int[] lineRotors = rotors[i];
        char[] res = lines[i].ToCharArray();
            
        //shift rotor from left to right
        for (int r = 0; r < lineRotors.Length; r++){
          int flaps = lineRotors[r];
          
        // dealing with flaps that exceed Alphabet max 54, cancel unnecessary full rotations of rotor
          int fullRotations = flaps / ALPHABET.Length;
          flaps -= fullRotations * ALPHABET.Length;
                
        // flap remaining characters from left to right
          for (int c = r; c < lineRotors.Length; c++){
            int n = ALPHABET.IndexOf(res[c]) + flaps;
            n = (n < ALPHABET.Length) ? n : n - ALPHABET.Length;
            res[c] = ALPHABET[n];
            }
          }
        //concat result
        lines[i] = new string(res);
      }
      return lines;
    }
}

//method 2
using System;
using System.Linq;

public class Dinglemouse
{
    private static string ALPHABET = Preloaded.ALPHABET;
    
    public static string[] FlapDisplay(String[] lines, int[][] rotors) =>
        Enumerable.Range(0, lines.Length).Select(i => FlapLine(lines[i], rotors[i])).ToArray();

    private static string FlapLine(string line, int[] rotor) =>
        string.Concat(Enumerable.Range(0, line.Length).Select(i => Rotate(line[i], rotor.Take(i + 1).Sum())));

    private static char Rotate(char input, int rotations) =>
        ALPHABET[(ALPHABET.IndexOf(input) + rotations) % ALPHABET.Length];
}
//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
public class SolutionTests
{
    private static string ALPHABET = Preloaded.ALPHABET;

    // Reference implementation
    private string[] FlapDisplay(string[] lines, int[][] rotors)
    {
        var ret = new List<string>();
        for (int y = 0; y < lines.Length; y++)
        {
            var newline = lines[y];
            for (int x = 0; x < lines[y].Length; x++)
            {
                // flap this char and all others to its right (by the rotor amount)
                var rotor = rotors[y][x];
                for (int c = x; c < lines[y].Length; c++)
                {
                    var before = ALPHABET.IndexOf(newline[c]);
                    var after = (before + rotor) % ALPHABET.Length;
                    newline = newline.Substring(0, c) + ALPHABET[after] + newline.Substring(c + 1);
                }
            }
            ret.Add(newline);
        }
        return ret.ToArray();
    }

    //====================================

    private string[] BEFORE(string[] a)
    {
        Console.WriteLine("Before:");
        return Preloaded.PrettyPrint(a);
    }

    private string[] AFTER(string[] a)
    {
        Console.WriteLine("After:");
        return Preloaded.PrettyPrint(a);
    }

    [Test]
    public void Example()
    {
        // CAT => DOG
        var before = BEFORE(new[] { "CAT" });
        var rotors = new int[][] { new[] { 1, 13, 27 } };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        var expected = new[] { "DOG" };
        Assert.AreEqual(expected, after);
    }

    [Test]
    public void Basic()
    {
        // HELLO => WORLD!
        var before = BEFORE(new[] { "HELLO " });
        var rotors = new int[][] { new[] { 15, 49, 50, 48, 43, 13 } };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        var expected = new[] { "WORLD!" };
        Assert.AreEqual(expected, after);

        // CODE => WARS
        var before2 = BEFORE(new[] { "CODE" });
        var rotors2 = new int[][] { new[] { 20, 20, 28, 0 } };
        var after2 = AFTER(Dinglemouse.FlapDisplay(before2, rotors2));
        var expected2 = new[] { "WARS" };
        Assert.AreEqual(expected2, after2);
    }


    [Test]
    public void Edges()
    {
        // No moves needed
        var before = BEFORE(new[] { "NOTHING MOVED" });
        var rotors = new int[][] { new[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 } };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        var expected = new[] { "NOTHING MOVED" };
        Assert.AreEqual(expected, after);

        // Max rotor moves
        var before2 = BEFORE(new[] { "EFGH" });
        var rotors2 = new int[][] { new[] { 53, 53, 53, 53 } };
        var after2 = AFTER(Dinglemouse.FlapDisplay(before2, rotors2));
        var expected2 = new[] { "DDDD" };
        Assert.AreEqual(expected2, after2);
    }

    [Test]
    public void RotorMalfunction()
    {
        // Some bad rotor goes around more than once!
        var before = BEFORE(new[] { "IN SPACE NOBODY...  " });
        var rotors = new int[][] { new[] { 48, 47, 0, 21, 38, 120, 48, 15, 41, 11, 43, 19, 47, 3, 17, 2, 41, 50, 23, 16 } };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        var expected = new[] { "CAN HEAR YOU SCREAM!" };
        Assert.AreEqual(expected, after);
    }

    [Test]
    public void Multiline()
    {
        // Multi-line display
        var before = BEFORE(new[]
        {
            "+---------------------------+",
            "| THIS IS A MULTI LINE TEST |",
            "+---------------------------+"
        });
        var expected = new[]
        {
            "*****************************",
            "*   DO YOU LIKE THIS KATA?  *",
            "*****************************"
        };
        var rotors = new int[][]
        {
            new[]{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 53 },
            new[]{ 8, 46, 7, 12, 30, 1, 4, 16, 34, 52, 32, 13, 11, 48, 3, 14, 4, 24, 16, 13, 3, 47, 22, 26, 50, 13, 52, 47, 8 },
            new[]{ 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 53 }
        };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        Assert.AreEqual(expected, after);
    }

    [Test]
    public void Lifelike()
    {
        // Just like the real thing?
        var before = BEFORE(new[]
        {
            "FLT NO  FROM             STATUS  TIME  GATE",
            "------  ---------------  ------  ----- ----",
            "QF 085  HONG KONG        LANDED  17.30   02",
            "NZ 008  AUCKLAND SYDNEY  LANDED  17.35   03",
            "CX 104  HONG KONG        ON TIME 17.38   --",
            "MH 108  KUALA LUMPA      DELAYED 17.55   --"
        });
        var expected = new[]
        {
            "FLT NO  FROM             STATUS  TIME  GATE",
            "------  ---------------  ------  ----- ----",
            "NZ 008  AUCKLAND SYDNEY  LANDED  17.35   03",
            "CX 104  HONG KONG        LANDED  17.38   01",
            "EK 418  CHRISTCHURCH     ON TIME 17.40   --",
            "MH 108  KUALA LUMPA      DELAYED 17.53   --"
        };
        var rotors = new int[][]
        {
            new []{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new []{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            new []{ 51, 23, 34, 0, 46, 11, 51, 0, 47, 13, 37, 15, 35, 5, 9, 45, 30, 26, 6, 33, 10, 45, 20, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 5, 49, 0, 0, 0, 1 },
            new []{ 43, 9, 2, 1, 53, 50, 4, 0, 7, 41, 17, 39, 19, 49, 45, 9, 24, 28, 48, 21, 44, 9, 34, 52, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 51, 0, 0, 0, 52 },
            new []{ 2, 39, 13, 3, 52, 3, 50, 0, 49, 52, 11, 52, 44, 17, 33, 6, 20, 31, 39, 5, 19, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 45, 8, 0, 0, 0, 0 },
            new []{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 52, 2, 0, 0, 0, 0 }
        };
        var after = AFTER(Dinglemouse.FlapDisplay(before, rotors));
        Assert.AreEqual(expected, after);
    }

    [Test]
    public void Random()
    {
        // random rotor values
        var random = new Random();
        var before = BEFORE(new[] { "THE QUICK BROWN FOX JUMPS OVER A LAZY DOG" });
        for (int rnd = 0; rnd < 20; rnd++)
        {
            var linerotors = new int[before[0].Length];
            for (int r = 0; r < before[0].Length; r++)
                linerotors[r] = random.Next(ALPHABET.Length);
            var expected = FlapDisplay(before, new int[][] { linerotors });
            var after = AFTER(Dinglemouse.FlapDisplay(before, new int[][] { linerotors }));
            Assert.AreEqual(expected, after);
        }
    }
}
