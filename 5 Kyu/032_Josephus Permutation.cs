/*Challenge link:https://www.codewars.com/kata/5550d638a99ddb113e0000a2/train/csharp
Question:
This problem takes its name by arguably the most important event in the life of the ancient historian Josephus: according to his tale, he and his 40 soldiers were trapped in a cave by the Romans during a siege.

Refusing to surrender to the enemy, they instead opted for mass suicide, with a twist: they formed a circle and proceeded to kill one man every three, until one last man was left (and that it was supposed to kill himself to end the act).

Well, Josephus and another man were the last two and, as we now know every detail of the story, you may have correctly guessed that they didn't exactly follow through the original idea.

You are now to create a function that returns a Josephus permutation, taking as parameters the initial array/list of items to be permuted as if they were in a circle and counted out every k places until none remained.

Tips and notes: it helps to start counting from 1 up to n, instead of the usual range 0 to n-1; k will always be >=1.

For example, with an array=[1,2,3,4,5,6,7] and k=3, the function should act this way.

[1,2,3,4,5,6,7] - initial sequence
[1,2,4,5,6,7] => 3 is counted out and goes into the result [3]
[1,2,4,5,7] => 6 is counted out and goes into the result [3,6]
[1,4,5,7] => 2 is counted out and goes into the result [3,6,2]
[1,4,5] => 7 is counted out and goes into the result [3,6,2,7]
[1,4] => 5 is counted out and goes into the result [3,6,2,7,5]
[4] => 1 is counted out and goes into the result [3,6,2,7,5,1]
[] => 4 is counted out and goes into the result [3,6,2,7,5,1,4]
So our final result is:

[3,6,2,7,5,1,4]
For more info, browse the Josephus Permutation page on wikipedia; related kata: Josephus Survivor.

Also, live game demo by OmniZoetrope.
*/

//***************Solution********************
using System.Collections.Generic;
public class Josephus{
   public static List<object> JosephusPermutation(List<object> items, int k){
     
       List<object> result = new List<object>();
       int pos = 0;
     
     //while item count is greater than 0
     //as the question stated, k start at 1, so shift pos by k-1 then mod item.Count
     //add items at pos into result, then remove the element in items at pos for next iteration
       while (items.Count > 0){
           pos = (pos + k - 1) % items.Count;
           result.Add(items[pos]);
           items.RemoveAt(pos);
       }
       return result;
   }
}

//****************Sample Test*****************
//the test case from java version
using NUnit.Framework;
using System;
using System.Collections.Generic;
public class JosephusTestSuit
{
    private static int NUM_RANDOM_TESTS = 40;
    private static int MAX_ITEMS = 50;
    private static int MAX_ITEM_VALUE = 200;
    private static int MAX_K = 20;

    [Test]
    public void Test1()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 1, new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });
    }

    [Test]
    public void Test2()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 }, 2, new object[] { 2, 4, 6, 8, 10, 3, 7, 1, 9, 5 });
    }

    [Test]
    public void Test3()
    {
        JosephusTest(new object[] { "C", "o", "d", "e", "W", "a", "r", "s" }, 4, new object[] { "e", "s", "W", "o", "C", "d", "r", "a" });
    }

    [Test]
    public void Test4()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7 }, 3, new object[] { 3, 6, 2, 7, 5, 1, 4 });
    }

    [Test]
    public void Test5()
    {
        JosephusTest(new object[] { }, 3, new object[] { });
    }

    [Test]
    public void Test6()
    {
        JosephusTest(new object[] { "C", 0, "d", 3, "W", 4, "r", 5 }, 4, new object[] { 3, 5, "W", 0, "C", "d", "r", 4 });
    }

    [Test]
    public void Test7()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50 }, 11, new object[] { 11, 22, 33, 44, 5, 17, 29, 41, 3, 16, 30, 43, 7, 21, 36, 50, 15, 32, 48, 14, 34, 1, 20, 39, 9, 28, 2, 25, 47, 24, 49, 27, 8, 38, 19, 6, 42, 35, 26, 23, 31, 40, 4, 18, 12, 13, 46, 37, 45, 10 });
    }

    [Test]
    public void Test8()
    {
        JosephusTest(new object[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 }, 40, new object[] { 10, 7, 8, 13, 5, 4, 12, 11, 3, 15, 14, 9, 1, 6, 2 });
    }

    [Test]
    public void Test9()
    {
        JosephusTest(new object[] { 1 }, 3, new object[] { 1 });
    }

    [Test]
    public void Test10()
    {
        JosephusTest(new object[] { true, false, true, false, true, false, true, false, true }, 9, new object[] { true, true, true, false, false, true, false, true, false });
    }

    [Test]
    public void RandomTest()
    {
        var random = new Random();
        for (int i = 0; i < NUM_RANDOM_TESTS; i++)
        {
            var items = new List<object>();
            for (int j = 0; j < random.Next(MAX_ITEMS); j++)
            {
                items.Add(random.Next(MAX_ITEM_VALUE));
            }
            int k = random.Next(MAX_K - 1) + 1;
            Assert.AreEqual(Solution(new List<object>(items), k), Josephus.JosephusPermutation(new List<object>(items), k));
        }
    }

    private void JosephusTest(object[] items, int k, object[] result)
    {
        Assert.AreEqual(new List<object>(result), Josephus.JosephusPermutation(new List<object>(items), k));
    }

    private List<object> Solution(List<object> items, int k)
    {
        var permutation = new List<object>();
        int position = 0;
        while (items.Count > 0)
        {
            position = (position + k - 1) % items.Count;
            var item = items[position];
            items.RemoveAt(position);
            permutation.Add(item);
        }
        return permutation;
    }
}
