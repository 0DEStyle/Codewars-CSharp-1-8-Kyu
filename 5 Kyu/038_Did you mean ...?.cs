/*Challenge link:https://www.codewars.com/kata/5259510fc76e59579e0009d4/train/csharp
Question:
I'm sure, you know Google's "Did you mean ...?", when you entered a search term and mistyped a word. In this kata we want to implement something similar.

You'll get an entered term (lowercase string) and an array of known words (also lowercase strings). Your task is to find out, which word from the dictionary is most similar to the entered one. The similarity is described by the minimum number of letters you have to add, remove or replace in order to get from the entered word to one of the dictionary. The lower the number of required changes, the higher the similarity between each two words.

Same words are obviously the most similar ones. A word that needs one letter to be changed is more similar to another word that needs 2 (or more) letters to be changed. E.g. the mistyped term berr is more similar to beer (1 letter to be replaced) than to barrel (3 letters to be changed in total).

Extend the dictionary in a way, that it is able to return you the most similar word from the list of known words.

Code Examples:

var fruits = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry" });
fruits.FindMostSimilar("strawbery"); // must return "strawberry"
fruits.FindMostSimilar("berry"); // must return "cherry"

things = new Dictionary(new List<string> { "stars", "mars", "wars", "codec", "codewars" });
things.FindMostSimilar("coddwars"); // must return "codewars"

languages = new Dictionary(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript" });
languages.FindMostSimilar("heaven"); // must return "java"
languages.FindMostSimilar("javascript"); // must return "javascript" (identical words are obviously the most similar)
I know, many of you would disagree that java is more similar to heaven than all the other ones, but in this kata it is ;)

Additional notes:

there is always exactly one possible correct solution

*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

public class Kata{
    private IEnumerable<string> words;

    public Kata(IEnumerable<string> words) => this.words = words;

  //Order the array and select the first one.
    public string FindMostSimilar(string term) =>
      words.OrderBy(x => LevenshteinDistance(x, term)).First();

  
  //measuring the difference between two strings.
    private int LevenshteinDistance(string s1, string s2){
      
      //info printer
        Console.WriteLine($"{s1}, {s2}");
        var d = new int[s1.Length, s2.Length];

        for (int i = 1; i < s1.Length; i++) d[i, 0] = i;
        for (int i = 1; i < s2.Length; i++) d[0, i] = i;

        for (int j = 1; j < s2.Length; j++){
            for (int i = 1; i < s1.Length; i++)
                d[i, j] = Math.Min(d[i - 1, j] + 1, Math.Min(d[i, j - 1] + 1, d[i - 1, j - 1] + (s1[i] == s2[j] ? 0 : 1)));
        }

        return d[s1.Length - 1, s2.Length - 1];
    }
}
//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTest
{
    private Random random = new Random();

    [Test]
    public void TestDictionary1()
    {
        Kata kata = new Kata(new List<string> { "cherry", "pineapple", "melon", "strawberry", "raspberry", "apple", "coconut", "banana" }.OrderBy(o => random.Next()));
        Assert.AreEqual("strawberry", kata.FindMostSimilar("strawbery"));
        Assert.AreEqual("cherry", kata.FindMostSimilar("berry"));
        Assert.AreEqual("apple", kata.FindMostSimilar("aple"));
    }

    [Test]
    public void TestDictionary2()
    {
        Kata kata = new Kata(new List<string> { "stars", "mars", "wars", "codec", "code", "codewars" }.OrderBy(o => random.Next()));
        Assert.AreEqual("codewars", kata.FindMostSimilar("coddwars"));
    }
    
    [Test]
    public void TestDictionary3()
    {
        Kata kata = new Kata(new List<string> { "javascript", "java", "ruby", "php", "python", "coffeescript", "c", "cpp", "brainfuck" }.OrderBy(o => random.Next()));
        Assert.AreEqual("java", kata.FindMostSimilar("heaven"));
        Assert.AreEqual("javascript", kata.FindMostSimilar("javascript"));
    }
    
    
    [Test]
    public void TestDictionary4Random()
    {
        Kata kata = new Kata(new List<string> { "psaysnhfrrqgxwik", "pdyjrkaylryr", "lnjhrzfrosinb", "afirbipbmkamjzw", "loogviwcojxgvi", "iqkyztorburjgiudi", "cwhyyzaorpvtnlfr", "iroezmixmberfr", "jhjyasikwyufr", "tklquxrnhfiggb", "cpnqknjyviusknmte", "hwzsemiqxjwfk", "ntwmwwmicnjvhtt", "emvquxrvvlvwvsi", "sefsknopiffajor", "znystgvifufptxr", "xuwahveztwoor", "hrwuhmtxxvmygb", "karpscdigdvucfr", "xrgdgqfrldwk", "nnsoamjkrzgldi", "ljxzjjorwgb", "cfvruditwcxr", "eglanhfredaykxr", "fxjskybblljqr", "qifwqgdsijibor", "xikoctmrhpvi", "ajacizfrgxfumzpvi", "mhmkakybpczjbb", "vkholxrvjwisrk", "npyrgrpbdfqhhncdi", "pxyousorusjxxbt", "jcocndjkyb", "fxpvfhfrujjaifr", "hkldhadcxrjbmkmcdi", "hirldidcuzbyb", "ggcvrtxrtnafw", "tdvibqccxr", "osbednerciaai", "qojfrlhufr", "kqijoorfkejdcxr", "zqdrhpviqslik", "clxmqmiycvidiyr", "xffrkbdyjveb", "dyhxgviphoptak", "dihhiczkdwiofpr", "riyhpvimgaliuxr", "fgtrjakzlnaebxr", "ppctybxgtleipb", "ucxmdeudiycokfnb" }.OrderBy(o => random.Next()));
        Assert.AreEqual("zqdrhpviqslik", kata.FindMostSimilar("rkacypviuburk"));
    }
}
