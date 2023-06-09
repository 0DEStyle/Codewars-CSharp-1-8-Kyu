/*Challenge link:https://www.codewars.com/kata/590adadea658017d90000039/train/csharp
Question:
Introduction
Slot machine (American English), informally fruit machine (British English), puggy (Scottish English slang), the slots (Canadian and American English), poker machine (or pokies in slang) (Australian English and New Zealand English) or simply slot (American English), is a casino gambling machine with three or more reels which spin when a button is pushed. Slot machines are also known as one-armed bandits because they were originally operated by one lever on the side of the machine as distinct from a button on the front panel, and because of their ability to leave the player in debt and impoverished. Many modern machines are still equipped with a legacy lever in addition to the button. (Source Wikipedia)

Task
You will be given three reels of different images and told at which index the reels stop. From this information your job is to return the score of the resulted reels.
Rules
1. There are always exactly three reels

2. Each reel has 10 different items.

3. The three reel inputs may be different.

4. The spin array represents the index of where the reels finish.

5. The three spin inputs may be different

6. Three of the same is worth more than two of the same

7. Two of the same plus one "Wild" is double the score.

8. No matching items returns 0.

Returns
Return an integer of the score.
Example
Initialise
Kata kata = new Kata();
string[] reel1 = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
string[] reel2 = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
string[] reel3 = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
int[] spins = new int[] { 5, 5, 5 };
int result = kata.fruit(reels, spins);
Scoring
reel1[5] == "Cherry"
reel2[5] == "Cherry"
reel3[5] == "Cherry"

Cherry + Cherry + Cherry == 50
Return
result == 50
Good luck and enjoy!
*/

//***************Solution********************

using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWars{
    public class Kata{
      
      //set up dictionary for later access
        private Dictionary<string, int> score = new Dictionary<string, int>(){
                {"Jack", 1},{"Queen", 2},{"King", 3},
                {"Bar", 4},{"Cherry", 5},{"Seven", 6},
                {"Shell", 7},{"Bell", 8},{"Star", 9},
                {"Wild", 10}
            };
      
        public int fruit(List<string[]> reels, int[] spins){
          //reels after the spins
          string[] result = reels.Select((c,i) =>c[spins[i]]).ToArray();
          
          //print some crap
          Console.WriteLine("Index of spins are:" + string.Join(" ,",spins));
          Console.WriteLine("Starting words for each reel are: " + string.Join(" ,",reels.Select((c,i) =>c[i])));
          Console.WriteLine("Reels after the spin are: " + string.Join(" ,",result));
          
          if(result.Distinct().Count() == result.Count())           //if nothing match
            return 0;
          else if(result[0] == result[1] && result[0] == result[2]) //if 3 of the same
            return score[result[0]] * 10;
          else{                                                     //check Wild Reel for double score, exclude wild itself.
            string sameReels = result[0] == result[1] ? result[1] : result[2];
            if(sameReels != "Wild" && result.Any(x => x == "Wild"))
              return score[sameReels] * 2;
            return score[sameReels];
          }
        }
    }
}

//****************Sample Test*****************
using NUnit.Framework;
using System.Collections.Generic;
using System;
using System.Linq;

namespace CodeWars
{
    [TestFixture]
    class KataTestClass
    {
        public string[] reel1R = new string[9];
        public string[] reel2R = new string[9];
        public string[] reel3R = new string[9];

        [TestCase]
        public void ExtraTest1()
        {
            Kata kata = new Kata();
            string[] reel = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            List<string[]> reels = new List<string[]> { reel, reel, reel };
            int[] spins = new int[] { 5, 5, 5 };
            Assert.AreEqual(50, kata.fruit( reels, spins));
        }

        [TestCase]
        public void ExtraTest2()
        {
            Kata kata = new Kata();
            string[] reel1 = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            string[] reel2 = new string[] { "Bar", "Wild", "Queen", "Bell", "King", "Seven", "Cherry", "Jack", "Star", "Shell" };
            string[] reel3 = new string[] { "Bell", "King", "Wild", "Bar", "Seven", "Jack", "Shell", "Cherry", "Queen", "Star" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 0, 1, 2 };
            Assert.AreEqual(100, kata.fruit(reels, spins));
        }

