Note: This is a reference document that includes useful snippet of codes that perform small tasks. It is constantly being updated as I learn.

 
- return bool -
 The expression below return value of true/false based on the program(2 ways).
 return str2.Length == 0;

- Data Type - 
Nullable int
int? test = null;

Check if object is integer (Seek 7 Kyu 073_List Filtering)
public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)=> listOfItems.OfType<int>();

Int to Hex conversion(Seek 5 Kyu 007_RGB To Hex Conversion)
r.ToString("X2"); //X2 means hex letter in capital(x is lowercase), with 2 digits placement.
or
$"{(r > 255 ? 255 : r < 0 ? 0 : r):X2}"
 
 int to char (not as ASCII, but the actual number itself)
 (int)Char.GetNumericValue(x[0])

 - Print tricks -
 var str2 = new string('x', 7 + "*\n"; //out put : xxxxxxx*
 - Assigning -
To assign 2 values in one line, instead of:
newB = a + b;
a = b;
b = newB;
Do the following:
(a, b) = (b, a + b);

To assign multiple elements into array using one line
ulong[] temp = {a,b,1};
 
- Time -
compare time using DateTime.Parse() (Seek 7 & 8 Kyu 098_The Coupon Code)
public static bool CheckCoupon(string enteredCode, string correctCode, string currentDate, string expirationDate) =>
      enteredCode == correctCode && DateTime.Parse(currentDate) <= DateTime.Parse(expirationDate);
                       
- Print out Array -
Console.WriteLine(String.Join(" ", test).ToArray());
public static string Solution(string str) => string.Join("", str.Reverse().Select(x => x.ToString()).ToArray());
or
return string.Concat(str.Reverse());
or
return new string(str.ToArray().Reverse().ToArray());

- Get first digit - 
int firstDigit = number.ToString().Substring(0,1)
int firstTwoDigits = number.ToString().Substring(0,2);
int firstDigit = (int)(Value.ToString()[0]) - 48;
int firstDigit = (int)(Value / Math.Pow(10, (int)Math.Floor(Math.Log10(Value))));



- String Manuipulation - 
 Check ending charcter of a string
if(temp.EndsWith(' '))
 Remove ending character of a string
temp = temp.TrimEnd();

Remove character from string (seek 048_Remove exclamation marks)
public static string RemoveExclamationMarks(string s) => Regex.Replace(s,@"!", "");
or
public static string RemoveExclamationMarks(string s) => s.Replace("!", "");
or
str = str.Remove(str.IndexOf(somech.ToString()), 1);

Break Camel Case (seek 6 Kyu 018_Break camelCase)
public static string BreakCamelCase(string str) => string.Concat(str.Select(c => Char.IsUpper(c) ? " " + c : c.ToString()));
or using Regex
public static string BreakCamelCase(string str)=> new Regex("([A-Z])").Replace(str, " $0");

Format example (Seek 5 Kyu 006_ Human Readable Time)
 public static string GetReadableTime(int seconds) => string.Format("{0:d2}:{1:d2}:{2:d2}", seconds / 3600, seconds / 60 % 60, seconds % 60);
or
 public static string GetReadableTime(int seconds) => $"{seconds / 3600:00}:{seconds / 60 % 60:00}:{seconds % 60:00}";

get all distinct characters
string uniquestr1 = new String(str1.Distinct().ToArray());

Count the number of vowels (Seek 7 & 8 Kyu 121_Vowel Count)
public static int GetVowelCount(string str) => str.Count("aeiouAEIOU".Contains);

                       
- Array -

Declare Array
int[] a = new int[] { 6,6,6,6,1 ,10, 10,10,10,10};
Empty array
string[] a = new string[] { };
or
string[] a = new string[] {0};

Split a string into array elements
return arr = temp.Split(' ');

Convert an Array to List
a = b.ToList();

Dynamic 2D array (Seek 6 Kyu 019_Logistic Map)
var a = new int[height, width];
Print out 2D array
Console.WriteLine(String.Join(" ", array2D.Cast<int>()));

Combine two 1D arrays into 2d arrays
string[,] arr3 = new string[2,arr.Length];
for(int i = 0; i < arr.Length; i++)
{
    arr3[0, i] = arr[i];
    arr3[1, i] = arr2[i];
}
                       
- Exception -
using System;
 throw new ArgumentOutOfRangeException();

- List -
Library
using System.Collections.Generic;

Initialize List
List<double> num = new List<double>(new double[10]);
Empty List
List<double> num = new List<double>();
Convert an List to Array
a = b.ToArray();

Nested/2D list (ref https://www.youtube.com/watch?v=6-cuxfD3lvg)
List<List<int>> LogisticMap = new List<List<int>>();
LogisticMap.Add(new List<int> { 1, 2, 3 });
LogisticMap.Add(new List<int> { 4, 5, 6 });

foreach (var list in LogisticMap){
    //print list //Console.WriteLine(String.Join(" ", list));
    foreach (var item in list)
        Console.WriteLine(String.Join(" ", item)); //print items inside list
}

List with 2 fields (Seek 5 Kyu 011_Weight for weight)
List<KeyValuePair<string, int>> list = new List<KeyValuePair<string, int>>();
                
Add values into a 2 fields list <string,int>
list.Add(new KeyValuePair<string, int>(arr[i], sum));

Order a 2 fields list
var listordered = list.OrderBy(x => x.Value).ThenBy(x=> x.Key);
                
Print out the result from a 2 fields list
Console.WriteLine(string.Join(" ", listordered.Select(x => x.Key).ToList()));
                
- Ternary Sign -
return n == 0 ? new double[]{0} : res;
or Lambda expressions
=> n == 0 ? new double[]{0} : res;
Declare an Array with Lambda expressions
public static int[] minMax(int[] lst) => new int[] {lst.Min(), lst.Max()};
Declare an Predefined Array with Lambda expressions and select one element
public static string HowMuchILoveYou(int nb_petals)=>  
  new string[] {"I love you", "a little", "a lot", "passionately", "madly", "not at all"}[(nb_petals - 1) % 6];
  
  
- Lambda Expressions - 
Check whether a string is Isograms or not (seek 7 & 8 Kyu > 047_Isograms)
=> str.ToLower().Distinct().Count()==str.Length;

Given an array of integers, find the one that appears an odd number of times. (seek 6 Kyu 013_Find the odd int)
public static int find_it(int[] seq) => seq.First(x => seq.Count(y => y == x) % 2 == 1);

Example of how to set multiple conditions in a Lambda Expression (calculate BMI)
public static string Bmi(double w, double h) => (w = w / h / h) > 30 ? "Obese" : w > 25 ? "Overweight" : w > 18.5 ? "Normal" : "Underweight";

- Linq -
Get Distinct number from array, order the number, parse the string into long
public static long MinValue(int[] a) => long.Parse(string.Concat(a.Distinct().OrderBy(x => x)));

Linq Max (seek 7 & 8 Kyu 050_Expressions Matter)
public static int ExpressionsMatter(int a, int b, int c) => new[] { a+b+c, a+b*c, a*b+c, a*b*c, (a+b)*c, a*(b+c)}.Max();

Replace Repeated Character (seek 6 Kyu 014_Duplicate Encoder)
public static string DuplicateEncode(string word)=> new string(word.ToLower() .Select(x => word.ToLower().Count(y => x == y) == 1 ? '(' : ')').ToArray());

Linq Find stray number (seek 7 & 8 Kyu 051_Find the stray number)
public static int Stray(int[] numbers) => numbers.Aggregate((a, b) => a ^ b);
or
public static int Stray(int[] numbers) => numbers.GroupBy(a => a).Single(b => b.Count() == 1).Key;
                
Sum the first 2 elements using Take(2) Linq
public static int sumTwoSmallestNumbers(int[] numbers => numbers.OrderBy(i => i).Take(2).Sum();

Order zero to the end of array Linq (Seek 5kyu 030_Moving Zeros To The End)
public static int[] MoveZeroes(int[] arr) =>  arr.OrderBy(x => x==0).ToArray();
                                        
SortBy, ThenBy (Seek 5 Kyu 011_Weight for weight Solution 2)
public static string orderWeight(string strng)  => string.Join(" ", strng.Split().OrderBy(s => s.Sum(char.GetNumericValue)).ThenBy(x => x));
                                        
GroupBy example (Seek 5 Kyu 012_First non-repeating character Solution 2 and 3)
//"GroupBy(char.ToLower)" is the same as "GroupBy(c => char.ToLower(c))" 
public class Kata{
  public static string FirstNonRepeatingLetter(string s) =>
             s.GroupBy(char.ToLower)
            .Where(gr => gr.Count() == 1)
            .Select(x => x.First().ToString())
            .DefaultIfEmpty("")
            .First();
            }
                                        
For Loop with Linq
Enumerable.Range(start, count)...

Repeat (int element, int count)
    public static int SequenceSum(int start, int end, int step) =>
         start > end ? 0 : Enumerable.Repeat(start, (end - start) / step + 1).Select((x, index) => x + step * index).Sum();


If statement with Linq
.Where(x => !someString.Contains("5"))...

- Null - 
Check Null (seek 6 Kyu 016_Simple Encryption)
string.IsNullOrWhiteSpace(text)
string.IsNullOrEmpty(text)
if (string.IsNullOrEmpty(text) || n <= 0) { return text; }
text == null

check Null for int array
return (input == null || input.Length ==0) ? new int[0] : new int[] { input.Count(o => o > 0), input.Where(o => o < 0).Sum() };
                                        
Null Conditional ?. if one operation in a chain of conditions returns null, the rest of the chain doesn't execute.
//ref https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/member-access-operators

Null Coalescing Operator ?? doesn't evaluate right-hand operation if the left-hand operand evalutes to non-null.
//ref https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/null-coalescing-operator
                                        
Example of using Null Conditional and Null Coalescing Operator (Seek 5 Kyu 012_First non-repeating character Solution 3)
public class Kata
{
    public static string FirstNonRepeatingLetter(string s) =>
    s.GroupBy(char.ToLower).FirstOrDefault(_ => _.Count() == 1)?.First().ToString() ?? string.Empty;
}
                                        
- System.Data -                                        
perform arithmetic using System.Data (Seek 7 & 8 Kyu 060_Basic Mathematical Operations.cs)
using System;
using System.Data;

public static class Program{
  public static double basicOp(char op, double a, double b) => Convert.ToDouble(new DataTable().Compute($"{a}{op}{b}", ""));}
                                        
                                   
- Regex -
Code reference : https://denhamcoder.files.wordpress.com/2019/11/110719_1134_netregexche1.png
ignore \
@"\b(\w)"
or 
"\b(\\w)"

set first character to the end and add ay (Seek 5 Kyu 040_Simple Pig Latin)
public static string PigIt(string str) =>Regex.Replace(str, @"(\w)(\w*)", "$2$1ay");
                                        
- Dictionary - 
using System.Collections.Generic;
IDictionary<string, int> weight = new Dictionary<string, int>();
weight.Add(arr[i], sum);
                                        

Dictionary example
IDictionary<int, string> weight = new Dictionary<int, string>();
var myDictionary = new Dictionary<int, string>()
{
    {1, "One"},
    {2, "Two"},
    {3, "Three"},
}
Console.WriteLine(myDictionary[1]);
                                        
To print out value in dictionary
foreach (KeyValuePair<string, int> kvp in weight)
    Console.WriteLine("Key: {0}, Value: {1}", kvp.Key, kvp.Value);      
                                        
Without using Dictionary, the Lamda method (Seek 7-8 Kyu 097_Switch it Up)
public static string SwitchItUp(int num)=> 
    new string[]{"Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine"}[num];

To sort dictionary by value
var ordered = weight.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

To print out values in oneline
Console.WriteLine(string.Join(" ",ordered.Keys.ToArray())); 
                                        
Get value by key (Seek 8 Kyu 072_Welcome!)
return myDictionary.ContainsKey(language) ? myDictionary[language] : myDictionary["english"];
                                        
int32 to IPv4 (seek 019_int32 to IPv4)
public static string UInt32ToIP(uint ip) => IPAddress.Parse(ip.ToString()).ToString();
or using bit shifting
public static string UInt32ToIP(uint ip) =>
    string.Join(".", new byte[] {
                (byte)((ip>>24) & 0xFF) ,
                (byte)((ip>>16) & 0xFF) ,
                (byte)((ip>>8)  & 0xFF) ,
                (byte)( ip & 0xFF)});

                                        
Switching syntax "Convert" to "Change"
using Change=System.Convert;

public class Kata
{
  public static int Calculate(string num1, string num2)
  {
    return Change.ToInt32(num1,2)+Change.ToInt32(num2,2);
  }
}
