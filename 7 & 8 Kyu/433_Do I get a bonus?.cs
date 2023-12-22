/*Challenge link:https://www.codewars.com/kata/56f6ad906b88de513f000d96/train/csharp
Question:
It's bonus time in the big city! The fatcats are rubbing their paws in anticipation... but who is going to make the most money?

Build a function that takes in two arguments (salary, bonus). Salary will be an integer, and bonus a boolean.

If bonus is true, the salary should be multiplied by 10. If bonus is false, the fatcat did not make enough money and must receive only his stated salary.

Return the total figure the individual will receive as a string prefixed with "£" (= "\u00A3", JS, Go, Java, Scala, and Julia), "$" (C#, C++, Ruby, Clojure, Elixir, PHP, Python, Haskell, and Lua) or "¥" (Rust).
*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression 
//ternary to condition result.
//string interpolation to format string.
public static class Kata{
        public static string bonus_time(int salary, bool bonus) => bonus == true ? $"${salary * 10}" : $"${salary}";
}

//solution 2
public static class Kata
{
    public static string bonus_time(int salary, bool bonus)
    {
        return $"${salary * (bonus ? 10 : 1)}";
    }
}

//****************Sample Test*****************
using System;
using NUnit.Framework;    
    
    [TestFixture]
    public class Test
    {
        [Test]
        public void BasicTest()
        {
            StringAssert.AreEqualIgnoringCase("$100000", Kata.bonus_time(10000, true));
            StringAssert.AreEqualIgnoringCase("$250000", Kata.bonus_time(25000, true));
            StringAssert.AreEqualIgnoringCase("$10000", Kata.bonus_time(10000, false));
            StringAssert.AreEqualIgnoringCase("$60000", Kata.bonus_time(60000, false));
            StringAssert.AreEqualIgnoringCase("$20", Kata.bonus_time(2, true));
            StringAssert.AreEqualIgnoringCase("$78", Kata.bonus_time(78, false));
            StringAssert.AreEqualIgnoringCase("$678900", Kata.bonus_time(67890, true));
        }


        [Test]
        public void RandomTest([Values(1)] int a, [Random(-1, 1, 40)] double d)
        {
            RgTest rg = new RgTest((int) d*10000);
            int salary = rg.Salary();
            bool bonus = rg.Bonus();
            string output = "";
            if (bonus)
            {
                output = "$" + (salary*10);
            }
            else
            {
                output = "$" + salary;
            }
            StringAssert.AreEqualIgnoringCase(output, Kata.bonus_time(salary,bonus));
        }
    }

    public class RgTest
    {
        static Random _random;
        private static int _counter;
        public RgTest(int seed)
        {
            _counter = _counter + 1;
            _random = new Random(seed + _counter);
        }

        public int Salary()
        {
            return _random.Next(1, 102);
        }

        public bool Bonus()
        {
            return _random.Next(0, 2) < 1;
        }
    }
