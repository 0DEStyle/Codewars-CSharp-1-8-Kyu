/*Challenge link:https://www.codewars.com/kata/556025c8710009fc2d000011/train/csharp
Question:
Getting Familiar: LEET: (sometimes written as "1337" or "l33t"), also known as eleet or leetspeak, is another alphabet for the English language that is used mostly on the internet. It uses various combinations of ASCII characters to replace Latinate letters. For example, leet spellings of the word leet include 1337 and l33t; eleet may be spelled 31337 or 3l33t.

GREEK: The Greek alphabet has been used to write the Greek language since the 8th century BC. It was derived from the earlier Phoenician alphabet, and was the first alphabetic script to have distinct letters for vowels as well as consonants. It is the ancestor of the Latin and Cyrillic scripts.Apart from its use in writing the Greek language, both in its ancient and its modern forms, the Greek alphabet today also serves as a source of technical symbols and labels in many domains of mathematics, science and other fields.

Your Task :

You have to create a function **GrεεκL33t** which    
takes a string as input and returns it in the form of 
(L33T+Grεεκ)Case.
Note: The letters which are not being converted in 
(L33T+Grεεκ)Case should be returned in the lowercase.
(L33T+Grεεκ)Case:

A=α (Alpha)      B=β (Beta)      D=δ (Delta)
E=ε (Epsilon)    I=ι (Iota)      K=κ (Kappa)
N=η (Eta)        O=θ (Theta)     P=ρ (Rho)
R=π (Pi)         T=τ (Tau)       U=μ (Mu)      
V=υ (Upsilon)    W=ω (Omega)     X=χ (Chi)
Y=γ (Gamma)
Examples:

GrεεκL33t("CodeWars") = "cθδεωαπs"
GrεεκL33t("Kata") = "κατα"
*/

//***************Solution********************

//Solution 1
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
//check if dictionary contains key, then extra the corresponding value
//return the result.
using System.Collections.Generic;

public class L33TGreekCase{
  public static string GreekL33t(string str){
    
    IDictionary<char, char> weight = new Dictionary<char, char>();
    var myDictionary = new Dictionary<char, char>(){
    {'A', 'α'},{'B', 'β'},{'D', 'δ'},{'E', 'ε'},
    {'I', 'ι'},{'K', 'κ'},{'N', 'η'},{'O', 'θ'},
    {'P', 'ρ'},{'R', 'π'},{'T', 'τ'},{'U', 'μ'},
    {'V', 'υ'},{'W', 'ω'},{'X', 'χ'},{'Y', 'γ'},
    };
    string text = "";
    foreach (char c in str)
      text += myDictionary.TryGetValue(char.ToUpper(c), out var value) ? value : char.ToLower(c);
    return text;
  }
}

//solution 2
//get character by using the index of string, then return the result.
class L33TGreekCase
{
  public static string GreekL33t(string str)
  {
    string result = "",
      abc  =  "abdeiknoprtuvwxy",
      greek = "αβδεικηθρπτμυωχγ";
    
    foreach (char ch in str.ToLower())
    {
      if (abc.Contains(ch))
        result += greek[abc.IndexOf(ch)];
      else 
        result += ch;
    }
    
    return result;
  }
}
//****************Sample Test*****************
namespace Solution 
{
  using NUnit.Framework;
  using System;
  using System.Linq;

  [TestFixture]
  public class L33TGreekCaseTests
  {
    [Test]
    public void BasicTests()
    {
      Assert.AreEqual("cθδεωαπs", L33TGreekCase.GreekL33t("codewars"));
      Assert.AreEqual("κατα", L33TGreekCase.GreekL33t("kata"));
      Assert.AreEqual("κμmιτε", L33TGreekCase.GreekL33t("kumite"));
      Assert.AreEqual("gπεεκlεετ", L33TGreekCase.GreekL33t("greekleet"));
    }
    
    [Test]
    public void ExtendedTests()
    {
      Assert.AreEqual("τhιs κατα's sεηsει ιs διυγαηsh", L33TGreekCase.GreekL33t("This Kata's Sensei is Divyansh"));
      Assert.AreEqual("αηγ πευιεωs αβθμτ cs50", L33TGreekCase.GreekL33t("Any reviews about CS50"));
      Assert.AreEqual("mαη ιs sτιll τhε mθsτ εχτπαθπδιηαπγ cθmρμτεπ θf αll.", L33TGreekCase.GreekL33t("Man is still the most extraordinary computer of all."));
      Assert.AreEqual("ι δθ ηθτ fεαπ cθmρμτεπs. ι fεαπ τhε lαcκ θf τhεm.", L33TGreekCase.GreekL33t("I do not fear computers. I fear the lack of them."));
      Assert.AreEqual("δθ γθμ αlsθ τhιηκ τhεsε qμθτεs απε cθηflιcτιηg εαch θτhεπ?", L33TGreekCase.GreekL33t("Do you also think these quotes are conflicting each other?"));
    }
    
    [Test]
    public void RandomTests()
    {
      var rand = new Random();
      
      Func<string,string> myGreekL33t = delegate (string str)
      {
        return string.Concat(str.Select(a => 
        {
          switch(char.ToUpper(a))
          {
            case 'A': return 'α';
            case 'B': return 'β';
            case 'D': return 'δ';
            case 'E': return 'ε';
            case 'I': return 'ι';
            case 'K': return 'κ';
            case 'N': return 'η';
            case 'O': return 'θ';
            case 'P': return 'ρ';
            case 'R': return 'π';
            case 'T': return 'τ';
            case 'U': return 'μ';
            case 'V': return 'υ';
            case 'W': return 'ω';
            case 'X': return 'χ';
            case 'Y': return 'γ';
     
            default: return char.ToLower(a);
          }
        }));
      };
      
      for(int i = 0; i < 20; i++)
      {
        var length = rand.Next(1, 50);
        
        var text = string.Concat(Enumerable.Range(0, length).Select(a => (char)rand.Next(48,100)));
        
        Console.WriteLine("Random test for " + text);
        
        Assert.AreEqual(myGreekL33t(text), L33TGreekCase.GreekL33t(text));
      }      
    }    
  }
}
