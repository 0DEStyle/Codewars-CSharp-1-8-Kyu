/*Challenge link:https://www.codewars.com/kata/5fee4559135609002c1a1841/train/csharp
Question:
Background Information
When do we use an URL shortener?
In your PC life you have probably seen URLs like this before:

https://bit.ly/3kiMhkU
If we want to share a URL we sometimes have the problem that it is way too long, for example this URL:

https://www.google.com/search?q=codewars&tbm=isch&ved=2ahUKEwjGuLOJjvjsAhXNkKQKHdYdDhUQ2-cCegQIABAA&oq=codewars&gs_lcp=CgNpbWcQAzICCAAyBAgAEB4yBAgAEB4yBAgAEB4yBAgAEB4yBAgAEB4yBAgAEB4yBAgAEB4yBAgAEB4yBggAEAUQHlDADlibD2CjEGgAcAB4AIABXIgBuAGSAQEymAEAoAEBqgELZ3dzLXdpei1pbWfAAQE&sclient=img&ei=RJmqX8aGHM2hkgXWu7ioAQ&bih=1099&biw=1920#imgrc=Cq0ZYnAGP79ddM
In such cases a URL shortener is very useful.

How does it work?
The URL shortener is given a long URL, which is then converted into a shorter one. Both URLs are stored in a database. It is important that each long URL is assigned a unique short URL.

If a user then calls up the short URL, the database is checked to see which long URL belongs to this short URL and you are redirected to the original/long URL.

Important Note: Some URLs such as www.google.com are used very often. It can happen that two users want to shorten the same URL, so you have to check if this URL has been shortened before to save memory in your database.

Task
URL Shortener
Note: short.ly/ is not a valid short URL.

Redirect URL
Performance
There are 475_000 random tests. You don't need a complicated algorithm to solve this kata, but iterating each time through the whole database to check if a URL was used before or generating short URLs based on randomness, won't pass.

GOOD LUCK AND HAVE FUN!
*/

//***************Solution********************
using System;
using System.Collections.Generic;

namespace CW {
  class UrlShortener {
    public Dictionary<string, string> shortDict = new();
    public Dictionary<string, string> longDict = new();
    private static int num = 0;
    
    public string Shorten(string longURL) {
      if(longDict.ContainsKey(longURL))          //check existing url.
        return longDict[longURL];
      
        string _short = "short.ly/" + base26(++num); //Console.WriteLine($"created new shorturl : {_short}");
      
        shortDict[_short] = longURL;   //store in 2 dictionaries because Linq took too long to access key by value
        longDict[longURL] = _short;
      
        return _short;
      }
    
    public string Redirect(string shortURL) => shortDict[shortURL];
    
    public static string base26(int n) {  // ensure only letter a-z, 26 letters
        string ans = "";
        while (n != 0) {
            int rem = --n % 26;
            ans = (char)(rem+'a') + ans;
            n /= 26;
        } 
        return ans;
    }
  }
}


//****************Sample Test*****************
namespace CW {
  using NUnit.Framework;
  using System;
  using System.Text.RegularExpressions;
  using System.Text;
  using System.Collections.Generic;
  
  [TestFixture]
  public class TestCases
  {
    
    private Random rnd = new Random();
    
    private void TestFormat(string s) {
      Assert.IsTrue(Regex.IsMatch(s, @"^short.ly\/[a-z]{1,4}$"), $"'{s}' url format is incorrect: should starts with 'short.ly/'', with length<14 and only lowercase letters at the end.");
    }
    
    private string RandomURL() {
      string[] start = {"https://", "http://", ""};
      string[] endings = {".com", ".org", ".us", ".io", ".fr", ".codes", ".ru", ".sh"};
      string letters = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ?!%=";
      StringBuilder url = new StringBuilder();
      int l = rnd.Next(1, 51);
      url.Append(start[rnd.Next(0,3)]);
      if (rnd.Next(0,2) == 1) url.Append("www.");
      for (int i = 0; i < l; i++) url.Append(letters[rnd.Next(0, 66)]);
      url.Append(endings[rnd.Next(0,8)]);
      if (rnd.Next(0,2) == 1) url.Append("/");
      return url.ToString();
    }
    
    public void Shuffle (Random rng, List<string> array)
    {
        int n = array.Count;
        while (n > 1) 
        {
            int k = rng.Next(n--);
            string temp = array[n];
            array[n] = array[k];
            array[k] = temp;
        }
    }
    
    [Test]
    public void TestingTwoDifferentURLs()
    {
      UrlShortener urlShortener = new UrlShortener();
      string shortUrl1 = urlShortener.Shorten("https://www.codewars.com/kata/5ef9ca8b76be6d001d5e1c3e");
      TestFormat(shortUrl1);
      string shortUrl2 = urlShortener.Shorten("https://www.codewars.com/kata/5efae11e2d12df00331f91a6");
      TestFormat(shortUrl2);
      Assert.AreEqual(urlShortener.Redirect(shortUrl1), "https://www.codewars.com/kata/5ef9ca8b76be6d001d5e1c3e");
      Assert.AreEqual(urlShortener.Redirect(shortUrl2), "https://www.codewars.com/kata/5efae11e2d12df00331f91a6");
    }
    
    [Test]
    public void TestingSameURLs()
    {
      UrlShortener urlShortener = new UrlShortener();
      string shortUrl1 = urlShortener.Shorten("https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f");
      TestFormat(shortUrl1);
      string shortUrl2 = urlShortener.Shorten("https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f");
      TestFormat(shortUrl2);
      Assert.AreEqual(shortUrl1, shortUrl2, "Should work with same long URLs");
      Assert.AreEqual(urlShortener.Redirect(shortUrl1), "https://www.codewars.com/kata/5ef9c85dc41b4e000f9a645f");
    }
    
    private Dictionary<string, string> t = new Dictionary<string, string>();
    private UrlShortener urlShortener = new UrlShortener();
    
    [Test]
    public void TestingPermutationsAndPerformance() {
      for (int i = 0; i < 475000; i++) {
        string buffer = RandomURL();
        string buffer2 = urlShortener.Shorten(buffer);
        TestFormat(buffer2);
        if (t.ContainsKey(buffer)) {
          Assert.AreEqual(t.GetValueOrDefault(buffer), buffer2, "Should work with same URLs!");
        } else {
          t.Add(buffer, buffer2);
        }
      }
      
      List<string> keys = new List<string>(t.Keys);
      Shuffle(rnd, keys);
      foreach (string key in keys) {
        Assert.AreEqual(urlShortener.Redirect(t.GetValueOrDefault(key)), key);
      }
      
      List<string> urls = new List<string>();
      for (int i = 0; i < 300; i++) {
        urls.Add(keys[rnd.Next(0, keys.Count)]);
      }
      
      foreach(string url in urls) {
        int end = rnd.Next(1,4);
        for (int x = 0; x < end; x++) {
          Assert.AreEqual(urlShortener.Redirect(t.GetValueOrDefault(url)), url, "Testing if the URL mapping remains bijective under more than one operation");
        }
      }
    }
  }
}
