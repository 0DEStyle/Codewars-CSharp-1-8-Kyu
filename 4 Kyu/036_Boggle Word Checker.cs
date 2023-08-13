/*Challenge link:https://www.codewars.com/kata/57680d0128ed87c94f000bfd/train/csharp
Question:
Write a function that determines whether a string is a valid guess in a Boggle board, as per the rules of Boggle. A Boggle board is a 2D array of individual characters, e.g.:

[ ["I","L","A","W"],
  ["B","N","G","E"],
  ["I","U","A","O"],
  ["A","S","R","L"] ]
Valid guesses are strings which can be formed by connecting adjacent cells (horizontally, vertically, or diagonally) without re-using any previously used cells.

For example, in the above board "BINGO", "LINGO", and "ILNBIA" would all be valid guesses, while "BUNGIE", "BINS", and "SINUS" would not.

Your function should take two arguments (a 2D array and a string) and return true or false depending on whether the string is found in the array as per Boggle rules.

Test cases will provide various array and string sizes (squared arrays up to 150x150 and strings up to 150 uppercase letters). You do not have to check whether the string is a real word or not, only if it's a valid guess.
*/

//***************Solution********************
using System.Linq;
public class Boggle{
  private string w;
  private char[][] b;
  
  //pass in the word and board.
  public Boggle(char[][] board, string word){  
    w = word;
    b = board;
  }
  
  //select row in b, then select element in row, pass the index r and c into TryCell
  public bool Check() => b.Where((a,r) => a.Where((ch, c) => TryCell(r, c, 0)).Any()).Any();
  
  
  private bool TryCell(int r, int c, int n){
    
    //if index r and c are out of bound or word does not match return false.
    if (r < 0 || r >= b.Length || c < 0 || c >= b.Length || b[r][c] != w[n]) 
      return false;   
    
    //check word length matches ++n
    if (++n == w.Length) 
      return true;
    
    //overwrite board index r and c with '_'
    b[r][c] = '_';  
    
    //Recursive method to check neightbouring cells, horizontally, vertically, or diagonally 8 directions
    var anyDirValid = ( TryCell(r-1, c-1, n) || TryCell(r-1, c, n) || TryCell(r-1, c+1, n) ||    
                        TryCell(r,   c-1, n)                       || TryCell(r,   c+1, n) ||
                        TryCell(r+1, c-1, n) || TryCell(r+1, c, n) || TryCell(r+1, c+1, n) );
    
    //shift the character
    b[r][c] = w[n-1];
    return anyDirValid;
  }
}
//****************Sample Test*****************
using NUnit.Framework;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
public class SolutionTest
{
    private char[][] DeepCopy(char[][] arr)
    {
        return arr.Select(a =>
       {
           var target = new char[a.Length];
           Array.Copy(a, target, a.Length);
           return target;
       }).ToArray();
    }

    [Test]
    public void SampleTests()
    {
        char[][] board =
        {
            new []{'E','A','R','A'},
            new []{'N','L','E','C'},
            new []{'I','A','I','S'},
            new []{'B','Y','O','R'}
        };

        var toCheck = new[] { "C", "EAR", "EARS", "BAILER", "RSCAREIOYBAILNEA", "CEREAL", "ROBES" };
        var expecteds = new[] { true, true, false, true, true, false, false };

        for (int i = 0; i < toCheck.Length; i++)
        {
            Assert.AreEqual(expecteds[i], new Boggle(DeepCopy(board), toCheck[i]).Check());
        }
    }

    [Test]
    public void Grid_5x5()
    {
        char[][] board = {
        new []{'T','T','M','D','A'},
        new []{'G','Y','I','N','N'},
        new []{'P','A','L','C','E'},
        new []{'I','A','U','L','G'},
        new []{'A','M','I','N','A'}
    };

        var toCheck = new[] { "T", "TT", "YTG", "ANIMA", "ANIMAL", "MINGLE", "GCLLAUP", "ANIMALITY", "ANIMALAMINA", "ECLINCL", "PLACE", "PALACE", "MGYIGA", "Z", "WHATEVER", "AKGJEIKO", "ALLO", "AMINLGIA" };
        var expecteds = new[] { true, true, true, true, true, true, false, true, false, false, false, false, false, false, false, false, false, false };

        for (int i = 0; i < toCheck.Length; i++)
        {
            Assert.AreEqual(expecteds[i], new Boggle(DeepCopy(board), toCheck[i]).Check());
        }
    }

