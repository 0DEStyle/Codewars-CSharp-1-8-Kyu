/*Challenge link:https://www.codewars.com/kata/580ed88494291dd28c000019/train/csharp
Question:
When no more interesting kata can be resolved, I just choose to create the new kata, to solve their own, to enjoy the process --myjinxin2015 said

Description:
John learns to play poker with his uncle. His uncle told him: Poker to be in accordance with the order of "2 3 4 5 6 7 8 9 10 J Q K A". The same suit should be put together. But his uncle did not tell him the order of the four suits.

Give you John's cards and Uncle's cards(two string john and uncle). Please reference to the order of Uncle's cards, sorting John's cards.

Examples
For Python:

Suits are defined as S, D, H, C.

sort_poker("D6H2S3D5SJCQSKC7D2C5H5H10SA","S2S3S5HJHQHKC8C9C10D4D5D6D7")
should return "S3SJSKSAH2H5H10C5C7CQD2D5D6"
sort_poke("D6H2S3D5SJCQSKC7D2C5H5H10SA","C8C9C10D4D5D6D7S2S3S5HJHQHK") 
should return "C5C7CQD2D5D6S3SJSKSAH2H5H10" 
*/

//***************Solution********************
/*
⠀⠀⠀⠀⢀⡆⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⣀⣀⣀⡏⢱⣀⣀⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠠⠀⠀⠀
⠈⠛⢏⡉⡀⠀⠁⡔⠊⠁⠀⠀⠀⠀⠀⢀⣠⣤⡤⠤⣀⣀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⢀⣿⠔⠒⠢⣽⡄⠀⠀⠀⠀⣠⡖⣿⠃⠁⠀⣀⣀⣀⣉⣆⣀⠀⠀⠐⠀⠂
⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⣼⡽⡁⠁⢀⣻⣿⡿⠿⠋⢿⡉⠉⠉⢷⡄⠀⠀(<3)
⠀⠀⠀⠀⠀⠀⠀⢀⣖⣶⡿⣿⡯⠁⠀⢴⡿⠟⠉⠀⠀⠀⠀⠉⠉⠉⢹⣧⠀⠀
⠀⠀⠀⠀⠀⠀⠀⣿⠞⠁⢠⡿⠁⠀⠀⠸⣿⣦⣄⣀⣀⣀⣀⣀⣀⣄⣺⡟⠀⠀
⠀⠀⠀⠀⠀⠀⠈⡏⠀⡴⢸⡇⠀⠀⠀⠀⠈⠙⠛⠛⠛⠓⠛⠛⠛⣻⡏⠁⠀⠀
⠀⠀⠀⠀⠀⠀⠀⡇⡌⠀⢸⣟⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⡇⠀⠂⠀
⠀⠀⠀⠀⠀⠀⠀⣗⣇⠀⢸⣟⣧⡀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⣽⡇⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⡟⡗⡱⢸⣷⣯⣇⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⢣⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠘⠻⠾⠷⢿⡧⢟⣟⣄⠀⠀⠀⠀⠀⣀⡀⠀⢖⢿⣿⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠱⣒⣓⣯⡖⣄⡀⠀⣾⣿⣿⡄⠁⢸⣿⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⠷⣕⣌⣽⣺⣎⡿⠁⢹⣷⣶⣟⡝⠂⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀

2 3 4 5 6 7 8 9 10 J Q K A

suit S, D, H, C.

"♦6♥2♠3♦5♠J♣Q♠K♣7♦2♣5♥5♥10♠A"             john
"♠2♠3♠5     ♥J♥Q♥K  ♣8♣9♣10  ♦4♦5♦6♦7"   uncle
to  V        V          V       V
"♠3♠J♠K♠A  ♥2♥5♥10  ♣5♣7♣Q  ♦2♦5♦6"

"♦6♥2♠3♦5♠J♣Q♠K♣7♦2♣5♥5♥10♠A"            john
"♣8♣9♣10  ♦4♦5♦6♦7  ♠2♠3♠5  ♥J♥Q♥K"     uncle
to V          V       V       V
"♣5♣7♣Q  ♦2♦5♦6  ♠3♠J♠K♠A  ♥2♥5♥10"

same suit order
*/    
using System;
using System.Linq;
using System.Collections.Generic;

