/*Challenge link:https://www.codewars.com/kata/537e18b6147aa838f600001b/train/csharp
Question:
Your task in this Kata is to emulate text justification in monospace font. You will be given a single-lined text and the expected justification width. The longest word will never be greater than this width.

Here are the rules:

Use spaces to fill in the gaps between words.
Each line should contain as many words as possible.
Use '\n' to separate lines.
Gap between words can't differ by more than one space.
Lines should end with a word not a space.
'\n' is not included in the length of a line.
Large gaps go first, then smaller ones ('Lorem--ipsum--dolor--sit-amet,' (2, 2, 2, 1 spaces)).
Last line should not be justified, use only one space between words.
Last line should not contain '\n'
Strings with one word do not need gaps ('somelongword\n').
Example with width=30:

Lorem  ipsum  dolor  sit amet,
consectetur  adipiscing  elit.
Vestibulum    sagittis   dolor
mauris,  at  elementum  ligula
tempor  eget.  In quis rhoncus
nunc,  at  aliquet orci. Fusce
at   dolor   sit   amet  felis
suscipit   tristique.   Nam  a
imperdiet   tellus.  Nulla  eu
vestibulum    urna.    Vivamus
tincidunt  suscipit  enim, nec
ultrices   nisi  volutpat  ac.
Maecenas   sit   amet  lacinia
arcu,  non dictum justo. Donec
sed  quam  vel  risus faucibus
euismod.  Suspendisse  rhoncus
rhoncus  felis  at  fermentum.
Donec lorem magna, ultricies a
nunc    sit    amet,   blandit
fringilla  nunc. In vestibulum
velit    ac    felis   rhoncus
pellentesque. Mauris at tellus
enim.  Aliquam eleifend tempus
dapibus. Pellentesque commodo,
nisi    sit   amet   hendrerit
fringilla,   ante  odio  porta
lacus,   ut   elementum  justo
nulla et dolor.
Also you can always take a look at how justification works in your text editor or directly in HTML (css: text-align: justify).

Have fun :)


*/

//***************Solution********************
//regex ref: https://denhamcoder.files.wordpress.com/2019/11/110719_1134_netregexche1.png

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Solution {
  public class Kata{
    public static string Justify(string s, int l){  
      Console.WriteLine($"Len: {l}, {s}");
      //string interpolation to check match, anchor \G where previous match ends
      var strSplit = Regex.Matches(s, @$"\G.{{1,{l}}}( |$)").Cast<Match>().Select(x => x.Value.Trim()).ToArray();
      //positive lookbehind that matches any non-whitespace, followed by a whtiespace
      var pattern = new Regex(@"(?<=\S) ");
      int quotient = 0, remainder = 0;
      
      //up to strSplit.Count - 1, since index start at 1 not 0
        for (int i = 0; i < strSplit.Count() - 1; i++){
          //split elements inside strSplit into lines, then split lines into words.
          string lines = strSplit[i];    
          var words = lines.Split(' ');
          //required length - whatever the length of the current line
          int spaceLeft = l - lines.Length;
          
          if(words.Length > spaceLeft)
            lines = pattern.Replace(lines, "  ", spaceLeft);
          //repeat quotient amount of time for ' ', repeat remainder amount of time for "  "
          else if(words.Length > 1){
            quotient = Math.DivRem(spaceLeft, words.Length - 1,out remainder);
            lines = pattern.Replace(lines,  new string(' ', quotient + 1));
            lines = pattern.Replace(lines, "  ", remainder);
          }
          //after the process, store lines into current strSplit
          strSplit[i] = lines;
          }
      return string.Join("\n",strSplit);
    }
  }
}

