/*Challenge link:https://www.codewars.com/kata/5ae43ed6252e666a6b0000a4/train/csharp
Question:
Welcome
This kata is inspired by This Kata

We have a string s

We have a number n

Here is a function that takes your string, concatenates the even-indexed chars to the front, odd-indexed chars to the back.

Examples
s = "Wow Example!"
result = "WwEapeo xml!"
s = "I'm JomoPipi"
result = "ImJm ii' ooPp"
The Task:
return the result of the string after applying the function to it n times.

example where s = "qwertyuio" and n = 2:

after 1 iteration  s = "qetuowryi"
after 2 iterations s = "qtorieuwy"
return "qtorieuwy"
Note
there's a lot of tests, big strings, and n is greater than a billion

so be ready to optimize.

after doing this: do it's best friend!
*/

//***************Solution********************
using System;
using System.Text;
public class JomoPipi{
  public static string jumbledString(string s, long n){
      string str = s;
    
      for (int x = 1; x <= n; x++){ 
          StringBuilder a = new StringBuilder(), b = new StringBuilder();
          for (int i=0; i < s.Length; i++)
            //even number append
              if (i%2==0)
                  a.Append(s[i]);
            //odd number appened
              else
                  b.Append(s[i]); 
          a.Append(b);
          s = a.ToString();
          if (str.Equals(s)){
            n %= x;
            x = 0;
          }
      }
      return s;
  }
}

//****************Sample Test*****************
namespace JP 
{
  using NUnit.Framework;
  using System;
  using System.Text;
  
  [TestFixture]
  public class SolutionTest
  {
    public static int thisMod(string s, long n) {
      string str = s;
      int x = 0;
      do  {
          StringBuilder a = new StringBuilder(), b = new StringBuilder();
          for (int i=0; i < s.Length; i++)
              if (i%2==0)
                  a.Append(s[i]);
              else
                  b.Append(s[i]);
          a.Append(b);
          s = a.ToString();
          x++;
      } while (!str.Equals(s));
      return x;
    }
    public static string answer(string s, long n) {
      string str = s;
      int x = 0;
      do  {
          StringBuilder a = new StringBuilder(), b = new StringBuilder();
          for (int i=0; i < s.Length; i++)
              if (i%2==0)
                  a.Append(s[i]);
              else
                  b.Append(s[i]);
          a.Append(b);
          s = a.ToString();
          x++;
      } while (!str.Equals(s));
      n = n % x;
      while (n > 0) {
          StringBuilder a = new StringBuilder(), b = new StringBuilder();
          for (int i=0; i < s.Length; i++)
              if (i%2==0)
                  a.Append(s[i]);
              else
                  b.Append(s[i]);
          a.Append(b);
          s = a.ToString();
          n--;
      } 
      return s;
    }
    [Test]
    public void Basic_Test_Of_The_Number_1()
    {
        string s = "c#", a = "c#";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,0));
    }
    [Test]
    public void Basic_Test_Of_The_Number_2()
    {
        string s = "Such Wow!", a = "Sc o!uhWw";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,1));
    }
    [Test]
    public void Basic_Test_Of_The_Number_3()
    {
        string s = "better example", a = "bexltept merae";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,2));
    }
    [Test]
    public void Basic_Test_Of_The_Number_4()
    {
        string s = "qwertyuio", a = "qtorieuwy";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,2));
    }
    [Test]
    public void Basic_Test_Of_The_Number_5()
    {
        string s = "Greetings", a = "Gtsegenri";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,8));
    }
    [Test]
    public void Fixed_Large_Tests() {
        string s = "I like it!", a = "Iiei t kl!";
        Assert.AreEqual(a, JomoPipi.jumbledString(s,1234));
        string s1 = "codingisfornerdsyounerd", a1 = "criyinodedsgufrnodnoser";
        Assert.AreEqual(a1, JomoPipi.jumbledString(s1,10101010));
        string s2 = "this_test_will_hurt_you", a2 = "ti_etwl_utyuhsts_ilhr_o";
        Assert.AreEqual(a2, JomoPipi.jumbledString(s2,12345678987654321L));
        string s3 = "This test has a String which is so long that I hope it messes you up. It will mess you up real good, cause it's still going, and it's not going to stop anytime soon.";
        string a3 = "T yahaotinu sd I  u tiphet os'rptsee  a hnliao tstg   omagoe odsSi,stn ergcsi a ntuygoso  euws  htiuiotpcp'.h s  a Iinstsyt  tiwsiliomll e ll g osomnoiegons ngst., h";
        Assert.AreEqual(a3, JomoPipi.jumbledString(s3,18));
    }
    [Test]
        public void large_strings_large_n() {
            Random rnd = new Random();
            for (int i = 0; i < 2; i++) 
                for (int j = 0; j < 2; j++) {
                    int L = 1134;
                    long N = (long)(rnd.Next(1,5))+200000;
                    char[] text = new char[(int)L];
                    for (int k = 0; k < L; k++) text[k] = (char)(rnd.Next(65,123));
                    string S = ""+text;
                    string expected = answer(S,N), actual = JomoPipi.jumbledString(S,N);
                    if (!expected.Equals(actual))
                        Assert.AreEqual(expected, actual);
                }
        }
         [Test]
        public void BROWSER_CHOKER()  { 
                Random rnd = new Random();
                int L = 72345;             // key val
                long N = 100010001000L;
                char[] text = new char[(int)L];
                for (int k = 0; k < L; k++) text[k] = (char)(rnd.Next(65,125));
                string S = ""+text;
                string expected = answer(S,N), actual = JomoPipi.jumbledString(S,N);
                if (!expected.Equals(actual))
                    Assert.AreEqual(expected, actual);
        }
    [Test]
    public void Seven_Thousand_Random_Tests___________________________________________________________________________________________________________________________________________________________________________________________________________________________________omg() {
        Random rnd = new Random();
        for (int i=0; i<7000; i++) {
          
          long n = (long)(rnd.Next(1000000000,Int32.MaxValue));
          int length = rnd.Next(165,170);
          StringBuilder s = new StringBuilder();
          for (int j=0; j<length; j++)
          {
            int type = rnd.Next(0,3);
            switch(type) {
              case 0: s.Append((char)rnd.Next(48,58)); break;
              
              case 1: s.Append((char)rnd.Next(65,91)); break;
              
              case 2: s.Append((char)rnd.Next(97,124)); break;
            }
          }
          string x = s.ToString();
          if (n % thisMod(x , n) == 0) n++;
          string a = answer(x, n);
          Assert.AreEqual(a, JomoPipi.jumbledString(x,n));
        }
    }
  }
}
