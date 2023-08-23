/*Challenge link:https://www.codewars.com/kata/59df2f8f08c6cec835000012/train/csharp
Question:
John has invited some friends. His list is:

s = "Fred:Corwill;Wilfred:Corwill;Barney:Tornbull;Betty:Tornbull;Bjon:Tornbull;Raphael:Corwill;Alfred:Corwill";
Could you make a program that

makes this string uppercase
gives it sorted in alphabetical order by last name.
When the last names are the same, sort them by first name. Last name and first name of a guest come in the result between parentheses separated by a comma.

So the result of function meeting(s) will be:

"(CORWILL, ALFRED)(CORWILL, FRED)(CORWILL, RAPHAEL)(CORWILL, WILFRED)(TORNBULL, BARNEY)(TORNBULL, BETTY)(TORNBULL, BJON)"
It can happen that in two distinct families with the same family name two people have the same first name too.

Notes
You can see another examples in the "Sample tests".
*/

//***************Solution********************


//convert string s to uppercase
//split by ";"
//from the split element, select current element and change to string.Join(", ", x.Split(':').Reverse()) using string interpolation
//order the element in ascending order.
//concat the result and return it.
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System.Linq;

public class JohnMeeting{
  public static string Meeting(string s) =>
    string.Concat(s.ToUpper()
                   .Split(";")
                   .Select(x => $"({string.Join(", ", x.Split(':').Reverse())})")
                   .OrderBy(f => f));
}

