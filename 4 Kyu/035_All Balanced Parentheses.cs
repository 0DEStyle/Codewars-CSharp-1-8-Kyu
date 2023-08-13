/*Challenge link:https://www.codewars.com/kata/5426d7a2c2c7784365000783/train/csharp
Question:
Write a function which makes a list of strings representing all of the ways you can balance n pairs of parentheses

Examples
BalancedParens(0) returns List<string> with element:  ""
BalancedParens(1) returns List<string> with element:  "()"
BalancedParens(2) returns List<string> with elements: "()()","(())"
BalancedParens(3) returns List<string> with elements: "()()()","(())()","()(())","(()())","((()))"
*/

//***************Solution********************

using System.Collections.Generic;
public class Balanced{
    public static List<string> BalancedParens(int n){
        List<string> result = new List<string>();
      
      //if n is 0 return nothing.
        if(n == 0){
          result.Add("");
          return result;
        }
      
      //recursive method to add parentheses.
        for(int i=0; i<n; i++){
          foreach(string x in BalancedParens(i)){
            foreach(string y in BalancedParens(n-i-1))
              result.Add("(" + x + ")" + y);
          }
        }
        return result;
    }
}

//method 2
using System;
using System.Collections.Generic;
using System.Linq;
public class Balanced
{
    public static List<string> BalancedParens(int n)
    {
            return n == 0 ?
                new List<string>() { "" } :
                Enumerable.Range(0, n).SelectMany(i =>
                    from left in BalancedParens(i)
                    from right in BalancedParens(n - 1 - i)
                    select $"({left}){right}"
                ).ToList();
    }
}

//method 3
using System.Collections.Generic;
public class Balanced
{
    public static void RecursiveParens(string s, int n, int nOpen, int nClosed, List<string> res)
    {
        if (nOpen < n)
            RecursiveParens(s + "(", n, nOpen + 1, nClosed, res);
        if (nClosed < nOpen)
            RecursiveParens(s + ")", n, nOpen, nClosed + 1, res);
        if (nOpen == n && nClosed == n)
            res.Add(s);
    }    

    public static List<string> BalancedParens(int n)
    {
        var res = new List<string>();
        RecursiveParens("", n, 0, 0, res);
        return res;
    }
}

//****************Sample Test*****************
//The test cases from java version
using NUnit.Framework;
using System;
using System.Text;
using System.Collections.Generic;
public class SolutionTest
{
    [Test]
    public void TestCases()
    {
        var warriorResult = new List<string>();
        var testList = new List<string>();
        var testValues = new List<int> { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
        Shuffle(testValues);
        foreach (int target in testValues)
        {
            testList = TestParens(target);
            testList.Sort();
            warriorResult = Balanced.BalancedParens(target);
            warriorResult.Sort();
            Assert.AreEqual(testList, warriorResult);
            Console.WriteLine("Value of n = " + target);
        }
    }

    private static void Shuffle<T>(List<T> deck)
    {
        var rnd = new Random();
        for (int n = deck.Count - 1; n > 0; --n)
        {
            int k = rnd.Next(n + 1);
            T temp = deck[n];
            deck[n] = deck[k];
            deck[k] = temp;
        }
    }

    private static List<string> TestParens(int n)
    {
        var lst = new List<string>();
        var sb = new StringBuilder();
        Dfs(sb, lst, 0, 0, n);
        return lst;
    }
    private static void Dfs(StringBuilder sb, List<string> lst, int open, int close, int max)
    {
        if (close == max)
        {
            lst.Add(sb.ToString());
            return;
        }
        if (open > close)
        {
            sb.Append(')');
            Dfs(sb, lst, open, close + 1, max);
            sb.Remove(sb.Length - 1, 1);
        }
        if (open < max)
        {
            sb.Append('(');
            Dfs(sb, lst, open + 1, close, max);
            sb.Remove(sb.Length - 1, 1);
        }
    }
}
