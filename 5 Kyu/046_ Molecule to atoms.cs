/*Challenge link:https://www.codewars.com/kata/52f831fa9d332c6591000511/train/csharp
Question:
For a given chemical formula represented by a string, count the number of atoms of each element contained in the molecule and return an object (associative array in PHP, Dictionary<string, int> in C#, Map<String,Integer> in Java).

For example:

Kata.ParseMolecule("H2O"); // => new Dictionary<string, int> {{"H", 2}, {"O", 1}}
Kata.ParseMolecule("Mg(OH)2"); // => new Dictionary<string, int> {{"Mg", 1}, {"O", 2}, {"H", 2}}
Kata.ParseMolecule("K4[ON(SO3)2]2"); // => new Dictionary<string, int> {{"K", 4}, {"O", 14}, {"N", 2}, {"S", 4}}
As you can see, some formulas have brackets in them. The index outside the brackets tells you that you have to multiply count of each atom inside the bracket on this index. For example, in Fe(NO3)2 you have one iron atom, two nitrogen atoms and six oxygen atoms.

Note that brackets may be round, square or curly and can also be nested. Index after the braces is optional.


*/

//***************Solution********************
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class Kata{
  //to either return key or value.
    public static V SafeGetValue<K, V>(this Dictionary<K, V> dict, K key, V value = default(V))
        => dict.ContainsKey(key) ? dict[key] : value;
  
    public static Dictionary<string, int> ParseMolecule(string formula){
      //create a stack format to read.
        var factor = new Stack<int>(); 
        factor.Push(1); 
        factor.Push(1);
      
        var result = new Dictionary<string, int>();
      //capture group <e>: element, find A-Za-z match 0 or more
      //capture group <n>: any digit from 0-9 with one or more
      //capture group <l>: match left bracket '[' '(' '{' , \ before it means escaped character 
      //capture group <r>: match right bracket ']' ')' '}'
        var lexems = Regex.Matches(formula, @"(?<e>[A-Z][a-z]*)|(?<n>\d+)|(?<l>[\[({])|(?<r>[\])}])");

      //pop: return top of stack and remove it
      //peek: return top of stack without remove it
      //push: insert object into top of stack.
        foreach (var lexem in lexems.Cast<Match>().Reverse()){
          //capture group n for number
            if (lexem.Groups["n"].Success)
                factor.Push(factor.Pop() * int.Parse(lexem.Value));
          
          //capture group l for left
            if (lexem.Groups["l"].Success){
                factor.Pop();
                factor.Pop();
                factor.Push(factor.Peek());
            }
          
          //capture group r for right
            if (lexem.Groups["r"].Success)
                factor.Push(factor.Peek());
          
          //capture group e for element
            if (lexem.Groups["e"].Success){
                result[lexem.Value] = factor.Pop() + result.SafeGetValue(lexem.Value);
                factor.Push(factor.Peek());
            }
        }

        return result;
    }
}
//****************Sample Test*****************

namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text.RegularExpressions;

  [TestFixture]
  public class ParseMoleculeTest
  {
    [Test]
    public void DescriptionExampleTests()
    {
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"H", 2}, {"O", 1}}, Kata.ParseMolecule("H2O"));
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Mg", 1}, {"O", 2}, {"H", 2}}, Kata.ParseMolecule("Mg(OH)2"));
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"K", 4}, {"O", 14}, {"N", 2}, {"S", 4}}, Kata.ParseMolecule("K4[ON(SO3)2]2"));
    }
    [Test]
    public void FixedTests()
    {
      Console.WriteLine("Real-life examples");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"B", 2}, {"H", 6}}, Kata.ParseMolecule("B2H6"), "Your function should correctly parse diborane");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"C", 6}, {"H", 12}, {"O", 6}}, Kata.ParseMolecule("C6H12O6"), "Your function should correctly parse glucose");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Mo", 1}, {"C", 6}, {"O", 6}}, Kata.ParseMolecule("Mo(CO)6"), "Your function should also work for molybdenum hexacarbonyl");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Fe", 1}, {"C", 10}, {"H", 10}}, Kata.ParseMolecule("Fe(C5H5)2"), "Your function should also work for ferrocene");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"C", 8}, {"H", 8}, {"Fe", 1}, {"O", 2}}, Kata.ParseMolecule("(C5H5)Fe(CO)2CH3"), "Your function should correctly parse cyclopentadienyliron dicarbonyl dimer");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Pd", 1}, {"P", 4}, {"C", 72}, {"H", 60}}, Kata.ParseMolecule("Pd[P(C6H5)3]4"), "Your function should correctly parse tetrakis(triphenylphosphine)palladium(0)");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"As", 2}, {"Be", 16}, {"C", 44}, {"B", 8}, {"Co", 24}, {"O", 48}, {"Cu", 5}}, Kata.ParseMolecule("As2{Be4C5[BCo3(CO2)3]2}4Cu5"), "Your function should also correctly parse As2{Be4C5[BCo3(CO2)3]2}4Cu5");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Co", 4}, {"N", 12}, {"H", 42}, {"O", 18}, {"S", 3}}, Kata.ParseMolecule("{[Co(NH3)4(OH)2]3Co}(SO4)3"), "Your function should correctly parse hexol sulphate");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"C", 4}, {"H", 4}, {"O", 4}}, Kata.ParseMolecule("C2H2(COOH)2"), "Your function should correctly parse maleic acid");
    }
    [Test]
    public void EdgeTests()
    {
      Console.WriteLine("Syntactically valid (but not necessarily chemically correct) \"chemical formulae\" ;)");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"H", 2}, {"O", 1}}, Kata.ParseMolecule("{((H)2)[O]}"), "Should work for an \"evilized\" version of a water molecule");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Uun", 42}, {"Uuu", 103}, {"Uub", 103}, {"Uut", 103}, {"Uuq", 1442}, {"Uup", 33166}, {"Uuh", 33166}, {"Ts", 1442}, {"Og", 1442}, {"Uue", 1442}, {"Ubn", 1442}}, Kata.ParseMolecule("Uun42((UuuUubUut)(Uuq(UupUuh)23Ts(OgUue)Ubn)14)103"), "Your function should correctly parse a \"chemical formula\" from Dante's seventh circle of hell ;)");
      CollectionAssert.AreEquivalent(new Dictionary<string, int> {{"Ubn", 46}, {"Ubu", 46}, {"Ubb", 46}, {"Ubt", 805}, {"Ubq", 805}, {"Ubp", 391}, {"Ubh", 8602}, {"Ubs", 25806}, {"Ubo", 25806}, {"Ube", 8602}, {"Utn", 391}}, Kata.ParseMolecule("((UbnUbuUbb)2((Ubt)(Ubq))35((Ubp(Ubh(UbsUbo)3Ube)22Utn)17))23"), "Your function should correctly parse a \"chemical formula\" from the bottomless pit of the Book of Revelation ;)");
    }
    protected static Dictionary<string, int> Solution(string s)
    {
      string r = new Regex("\\)([^\\d])").Replace(new Regex("\\)$").Replace(new Regex("\\]|\\}").Replace(new Regex("\\[|\\{").Replace(s, "("), ")"), ")1"), new MatchEvaluator(m => ")1" + m.Groups[1].Value));
      Regex repeatPattern = new Regex("\\(([^()]+)\\)(\\d+)");
      MatchEvaluator unroll = new MatchEvaluator(m => String.Join("", Enumerable.Repeat(m.Groups[1].Value, Int32.Parse(m.Groups[2].Value)).ToArray()));
      while (repeatPattern.IsMatch(r)) r = repeatPattern.Replace(r, unroll);
      r = new Regex("([A-Z][a-z]*)(\\d+)").Replace(r, unroll);
      string[] a = new Regex("[A-Z][a-z]*").Matches(r).OfType<Match>().Select(m => m.Value).ToArray();
      string[] elements = new HashSet<string>(a).ToArray();
      Dictionary<string, int> result = new Dictionary<string, int>();
      for (int i = 0; i < elements.Length; i++) result.Add(elements[i], a.Where(e => e == elements[i]).Count());
      return result;
    }
    protected const int RANDOM_MOLECULE_MAX_NESTING = 4;
    protected static readonly string[] Elements = new string[] {"H", "He", "Li", "Be", "B", "C", "O", "N", "F", "Ne", "Na", "Mg", "Al", "Si", "P", "S", "Cl", "Ar", "K", "Ca", "Fe", "U", "Uun", "Uuu", "Uub", "Uup", "Uuo", "Ubn", "Utn", "Uqn"};
    protected static readonly Random Rng = new Random();
    protected static string RandomMolecule() => String.Join("", Enumerable.Range(1, Rng.Next(3, 8)).ToArray().Select(_ => Rng.NextDouble() < 0.5d ? "(" + RandomMolecule(RANDOM_MOLECULE_MAX_NESTING - 1) + ")" + Rng.Next(2, 14) : Elements[Rng.Next(0, Elements.Length)]).ToArray());
    protected static string RandomMolecule(int n) => String.Join("", Enumerable.Range(1, Rng.Next(3, 8)).ToArray().Select(_ => Rng.NextDouble() < 0.5d && n > 0 ? "(" + RandomMolecule(n - 1) + ")" + Rng.Next(2, 14) : Elements[Rng.Next(0, Elements.Length)]).ToArray());
    [Test]
    public void HugeRandomFictionalMoleculeTest()
    {
      Console.WriteLine("One super-complex random \"chemical formula\" ;)");
      string s = RandomMolecule();
      Console.WriteLine("Testing for chemical formula " + s);
      CollectionAssert.AreEquivalent(Solution(s), Kata.ParseMolecule(s));
    }
  }
}