namespace Solution{
  public class Kata{
    //fixed list
    private static string[] cardOrder = {"2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A"};
    private static char[] cardSuit = {'♦', '♥', '♠', '♣'};
    
    //get substring of card
    private static IEnumerable<string> cardChar(string cards){
      int i = 0, j = 0;
      while(i != -1){
        j = cards.IndexOfAny(cardSuit, i + 1);
        yield return j == -1 ? 
          cards.Substring(i) : 
          cards.Substring(i, j - i);
        i = j;
      }
    }
    
    public static string SortPoker(string john, string uncle){
      
      //get the suit order from uncle
      var uncleOrder = cardChar(uncle).Select(x => x[0])
                                      .Distinct()
                                      .ToArray();
      //sort john's card by uncle's card suit, then by card order.
      var johnNewOrder = cardChar(john).OrderBy(x => Array.IndexOf(uncleOrder, x[0]))
                                   .ThenBy(x => Array.IndexOf(cardOrder, x.Substring(1)))
                                   .ToArray();
      
      //format string and return result.
      return string.Concat(johnNewOrder);
    }
    
    
  }
}

//solution 2
using System.Linq;
using System;
namespace Solution
{
  public class Kata
  {
    public static string SortPoker(string john, string uncle) => 
      string.Concat("♠♥♦♣".OrderBy(suit => uncle.IndexOf(suit)).SelectMany(s => 
        john.Where((v,i) => Char.IsLetterOrDigit(v) && john[i-1] == s)
        .OrderBy(v => "234567891JQKA".IndexOf(v)).Select(v => $"{s}{v}") )).Replace("1","10");
  }
}

//solution 3
namespace Solution
{
  using System.Text.RegularExpressions;
  using System.Linq;
  using System;
  public class Kata
  {
        public static string SortPoker(string john, string uncle)
        {
            var order = Regex.Split(uncle, @"[0-9]+|[JQKA]").Where(x => x != "").GroupBy(x => x).Select(x => x.Key).ToArray();
            var table = new[] { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            return string.Concat(Regex.Matches(john, @"([♦♥♠♣])([0-9]+|[JQKA])").Cast<Match>()
                .OrderBy(x => Array.IndexOf(order, x.Groups[1].Value))
                .ThenBy(x => Array.IndexOf(table, x.Groups[2].Value)).Select(x => x.Value));
        }
  }
}
//****************Sample Test*****************
namespace Solution {
using NUnit.Framework;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;



  [TestFixture]
  public class SolutionTest
  {
  
  
  
  
    [Test]
    public void SampleTestsEdgeCases()
    {
            Assert.AreEqual(Kata.SortPoker("♦6♥2♠3♦5♠J♣Q♠K♣7♦2♣5♥5♥10♠A", "♠2♠3♠5♥J♥Q♥K♣8♣9♣10♦4♦5♦6♦7"), "♠3♠J♠K♠A♥2♥5♥10♣5♣7♣Q♦2♦5♦6");
            Assert.AreEqual(Kata.SortPoker("♦6♥2♠3♦5♠J♣Q♠K♣7♦2♣5♥5♥10♠A", "♣8♣9♣10♦4♦5♦6♦7♠2♠3♠5♥J♥Q♥K"), "♣5♣7♣Q♦2♦5♦6♠3♠J♠K♠A♥2♥5♥10");
    }
    
    
    
    
            public class rank
        {
            public int rankValue { get; set; }
            public string rankSymbol { get; set; }

            public rank(int Item1, string Item2)
            {
                this.rankValue = Item1;
                this.rankSymbol = Item2;
            }
        }

        public class Card
        {
            public string suit { get; set; }
            public rank rank { get; set; }

            public Card(string input)
            {
                this.suit = input[0].ToString();
                this.rank = new rank(ranks[input.Substring(1)], input.Substring(1));
            }
        }


