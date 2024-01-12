/*Challenge link:https://www.codewars.com/kata/5b16490986b6d336c900007d/train/csharp
Question:
Task
You are given a dictionary/hash/object containing some languages and your test results in the given languages. Return the list of languages where your test score is at least 60, in descending order of the scores.

Note: the scores will always be unique (so no duplicate values)

Examples
new Dictionary<string, int> {{"Java", 10}, {"Ruby", 80}, {"Python", 65}} => {"Ruby", "Python"}
new Dictionary<string, int> {{"Hindi", 60}, {"Greek", 71}, {"Dutch", 93}} => {"Dutch", "Greek", "Hindi"}
new Dictionary<string, int> {{"C++", 50}, {"ASM", 10}, {"Haskell", 20}} => {}
My other katas
If you enjoyed this kata then please try my other katas! :-)

Translations are welcome!
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
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
//x is the current eleement, from dictionary results, get all values that is greater or equal to 60
//sort the values in descending order, select the key and return the result.
using System.Linq;
using System.Collections.Generic;

public static class Kata{
  public static IEnumerable<string> MyLanguages(Dictionary<string, int> results) => 
    results.Where(x => x.Value >= 60).OrderBy(x => -x.Value).Select(x => x.Key);
}

//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;

  [TestFixture, Description("MyLanguages")]
  public class TextFixture
  {
    [Test, Description("Fixed tests")]
    public void FixedTests()
    {
      Assert.That(Kata.MyLanguages(new Dictionary<string, int> {{"Java", 10}, {"Ruby", 80}, {"Python", 65}}), Is.EqualTo((IEnumerable<string>)new string[] {"Ruby", "Python"}));
      Assert.That(Kata.MyLanguages(new Dictionary<string, int> {{"Hindi", 60}, {"Greek", 71}, {"Dutch", 93}}), Is.EqualTo((IEnumerable<string>)new string[] {"Dutch", "Greek", "Hindi"}));
      Assert.That(Kata.MyLanguages(new Dictionary<string, int> {{"C++", 50}, {"ASM", 10}, {"Haskell", 20}}), Is.EqualTo((IEnumerable<string>)new string[] {}));
    }
    
    [Test, Description("Random tests")]
    public void RandomTests()
    {
      Random rnd = new Random();
      Func<Dictionary<string, int>, IEnumerable<string>> sol = results =>
        results.Where(kvp => kvp.Value >= 60)
               .OrderByDescending(kvp => kvp.Value)
               .Select(kvp => kvp.Key);
      Func<string> randStr = () => String.Concat(new char[10].Select(v => (char)(rnd.Next(0, 25) + 97)));
      Func<Dictionary<string, int>> randTestCase = () => Enumerable.Range(0, rnd.Next(2, 20)).ToDictionary(_ => randStr(), _ => rnd.Next(0, 101));
    
      for (int i = 0; i < 100; ++i)
      {
        var testCase = randTestCase();
        var actual = Kata.MyLanguages(testCase);
        var expected = sol(testCase);
        Assert.That(actual, Is.EqualTo(expected));
      }
    }
  }
}
