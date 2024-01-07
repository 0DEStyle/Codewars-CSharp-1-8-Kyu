/*Challenge link:https://www.codewars.com/kata/5b8dc84b8ce20454bd00002e/train/csharp
Question:
Theory
This section does not need to be read and can be skipped, but it does provide some clarity into the inspiration behind the problem.

In music theory, a major scale consists of seven notes, or scale degrees, in order (with tonic listed twice for demonstrative purposes):

Tonic, the base of the scale and the note the scale is named after (for example, C is the tonic note of the C major scale)
Supertonic, 2 semitones (or one tone) above the tonic
Mediant, 2 semitones above the supertonic and 4 above the tonic
Subdominant, 1 semitone above the median and 5 above the tonic
Dominant, 2 semitones above the subdominant and 7 above the tonic
Submediant, 2 semitones above the dominant and 9 above the tonic
Leading tone, 2 semitones above the mediant and 11 above the tonic
Tonic (again!), 1 semitone above the leading tone and 12 semitones (or one octave) above the tonic
An octave is an interval of 12 semitones, and the pitch class of a note consists of any note that is some integer number of octaves apart from that note. Notes in the same pitch class sound different but share similar properties. If a note is in a major scale, then any note in that note's pitch class is also in that major scale.

Problem
Using integers to represent notes, the major scale of an integer note will be an array (or list) of integers that follows the major scale pattern note, note + 2, note + 4, note + 5, note + 7, note + 9, note + 11. For example, the array of integers [1, 3, 5, 6, 8, 10, 12] is the major scale of 1.

Secondly, the pitch class of a note will be the set of all integers some multiple of 12 above or below the note. For example, 1, 13, and 25 are all in the same pitch class.

Thirdly, an integer note1 is considered to be in the key of an integer note2 if note1, or some integer in note1's pitch class, is in the major scale of note2. More mathematically, an integer note1 is in the key of an integer note2 if there exists an integer i such that note1 + i × 12 is in the major scale of note2. For example, 22 is in the key of of 1 because, even though 22 is not in 1's major scale ([1, 3, 5, 6, 8, 10, 12]), 10 is and is also a multiple of 12 away from 22. Likewise, -21 is also in the key of 1 because -21 + (2 × 12) = 3 and 3 is present in the major scale of 1. An array is in the key of an integer if all its elements are in the key of the integer.

Your job is to create a function is_tune that will return whether or not an array (or list) of integers is a tune. An array will be considered a tune if there exists a single integer note all the integers in the array are in the key of. The function will accept an array of integers as its parameter and return True if the array is a tune or False otherwise. Empty and null arrays are not considered to be tunes. Additionally, the function should not change the input array.

Examples
is_tune([1, 3, 6, 8, 10, 12]) # Returns True, all the elements are in the major scale  
    # of 1 ([1, 3, 5, 6, 8, 10, 12]) and so are in the key of 1.
is_tune([1, 3, 6, 8, 10, 12, 13, 15]) # Returns True, 14 and 15 are also in the key of 1 as 
    # they are in the major scale of 13 which is in the pitch class of 1 (13 = 1 + 12 * 1).
is_tune([1, 6, 3]) # Returns True, arrays don't need to be sorted.
is_tune([1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]) # Returns False, this array is not in the 
    # key of any integer.
is_tune([2, 4, 7, 9, 11, 13]) # Returns True, the array is in the key of 2 (the arrays
    #  don't need to be in the key of 1, just some integer)
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
               __________________________________
              /                                  \
             /					                          \__________
            /                                                \
           /                                                  \
          /                                                    \              ♪
         /                                                      |       𝄞
        /		             _______________			                  |
       /                |	      |	      |                      /|
      /                 |=======+=======|                     / |
     /                  |_______|_______|                    /  |
    /_______________________________________________________/   |
    |                                                       |   /
    |   _   _       _   _   _       _   _       _   _   _   |  /
    |__//|_//|_____//|_//|_//|_____//|_//|_____//|_//|_//|__| /
   /  /// ///  /  /// /// ///  /  /// ///  /  /// /// ///  / /
  /  ||/ ||/  /  ||/ ||/ ||/  /  ||/ ||/  /  ||/ ||/ ||/  / /
 /___/___/___/___/___/___/___/___/___/___/___/___/___/___/ /
 |___|___|___|___|___|___|___|___|___|___|___|___|___|___|/
        \   /                                 \   /
         | ||                                  | ||
         | ||                                  | ||
         |_|/                                  |_|/
*/
//check null or 0 first,
//then generate sequence start from 0, count up to 12
//x(num in sequence) and y(note in notes) are current elements.
//the notes in base scale list are 0, 2, 4, 5, 7, 9, 11 (start from 0)
//find the difference between y and x, get remainder by moding 12(current octave), add 12 then mod again(for next tonic scale/octave)
//if the any result contains inside the base scale list, return a bool value.

