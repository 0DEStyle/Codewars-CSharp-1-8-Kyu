/*Challenge link:https://www.codewars.com/kata/586423aa39c5abfcec0001e6/train/csharp
Question:
A famous casino is suddenly faced with a sharp decline of their revenues. They decide to offer Texas hold'em also online. Can you help them by writing an algorithm that can rank poker hands?

Task:

Create a poker hand that has a constructor that accepts a string containing 5 cards:
PokerHand hand = new PokerHand("KS 2H 5C JD TD");
The characteristics of the string of cards are:
A space is used as card seperator
Each card consists of two characters
The first character is the value of the card, valid characters are:
`2, 3, 4, 5, 6, 7, 8, 9, T(en), J(ack), Q(ueen), K(ing), A(ce)`
The second character represents the suit, valid characters are:
`S(pades), H(earts), D(iamonds), C(lubs)`

The poker hands must be sortable by rank, the highest rank first:
var hands = new List<PokerHand> 
{ 
    new PokerHand("KS 2H 5C JD TD"),
    new PokerHand("2C 3C AC 4C 5C")
};
hands.Sort();
Apply the Texas Hold'em rules for ranking the cards.
There is no ranking for the suits.
An ace can either rank high or rank low in a straight or straight flush. Example of a straight with a low ace:
`"5C 4D 3C 2S AS"`

Note: there are around 25000 random tests, so keep an eye on performances.
*/

//***************Solution********************
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⡤⠶⠒⠛⠋⠉⠉⠉⠉⠉⠉⠙⠓⠲⠦⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡴⠞⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠳⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠹⣆⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠁⠀⠀⠀⠀⠀⠀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢳⠀⠀⠀⠀⠀⠀⢹⡄⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡼⠁⠀⠀⠀⠀⠀⠀⠀⠈⢣⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⠈⡇⢀⠀⠀⠀⠀⠈⡇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠘⣇⠁⡞⠀⠀⠀⠀⠀⣿⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⢀⡾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⢰⡃⠀⠀⠀⠀⠀⠈⢷⠀⠀⠀⠀⠀    https://en.wikipedia.org/wiki/Texas_hold_%27em#Rules
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⠀⠀⠸⣇⠀⠀⠀⠀⠀⣀⣤⣾⡇⠀⠏⢨⠓⢠⣄⠀⠀⠀⠀⣼⠃⠀⠀⠀⠀ / 
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢦⣀⡀⣿⣋⣥⣤⣤⣝⣦⠀⣼⣿⣿⣯⣟⣶⡀⡾⠃⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢹⡆⠀⠀⠀⠀⠀⠀⠀⡀⠀⠀⠒⠃⢧⣀⡘⠛⣋⣴⠇⠀⠘⢯⡈⠻⢟⡻⠿⣇⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣆⠀⠀⠀⠀⠀⣼⠁⠀⠀⠀⠀⠀⠀⢉⣩⠽⠋⠀⠀⠀⢈⡿⠭⡍⠀⠀⠘⡇⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠳⣄⡀⠀⠀⢷⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡄⠀⠀⠀⢸⠃⠀⠀⠀⠀⣰⡇⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⢦⡬⠷⣤⣀⠀⠀⠀⠀⠀⢠⡞⣁⠀⠀⠀⢸⣷⠀⠀⣠⡾⠋⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣸⠁⠀⡇⠈⠉⠙⡆⠀⢠⠟⠖⠿⢷⡀⠀⣠⢿⡀⢸⠋⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣰⠏⠀⠀⡇⠀⠀⠀⡇⠀⡞⠀⠀⢀⣠⣍⣩⣅⠀⡇⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣤⠏⠀⠀⠀⡇⠀⠀⠀⠀⠰⠇⢀⣴⣛⣡⣏⣱⣏⡇⠁⣾⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣤⣴⠶⠒⠛⣻⠟⠉⣱⠏⠀⠀⠀⢸⠃⠀⠀⠀⠀⠀⠀⠀⠘⢧⣀⠀⣀⡼⠁⠀⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⢀⣠⡴⠞⠛⠉⠀⠀⠀⠀⢰⠏⠀⠀⠁⠀⠀⠀⠀⢸⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠨⠭⠭⠀⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣀⣤⠾⠟⠁⠀⠀⠀⠀⠀⠀⠀⢠⡟⠀⠀⠀⠀⠀⠀⠀⠀⠸⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠒⠲⢤⡀⠀⠈⠙⡆⠀⠀⠀⠀⠀⠀⠀
⡾⠛⣁⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀⠘⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠦⣄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⢀⣷⣄⠀⠀⠀⠀⠀⠀
⠚⠛⠉⠉⠉⠙⠛⠶⢦⣀⠀⠀⠀⠀⠸⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠓⠦⢤⣀⣀⠀⢀⣀⣤⢷⠶⠚⠋⠁⠹⡗⢦⣄⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⢷⡀⠀⠀⠀⠹⣄⠀⡴⢤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⠏⠉⠉⠀⠀⣸⠃⠀⠀⠀⠀⠀⠀⠙⢷⣄⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣿⣆⠆⠀⠀⠙⢦⣙⣣⢇⠤⡄⠀⠀⠀⠀⠀⠀⠀⠈⠉⣁⠀⠀⠀⢀⡼⣣⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣆
*/
/* 
1)There is no ranking for the suits.

2) sort handValues from high to low
straight flush
straight A5(low) + flush
4 of a kind            
full house        
flush          
straight
straight A5(low)         
3 of a kind            
2 pairs           
pair              
high card             
*/  
using System;
using System.Linq;
using System.Collections.Generic;

