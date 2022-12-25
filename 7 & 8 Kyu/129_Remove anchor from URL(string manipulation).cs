/*Challenge link:https://www.codewars.com/kata/51f2b4448cadf20ed0000386/train/csharp
Question:
Complete the function/method so that it returns the url with anything after the anchor (#) removed.

Examples
"www.codewars.com#about" --> "www.codewars.com"
"www.codewars.com?page=1" -->"www.codewars.com?page=1"
*/

//***************Solution********************

//find the last index starting from '#' in the url string
//if index is greater or euqal to 0, return url string from index 0 to the last index of '#'
//else return normally.

public static class Kata{
  public static string RemoveUrlAnchor(string url){
    int index = url.LastIndexOf("#");
    return index >=0 ? url.Substring(0, index) : url;
  }
}

//solution 2
//split the url string starting from the letter '#'
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public static class Kata
{
  public static string RemoveUrlAnchor(string url)
  {
    return url.Split('#')[0];
  }
}

//solution 3
using System.Text.RegularExpressions;
public static class Kata
{
  public static string RemoveUrlAnchor(string url)
  {
    return Regex.Match(url, @"[^#]+").Value;
  }
}

//****************Sample Test*****************
namespace Solution
{
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;
  
  public static class Solution
  {
    public static string RemoveUrlAnchor(string url) =>
      new Regex("#.*$").Replace(url, "");
  }
  
  public static class FakeUrlGenerator
  {
    private static Random rnd = new Random();
    private static string chars = "0123456789abcdefghijklmnopqrstuvwxyz";
  
    public static List<string> Domains = new List<string>
    {
      ".com", ".net", ".org", ".gov",
      ".rawdanger", ".is", ".best", ".danger"
    };
  
    private static string randomString(int min = 1, int max = 10)
    {
      return String.Concat(new char[rnd.Next(min, max)].Select(_ => chars[rnd.Next(0, chars.Length)]));
    }
    
    public static string Anchor()
    {
      return "#" + randomString(4, 12);
    }
    
    public static string Url()
    {
      bool query = false;
    
      // Base URL including possible subdomain
      StringBuilder url = new StringBuilder();
      url.Append("www." + ((rnd.Next(0, 2) == 0) ? randomString(2, 6) + "." : "") + randomString(6, 18) + Domains[rnd.Next(0, Domains.Count)]);
      
      // Path
      while (rnd.Next(0, 4) != 0)
      {
        url.Append("/" + randomString(4, 12));
      }
      
      // Query
      if (rnd.Next(0, 2) == 0)
      {
        query = true;
        url.Append("/" + Query());
      }
      
      // Anchor
      if (rnd.Next(0, 2) == 0)
      {
        if (!query) { url.Append("/"); }
        url.Append(Anchor());
      }
      
      return url.ToString();
    }
    
    
    public static string Query()
    {
      return "?" + randomString(4, 12) + "=" + randomString(1, 5);
    }
    
  }
  
  [TestFixture]
  public class Tests
  {
    [Test, Description("Sample Tests")]
    public void SampleTests()
    {
      Assert.AreEqual("www.codewars.com", Kata.RemoveUrlAnchor("www.codewars.com#about"));
      Assert.AreEqual("www.codewars.com/katas/?page=1", Kata.RemoveUrlAnchor("www.codewars.com/katas/?page=1#about"));
      Assert.AreEqual("www.codewars.com/katas/", Kata.RemoveUrlAnchor("www.codewars.com/katas/"));
    }
    
    [Test, Description("Random Tests")]
    public void RandomTests()
    {
      const int Tests = 100;
      
      for (int i = 0; i < Tests; ++i)
      {
        string url = FakeUrlGenerator.Url();
        Console.WriteLine(url);
        
        string expected = Solution.RemoveUrlAnchor(url);
        string actual = Kata.RemoveUrlAnchor(url);
        
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
