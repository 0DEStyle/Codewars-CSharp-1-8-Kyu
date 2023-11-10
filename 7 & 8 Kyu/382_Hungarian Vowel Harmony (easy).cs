/*Challenge link:https://www.codewars.com/kata/57fd696e26b06857eb0011e7/train/csharp
Question:
Vowel harmony is a phenomenon in some languages. It means that "A vowel or vowels in a word are changed to sound the same (thus "in harmony.")" (wikipedia). This kata is based on vowel harmony in Hungarian.

Task:
Your goal is to create a function dative() (Dative() in C#) which returns the valid form of a valid Hungarian word w in dative case i. e. append the correct suffix nek or nak to the word w based on vowel harmony rules.

Vowel Harmony Rules (simplified)
When the last vowel in the word is

a front vowel (e, é, i, í, ö, ő, ü, ű) the suffix is -nek
a back vowel (a, á, o, ó, u, ú) the suffix is -nak
Examples:
Kata.Dative("ablak") == "ablaknak"
Kata.Dative("szék") == "széknek"
Kata.Dative("otthon") == "otthonnak"
Preconditions:
To keep it simple: All words end with a consonant :)
All strings are unicode strings.
There are no grammatical exceptions in the tests.

*/

//***************Solution********************

//if string "aáoóuú" contains the last character from string "eéiíöőüűaáoóuú" in word, return nak
//else return nek, append the suffix to word.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public static class Kata {
    public static string Dative(string word) =>
       word + ("aáoóuú".Contains(word.Last(c => "eéiíöőüűaáoóuú".Contains(c))) ? "nak" : "nek");
}

//solution 2
public static class Kata {
   static char[] front = { 'e', 'é', 'i', 'í', 'ö', 'ő', 'ü', 'ű' };
   static char[] back = { 'a', 'á', 'o', 'ó', 'u', 'ú' };

    public static string Dative(string word) {
        return word + (word.LastIndexOfAny(front) > word.LastIndexOfAny(back) ? "nek" : "nak");
    }
}

//solution 3
using System.Text.RegularExpressions;
public static class Kata {
  public static string Dative(string w)
  {
      return w + (Regex.IsMatch(w, @".*[aáoóuú].{1,3}$") ? "nak" : "nek");
  }
}

//solution 4
using System.Linq;

public static class Kata {
    public static string Dative(string word) {
        const string nek = "eéiíöőüű";
        const string nak = "aáoóuú";
        return word + (nek.Contains(word.Last((nek+nak).Contains)) ? "nek" : "nak");
    }
}
//****************Sample Test*****************
namespace Solution {
    using NUnit.Framework;
    using System;
    using System.Linq;
    using System.Text;

    [TestFixture]
    public class SolutionTest
    {
        [Test]
        public void BasicTests()
        {
            Assert.AreEqual("ablaknak", Kata.Dative("ablak"));
            Assert.AreEqual("tükörnek", Kata.Dative("tükör"));
            Assert.AreEqual("keretnek", Kata.Dative("keret"));
            Assert.AreEqual("otthonnak", Kata.Dative("otthon"));
            Assert.AreEqual("virágnak", Kata.Dative("virág"));
            Assert.AreEqual("tettnek", Kata.Dative("tett"));
            Assert.AreEqual("rokkantnak", Kata.Dative("rokkant"));
            Assert.AreEqual("rossznak", Kata.Dative("rossz"));
            Assert.AreEqual("gonosznak", Kata.Dative("gonosz"));
            Assert.AreEqual("rögnek", Kata.Dative("rög"));
            Assert.AreEqual("királynak", Kata.Dative("király"));
        }

        private static readonly string FrontConsonants = "eéiíöőüű";
        private static readonly string Backonsonants = "aáoóuú";

        private string Reference(string word)
        {
            {
                foreach (var c in word.ToCharArray().Reverse())
                {
                    if (FrontConsonants.Contains(c))
                    {
                        return string.Format("{0}nek", word); 
                    }
                    else if (Backonsonants.Contains(c))
                    {
                        return string.Format("{0}nak", word);
                    }
                }
                throw new ArgumentException(string.Format("Invalid input: {0}", word));
            }
        }

        private static string RandomWords = "kalap,ház,tűz,víz,méz,kéz,ember,rák,máz,üveg,pohár,húr,gödör,csűr,lakás,rokon";
        private static string Front = "terv,kérvény,vény,kép,hit,tök,őr,füst,űr";
        private static string Back = "rag,tár,kár,zár,gondnok,mór,mókus,úr";
        private static string Words = RandomWords + Front + Back;

        public string ConvertToUtf8(string word) {
            byte[] bytes = Encoding.Default.GetBytes(word);
            word = Encoding.UTF8.GetString(bytes);
            return word;
        }

        [Test]
        public void RandomTests()
        {
            Random rnd=new Random();
            var RandomizedWords = Words.Split(',').OrderBy(x => rnd.Next());
            foreach (var word in RandomizedWords) {
                Assert.AreEqual(Reference(word), Kata.Dative(word));
            }
        }
    }
}
