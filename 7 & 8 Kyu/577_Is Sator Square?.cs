/*Challenge link:https://www.codewars.com/kata/5cb7baa989b1c50014a53333/train/csharp
Question:
A Discovery
One fine day while tenaciously turning the soil of his fields, Farmer Arepo found a square stone tablet with letters carved into it... he knew such artifacts may 'show a message in four directions', so he wisely kept it. As he continued to toil in his work with his favourite rotary plough, he found more such tablets, but with so many crops to sow he had no time to decipher them all.

Your Task
Please help Farmer Arepo by inspecting each tablet to see if it forms a valid Sator Square!

//see image in link

sator square
The Square
is a two-dimentional palindrome, made from words of equal length that can be read in these four ways:

    1)    left-to-right    (across)
    2)    top-to-bottom    (down)
    3)    bottom-to-top    (up)
    4)    right-to-left    (reverse)
An Example
Considering this square:

    B A T S
    A B U T
    T U B A
    S T A B
Here are the four ways a word (in this case "TUBA") can be read:
//see image in link
                         down
                          ↓
           B A T S    B A T S    B A T S    B A T S
           A B U T    A B U T    A B U T    A B U T ← reverse
  across → T U B A    T U B A    T U B A    T U B A
           S T A B    S T A B    S T A B    S T A B
                                   ↑
                                   up
IMPORTANT:

In a true Sator Square, ALL of its words can be read in ALL four of these ways.
If there is any deviation, it would be false to consider it a Sator Square.
Some Details
tablet (square) dimensions range from 2x2 to 33x33 inclusive
all characters used will be upper-case alphabet letters
there is no need to validate any input
Input
an N x N (square) two-dimentional matrix of uppercase letters
Output
boolean true or false whether or not the tablet is a Sator Square
*/

//***************Solution********************
namespace Kata{
    class Solution{
        public static bool IsSatorSquare(char[,] tablet){
          //find size of tablet
          int size = tablet.GetLength(0);
          
          //loop through each cell
          //check for false, if cell [i, j] is the different than cell [j, i] or
          //cell[i ,j] is different to cell [size - i - 1, size - j - 1]
          for(int i = 0; i < size; i++){
            for(int j = 0; j < size; j++)
              if(tablet[i, j] != tablet[j, i]  ||  tablet[i ,j] != tablet[size - i - 1, size - j - 1])
                return false;
              }
        return true;
        }
    }
}

//****************Sample Test*****************
namespace IsSatorSquare
{
  using System.Collections.Generic;
  using NUnit.Framework;
  using System.Linq;
  using System.Text;
  using System;
  
