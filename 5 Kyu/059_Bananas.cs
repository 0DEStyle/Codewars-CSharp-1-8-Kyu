/*Challenge link:https://www.codewars.com/kata/5917fbed9f4056205a00001e/train/csharp
Question:
> "What is your name" said Tim.
"My name" said the mouse "Is Dinglemouse".

> "What were you before the witch turned you into a mouse" said Rose.
"I was a banana" said Dingle the mouse, "So be careful. If you see her, run away!".
- Badjelly the Witch (12:32), Spike Milligan

Kata Task
Given a string of letters a, b, n how many different ways can you make the word "banana" by crossing out various letters and then reading left-to-right?

(Use - to indicate a crossed-out letter)

Example
Input

bbananana
Output

b-anana--
b-anan--a
b-ana--na
b-an--ana
b-a--nana
b---anana
-banana--
-banan--a
-bana--na
-ban--ana
-ba--nana
-b--anana
Notes
You must return all possible bananas, but the order does not matter
The example output above is formatted for readability. Please refer to the example tests for expected format of your result.
:-)
*/

//***************Solution********************
using System;
using System.Collections.Generic;

public class Dinglemouse{
    public static HashSet<string> Bananas(string s){
      //create hashset to store answers
        var ans = new HashSet<string>();
      //break string s to char array
        var xs = s.ToCharArray();
        perm(xs, 0, ans);
        return ans;
      
      //main function
        void perm(char[] arr, int i, HashSet<string> hs) {
          //if i is the same as the char array length
          //store those character into new string m
          //in string m, replace "-" with empty, store in n
            if (i == arr.Length) {
                var m = new string(arr);
                var n = m.Replace("-", string.Empty);
              
              //if n is equal to "banana" add to HashSet
                if (n.Equals("banana")) 
                  hs.Add(m);
                return;
            } 
          //get all result cursively by adding 1 to i
          //store current index of arr in a
          //replace current index of arr to '-'
          //get all result cursively by adding 1 to i again
          //set current index of arr back to a.
            perm(arr, i+1, hs);
            var a = arr[i];
            arr[i] = '-';
            perm(arr, i+1, hs);
            arr[i] = a;
        }
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
public class SolutionTests
{
    // My reference implementation (for random tests)
    private class Solution
    {
        public static HashSet<string> Bananas(string s)
        {
            var result = new HashSet<string>();
            FindBananas(result, s, "banana", "");
            return result;
        }

        private static void FindBananas(HashSet<string> res, string s, string lookFor, string x)
        {
            var slen = s.Length;
            var looklen = lookFor.Length;
            if (looklen == 0 || looklen > slen) return;
            var lookForCh = lookFor[0];
            var tmp = "";
            for (int i = 0; i < slen; i++)
            {
                var ch = s[i];
                if (ch == lookForCh)
                {
                    if (looklen == 1)
                    {
                        var v = tmp + ch;
                        while (v.Length != slen) v += "-";
                        res.Add(x + v);
                        tmp += "-";
                    }
                    else
                    {
                        if (i + 1 < slen)
                        {
                            FindBananas(res, s.Substring(i + 1), lookFor.Substring(1), x + tmp + ch);
                            tmp += "-";
                        }
                    }
                }
                else
                {
                    tmp += "-";
                }
            }
        }
    }

    // common test code
    private void DoTest(string input, HashSet<string> expected, HashSet<string> actual)
    {
        Console.WriteLine($"INPUT: {input}");
        Console.WriteLine($"EXPECTED: {string.Join(", ", expected)} ");
        Assert.AreEqual(expected.Count, actual.Count, "wrong number of bananas!");
        Assert.IsTrue(actual.SetEquals(expected), $"ACTUAL: {string.Join(", ", actual)}\n  banana mismatch!");
    }

    [Test]
    public void Ex0()
    {
        var input = "banann";
        var expected = new HashSet<string>();
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void Ex1()
    {
        var input = "banana";
        var expected = new HashSet<string> { "banana" };
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void Ex2()
    {
        var input = "bbananana";
        var expected = new HashSet<string>
        {
            "b-an--ana", "-banana--", "-b--anana", "b-a--nana", "-banan--a",
            "b-ana--na", "b---anana", "-bana--na", "-ba--nana", "b-anan--a",
            "-ban--ana", "b-anana--"
        };
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void Ex3()
    {
        var input = "bananaaa";
        var expected = new HashSet<string> { "banan-a-", "banana--", "banan--a" };
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void Ex4()
    {
        var input = "bananana";
        var expected = new HashSet<string> { "ban--ana", "ba--nana", "bana--na", "b--anana", "banana--", "banan--a" };
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void BigBunch()
    {
        var input = "bbananabananana";
        var expected = new HashSet<string>
        {
            "b---an----ana--", "b---an----an--a", "-bana------na--", "-ban--a--n--a--", "-b--an----ana--",
            "-b--an----an--a", "b-ana------n--a", "b-an--a--n----a", "b-ana------na--", "b-an--a--n--a--",
            "b-----a----nana", "-b--------anana", "-b--an--a--na--", "-b--an--a--n--a", "-b--a----na--na",
            "b-a------nan--a", "b-a------nana--", "b---an--a--na--", "-b----a----nana", "-ba------nana--",
            "-ba------nan--a", "-bana------n--a", "-ban--a--n----a", "b---------anana", "b---an--a--n--a",
            "b---a----na--na", "-bana--------na", "b---an----a--na", "b-ana--------na", "b-------anana--",
            "b-------anan--a", "-b--an----a--na", "b-a--n--a--n--a", "b-a------na--na", "b-a--n--a--na--",
            "-b--ana----n--a", "-b--an--a----na", "-b--ana----na--", "-b--a----n--ana", "-ba--n--a--na--",
            "-ba--n--a--n--a", "-ba------na--na", "b---ana----n--a", "b---an--a----na", "b---ana----na--",
            "b---a----n--ana", "-b------anan--a", "-b------anana--", "-b------ana--na", "-banan--------a",
            "b-anan------a--", "b-anan--------a", "-------ba--nana", "-banan------a--", "b-a------n--ana",
            "-ban----a--n--a", "-b--a----nana--", "-b--a----nan--a", "b-------ana--na", "b-a--n--a----na",
            "-ba--------nana", "b---ana------na", "-b--ana------na", "-------bana--na", "b-an----ana----",
            "-ban----ana----", "b-anana--------", "b-an--------ana", "-ba------n--ana", "-ba--n--a----na",
            "b-a--------nana", "-b----a--na--na", "b-an------an--a", "-------b--anana", "b-an------ana--",
            "-b------an--ana", "b-----a--na--na", "-ban------ana--", "-ban------an--a", "b-------an--ana",
            "b-a--na------na", "b---an--ana----", "b-an--a--na----", "-ban----a--na--", "-b--an------ana",
            "b-an----an--a--", "b-an----an----a", "-b------a--nana", "b-------a--nana", "-ba--n----a--na",
            "-b--an--ana----", "-------ban--ana", "b-a--n----a--na", "b-an----a--n--a", "b---a----nan--a",
            "-ba--na------na", "b-an----a--na--", "b---an------ana", "b---a----nana--", "-ban--a--na----",
            "-ban----an----a", "-ban----an--a--", "b-an------a--na", "b-anan--a------", "b-ana----n----a",
            "-b----a--n--ana", "b---a------nana", "b-----a--n--ana", "-ba--n--ana----", "-ban------a--na",
            "-banan--a------", "b-a--n--ana----", "-b--a------nana", "b---ana--na----", "b---an--an----a",
            "b---an--an--a--", "-bana----n--a--", "-bana----n----a", "-ban--a----na--", "-ban--a----n--a",
            "-ban----a----na", "b-a--n------ana", "b-an--a----na--", "b-an--a----n--a", "b-an----a----na",
            "-ba--n------ana", "-b--an--an----a", "-b--an--an--a--", "-b--ana--na----", "-b--ana--n--a--",
            "-b--ana--n----a", "-ba--na--na----", "b-a--na--na----", "b-a--n--an----a", "-ba--n--an----a",
            "b-a--n--an--a--", "-banan----a----", "b---ana--n--a--", "b-anan----a----", "-ba--n--an--a--",
            "-banana--------", "-ban--------ana", "b---ana--n----a", "-------banan--a", "-------banana--",
            "-ban--a------na", "b-an--a------na", "b-ana----n--a--", "b-a--na--n----a", "-b----a--nana--",
            "b-a--na--n--a--", "-b----a--nan--a", "b-----a--nana--", "-ba--na--n--a--", "-ba--na--n----a",
            "b-----a--nan--a", "-ba--n----an--a", "-ba--n----ana--", "b-a--na----n--a", "b-a--na----na--",
            "b-a--n----ana--", "b-a--n----an--a", "-ba--na----n--a", "-ba--na----na--", "b-ana----na----",
            "-bana----na----"
        };
        var actual = Dinglemouse.Bananas(input);
        DoTest(input, expected, actual);
    }

    [Test]
    public void Random()
    {
        var random = new Random();
        for (int r = 0; r < 50; r++)
        {
            var s = "b";
            for (int i = 0; i < random.Next(10, 20); i++)
            {
                var rnd = random.NextDouble();
                s += rnd < 0.4 ? "a" : rnd < 0.8 ? "n" : "b";
            }
            var input = s;
            var expected = Solution.Bananas(input);
            var actual = Dinglemouse.Bananas(input);
            Console.WriteLine($"<br>Random test {r}");
            DoTest(input, expected, actual);
        }
    }
}
