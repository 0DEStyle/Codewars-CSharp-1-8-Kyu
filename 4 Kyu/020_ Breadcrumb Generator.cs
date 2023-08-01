/*Challenge link:https://www.codewars.com/kata/563fbac924106b8bf7000046/train/csharp
Question:
As breadcrumb menùs are quite popular today, I won't digress much on explaining them, leaving the wiki link to do all the dirty work in my place.

What might not be so trivial is instead to get a decent breadcrumb from your current url. For this kata, your purpose is to create a function that takes a url, strips the first part (labelling it always HOME) and then builds it making each element but the last a <a> element linking to the relevant path; last has to be a <span> element getting the active class.

All elements need to be turned to uppercase and separated by a separator, given as the second parameter of the function; the last element can terminate in some common extension like .html, .htm, .php or .asp; if the name of the last element is index.something, you treat it as if it wasn't there, sending users automatically to the upper level folder.

A few examples can be more helpful than thousands of words of explanation, so here you have them:

Kata.GenerateBC("mysite.com/pictures/holidays.html", " : ") == '<a href="/">HOME</a> : <a href="/pictures/">PICTURES</a> : <span class="active">HOLIDAYS</span>';
Kata.GenerateBC("www.codewars.com/users/GiacomoSorbi", " / ") == '<a href="/">HOME</a> / <a href="/users/">USERS</a> / <span class="active">GIACOMOSORBI</span>';
Kata.GenerateBC("www.microsoft.com/docs/index.htm", " * ") == '<a href="/">HOME</a> * <span class="active">DOCS</span>';
Seems easy enough?

Well, probably not so much, but we have one last extra rule: if one element (other than the root/home) is longer than 30 characters, you have to shorten it, acronymizing it (i.e.: taking just the initials of every word); url will be always given in the format this-is-an-element-of-the-url and you should ignore words in this array while acronymizing: ["the","of","in","from","by","with","and", "or", "for", "to", "at", "a"]; a url composed of more words separated by - and equal or less than 30 characters long needs to be just uppercased with hyphens replaced by spaces.

Ignore anchors (www.url.com#lameAnchorExample) and parameters (www.url.com?codewars=rocks&pippi=rocksToo) when present.

Examples:

You will always be provided valid url to webpages in common formats, so you probably shouldn't bother validating them.

If you like to test yourself with actual work/interview related kata, please also consider this one about building a string filter for Angular.js.

Special thanks to the colleague that, seeing my code and commenting that I worked on that as if it was I was on CodeWars, made me realize that it could be indeed a good idea for a kata :)
*/

//***************Solution********************
//ref: https://learn.microsoft.com/en-us/dotnet/api/system.uri?view=net-7.0
//https://learn.microsoft.com/en-us/dotnet/api/system.uri.segments?view=net-7.0
using System;
using System.Linq;

