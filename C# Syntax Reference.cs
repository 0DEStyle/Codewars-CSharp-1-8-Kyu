Note: This is a reference document that includes useful snippet of codes that perform small tasks. It is constantly being updated as I learn.

- Switch case -
 //using Lambda instead of ternary (Seek 7 & 8 Kyu Bartender, drinks!.cs)
  public static string GetDrinkByProfession(string p) => p.ToLower() switch
  {
    "jabroni" => "Patron Tequila",
    "school counselor" => "Anything with Alcohol",
    "programmer" =>  "Hipster Craft Beer",
    "bike gang member" => "Moonshine",
    "politician" => "Your tax dollars",
    "rapper" => "Cristal",
    _ => "Beer" 
  };

//Switch case in one line
        public static string DefineSuit(string card) =>
            card[^1] switch
            {
                '♣' => "clubs",
                '♦' => "diamonds",
                '♥' => "hearts",
                _ => "spades",
            };

//weird if statment method
//instead of doing
    if (a == null) a = "";
    if (b == null) b = "";
//do this (null-coalescing operators)
    a ??= "";
    b ??= "";

- Pass Function as argument -
//definition Func<Type of function , Type of argument>
 //example

 public  static string VertMirror(string strng) =>
      string.Join("\n", strng.Split("\n").Select(x => new String(x.Reverse().ToArray())));
  
    public  static string HorMirror(string strng)=> 
      string.Join("\n",strng.Split("\n").Reverse());
  
    public static string Oper(Func<string,string>fct, string s) => fct(s);
 

//pass a bunch of function using a list
//example
public static void Function()
        {
            RollDice();
            Move();
            Combat();
            GetCoins();
            BuyHealth();    
            PrintStatus();
        }

//solution 1
 public static void PlayTurn(){
    Log = new List<string> { "RollDice", "Move", "Combat", "GetCoins", "BuyHealth", "PrintStatus" };
  }
//solution 2
public static void PlayTurn()
  {
    Log = "RollDice Move Combat GetCoins BuyHealth PrintStatus".Split().ToList();
  }

- return bool -
 The expression below return value of true/false based on the program(2 ways).
 return str2.Length == 0;


//count the number of args/arguments
  public static int CountArgs(params object[] args) => args.Length;
//method 2
  public static int CountArgs(params dynamic[] args) => args.Length;


//call different functions based on condition, one line
public static void If(bool condition, Action func1, Action func2) => (condition ? func1 : func2)();

//Ternary operator combo with Console.WriteLine
  public static void Main(string[] args) => Console.WriteLine("Hello World!");

- Join arguments together with string.join -
    public static string buildString(string[] args) => $"I like {string.Join(", ", args)}!";



- Data Type - 
Nullable int
int? test = null;

nullable type, pass an empty double
public static double? ParseF(object s = null) => double.TryParse(s?.ToString(), out var result) ? result : (double?) null;
  
//biginterger power
using System.Numerics;
BigInteger.Pow(2, x)

- adding single digit in string without convert to int -
 //(Seek 6 Kyu 038_Reverse or rotate?)
 foreach (string chunk in chunks)
      if (chunk.Sum(c => (c - '0') * (c - '0')) % 2 == 0);

//check if a string is a digit
public static bool IsDigit(string s)  => float.TryParse(s, out _);

Check if object is integer (Seek 7 Kyu 073_List Filtering)
public static IEnumerable<int> GetIntegersFromList(List<object> listOfItems)=> listOfItems.OfType<int>();

Int to Hex conversion(Seek 5 Kyu 007_RGB To Hex Conversion)
r.ToString("X2"); //X2 means hex letter in capital(x is lowercase), with 2 digits placement.
or
$"{(r > 255 ? 255 : r < 0 ? 0 : r):X2}"
 
 int to char (not as ASCII, but the actual number itself)
 (int)Char.GetNumericValue(x[0])

 //convert string array to int array
 .Select(int.Parse).ToArray();

//convert char array to int array
.Select(a => a - '0')

 //convert the character to ASCII and Concat it together.
public static string Switcher(string[] x) => string.Concat(x.Select(n => "zyxwvutsrqponmlkjihgfedcba!? "[int.Parse(n) - 1]));

 - Print tricks -
 //get the length of a number by converting to string using interpolation
    return $"{n}".Length;

 //Linq return or print certain length of characters
 return String.Join("", Enumerable.Repeat(character, text.Length));

