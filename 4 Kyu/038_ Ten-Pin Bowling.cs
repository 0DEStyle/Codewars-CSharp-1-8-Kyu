/*Challenge link:https://www.codewars.com/kata/5531abe4855bcc8d1f00004c/train/csharp
Question:
Ten-Pin Bowling
In the game of ten-pin bowling, a player rolls a bowling ball down a lane to knock over pins. There are ten pins set at the end of the bowling lane. Each player has 10 frames to roll a bowling ball down a lane and knock over as many pins as possible. The first nine frames are ended after two rolls or when the player knocks down all the pins. The last frame a player will receive an extra roll every time they knock down all ten pins; up to a maximum of three total rolls.

The Challenge
In this challenge you will be given a string representing a player's ten frames. It will look something like this: 'X X 9/ 80 X X 90 8/ 7/ 44' (in Java: "X X 9/ 80 X X 90 8/ 7/ 44"), where each frame is space-delimited, 'X' represents strikes, and '/' represents spares. Your goal is take in this string of frames into a function called bowlingScore and return the players total score.

Scoring
The scoring for ten-pin bowling can be difficult to understand, and if you're like most people, easily forgotten if you don't play often. Here is a quick breakdown:

Frames
In Ten-Pin Bowling there are ten frames per game. Frames are the players turn to bowl, which can be multiple rolls. The first 9 frames you get 2 rolls maximum to try to get all 10 pins down. On the 10th or last frame a player will receive an extra roll each time they get all ten pins down to a maximum of three total rolls. Also on the last frame bonuses are not awarded for strikes and spares moving forward.

In this challenge, three frames might be represented like this: 54 72 44. In this case, the player has had three frames. On their first frame they scored 9 points (5 + 4), on their second frame they scored 9 points (7 + 2) and on their third frame they scored 8 points (4 + 4). This is a very simple example of bowling scoring. It gets more complicated when we introduce strikes and spares.

Strikes
Represented in this challenge as 'X'

A strike is scored when a player knocks all ten pins down in one roll. In the first 9 frames this will conclude the players turn and it will be scored as 10 points plus the points received from the next two rolls. So if a player were to have two frames X 54, the total score of those two frames would be 28. The first frame would be worth 19 (10 + 5 + 4) and the second frame would be worth 9 (5 + 4).

A perfect game in bowling is 12 strikes in a row and would be represented like this 'X X X X X X X X X XXX' (in Java: "X X X X X X X X X XXX"). This adds up to a total score of 300.

Spares
Represented in this challenge as '/'

A spare is scored when a player knocks down all ten pins in two rolls. In the first 9 frames this will be scored as 10 points plus the next roll. So if a player were to have two frames 9/ 54, the total score of the two frames would be 24. The first frame would be worth 15 (10 + 5) and the second frame would be worth 9 (5 + 4).

For a more detailed explanation see Wikipedia:

http://en.wikipedia.org/wiki/Ten-pin_bowling#Scoring
*/

//***************Solution********************
using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class Kata{
    public static int BowlingScore(string frames){
      
      //check pattern X for Strikes or 0-9 with Spares
        Regex rgx = new Regex("X|[0-9]/");
      //Spilt string into array element by space
        string[] framesArr = frames.Split(" ");
        int score = 0;
      
        for (int i = 0; i < framesArr.Length; i++){
          if (rgx.IsMatch(framesArr[i])){
            if (i < 9)
              //2 rolls maximum to try get 10 pins down, include the first one. 
              framesArr[i] = string.Join("", framesArr.Skip(i).Take(framesArr.Length)).Substring(0, 3);
          }
          
          //change XXX to X
          char[] score_element = rgx.Replace(framesArr[i], "X").ToCharArray();
          
          foreach (char element in score_element){
            if (element == 'X')
              score += 10;
            else
              score += Convert.ToInt32(element.ToString());
          }
        }
        return score;
    }
}

//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void ExampleTests() 
        {
            Console.WriteLine("Maybe this bowler should put bumpers on...\n ");
            Assert.AreEqual(20, Kata.BowlingScore("11 11 11 11 11 11 11 11 11 11"));

            Console.WriteLine("Woah! Perfect game!");
            Assert.AreEqual(300, Kata.BowlingScore("X X X X X X X X X XXX"));
        }

        [Test]
        public void BasicTests()
        {
            Assert.AreEqual(115, Kata.BowlingScore("00 5/ 4/ 53 33 22 4/ 5/ 45 XXX"));
            Assert.AreEqual(150, Kata.BowlingScore("5/ 4/ 3/ 2/ 1/ 0/ X 9/ 4/ 8/8"));
            Assert.AreEqual(143, Kata.BowlingScore("5/ 4/ 3/ 2/ 1/ 0/ X 9/ 4/ 7/2"));
            Assert.AreEqual(171, Kata.BowlingScore("X X 9/ 80 X X 90 8/ 7/ 44"));
            Assert.AreEqual(139, Kata.BowlingScore("6/ 5/ 6/ 2/ 3/ 0/ 1/ 8/ 3/ 6/5"));
            Assert.AreEqual(20, Kata.BowlingScore("00 00 00 00 00 00 00 00 00 0/X"));
            Assert.AreEqual(40, Kata.BowlingScore("00 00 00 00 00 00 00 00 X 0/X"));
        }

        [Test]
        public void RandomTests()
        {
            var endFrame = new string[] { "XXX", "12", "1/X", "34", "53", "XX1" };
            var random = new Random();

            for (var i = 0; i < 100; i++)
            {
                var frames = new string[10];
                for (int j = 0; j < frames.Length - 1; j++)
                {
                    var first = random.Next(11);
                    var second = random.Next(10);
                    frames[j] = first == 10 ? "X" : first.ToString() + (first + second >= 10 ? "/" : second.ToString());
                }
                frames[9] = endFrame[random.Next(endFrame.Length)];

                var frame = string.Join(" ", frames);
                Assert.AreEqual(_Kata.BowlingScore(frame), Kata.BowlingScore(frame));
            }
        }

        private static class _Kata
        {
            public static int BowlingScore(string frames) 
            {
                var chars = frames.Replace(" ", "").ToCharArray();
                var rolls = new int[chars.Length];

                for (var i = 0; i < rolls.Length; i++) 
                {
                    switch (chars[i]) {
                        case 'X':
                            rolls[i] = 10;
                            break;
                        case '/':
                            rolls[i] = 10 - rolls[i - 1];
                            break;
                        default:
                            rolls[i] = (int)char.GetNumericValue(chars[i]);
                            break;
                    }
                }
                return BowlingScore(rolls);
            }

            public static int BowlingScore(int[] rolls)
            {
                var frame = 1;
                var points = 0;

                for (var i = 0; i < rolls.Length && frame <= 10; i++)
                {
                    int firstRoll = rolls[i];

                    if (firstRoll == 10)
                    {
                        points += firstRoll + rolls[i + 1] + rolls[i + 2];
                    } 
                    else 
                    {
                        var secondRoll = rolls[++i];
                        var frameRoll = firstRoll + secondRoll;

                        points += frameRoll;

                        if (frameRoll == 10)
                            points += rolls[i + 1];
                    }

                    frame++;
                }

                return points;
            }
        }
    }

}
