/*Challenge link:https://www.codewars.com/kata/564e21ba7cd824845b000097/train/csharp
Question:
Knight vs Bishop
If you are not familiar with chess game you can learn more here.

You will be provided with two object arrays. Each of them contains an integer and a string which represent the positions of the pieces on the chess board (e.g. [4, "C"] and [6, "D"]).

Implement a function which returns:

"Knight" if the knight can capture the bishop
"Bishop" if the bishop can capture the knight
"None" if both pieces are safe
Check the test cases and Happy coding :)
*/

//***************Solution********************

//[4, "C"] => [int, string]
//find absolute value between knight and bishop position for both x and y axis
//if x and y are the same, return "Bishop"
//if x + y is 3(knight move 3 cells at a time), and x and y are not zero, return "Knight"
//else return "None"
using static System.Math;

public class KnightBishop{
        public static string KnightVsBishop(object[] knightPosition, object[]bishopPosition){
          int x = Abs((int)knightPosition[0] - (int)bishopPosition[0]);
          int y = Abs(((string)knightPosition[1])[0] - ((string)bishopPosition[1])[0]);
          return x == y ? "Bishop" :
                 x + y == 3 && x != 0 && y != 0 ?
                 "Knight" : "None";
        }    
    }

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
    public class KnightBishopTest
    {
        [Test]
        public void KnightTest()
        {
            object[] bishopPosition = { 4, "C" };
            object[] knightPosition = {6, "D"};
            StringAssert.AreEqualIgnoringCase("Knight",KnightBishop.KnightVsBishop(knightPosition,bishopPosition));
        }
        
        [Test]
        public void BishopTest()
        {
            object[] bishopPosition = { 2, "G" };
            object[] knightPosition = { 6, "C" };
            StringAssert.AreEqualIgnoringCase("Bishop", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void TestOne()
        {
            object[] bishopPosition = { 5,"E" };
            object[] knightPosition = { 6,"E" };
            StringAssert.AreEqualIgnoringCase("None", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void TestTwo()
        {
            object[] bishopPosition = { 5,"E" };
            object[] knightPosition = { 5,"F" };
            StringAssert.AreEqualIgnoringCase("None", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void TestThree()
        {
            object[] bishopPosition = { 1,"A" };
            object[] knightPosition = { 4,"A" };
            StringAssert.AreEqualIgnoringCase("None", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void TestFour()
        {
            object[] bishopPosition = { 1,"A" };
            object[] knightPosition = { 1,"D" };
            StringAssert.AreEqualIgnoringCase("None", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void NoneTest()
        {
            object[] bishopPosition = { 2, "F" };
            object[] knightPosition = { 7, "B" };
            StringAssert.AreEqualIgnoringCase("None", KnightBishop.KnightVsBishop(knightPosition, bishopPosition));
        }
        
        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 30)] double d)
        {
            KnightBishopRandom knightBishopRandom = new KnightBishopRandom((int)d * 10000);
            List<object[]> positions = knightBishopRandom.PositionList();
            StringAssert.AreEqualIgnoringCase(KnightBishop19November.KnightVsBishop(positions[0], positions[1]),
                KnightBishop.KnightVsBishop(positions[0], positions[1]),
                string.Format("Knight Position: {0},{1} and Bishop Position: {2},{3} --> {4}", positions[0][0],
                    positions[0][1], positions[1][0], positions[1][0],
                    KnightBishop19November.KnightVsBishop(positions[0], positions[1])));
        }
    }