//class as Icomparator
public class PokerHand : IComparable {
  private string Score;
  
  //card rank by index      BCDEFGHIJKLMA
  //                    A + 23456789TJQKA
  private char rank(string cardChar) => (char)('A'+"23456789TJQKA".IndexOf(cardChar[0]));
  
  //comparator hand and score
  public int CompareTo(object hands) => ((PokerHand)hands).Score.CompareTo(Score);
  
  //main
  public PokerHand(string hands){ Score = handValues(hands.Split().OrderByDescending(rank).ToList()); 
    //uncomment to check result 
    //Console.WriteLine($"{hands} {Score}");
  }
                                 
  //hand values logic
  private string handValues(List<string> cards){
    //prefix holder
    var firstLetter = "";    
    
    //setting ranks order
    var gRank = cards.GroupBy(rank).OrderBy(x => -x.Count());
    var gCount = string.Concat(gRank.Select(x => x.Count()));
    var groupRanks = string.Concat(gRank.Select(x => rank(x.First())));
    
    //check hand values for lower straight, straight, flush
    var checkStraightA5Low = string.Concat(cards.Select(rank)) == "MDCBA";
    var checkStraight = checkStraightA5Low || !cards.Where((x, i) => rank(x) != rank(cards.First()) - i).Any(); 
    var checkFlush = cards.GroupBy(x => x.Last()).Count() == 1;
    
    //because
    //card rank by index
    //    BCDEFGHIJKLMA
    //A + 23456789TJQKA
    //so any letters after M to sort order, see handValues order at top comment 2)
    if (gCount == "2111") firstLetter = "R";
    if (gCount == "221") firstLetter = "S";
    if (gCount == "311") firstLetter = "T";
    if (checkStraight) firstLetter = "U";
    if (checkFlush) firstLetter = "V";
    if (gCount == "32") firstLetter = "W";
    if (gCount == "41") firstLetter = "X";
    if (checkStraight && checkFlush) firstLetter = "Y";

    return firstLetter + (checkStraightA5Low ? groupRanks.Replace("M", "") : groupRanks);
  }
}

//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;