//****************Sample Test*****************
using System;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public static class JohnMeetingTests 
{

    private static void testing(string s, string expect) {
    		Console.WriteLine("Testing\n" + s);
    		string actual = JohnMeeting.Meeting(s);
    		Console.WriteLine("Actual\n" + actual);
    		Console.WriteLine("Expect\n" + expect);
    		Console.WriteLine(actual == expect);
    		Console.WriteLine("-");        
        Assert.AreEqual(expect, actual);
    }
[Test]
    public static void test1() 
    {        
        Console.WriteLine("Basic Tests");
        testing("Alexis:Wahl;John:Bell;Victoria:Schwarz;Abba:Dorny;Grace:Meta;Ann:Arno;Madison:STAN;Alex:Cornwell;Lewis:Kern;Megan:Stan;Alex:Korn", 
                "(ARNO, ANN)(BELL, JOHN)(CORNWELL, ALEX)(DORNY, ABBA)(KERN, LEWIS)(KORN, ALEX)(META, GRACE)(SCHWARZ, VICTORIA)(STAN, MADISON)(STAN, MEGAN)(WAHL, ALEXIS)");
        testing("John:Gates;Michael:Wahl;Megan:Bell;Paul:Dorries;James:Dorny;Lewis:Steve;Alex:Meta;Elizabeth:Russel;Anna:Korn;Ann:Kern;Amber:Cornwell", 
            "(BELL, MEGAN)(CORNWELL, AMBER)(DORNY, JAMES)(DORRIES, PAUL)(GATES, JOHN)(KERN, ANN)(KORN, ANNA)(META, ALEX)(RUSSEL, ELIZABETH)(STEVE, LEWIS)(WAHL, MICHAEL)");
        testing("Alex:Arno;Alissa:Cornwell;Sarah:Bell;Andrew:Dorries;Ann:Kern;Haley:Arno;Paul:Dorny;Madison:Kern", 
            "(ARNO, ALEX)(ARNO, HALEY)(BELL, SARAH)(CORNWELL, ALISSA)(DORNY, PAUL)(DORRIES, ANDREW)(KERN, ANN)(KERN, MADISON)");
        testing("Anna:Wahl;Grace:Gates;James:Russell;Elizabeth:Rudd;Victoria:STAN;Jacob:Wahl;Alex:Wahl;Antony:Gates;Alissa:Meta;Megan:Bell;Amandy:Stan;Anna:Steve", 
            "(BELL, MEGAN)(GATES, ANTONY)(GATES, GRACE)(META, ALISSA)(RUDD, ELIZABETH)(RUSSELL, JAMES)(STAN, AMANDY)(STAN, VICTORIA)(STEVE, ANNA)(WAHL, ALEX)(WAHL, ANNA)(WAHL, JACOB)");
        testing("Ann:Russel;John:Gates;Paul:Wahl;Alex:Tolkien;Ann:Bell;Lewis:Kern;Sarah:Rudd;Sydney:Korn;Madison:Meta", 
            "(BELL, ANN)(GATES, JOHN)(KERN, LEWIS)(KORN, SYDNEY)(META, MADISON)(RUDD, SARAH)(RUSSEL, ANN)(TOLKIEN, ALEX)(WAHL, PAUL)");
        testing("Paul:Arno;Matthew:Schwarz;Amandy:Meta;Grace:Meta;Ann:Arno;Alex:Schwarz;Jacob:Rudd;Amber:Cornwell", 
            "(ARNO, ANN)(ARNO, PAUL)(CORNWELL, AMBER)(META, AMANDY)(META, GRACE)(RUDD, JACOB)(SCHWARZ, ALEX)(SCHWARZ, MATTHEW)");
        testing("Abba:Bell;Lewis:Cornwell;Jacob:STAN;Matthew:Schwarz;Ann:STAN;Sophia:Gates;Victoria:Korn;Anna:Bell;Paul:Kern;Alissa:Tolkien", 
            "(BELL, ABBA)(BELL, ANNA)(CORNWELL, LEWIS)(GATES, SOPHIA)(KERN, PAUL)(KORN, VICTORIA)(SCHWARZ, MATTHEW)(STAN, ANN)(STAN, JACOB)(TOLKIEN, ALISSA)");
        testing("Victoria:Thorensen;Ann:Arno;Alexis:Wahl;Emily:Stan;Anna:STAN;Jacob:Korn;Sophia:Gates;Amber:Kern", 
            "(ARNO, ANN)(GATES, SOPHIA)(KERN, AMBER)(KORN, JACOB)(STAN, ANNA)(STAN, EMILY)(THORENSEN, VICTORIA)(WAHL, ALEXIS)");
        testing("Andrew:Arno;Jacob:Russell;Anna:STAN;Antony:Gates;Amber:Korn;Lewis:Dorries;Ann:Burroughs;Alex:Kern;Anna:Arno;Elizabeth:Kern;John:Schwarz;Sarah:STAN", 
            "(ARNO, ANDREW)(ARNO, ANNA)(BURROUGHS, ANN)(DORRIES, LEWIS)(GATES, ANTONY)(KERN, ALEX)(KERN, ELIZABETH)(KORN, AMBER)(RUSSELL, JACOB)(SCHWARZ, JOHN)(STAN, ANNA)(STAN, SARAH)");
        testing("Megan:Wahl;Alexis:Arno;Alex:Wahl;Grace:STAN;Amber:Kern;Amandy:Schwarz;Alissa:Stan;Paul:Kern;Ann:Meta;Lewis:Burroughs;Andrew:Bell", 
            "(ARNO, ALEXIS)(BELL, ANDREW)(BURROUGHS, LEWIS)(KERN, AMBER)(KERN, PAUL)(META, ANN)(SCHWARZ, AMANDY)(STAN, ALISSA)(STAN, GRACE)(WAHL, ALEX)(WAHL, MEGAN)");
    }
    //-----------------------
    private static string Meeting122(string s) => (
    		string.Join("", s
    						.ToUpper().Split(';')
    						.Select(uu => uu.Split(':'))
    						.OrderBy(f=> f[1]).ThenBy(g=> g[0])
    						.Select(a => "(" + a[1] + ", " + a[0] + ")")));
    //-----------------------
    private static Random rnd = new Random();
  	private static void Shuffle(Random rnd, String[] arr)
  	{
    		for (int i = arr.Length - 1; i >= 0; i--)
    		{
    		  int index = rnd.Next(i + 1);
    		  string a = arr[index];
    		  arr[index] = arr[i];
    		  arr[i] = a;
    		}
  	}
  	
  	private static string compose(int k)
  	{
    		string[] fnams = new string[]{"Emily", "Sophia", "Anna", "Anna", "Sarah", "Michael", "Jacob", "Alex", "Alex", "Alex", "Antony", "John", "Matthew", "Andrew", "Paul", "Paul", "Ann", "Ann", "Ann", "Ann", "Robert", "Megan", "Alissa", "Alexis", "Grace", "Madison", "Elizabeth", "James", "Amandy", "Abba", "Victoria", "Amber", "Sydney", "Haley", "Lewis"};
    		string[] names = new string[]{"Korn", "Arno", "Arno", "Bell", "Bell", "Kern", "Kern", "Kern", "Russel", "Meta", "Meta", "Meta", "Cornwell", "Cornwell", "Wahl", "Wahl", "Wahl", "Wahl", "Dorny", "Dorries", "Stan", "STAN", "STAN", "Thorensen", "Schwarz", "Schwarz", "Gates", "Steve", "Tolkien", "Burroughs", "Gates", "Bell", "Korn", "Russell", "Rudd"};
    		StringBuilder result = new StringBuilder();
    		for (int i = 0; i < k; ++i)
    		{
    			Shuffle(rnd, fnams);
    			Shuffle(rnd, names);
    			string s = fnams[i] + ":" + names[i] + ";";
    			result.Append(s);
    		}
    		return result.ToString().Substring(0, result.Length - 2);
  	}
  
    private static void wTests() 
    {
        for (int i = 0; i < 100; i++)
  		  {
  			  string s = compose(rnd.Next(8, 12));			
  			  string exp = Meeting122(s);			  
  			  testing(s, exp);
  		  }  
    }
[Test] 
    public static void RandomTests() 
    { 
        Console.WriteLine("Random Tests");
        wTests();
    } 
}
