/*Challenge link:https://www.codewars.com/kata/5868812b15f0057e05000001/train/csharp
Question:
You'll be given a list of two strings, and each will contain exactly one colon (":") in the middle (but not at beginning or end). The length of the strings, before and after the colon, are random.

Your job is to return a list of two strings (in the same order as the original list), but with the characters after each colon swapped.

Examples
["abc:123", "cde:456"]  -->  ["abc:456", "cde:123"]
["a:12345", "777:xyz"]  -->  ["a:xyz", "777:12345"]
*/

//***************Solution********************


//split element in arr by ":"
//then swap the tail in both elements, format using string interpolation.
using System;

public static class Kata{
  public static string[] TailSwap(string[] arr){
    var split1 = arr[0].Split(":");
    var split2 = arr[1].Split(":");
    return new string[] { $"{split1[0]}:{split2[1]}",$"{split2[0]}:{split1[1]}"};
  }
}

//solution 2
using System.Linq;

public static class Kata
{
  public static string[] TailSwap(string[] arr)
  {
    return arr.Select(x => x.Split(':')).Aggregate((a, b) => new[] { $"{a[0]}:{b[1]}", $"{b[0]}:{a[1]}" });
  }
}

//solution 3
using System;

public static class Kata
{
  public static string[] TailSwap(string[] arr)
    => new[]
    {
       $"{arr[0].Split(":")[0]}:{arr[1].Split(":")[1]}",
       $"{arr[1].Split(":")[0]}:{arr[0].Split(":")[1]}"
    };
}


//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
  [Test]
  public void SampleTest()
  {
    Assert.AreEqual(new[] { "a:d", "c:b" }, Kata.TailSwap(new[] { "a:b", "c:d" }));
    Assert.AreEqual(new[] { "1:4", "3:2" }, Kata.TailSwap(new[] { "1:2", "3:4" }));
    Assert.AreEqual(new[] { "abc:456", "cde:123" }, Kata.TailSwap(new[] { "abc:123", "cde:456" }));
    Assert.AreEqual(new[] { "a:xyz", "777:12345" }, Kata.TailSwap(new[] { "a:12345", "777:xyz" }));
    Assert.AreEqual(new[] { "(:]", "[:)" }, Kata.TailSwap(new[] { "(:)", "[:]" }));
    Assert.AreEqual(new[] { ",:,", ",:;" }, Kata.TailSwap(new[] { ",:;", ",:," }));
  }
  
  private static readonly Random Rand = new();

  [Test]
  public void RandomTest()
  {
    for (var i = 0; i < 300; i++)
    {
      var arr = new[] { $"{GenerateFragment()}:{GenerateFragment()}", $"{GenerateFragment()}:{GenerateFragment()}" };
      var expected = arr.Select(x => x.Split(':')).Aggregate((a, b) => new[] { $"{a[0]}:{b[1]}", $"{b[0]}:{a[1]}" });
      var message = FailureMessage(arr, expected);
      var actual = Kata.TailSwap(arr);
      Assert.AreEqual(expected, actual, message);
    }
  }

  private static string GenerateFragment()
  {
    const string chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()<>[]";
    return string.Concat(Enumerable.Repeat(chars, Rand.Next(1, chars.Length)).Select(s => s[Rand.Next(s.Length)])
        .Take(Rand.Next(1, 15)));
  }

  private static string FailureMessage(string[] actual, string[] expected)
  {
    return $"Should return [{string.Join(", ", expected.Select(x => $"\"{x}\""))}] with arr=[{string.Join(", ", actual.Select(x => $"\"{x}\""))}]";
  }
}
