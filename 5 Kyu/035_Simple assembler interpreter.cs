/*Challenge link:https://www.codewars.com/kata/58e24788e24ddee28e000053/train/csharp
Question:
This is the first part of this kata series. Second part is here.

We want to create a simple interpreter of assembler which will support the following instructions:

mov x y - copies y (either a constant value or the content of a register) into register x
inc x - increases the content of the register x by one
dec x - decreases the content of the register x by one
jnz x y - jumps to an instruction y steps away (positive means forward, negative means backward, y can be a register or a constant), but only if x (a constant or a register) is not zero
Register names are alphabetical (letters only). Constants are always integers (positive or negative).

Note: the jnz instruction moves relative to itself. For example, an offset of -1 would continue at the previous instruction, while an offset of 2 would skip over the next instruction.

The function will take an input list with the sequence of the program instructions and will execute them. The program ends when there are no more instructions to execute, then it returns a dictionary (a table in COBOL) with the contents of the registers.

Also, every inc/dec/jnz on a register will always be preceeded by a mov on the register first, so you don't need to worry about uninitialized registers.

Example
["mov a 5"; "inc a"; "dec a"; "dec a"; "jnz a -1"; "inc a"]

visualized:

mov a 5
inc a
dec a
dec a
jnz a -1
inc a
The above code will:

set register a to 5,
increase its value by 1,
decrease its value by 2,
then decrease its value until it is zero (jnz a -1 jumps to the previous instruction if a is not zero)
and then increase its value by 1, leaving register a at 1
So, the function should return:

new Dictionary<string, int> { { "a" , 1 } };
This kata is based on the Advent of Code 2016 - day 12
*/

//***************Solution********************

using System;
using System.Collections.Generic;

namespace Solution{
    public static class SimpleAssembler{
        public static Dictionary<string, int> Interpret(string[] program){
          
          //create dictionary for memory(instruction, value)
          //GetValue function to test whether the input is a number or char
            var memory = new Dictionary<string, int>();
            int GetValue(string s) => int.TryParse(s, out var tmp) ? tmp : memory[s];
          
          //pointer to select statement
          //when pointed to the statement, split it and store in values
          //check the first instruction valuep[0] with switch case and perform function accordingly
          //"jnz" shift pinter by either positive or negative,
          //_ empty variable, throw exception if the input is anything else
            for (var pointer = 0; pointer < program.Length; pointer++){
                var values = program[pointer].Split();
                var _ = values[0] switch{
                    "mov" => memory[values[1]] = GetValue(values[2]),
                    "inc" => memory[values[1]]++,
                    "dec" => memory[values[1]]--,
                    "jnz" => pointer += GetValue(values[1]) != 0 ? GetValue(values[2]) - 1 : 0,
                    _ => throw new Exception("Input error")
                };
            }

            return memory;
        }
    }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;
using System.Collections.Generic;

namespace Solution
{    
    public static class TestUtil
    {
        public static void Test(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            var expectedStr = "{ " +
                              string.Join(", ", expected.Select(kv => $"{kv.Key}: {kv.Value}"))
                              + " }";
            var actualStr = "{ " +
                            string.Join(", ", actual.Select(kv => $"{kv.Key}: {kv.Value}"))
                            + " }";

            Assert.AreEqual(expected, actual, $"Expected: {expectedStr}, Actual: {actualStr}");
        }
    }

    public static class TestAssembler
    {
        public static Dictionary<string, int> Interpret(string[] program)
        {
            var pc = 0;
            var registers = new Dictionary<string, int>();
            int GetValue(string val) => int.TryParse(val, out var num) ? num : registers[val];
            var handlers = new Dictionary<string, Action<string[]>>
            {
                {"mov", (split) => registers[split[1]] = GetValue(split[2])},
                {"inc", (split) => registers[split[1]]++},
                {"dec", (split) => registers[split[1]]--},
                {"jnz", (split) => pc += (GetValue(split[1]) != 0 ? int.Parse(split[2]) : 1) - 1}
            };

            while (pc < program.Length)
            {
                var split = program[pc].Split(" ");
                handlers[split[0]](split);
                pc++;
            }

            return registers;
        }
    }