//Linq preset string
        public static bool Validate_hello(string greetings)=>
          new[] { "hello", "ciao", "salut", "hallo", "hola", "ahoj", "czesc" }.Any(x => greetings.ToLower().Contains(x));


 //check if string is null or empty
 public static string Hello(string name) => string.IsNullOrEmpty(name);

 //first letter to uppercase
using System.Globalization;
public static string Hello(string name) => 
    string.IsNullOrEmpty(name) ? 
    "Hello, World!" : 
    $"Hello, {CultureInfo.CurrentCulture.TextInfo.ToTitleCase(name.ToLower())}!";

//Switch letter cases, upper to lower, lower to upper
public static string alternateCase(string s) =>
             string.Concat(s.Select(e => char.IsUpper(e) ? char.ToLower(e) : char.ToUpper(e)));


 String Interpolation
 
 //format string to certain length (3 method)
 return $"Value is {value.ToString().PadLeft(5, '0')}";  //00005 adding '0' to the left
 return $"Value is {value:D5}";
 return string.Format("Value is {0:00000}", value);
 
 return $"Congratulations! You're going to have a {sperm == "XY" ? "son" : "daughter"}.";
 return $"At match {t[0]} - {t[1]}, {(s[0] == s[1] ? "teams played draw." : t[s[0] > s[1] ? 0 : 1] + " won!")}";

 var str2 = new string('x', 7 + "*\n"; //out put : xxxxxxx*
 - Assigning -
 
 //count the number of times x appear in xs, using Equals.
 public static int NumberOfOccurrences(int x, int[] xs) => xs.Count(x.Equals);
 
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
//split string by size
//seek 7 & 8 Kyu (298_Split In Parts.cs)
    public static string SplitInParts(string s, int partLength){  
        for(int i = partLength; i < s.Length; i += partLength + 1)
            s = s.Insert(i, " ");
        return s;    
    }
}  
                       
//methods to join two Enumerables together
return string.Concat(a.Where(x=>!b.Contains(x))) + string.Concat(b.Where(x=>!a.Contains(x)));
//alt method
return string.Concat(a.Where(x => !b.Contains(x)).Concat(b.Where(x => !a.Contains(x))));
 
//find unique letters by replace letters 
return Replace(a, $"[{b}]", "") + Replace(b, $"[{a}]", "");
                       
//Select a pattern, separate with string by 8 character, commonly used in reversing bits.
Enumerable.Range(0, str.Length / 8).Select(i => str.Substring(i * 8, 8)).ToArray();
                       
//string interporlation
public static string SayHello(string[] a, string b, string c) => $"Hello, {string.Join(" ",a)}! Welcome to {b}, {c}!";
                       
(Seek 7 & 8 Kyu 132_Sort and Star)
//sort the string alphabtically, select the first letter and store as array, join each element with ***
public static string TwoSort(string[] s)=> string.Join("***", s.OrderBy(a => a, StringComparer.Ordinal).First().ToArray());
                       
//Create a new string using string builder (Seek 6 Kyu 038_Reverse or rotate?)
using System.Text; //var result = new StringBuilder();

//Insert a space in between string(str) of the string chunk size(sz) (Seek 6 Kyu 038_Reverse or rotate?)
for (int i = size; i < str.Length; i += size + 1)
      str = str.Insert(i, " ");
                       
//split the string into chunks and store in array (Seek 6 Kyu 038_Reverse or rotate?)
    var chunks = str.Split().Where(x => x.Length == size);
                       
//reverse string
string.Concat(chunk.Reverse());
                       
//Shift character to the left by 1, append anything after index 1 to the first letter
result.Append(chunk.Substring(1) + chunk[0]);
                       
 Check ending charcter of a string
if(temp.EndsWith(' '))
 Remove ending character of a string
temp = temp.TrimEnd();

//replace the string num(convert to string using string interpolation) 
//if character is equal to pattern 1,3,5,7,9, using the regex Lookahead operator ?= to check the next character
//then return the string with $1 the number itself with the character '-'
public static string InsertDash(int num) => Regex.Replace($"{num}", "([1,3,5,7,9])(?=[1,3,5,7,9])", "$1-");

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

