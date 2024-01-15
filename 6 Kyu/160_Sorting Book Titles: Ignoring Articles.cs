/*Challenge link:https://www.codewars.com/kata/5909cd53e0db4280740000eb/train/csharp
Question:
When sorting lists of book titles alphabetically, articles (the, an, or a) in the beginning of the title should be ignored, and moved to the end.

For example, given a list that contains A Petition to Magic and Heritage of Deceit, Heritage of Deceit should be sorted before A Petition to Magic.

The remainder of the title should be sorted as if the article was appended to the end of the title.

For example, A Petition to Magic becomes Petition to Magic, A for purposes of sorting, and The Great Gatsby becomes Great Gatsby, The.

Write a method that receives a list of book titles as strings, and returns a new, sorted list, which follows the above rules.

You should not modify the original title. It should be returned as-is in the resulting list.

If null is passed to the method, it should return null. If an empty list is passed, the method should return an empty list.

Note: only exclude articles if they appear in the beginning of the title. For example, if a title happens to include the word The in the middle, that word should not be excluded.

Also, do not exclude articles if the entire title is an article (for example, a book titled simply The should remain The for purposes of sorting).
*/

//***************Solution********************
/*
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣤⣤⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣀⣀⠀⠀⠀⢀⣴⠟⠉⠀⠀⠀⠈⠻⣦⡀⠀⠀⠀⣤⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⣿⣿⣷⣀⢀⣾⠿⠻⢶⣄⠀⠀⣠⣶⡿⠶⣄⣠⣾⣿⠗⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠉⢻⣿⣿⡿⣿⠿⣿⡿⢼⣿⣿⡿⣿⣎⡟⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡟⠉⠛⢛⣛⡉⠀⠀⠙⠛⠻⠛⠑⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⣿⣧⣤⣴⠿⠿⣷⣤⡤⠴⠖⠳⣄⣀⣹⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣿⣀⣟⠻⢦⣀⡀⠀⠀⠀⠀⣀⡈⠻⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣼⡿⠉⡇⠀⠀⠛⠛⠛⠋⠉⠉⠀⠀⠀⠹⢧⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣾⡟⠀⢦⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠃⠀⠈⠑⠪⠷⠤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣠⣾⣿⣿⣿⣦⣼⠛⢦⣤⣄⡀⠀⠀⠀⠀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠉⠑⠢⡀⠀⠀⠀⠀⠀
⠀⠀⠀⠀⠀⠀⠀⢀⣠⠴⠲⠖⠛⠻⣿⡿⠛⠉⠉⠻⠷⣦⣽⠿⠿⠒⠚⠋⠉⠁⡞⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⢦⠀⠀⠀⠀
⠀⠀⠀⠀⠀⢀⣾⠛⠁⠀⠀⠀⠀⠀⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠤⠒⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⢣⠀⠀⠀
⠀⠀⠀⠀⣰⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣑⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⡇⠀⠀
⠀⠀⠀⣰⣿⣁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣧⣄⠀⠀⠀⠀⠀⠀⢳⡀⠀
⠀⠀⠀⣿⡾⢿⣀⢀⣀⣦⣾⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣾⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡰⣫⣿⡿⠟⠻⠶⠀⠀⠀⠀⠀⢳⠀
⠀⠀⢀⣿⣧⡾⣿⣿⣿⣿⣿⡷⣶⣤⡀⠀⠀⠀⠀⠀⠀⠀⢀⡴⢿⣿⣧⠀⡀⠀⢀⣀⣀⢒⣤⣶⣿⣿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⡾⠁⠙⣿⡈⠉⠙⣿⣿⣷⣬⡛⢿⣶⣶⣴⣶⣶⣶⣤⣤⠤⠾⣿⣿⣿⡿⠿⣿⠿⢿⣿⣿⣿⣿⣧⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣸⠃⠀⠀⢸⠃⠀⠀⢸⣿⣿⣿⣿⣿⣿⣷⣾⣿⣿⠟⡉⠀⠀⠀⠈⠙⠛⠻⢿⣿⣿⣿⣿⣿⣿⣿⣿⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇
⠀⣿⠀⠀⢀⡏⠀⠀⠀⢸⣿⣿⣿⣿⣿⣿⣿⠿⠿⠛⠛⠉⠁⠀⠀⠀⠀⠀⠉⠠⠿⠟⠻⠟⠋⠉⢿⣿⣦⡀⢰⡀⠀⠀⠀⠀⠀⠀⠁
⢀⣿⡆⢀⡾⠀⠀⠀⠀⣾⠏⢿⣿⣿⣿⣯⣙⢷⡄⠀⠀⠀⠀⠀⢸⡄⠀⠀⠀⠀⠀⠀⠀⠀⢀⣤⣿⣻⢿⣷⣀⣷⣄⠀⠀⠀⠀⢸⠀
⢸⠃⠠⣼⠃⠀⠀⣠⣾⡟⠀⠈⢿⣿⡿⠿⣿⣿⡿⠿⠿⠿⠷⣄⠈⠿⠛⠻⠶⢶⣄⣀⣀⡠⠈⢛⡿⠃⠈⢿⣿⣿⡿⠀⠀⠀⠀⠀⡀
⠟⠀⠀⢻⣶⣶⣾⣿⡟⠁⠀⠀⢸⣿⢅⠀⠈⣿⡇⠀⠀⠀⠀⠀⣷⠂⠀⠀⠀⠀⠐⠋⠉⠉⠀⢸⠁⠀⠀⠀⢻⣿⠛⠀⠀⠀⠀⢀⠇
⠀⠀⠀⠀⠹⣿⣿⠋⠀⠀⠀⠀⢸⣧⠀⠰⡀⢸⣷⣤⣤⡄⠀⠀⣿⡀⠀⠀⠀⠀⠀⠀⠀⠀⢀⡆⠀⠀⠀⠀⡾⠀⠀⠀⠀⠀⠀⢼⡇
⠀⠀⠀⠀⠀⠙⢻⠄⠀⠀⠀⠀⣿⠉⠀⠀⠈⠓⢯⡉⠉⠉⢱⣶⠏⠙⠛⠚⠁⠀⠀⠀⠀⠀⣼⠇⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀⠀⡇
⠀⠀⠀⠀⠀⠀⠻⠄⠀⠀⠀⢀⣿⠀⢠⡄⠀⠀⠀⣁⠁⡀⠀⢠⠀⠀⠀⠀⠀⠀⠀⠀⢀⣐⡟⠀⠀⠀⠀⢸⡇⠀⠀⠀⠀⠀⠀⢠⡇⠀⠀⠀⠀⠀
*/
//if list is empty, return null
//regex pattern: ignore case,  ^ start of string, $ end of string
//1st capture group include "the" or "an" or "a", a space
//2nd capture group any character except newline, more than once
//swap position of 1st and 2nd capture group
//store in list and return the result.