    [TestFixture, Description("Fixed tests")]
    public class FixedTests
    {
        private void Test(Dictionary<string, int> expected, Dictionary<string, int> actual)
        {
            var expectedStr = "{ " +
                              string.Join(", ", expected.Select(kv => $"{kv.Key}: {kv.Value}"))
                              + " }";
            var actualStr = "{ " +
                            string.Join(", ", actual.Select(kv => $"{kv.Key}: {kv.Value}"))
                            + " }";

            Assert.AreEqual(expected, actual, $"Expected: {expectedStr}, Actual: {actualStr}");
        }

        [Test, Description("Should work for some example programs")]
        public void ExamplePrograms()
        {
            Test(new Dictionary<string, int> {{"a", 1}},
                SimpleAssembler.Interpret(new[] {"mov a 5", "inc a", "dec a", "dec a", "jnz a -1", "inc a"}));
            Test(new Dictionary<string, int> {{"a", 0}, {"b", -20}},
                SimpleAssembler.Interpret(new[] {"mov a -10", "mov b a", "inc a", "dec b", "jnz a -2"}));
            Test(new Dictionary<string, int> {{"a", 318009}, {"b", 196418}, {"c", 0}, {"d", 0}},
                SimpleAssembler.Interpret(new[]
                    {
                        "mov a 1", "mov b 1", "mov c 0", "mov d 26", "jnz c 2", "jnz 1 5", "mov c 7", "inc d", "dec c",
                        "jnz c -2", "mov c a", "inc a", "dec b", "jnz b -2", "mov b c", "dec d", "jnz d -6", "mov c 18",
                        "mov d 11", "inc a", "dec d", "jnz d -2", "dec c", "jnz c -5"
                    }
                ));
            Test(new Dictionary<string, int> {{"d", 1}, {"b", 0}, {"a", 1}},
                SimpleAssembler.Interpret(new[]
                    {"mov d 100", "dec d", "mov b d", "jnz b -2", "inc d", "mov a d", "jnz 5 10", "mov c a"}));
            Test(new Dictionary<string, int> {{"c", 409600}, {"b", 409600}, {"a", 409600}},
                SimpleAssembler.Interpret(new[]
                {
                    "mov c 12", "mov b 0", "mov a 200", "dec a", "inc b", "jnz a -2", "dec c", "mov a b", "jnz c -5",
                    "jnz 0 1", "mov c a"
                }));
        }
    }
    
    [TestFixture, Description("Random tests")]
    public class RandomTests
    {
        private static Random rand = new Random();

        [Test, Description("Should work for some random programs")]
        public void RandomPrograms()
        {
            const string regs = "abcdefghijklmnopqrstuvwxyz";
            for (var i = 0; i < 100; i++)
            {
                var prog = new List<string>();
                var table = rand.NextDouble() < 0.5 ? new[] {"inc", "inc", "dec"} : new[] {"dec", "dec", "inc"};
                var regAB = new char[2];
                regAB[0] = regs[rand.Next(regs.Length)];
                do
                {
                    regAB[1] = regs[rand.Next(regs.Length)];
                } while (regAB[1] == regAB[0]);

                prog.Add($"mov {regAB[0]} {rand.Next(20, 400)}");
                prog.Add($"mov {regAB[1]} {rand.Next(0, 3)}");
                prog.Add($"jnz {regAB[1]} {rand.Next(2, 6)}");
                prog.Add($"jnz {regAB[0]} {rand.Next(2, 6)}");
                
                for (var q = 1; q < rand.Next(6, 16); q++)
                    prog.Add($"{table[rand.Next(table.Length)]} {regAB[rand.Next(regAB.Length)]}");
                
                var expected = TestAssembler.Interpret(prog.ToArray());
                var actual = SimpleAssembler.Interpret(prog.ToArray());
                TestUtil.Test(expected,actual);
            }
        }
    }
}