  [TestFixture]
  public class Fixed_Tests
  {
    private static void Tester(char[,] tablet, bool expected)
    {
      bool submitted = Kata.Solution.IsSatorSquare(tablet);
      string message = "";
      if(submitted != expected)
      {
        int n = tablet.GetLength(0);
        StringBuilder square = new StringBuilder("\n", (n + 3) * (n + 3));
        foreach(int i in Enumerable.Range(0, n))
        {
          StringBuilder row = new StringBuilder("", (n + 3));
          foreach(int j in Enumerable.Range(0, n))
          {
            row.Append(tablet[i, j] + " ");
          }
          square.AppendLine(row.ToString());
        }
        message = square.ToString();
      }
      Assert.AreEqual(expected, submitted, message);
    }
    [Test]
    public void Test01()
    {
      char[,] tablet = new char[2, 2] {{ 'A', 'H' },
                                       { 'H', 'A' }};
      Tester(tablet, true);
    }
    [Test]
    public void Test02()
    {
      char[,] tablet = new char[3, 3] {{ 'N', 'O', 'T' },
                                       { 'O', 'V', 'O' },
                                       { 'N', 'O', 'T' }};
      Tester(tablet, false);
    }
    [Test]
    public void Test03()
    {
      char[,] tablet = new char[3, 3] {{ 'T', 'A', 'T' },
                                       { 'A', 'M', 'A' },
                                       { 'G', 'A', 'G' }};
      Tester(tablet, false);
    }
    [Test]
    public void Test04()
    {
      char[,] tablet = new char[3, 3] {{ 'A', 'A', 'A' },
                                       { 'A', 'G', 'A' },
                                       { 'A', 'A', 'A' }};
      Tester(tablet, true);
    }
    [Test]
    public void Test05()
    {
      char[,] tablet = new char[3, 3] {{ 'A', 'M', 'A' },
                                       { 'M', 'O', 'M' },
                                       { 'A', 'M', 'A' }};
      Tester(tablet, true);
    }
    [Test]
    public void Test06()
    {
      char[,] tablet = new char[3, 3] {{ 'A', 'M', 'A' },
                                       { 'A', 'A', 'A' },
                                       { 'A', 'A', 'A' }};
      Tester(tablet, false);
    }
    [Test]
    public void Test07()
    {
      char[,] tablet = new char[4, 4] {{'O', 'T', 'T', 'O'},
                                       {'T', 'O', 'O', 'T'},
                                       {'T', 'O', 'O', 'T'},
                                       {'O', 'T', 'T', 'O'}};
      Tester(tablet, true);
    }   
    [Test]
    public void Test08()
    {
      char[,] tablet = new char[4, 4] {{'P', 'R', 'E', 'P'},
                                       {'R', 'I', 'M', 'E'},
                                       {'E', 'M', 'I', 'R'},
                                       {'P', 'E', 'R', 'P'}};
      Tester(tablet, true);
    }           
    [Test]
    public void Test09()
    {
      char[,] tablet = new char[4, 4] {{'B', 'A', 'T', 'S'},
                                       {'U', 'B', 'U', 'T'},
                                       {'T', 'U', 'B', 'U'},
                                       {'S', 'T', 'A', 'B'}};
      Tester(tablet, false);
    }
    [Test]
    public void Test10()
    {
      char[,] tablet = new char[4, 4] {{'P', 'A', 'L', 'S'},
                                       {'A', 'B', 'U', 'L'},
                                       {'T', 'U', 'B', 'A'},
                                       {'S', 'T', 'A', 'P'}};
      Tester(tablet, false);
    }
    [Test]
    public void Test11()
    {
      char[,] tablet = new char[4, 4] {{'B', 'A', 'T', 'S'},
                                       {'A', 'B', 'U', 'T'},
                                       {'T', 'U', 'B', 'U'},
                                       {'S', 'T', 'U', 'B'}};
      Tester(tablet, false);
    }
    [Test]
    public void Test12()
    {
      char[,] tablet = new char[5, 5] {{'S', 'A', 'T', 'O', 'R'},
                                       {'A', 'R', 'I', 'P', 'O'},
                                       {'T', 'E', 'N', 'E', 'T'},
                                       {'O', 'P', 'I', 'R', 'A'},
                                       {'R', 'O', 'T', 'A', 'S'}};
      Tester(tablet, false);
    }
    [Test]
    public void Test13()
    {
      char[,] tablet = new char[5, 5] {{'S', 'A', 'T', 'O', 'R'},
                                       {'A', 'R', 'E', 'P', 'O'},
                                       {'T', 'A', 'N', 'A', 'T'},
                                       {'O', 'P', 'E', 'R', 'A'},
                                       {'R', 'O', 'T', 'A', 'S'}};
      Tester(tablet, false);
    }
    [Test]
    public void Test14()
    {
      char[,] tablet = new char[5, 5] {{'S', 'A', 'T', 'O', 'R'},
                                       {'A', 'R', 'E', 'P', 'O'},
                                       {'T', 'E', 'N', 'E', 'T'},
                                       {'O', 'P', 'E', 'R', 'A'},
                                       {'R', 'O', 'T', 'A', 'S'}};
      Tester(tablet, true);
    }
    [Test]
    public void Test15()
    {
      char[,] tablet = new char[5, 5] {{'X', 'X', 'X', 'X', 'X'},
                                       {'X', 'X', 'X', 'X', 'X'},
                                       {'X', 'X', 'X', 'X', 'X'},
                                       {'X', 'X', 'X', 'X', 'X'},
                                       {'X', 'X', 'X', 'X', 'X'}};
      Tester(tablet, true);
    }
  }
  
  [TestFixture]
  public class Random_Tests
  {
    private static void Tester(char[,] tablet, bool expected)
    {
      bool submitted = Kata.Solution.IsSatorSquare(tablet);
      string message = "";
      if(submitted != expected)
      {
        int n = tablet.GetLength(0);
        StringBuilder square = new StringBuilder("\n", (n + 3) * (n + 3));
        foreach(int i in Enumerable.Range(0, n))
        {
          StringBuilder row = new StringBuilder("", (n + 3));
          foreach(int j in Enumerable.Range(0, n))
          {
            row.Append(tablet[i, j] + " ");
          }
          square.AppendLine(row.ToString());
        }
        message = square.ToString();
      }
      Assert.AreEqual(expected, submitted, message);
    }
    private bool ArepoSolution(char[,] tablet)
    {
      int n = (int)Math.Sqrt(tablet.Length);
      int d = n / 2;
      int m = n - 1;
      for(int r=0; r<d; r++)
      {
        for(int c=r; c<n-r; c++)
        {
          int y = m - r;
          int x = m - c;
          char current = tablet[r,c];
          if ( current != tablet[c,r] ||
               current != tablet[y,x] ||
               current != tablet[x,y] ) return false;
        }
      }
      return true;
    }    