//better solution
namespace Solution {
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  public class Kata {
    public static string Justify(string text, int width) =>
      string.Join("\n", (text ?? string.Empty).Split(" ")
        .Aggregate(new List<List<StringBuilder>>(new[]{ new List<StringBuilder>() }), (lines, word) => {
          var line = lines.Last();
          var blank = width - string.Join(" ", line).Length;
          if (blank > word.Length) {
            line.Add(new StringBuilder(word));
          } else {
            if (line.Count > 1)
              for (var i=0; i<blank; i++)
                line[i%(line.Count-1)].Append(" ");
            lines.Add(new[]{ new StringBuilder(word) }.ToList());
          }
          return lines;
      }).Select(line => string.Join(" ", line)));
  }
}

//no regex
using System.Linq;
using System;

namespace Solution 
{
  public class Kata
  {
    public static string Justify(string str, int len)
    { 
      if (String.IsNullOrEmpty(str))
        return "";

      string result = "", line = "";
      var words = str.Split();
      foreach (var word in words)
      {
          if (line.Length + word.Length > len)
          {
            result += BuildLine(line, len);
            line = word + " ";  
          }
          else
            line += word + " ";
      }
      
      return result + line.Trim();
    }
    
    public static string BuildLine(string line, int len)
    {
      var words = line.Trim().Split();
      if (words.Length == 1)
        return words[0]+"\n";
      
      int wordsLength = words.Sum(x => x.Length);
      int wordsIndex = 0;
      
      //append spaces for each word except last
      for (int i = len - wordsLength; i > 0; i--)
      {
        if (wordsIndex == words.Length - 1)
          wordsIndex = 0;
        words[wordsIndex++] += " ";
      }
//****************Sample Test*****************
      namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Collections.Generic;
  using System.Text;
  [TestFixture]
  public class SolutionTest
  {
       [Test]
        public void MyTest()
        {
            var str = 
              "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " + 
              "Vestibulum sagittis dolor mauris, at elementum ligula tempor eget. " + 
              "In quis rhoncus nunc, at aliquet orci. Fusce at dolor sit amet felis suscipit tristique. " + 
              "Nam a imperdiet tellus. Nulla eu vestibulum urna. Vivamus tincidunt suscipit enim, " + 
              "nec ultrices nisi volutpat ac. Maecenas sit amet lacinia arcu, non dictum justo. " + 
              "Donec sed quam vel risus faucibus euismod. Suspendisse rhoncus rhoncus felis at fermentum. " + 
              "Donec lorem magna, ultricies a nunc sit amet, blandit fringilla nunc. " + 
              "In vestibulum velit ac felis rhoncus pellentesque. Mauris at tellus enim. " + 
              "Aliquam eleifend tempus dapibus. Pellentesque commodo, nisi sit amet hendrerit fringilla, " + 
              "ante odio porta lacus, ut elementum justo nulla et dolor.";
          
            Assert.AreEqual("", Kata.Justify("", 2), "Expect empty string for empty string");
            var lengths = new int[] {15, 20, 25, 30, 50, 75, 100};

            foreach (var length in lengths)
            {
                var expected = Justify(str, length);
                var actual = Kata.Justify(str, length);
                Assert.AreEqual(expected, actual, "Expected different result:");
                Assert.AreEqual(expected.Length, actual.Length, "Expected different amount of characters");

            }
        }
        private static string Justify(string str, int len)
        {
            if (string.IsNullOrEmpty(str)) return "";
            var queue = new Queue<string>(str.Split(' '));
            var builder = new StringBuilder();
            while (queue.Count > 0)
            {
                var temp = new List<string> { queue.Dequeue() };
                while (queue.Count > 0 && string.Join(" ", temp).Length + queue.Peek().Length < len)
                    temp.Add(queue.Dequeue());
                var missingspaces = len - string.Join(" ", temp).Length;
                var i = 0;
                while (missingspaces > 0 && queue.Count > 0 && temp.Count > 1)
                {
                    temp[i % (temp.Count - 1)] += " ";
                    i++;
                    missingspaces--;
                }
                builder.Append(string.Join(" ", temp));
                if (queue.Count > 0) builder.Append('\n');
            }
            return builder.ToString();
        }
  }
}