        [TestCase]
        public void ExtraTest3()
        {
            Kata kata = new Kata();
            string[] reel1 = new string[] { "King", "Cherry", "Bar", "Jack", "Seven", "Queen", "Star", "Shell", "Bell", "Wild" };
            string[] reel2 = new string[] { "Bell", "Seven", "Jack", "Queen", "Bar", "Star", "Shell", "Wild", "Cherry", "King" };
            string[] reel3 = new string[] { "Wild", "King", "Queen", "Seven", "Star", "Bar", "Shell", "Cherry", "Jack", "Bell" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 9, 8, 7 };
            Assert.AreEqual(10, kata.fruit(reels, spins));
        }

        [TestCase]
        public void ExtraTest4()
        {
            Kata kata = new Kata();
            string[] reel1 = new string[] { "King", "Jack", "Wild", "Bell", "Star", "Seven", "Queen", "Cherry", "Shell", "Bar" };
            string[] reel2 = new string[] { "Star", "Bar", "Jack", "Seven", "Queen", "Wild", "King", "Bell", "Cherry", "Shell" };
            string[] reel3 = new string[] { "King", "Bell", "Jack", "Shell", "Star", "Cherry", "Queen", "Bar", "Wild", "Seven" };
            List<string[]> reels = new List<string[]> { reel1, reel2, reel3 };
            int[] spins = new int[] { 0, 5, 0 };
            Assert.AreEqual(6, kata.fruit(reels, spins));
        }

        private void shuffle()
        {
            Random rnd = new Random();

            int count1 = reel1R.Length;
            for (int i=0; i<rnd.Next(100); i++)
            {
                int n1 = rnd.Next(count1);
                int n2 = rnd.Next(count1);
                string temp = reel1R[n1];
                reel1R[n1] = reel1R[n2];
                reel1R[n2] = temp;
            }

            int count2 = reel2R.Length;
            for (int i = 0; i < rnd.Next(100); i++)
            {
                int n1 = rnd.Next(count2);
                int n2 = rnd.Next(count2);
                string temp = reel2R[n1];
                reel2R[n1] = reel2R[n2];
                reel2R[n2] = temp;
            }

            int count3 = reel3R.Length;
            for (int i = 0; i < rnd.Next(100); i++)
            {
                int n1 = rnd.Next(count3);
                int n2 = rnd.Next(count3);
                string temp = reel3R[n1];
                reel3R[n1] = reel3R[n2];
                reel3R[n2] = temp;
            }
        }

        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        [TestCase]
        public void RandomTests()
        {
            Random rnd = new Random();
            Kata kata = new Kata();
            Solve solve = new Solve();
            reel1R = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            reel2R = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            reel3R = new string[] { "Wild", "Star", "Bell", "Shell", "Seven", "Cherry", "Bar", "King", "Queen", "Jack" };
            shuffle();
            Console.Write("Reel 1 = ");
            for (int i = 0; i < reel1R.Length; i++)
            {
                Console.Write(reel1R[i]+" ");
            }
            Console.Write("\nReel 2 = ");
            for (int i = 0; i < reel2R.Length; i++)
            {
                Console.Write(reel2R[i]+" ");
            }
            Console.Write("\nReel 3 = ");
            for (int i = 0; i < reel3R.Length; i++)
            {
                Console.Write(reel3R[i]+" ");
            }
            List<string[]> reels = new List<string[]> { reel1R, reel2R, reel3R };
            int[] spins = new int[] { rnd.Next(9), rnd.Next(9), rnd.Next(9) };
            Console.Write("\nspins = ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(spins[i] + " ");
            }
            int result = solve.fruit(reels, spins);
            Console.WriteLine("\nExpecting - " + result.ToString());
            Assert.AreEqual(result, kata.fruit(reels, spins));
        }
    }
}