    private int[,] DoubleFours = new int[20, 4]
    {
      {0, 1, 1, 0}, {0, 1, 1, 3}, {0, 1, 2, 0}, {0, 1, 2, 3},
      {0, 1, 3, 2}, {0, 2, 1, 0}, {0, 2, 1, 3}, {0, 2, 2, 0},
      {0, 2, 2, 3}, {0, 2, 3, 1}, {1, 0, 2, 3}, {1, 0, 3, 1},
      {1, 0, 3, 2}, {1, 3, 2, 0}, {1, 3, 3, 1}, {1, 3, 3, 2},
      {2, 0, 3, 1}, {2, 0, 3, 2}, {2, 3, 3, 1}, {2, 3, 3, 2}
    };
    
    private int[,] DoubleFives = new int[31, 4]
    {
      {0, 1, 1, 0}, {0, 1, 1, 4}, {0, 1, 3, 0}, {0, 1, 3, 4},
      {0, 1, 4, 2}, {0, 1, 4, 3}, {0, 2, 2, 0}, {0, 2, 2, 4},
      {0, 2, 4, 2}, {0, 3, 1, 0}, {0, 3, 1, 4}, {0, 3, 3, 0},
      {0, 3, 3, 4}, {0, 3, 4, 1}, {1, 0, 3, 4}, {1, 0, 4, 1},
      {1, 0, 4, 3}, {1, 2, 2, 1}, {1, 2, 2, 3}, {1, 2, 3, 2},
      {1, 4, 3, 0}, {1, 4, 4, 1}, {1, 4, 4, 3}, {2, 0, 2, 4},
      {2, 0, 4, 2}, {2, 1, 2, 3}, {2, 1, 3, 2}, {2, 3, 3, 2},
      {2, 4, 4, 2}, {3, 0, 4, 1}, {3, 0, 4, 3}
    };
    
    [Test]
    public void Tests()
    {
      System.Random rand = new System.Random();
      int[] indices = Enumerable.Range(0, 200).ToArray();
      indices = indices.OrderBy(x => rand.Next()).ToArray();
      for(int test=0; test<200; test++)
      {
        int index = indices[test];
        int p = index > 99 ? 0 : (index > 50 ? 1 : (index > 19 ? 3 : 2));
        int randN = p == 3 ? 5 : (p == 2 ? 4 : rand.Next(31) + 3);
        char[,] randTablet = new char[randN, randN];
        int i = randN - 1;
        int d = randN / 2;
        int m = randN % 2;
        char randChar;
        for(int r=0; r<d; r++)
        {
          for(int c=r; c<randN-r; c++)
          {
            int y = i - r;
            int x = i - c;
            randChar = (char)(rand.Next(26) + 65);
            randTablet[r, c] = randChar;
            randTablet[c, r] = randChar;
            randTablet[y, x] = randChar;
            randTablet[x, y] = randChar;
          }
        }
        if(m != 0)
        {
          randChar = (char)(rand.Next(26) + 65);
          randTablet[d, d] = randChar;
        }
        if(p > 0)
        {
          char randFlaw = (char)(rand.Next(26) + 65);
          if(p == 1)
          {
            int reps = rand.Next(2) == 1 ? 3 : 1;
            while(reps --> -1)
            {
              int _0 = rand.Next(randN);
              int _1 = rand.Next(randN);
              while(randFlaw == randTablet[_0, _1])
              {
                randFlaw = (char)(rand.Next(26) + 65);
              }
              randTablet[_0, _1] = randFlaw;
            }
          }
          else
          {
            int _0, _1, _2, _3;
            if(p == 2)
            {
              _0 = DoubleFours[index, 0];
              _1 = DoubleFours[index, 1];
              _2 = DoubleFours[index, 2];
              _3 = DoubleFours[index, 3];
            }
            else
            {
              _0 = DoubleFives[index - 20, 0];
              _1 = DoubleFives[index - 20, 1];
              _2 = DoubleFives[index - 20, 2];
              _3 = DoubleFives[index - 20, 3];
            }
            while(randFlaw == randTablet[_0, _1])
            {
              randFlaw = (char)(rand.Next(26) + 65);
            }
            randTablet[_0, _1] = randFlaw;
            while(randFlaw == randTablet[_2, _3])
            {
              randFlaw = (char)(rand.Next(26) + 65);
            }
            randTablet[_2, _3] = randFlaw;
          }
        }
        bool expected = ArepoSolution(randTablet);
        Tester(randTablet, expected);
      }
    }
  }
}