//count smiley face pattern
public static int CountSmileys(string[] smileys) => Regex.Matches(string.Join(" ",smileys), @"(?::|;)(?:-|~)?(\)|D)").Count();
 or
public static int CountSmileys(string[] smileys)=> smileys.Count(s => Regex.IsMatch(s, @"^[:;]{1}[~-]{0,1}[\)D]{1}$"));
//Note that {1} is redundant and {0,1} is best written as ?. 
 or
public static int CountSmileys(string[] smileys) => Regex.Matches(string.Join(" ",smileys), "([:;][-~]?)[)D]").Count;
                       
- Array -
//Take the first n elements
public static object[] TakeFirstElements(object[] array, int n = 1)=> array.Take(n).ToArray();
                       
//remove first and last elements of array using [1..^1]
return string.Join(" ", arr[1..^1]);
                       
//store array elements with equation in one line
public static int[] Get_size(int w,int h,int d) => new int[] {2*(h*w + h*d + w*d), w*h*d};
                       
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
                       
Example of linq generate array
Enumerable.Range(0, n+1).Select(x => BigInteger.Pow(2, x)).ToArray();         
n = 0  ==> [1]        # [2^0]
n = 1  ==> [1, 2]     # [2^0, 2^1]
n = 2  ==> [1, 2, 4]  # [2^0, 2^1, 2^2]

//Join 2D array together and print it
  public static string Crap(char[,] x)
    string str = String.Join(" ", x.Cast<char>());
    
- Exception -
using System;
 throw new ArgumentOutOfRangeException();

- List -
//C# keyword to create a tuple using Tuple.Create (Seek 7 & 8 Kyu 242_ Ordered Count of Characters)
//ref: https://learn.microsoft.com/en-us/dotnet/api/system.tuple.create?view=net-7.0
public static List<Tuple<char, int>> OrderedCount(string input) => input.GroupBy(x=>x).Select(c => Tuple.Create(c.Key, c.Count())).ToList();
                       
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
                
//using Chunk to split string into certain size
public static string SplitInParts(string s, int partLength)=> string.Join(" ",s.Chunk(partLength).Select(c => string.Concat(c)));
                
//Join elements together with Aggregate instead of string.Join
int[] data = new int[32] { 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 0 };
var str = data.Aggregate("",(i, j) => i + j);
Console.WriteLine(string.Concat(str));
                
Get Distinct number from array, order the number, parse the string into long
public static long MinValue(int[] a) => long.Parse(string.Concat(a.Distinct().OrderBy(x => x)));

Linq Max (seek 7 & 8 Kyu 050_Expressions Matter)
public static int ExpressionsMatter(int a, int b, int c) => new[] { a+b+c, a+b*c, a*b+c, a*b*c, (a+b)*c, a*(b+c)}.Max();

Replace Repeated Character (seek 6 Kyu 014_Duplicate Encoder)
public static string DuplicateEncode(string word)=> new string(word.ToLower() .Select(x => word.ToLower().Count(y => x == y) == 1 ? '(' : ')').ToArray());

//Replace character to index order.
public static string Vowel2Index(string str) => Regex.Replace(str, "[aeiou]", i => $"{i.Index + 1}");

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
return string.Join("\n", Enumerable.Range(1, 10).Select(i => $"{i} * {number} = {i * number}"));
//Skip element with loop                                        
xs.Skip(1).Where((x, i) => x % (i + 1) == 0).ToList();
                                        
//To use OrderBy and Enumeral.Range together, you need to Zip 2 arrays together.
    return a.OrderBy(n => n).Skip(a.Length / 2).Zip(a.OrderByDescending(n => n).Skip(a.Length / 2), (x, y) => x * y).Sum();

//Enumeral.Range method
a = a.OrderBy(x=>x).ToArray();
        return Enumerable.Range(0,a.Length/2).Select((x,i) =>a[i]*a[a.Length-1-i]).Sum();
                                        

Repeat (int element, int count)
    public static int SequenceSum(int start, int end, int step) =>
         start > end ? 0 : Enumerable.Repeat(start, (end - start) / step + 1).Select((x, index) => x + step * index).Sum();

Where, with (x,i)

