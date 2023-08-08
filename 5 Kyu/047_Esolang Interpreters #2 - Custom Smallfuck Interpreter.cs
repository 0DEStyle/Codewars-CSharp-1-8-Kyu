/*Challenge link:https://www.codewars.com/kata/58678d29dbca9a68d80000d7/train/csharp
Question:
The Language
Smallfuck is an esoteric programming language/Esolang invented in 2002 which is a sized-down variant of the famous Brainfuck Esolang. Key differences include:

Smallfuck operates only on bits as opposed to bytes
It has a limited data storage which varies from implementation to implementation depending on the size of the tape
It does not define input or output - the "input" is encoded in the initial state of the data storage (tape) and the "output" should be decoded in the final state of the data storage (tape)
Here are a list of commands in Smallfuck:

> - Move pointer to the right (by 1 cell)
< - Move pointer to the left (by 1 cell)
* - Flip the bit at the current cell
[ - Jump past matching ] if value at current cell is 0
] - Jump back to matching [ (if value at current cell is nonzero)
As opposed to Brainfuck where a program terminates only when all of the commands in the program have been considered (left to right), Smallfuck terminates when any of the two conditions mentioned below become true:

All commands have been considered from left to right
The pointer goes out-of-bounds (i.e. if it moves to the left of the first cell or to the right of the last cell of the tape)
Smallfuck is considered to be Turing-complete if and only if it had a tape of infinite length; however, since the length of the tape is always defined as finite (as the interpreter cannot return a tape of infinite length), its computational class is of bounded-storage machines with bounded input.

More information on this Esolang can be found here.

The Task
Implement a custom Smallfuck interpreter interpreter() (interpreter in Haskell and F#, Interpreter in C#, custom_small_fuck:interpreter/2 in Erlang) which accepts the following arguments:

code - Required. The Smallfuck program to be executed, passed in as a string. May contain non-command characters. Your interpreter should simply ignore any non-command characters.
tape - Required. The initial state of the data storage (tape), passed in as a string. For example, if the string "00101100" is passed in then it should translate to something of this form within your interpreter: [0, 0, 1, 0, 1, 1, 0, 0]. You may assume that all input strings for tape will be non-empty and will only contain "0"s and "1"s.
Your interpreter should return the final state of the data storage (tape) as a string in the same format that it was passed in. For example, if the tape in your interpreter ends up being [1, 1, 1, 1, 1] then return the string "11111".

NOTE: The pointer of the interpreter always starts from the first (leftmost) cell of the tape, same as in Brainfuck.

Good luck :D
*/

//***************Solution********************
using System;
using System.Linq;

public class Smallfuck {
  
  //function to check block 
  //code , pointer, and direction
  private static int MatchBlock(string code, int p, int dir) {
    var b = dir;
    while (b != 0) {
      p += dir;
      if (code[p] == '[') b++;
      else if (code[p] == ']') b--;
    }
    return p;
  }
  
  public static string Interpreter(string code, string tape) {
    
    //store all '1's into data array
    var data = tape.Select(x => x == '1').ToArray();
    // data pointer and code pointer
    var dp = 0; 
    var cp = 0; 
    
    while (cp >= 0 && cp < code.Length && dp >= 0 && dp < data.Length) {
      
      //shift right by 1 cell
      if (code[cp] == '>') dp++;
      //shift left by 1 cell
      else if (code[cp] == '<') dp--;
      //invert the bit of current cell (bool)
      else if (code[cp] == '*') data[dp] = !data[dp];
      //check block direction to the right
      else if (code[cp] == '[' && !data[dp]) cp = MatchBlock(code, cp, 1) - 1;
      //check block direction to the left
      else if (code[cp] == ']' && data[dp]) cp = MatchBlock(code, cp, -1);
      //add 1 to code pointer and go to next iteration.
      cp++;
    }
    //turn bool value true of false into 1 and 0
    return new String(data.Select(x => x ? '1' : '0').ToArray());
  }
}


//method 2
using System.Text;

public class Smallfuck
{
  public static string Interpreter(string code, string tape)
  {
    var output = new StringBuilder(tape);
    int pos = 0;
    
    for (int i = 0; i < code.Length; ++i)
    {
      char c = code[i];
      switch (c)
      {
        case '<':
          --pos;
          if (pos < 0) { goto done; }
          break;
        case '>':
          ++pos;
          if (pos >= output.Length) { goto done; }
          break;
        case '*':
          output[pos] = output[pos] == '0' ? '1' : '0';
          break;
        case '[':
          if (output[pos] == '0') 
          {
            int stack = 1;
            for (++i; i < code.Length; ++i)
            {
              if (code[i] == '[') { ++stack; }
              if (code[i] == ']') { --stack; }
              if (stack == 0) { break; }
            }
          }
          break;
        case ']':
          if (output[pos] != '0') 
          {
            int stack = 1;
            for (--i; i >= 0; --i)
            {
              if (code[i] == ']') { ++stack; }
              if (code[i] == '[') { --stack; }
              if (stack == 0) { break; }
            }
          }
          break;
      }
    }
    
done:
    return output.ToString();
  }
}

