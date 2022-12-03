/*Challenge link:https://www.codewars.com/kata/57fb09ef2b5314a8a90001ed/train/csharp
Question:Description:
Replace all vowel to exclamation mark in the sentence. aeiouAEIOU is vowel.

Examples
replace("Hi!") === "H!!"
replace("!Hi! Hi!") === "!H!! H!!"
replace("aeiou") === "!!!!!"
replace("ABCDE") === "!BCD!"
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
//                              `-:/+++++++/++:-.                                          
//                            .odNMMMMMMMMMMMMMNmdo-`                                      
//                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
//                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
//                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
//                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
//                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                               
//                    ```:mMMNhyyyyhMMMh+::::-        `:sNMN:                              
//                 -oyhdmMMMMmhyyyyhMMNyy+::::---------::yMMm                              
//                +MMMMNNNMMMdhyyyyhMMNyyyso/::::::://+oshMMM`                             
//                NMMNhyyyMMMhhyyyyyNMMmyyyyyyssssyyyyyyymMMd                              
//                MMMdyyyhMMNhhyyyyyhNMMNdyyyyyyyyyyyhdmMMMN-                              
//                MMMdhhhdMMNhhhyyyyyymMMMMNmmmmmmNNMMMMMMN.                               
//                MMMhhhhdMMNhhhyyyyyyyhdmNNNMMNNNmmdhhdMMd                                
//               `MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM.                               
//               .MMMhhhhdMMNhhhhyyyyyyyyyyyyyyyyyyyyyydMMM:                               
//               .MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhhMMM+                               
//               -MMNhhhhdMMNhhhhhyyyyyyyyyyyyyyyyyyyyhdMMM/                               
//               -MMMhhhhdMMNhhhhhhhyyyyyyyyyyyyyyyyyhhdMMM-                               
//               `MMMhhhhhMMNhhhhhhhhhhyyyyyyyyyyyhhhhhmMMN                                
//                hMMmhhhhMMNhhhhhhhhhhhhhhhhhhhhhhhhhhNMMy                                
//                :MMMNmddMMMhhhhhhhhhhddddhhhhhhhhhhhdMMM/                                
//                 :hNMMMMMMMdhhhhhhhhdMMMMMMNNNNNdhhhNMMN`                                
//                   .-/+oMMMmhhhhhhhhmMMmyhMMMddhhhhdMMMy                                 
//                        hMMNhhhhhhhhmMMd :MMMhhhhhhdMMM+                                 
//                        sMMNhhhhhhhhNMMm .MMMdhhhhhdMMN.                                 
//                        /MMMdhhhhhhdMMM+  oNMMNNNNNMMm:                                  
//                        `dMMMNmmmNNMMMh`   -syyyyhhy/`                                   
//                         `/hmNNNNNmdh/`                                                  
//                            `.---..`


using System.Text.RegularExpressions;

public static class Kata{
  public static string Replace(string s) => Regex.Replace(s, "[aeiouAEIOU]", "!");
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text.RegularExpressions;
  
  public static class Solution
  {
    public static string Replace(string s) =>
      new Regex("[aeiou]", RegexOptions.IgnoreCase).Replace(s, "!");
  }

  [TestFixture]
  public class SolutionTest
  {
    [Test, Description("Basic Tests")]
    public void BasicTest()
    {
      Assert.AreEqual("H!!", Kata.Replace("Hi!"));
      Assert.AreEqual("!H!! H!!", Kata.Replace("!Hi! Hi!"));
      Assert.AreEqual("!!!!!", Kata.Replace("aeiou"));
      Assert.AreEqual("!BCD!", Kata.Replace("ABCDE"));
    }
    
    [Test, Description("Random Tests")]
    public void RandomTest()
    {
      const int Tests = 1000;
      Random rnd = new Random();
      
      for (int i = 0; i < Tests; ++i)
      {
        string s = String.Concat(new string[rnd.Next(2, 30)].Select(_ => rnd.Next(0, 2) == 0 ? (char)rnd.Next(65, 91) : (char)rnd.Next(97, 123)));
        
        string expected = Solution.Replace(s);
        string actual = Kata.Replace(s);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