using System.Linq;

public class Kata {
    public static bool IsTune(int[] notes) => 
      notes != null && notes.Length > 0 && 
      Enumerable.Range(0,12)
                .Any(x => notes.All(y => new int[]{0, 2, 4, 5, 7, 9, 11}
                .Contains(((y-x) % 12 + 12) % 12)));
}


//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
[TestFixture]
public class IntTunesHiddenTests
{
    [Test]
    public void ExampleTests()
    {
        Assert.AreEqual(true, Kata.IsTune(new int[]{1, 3, 6, 8, 10, 12}));
        Assert.AreEqual(true, Kata.IsTune(new int[]{1, 3, 6, 8, 10, 12, 13, 15}));
        Assert.AreEqual(true, Kata.IsTune(new int[]{1, 6, 3}));
        Assert.AreEqual(false, Kata.IsTune(new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12}));
    }
    
    [Test]
    public void EdgeCaseTests() {
        Assert.AreEqual(false, Kata.IsTune(null));
        Assert.AreEqual(false, Kata.IsTune(new int[]{}));
        Assert.AreEqual(true, Kata.IsTune(new int[]{1}));
    }
    
    [Test]
    public void HardTests() {
        Assert.AreEqual(true, Kata.IsTune(new int[]{3, 5, 6, 8, 10, 12}));
        Assert.AreEqual(true, Kata.IsTune(new int[]{-11, -9, -7, -6, -4, -2, 0, 1, 3, 6, 8, 10, 12, 13, 15}));
        Assert.AreEqual(true, Kata.IsTune(new int[]{-4, -2, 0, 1, 3, 6, 8, 10, 12, 13, 15}));
    }
    
    [Test]
    public void DoesntChangeInputTest() {
        int[] original = new int[]{-11, -9, -7, -6, -4, -2, 0, 1, 3, 6, 8, 10, 12, 13, 15};
        int[] copy = (int[])original.Clone();
        Kata.IsTune(copy);
        Assert.AreEqual(true, original.Zip(copy, (x, y) => x == y).All(x => x));
    }
    
    // Set up for random tests
    public static bool CorrectSolution(int[] notes)
    {
        if(notes == null || notes.Length == 0) return false;
            
        int[] notesInKeyOfZero = {0, 2, 4, 5, 7, 9, 11};
        for(var root = 0; root < 12; root++) {
            if ( notes.All(x => notesInKeyOfZero.Contains(PositiveMod(x - root, 12))) )
            {
                return true;
            }
        }
        return false;
    }
    public static int PositiveMod(int x, int modulo)
    {
        return (x%modulo + modulo)%modulo;
    }
    //End of set up for random tests
    
    [Test]
    public void RandomTests() {
        var rnd = new Random();
        var numberOfRandomTests = 1000;
        for(var i = 0; i < numberOfRandomTests; i++)
        {
            var length = rnd.Next(3, 11);
            var randomNotes = new int[length];
            for(var notesIndex = 0; notesIndex < length; notesIndex++)
            {
                randomNotes[notesIndex] = rnd.Next(-1000, 1001);
            }
            Assert.AreEqual(Kata.IsTune(randomNotes), CorrectSolution(randomNotes));
        }
    }
}