        // Helper Methods!
        private static List<Card> OrganizeCards(string s, string suit) => Regex.Matches(s, suit + "[\\d\\w]{1,2}").Cast<Match>().Select(x => new Card(x.Value.ToString())).OrderBy(x => x.rank.rankValue).ToList();
        private static List<string> GetOrder(string s) => Regex.Matches(s, "[^\\d\\w]").Cast<Match>().Select(x => x.ToString()).Distinct().ToList();
        // Main!!!
        public static string _SortPoker(string john, string uncle)
        {

            var list = new List<Card>();
            var uncleOrder = GetOrder(uncle);
            for (int i = 0; i < uncleOrder.Count; i++)
            {
                switch (uncleOrder[i])
                {
                    case "♠":
                        list.AddRange(OrganizeCards(john, "♠"));
                        break;
                    case "♣":
                        list.AddRange(OrganizeCards(john, "♣"));
                        break;
                    case "♦":
                        list.AddRange(OrganizeCards(john, "♦"));
                        break;
                    case "♥":
                        list.AddRange(OrganizeCards(john, "♥"));
                        break;
                }
            }

            return list.Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c, n) => c + n);
        }
    
    
    
        // RankData! in Dictionary Format!!!
        private static Dictionary<string, int> ranks = new Dictionary<string, int>
        {
            { "2",2}, {"3", 3 },{"4", 4 }, {"5", 5 },{"6", 6 },{"7", 7 },{"8", 8 },{"9", 9 },{"10", 10 },{"J", 11 },{"Q", 12 },{"K", 13 },{"A", 14 }
        };

        public static Random rnd = new Random();

        public string[] shuffle()
        {
            var newOrder = new HashSet<string>();
            var suits = new string[] { "♦", "♥", "♠", "♣" };
            while (newOrder.Count() < 4)
            {
                newOrder.Add(suits[rnd.Next(0, 4)]);
            }
            return newOrder.ToArray();
        }


        public string[] spades = "2,3,4,5,6,7,8,9,10,J,Q,K,A".Split(',').Select(x =>  '♥' + x).ToArray();
        public string[] clubs = "2,3,4,5,6,7,8,9,10,J,Q,K,A".Split(',').Select(x =>  '♣' + x).ToArray();
        public string[] diamonds = "2,3,4,5,6,7,8,9,10,J,Q,K,A".Split(',').Select(x => '♦' + x).ToArray();
        public string[] hearts = "2,3,4,5,6,7,8,9,10,J,Q,K,A".Split(',').Select(x => '♥' + x).ToArray();
    
    
    
    [Test]
    public void RandomTests()
    {
                for (int i = 0; i < 1; i++)
            {
                var shuffleOrder = shuffle();
                var UncleCardDeck = new List<Card>();
                string str = "";
                foreach (var item in shuffleOrder)
                {
                    switch (item)
                    {
                        case "♠":
                            var s = new List<Card>();
                            Enumerable.Range(0,3).ToList().ForEach(x => s.Add(new Card(spades[rnd.Next(0, 13)])));
                            UncleCardDeck.AddRange(s);
                            str += s.OrderBy(x => x.rank.rankValue).Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c,n) => c + n);
                            break;
                        case "♣":
                            var club = new List<Card>();
                            Enumerable.Range(0, 3).ToList().ForEach(x => club.Add(new Card(clubs[rnd.Next(0, 13)])));
                            UncleCardDeck.AddRange(club);
                            str += club.OrderBy(x => x.rank.rankValue).Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c, n) => c + n);
                            break;
                        case "♦":
                            var dia = new List<Card>();
                            Enumerable.Range(0, 3).ToList().ForEach(x => dia.Add(new Card(diamonds[rnd.Next(0, 13)])));
                            UncleCardDeck.AddRange(dia);
                            str += dia.OrderBy(x => x.rank.rankValue).Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c, n) => c + n);
                            break;
                        case "♥":
                            var heart = new List<Card>();
                            Enumerable.Range(0, 4).ToList().ForEach(x => heart.Add(new Card(hearts[rnd.Next(0, 13)])));
                            UncleCardDeck.AddRange(heart);
                            str += heart.OrderBy(x => x.rank.rankValue).Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c, n) => c + n);
                            break;
                    }
                    var uncle = str;
                    var john = UncleCardDeck.Select(x => x.suit + x.rank.rankSymbol).Aggregate("", (c, n) => c + n);
                    Assert.AreEqual(Kata.SortPoker(john, uncle), _SortPoker(john, uncle));
                }

            }
    }
    
    
  }
}
