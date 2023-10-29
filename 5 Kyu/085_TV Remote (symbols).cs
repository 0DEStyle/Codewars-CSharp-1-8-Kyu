/*Challenge link:https://www.codewars.com/kata/5b3077019212cbf803000057/train/csharp
Question:
Hint
This Kata is an extension of the earlier ones in this series. Completing those first will make this task easier.

Background
My TV remote control has arrow buttons and an OK button.

I can use these to move a "cursor" on a logical screen keyboard to type words...

Keyboard
The screen "keyboard" layouts look like this

(please click the link at the start to see images.)

Keypad Mode 1 = alpha-numeric (lowercase)	Keypad Mode 3 = symbols
a	b	c	d	e	1	2	3
f	g	h	i	j	4	5	6
k	l	m	n	o	7	8	9
p	q	r	s	t	.	@	0
u	v	w	x	y	z	_	/
aA#	SP						
^	~	?	!	'	"	(	)
-	:	;	+	&	%	*	=
<	>	€	£	$	¥	¤	\
[	]	{	}	,	.	@	§
#	¿	¡				_	/
aA#	SP						
aA# is the SHIFT key. Pressing this key cycles through THREE keypad modes.

Mode 1 = alpha-numeric keypad with lowercase alpha (as depicted above)

Mode 2 = alpha-numeric keypad with UPPERCASE alpha

Mode 3 = symbolic keypad (as depicted above)

SP is the space character

The other (solid fill) keys in the bottom row have no function

Special Symbols
For your convenience, here are Unicode values for the less obvious symbols of the Mode 3 keypad

¡ = U-00A1	£ = U-00A3	¤ = U-00A4	¥ = U-00A5
§ = U-00A7	¿ = U-00BF	€ = U-20AC	
Kata task
How many button presses on my remote are required to type the given words?

Notes
The cursor always starts on the letter a (top left)
The inital keypad layout is Mode 1
Remember to also press OK to "accept" each letter
Take the shortest route from one letter to the next
The cursor wraps, so as it moves off one edge it will reappear on the opposite edge
Although the blank keys have no function, you may navigate through them if you want to
Spaces may occur anywhere in the words string
Do not press the SHIFT key until you need to. For example, with the word e.Z, the SHIFT change happens after the . is pressed (not before). In other words, do not try to optimize total key presses by pressing SHIFT early.
Example
words = Too Easy?

T => a-aA#-OK-U-V-W-X-Y-T-OK = 9
o => T-Y-X-W-V-U-aA#-OK-OK-a-b-c-d-e-j-o-OK = 16
o => o-OK = 1
space => o-n-m-l-q-v-SP-OK = 7
E => SP-aA#-OK-A-3-2-1--E-OK = 8
a => E-1-2-3-A-aA-OK-OK-a-OK = 9
s => a-b-c-d-i-n-s-OK = 7
y => s-x-y-OK = 3
? => y-x-w-v-u-aA#-OK-OK-^-~-?-OK = 11
Answer = 9 + 16 + 1 + 7 + 8 + 9 + 7 + 3 + 11 = 71

*Good Luck!
DM.*
*/

//***************Solution********************
using System;
using System.Collections.Generic;
using System.Linq;

public class Dinglemouse{
    private static int mode;
    
    public static int TvRemote(string word){
      //set mode to 0,
      mode = 0;
      //from word, select many from GetButtons function. Aggregate sum of each button, then get the final sum for all buttons.
      return word.SelectMany(GetButtons).Aggregate((Sum:0, PrevB:0), (a,b) => (a.Sum + Dist(a.PrevB, b), b)).Sum;
    }
    
    private static IEnumerable<int> GetButtons(char c){
      //mode 1
      string mode1 = "abcde123fghij456klmno789pqrst.@0uvwxyz_/↑ ☐☐☐☐☐☐"; 
      //mode 1, mode 2 uppercase, mode 3, store in kb
      var kb = new[] { mode1, mode1.ToUpper(), "^~?!'\"()-:;+&%*=<>€£$¥¤\\[]{},.@§#¿¡☐☐☐_/↑ ☐☐☐☐☐☐" };
      
      //rotate mode, while kb[mode++ % 3] doesn't contain char c. return 40
      while (!kb[mode++ % 3].Contains(c))
          yield return 40;
      //return kb[--mode % 3] of the index for char c
      yield return kb[--mode % 3].IndexOf(c);
    }
    
  //6 rows and 8 columns
    private static int Dist(int cur, int i){
      var cols = Math.Abs(i%8 - cur%8);
      var rows = Math.Abs(i/8 - cur/8);
      return 1 + Math.Min(6-rows, rows) + Math.Min(8-cols, cols);
    }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
public class SolutionTests
{
    [Test]
    public void Example()
    {
        Assert.AreEqual(71, Dinglemouse.TvRemote("Too Easy?"));
    }