var values = new List<int> { 100, 200, 300 };
foreach (var v in values.Select((x, i) => (x, i))) // x is the value, i is the index
    Console.WriteLine(v);
//output: (100, 0),(200, 1),(300, 2)
//(x, i+1): (100, 1), (200, 2), (300, 3)
                                        

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
using System.Text.RegularExpressions;
// \p{category} - In that Unicode category
// category = Lu - Letter, uppercase
// category = Ll - letter, lowercase
// [0-9] = numbers
// \W = non word character
int countUpper = Regex.Matches(s, @"\p{Lu}").Count;
int countLower = Regex.Matches(s, @"\p{Ll}").Count;
int countNumber= Regex.Matches(s, @"[0-9]").Count;
int countOther = Regex.Matches(s, @"\W").Count;
                                        
//Alternative
s.Count(char.IsUpper),
s.Count(char.IsLower),
s.Count(char.IsDigit),
s.Count(x => !char.IsLetterOrDigit(x))
                                        
//Check if string contains certain word, case insensitive
public static bool SpeakEnglish(string sentence)=> Regex.IsMatch(sentence, "(?i)english");
                                        
//replace a with b, and replace b with a
public static string Switcheroo(string x) => Regex.Replace(x, "[ab]", m => m.Value == "a" ? "b" : "a");
                                        
//Some options for Regex pattern. such as ignore case with (?i)
//https://learn.microsoft.com/en-us/dotnet/standard/base-types/regular-expression-options
public static int[] VowelIndices(string word) => Regex.Matches(word, "(?i)[aeiouy]").Select(m => m.Index + 1).ToArray();

//return only lowercase letter, number and underscore, length between 4 to 16 character
public static bool ValidateUsr(string username) => Regex.IsMatch(username, "^[a-z0-9_]{4,16}$");                 
                                        
Code reference : https://denhamcoder.files.wordpress.com/2019/11/110719_1134_netregexche1.png
ignore \
@"\b(\w)"
or 
"\b(\\w)"

set first character to the end and add ay (Seek 5 Kyu 040_Simple Pig Latin)
public static string PigIt(string str) =>Regex.Replace(str, @"(\w)(\w*)", "$2$1ay");
                     
Check vowels exist in object array without using Regex, then convert ASCII code to Char
 public static object[] IsVow(object[] a) =>
   a.Select(x => "aeiou".Contains(Convert.ToChar(x)) ? Convert.ToChar(x).ToString() : x).ToArray();

- Dictionary - 
using System.Collections.Generic;

Hash table (Seek 7 & 8 Kyu 311_Building Strings From a Hash)

public static string StringifyDict<TKey, TValue>(Dictionary<TKey, TValue> hash){
    foreach(KeyValuePair<TKey, TValue> element in hash)
            Console.WriteLine("Key:- {0} and Value:- {1}", element.Key, element.Value);
    return string.Join(",", hash.Select(x => $"{x.Key} = {x.Value}"));
  }

IDictionary<string, int> weight = new Dictionary<string, int>();
weight.Add(arr[i], sum);
                                        
//switch case
 public static string Boredom(Dictionary<string, string> staff){
    var score = staff.Sum(x => x.Value switch
    {
        "accounts" => 1,
        "finance" => 2,
        "canteen" => 10,
        "regulation" => 3,
        "trading" => 6,
        "change" => 6,
        "IS" => 8,
        "retail" => 5,
        "cleaning" => 4,
        "pissing about" => 25,
        _ => 0
    });
 }
   
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
                                        
- Object-oriented Programming OOP -
 //Create a class Human
//and from Human create 2 subclasses, Man and Woman

//Create new Human Array where [0] is Man and [1] is Woman
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
public class God{
  public static Human[] Create() => new Human[] {new Man(), new Woman()};
}
public class Human {}
public class Man : Human {}
public class Woman : Human {}

                                        
                                        
                                        
                                         - Date and Time -
                                        
Seek 7 & 8 Kyu(272_ Unlucky Days.cs)
//from month 1 to 12 (Jan to Dec)
//select date 13, count the number of day equals to Friday
//return the result
  public static int UnluckyDays(int year) => Enumerable.Range(1, 12).Select(x => new DateTime(year, x, 13)).Count(x => x.DayOfWeek == DayOfWeek.Friday);
