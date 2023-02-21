/*Challenge link:https://www.codewars.com/kata/568018a64f35f0c613000054/train/csharp
Question:
Imagine you are creating a game where the user has to guess the correct number. But there is a limit of how many guesses the user can do.

If the user tries to guess more than the limit, the function should throw an error.
If the user guess is right it should return true.
If the user guess is wrong it should return false and lose a life.
Can you finish the game so all the rules are met?


*/

//***************Solution********************

//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;

public class Guesser
{
    private int number;
    private int lives;

    public Guesser(int number, int lives)
    {
        this.number = number;
        this.lives = lives;
    }

    public bool Guess(int n)
    {
      if (lives == 0) throw new Exception("throw some random exception I guessssssss lol");
      if(n == number)
        return true;
        else 
          lives--;
      return false;
    }
}

//****************Sample Test*****************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

[TestFixture]
public class KataTest
{
    private Random random = new Random();

    public class Solution
    {
        private int number;
        private int lives;
    
        public Solution(int number, int lives)
        {
            this.number = number;
            this.lives = lives;
        }
    
        public bool Guess(int n)
        {
            if (this.lives > 0 && this.number == n)
            {
                return true;
            }
            else if (this.lives == 0)
            {
                throw new Exception("dead");
            }
            this.lives--;
    
            return false;
        }
    }
    [Test]
    public void _0_Correct_Guess_Should_Return_True()
    {
        Guesser guesser = new Guesser(10, 2);
        guesser.Guess(10);
        guesser.Guess(10);
        guesser.Guess(10);
        guesser.Guess(10);
        Assert.IsTrue(guesser.Guess(10));
    }
    
    [Test]
    public void _1_Wrong_Guess_Should_Return_False()
    {
        Guesser guesser = new Guesser(10, 2);
        guesser.Guess(1);
        Assert.IsFalse(guesser.Guess(1));
    }
    
    [Test]
    public void _3_Lives_Ran_Out_Should_Throw()
    {
        Guesser guesser = new Guesser(10, 2);
        guesser.Guess(1);
        guesser.Guess(2);
        
        bool pass = false;
        try
        {
            guesser.Guess(10);
        }
        catch
        {
            pass = true;
        }
        
        Assert.IsTrue(pass, "Expected error thrown");
    }
    
    [Test]
    public void _4_RandomTests()
    {
        int rnd = random.Next(15);
        int l = random.Next(20);
        
        Solution solution = new Solution(rnd, l);
        Guesser guesser = new Guesser(rnd, l);

        for (int j = 0; j < 20; ++j)
        {
            int g = random.Next(15);
            
            bool pass = false;
            try
            {
                var s = solution.Guess(g);
                var r = guesser.Guess(g);
          
                Assert.AreEqual(s, r);
                pass = s == r;
            }
            catch
            {
                try
                {
                    guesser.Guess(g);
                }
                catch
                {
                    pass = true;
                }
            }
            Assert.IsTrue(pass, "Expected error thrown");
        }
    }
}
