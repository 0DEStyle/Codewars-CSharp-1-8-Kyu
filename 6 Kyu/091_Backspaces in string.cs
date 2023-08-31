/*Challenge link:https://www.codewars.com/kata/5727bb0fe81185ae62000ae3/train/csharp
Question:
Assume "#" is like a backspace in string. This means that string "a#bc#d" actually is "bd"

Your task is to process a string with "#" symbols.

Examples
"abc#d##c"      ==>  "ac"
"abc##d######"  ==>  ""
"#######"       ==>  ""
""              ==>  ""
*/

//***************Solution********************

//ref: https://regexr.com/
//?<c> capturing group
//[^#] negated set with character '#'
//| or
//?<-c> capturing group with character '#'
//* match 0 or more
//?(c)group condition
//(?!) negative lookahead '#', match 0 or more.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.

using System.Text.RegularExpressions;

public class Kata{
  public static string CleanString(string s) =>
    Regex.Replace(s, "((?<c>[^#])|(?<-c>#))*(?(c)(?!))#*", "");
}

//method 2
using System.Linq;

public class Kata
{
  public static string CleanString(string s)
  {
    return s.Aggregate("", (a, c) => c == '#' ? a.Any() ? a[..^1] : a : a + c);
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Collections.Generic;

  [TestFixture]
  public class SolutionTest
  {
    [Test]
    public void SampleTest()
    {
      Assert.AreEqual("ac", Kata.CleanString("abc#d##c"));
      Assert.AreEqual("", Kata.CleanString("abc####d##c#"));
    }
    
    [Test]
    public void FixedTest()
    {
      Assert.AreEqual("jf", Kata.CleanString("abjd####jfk#"));
      Assert.AreEqual("gdasda", Kata.CleanString("gfh#jds###d#dsd####dasdaskhj###dhkjs####df##s##d##"));
      Assert.AreEqual("6+yqw8hfklsd-=-f", Kata.CleanString("831####jns###s#cas/*####-5##s##6+yqw87e##hfklsd-=-28##fds##"));
      Assert.AreEqual("jdsfdasns", Kata.CleanString("######831###dhkj####jd#dsfsdnjkf###d####dasns"));
      Assert.AreEqual("", Kata.CleanString(""));
      Assert.AreEqual("", Kata.CleanString("#######"));
      Assert.AreEqual("sa", Kata.CleanString("####gfdsgf##hhs#dg####fjhsd###dbs########afns#######sdanfl##db#####s#a"));
      Assert.AreEqual("hskjdgd", Kata.CleanString("#hskjdf#gd"));
      Assert.AreEqual("hsk48hjjdfgd", Kata.CleanString("hsk48hjjdfgd"));
      Assert.AreEqual("Io4f", Kata.CleanString("fjnwui#NI#(*N#ION#Onfjen################Io4f"));
      Assert.AreEqual("6d87hbaskj$$%$$2332ff", Kata.CleanString("####6d87hbaskjdnf###$$%W#$@#$2332fr#f"));
      Assert.AreEqual("9OooooO", Kata.CleanString("#9#9#9#9o#9#9#9#Oooooo#OOOooO#OO######"));
      Assert.AreEqual("0", Kata.CleanString("0###0###0"));
      Assert.AreEqual("904rfDj*fsf09mfednkmfd;m", Kata.CleanString("904rfn#jlkcn#####Djva2###*(#fsdgfd####fsdg###09849###mfenf##dnjn##kmfd;l#mg03###"));
    }
    
    private static Random rnd = new Random();
    
    private static string Solution(string s)
    {
      List<char> result = new List<char>();
      for (int i = 0; i < s.Length; ++i)
      {
        if (s[i] == '#' && result.Count > 0) result.RemoveAt(result.Count - 1);
        else if (s[i] != '#') result.Add(s[i]);
      }
      return String.Join("", result);
    }
    
    [Test]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@$%^&*()";
        string test = "";
        int loop = rnd.Next(1, 100);
        for (int j = 0; j < loop; ++j)
        {
          test += (rnd.Next(0, 2) == 0) ? '#' : chars[rnd.Next(0, chars.Length)];
        }
        string expected = Solution(test);
        string actual = Kata.CleanString(test);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