[TestFixture]
public class PokerTests
{
    private List<string> _hands = new List<string> {
                "JH AH TH KH QH", // royal flush
                "JH 9H TH KH QH", // straight flush
                "5C 6C 3C 7C 4C", // straight flush
                "2D 6D 3D 4D 5D", // straight flush
                "2C 3C AC 4C 5C", // straight flush
                "JC KH JS JD JH", // 4 of a kind
                "JC 7H JS JD JH", // 4 of a kind
                "JC 6H JS JD JH", // 4 of a kind
                "KH KC 3S 3H 3D", // full house
                "2H 2C 3S 3H 3D", // full house
                "3D 2H 3H 2C 2D", // full house
                "JH 8H AH KH QH", // flush
                "4C 5C 9C 8C KC", // flush
                "3S 8S 9S 5S KS", // flush
                "8C 9C 5C 3C TC", // flush
                "QC KH TS JS AH", // straight
                "JS QS 9H TS KH", // straight
                "6S 8S 7S 5H 9H", // straight
                "3C 5C 4C 2C 6H", // straight
                "2C 3H AS 4S 5H", // straight
                "AC KH QH AH AS", // 3 of a kind
                "7C 7S KH 2H 7H", // 3 of a kind
                "7C 7S 3S 7H 5S", // 3 of a kind
                "AS 3C KH AD KC", // 2 pairs
                "3C KH 5D 5S KC", // 2 pairs
                "5S 5D 2C KH KC", // 2 pairs
                "3H 4C 4H 3S 2H", // 2 pairs
                "AH 8S AH KC JH", // pair
                "KD 4S KD 3H 8S", // pair
                "KC 4H KS 2H 8D", // pair
                "QH 8H KD JH 8S", // pair
                "8C 4S KH JS 4D", // pair
                "KS 8D 4D 9S 4S", // pair
                "KD 6S 9D TH AD",
                "TS KS 5S 9S AC",
                "JH 8S TH AH QH",
                "TC 8C 2S JH 6C",
                "2D 6D 9D TH 7D",
                "9D 8H 2C 6S 7H",
                "4S 3H 2C 7S 5H" };
        
    [Test]
    public void PokerHandSortTest()
    {
        var expected = new List<PokerHand> {
            new PokerHand("KS AS TS QS JS"),
            new PokerHand("2H 3H 4H 5H 6H"),
            new PokerHand("AS AD AC AH JD"),
            new PokerHand("JS JD JC JH 3D"),
            new PokerHand("2S AH 2H AS AC"),
            new PokerHand("AS 3S 4S 8S 2S"),
            new PokerHand("2H 3H 5H 6H 7H"),
            new PokerHand("2S 3H 4H 5S 6C"),
            new PokerHand("2D AC 3H 4H 5S"),
            new PokerHand("AH AC 5H 6H AS"),
            new PokerHand("2S 2H 4H 5S 4C"),
            new PokerHand("AH AC 5H 6H 7S"),
            new PokerHand("AH AC 4H 6H 7S"),
            new PokerHand("2S AH 4H 5S KC"),
            new PokerHand("2S 3H 6H 7S 9C")
        };
        var random = new Random((int)DateTime.Now.Ticks);
        var actual = expected.OrderBy(x => random.Next()).ToList();
        actual.Sort();
        for (var i = 0; i < expected.Count; i++)
            Assert.AreEqual(expected[i], actual[i], "Unexpected sorting order at index {0}", i);
    }

    [Test]
    public void RandomizedTest()
    {
        var random = new Random((int)DateTime.Now.Ticks);
        var expected = _hands.Select(x => new PokerHand(x)).ToList();
        for (var i = 0; i < 25000; i++)
        {
            var actual = expected.OrderBy(x => random.Next()).ToList();
            actual.Sort();
            for (var j = 0; j < expected.Count; j++)
                Assert.AreEqual(expected[j], actual[j], "Unexpected sorting order found at index {0}", j);
        }
    }
}