    [Test]
    public void Lower()
    {
        Assert.AreEqual(16, Dinglemouse.TvRemote("does"));
        Assert.AreEqual(21, Dinglemouse.TvRemote("your"));
        Assert.AreEqual(33, Dinglemouse.TvRemote("solution"));
        Assert.AreEqual(18, Dinglemouse.TvRemote("work"));
        Assert.AreEqual(12, Dinglemouse.TvRemote("for"));
        Assert.AreEqual(27, Dinglemouse.TvRemote("these"));
        Assert.AreEqual(23, Dinglemouse.TvRemote("words"));
    }

    [Test]
    public void LowerEdge()
    {
        Assert.AreEqual(1, Dinglemouse.TvRemote("a"));
        Assert.AreEqual(30, Dinglemouse.TvRemote("aadvarks"));
        Assert.AreEqual(29, Dinglemouse.TvRemote("a/a/a/a/"));
        Assert.AreEqual(26, Dinglemouse.TvRemote("1234567890"));
        Assert.AreEqual(35, Dinglemouse.TvRemote("mississippi"));
    }

    [Test]
    public void Upper()
    {
        Assert.AreEqual(19, Dinglemouse.TvRemote("DOES"));
        Assert.AreEqual(22, Dinglemouse.TvRemote("YOUR"));
        Assert.AreEqual(34, Dinglemouse.TvRemote("SOLUTION"));
        Assert.AreEqual(19, Dinglemouse.TvRemote("WORK"));
        Assert.AreEqual(15, Dinglemouse.TvRemote("FOR"));
        Assert.AreEqual(28, Dinglemouse.TvRemote("THESE"));
        Assert.AreEqual(24, Dinglemouse.TvRemote("WORDS"));
    }

