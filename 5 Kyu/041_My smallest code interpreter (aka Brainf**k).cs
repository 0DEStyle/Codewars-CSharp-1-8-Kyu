/*Challenge link:https://www.codewars.com/kata/526156943dfe7ce06200063e/train/csharp
Question:
Inspired from real-world Brainf**k, we want to create an interpreter of that language which will support the following instructions:

> increment the data pointer (to point to the next cell to the right).
< decrement the data pointer (to point to the next cell to the left).
+ increment (increase by one, truncate overflow: 255 + 1 = 0) the byte at the data pointer.
- decrement (decrease by one, treat as unsigned byte: 0 - 1 = 255 ) the byte at the data pointer.
. output the byte at the data pointer.
, accept one byte of input, storing its value in the byte at the data pointer.
[ if the byte at the data pointer is zero, then instead of moving the instruction pointer forward to the next command, jump it forward to the command after the matching ] command.
] if the byte at the data pointer is nonzero, then instead of moving the instruction pointer forward to the next command, jump it back to the command after the matching [ command.
The function will take in input...

the program code, a string with the sequence of machine instructions,
the program input, a string, possibly empty, that will be interpreted as an array of bytes using each character's ASCII code and will be consumed by the , instruction
... and will return ...

the output of the interpreted code (always as a string), produced by the . instruction.
Implementation-specific details for this Kata:

Your memory tape should be large enough - the original implementation had 30,000 cells but a few thousand should suffice for this Kata
Each cell should hold an unsigned byte with wrapping behavior (i.e. 255 + 1 = 0, 0 - 1 = 255), initialized to 0
The memory pointer should initially point to a cell in the tape with a sufficient number (e.g. a few thousand or more) of cells to its right. For convenience, you may want to have it point to the leftmost cell initially
You may assume that the , command will never be invoked when the input stream is exhausted
Error-handling, e.g. unmatched square brackets and/or memory pointer going past the leftmost cell is not required in this Kata. If you see test cases that require you to perform error-handling then please open an Issue in the Discourse for this Kata (don't forget to state which programming language you are attempting this Kata in).
*/

//***************Solution********************
using System.Collections.Generic;

public static class Kata{
  public static string BrainLuck(string code, string input, string outp = ""){
    var data = new byte[32];
    
    //instructions
    for(int i = 0, inP = 0, p = 0; i < code.Length; i++){
      if (code[i] == '>')  p++;
      if (code[i] == '<')  p--;
      if (code[i] == '+')  data[p]++;
      if (code[i] == '-')  data[p]--;
      if (code[i] == '.')  outp += (char)data[p];
      if (code[i] == ',')  data[p] = (byte)input[inP++];
      
      //pair "[" and "]"
      if (code[i] == '[' & data[p] == 0) i = BMatch(code, i, -1, 1,']');
      if (code[i] == ']' & data[p] != 0) i = BMatch(code, i, 1, -1, '[');
    }
    return outp;
  }
  
  private static int BMatch(string s, int i, int b, int dir, char pair){
    if (s[i] == pair && b == 0) return i; 
    if (s[i] == '[') b++;
    if (s[i] == ']') b--;
    return BMatch(s, i+dir, b, dir, pair);
  }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;

[TestFixture]
    public class BrainLuckTest
    {
        [Test]
        public void test1()
        {
            Assert.AreEqual("Hello World!", Kata.BrainLuck("++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.",""), "Should return \"Hello World!\" ");
        }
        
        private string randomString1 = Guid.NewGuid().ToString();
        [Test]
        public void test2()
        {
            Assert.AreEqual(randomString1, Kata.BrainLuck(",[.[-],]", randomString1 + char.ConvertFromUtf32(0)), "Should return "+ randomString1);
        }

        [Test]
        public void test3()
        {
            Assert.AreEqual("Codewars", Kata.BrainLuck(",+[-.,+]","Codewars"+char.ConvertFromUtf32(255)), "Should return \"Codewars\" ");
        }

        Random random = new Random();
        [Test]
        public void test4()
        {
            int A = random.Next(0, 15);
            int B = random.Next(0, 15);
            Assert.AreEqual(char.ConvertFromUtf32(A*B), Kata.BrainLuck(",>,<[>[->+>+<<]>>[-<<+>>]<<<-]>>.", char.ConvertFromUtf32(A) + char.ConvertFromUtf32(B)), "Should return "+ char.ConvertFromUtf32(A*B));
        }

        [Test]
        public void test5()
        {
            Assert.AreEqual("1, 1, 2, 3, 5, 8, 13, 21, 34, 55", Kata.BrainLuck(",>+>>>>++++++++++++++++++++++++++++++++++++++++++++>++++++++++++++++++++++++++++++++<<<<<<[>[>>>>>>+>+<<<<<<<-]>>>>>>>[<<<<<<<+>>>>>>>-]<[>++++++++++[-<-[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<[>>>+<<<-]>>[-]]<<]>>>[>>+>+<<<-]>>>[<<<+>>>-]+<[>[-]<[-]]>[<<+>>[-]]<<<<<<<]>>>>>[++++++++++++++++++++++++++++++++++++++++++++++++.[-]]++++++++++<[->-<]>++++++++++++++++++++++++++++++++++++++++++++++++.[-]<<<<<<<<<<<<[>>>+>+<<<<-]>>>>[<<<<+>>>>-]<-[>>.>.<<<[-]]<<[>>+>+<<<-]>>>[<<<+>>>-]<<[<+>-]>[<+>-]<<<-]", char.ConvertFromUtf32(10)), "Should return \"1, 1, 2, 3, 5, 8, 13, 21, 34, 55\" ");
        }

    }
