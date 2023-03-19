/*Challenge link:https://www.codewars.com/kata/5a360620f28b82a711000047/train/csharp
Question:
You get any card as an argument. Your task is to return the suit of this card (in lowercase).

Our deck (is preloaded):

string[] Deck =
{
    "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣", "A♣",
    "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦", "A♦",
    "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥", "A♥",
    "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠", "A♠"
};
DefineSuit("3♣") -> return "clubs"
DefineSuit("3♦") -> return "diamonds"
DefineSuit("3♥") -> return "hearts"
DefineSuit("3♠") -> return "spades"
*/

//***************Solution********************
//check the last character in the string "card", and return the result accordingly
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
namespace Solution{
    public partial class Kata{
        public static string DefineSuit(string card) => 
          card[card.Length - 1] == '♣' ?  "clubs" : 
          card[card.Length - 1] == '♦' ?  "diamonds" : 
          card[card.Length - 1] == '♥' ?  "hearts" : "spades";
    }
}

//solution 2
namespace Solution
{
    public partial class Kata
    {
        public static string DefineSuit(string card) =>
            card[^1] switch
            {
                '♣' => "clubs",
                '♦' => "diamonds",
                '♥' => "hearts",
                _ => "spades",
            };
    }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

namespace Solution
{
    [TestFixture]
    public class SolutionTests
    {
        [Test]
        public void SampleTest()
        {
            Assert.AreEqual("clubs", Kata.DefineSuit("3♣"), "Should return clubs with \"3♣\"");
            Assert.AreEqual("spades", Kata.DefineSuit("Q♠"), "Should return spades with \"Q♠\"");
            Assert.AreEqual("diamonds", Kata.DefineSuit("9♦"), "Should return diamonds with \"9♦\"");
            Assert.AreEqual("hearts", Kata.DefineSuit("J♥"), "Should return hearts with \"J♥\"");
        }

        [Test]
        public void FixedTest()
        {
            foreach (var card in Deck)
            {
                var expected = Solution(card);
                var message = FailureMessage(card, expected);
                var actual = Kata.DefineSuit(card);

                Assert.AreEqual(expected, actual, message);
            }
        }

        private static string Solution(string card)
        {
            return card.Last() switch
            {
                '♣' => "clubs",
                '♦' => "diamonds",
                '♥' => "hearts",
                '♠' => "spades",
                _ => throw new ArgumentException()
            };
        }

        private static readonly Random Random = new Random();

        private static readonly string[] Deck =
        {
            "2♣", "3♣", "4♣", "5♣", "6♣", "7♣", "8♣", "9♣", "10♣", "J♣", "Q♣", "K♣", "A♣",
            "2♦", "3♦", "4♦", "5♦", "6♦", "7♦", "8♦", "9♦", "10♦", "J♦", "Q♦", "K♦", "A♦",
            "2♥", "3♥", "4♥", "5♥", "6♥", "7♥", "8♥", "9♥", "10♥", "J♥", "Q♥", "K♥", "A♥",
            "2♠", "3♠", "4♠", "5♠", "6♠", "7♠", "8♠", "9♠", "10♠", "J♠", "Q♠", "K♠", "A♠"
        };

        private static string RandomCard()
        {
            return Deck[Random.Next(Deck.Length)];
        }

        private static string FailureMessage(string card, string value)
        {
            return $"Should return \"{value}\" with \"{card}\"";
        }

        [Test]
        public void RandomTest()
        {
            for (var i = 0; i < 100; i++)
            {
                var card = RandomCard();
                var expected = Solution(card);
                var message = FailureMessage(card, expected);
                var actual = Kata.DefineSuit(card);

                Assert.AreEqual(expected, actual, message);
            }
        }
    }
}
