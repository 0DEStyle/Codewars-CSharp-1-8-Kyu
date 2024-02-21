/*Challenge link:https://www.codewars.com/kata/56b5dd1702a30326ce000b02/train/csharp
Question:
Your task is to rotate a matrix 90 degree to the left. The matrix is an array of integers with dimension n,m. So this kata checks some basics, it's not too difficult.

There's nothing more to explain, no tricks, no "bad cases";-). Perhaps you take a look at the testcases...

One easy example:

Input: {{-1, 4, 5},
        { 2, 3, 4}}

Output: {{ 5, 4},
         { 4, 3},
         {-1, 2}}
First there are some static tests, later on random tests too...


Hope you have fun:-)!
*/

//***************Solution********************
/*
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
🟨⬛⬜🟨🟨🟨🟨🟨⬛⬜🟨
🟨⬛⬛🟨🟨🟨🟨🟨⬛⬛🟨
🟨⬛⬛🟨🟨⬛🟨🟨⬛⬛🟨
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟥🟥🟨🟨🟨⬛🟨🟨🟨🟥🟥
🟥🟥🟨🟨⬛🟨⬛🟨🟨🟥🟥
🟥🟨🟨🟨🟨🟨🟨🟨🟨🟨🟥
🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨🟨
*/
using System;
namespace smile67Kata{
    public class Kata{
        public int[,] rotateMatrixLeft(int[,] matrix){
          //get length of col and row
          //create new array to store rotated matrix
          var colLen = matrix.GetLength(1);
          var rowLen = matrix.GetLength(0);
          var newMatrix = new int[colLen, rowLen];
          
          //rotate matrix magic
          for(int i = 0; i < colLen; i++)
            for(int j = 0; j < rowLen; j++)
              newMatrix[i, j] = matrix[j, colLen - i - 1];
          return newMatrix;
        }
    }
}

//****************Sample Test*****************
namespace smile67Kata
{
    using NUnit.Framework;
    using System;
    [TestFixture]
    public class smile67KataTest
    {
        [Test]
        public void smile67KataTest_withoutRandom1()
        {
            int[,] oldMatrix = new int[4, 4] 
            {{-1,4,3,4},
             {5,6,7,8},
             {2,5,1,7},
             {3,14,-5,3}};
            int[,] newMatrix = new int[4, 4] 
            {{4,8,7,3},
             {3,7,1,-5},
             {4,6,5,14},
             {-1,5,2,3}};
            Assert.AreEqual(newMatrix, new Kata().rotateMatrixLeft(oldMatrix));
        }
        [Test]
        public void smile67KataTest_withoutRandom2()
        {
            int[,] oldMatrix = new int[2, 4] 
            {{-1,4,3,4},
             {5,6,7,8}};
            int[,] newMatrix = new int[4, 2] 
            {{4,8},
             {3,7},
             {4,6},
             {-1,5}};
            Assert.AreEqual(newMatrix, new Kata().rotateMatrixLeft(oldMatrix));
        }
        [Test]
        public void smile67KataTest_withoutRandom3()
        {
            int[,] oldMatrix = new int[1, 1] 
            {{-1}};
            int[,] newMatrix = new int[1, 1] 
            {{-1}};
            Assert.AreEqual(newMatrix, new Kata().rotateMatrixLeft(oldMatrix));
        }
        [Test]
        public void smile67KataTest_withoutRandom4()
        {
            int[,] oldMatrix = new int[4, 2] 
            {{-1,4},
             {5,6},
             {2,5},
             {-5,3}};
            int[,] newMatrix = new int[2, 4] 
            {{4,6,5,3},
             {-1,5,2,-5}};
            Assert.AreEqual(newMatrix, new Kata().rotateMatrixLeft(oldMatrix));
        }

        [Test]
        public void smile67Kata_Random_Tests()
        {
            Kata userClass = new Kata();
            string testResult = smile67Kata.Tests.testIt_adf02ad6_a228_4g19_9313_8aa900584458(ref userClass); //mit GUID verwenden, falls keine Random Tests in "Example Testcases" verwendent sind, sondern nur für "Testcases"
            if (testResult.Length > 0) Assert.Fail(testResult);
        }
    }
}	