//****************Sample Test*****************
namespace Solution {
  using NUnit.Framework;
  using System;
  using System.Linq;
  using System.Text;

  [TestFixture, Description("Your interpreter")]
  public class InterpreterTest
  {
    private static Random rng = new Random();
  
    [Test, Description("should work for some example test cases")]
    public void ExampleTest()
    {
      Action[] tests = new Action[]
      {
        // Flips the leftmost cell of the tape
        () => Assert.AreEqual("10101100", Smallfuck.Interpreter("*", "00101100")),
        // Flips the second and third cell of the tape
        () => Assert.AreEqual("01001100", Smallfuck.Interpreter(">*>*", "00101100")),
        // Flips all the bits in the tape
        () => Assert.AreEqual("11010011", Smallfuck.Interpreter("*>*>*>*>*>*>*>*", "00101100")),
        // Flips all the bits that are initialized to 0
        () => Assert.AreEqual("11111111", Smallfuck.Interpreter("*>*>>*>>>*>*", "00101100")),
        // Goes somewhere to the right of the tape and then flips all bits that are initialized to 1, progressing leftwards through the tape
        () => Assert.AreEqual("00000000", Smallfuck.Interpreter(">>>>>*<*<<*", "00101100")),
      };
      tests.OrderBy(x => rng.Next()).ToList().ForEach(a => a.Invoke());
    }
    
    // Translator's note: For easier debugging, I decided not to shuffle other tests
    [Test, Description("should ignore all non-command characters")]
    public void InvalidCharTest()
    {
      Assert.AreEqual("10101100", Smallfuck.Interpreter("iwmlis *!BOSS 333 ^v$#@", "00101100"), "Your interpreter should ignore all non-command characters");
      Assert.AreEqual("01001100", Smallfuck.Interpreter(">*>*;;;.!.,+-++--!!-!!!-", "00101100"), "Your interpreter should not treat any of \"+\", \"-\", \",\", \".\" (valid brainfuck commands) and \";\" as valid command characters");
      Assert.AreEqual("11010011", Smallfuck.Interpreter("    *  >\n    *           >\n\t\n\n*>*lskdfjsdklfj>*;;+--+--+++--+-+-  lskjfiom,x\t\n>*sdfsdf>sdfsfsdfsdfwervbnbvn*,.,.,,.,.  >\n\n\n*", "00101100"), "Your interpreter should ignore all tabs, newlines and spaces");
      Assert.AreEqual("11111111", Smallfuck.Interpreter("*,,...,..,..++-->++++-*>--+>*>+++->>..,+-,*>*", "00101100"));
      Assert.AreEqual("00000000", Smallfuck.Interpreter(">>nssewww>>wwess>*<nnn*<<ee*", "00101100"), "Your interpreter should not recognise any of \"n\", \"e\", \"s\", \"w\" (all valid Paintfuck commands) as valid commands");
    }
    
    [Test, Description("should return the final state of the tape immediately if the pointer ever goes out of bounds")]
    public void BoundsTest()
    {
      Assert.AreEqual("1001101000000111", Smallfuck.Interpreter("*>>>*>*>>*>>>>>>>*>*>*>*>>>**>>**", "0000000000000000"), "Your interpreter should return the final state of the tape immediately when the pointer moves too far to the right");
      Assert.AreEqual("0000000000000000", Smallfuck.Interpreter("<<<*>*>*>*>*>>>*>>>>>*>*", "0000000000000000"), "Your interpreter should immediately return the final state of the tape at the first instance where the pointer goes out of bounds to the left even if it resumes to a valid position later in the program");
      Assert.AreEqual("00011011110111111111111111111111", Smallfuck.Interpreter("*>*>*>>>*>>>>>*<<<<<<<<<<<<<<<<<<<<<*>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>*>*>*", "11111111111111111111111111111111"));
      Assert.AreEqual("1110", Smallfuck.Interpreter(">>*>*>*<<*<*<<*>*", "1101"), "Your interpreter should not follow through any command after the pointer goes out of bounds for the first time");
    }
    
