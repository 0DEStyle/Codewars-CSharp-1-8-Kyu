/*Challenge link:https://www.codewars.com/kata/628e3ee2e1daf90030239e8a/train/csharp
Question:
Task
Write a function that checks if two non-negative integers make an "interlocking binary pair".

Interlock ?
numbers can be interlocked if their binary representations have no 1's in the same place
comparisons are made by bit position, starting from right to left (see the examples below)
when representations are of different lengths, the unmatched left-most bits are ignored
Examples
a = 9, b = 4
Stacking representations shows how they can interlock.

 9    1001
 4     100
Here, no 1's share any position, so the function returns true.

a = 3, b = 6
These representations do not interlock.

 3      11
 6     110
Finding they both have a 1 in the same position, the function returns false.

Input
Two non-negative integers.

Output
Boolean true or false whether or not these integers are interlockable.

Enjoy!
Consider one of the following kata to solve next:

Playing With Toy Blocks ~ Can you build a 4x4 square?
Four Letter Words ~ Mutations
Crossword Puzzle! (2x2)
Is Sator Square?
Nota Bene:
This kata is accepting of translations for any languages other than: Java, JavaScript, CoffeeScript, TypeScript, Go, Groovy, Julia, Dart, and Kotlin; as those are currently underway by the author. Thank you!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
//a AND b, if result is all zero then it's true, else false
public static class Kata{
    public static bool Interlockable(ulong a, ulong b) => (a & b) == 0; 
}

//****************Sample Test*****************
namespace Interlockable 
{
    using NUnit.Framework;
    using System.Linq;
    using System;

    [TestFixture]
    public class Tester
    {
        [Test]
        public void FixedTests()
        { 
            Object[][] tests =
            {
                new Object[] {true,  9UL, 4UL},
                new Object[] {false, 5UL, 6UL},
                new Object[] {true,  2UL, 5UL},
                new Object[] {false, 7UL, 1UL},
                new Object[] {true,  0UL, 8UL},

                new Object[] {true,  0UL, 0UL},
                new Object[] {true,  0UL, 1UL},
                new Object[] {false, 1UL, 1UL},
                new Object[] {true,  1UL, 2UL},
                new Object[] {false, 2UL, 2UL},

                new Object[] {false, 57UL, 69UL},
                new Object[] {true,  81UL, 14UL},
                new Object[] {true,  68UL, 58UL},
                new Object[] {false, 15UL, 49UL},
                new Object[] {false, 21UL, 97UL},

                new Object[] {true,  532UL, 448UL},
                new Object[] {false, 384UL, 259UL},
                new Object[] {true,  384UL, 564UL},
                new Object[] {false, 750UL, 954UL},
                new Object[] {true,  212UL, 256UL},

                new Object[] {true,  8749UL, 7634UL},
                new Object[] {false, 2104UL, 1514UL},
                new Object[] {false, 6168UL, 7572UL},
                new Object[] {true,  5386UL, 2084UL},
                new Object[] {false, 5562UL, 8953UL},

                new Object[] {false,      470996387497838UL,      100749658945681UL},
                new Object[] {true,      6610039577326596UL,        4622375373819UL},
                new Object[] {false,   108225895783146480UL,      423445227166739UL},
                new Object[] {true,   6148914691236517205UL, 12297829382473034410UL},
                new Object[] {false, 13835058055282163710UL,  4611686020574871553UL},
            };
            foreach(Object[] test in tests)
            {
                bool expected = (bool)test[0];
                ulong a = (ulong)test[1];
                ulong b = (ulong)test[2];
                bool submitted = Kata.Interlockable(a, b);
                string message = "a = " + a + "\n  b = " + b;
                Assert.AreEqual(expected, submitted, message);
            }
        }
        private static Random rnd = new Random();
        public static bool Solution(ulong a, ulong b)
        {
            return (a & b) == 0;
        }
        private static void shuffle(bool[] tests)
        {
            for (int i = 0; i < tests.Length - 1; i++)
            {
                int j = rnd.Next(i, tests.Length);
                bool temp = tests[i];
                tests[i] = tests[j];
                tests[j] = temp;
            }
        }
        private static ulong[] GenUlongs(bool expected)
        {
            char[] aBits = Enumerable.Repeat('0', 64).ToArray();
            char[] bBits = Enumerable.Repeat('0', 64).ToArray();
            for(int i=0; i<64; i++)
            {
                if(rnd.Next(0, 2) == 1)
                {
                    if(rnd.Next(0, 2) == 1)
                    {
                        aBits[i] = '1';
                    }
                }
                else if(rnd.Next(0, 2) == 1)
                {
                    bBits[i] = '1';
                }
            }          
            int larger = rnd.Next(0, 64) + 1;
            int smaller = rnd.Next(0, larger) + 1;
            int larger_diff = 64 - larger;
            int smaller_diff = 64 - smaller;          
            for(int i=0; i<larger_diff; i++)
            {
                aBits[i] = '0';
            }
            for(int i=0; i<smaller_diff; i++)
            {
                bBits[i] = '0';
            }
            if(!expected)
            {
                int div = rnd.Next(0, smaller) + 1;
                int ones = rnd.Next(0, smaller / div) + 1;              
                while(ones --> 0)
                {
                    int index = rnd.Next(0, smaller) + smaller_diff;
                    aBits[index] = '1';
                    bBits[index] = '1';
                }
            }
            ulong a = Convert.ToUInt64(new string(aBits), 2);
            ulong b = Convert.ToUInt64(new string(bBits), 2);
            if(rnd.Next(0, 2) == 1)
            {
                ulong swapper = a;
                a = b;
                b = swapper;
            }
            ulong[] numbers = new ulong[2];
            numbers[0] = a;
            numbers[1] = b;
            return numbers;
        }
        [Test]
        public void RandomTests()
        {
            int count = 100;
            bool[] tests = new bool[count];
            for(int i=0; i<count; i++)
            {
                tests[i] = i < 50;
            }
            shuffle(tests);
            int zedCap = 0;
            while(count --> 0)
            {   
                bool expected = tests[count];
                ulong a = 0;
                ulong b = 0;
                while(a == 0 || b == 0)
                {
                    ulong[] numbers = GenUlongs(expected);
                    a = numbers[0];
                    b = numbers[1];
                    if(a == 0 || b == 0)
                    {
                        zedCap += 1;
                    }
                    if(zedCap % 7 == 0)
                    {
                        break;
                    }
                }
                bool submitted = Kata.Interlockable(a, b);
                string message = "a = " + a + "\n  b = " + b;
                Assert.AreEqual(expected, submitted, message);
            }
        }
    }
}