    [Test]
    public void Grid_7x7()
    {
        char[][] board =
        {
            new []{'L','H','A','R','R','G','A'},
            new []{'H','O','E','A','Y','C','L'},
            new []{'C','A','B','D','T','E','U'},
            new []{'C','N','A','Y','O','D','A'},
            new []{'R','O','K','T','L','I','R'},
            new []{'P','N','I','A','P','T','V'},
            new []{'G','M','S','E','M','R','S'}
        };

        var toCheck = new[]{"SEAMS",           "IKTLOTDAEULCYRGA", "IKTLOTDAEULCYRGAR",  "KITLITVSRMPAESMNONAABDTOD", "LHOABDTEUDARVSRTVS",
                          "ABDOTYTEDLOTYCL",  "LHARRGALUARVSRM",  "LOBEDATLPEAS",       "ROKANTYD",                  "CONATODE",
                          "TRIDENT",          "STRIDE",           "ACETYLATIONS",       "VIDEOTAPES",                "EPILATIONS",
                          "FOG" };
        var expecteds = new[]{false,              true,               false,               true,                        false,
                           false,              true,               true,                false,                       true,
                           false,              true,               true,                true,                        true,
                           false };

        for (int i = 0; i < toCheck.Length; i++)
        {
            Assert.AreEqual(expecteds[i], new Boggle(DeepCopy(board), toCheck[i]).Check());
        }
    }

    /* ********************
           RANDOM TESTS
     * ********************/
    private class BoggleTest
    {

        private Point[] MOVES = 
        {
            new Point(-1, -1), new Point(-1, 0), new Point(-1, 1),
            new Point(0, -1), new Point(0, 1), new Point(1, -1),
            new Point(1, 0), new Point(1, 1)
        };
        private char[][] board;
        private string word;

        public BoggleTest(char[][] board, string word)
        {
            this.board = board;
            this.word = word;
        }

        public bool Check()
        {
            for (int x = 0; x < board.Length; x++)
                for (int y = 0; y < board[x].Length; y++)
                    if (word[0] == board[x][y])
                    {
                        var isPresent = DfsCheck(1, new Point(x, y));
                        if (isPresent) return true;
                    }
            return false;
        }

        private bool DfsCheck(int iC, Point p)
        {
            if (iC == word.Length) return true;

            var wasC = board[p.X][p.Y];
            board[p.X][p.Y] = '\0';
            var isPresent = MOVES.Select(m => new Point(m.X + p.X, m.Y + p.Y))
                .Where(m => 0 <= m.X && m.X < board.Length && 0 <= m.Y && m.Y < board.Length && board[m.X][m.Y] == word[iC])
                .Any(m => DfsCheck(iC + 1, m));
            board[p.X][p.Y] = wasC;
            return isPresent;
        }
    }

    private static Random rand = new Random();

    private int RN(int x) => RN(x, 0);
    private int RN(int x, int y) => y + rand.Next(x);

    private char[][] GenRndBoard(int n)
    {
        var b = new char[n][];
        for (int x = 0; x < n; x++)
        {
            b[x] = new char[n];
            for (int y = 0; y < n; y++)
                b[x][y] = (char)RN(26, 65);
        }
        return b;
    }

    private string CrawlWord(char[][] board, bool isValid)
    {
        int size = board.Length,
            dir = RN(2) == 1 ? 1 : -1,
            x = (RN(4) * dir + size - 1) % size,
            y = RN(Math.Max(1, size / 2), size / 4),
            len = RN(Math.Max(1, size - 5), 5);

        var isSwapped = false;
        StringBuilder sb = new StringBuilder();
        while (sb.Length < len)
        {
            if (isValid || RN(100) > 10) sb.Append(board[x][y]);
            else sb.Append((char)RN(26, 65));
            x = isSwapped ? Math.Max(-1, Math.Min(size, x + RN(3, -1))) : x + dir;
            y = isSwapped ? y + dir : Math.Max(-1, Math.Min(size, y + RN(3, -1)));
            if (x == -1 || x == size || y == -1 || y == size) break;
            if (RN(200) < 5) isSwapped = !isSwapped;

        }
        return sb.ToString();
    }

    private string GenRndStr(char[][] board, int n)
    {
        return string.Concat(Enumerable.Range(0, n).Select(i => $"{board[RN(board.Length)][RN(board.Length)]}"));
    }


    [Test]
    public void TestsRandom()
    {
        foreach (var sb in new int[] { 15, 30, 50, 80 })
        {
            for (int r = 0; r < 40; r++)
            {
                char[][] board = GenRndBoard(RN(sb * 2 / 5, sb));

                for (int t = 0; t < 100; t++)
                {
                    var word = CrawlWord(board, RN(10) > 0);
                    if (word.Length < 3) word = GenRndStr(board, RN(7, sb - 4));
                    var expected = new BoggleTest(board, word).Check();
                    var actual = new Boggle(DeepCopy(board), word).Check();
                    Assert.AreEqual(expected, actual);
                }
            }
        }
    }
}