    [Test, Description("should work for some simple and nested loops")]
    public void LoopTest()
    {
      Assert.AreEqual(new String('1', 256), Smallfuck.Interpreter("*[>*]", new String('0', 256)), "Your interpreter should evaluate a simple non-nested loop properly");
      Assert.AreEqual(new String('0', 256), Smallfuck.Interpreter("[>*]", new String('0', 256)), "Your interpreter should jump to the matching \"]\" when it encounters a \"[\" and the bit under the pointer is 0");
      Assert.AreEqual("11001100001" + new String('0', 245), Smallfuck.Interpreter("*>*>>>*>*>>>>>*>[>*]", new String('0', 256)), "Your interpreter should jump to the matching \"]\" when it encounters a \"[\" and the bit under the pointer is 0");
      Assert.AreEqual("11001100001" + new String('1', 245), Smallfuck.Interpreter("*>*>>>*>*>>>>>*[>*]", new String('0', 256)), "Your interpreter should jump back to the matching \"[\" when it encounters a \"]\" and the bit under the pointer is nonzero");
      Assert.AreEqual("1" + new String('0', 255), Smallfuck.Interpreter("*[>[*]]", new String('0', 256)), "Your interpreter should also work properly with nested loops");
      Assert.AreEqual("0" + new String('1', 255), Smallfuck.Interpreter("*[>[*]]", new String('1', 256)), "Your interpreter should also work properly with nested loops");
      Assert.AreEqual("000", Smallfuck.Interpreter("[[]*>*>*>]", "000"), "Your interpreter should also work properly with nested loops");
      Assert.AreEqual("100", Smallfuck.Interpreter("*>[[]*>]<*", "100"), "Your interpreter should also work properly with nested loops");
      Assert.AreEqual("01100", Smallfuck.Interpreter("[*>[>*>]>]", "11001"), "Your interpreter should also work properly with nested loops");
      Assert.AreEqual("10101", Smallfuck.Interpreter("[>[*>*>*>]>]", "10110"), "Your interpreter should also work properly with nested loops");
    }
    
    private static string Solution(string code, string tape)
    {
      // Convert tape to an array of boolean values
      bool[] tapeArr = tape.ToCharArray().Select(v => v == '0' ? false : true).ToArray();
      
      // Variables which keep track of tape/code index
      int tapePtr = 0;
      int codePtr = 0;
      
      // Main execution loop
      while (true) 
      {
    
        // If we're out of bounds, stop execution
        if (tapePtr < 0 || tapePtr >= tape.Length || codePtr >= code.Length) { break; }
        
        switch (code[codePtr]) 
        {
          case '*':                                         // '*': Flip the bit at the current cell
            tapeArr[tapePtr] = !tapeArr[tapePtr];
            ++codePtr;
            break;
          case '>':                                         // '>': Move pointer to the right (by 1 cell)
            ++tapePtr;
            ++codePtr;
            break;
          case '<':                                         // '<': Move pointer to the left (by 1 cell)
            --tapePtr;
            ++codePtr;
            break;
          case '[':                                         // '[': Jump past matching ']' if value at current cell is (0)
          {                                                 
            if (tapeArr[tapePtr])                             // If cell is true (1), break out of this op
            {                          
              ++codePtr;
              break;
            }
            
            int stack = 1;                                    // Declare a stack to keep track of matching brackets
            while (stack != 0)                                // Loop while we have brackets in our stack      
            {                                   
              ++codePtr;                                        // Iterate through the code
              if (code[codePtr] == '[') { ++stack; }            // If we see another '[', add it to our stack
              else if (code[codePtr] == ']') { --stack; }       // Conversely, if we see a ']', remove it from our stack
            }
            ++codePtr;                                        // Increment the code pointer one more time (to break out of the code's loop)
            break;
          }
          case ']':                                         // ']': Jump back to matching '[' if value at current cell is nonzero (1)
          {                                                 
            if (!tapeArr[tapePtr])                            // If cell is false (0), break out of this op
            {                                                 
              ++codePtr;
              break;
            }
            
            int stack = 1;                                    // Declare a stack to keep track of matching brackets
            while (stack != 0)                                // Loop while we have brackets in our stack
            {                                    
              --codePtr;                                        // Iterate backwards through the code
              if (code[codePtr] == ']') { ++stack; }            // If we see another ']', add it to our stack
              else if (code[codePtr] == '[') { --stack; }       // Conversely, if we see a '[', remove it from our stack
            }
            break;
          }
          default:                                          // If we see an unrecognized opcode, skip it
            ++codePtr;
            break;
        }
      }
      
      // Return the new tape as a string
      return String.Concat(tapeArr.Select(v => v ? '1' : '0'));
    }
    
    private static string RandomProgram()
    {
      StringBuilder code = new StringBuilder(rng.Next(101, 1001));
      
      for (int i = 0; i < code.Capacity; ++i)
      {
        code.Append("<*>"[rng.Next(0, 3)]);
      }
      
      return code.ToString();
    }
    
    private static string RandomTape()
    {
      StringBuilder tape = new StringBuilder(1000);
      
      for (int i = 0; i < tape.Capacity; ++i)
      {
        tape.Append("01"[rng.Next(0, 2)]);
      }
      
      return tape.ToString();
    }
    
    [Test, Description("should work for randomly-generated programs")]
    public void RandomTest()
    {
      for (int i = 0; i < 100; ++i)
      {
        string program = new String('>', 500) + RandomProgram();
        string tape = RandomTape();
        string expected = Solution(program, tape);
        string actual = Smallfuck.Interpreter(program, tape);
        Assert.AreEqual(expected, actual);
      }
    }
  }
}