public class Kata {
  public static string GenerateBC(string url, string separator){
    
    //creat a list of word to ignore in uppercase
    var wordsExclude = new[] {"THE", "OF", "IN", "FROM", "BY", "WITH", "AND", "OR", "FOR", "TO", "AT", "A"};
    
    //create new Uri using UriBuilder, convert to string
    //skip the first segment, and check select everything where that isn't "index."
    var urlParts = new Uri(new UriBuilder(url).ToString()).Segments.Skip(1).Where(x => !x.Contains("index."));
    
    
    //info printer
    //Console.WriteLine("url: " + url + ", " + string.Join(",",urlParts));
    //Console.WriteLine(string.Join(separator, urlParts.Select(s => s.Split('.')[0].TrimEnd('/').ToUpper()).Prepend("HOME")));
    
    //using string.Join to format the string, separator as separator.
    //from urlParts, select elements
    //Prepend "HOME" at the start, 
    //split element by ".", select the first part using [0] and trim '/', then convert to uppercase
    return string.Join(separator, urlParts.Select(s => s.Split('.')[0].TrimEnd('/').ToUpper()).Prepend("HOME")
                       
    //s is element, i is index
    //concat urlPart at index into herf
    //if the word length is greater than 30, split the string by "-", then ignore words from wordsExclude list.
    //else replace "-" with space
        .Select((s, i) => new
        {
            href = string.Concat(urlParts.Take(i)),
            text = s.Length > 30
                ? string.Concat(s.Split('-').Where(w => !wordsExclude.Contains(w)).Select(c => c[0]))
                : s.Replace("-", " ")
        })
                       
      //x is element , i is index
      // format the string if index is less than urlParts.Count
      // pass in the variable herf into to x.herf and text into x.text
      // else, pass text into x.text in span
        .Select((x, i) =>
            i < urlParts.Count()
                ? $"<a href=\"/{x.href}\">{x.text}</a>"
                : $"<span class=\"active\">{x.text}</span>"));
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;
  using System.Collections.Generic;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class SolutionTest
  {
    private string[] urls = new string[] {"mysite.com/pictures/holidays.html",
                                          "www.codewars.com/users/GiacomoSorbi?ref=CodeWars",
                                          "www.microsoft.com/docs/index.htm#top",
                                          "mysite.com/very-long-url-to-make-a-silly-yet-meaningful-example/example.asp",
                                          "www.very-long-site_name-to-make-a-silly-yet-meaningful-example.com/users/giacomo-sorbi",
                                          "https://www.linkedin.com/in/giacomosorbi",
                                          "www.agcpartners.co.uk/",
                                          "www.agcpartners.co.uk",
                                          "https://www.agcpartners.co.uk/index.html",
                                          "http://www.agcpartners.co.uk"};
    
    private string[] seps = new string[] {" : ", " / ", " * ", " > ", " + ", " * ", " * ", " # ", " >>> ", " % "};
    
    
    private string[] anss = new string[] {"<a href=\"/\">HOME</a> : <a href=\"/pictures/\">PICTURES</a> : <span class=\"active\">HOLIDAYS</span>",
                                          "<a href=\"/\">HOME</a> / <a href=\"/users/\">USERS</a> / <span class=\"active\">GIACOMOSORBI</span>",
                                          "<a href=\"/\">HOME</a> * <span class=\"active\">DOCS</span>",
                                          "<a href=\"/\">HOME</a> > <a href=\"/very-long-url-to-make-a-silly-yet-meaningful-example/\">VLUMSYME</a> > <span class=\"active\">EXAMPLE</span>",
                                          "<a href=\"/\">HOME</a> + <a href=\"/users/\">USERS</a> + <span class=\"active\">GIACOMO SORBI</span>",
                                          "<a href=\"/\">HOME</a> * <a href=\"/in/\">IN</a> * <span class=\"active\">GIACOMOSORBI</span>",
                                          "<span class=\"active\">HOME</span>",
                                          "<span class=\"active\">HOME</span>",
                                          "<span class=\"active\">HOME</span>",
                                          "<span class=\"active\">HOME</span>"};
    [Test]
    public void ExampleTests()
    {
      for (int i = 0; i < 10; i++)
      {
        Console.WriteLine($"\nTest With: {urls[i]}");
        if (i == 5) Console.WriteLine("\nThe one used in the above test was my LinkedIn Profile; if you solved the kata this far and manage to get it, feel free to add me as a contact, message me about the language that you used and I will be glad to endorse you in that skill and possibly many others :)\n\n ");
        
        Assert.AreEqual(anss[i], Kata.GenerateBC(urls[i], seps[i]));
      }
    }
    
    [Test]
    public void RandomTests()
    {
      Random random = new Random();
      
      for (int i = 0; i < 100; i++)
      {
        int docAndExt = random.Next(2);
        int bonus1 = random.Next(10) > 6 ? 1 : 0;
        int bonus2 = random.Next(10) > 6 ? 1 : 0;
        int[] config = new int[] { 1, 1, random.Next(2), random.Next(20, 50), docAndExt, docAndExt, bonus1, bonus2 };
        
        StringBuilder urlSB = new StringBuilder();
        
        // Protocol and site
        for (int urlPart = 0; urlPart < 2; urlPart++)
        {
          for (int n = 0; n < config[urlPart]; n++)
          {
            urlSB.Append(table[urlPart][random.Next(table[urlPart].Length)]);
          }
        }
        
        // Paths and words
        urlSB.Append("/");
        int tempLen = urlSB.Length;
        for (int urlPart = 2; urlPart < 4; urlPart++)
        {
          for (int n = 0; n < config[urlPart]; n++)
          {
            urlSB.Append(table[urlPart][random.Next(table[urlPart].Length)]);
            if (urlPart == 3)
            {
              if (urlSB.Length > config[urlPart] + tempLen) break;
              urlSB.Append("-");
            }
            else
            {
              urlSB.Append("/");
            }
          }
        }
        
        // Files and extensions
        urlSB.Append("/");
        for (int urlPart = 4; urlPart < 6; urlPart++)
        {
          for (int n = 0; n < config[urlPart]; n++)
          {
            urlSB.Append(table[urlPart][random.Next(table[urlPart].Length)]);
          }
        }
        
        // Anchors and variables
        for (int urlPart = 6; urlPart < table.Length; urlPart++)
        {
          for (int n = 0; n < config[urlPart]; n++)
          {
            urlSB.Append(table[urlPart][random.Next(table[urlPart].Length)]);
          }
        }
        
        string url = urlSB.ToString();
        string sep = separators[random.Next(separators.Length)];
        string expected = Solution(url, sep);
        string actual = Kata.GenerateBC(url, sep);
        
        Console.WriteLine($"Using URL: {url}");
        Console.WriteLine($"Using Separator: '{sep}'\n");
        
        Assert.AreEqual(expected, actual);
      }
    }
    
    private static string[] separators = new string[] { " * ", " > ", " / ", " : ", " . ", " >>> ", " # ", " + ", " - ",
        " ; " };
    private static string[] siteprefixes = new string[] { "http://", "https://", "http://www.", "https://www.", "", "", "",
        "" };
    private static string[] sites = new string[] { "codewars.com", "google.ca", "facebook.fr", "linkedin.it", "github.com",
        "agcpartners.co.uk", "twitter.de", "pippi.pi" };
    private static string[] paths = new string[] { "pictures", "images", "profiles", "users",
        "pictures-you-wished-you-never-saw-but-you-cannot-unsee-now", "issues", "files", "games", "app", "wanted",
        "web", "most-downloaded", "most-viewed" };
    private static string[] words = new string[] { "the", "of", "in", "from", "by", "with", "and", "or", "for", "to", "at",
        "a", "bed", "uber", "cauterization", "pippi", "surfer", "insider", "kamehameha", "bladder", "skin",
        "transmutation", "meningitis", "paper", "research", "biotechnology", "bioengineering", "eurasian",
        "diplomatic", "immunity" };
    private static string[] documents = new string[] { "index", "funny", "giacomo-sorbi", "login", "test", "secret-page" };
    private static string[] extensions = new string[] { ".html", ".htm", ".asp", ".php" };
    private static string[] anchors = new string[] { "#top", "#bottom", "#images", "#info", "#conclusion", "#team", "#people",
        "#offers" };
    private static string[] parameters = new string[] { "?source=utm_pippi", "?hack=off", "?referral=CodeWars",
        "?order=desc&filter=adult", "?favourite=code", "?previous=normalSearch&output=full",
        "?rank=recent_first&hide=sold", "?sortBy=year" };
    
    private static string[][] table = new string[][] { siteprefixes, sites, paths, words, documents, extensions, anchors,
        parameters };
    
    private string Solution(string url, string separator)
    {
      List<string> output = new List<string>();
      List<string> paths = Regex.Replace(url, @"(.+:\/\/)?.+?(\/|$)([a-z\-\/]+)?(.+)?", "$3", RegexOptions.IgnoreCase).Split('/').ToList();
      paths.RemoveAll(x => x == "index" || string.IsNullOrWhiteSpace(x) || string.IsNullOrEmpty(x));
  
      var formatted = paths
        .Select((x, i) => i == paths.Count() - 1
          ? $"<span class=\"active\">{Acronymize(x)}</span>"
          : $"<a href=\"/{string.Join("/", Enumerable.Range(0, i + 1).Select(y => paths[y]))}/\">{Acronymize(x)}</a>");
  
      return string.Join(separator, new string[] { (paths.Count() == 0 ? "<span class=\"active\">HOME</span>" : "<a href=\"/\">HOME</a>") }.Concat(formatted));
    }
    
    private string Acronymize(string str)
    {
      return (str.Length <= 30 
        ? Regex.Replace(str, "-", " ") 
        : Regex.Replace(Regex.Replace(str, @"\b(the|of|in|from|by|with|and|or|for|to|at|a)\b", ""), @"\b(\w)\w*", "$1").Replace("-", "")).ToUpper();
    }
  }
}
