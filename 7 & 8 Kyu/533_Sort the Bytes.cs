/*Challenge link:https://www.codewars.com/kata/6076d4edc7bf5d0041b31dcf/train/csharp
Question:
Task
Implement a function that takes an unsigned 32 bit integer as input and sorts its bytes in descending order, returning the resulting (unsigned 32 bit) integer.

An alternative way to state the problem is as follows: The number given as input is made up of four bytes. Reorder these bytes so that the resulting (unsigned 32 bit) integer is as large as possible.

Example
Input: 3735928559
  
3735928559 is 0xdeadbeef in hexadecimal representation and 11011110 10101101 10111110 11101111
in binary representation.
  
After sorting the bytes in descending order the resulting unsigned 32 bit integer is 4024352429 
in decimal representation, which is 0xefdebead in hexadecimal and 11101111 11011110 10111110 10101101
in binary.

Output should be: 4024352429
*/

//***************Solution********************
/*                             `-:/+++++++/++:-.                                          
                            .odNMMMMMMMMMMMMMNmdo-`                                      
                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                               
                    ```:mMMNhyyyyhMMMh+::::-        `:sNMN:                              
                 -oyhdmMMMMmhyyyyhMMNyy+::::---------::yMMm                              
                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`                             
                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                              
                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-                              
                MMMdhhhdMMNhhhyyyyyymMMMMNmmmmmmNNMMMMMMN.                               
                MMMhhhhdMMNhhhyyyyyyyhdmNNNMMNNNmmdhhdMMd                                
               `MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM.                               
               .MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM:                               
               .MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhhMMM+                               
               -MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhdMMM/                               
               -MMMhhhhdMMNhhhhhhhyyyyyyyyyyyyyyyyyhhdMMM-                               
               `MMMhhhhhMMNhhhhhhhhhhyyyyyyyyyyyhhhhhmMMN                                
                hMMmhhhhMMNhhhhhhhhhhhhhhhhhhhhhhhhhhNMMy                                
                :MMMNmddMMMhhhhhhhhhhddddhhhhhhhhhhhdMMM/                                
                 :hNMMMMMMMdhhhhhhhhdMMMMMMNNNNNdhhhNMMN`                                
                   .-/+oMMMmhhhhhhhhmMMmyhMMMddhhhhdMMMy                                 
                        hMMNhhhhhhhhmMMd :MMMhhhhhhdMMM+                                 
                        sMMNhhhhhhhhNMMm .MMMdhhhhhdMMN.                                 
                        /MMMdhhhhhhdMMM+  oNMMNNNNNMMm:                                  
                        `dMMMNmmmNNMMMh`   -syyyyhhy/`                                   
                         `/hmNNNNNmdh/`                                                  
                            `.---..`
*/
//get the bytes format of number n, sort the array and convert back to UInt32
using System;

static class Kata {
    public static uint SortBytes(uint n){
      var bytes = BitConverter.GetBytes(n);
      Array.Sort(bytes);
      return BitConverter.ToUInt32(bytes);
    }
}

//solution 2
using System;
using System.Linq;

static class Kata
{
  public static uint SortBytes(uint t)
  {
    var a = Convert.ToString(t, 2).PadLeft(32, '0');
		return Convert.ToUInt32(string.Concat(Enumerable.Range(0, 4)
			.Select(i => a[(8 * i)..(8 * i + 8)])
			.OrderByDescending(_ => _)), 2);
  }
}
//****************Sample Test*****************
namespace Solution 
{
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;
    using System.Linq;
  
    [TestFixture]
    public class SolutionTest
    {
        private static void Act(uint number, uint expected)
        {
            var msg = $"Invalid answer for number: {number}";
            var actual = Kata.SortBytes(number);
            Assert.AreEqual(expected, actual, msg);
        }
      
        [TestCase(0U, 0U)]
        [TestCase(1U, 16777216U)]
        [TestCase(2U, 33554432U)]
        [TestCase(4294967295U, 4294967295U)]
        [TestCase(3735928559U, 4024352429U)]
        [TestCase(255U, 4278190080U)]
        [TestCase(305419896U, 2018915346U)]
        [TestCase(19088743U, 1732584193U)]
        [TestCase(555885348U, 606282273U)]
        [TestCase(43839U, 2873032704U)]
        [TestCase(723893U, 3037399808U)]
        [TestCase(3567U, 4010606592U)]
        public void FixedTests(uint number, uint expected)
        {
            Act(number, expected);
        }
      
        [TestCaseSource(nameof(GenerateTestCases))]
        public void RandomTests((uint, uint) testCase)
        {
            var (number, expected) = testCase;
            Act(number, expected);
        }
    
        private static IEnumerable<TestCaseData> GenerateTestCases()
        {
            var rnd = new Random();
            int rndLimit() => rnd.NextDouble() < 0.2 ? byte.MaxValue : rnd.NextDouble() < 0.4 ? short.MaxValue : int.MaxValue;
            for (var i = 0; i < 200; ++i) 
                yield return GenerateTestCase(rnd, rndLimit(), i+1);
        }
    
        private static TestCaseData GenerateTestCase(Random rnd, int limit, int n)
        {
            // reference solution
            uint ReferenceSolution(uint refNumber)
            {
                var le = BitConverter.IsLittleEndian;
                var bytes = BitConverter.GetBytes(refNumber);
                var sorted = bytes.OrderBy(x => le ? x : -x).ToArray();
                var maxed = BitConverter.ToUInt32(sorted);
                return maxed;
            }
    
            // test case data generation
            int RandomInt() => rnd.Next(limit);
            uint RandomUInt() => (uint)RandomInt() + (uint)RandomInt();
            var number = RandomUInt();
            var expected = ReferenceSolution(number);
            return new TestCaseData((number, expected))
            {
                HasExpectedResult = false
            }.SetDescription($"Test {n}: number = {number}");
        }
    }
}
