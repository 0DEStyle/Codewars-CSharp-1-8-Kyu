/*Challenge link:https://www.codewars.com/kata/5a3dd29055519e23ec000074/train/csharp
Question:
The first input array is the key to the correct answers to an exam, like ["a", "a", "b", "d"]. The second one contains a student's submitted answers.

The two arrays are not empty and are the same length. Return the score for this array of answers, giving +4 for each correct answer, -1 for each incorrect answer, and +0 for each blank answer, represented as an empty string (in C the space character is used).

If the score < 0, return 0.

For example:

checkExam(["a", "a", "b", "b"], ["a", "c", "b", "d"]) → 6
checkExam(["a", "a", "c", "b"], ["a", "a", "b",  ""]) → 7
checkExam(["a", "a", "b", "c"], ["a", "a", "b", "c"]) → 16
checkExam(["b", "c", "b", "a"], ["",  "a", "a", "c"]) → 0

*/

//***************Solution********************

//loop by arr1.Length
//if element in arr2 is empty, ans + 0
//if the element in arr1 is the same as arr2, ans + 4
//else ans -1
//if the answer is negative, return 0

using System;
public static class Kata{
    public static int CheckExam(string[] arr1, string[] arr2){
      int ans = 0;
      for(int i  = 0; i < arr1.Length; i++){
        if(arr2[i] == "")
          ans = ans;
        else if(arr1[i] == arr2[i])
          ans+=4;
        else
          ans--;
      }
      return ans < 0 ? 0 : ans;
    }
}

//solution 2
//Then simiplfied into one line by using an Lambda expression with Enumerable methods.
using System;
using System.Linq;

public static class Kata
{
  public static int CheckExam(string[] arr1, string[] arr2)
  {
    return Math.Max(arr2.Select((s, i) => s == "" ? 0 : s == arr1[i] ? 4 : -1).Sum(), 0);
  }
}

//****************Sample Test*****************
using System;
using System.Linq;
using NUnit.Framework;

[TestFixture]
public class KataTests
{
    [TestCase(new string[] { "a", "a", "b", "b" }, new string[] { "a", "c", "b", "d" }, 6)]
    [TestCase(new string[] { "a", "a", "c", "b" }, new string[] { "a", "a", "b", "" }, 7)]
    [TestCase(new string[] { "a", "a", "b", "c" }, new string[] { "a", "a", "b", "c" }, 16)]
    [TestCase(new string[] { "b", "c", "b", "a" }, new string[] { "", "a", "a", "c" }, 0)]
    public void SampleTest(string[] arr1, string[] arr2, int score)
    {
        Assert.AreEqual(score, Kata.CheckExam(arr1, arr2));
    }

    [Test]
    public void RandomTests1()
    {
        var letsAnswers = new string[] { "a", "b", "c", "d" };
        var letsStudent = new string[] { "a", "b", "c", "d", "" };

        for (int i = 0; i <= 100; i++)
        {
            string[] rndAnswers = new string[letsAnswers.Length];
            string[] rndStudent = new string[letsAnswers.Length];

            for (int j = 0; j < letsAnswers.Length; j++)
            {
                rndAnswers[j] = letsAnswers[Rnd.Next(0, letsAnswers.Length)];
                rndStudent[j] = letsStudent[Rnd.Next(0, letsStudent.Length)];
            }

            int expected = Solution(rndAnswers, rndStudent);
            string message = FailureMessage(rndAnswers, rndStudent, expected);
            int actual = Kata.CheckExam(rndAnswers, rndStudent);

            Assert.AreEqual(expected, actual, message);
        }
    }

    [Test]
    public void RandomTests2()
    {
        var letsAnswers = new string[] { "a", "b", "c", "d" };
        var letsStudent = new string[] { "a", "b", "c", "d", "" };

        for (int i = 0; i <= 100; i++)
        {
            int arrLength = Rnd.Next(4, 20);
            string[] rndAnswers = new string[arrLength];
            string[] rndStudent = new string[arrLength];

            for (int j = 0; j < arrLength; j++)
            {
                rndAnswers[j] = letsAnswers[Rnd.Next(0, letsAnswers.Length)];
                rndStudent[j] = letsStudent[Rnd.Next(0, letsStudent.Length)];
            }

            int expected = Solution(rndAnswers, rndStudent);
            string message = FailureMessage(rndAnswers, rndStudent, expected);
            int actual = Kata.CheckExam(rndAnswers, rndStudent);

            Assert.AreEqual(expected, actual, message);
        }
    }

    private static readonly Random Rnd = new Random();

    private static int Solution(string[] arr1, string[] arr2)
    {
        int sum = 0;
        for (int i = 0; i < arr2.Length; i++)
        {
            if (arr1[i] == arr2[i])
                sum += 4;
            else if (arr2[i] == "")
                sum += 0;
            else
                sum += -1;
        }

        return sum > 0 ? sum : 0;
    }

    private static string FailureMessage(string[] answers, string[] student, int value)
    {
        var joinAnswers = string.Join(", ", answers.Select(x => $"\"{x}\""));
        var joinStudent = string.Join(", ", student.Select(x => $"\"{x}\""));
        var result = $"Should return {value} with [{joinAnswers}] and [{joinStudent}]";
        return result;
    }
}