    [Test]
    public void Symbols()
    {
        Assert.AreEqual(33, Dinglemouse.TvRemote("^does^"));
        Assert.AreEqual(53, Dinglemouse.TvRemote("$your$"));
        Assert.AreEqual(49, Dinglemouse.TvRemote("#solution#"));
        Assert.AreEqual(34, Dinglemouse.TvRemote("\u00bfwork\u00bf"));
        Assert.AreEqual(38, Dinglemouse.TvRemote("{for}"));
        Assert.AreEqual(57, Dinglemouse.TvRemote("\u00a3these\u00a3"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("?symbols?"));
    }

    [Test]
    public void SymbolsEdge()
    {
        Assert.AreEqual(5, Dinglemouse.TvRemote("^"));
        Assert.AreEqual(44, Dinglemouse.TvRemote("..._^_--9__")); // same char but on different keypads
        var underline = Dinglemouse.TvRemote("\u005f");
        Assert.AreEqual(underline, Dinglemouse.TvRemote("_")); // same character via ascii/unicode
        Assert.AreEqual(34, Dinglemouse.TvRemote("^/^/^/a/"));
        Assert.AreEqual(21, Dinglemouse.TvRemote("^,@/_"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("m\u00a1$$\u00a1$$\u00a1pp\u00a1"));
    }

    [Test]
    public void All()
    {
        var mode1 = "abcde123fghij456klmno789pqrst.@0uvwxyz_/ ";
        var mode2 = "ABCDE123FGHIJ456KLMNO789PQRST.@0UVWXYZ_/ ";
        var mode3 = "^~?!'\"()-:;+&%*=<>\u20ac\u00a3$\u00a5\u00a4\\[]{},.@\u00a7#\u00bf\u00a1_/ ";
        Assert.AreEqual(87, Dinglemouse.TvRemote(mode1));
        Assert.AreEqual(90, Dinglemouse.TvRemote(mode2));
        Assert.AreEqual(88, Dinglemouse.TvRemote(mode3));
    }

    [Test]
    public void UpperEdge()
    {
        Assert.AreEqual(4, Dinglemouse.TvRemote("A"));
        Assert.AreEqual(33, Dinglemouse.TvRemote("AADVARKS"));
        Assert.AreEqual(32, Dinglemouse.TvRemote("A/A/A/A/"));
        Assert.AreEqual(26, Dinglemouse.TvRemote("1234567890"));
        Assert.AreEqual(38, Dinglemouse.TvRemote("MISSISSIPPI"));
    }

    [Test]
    public void Mixed()
    {
        Assert.AreEqual(29, Dinglemouse.TvRemote("Does"));
        Assert.AreEqual(34, Dinglemouse.TvRemote("Your"));
        Assert.AreEqual(46, Dinglemouse.TvRemote("Solution"));
        Assert.AreEqual(27, Dinglemouse.TvRemote("Work"));
        Assert.AreEqual(21, Dinglemouse.TvRemote("For"));
        Assert.AreEqual(36, Dinglemouse.TvRemote("These"));
        Assert.AreEqual(32, Dinglemouse.TvRemote("Words"));
    }

    [Test]
    public void Xox()
    {
        Assert.AreEqual(54, Dinglemouse.TvRemote("Xoo ooo ooo"));
        Assert.AreEqual(66, Dinglemouse.TvRemote("oXo ooo ooo"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("ooX ooo ooo"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("ooo Xoo ooo"));
        Assert.AreEqual(66, Dinglemouse.TvRemote("ooo oXo ooo"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("ooo ooX ooo"));
        Assert.AreEqual(54, Dinglemouse.TvRemote("ooo ooo Xoo"));
        Assert.AreEqual(66, Dinglemouse.TvRemote("ooo ooo oXo"));
        Assert.AreEqual(53, Dinglemouse.TvRemote("ooo ooo ooX"));
    }

    [Test]
    public void Sentences()
    {
        Assert.AreEqual(262, Dinglemouse.TvRemote("The Quick Brown Fox Jumps Over A Lazy Dog."));
        Assert.AreEqual(250, Dinglemouse.TvRemote("Pack My Box With Five Dozen Liquor Jugs."));
    }

    [Test]
    public void Spaces()
    {
        Assert.AreEqual(0, Dinglemouse.TvRemote(""));
        Assert.AreEqual(3, Dinglemouse.TvRemote(" "));
        Assert.AreEqual(5, Dinglemouse.TvRemote("   "));
        Assert.AreEqual(30, Dinglemouse.TvRemote("    x   X    "));
    }

    // ====================================

    private class Solution
    {
        // Three KB layouts depending on the "aA#" SHIFT mode
        private static string[] KB =
        {
            "abcde123fghij456klmno789pqrst.@0uvwxyz_/| ||||||",
            "ABCDE123FGHIJ456KLMNO789PQRST.@0UVWXYZ_/| ||||||",
            "^~?!'\"()-:;+&%*=<>\u20ac\u00a3$\u00a5\u00a4\\[]{},.@\u00a7#\u00bf\u00a1|||_/| ||||||"
        };

        private static int HEIGHT = 6, WIDTH = 8;

        public static int TvRemote(string words)
        {
            int n = 0, prevx = 0, prevy = 0, mode = 0, idx = -1;

            foreach (var c in words)
            {

                // If character not on this keyboard then need to toggle the SHIFT key
                if ((idx = KB[mode].IndexOf(c)) == -1)
                {
                    // navigate to the SHIFT key
                    int tx = Math.Min(prevx, WIDTH - prevx);
                    int ty = Math.Abs(HEIGHT - 1 - prevy); ty = Math.Min(ty, HEIGHT - ty);
                    n += tx + ty;
                    while ((idx = KB[mode].IndexOf(c)) == -1)
                    {
                        n++; // + 1 for the OK button          
                        mode = (mode + 1) % 3;
                    }
                    prevx = 0; prevy = HEIGHT - 1;
                }

                int y = idx / WIDTH, x = idx % WIDTH;
                int dx = Math.Abs(x - prevx); dx = Math.Min(dx, WIDTH - dx);
                int dy = Math.Abs(y - prevy); dy = Math.Min(dy, HEIGHT - dy);
                n += dx + dy + 1; // + 1 for the OK button
                prevx = x; prevy = y;
            }
            return n;
        }
    }

    // Spaces are repeated deliberately so they appear more frequently :-)
    private static string KB_LETTERS_AND_SYMBOLS =
    "   abcdefghijklmnopqrstuvwxyz 1234567890 .@_/" +   // lower alpha-num
    "   ABCDEFGHIJKLMNOPQRSTUVWXYZ 1234567890 .@_/" +   // upper alpha-num
    "   ^~?!'\"()-:;+&%*=<>$\\[]{}#,.@_/" +             // ascii symbols
    "   \u20ac\u00a3\u00a5\u00a4\u00a7\u00bf\u00a1";    // unicode symbols

    [Test]
    public void Random()
    {
        var random = new Random();
        for (int r = 0; r < 200; r++)
        {
            var wlen = random.Next(1, 31);
            var words = "";
            for (int i = 0; i < wlen; i++)
                words += KB_LETTERS_AND_SYMBOLS[random.Next(KB_LETTERS_AND_SYMBOLS.Length)];
            Console.WriteLine($"Random test #{r + 1} words: {words}");
            var expected = Solution.TvRemote(words);
            Assert.AreEqual(expected, Dinglemouse.TvRemote(words));
        }
    }
}
