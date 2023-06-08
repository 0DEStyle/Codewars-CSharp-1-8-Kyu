/*Challenge link:https://www.codewars.com/kata/adding-big-numbers/train/csharp
Question:
We need to sum big numbers and we require your help.

Write a function that returns the sum of two numbers. The input numbers are strings and the function must return a string.

Example
add("123", "321"); -> "444"
add("11", "99");   -> "110"
Notes
The input numbers are big.
The input is a string of only digits
The numbers are positives
*/

//***************Solution********************
//Using BigInteger.TryParse from System.Numeric to check if a number is valid
//if valid, then add bigA and bigB, then using string interpolation to return the format as string.

using System.Numerics;

public class Kata{
  public static string Add(string a, string b){
    BigInteger.TryParse(a, out var bigA);
    BigInteger.TryParse(b, out var bigB);
    return $"{bigA + bigB}";
  }
}
//solution 2
using System;
using System.Numerics;

public class Kata
{
 public static string Add(string a, string b)
	{		
		return (BigInteger.Parse(a) + BigInteger.Parse(b)).ToString(); // Fix this!
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
  [Test]
  public void ASimpleKataTest()
  {
    Assert.AreEqual("110", Kata.Add("91", "19"));
    Assert.AreEqual("1111111111", Kata.Add("123456789", "987654322"));
    Assert.AreEqual("1000000000", Kata.Add("999999999", "1"));
  }
  
  [Test]
  public void BigTests()
  {
    Assert.AreEqual("1057853509440367665682450458794866464501746580388666517943654"
      , Kata.Add("823094582094385190384102934810293481029348123094818923749817", "234758927345982475298347523984572983472398457293847594193837"));

    Assert.AreEqual("1222288369471848635431742533238794347796709858386130887087383"
      , Kata.Add("234859234758913759182357398457398474598237459823745928347538", "987429134712934876249385134781395873198472398562384958739845"));
      
    Assert.AreEqual("1188027920792406899351871815238255333339717894129824807166673"
      , Kata.Add("854694587458967459867923420398420394845873945734985374844444", "333333333333439439483948394839834938493843948394839432322229"));
      
    Assert.AreEqual("1131313130303031311313030303131313121212131313129120030130132"
      , Kata.Add("666666665656566666666565656666666656565666666665656566666666", "464646464646464644646464646464646464646464646463463463463466"));
      
    Assert.AreEqual("1823172964260263830982280609675150766951754355882242391698277783797094242179652457248777050585906182180138262963360272327"
      , Kata.Add("987429134712934876249385134781395873198472398562384958739845234859234758913759182357398457398474598237459823745928347538", "835743829547328954732895474893754893753281957319857432958432548937859483265893274891378593187431583942678439217431924789"));
  }
  
  private string AddSolution(string a, string b) {
    var aa=a.PadLeft(Math.Max(a.Length,b.Length)).Replace(" ","0").Select(x=>x-48).ToArray();
    var bb=b.PadLeft(Math.Max(a.Length,b.Length)).Replace(" ","0").Select(x=>x-48).ToArray();
    var rs="";
    var add=0;
    for (int i=aa.Length-1;i>0;i--){
      rs=(aa[i]+bb[i]+add)%10+rs;
      add=(aa[i]+bb[i]+add)/10;
    }
    return (aa[0]+bb[0]+add)+rs;
  }
  
  [Test]
  public void RandomTest() {
    Random random = new Random();
    for (int i = 0; i < 100; ++i) {
      string str1 = string.Join("", Enumerable.Range(1, 20).Select(_ => random.Next(1000, 100001).ToString()));
      string str2 = string.Join("", Enumerable.Range(1, 20).Select(_ => random.Next(1000, 100001).ToString()));
      Assert.AreEqual(AddSolution(str1, str2), Kata.Add(str1, str2));
    }
  }
}
