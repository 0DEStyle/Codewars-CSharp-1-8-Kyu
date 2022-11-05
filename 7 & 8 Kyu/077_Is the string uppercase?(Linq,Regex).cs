/*Challenge link:https://www.codewars.com/kata/56cd44e1aa4ac7879200010b/train/csharp
Question:
Is the string uppercase?
Task
Create a method to see whether the string is ALL CAPS.

Examples (input -> output)
"c" -> False
"C" -> True
"hello I AM DONALD" -> False
"HELLO I AM DONALD" -> True
"ACSKLDFJSgSKLDFJSKLDFJ" -> False
"ACSKLDFJSGSKLDFJSKLDFJ" -> True
In this Kata, a string is said to be in ALL CAPS whenever it does not contain any lowercase letter so any string containing no letters at all is trivially considered to be in ALL CAPS.
*/

//***************Solution********************
//solution 1
//using regex to remove all digit and non word character fromt the string text
//if all remaining letters are upperletter, return true.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

/*                             `-:/+++++++/++:-.                                          
                            .odNMMMMMMMMMMMMMNmdo-`                                      
                           +mMMNmdhhhhhhhhhdmNMMMNd/`                                    
                          sMMMmhyyyyyyyyyyyyyyhmNMMMh-                                   
                         +MMMdyyyyyyyhhhhdddddddmMMMMN/                                  
                        `NMMmyyyyyymNNMMNNNmmmmmmmNNMMMy`                                
                        :MMMhyyyyyNMMMho+//:-.....-:omMMd-                       Keep scrolling :^)        
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

using System.Linq;
using System.Text.RegularExpressions;
public static class StringExtensions
{
  public static bool IsUpperCase(this string text) => Regex.Replace(text, @"\W|\d", "").All(x => char.IsUpper(x));
}

//solution 2
public static class StringExtensions
{
  public static bool IsUpperCase(this string value) => value.ToUpper() == value;
}
//****************Sample Test*****************
public class Tests
{
  private static Random r = new Random();

  [Test]
  [TestCase("c", ExpectedResult=false)]
  [TestCase("C", ExpectedResult=true)]
  [TestCase("hello I AM DONALD", ExpectedResult=false)]
  [TestCase("HELLO I AM DONALD", ExpectedResult=true)]
  [TestCase("ACSKLDFJSgSKLDFJSKLDFJ", ExpectedResult=false)]
  [TestCase("ACSKLDFJSGSKLDFJSKLDFJ", ExpectedResult=true)]
  public static bool FixedTest(string str)
  {
    return str.IsUpperCase();
  }
  
  [Test]
  public static void RandomTest([Random(0,100,100)] int len)
  {
    string s = RandomString(len, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!§$%&/()= ");
    Assert.AreEqual(Solution(s), s.IsUpperCase(), "Should work for {0}", s);
  }
  
  private static bool Solution(string text)
  {
    return text.ToUpper() == text;
  }
  
  private static string RandomString(int randStrLength, string allowedChars)
  {
    string randStr = string.Empty;    
    for (int i = 0; i < randStrLength; i++)
    {
      randStr += allowedChars[r.Next(allowedChars.Length)];
    }
    return randStr;
  }
}
