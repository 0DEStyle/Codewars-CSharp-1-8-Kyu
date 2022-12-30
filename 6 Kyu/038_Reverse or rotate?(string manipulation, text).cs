/*Challenge link:https://www.codewars.com/kata/56b5afb4ed1f6d5fb0000991/train/csharp
Question:
The input is a string str of digits. Cut the string into chunks (a chunk here is a substring of the initial string) of size sz (ignore the last chunk if its size is less than sz).

If a chunk represents an integer such as the sum of the cubes of its digits is divisible by 2, reverse that chunk; otherwise rotate it to the left by one position. Put together these modified chunks and return the result as a string.

If

sz is <= 0 or if str is empty return ""
sz is greater (>) than the length of str it is impossible to take a chunk of size sz hence return "".
Examples:
revrot("123456987654", 6) --> "234561876549"
revrot("123456987653", 6) --> "234561356789"
revrot("66443875", 4) --> "44668753"
revrot("66443875", 8) --> "64438756"
revrot("664438769", 8) --> "67834466"
revrot("123456779", 8) --> "23456771"
revrot("", 8) --> ""
revrot("123456779", 0) --> "" 
revrot("563000655734469485", 4) --> "0365065073456944"
Example of a string rotated to the left by one position:
s = "123456" gives "234561".
*/

//***************Solution********************
using System.Linq;
using System.Text; //var result = new StringBuilder();

public class Revrot {
  public static string RevRot(string str, int sz){
    
    //if string size is 0, or string size is greater than string length, or string is empty
    if (sz <= 0 || sz > str.Length || string.IsNullOrEmpty(str)) 
      return "";
    
    //Insert a space in between string(str) of the string chunk size(sz)
    for (int i = sz; i < str.Length; i += sz + 1)
      str = str.Insert(i, " ");
    
    //split the string into chunks and store in array
    var chunks = str.Split().Where(x => x.Length == sz);
    var result = new StringBuilder();
    
    //1.cubing a number is the same as squaring, so no need for cube
    //2. c-'0':  turn the character into ASCII, which becomes int
    //3.perform square and check if the result is divisible by 2
    foreach (string chunk in chunks){
      if (chunk.Sum(c => (c - '0') * (c - '0')) % 2 == 0)
        result.Append(string.Concat(chunk.Reverse()));  //reverse that chunk of string
      else
        result.Append(chunk.Substring(1) + chunk[0]); //append anything after index 1 to the first letter
    }
    
    return result.ToString();  //return the result
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public static class RevrotTests 
{
    private static Random rnd = new Random();

    private static void testing(string actual, string expected) 
    {
        Assert.AreEqual(expected, actual);
    }

[Test]
    public static void test1() 
    {
        Console.WriteLine("Testing RevRot");        
        testing(Revrot.RevRot("1234", 0), "");
        testing(Revrot.RevRot("", 0), "");
        testing(Revrot.RevRot("1234", 5), "");
        String s = "733049910872815764";
        testing(Revrot.RevRot(s, 5), "330479108928157");
        s = "73304991087281576455176044327690580265896";
        testing(Revrot.RevRot(s, 8), "1994033775182780067155464327690480265895");
        s = "73304991087281576455176044327690580265896896028";
        testing(Revrot.RevRot(s, 8), "1994033775182780067155464327690480265895");
        s = "73304991087281576455176044327690580265896896028126182265439";
        testing(Revrot.RevRot(s, 11), "3304991087781576455172509672344060265896896862281621820");
        s = "73304991087281576455176044327690580265896896028126182265439441215340989";
        testing(Revrot.RevRot(s, 14), "1827801994033776455176044325690580265896875622816218206939441215340984");

        s = "563000655734469485";
        testing(Revrot.RevRot(s, 4), "0365065073456944");
        s = "56300065573446948588855";
        testing(Revrot.RevRot(s, 3), "365000556437694854888");
        s = "56300065573446948588855200928875449742090";
        testing(Revrot.RevRot(s, 6), "000365437556584964255888092880794457");
        s = "56300065573446948588855200928875449742090827299285754137212";
        testing(Revrot.RevRot(s, 11), "3755600036546948588854457882900257280902479499285754132");
        s = "56300065573446948588855200928875449742090827299285754137212673841954794395427";
        testing(Revrot.RevRot(s, 10), "6300065575446948588355200928885449742097582992728062127314573841954797");
    }
    
    //-----------------------
    private static string[] SplitEqualSol(string str, int sz)
    {
        return Enumerable.Range(0, str.Length / sz)
            .Select(i => str.Substring(i * sz, sz)).ToArray();
    }
    private static string RevRotSol(string strng, int sz)
    {
        if ((sz <= 0) || (strng.Equals("")) || (sz > strng.Length)) return "";
        string[] arr = SplitEqualSol(strng, sz);
        string[] arrnew = new string[arr.Length];
        for (int i = 0; i < arr.Length; i++) 
        {
            char[] u = arr[i].ToCharArray();
            int sm = 0;
            for (int j = 0; j < u.Length; j++) 
            {
                int k = (int)Char.GetNumericValue(u[j]);
                sm += k * k * k;
            }
            if (sm % 2 == 0) 
            {
                Array.Reverse(u);
                arrnew[i] = new string(u);
            }
            else arrnew[i] = arr[i].Substring(1) + arr[i][0]; 
        }
        return String.Join("", arrnew);
    }
    //-----------------------
[Test]    
    public static void RandomTest() 
    {
        Console.WriteLine("Random Tests");
        int i = 0; string s = "";
        while (i < 100) 
        {
            int v = rnd.Next(1, 10);
            int j = 0;
            while (j <= v) 
            {
                int k = rnd.Next(10000, 10000000);
                s += k;
                j++;
            }
            int n = rnd.Next(3, Math.Max(s.Length / 3, 5));
            testing(Revrot.RevRot(s, n), RevRotSol(s, n));
            i++;
      }
   }
}  