using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Kata{
  public class TitleSorter{
    public List<string> Sort(List<string> unsortedTitles){
      if(unsortedTitles == null) return null;
      
      var temp = unsortedTitles.OrderBy(x => Regex.Replace(x , "(?i)^(the|an|a) (.+)$","$2, $1")).ToList();
      
      return temp;
    }
  }
}

//solution 2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Kata
{
  public class TitleSorter
  {
    public List<string> Sort(List<string> unsortedTitles)
    {
      return unsortedTitles?.OrderBy(x=>Regex.Replace(x,@"(?i)^(the|an|a) (?!$)","")).ThenBy(x=>x.Length).ToList();
    }
  }
}

//****************Sample Test*****************
using System.Collections.Generic;
using NUnit.Framework;

namespace Kata
{
  [TestFixture]
  public class TitleSorterTests
  {
    [Test]
    public void BooksSortTest()
    {
      List<string> titlesToSort = new List<string>()
      {
        "A Petition to Magic",
        "Heritage of Deceit",
        "Stingers",
        "Billy's Zombie",
        "Heaven and Earth: Paranormal Flash Fiction",
        "Tales From Virdura",
        "The Great Gatsby",
        "Animal Farm",
        "Theo's Mood",
        "Alice in Wonderland"
      };
      List<string> sortedList = new TitleSorter().Sort(titlesToSort);
      Assert.AreEqual(titlesToSort.Count, sortedList.Count);
      Assert.AreEqual("Alice in Wonderland", sortedList[0]);
      Assert.AreEqual("Animal Farm", sortedList[1]);
      Assert.AreEqual("The Great Gatsby", sortedList[3]);
      Assert.AreEqual("A Petition to Magic", sortedList[6]);
      Assert.AreEqual("Theo's Mood", sortedList[9]);
    }

    [Test]
    public void NullInputTest()
    {
      List<string> result = new TitleSorter().Sort(null);
      Assert.IsNull(result);
    }

    [Test]
    public void EmptyListTest()
    {
      List<string> result = new TitleSorter().Sort(new List<string>());
      Assert.AreEqual(0, result.Count);
    }

    [Test]
    public void SampleBooksSortTest()
    {
      List<string> titlesToSort = new List<string>()
      {
        "A Petition to Magic",
        "Heritage of Deceit",
      };
      List<string> sortedList = new TitleSorter().Sort(titlesToSort);
      Assert.AreEqual(titlesToSort.Count, sortedList.Count);
      Assert.AreEqual("Heritage of Deceit", sortedList[0]);
      Assert.AreEqual("A Petition to Magic", sortedList[1]);
    }

    [Test]
    public void TitlesDifferingOnlyByArticlesTest()
    {
      List<string> titlesToSort = new List<string>()
      {
        "A Petition to Magic",
        "Petition to Magic",
        "The Petition to Magic",
        "An Petition to Magic",
        "Great Expectations" //So people actually still DO ignore articles!
      };
      List<string> sortedList = new TitleSorter().Sort(titlesToSort);
      List<string> expectedList = new List<string>()
      {
        "Great Expectations",
        "Petition to Magic",
        "A Petition to Magic",
        "An Petition to Magic",
        "The Petition to Magic"
      };
      CollectionAssert.AreEqual(expectedList, sortedList);
    }

    [Test]
    public void TitlesAreOnlyArticlesAndSpacesTest()
    {
      List<string> titlesToSort = new List<string>()
      {
        "A",
        "An",
        "The",
        "A ",
        "The ",
        "An "
      };
      List<string> sortedList = new TitleSorter().Sort(titlesToSort);
      Assert.AreEqual("A", sortedList[0]);
      Assert.AreEqual("A ", sortedList[1]);
      Assert.AreEqual("An", sortedList[2]);
      Assert.AreEqual("An ", sortedList[3]);
      Assert.AreEqual("The", sortedList[4]);
      Assert.AreEqual("The ", sortedList[5]);
    }

    [Test]
    public void ArticlesInMiddleTest()
    {
      List<string> titlesToSort = new List<string>()
      {
        "B D",
        "B A C",
        "D F",
        "D The E",
        "F H",
        "F An G"
      };
      List<string> sortedList = new TitleSorter().Sort(titlesToSort);
      Assert.AreEqual("B A C", sortedList[0]);
      Assert.AreEqual("B D", sortedList[1]);
      Assert.AreEqual("D F", sortedList[2]);
      Assert.AreEqual("D The E", sortedList[3]);
      Assert.AreEqual("F An G", sortedList[4]);
      Assert.AreEqual("F H", sortedList[5]);
    }      
  }
}
